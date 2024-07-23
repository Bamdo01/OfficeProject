using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Collections.ObjectModel;
using System.Collections;

namespace NUPROJECT_vcs
{
    /// <summary>
    /// FriendAddPage.xaml에 대한 상호 작용 논리
    /// </summary>

    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Fadd { get; set; }

    }

    public partial class FriendAddPage : Page
    {
        private List<User> _list;
        public FriendAddPage()
        {
            InitializeComponent();

            _list = new List<User>
            {

            };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //커넥터로 텍스트에 있는값 가져와서 검색
            NUPServerConnector connector = new NUPServerConnector();
            connector.SendGetUser(Fserch.Text, SerchOk, SerchNg);


            //리스트 생성 여기에 검색된 결과 넣기
             
            //FriendCheck.ItemsSource = _list;
        }

        private void SerchOk(string rsp)
        {
            MessageBox.Show(rsp);
            string[] lines = rsp.Split(new string[] { Environment.NewLine },  //개행 단위로 문자열을 쪼갬
                StringSplitOptions.RemoveEmptyEntries);// 비어있는 라인은 무시하고 가져옴

            for(int i= 0; i< lines.Length; i++)
            {
                string[] ie = lines[i].Split(',');

                _list.Add(new User { Name = ie[0], Email = ie[1], Fadd = "친구추가하기" });                                         
            }
            FriendCheck.ItemsSource = _list;
        }

        private void SerchNg(string rsp)
        {

        }

    }
}
