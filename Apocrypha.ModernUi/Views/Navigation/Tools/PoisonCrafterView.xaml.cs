using System.Windows;
using System.Windows.Controls;
using Apocrypha.ModernUi.ViewModels.Navigation.Tools;

namespace Apocrypha.ModernUi.Views.Navigation.Tools;

public partial class PoisonCrafterView : UserControl
{
    public PoisonCrafterView()
    {
        InitializeComponent();
    }

    private void PoisonCrafterView_OnLoaded(object sender, RoutedEventArgs e)
    {
        if (sender is PoisonCrafterView {DataContext: PoisonCrafterViewModel viewModel})
            viewModel.SavePoisonCommand.NotifyCanExecuteChanged();
    }
}