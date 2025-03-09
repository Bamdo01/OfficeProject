using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace WPFOfficeProject
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private string _id;
        private string _password;
        private string _email;
        private string _address;
        private DateTime? _birthDate;
        private string _gender;
        private string _phone;

        public string Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }

        public string Address
        {
            get => _address;
            set { _address = value; OnPropertyChanged(nameof(Address)); }
        }

        public DateTime? BirthDate//DateTime?를 사용하면 null을 허용할 수 있음!
        {
            get => _birthDate;
            set { _birthDate = value; OnPropertyChanged(nameof(BirthDate)); }
        }

        public string Gender
        {
            get => _gender;
            set { _gender = value; OnPropertyChanged(nameof(Gender)); }
        }

        public string Phone
        {
            get => _phone;
            set { _phone = value; OnPropertyChanged(nameof(Phone)); }
        }

        public ICommand RegisterCommand { get; }
        public ICommand CancelCommand { get; }

        public RegisterViewModel()
        {
            RegisterCommand = new RelayCommand(ExecuteRegister);
            CancelCommand = new RelayCommand(ExecuteCancel);
        }

        private void ExecuteRegister(object parameter)
        {
            // 확인 버튼을 눌렀을 때 텍스트박스 값 가져오기
            // 나중에 서버로 쏴주면 된다
            MessageBox.Show($"회원가입 정보:\n" +
                            $"아이디: {Id}\n" +
                            $"비밀번호: {Password}\n" +
                            $"이메일: {Email}\n" +
                            $"주소: {Address}\n" +
                            $"생일: {BirthDate?.ToShortDateString()}\n" +
                            $"성별: {Gender}\n" +
                            $"전화번호: {Phone}");

            //원래 비하인드 코드에 있던 회원가입 코드임 나중에 참고하기
            // //private void ConfirnClick(object sender, RoutedEventArgs e)
            //{
            //    NUPServerConnector connector = new NUPServerConnector();
            //    connector.SendUserRegister(txtId.Text, txtPw.Text, txtEmail.Text, txtAddr.Text,dpBirth.DisplayDate,1, txtPhone.Text, RegisterOk, RegisterNg);
            //}
            //private void RegisterOk(string res)
            //{
            //    MessageBox.Show("회원가입 성공");
            //    MainWindow mainWindow = new MainWindow();
            //    mainWindow.Show();

            //    Window parent = Window.GetWindow(this);
            //    parent.Close();
            //}

            //private void RegisterNg(string res)
            //{
            //    MessageBox.Show("회원가입 실패 하였습니다.");
            //}

            //private void CancelClick(object sender, RoutedEventArgs e)
            //{
            //    Window parent = Window.GetWindow(this);
            //    (parent as LoginWindow).LoginFrame.NavigationService.Navigate(this.loginPage);
            //}
        }

        private void ExecuteCancel(object parameter)
        {
            MessageBox.Show("회원가입 취소");
            // 현재 창(Window)을 찾기
            Window window = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);

            if (window is LoginWindow loginWindow) // 로그인 창이 있으면
            {
                loginWindow.LoginFrame.Content = new LoginPage(loginWindow.ViewModel); // 로그인 페이지로 변경
            }
            else
            {
                MessageBox.Show("로그인 창을 찾을 수 없습니다.");
            }

           
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
