using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WPFOfficeProject.Models;
using WPFOfficeProject.Views;
using WPFOfficeProject.Services;

namespace WPFOfficeProject.ViewModels
{
    public class RegisterPageViewModel : INotifyPropertyChanged
    {
        // --- 모델 인스턴스 (사용자 정보를 여기에 저장합니다) ---
        private User _user;

        // --- 뷰에 바인딩될 속성들 (User 모델의 값을 가져오거나 설정합니다) ---

        public string Id
        {
            get => _user.Id;
            set
            {
                if (_user.Id != value)
                {
                    _user.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get => _user.Password;
            set
            {
                if (_user.Password != value)
                {
                    _user.Password = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Email
        {
            get => _user.Email;
            set
            {
                if (_user.Email != value)
                {
                    _user.Email = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Address
        {
            get => _user.Address;
            set
            {
                if (_user.Address != value)
                {
                    _user.Address = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime? BirthDate
        {
            get => _user.BirthDate;
            set
            {
                if (_user.BirthDate != value)
                {
                    _user.BirthDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Gender
        {
            get => _user.Gender;
            set
            {
                if (_user.Gender != value)
                {
                    _user.Gender = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Phone
        {
            get => _user.Phone;
            set
            {
                if (_user.Phone != value)
                {
                    _user.Phone = value;
                    OnPropertyChanged();
                }
            }
        }

        // --- 커맨드 (확인/취소 버튼에 바인딩될 로직) ---
        public ICommand RegisterCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        // --- 생성자 ---
        public RegisterPageViewModel()
        {
            _user = new User(); // 새 User 모델 인스턴스 생성 및 초기화

            // 커맨드 초기화 나중에 CanExecuteRegister 로직 완성하기
            //RegisterCommand = new RelayCommand(ExecuteRegister, CanExecuteRegister);
            RegisterCommand = new RelayCommand(ExecuteRegister);
            CancelCommand = new RelayCommand(ExecuteCancel);

            Debug.WriteLine("RegisterPageViewModel이 생성되었습니다.");
        }

        // --- 커맨드 실행 로직 ---

        private void ExecuteRegister(object parameter)
        {
            // 실제 회원가입 로직 (예: 유효성 검사, DB 저장 등)
            //Debug.WriteLine("회원가입 '확인' 버튼 클릭됨!");
            //Debug.WriteLine($"입력된 ID: {Id}, Email: {Email}, Phone: {Phone}");

            // TODO: 여기에 실제 회원가입 처리 로직을 구현합니다.
            // 성공 시 로그인 페이지로 이동하거나, 메인 대시보드로 이동합니다.
            // 실패 시 오류 메시지를 사용자에게 표시합니다.

            // 예시: 회원가입 성공 후 로그인 페이지로 돌아가기
            NavigationService.Instance.NavigateTo("LoginPage.xaml");
            MessageBox.Show("회원가입이 완료되었습니다!", "안내", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool CanExecuteRegister(object parameter)
        {
            // 회원가입 버튼 활성화 여부 판단 로직
            // 예: 필수 필드가 모두 입력되었는지 확인
            return !string.IsNullOrWhiteSpace(Id) &&
                   !string.IsNullOrWhiteSpace(Password) &&
                   !string.IsNullOrWhiteSpace(Email);
        }

        private void ExecuteCancel(object parameter)
        {
            Debug.WriteLine("회원가입 '취소' 버튼 클릭됨! 로그인 페이지로 이동.");
            // 로그인 페이지로 돌아가기
            NavigationService.Instance.NavigateTo("LoginPage.xaml");
        }

        // --- INotifyPropertyChanged 구현 ---
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
