using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFOfficeProject
{
    //바인딩 로케이터 모음 클래스 이제 만드는 뷰 모델을을 여기에 넣어주고  
    //<local:ViewModelLocator x:Key="Locator" />  을 App.xaml 파일에 넣어주면된다
    //그리고 사용할 Xmal 파일에 대항하는 뷰모델을 DataContext="{Binding LoginViewModel, Source={StaticResource Locator}}">
    //이렇게 넣어주면 된다
    //나중에 알아보기
    public class ViewModelLocator
    {
        //표현식 본문 속성 문법이래용
        public LoginViewModel LoginViewModel => new LoginViewModel();
    }
}
