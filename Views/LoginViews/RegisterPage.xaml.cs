using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WPFOfficeProject
{
    /// <summary>
    /// RegisterPage.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 
    public partial class RegisterPage : Page
    {
        private LoginPage loginPage;

        public RegisterPage(LoginPage loginPage)
        {
            this.loginPage = loginPage;
            InitializeComponent();
        }

        private void ConfirnClick(object sender, RoutedEventArgs e)
        {
            NUPServerConnector connector = new NUPServerConnector();
            connector.SendUserRegister(txtId.Text, txtPw.Text, txtEmail.Text, txtAddr.Text,dpBirth.DisplayDate,1, txtPhone.Text, RegisterOk, RegisterNg);
        }
        private void RegisterOk(string res)
        {
            MessageBox.Show("회원가입 성공");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            Window parent = Window.GetWindow(this);
            parent.Close();
        }

        private void RegisterNg(string res)
        {
            MessageBox.Show("회원가입 실패 하였습니다.");
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            Window parent = Window.GetWindow(this);
            (parent as LoginWindow).LoginFrame.NavigationService.Navigate(this.loginPage);
        }
    }
}
