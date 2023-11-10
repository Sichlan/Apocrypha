using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Apocrypha.CommonObject.Models.Simulation.Layers;
using Apocrypha.CommonObject.Services.SimulationServices;
using Apocrypha.ModernUi.Services.Map;
using Apocrypha.ModernUi.ViewModels.Common;
using CommunityToolkit.Mvvm.Input;
using Mars.Interfaces.Model;
using Mars.Interfaces.Model.Options;
using Microsoft.Win32;

namespace Apocrypha.ModernUi.ViewModels.Tools.MapSimulation;

/// <summary>
/// An enum defining all gis layer types.
/// </summary>
public enum GisLayerTypeEnum
{
    /// <summary>
    /// The Cells layer
    /// </summary>
    Cells = 0,


    /// <summary>
    /// The Rivers layer
    /// </summary>
    Rivers = 1,


    /// <summary>
    /// The Routes layer
    /// </summary>
    Routes = 2,


    /// <summary>
    /// The Markers layer
    /// </summary>
    Markers = 3,


    /// <summary>
    /// The Settlements layer
    /// </summary>
    Settlements = 4
}

public class NewMapConfigurationViewModel : BaseViewModel
{
    private string _gisCellsLayerFilePath;
    private string _gisRiversLayerFilePath;
    private string _gisRoutesLayerFilePath;
    private string _gisMarkersLayerFilePath;
    private string _gisSettlementsLayerFilePath;

    private readonly ISimulationContainerService _simulationContainerService;
    private readonly IExportCsvToGeoJsonsService _exportCsvToGeoJsonsService;

