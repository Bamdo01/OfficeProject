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
using System.Windows.Shapes;

namespace NUPROJECT_vcs
{
    /// <summary>
    /// LoginWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("RG clicked!");
        }
        private void IdFind_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ID clicked!");
        }
        private void PwFind_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("PW clicked!");
        }
    }
}
