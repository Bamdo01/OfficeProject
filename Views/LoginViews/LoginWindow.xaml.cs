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
using System.Net.Sockets;

namespace WPFOfficeProject
{
    /// <summary>
    /// LoginWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    //public partial class LoginWindow : Window
    //{
    //    //private LoginViewModel _viewModel;  // ViewModel을 저장할 필드 추가 + 로그인 뷰 모델이 여기 로그인 윈도우에서 생성했는데 로그인 페이지에서도 객체를 생성하고 거기서 페이지를 바꾸려고하니깐 안되던거임

    //    public LoginWindow()
    //    {
    //        InitializeComponent();
    //        this.DataContext = new LoginViewModel();
    //    }
    //}
    public partial class LoginWindow : Window
    {
        public LoginViewModel ViewModel { get; private set; }  // ✅ ViewModel을 저장하는 필드 추가

        public LoginWindow()
        {
            InitializeComponent();
            ViewModel = new LoginViewModel();  // ✅ ViewModel을 한 번만 생성
            this.DataContext = ViewModel;  // ✅ Window의 DataContext로 설정
            LoginFrame.Content = new LoginPage(ViewModel);  // ✅ LoginPage에도 같은 ViewModel 전달
        }
    }



}
