using Apocrypha.WPF.ViewModels;
using Wpf.Ui.Common.Interfaces;

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

    [Obsolete("Only for design purposes! Do not use!")]
    public RegistrationView()
    {
        InitializeComponent();
    }

    /// <inheritdoc/>
    public RegistrationViewModel ViewModel { get; }
}