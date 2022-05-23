using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Apocrypha.WPF.Annotations;

namespace Apocrypha.WPF.Controls
{
    public partial class MultiSelectComboBox : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty ItemSourceProperty = DependencyProperty.Register(
            "ItemSource", typeof(IEnumerable), typeof(MultiSelectComboBox), new PropertyMetadata(default(IEnumerable)));
        public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register(
            "SelectedItems", typeof(IEnumerable), typeof(MultiSelectComboBox), new PropertyMetadata(default(IEnumerable)));
        public static readonly DependencyProperty IsPopupOpenProperty = DependencyProperty.Register(
            "IsPopupOpen", typeof(bool), typeof(MultiSelectComboBox), new PropertyMetadata(default(bool)));

        public IEnumerable ItemSource
        {
            get => (IEnumerable)GetValue(ItemSourceProperty);
            set { SetValue(ItemSourceProperty, value); OnPropertyChanged();}
        }
        
        public IEnumerable SelectedItems
        {
            get => (IEnumerable)GetValue(SelectedItemsProperty);
            set { SetValue(SelectedItemsProperty, value); OnPropertyChanged();}
        }
        
        public bool IsPopupOpen
        {
            get => (bool)GetValue(IsPopupOpenProperty);
            set { SetValue(IsPopupOpenProperty, value); OnPropertyChanged();}
        }
        public MultiSelectComboBox()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}