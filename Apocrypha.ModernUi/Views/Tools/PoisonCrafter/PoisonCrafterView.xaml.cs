using System.Windows;
using Apocrypha.ModernUi.ViewModels.Tools.PoisonCrafter;

namespace Apocrypha.ModernUi.Views.Tools.PoisonCrafter;

public partial class PoisonCrafterView
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