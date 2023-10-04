using System.Windows;

namespace ModernWpfSampleApp.ControlPages
{
    public partial class CalendarPage
    {
        public CalendarPage()
        {
            InitializeComponent();
        }

        private void AddDatesInPastToBlackoutDates(object sender, RoutedEventArgs e)
        {
            calendar.BlackoutDates.AddDatesInPast();
        }
    }
}