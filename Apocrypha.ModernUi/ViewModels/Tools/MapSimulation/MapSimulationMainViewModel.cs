using System;
using System.IO;
using System.Windows.Media;
using Apocrypha.CommonObject.Services.Configuration;
using Apocrypha.CommonObject.Services.SimulationServices;
using Apocrypha.ModernUi.Helpers;
using Apocrypha.ModernUi.Helpers.Commands.Navigation;
using Apocrypha.ModernUi.ViewModels.Common;
using Apocrypha.ModernUi.ViewModels.Navigation;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using ModernWpf.Controls;

namespace Apocrypha.ModernUi.ViewModels.Tools.MapSimulation;

public class MapSimulationMainViewModel : NavigableViewModel
{
    private readonly ISimulationContainerService _simulationContainerService;
    private readonly IConfigurationService _configurationService;
    private readonly CreateViewModel<MapMainViewModel> _createViewModel;
    private MapMainViewModel _mapMainViewModel;

    public event Action OpenNewConfigDialog;

    public MapMainViewModel MapMainViewModel
    {
        get => _mapMainViewModel;
        set
        {
            if (Equals(value, _mapMainViewModel))
                return;

            _mapMainViewModel = value;
            OnPropertyChanged();
        }
    }

    public MapSimulationMainViewModel(NavigateToPageCommand navigateToPageCommand, ISimulationContainerService simulationContainerService,
        IConfigurationService configurationService, CreateViewModel<MapMainViewModel> createViewModel) : base(navigateToPageCommand)
    {
        _simulationContainerService = simulationContainerService;
        _configurationService = configurationService;
        _createViewModel = createViewModel;

        NewSimulationConfigurationCommand = new RelayCommand(ExecuteNewSimulationConfigurationCommand, CanExecuteNewSimulationConfigurationCommand);
        SaveSimulationConfigurationCommand = new RelayCommand(ExecuteSaveSimulationConfigurationCommand, CanExecuteSaveSimulationConfigurationCommand);
        LoadSimulationConfigurationCommand = new RelayCommand(ExecuteLoadSimulationConfigurationCommand, CanExecuteLoadSimulationConfigurationCommand);

        _simulationContainerService.OnSimulationConfigChanged += OnSimulationConfigChanged;
    }

    public override void OnNavigateTo()
    {
        base.OnNavigateTo();

        MapMainViewModel = _createViewModel();

        if (!Directory.Exists(_configurationService.ApocryphaConfiguration.AppDataRootDirectory))
            Directory.CreateDirectory(_configurationService.ApocryphaConfiguration.AppDataRootDirectory);
    }

    private static bool CanExecuteLoadSimulationConfigurationCommand()
    {
        return true;
    }

    private async void ExecuteLoadSimulationConfigurationCommand()
    {
        var openFileDialog = new OpenFileDialog
        {
            InitialDirectory = $"{_configurationService.ApocryphaConfiguration.AppDataRootDirectory}Configurations",
            RestoreDirectory = true,
            // Title = Localization.OpenDialogTitle,
            CheckFileExists = true,
        };

        if (openFileDialog.ShowDialog() != true)
            return;

        await _simulationContainerService.LoadSimulationConfiguration(openFileDialog.FileName);
        _simulationContainerService.InitSimulation();
    }

    private bool CanExecuteSaveSimulationConfigurationCommand()
    {
        return _simulationContainerService.SimulationConfiguration != null;
    }

    private void ExecuteSaveSimulationConfigurationCommand()
    {
        if (_simulationContainerService.SimulationConfiguration == null)
            return;

        var saveFileDialog = new SaveFileDialog
        {
            InitialDirectory = _configurationService.ApocryphaConfiguration.AppDataRootDirectory,
            RestoreDirectory = true,
            // Title = Localization.SaveDialogTitle,
            DefaultExt = "zip",
            CheckFileExists = false,
            CheckPathExists = true,
            // FileName = Localization.DefaultSaveConfigurationFileName
        };

        if (saveFileDialog.ShowDialog() == true)
        {
            _simulationContainerService.SaveSimulationConfiguration(saveFileDialog.FileName);
        }
    }

    private bool CanExecuteNewSimulationConfigurationCommand()
    {
        return true;
    }

    private async void ExecuteNewSimulationConfigurationCommand()
    {
        var content = new NewMapConfigurationViewModel(_simulationContainerService);

        var dialog = new ContentDialog()
        {
            Title = "TODO Title",
            Content = content,
            PrimaryButtonText = "TODO Ok",
            CloseButtonText = "TODO Cancel",
            DefaultButton = ContentDialogButton.Primary,
            Background = new SolidColorBrush(Color.FromArgb(100, 100, 100, 100)),
            IsShadowEnabled = false,
            FullSizeDesired = true
        };
        var result = await dialog.ShowAsync();

        switch (result)
        {
            case ContentDialogResult.None:
                break;
            case ContentDialogResult.Primary:
                await _simulationContainerService.LoadSimulationConfiguration(content.ToSimulationConfig());
                _simulationContainerService.InitSimulation();

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public IRelayCommand NewSimulationConfigurationCommand { get; }
    public IRelayCommand SaveSimulationConfigurationCommand { get; }
    public IRelayCommand LoadSimulationConfigurationCommand { get; }

    private void OnSimulationConfigChanged(ISimulationContainerService sender)
    {
        // call OnNotifyCanExecuteChanged for all commands here
        DispatcherHelper.RunOnMainThread(() =>
        {
            NewSimulationConfigurationCommand.NotifyCanExecuteChanged();
            SaveSimulationConfigurationCommand.NotifyCanExecuteChanged();
            LoadSimulationConfigurationCommand.NotifyCanExecuteChanged();
        });
    }
}