using System.Windows;
using System.Windows.Controls;

namespace Apocrypha.ModernUi.Views.Users;

public partial class UserMessageView : UserControl
{
    public UserMessageView()
    {
        InitializeComponent();
    }

    private void ButtonDetailsOnClick(object sender, RoutedEventArgs e)
    {
        if (TextMessageDetails.Visibility == Visibility.Collapsed)
            TextMessageDetails.Visibility = Visibility.Visible;
        else
            TextMessageDetails.Visibility = Visibility.Collapsed;
    }
}