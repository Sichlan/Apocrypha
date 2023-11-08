using Apocrypha.CommonObject.Models.Simulation.Agents;
using Apocrypha.CommonObject.Models.Simulation.Layers;
using Apocrypha.CommonObject.Services.Configuration;
using Apocrypha.CommonObject.Services.FileServices;
using Mars.Components.Starter;
using Mars.Core.Simulation;
using Mars.Core.Simulation.Entities;
using Mars.Interfaces.Model;
using Mars.Interfaces.Model.Options;
using Newtonsoft.Json;

// ReSharper disable StringLiteralTypo

namespace Apocrypha.CommonObject.Services.SimulationServices;

public class SimulationContainerService : ISimulationContainerService
{
    private readonly IZipFileService _zipFileService;
    private readonly IConfigurationService _configurationService;

    private SimulationConfig _simulationConfiguration;


    private readonly JsonSerializerSettings _jsonSerializerSettings = new()
    {
        PreserveReferencesHandling = PreserveReferencesHandling.Objects,
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        Formatting = Formatting.Indented
    };


    public SimulationContainerService(IZipFileService zipFileService, IConfigurationService configurationService)
    {
        _zipFileService = zipFileService;
        _configurationService = configurationService;
    }

    /// <inheritdoc/>
    public string GetOutputDirectory()
    {
        return $@"{_configurationService.ApocryphaConfiguration.AppDataRootDirectory}\Configurations\Active";
    }

    public event ISimulationContainerService.SimulationInitiatedEventHandler OnSimulationInitiated;
    public event ISimulationContainerService.SimulationStepEventHandler OnSimulationStep;
    public event ISimulationContainerService.SimulationConfigChangedHandler OnSimulationConfigChanged;

    #region Properties

    public ModelDescription ModelDescription { get; private set; }

    public SimulationConfig SimulationConfiguration
    {
        get => _simulationConfiguration;
        private set
        {
            _simulationConfiguration = value;
            OnSimulationConfigChanged?.Invoke(this);
        }
    }

    public ISimulation Simulation { get; private set; }
    public SimulationWorkflowState CurrentSimulationWorkflowState { get; private set; }

    #endregion

    /// <inheritdoc />
    public async Task LoadSimulationConfiguration(string filePath)
    {
        if (!File.Exists(filePath))
            throw new ArgumentException("Path does not exist!");

        var outputDirectory = GetOutputDirectory();
        var configPath = outputDirectory + "\\config.json";

        await _zipFileService.ReadSimulationConfigurationArchive(filePath, outputDirectory);

        if (!File.Exists(configPath))
            throw new FileNotFoundException("Can't find config file in archive");

        var fileContent = string.Join('\n', (await File.ReadAllLinesAsync(configPath)).Where(x => !x.Contains("outputKind") && !x.Contains("encoding")));
        var simulationConfig = JsonConvert.DeserializeObject<SimulationConfig>(fileContent, _jsonSerializerSettings);

        if (simulationConfig == null)
            throw new NullReferenceException("Deserialized config was null!");

        await LoadSimulationConfiguration(simulationConfig);
        ModelDescription = null;
    }

    /// <inheritdoc />
    public async Task LoadSimulationConfiguration(SimulationConfig config)
    {
        await Task.Run(() =>
        {
            AnnihilateSimulation();

            var outputDirectory = GetOutputDirectory();

            LayerMapping cellsLayer, riversLayer, routesLayer, markersLayer;

            if ((cellsLayer = config.LayerMappings.FirstOrDefault(x => x.Name == nameof(GisCellsLayer))) == null)
                throw new ArgumentException("No cells layer found!");
            if ((riversLayer = config.LayerMappings.FirstOrDefault(x => x.Name == nameof(GisRiverLayer))) == null)
                throw new ArgumentException("No rivers layer found!");
            if ((routesLayer = config.LayerMappings.FirstOrDefault(x => x.Name == nameof(GisRoutesLayer))) == null)
                throw new ArgumentException("No routes layer found!");
            if ((markersLayer = config.LayerMappings.FirstOrDefault(x => x.Name == nameof(GisMarkersLayer))) == null)
                throw new ArgumentException("No markers layer found!");

            cellsLayer.File = $@"{outputDirectory}\cells\cells.geojson";
            riversLayer.File = $@"{outputDirectory}\rivers\rivers.geojson";
            routesLayer.File = $@"{outputDirectory}\routes\routes.geojson";
            markersLayer.File = $@"{outputDirectory}\markers\markers.geojson";

            Directory.CreateDirectory(Path.GetDirectoryName(cellsLayer.File)!);
            Directory.CreateDirectory(Path.GetDirectoryName(riversLayer.File)!);
            Directory.CreateDirectory(Path.GetDirectoryName(routesLayer.File)!);
            Directory.CreateDirectory(Path.GetDirectoryName(markersLayer.File)!);

            SimulationConfiguration = config;
        });
    }

