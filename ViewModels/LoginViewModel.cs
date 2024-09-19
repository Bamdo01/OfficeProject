using System.ComponentModel;

namespace WPFOfficeProject
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public LoginViewModel()//생성자
        {
            // 처음에 로드할 페이지 설정
            FrameSource = "LoginPage.xaml";
        }

        private string _frameSource;//로그인의 프레임 소스
        public string FrameSource
        {
            get { return _frameSource; }
            set
            {
                _frameSource = value;
                OnPropertyChanged("FrameSource");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

