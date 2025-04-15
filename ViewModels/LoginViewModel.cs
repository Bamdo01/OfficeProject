using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WPFOfficeProject.Models;

namespace WPFOfficeProject
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public LoginViewModel() // 생성자
        {
            // 처음에 로드할 페이지 설정
            FrameSource = "LoginPage.xaml";
            MessageBox.Show($"FrameSource 변경됨: {FrameSource}"); // 로그 출력인데 이거 없애면 오류 발생함??....왜지

            // 로그인 및 회원가입 커맨드 초기화
            LoginCommand = new RelayCommand(ExecuteLogin /*, CanExecuteLogin*/);  // 나중에 검사 추가 가능
            RegisterCommand = new RelayCommand(ExecuteRegister);
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
        public string FrameSource
        {
            get { return _frameSource; }
            set
            {
                _frameSource = value;
                OnPropertyChanged("FrameSource");
            }
        }

        public ICommand LoginCommand { get; private set; }
        public ICommand RegisterCommand { get; private set; }

        private void ExecuteLogin(object parameter) //로그인 버튼 이벤트
        {
            MessageBox.Show($"로그인 버튼 클릭"); // 로그인 버튼 로그 출력

            // 현재 실행 중인 `LoginWindow` 가져오기
            Window loginWindow = Application.Current.Windows.OfType<LoginWindow>().FirstOrDefault();

            UserModel.UserId = UserId;

            if (loginWindow != null)
            {
                MainWindow mainWindow = new MainWindow(); // 메인 윈도우 생성
                mainWindow.Show();  // 메인 윈도우 표시
                loginWindow.Close();  // 기존 로그인 윈도우 닫기
            }


            //로그인 로직 추가 부분


        }


        private void ExecuteRegister(object parameter)
        {
            if (FrameSource == null)
            {
                MessageBox.Show("FrameSource가 null입니다!");  // 디버깅용 메시지
            }
            else
            {
                MessageBox.Show($"FrameSource 변경됨: {FrameSource}"); // 로그 출력
            }


            FrameSource = "RegisterPage.xaml";  // 회원가입 페이지로 이동
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