    /// <inheritdoc />
    public async Task SaveSimulationConfiguration(string path)
    {
        if (SimulationConfiguration == null)
            throw new NullReferenceException(nameof(SimulationConfiguration) + " may not be null!");

        LayerMapping cellsLayer, riversLayer, routesLayer, markersLayer;

        if ((cellsLayer = SimulationConfiguration.LayerMappings.FirstOrDefault(x => x.Name == nameof(GisCellsLayer))) == null)
            throw new ArgumentException("No cells layer found!");
        if ((riversLayer = SimulationConfiguration.LayerMappings.FirstOrDefault(x => x.Name == nameof(GisRiverLayer))) == null)
            throw new ArgumentException("No rivers layer found!");
        if ((routesLayer = SimulationConfiguration.LayerMappings.FirstOrDefault(x => x.Name == nameof(GisRoutesLayer))) == null)
            throw new ArgumentException("No routes layer found!");
        if ((markersLayer = SimulationConfiguration.LayerMappings.FirstOrDefault(x => x.Name == nameof(GisMarkersLayer))) == null)
            throw new ArgumentException("No markers layer found!");

        var directoryPath = Path.GetDirectoryName(path);

        if (string.IsNullOrEmpty(directoryPath))
            throw new DirectoryNotFoundException();

        string cellsPath = cellsLayer.File,
            riversPath = riversLayer.File,
            routesPath = routesLayer.File,
            markersPath = markersLayer.File;

        // var config = SimulationConfiguration.Serialize();
        var config = JsonConvert.SerializeObject(SimulationConfiguration, _jsonSerializerSettings);

        Directory.CreateDirectory(directoryPath);

        await _zipFileService.CreateSimulationConfigurationArchive(path,
            config,
            cellsPath,
            riversPath,
            routesPath,
            markersPath);
    }

    /// <inheritdoc />
    public void InitSimulation()
    {
        if (SimulationConfiguration == null)
            throw new NullReferenceException($"{nameof(SimulationConfiguration)} may not be null!");

        ModelDescription ??= InitModelDescription();

        Simulation = SimulationStarter.Build(ModelDescription, SimulationConfiguration);
        CurrentSimulationWorkflowState = Simulation.PrepareSimulation(ModelDescription, SimulationConfiguration);

        OnSimulationInitiated?.Invoke(this);
    }

    public void AnnihilateSimulation()
    {
        SimulationConfiguration = null;
        Simulation?.Dispose();
        ModelDescription = null;
        CurrentSimulationWorkflowState?.Dispose();
    }

    private ModelDescription InitModelDescription()
    {
        var description = new ModelDescription
        {
            SimulationConfig = SimulationConfiguration
        };

        description.AddLayer<GisCellsLayer>();
        description.AddLayer<GisRiverLayer>();
        description.AddLayer<GisRoutesLayer>();
        description.AddLayer<GisMarkersLayer>();
        // description.AddLayer<AgentLayer>();

        // description.AddAgent<ManualAgent, AgentLayer>();

        return description;
    }

    public static SimulationConfig GenerateExampleConfiguration()
    {
        return new SimulationConfig
        {
            Globals = new Globals
            {
                Steps = long.MaxValue,
                OutputTarget = OutputTargetType.Csv,
                CsvOptions = new CsvOptions
                {
                    Delimiter = ";",
                    NumberFormat = "en-EN"
                }
            },
            LayerMappings = new List<LayerMapping>
            {
                new()
                {
                    Name = nameof(GisCellsLayer),
                    File =
                        $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\EconomySimulator\Configurations\Active\cells\cells.geojson"
                }
            },
            AgentMappings = new List<AgentMapping>
            {
                new()
                {
                    Name = nameof(ManualAgent),
                    InstanceCount = 1
                }
            },
            Execution = new Execution
            {
                NodeNumber = 0
            }
        };
    }
}