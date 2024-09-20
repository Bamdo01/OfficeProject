using System;
using System.Collections.Generic;
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
using System.IO;
using System.Data;


namespace WPFOfficeProject
{
    /// <summary>
    /// FriendWaitPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public class FriendWaite
    {
        public string Name { get; set; }
        public string FAcc { get; set; }
        public string FCan { get; set; }

    }

    public partial class FriendWaitPage : Page
    {

        private List<FriendWaite> _list;

        public FriendWaitPage()
        {
            InitializeComponent();
           // NUPServerConnector connector = new NUPServerConnector();
           // connector.SendUserGetPendingFriends(File.ReadAllText("currentuser.txt"),OK,NG);

           //_list = new List<FriendWaite>
           // {

           // };
        }

        //private void OK(string rsp)
        //{
        //    MessageBox.Show(rsp);

        //    string[] lines = rsp.Split(new string[] { Environment.NewLine },  //개행 단위로 문자열을 쪼갬
        //       StringSplitOptions.RemoveEmptyEntries);// 비어있는 라인은 무시하고 가져옴

        //    for (int i = 1; i < lines.Length; i++)
        //    {
        //        _list.Add(new FriendWaite { Name = lines[i], FAcc = "수락" , FCan = "거절" });
        //    }
        //    WaitGrid.ItemsSource = _list;
        //}

        private void NG(string rsp)
        {
            MessageBox.Show(rsp);
        }

        private void FriedAcc_Click(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("수락");

            
            TextBlock textBlock = sender as TextBlock;
            if (textBlock != null)
            {
                var row = DataGridRow.GetRowContainingElement(textBlock);
                if (row != null)
                {
                   // WaitGrid myData = row.Item as Friend;
                    //if (myData != null)
                    //{
                     //   MessageBox.Show($"First Column Value: {myData.Column1}");
//                    }
                }
            }
        }

        private void Friedcan_Click(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("거절");
        }
    }
}
