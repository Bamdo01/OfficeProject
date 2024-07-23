using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NUPROJECT_vcs
{
    /// <summary>
    /// FriendListPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FriendListPage : Page
    {
        public FriendListPage()
        {
            InitializeComponent();
        }

        private void FriendAdd_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("친구추가 클릭");
            MainFrame.Content = new FriendAddPage();
        }
        private void FriendWaiting_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("친구추가 클릭");
            MainFrame.Content = new FriendWaitPage();
        }
        
    }
}
