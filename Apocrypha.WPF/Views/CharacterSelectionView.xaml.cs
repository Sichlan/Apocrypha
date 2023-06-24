using Apocrypha.WPF.ViewModels;

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

    public CharacterSelectionViewModel ViewModel { get; }
}