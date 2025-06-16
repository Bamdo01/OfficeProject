using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WPFOfficeProject.Models;
using WPFOfficeProject.Views;

namespace WPFOfficeProject.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public LoginViewModel() // 생성자
        {
            //// 처음에 로드할 페이지 설정
            //FrameSource = "LoginPage.xaml";
            //MessageBox.Show($"FrameSource 변경됨: {FrameSource}"); // 로그 출력인데 이거 없애면 오류 발생함??....왜지

            //// 로그인 및 회원가입 커맨드 초기화
            //LoginCommand = new RelayCommand(ExecuteLogin /*, CanExecuteLogin*/);  // 나중에 검사 추가 가능
            //RegisterCommand = new RelayCommand(ExecuteRegister);
        }

        private string _frameSource; // 로그인 페이지 경로
        private string _userId; //아이디

        public string UserId //아이디 받아서 저장하는 함수
        {
            get => _userId;
            set
            {
                _userId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }


        public ICommand LoginCommand { get; private set; }
        public ICommand RegisterCommand { get; private set; }




        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
