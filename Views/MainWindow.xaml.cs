using System;
using System.Windows;

namespace WPFOfficeProject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnFriendListItemClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new FriendListPage();
        }
        private void MainClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new MainPage();
        }

        private void OnChatClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ChatPage();
        }


    }
}
