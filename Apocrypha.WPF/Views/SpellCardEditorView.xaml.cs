using System.Windows;
using System.Windows.Controls;
using Apocrypha.CommonObject.Models.Spells;
using Apocrypha.WPF.ViewModels;

namespace Apocrypha.WPF.Views;

public partial class SpellCardEditorView
{
    public SpellCardEditorView()
    {
        InitializeComponent();
    }

    private void ToggleButton_ToggleChecked(object sender, RoutedEventArgs e)
    {
        if (sender is not CheckBox {DataContext: SpellSchool spellSchool} checkBox || DataContext is not SpellCardEditorViewModel context)
            return;

        context.AddOrRemoveSpellSchool(spellSchool, checkBox.IsChecked.GetValueOrDefault(false));
        context.SpellCardViewModel.OnPropertyChanged(nameof(SpellCardViewModel.BackgroundBrush));
        context.SpellCardViewModel.OnPropertyChanged(nameof(SpellCardViewModel.SpellSchoolString));
    }
}