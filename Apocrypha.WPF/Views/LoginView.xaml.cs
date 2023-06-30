using Apocrypha.WPF.ViewModels;
using Wpf.Ui.Common.Interfaces;

namespace Apocrypha.WPF.Views;

/// <summary>
///     Interaction logic for LoginView.xaml
/// </summary>
public partial class LoginView : INavigableView<LoginViewModel>
{
    public LoginView(LoginViewModel viewModel)
    {
        ViewModel = viewModel;

        InitializeComponent();
    }

    [Obsolete("Only for design purposes! Do not use!")]
    public LoginView()
    {
        InitializeComponent();
    }

    /// <inheritdoc/>
    public LoginViewModel ViewModel { get; }
}