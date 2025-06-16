using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFOfficeProject.Models;
using WPFOfficeProject.Services;
using WPFOfficeProject.Views;

namespace WPFOfficeProject.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        //기본생성자
        public LoginPageViewModel()
        {
            LoginCommand = new RelayCommand(ExecuteLogin /*, CanExecuteLogin*/);  // 나중에 검사 추가 가능
            RegisterCommand = new RelayCommand(ExecuteRegister);
        }

        public ICommand LoginCommand { get; private set; }
        public ICommand RegisterCommand { get; private set; }

        private void ExecuteLogin(object parameter) //로그인 버튼 이벤트
        {


            // 현재 실행 중인 `LoginWindow` 가져오기
            Window loginWindow = Application.Current.Windows.OfType<LoginWindow>().FirstOrDefault();

            if (loginWindow != null)
            {
                MainWindow mainWindow = new MainWindow(); // 메인 윈도우 생성
                mainWindow.Show();  // 메인 윈도우 표시
                loginWindow.Close();  // 기존 로그인 윈도우 닫기
            }
        }


        private void ExecuteRegister(object parameter)
        {
            NavigationService.Instance.NavigateTo("RegisterPage.xaml");

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
