using System.Windows;

namespace ModernWpfSampleApp.ControlPages
{
    public partial class HyperlinkButtonPage
    {
        public HyperlinkButtonPage()
        {
            InitializeComponent();
        }

        private void GoToHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ListBoxPage));
        }
    }
}