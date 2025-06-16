using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices; // CallerMemberName을 위해 추가

namespace WPFOfficeProject.Services
{
    // sealed 키워드는 상속을 막아 싱글톤 패턴을 더 강력하게 만듭니다.
    public sealed class NavigationService : INotifyPropertyChanged
    {
        // 1. 유일한 인스턴스를 저장할 private static readonly 필드
        private static readonly NavigationService _instance = new NavigationService();

        // 2. 외부에서 생성자를 호출할 수 없도록 private으로 선언
        private NavigationService()
        {
            // 초기 페이지 경로 설정
            _currentFrameSource = "LoginPage.xaml"; // 서비스 초기화 시 기본값 설정
        }

        // 3. 유일한 인스턴스에 접근할 수 있는 public static 속성
        public static NavigationService Instance
        {
            get { return _instance; }
        }

        // --- 현재 Frame의 Source 경로를 저장할 속성 ---
        private string _currentFrameSource;
        public string CurrentFrameSource
        {
            get { return _currentFrameSource; }
            set
            {
                if (_currentFrameSource != value)
                {
                    _currentFrameSource = value;
                    OnPropertyChanged(); // UI 업데이트를 위해 속성 변경 알림
                }
            }
        }

        // --- INotifyPropertyChanged 구현 (싱글톤 서비스가 변경사항을 UI에 알릴 때 필요) ---
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // --- 페이지 전환을 요청하는 메서드 (ViewModel에서 호출) ---
        public void NavigateTo(string pageUri)
        {
            // 이 메서드를 통해 CurrentFrameSource를 변경하면 UI가 업데이트됩니다.
            CurrentFrameSource = pageUri;
            Debug.WriteLine($"NavigationService: Navigated to {pageUri}");
        }
    }
}