using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using WPFOfficeProject.Models;
using WPFOfficeProject.Services;

namespace WPFOfficeProject.ViewModels
{
    public class LoginWindowViewModel : INotifyPropertyChanged
    {
        // 1. FrameSource는 이제 NavigationService에서 가져옵니다.
        //    ViewModel은 서비스의 CurrentFrameSource를 직접 바인딩합니다.
        //    따라서 여기에 별도의 _frameSource 필드나 public FrameSource 속성은 필요 없습니다.

        // 캐시된 ViewModel 인스턴스는 여전히 필요합니다.
        private Dictionary<string, object> _cachedViewModels = new Dictionary<string, object>();

        public LoginWindowViewModel()
        {
            // NavigationService 인스턴스를 가져옵니다. (싱글톤이므로 항상 같은 인스턴스)
            // 여기서는 초기 페이지를 NavigationService가 설정하므로, ViewModel에서는 특별히 초기화할 필요가 없습니다.
            // 필요하다면, NavigationService.Instance.NavigateTo("LoginPage.xaml"); 같은 호출을 할 수도 있습니다.

            // NavigationService의 속성 변경 이벤트 구독 (ViewModel에 바인딩된 경우 필요)
            // 이렇게 하면 서비스의 CurrentFrameSource가 변경될 때 ViewModel의 속성 변경 이벤트를 다시 발행하여
            // UI 바인딩이 업데이트되도록 할 수 있습니다.
            NavigationService.Instance.PropertyChanged += NavigationService_PropertyChanged;

            // TODO: 필요한 경우 다른 ViewModel (예: LoginPageViewModel) 생성 시
            // NavigationService.Instance.NavigateTo 메서드를 전달하여 통신 통로로 사용할 수 있습니다.
            // 예: _cachedViewModels["LoginPage"] = new LoginPageViewModel(NavigationService.Instance.NavigateTo);
            // 이 경우, LoginPageViewModel은 RequestPageChange 대신 NavigateTo를 호출하게 됩니다.
            // 일단은 현재 NavigationService가 직접 CurrentFrameSource를 변경하므로,
            // 별도의 Action<string> 전달은 하지 않아도 되지만, 상황에 따라 선택할 수 있습니다.

            // 애플리케이션 시작 시 기본 화면으로 '로그인 페이지'를 서비스에 요청
            // 이것이 최초의 내비게이션 요청이 됩니다.
            NavigationService.Instance.NavigateTo("LoginPage.xaml");
        }

        // NavigationService의 CurrentFrameSource가 변경될 때 ViewModel의 바인딩을 업데이트하기 위함
        private void NavigationService_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // NavigationService의 CurrentFrameSource가 변경될 때만 알림
            if (e.PropertyName == nameof(NavigationService.CurrentFrameSource))
            {
                OnPropertyChanged(nameof(FrameSource)); // ViewModel에 FrameSource 속성이 있다면
            }
        }

        // Frame의 Source에 직접 바인딩할 속성 (NavigationService에서 값을 가져옴)
        // 이 속성이 변경되면 UI에 알립니다.
        public string FrameSource
        {
            get { return NavigationService.Instance.CurrentFrameSource; }
        }

        // 이 부분은 ViewModel에서 페이지 전환을 요청할 때 사용될 수 있습니다.
        // (예: LoginPageViewModel에서 RegisterPage로 가고 싶을 때 NavigationService.Instance.NavigateTo("RegisterPage.xaml") 호출)
        public void RequestPageChange(string pageUri)
        {
            NavigationService.Instance.NavigateTo(pageUri);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
