using System.Windows.Input;
using Apocrypha.CommonObject.Services.Configuration;
using Apocrypha.ModernUi.Helpers;
using Apocrypha.ModernUi.Helpers.Commands.Navigation;
using Apocrypha.ModernUi.Resources.Localization;
using Apocrypha.ModernUi.Themes.Presets;
using Apocrypha.ModernUi.ViewModels.Navigation;
using CommunityToolkit.Mvvm.Input;
using ModernWpf;

namespace Apocrypha.ModernUi.ViewModels.Users;

public class SettingsViewModel : NavigableViewModel
{
    private readonly IConfigurationService _configurationService;

    public override string ViewModelTitle => Localization.SettingsViewModelTitle;
    public ICommand SwitchThemeCommand { get; }
    public ICommand SwitchPresetCommand { get; }

    public SettingsViewModel(NavigateToPageCommand navigateToPageCommand, IConfigurationService configurationService)
        : base(navigateToPageCommand)
    {
        _configurationService = configurationService;
        SwitchThemeCommand = new RelayCommand<ApplicationTheme?>(ExecuteSwitchThemeCommand, CanExecuteSwitchThemeCommand);
        SwitchPresetCommand = new RelayCommand<string>(ExecuteSwitchPresetCommand, CanExecuteSwitchPresetCommand);
    }

    private bool CanExecuteSwitchPresetCommand(string obj)
    {
        return true;
    }

    private void ExecuteSwitchPresetCommand(string obj)
    {
        _configurationService.ApocryphaConfiguration.DesignConfiguration.ColorPreset = PresetManager.Current.ColorPreset = obj;
    }

    private bool CanExecuteSwitchThemeCommand(ApplicationTheme? theme)
    {
        return true;
    }

    private void ExecuteSwitchThemeCommand(ApplicationTheme? theme)
    {
        DispatcherHelper.RunOnMainThread(() =>
        {
            _configurationService.ApocryphaConfiguration.DesignConfiguration.ApplicationTheme = ThemeManager.Current.ApplicationTheme = theme;
        });
    }
}