using Apocrypha.WPF.ViewModels;

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

    /// <inheritdoc/>
    public LoginViewModel ViewModel { get; }
}