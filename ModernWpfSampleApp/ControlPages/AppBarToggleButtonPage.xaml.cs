﻿using System.Windows;
using System.Windows.Controls.Primitives;
using ModernWpf.Controls;

namespace ModernWpf.SampleApp.ControlPages
{
    public partial class AppBarToggleButtonPage
    {
        AppBarToggleButton compactButton = null;
        AppBarSeparator separator = null;

        public AppBarToggleButtonPage()
        {
            InitializeComponent();
            Loaded += AppBarButtonPage_Loaded;
            Unloaded += AppBarToggleButtonPage_Unloaded;
        }

        private void AppBarToggleButtonPage_Unloaded(object sender, RoutedEventArgs e)
        {
            CommandBar appBar = NavigationRootPage.Current.TopCommandBar;
            compactButton.Click -= CompactButton_Click;
            appBar.PrimaryCommands.Remove(compactButton);
            appBar.PrimaryCommands.Remove(separator);
        }

        void AppBarButtonPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Add compact button to the command bar. It provides functionality specific
            // to this page, and is removed when leaving the page.

            CommandBar appBar = NavigationRootPage.Current.TopCommandBar;
            separator = new AppBarSeparator();
            appBar.PrimaryCommands.Insert(0, separator);

            compactButton = new AppBarToggleButton();
            compactButton.Icon = new SymbolIcon(Symbol.FontSize);
            compactButton.Label = "IsCompact";
            compactButton.Click += CompactButton_Click;
            appBar.PrimaryCommands.Insert(0, compactButton);
        }

        private void CompactButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton toggle = sender as ToggleButton;

            if (toggle != null && toggle.IsChecked != null)
            {
                Button1.IsCompact =
                    Button2.IsCompact =
                        Button3.IsCompact =
                            Button4.IsCompact = (bool)toggle.IsChecked;
            }
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            AppBarToggleButton b = sender as AppBarToggleButton;

            if (b != null)
            {
                string name = b.Name;

                switch (name)
                {
                    case "Button1":
                        Control1Output.Text = "IsChecked = " + b.IsChecked.ToString();

                        break;
                    case "Button2":
                        Control2Output.Text = "IsChecked = " + b.IsChecked.ToString();

                        break;
                    case "Button3":
                        Control3Output.Text = "IsChecked = " + b.IsChecked.ToString();

                        break;
                    case "Button4":
                        Control4Output.Text = "IsChecked = " + b.IsChecked.ToString();

                        break;
                }
            }
        }
    }
}