using Apocrypha.WPF.ViewModels;

namespace Apocrypha.WPF.Views;

/// <summary>
///     Interaction logic for RegistrationView.xaml
/// </summary>
public partial class RegistrationView : INavigableView<RegistrationViewModel>
{
    public RegistrationView(RegistrationViewModel viewModel)
    {
        ViewModel = viewModel;

        InitializeComponent();
    }

    /// <inheritdoc/>
    public RegistrationViewModel ViewModel { get; }
}