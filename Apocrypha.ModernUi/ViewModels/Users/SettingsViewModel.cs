using System.Windows.Input;
using Apocrypha.ModernUi.Helpers;
using Apocrypha.ModernUi.Helpers.Commands.Navigation;
using Apocrypha.ModernUi.Themes.Presets;
using Apocrypha.ModernUi.ViewModels.Navigation;
using CommunityToolkit.Mvvm.Input;
using ModernWpf;

namespace Apocrypha.ModernUi.ViewModels.Users;

public class SettingsViewModel : NavigableViewModel
{
    public ICommand SwitchThemeCommand { get; }
    public ICommand SwitchPresetCommand { get; }

    public SettingsViewModel(NavigateToPageCommand navigateToPageCommand)
        : base(navigateToPageCommand)
    {
        SwitchThemeCommand = new RelayCommand<ApplicationTheme?>(ExecuteSwitchThemeCommand, CanExecuteSwitchThemeCommand);
        SwitchPresetCommand = new RelayCommand<string>(ExecuteSwitchPresetCommand, CanExecuteSwitchPresetCommand);
    }

    private bool CanExecuteSwitchPresetCommand(string obj)
    {
        return true;
    }

    private void ExecuteSwitchPresetCommand(string obj)
    {
        PresetManager.Current.ColorPreset = obj;
    }

    private bool CanExecuteSwitchThemeCommand(ApplicationTheme? theme)
    {
        return true;
    }

    private void ExecuteSwitchThemeCommand(ApplicationTheme? theme)
    {
        DispatcherHelper.RunOnMainThread(() =>
        {
            ThemeManager.Current.ApplicationTheme = theme;
        });
    }
}