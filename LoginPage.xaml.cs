using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
    /// LoginPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginPage : Page
    {
        private RegisterPage regPage;

        public LoginPage()
        {
            regPage = new RegisterPage(this);
            InitializeComponent();
        }
        private void LoginClick(object sender, RoutedEventArgs e)
        {
            
            NUPServerConnector connector = new NUPServerConnector();
            connector.SendUserLogin(txtId.Text,txtPw.Text, LoginOk, LoginNg);

        }
        private void LoginOk(string res)
        {
            MessageBox.Show("로그인 성공 *** 환영합니다");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            Window parent = Window.GetWindow(this);
            parent.Close();
        }

        private void LoginNg(string res)
        {
            MessageBox.Show("로그인 실패 하였습니다.");
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Window parent = Window.GetWindow(this);
            (parent as LoginWindow).LoginFrame.NavigationService.Navigate(regPage);
        }
        private void IdFind_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ID clicked!");
            //아이디 찾기 로직부분
        }
        private void PwFind_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("PW clicked!");
            //비밀번호 찾기 로직 부분
        }
    }
}