    /// <summary>
    /// The path to the cells geojson file.
    /// </summary>
    public string GisCellsLayerFilePath
    {
        get => _gisCellsLayerFilePath;
        set
        {
            if (value == _gisCellsLayerFilePath)
                return;

            _gisCellsLayerFilePath = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// The path to the rivers geojson file.
    /// </summary>
    public string GisRiversLayerFilePath
    {
        get => _gisRiversLayerFilePath;
        set
        {
            if (value == _gisRiversLayerFilePath)
                return;

            _gisRiversLayerFilePath = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// The path to the routes geojson file.
    /// </summary>
    public string GisRoutesLayerFilePath
    {
        get => _gisRoutesLayerFilePath;
        set
        {
            if (value == _gisRoutesLayerFilePath)
                return;

            _gisRoutesLayerFilePath = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// The path to the markers geojson file.
    /// </summary>
    public string GisMarkersLayerFilePath
    {
        get => _gisMarkersLayerFilePath;
        set
        {
            if (value == _gisMarkersLayerFilePath)
                return;

            _gisMarkersLayerFilePath = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// The path to the settlements geojson file.
    /// </summary>
    public string GisSettlementsLayerFilePath
    {
        get => _gisSettlementsLayerFilePath;
        set
        {
            if (value == _gisSettlementsLayerFilePath)
                return;

            _gisSettlementsLayerFilePath = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand<GisLayerTypeEnum> SelectFilePathCommand { get; }
    public RelayCommand ConvertCsvFileCommand { get; }

    /// <inheritdoc />
    public NewMapConfigurationViewModel(ISimulationContainerService simulationContainerService, IExportCsvToGeoJsonsService exportCsvToGeoJsonsService)
    {
        _simulationContainerService = simulationContainerService;
        _exportCsvToGeoJsonsService = exportCsvToGeoJsonsService;
        SelectFilePathCommand = new RelayCommand<GisLayerTypeEnum>(ExecuteSelectFilePathCommand);
        ConvertCsvFileCommand = new RelayCommand(ExecuteConvertCsvFileCommand);
    }

    private async void ExecuteConvertCsvFileCommand()
    {
        var openFileDialog = new OpenFileDialog
        {
            RestoreDirectory = true,
            // Title = Localization.OpenDialogTitle,
            CheckFileExists = true,
            Filter = "CSV|*.csv"
        };

        if (openFileDialog.ShowDialog() != true)
            return;

        var path = openFileDialog.FileName;

        GisSettlementsLayerFilePath = await _exportCsvToGeoJsonsService.ConvertFile(path);
    }

    private void ExecuteSelectFilePathCommand(GisLayerTypeEnum gisLayerTypeEnum)
    {
        var openFileDialog = new OpenFileDialog
        {
            RestoreDirectory = true,
            // Title = Localization.OpenDialogTitle,
            CheckFileExists = true,
            Filter = "GeoJSON|*.geojson|All files|*.*"
        };

        if (openFileDialog.ShowDialog() != true)
            return;

        var path = openFileDialog.FileName;

        switch (gisLayerTypeEnum)
        {
            case GisLayerTypeEnum.Cells:
                GisCellsLayerFilePath = path;

                break;
            case GisLayerTypeEnum.Rivers:
                GisRiversLayerFilePath = path;

                break;
            case GisLayerTypeEnum.Routes:
                GisRoutesLayerFilePath = path;

                break;
            case GisLayerTypeEnum.Markers:
                GisMarkersLayerFilePath = path;

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gisLayerTypeEnum), gisLayerTypeEnum, null);
        }
    }

    public SimulationConfig ToSimulationConfig()
    {
        PrepareFiles();

        var outputDirectory = _simulationContainerService.GetOutputDirectory();

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
                },
                MongoOptions = null
            },
            LayerMappings = new List<LayerMapping>
            {
                new()
                {
                    Name = nameof(GisCellsLayer),
                    File = outputDirectory + "\\cells\\cells.geojson"
                },
                new()
                {
                    Name = nameof(GisRiverLayer),
                    File = outputDirectory + "\\rivers\\rivers.geojson"
                },
                new()
                {
                    Name = nameof(GisRoutesLayer),
                    File = outputDirectory + "\\routes\\routes.geojson"
                },
                new()
                {
                    Name = nameof(GisMarkersLayer),
                    File = outputDirectory + "\\markers\\markers.geojson"
                },
                new()
                {
                    Name = nameof(GisSettlementLayer),
                    File = outputDirectory + "\\settlements\\settlements.geojson"
                },
            },
            AgentMappings = new List<AgentMapping>(),
            Execution = new Execution
            {
                NodeNumber = 0
            }
        };
    }

    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    private void PrepareFiles()
    {
        _simulationContainerService.AnnihilateSimulation();
        var outputDirectory = _simulationContainerService.GetOutputDirectory();

        if (Directory.Exists(outputDirectory))
            Directory.Delete(outputDirectory, true);

        string cellsFilePath = outputDirectory + "\\cells\\cells.geojson",
            riversFilePath = outputDirectory + "\\rivers\\rivers.geojson",
            routesFilePath = outputDirectory + "\\routes\\routes.geojson",
            markersFilePath = outputDirectory + "\\markers\\markers.geojson",
            settlementsFilePath = outputDirectory + "\\settlements\\settlements.geojson";

        Directory.CreateDirectory(Path.GetDirectoryName(cellsFilePath)!);
        Directory.CreateDirectory(Path.GetDirectoryName(riversFilePath)!);
        Directory.CreateDirectory(Path.GetDirectoryName(routesFilePath)!);
        Directory.CreateDirectory(Path.GetDirectoryName(markersFilePath)!);
        Directory.CreateDirectory(Path.GetDirectoryName(settlementsFilePath)!);

        if (string.IsNullOrWhiteSpace(GisCellsLayerFilePath)
            || string.IsNullOrWhiteSpace(GisRiversLayerFilePath)
            || string.IsNullOrWhiteSpace(GisRoutesLayerFilePath)
            || string.IsNullOrWhiteSpace(GisMarkersLayerFilePath))
            throw new FileNotFoundException("A layer's path was empty or null!" +
                                            $"\n cells: {GisCellsLayerFilePath}" +
                                            $"\n rivers: {GisRiversLayerFilePath}" +
                                            $"\n routes: {GisRoutesLayerFilePath}" +
                                            $"\n markers: {GisMarkersLayerFilePath}" +
                                            $"\n markers: {GisSettlementsLayerFilePath}");

        if (!File.Exists(GisCellsLayerFilePath)
            || !File.Exists(GisRiversLayerFilePath)
            || !File.Exists(GisRoutesLayerFilePath)
            || !File.Exists(GisMarkersLayerFilePath))
            throw new FileNotFoundException("A layer's file could not be found!" +
                                            $"\n cells: {GisCellsLayerFilePath}" +
                                            $"\n rivers: {GisRiversLayerFilePath}" +
                                            $"\n routes: {GisRoutesLayerFilePath}" +
                                            $"\n markers: {GisMarkersLayerFilePath}" +
                                            $"\n markers: {GisSettlementsLayerFilePath}");

        File.Copy(GisCellsLayerFilePath, cellsFilePath);
        File.Copy(GisRiversLayerFilePath, riversFilePath);
        File.Copy(GisRoutesLayerFilePath, routesFilePath);
        File.Copy(GisMarkersLayerFilePath, markersFilePath);
        File.Copy(GisSettlementsLayerFilePath, settlementsFilePath);
    }
}