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
using System.Xml.Linq;
using System.IO;

//using System.Collections.ObjectModel;
//using System.Collections;

namespace NUPROJECT_vcs
{
    /// <summary>
    /// FriendAddPage.xaml에 대한 상호 작용 논리
    /// </summary>


    public partial class FriendAddPage : Page
    {
        public FriendAddPage()
        {
            InitializeComponent();

        }
        private void CreateDynamicRow(string userName)
        {
            // 행 정의 추가
            RowDefinition rowDefinition = new RowDefinition
            {
                Height = new GridLength(30) // 행의 높이를 30으로 설정
            };
            SerchList.RowDefinitions.Add(rowDefinition);

            // 가장 외곽의 Grid 생성
            Grid outerGrid = new Grid();
            Grid.SetRow(outerGrid, SerchList.RowDefinitions.Count - 1); //셋 로우를 할떄마다 행의 개수를 가져와서 세팅

            // Border 생성
            Border border = new Border
            {
                BorderThickness = new Thickness(1),
                BorderBrush = Brushes.AliceBlue,
                Margin = new Thickness(3)
            };

            // 내부의 Grid 생성
            Grid innerGrid = new Grid();

            // 열 정의 추가
            innerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
            innerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            innerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            // 첫 번째 열에 TextBlock 추가
            TextBlock textBlock = new TextBlock
            {
                Text = userName,  // 사용자 이름 설정
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Name = "name"
            };
            Grid.SetColumn(textBlock, 0);
            innerGrid.Children.Add(textBlock);

            // 두 번째 열에 수락 버튼 추가
            Button acceptButton = new Button
            {
                Content = "수락",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            acceptButton.Click += FriendAdd_Click;  // Click 이벤트 핸들러 연결
            Grid.SetColumn(acceptButton, 1);
            innerGrid.Children.Add(acceptButton);

            // 세 번째 열에 거절 버튼 추가
            Button declineButton = new Button
            {
                Content = "거절",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(declineButton, 2);
            innerGrid.Children.Add(declineButton);

            // Border에 innerGrid 추가
            border.Child = innerGrid;

            // outerGrid에 Border 추가
            outerGrid.Children.Add(border);

            // 최종적으로 SerchList에 outerGrid 추가
            SerchList.Children.Add(outerGrid);
        }


        private void SerchOk(string rsp)
        {
            MessageBox.Show(rsp);
            // 콤마를 기준으로 문자열을 자르기
            string[] result = rsp.Split(',');

            //검색된 유저의 수
            int SerchFriend = result.Length;

            for(int i = 0; i < SerchFriend; i++)
            {
                CreateDynamicRow(result[i]);
            }

        }

        private void SerchNg(string rsp)
        {

        }


        private void FaddOk(string rsp)
        {
            MessageBox.Show("친구요청 성공");
        }
        private void FaddNg(string rsp)
        {
            MessageBox.Show("친구요청 실패");
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NUPServerConnector connector = new NUPServerConnector();
            connector.SendGetUser(Fserch.Text, SerchOk, SerchNg);
        }

        private void FriendAdd_Click(object sender, RoutedEventArgs e)//수락버튼 눌렀을떄
        {

        }
    }
}
