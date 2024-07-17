using System;
using System.Windows;

namespace NUPROJECT_vcs
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnFriendListItemClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new FirstPage();
        }

    }
}
