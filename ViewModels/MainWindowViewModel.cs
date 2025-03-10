using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFOfficeProject
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private Page _currentPage;

        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        public ICommand NavigateToMainCommand { get; }
        public ICommand NavigateToChatCommand { get; }
        public ICommand NavigateToFriendListCommand { get; }
        public ICommand NavigateToNotepadCommand { get; }
        public ICommand NavigateToScheduleCommand { get; }
        public ICommand LogoutCommand { get; }

        public MainWindowViewModel()
        {
            NavigateToMainCommand = new RelayCommand(_ => CurrentPage = new MainPage());
            NavigateToChatCommand = new RelayCommand(_ => CurrentPage = new ChatPage());
            NavigateToFriendListCommand = new RelayCommand(_ => CurrentPage = new FriendListPage());
            NavigateToNotepadCommand = new RelayCommand(_ => CurrentPage = new NotepadPage());
            //NavigateToScheduleCommand = new RelayCommand(_ => CurrentPage = new SchedulePage());
            NavigateToScheduleCommand = new RelayCommand(_ =>
            {
                Console.WriteLine("📌 일정 페이지로 이동"); // 로그 확인
                CurrentPage = new SchedulePage();
            });
            LogoutCommand = new RelayCommand(_ => Logout());

            // 기본 페이지 설정
            CurrentPage = new MainPage();
        }

        private void Logout()
        {
            // 로그인 페이지로 이동
            var loginWindow = new LoginWindow();
            loginWindow.Show();

            // 현재 메인 윈도우 닫기
            foreach (Window window in App.Current.Windows)
            {
                if (window is MainWindow)
                {
                    window.Close();
                    break;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
