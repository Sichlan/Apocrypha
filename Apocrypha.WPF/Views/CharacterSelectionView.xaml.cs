using Apocrypha.WPF.ViewModels;
using Wpf.Ui.Common.Interfaces;

namespace Apocrypha.WPF.Views;

/// <summary>
///     Interaction logic for CharacterSelectionView.xaml
/// </summary>
public partial class CharacterSelectionView : INavigableView<CharacterSelectionViewModel>
{
    public CharacterSelectionView(CharacterSelectionViewModel viewModel)
    {
        ViewModel = viewModel;
        InitializeComponent();
    }

    [Obsolete("Only for design purposes! Do not use!")]
    public CharacterSelectionView()
    {
        InitializeComponent();
    }

    public CharacterSelectionViewModel ViewModel { get; }
}