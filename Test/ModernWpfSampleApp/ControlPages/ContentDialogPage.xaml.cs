﻿using System.Windows;
using ModernWpf.Controls;

namespace ModernWpfSampleApp.ControlPages
{
    public partial class ContentDialogPage
    {
        public ContentDialogPage()
        {
            InitializeComponent();
        }

        private async void ShowDialog_Click(object sender, RoutedEventArgs e)
        {
            ContentDialogExample dialog = new ContentDialogExample();
            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                DialogResult.Text = "User saved their work";
            }
            else if (result == ContentDialogResult.Secondary)
            {
                DialogResult.Text = "User did not save their work";
            }
            else
            {
                DialogResult.Text = "User cancelled the dialog";
            }
        }
    }
}