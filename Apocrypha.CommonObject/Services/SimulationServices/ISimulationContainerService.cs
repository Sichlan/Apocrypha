using Mars.Core.Simulation;
using Mars.Core.Simulation.Entities;
using Mars.Interfaces.Model;

namespace Apocrypha.CommonObject.Services.SimulationServices;

public interface ISimulationContainerService
{
    public delegate void SimulationInitiatedEventHandler(ISimulationContainerService sender);

    public delegate void SimulationStepEventHandler(ISimulationContainerService sender);

    public delegate void SimulationConfigChangedHandler(ISimulationContainerService sender);

    public event SimulationInitiatedEventHandler OnSimulationInitiated;
    public event SimulationStepEventHandler OnSimulationStep;
    public event SimulationConfigChangedHandler OnSimulationConfigChanged;


    ModelDescription ModelDescription { get; }
    SimulationConfig SimulationConfiguration { get; }

    ISimulation Simulation { get; }
    SimulationWorkflowState CurrentSimulationWorkflowState { get; }

    /// <summary>
    /// Loads a <see cref="SimulationConfiguration"/> from a given path and executes <see cref="LoadSimulationConfiguration(SimulationConfig)"/> with it.
    /// Note that to actually "load" the simulation into a displayable state, <see cref="InitSimulation"/> must be executed as well.
    /// </summary>
    /// <param name="configPath">The path to the config file.</param>
    /// <exception cref="ArgumentException">Throws an ArgumentException if the file path is invalid.</exception>
    Task LoadSimulationConfiguration(string configPath);

    /// <summary>
    /// Loads a <see cref="SimulationConfiguration"/> instance. 
    /// </summary>
    /// <param name="config"></param>
    Task LoadSimulationConfiguration(SimulationConfig config);

    /// <summary>
    /// Saves the current simulation configuration to the given path.
    /// </summary>
    /// <param name="path">The path to save the configuration at.</param>
    /// <exception cref="NullReferenceException">Throws an exception if no simulation is currently loaded.</exception>
    /// <exception cref="ArgumentException">Throws an exception if the path is invalid.</exception>
    Task SaveSimulationConfiguration(string path);

    /// <summary>
    /// Initializes the simulation and generates a <see cref="ModelDescription"/>, <see cref="ISimulation"/> and <see cref="SimulationWorkflowState"/>.
    /// </summary>
    void InitSimulation();

    /// <summary>
    /// Terminates the current simulation.
    /// </summary>
    void AnnihilateSimulation();

    /// <summary>
    /// Returns the path where the active configuration is exported to. 
    /// </summary>
    string GetOutputDirectory();
}