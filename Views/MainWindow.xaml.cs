using System;
using System.Windows;

namespace WPFOfficeProject
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel(); // ✅ 뷰 모델을 직접 선언
            this.DataContext = _viewModel; // ✅ DataContext 설정

            // ✅ 필요하면 _viewModel을 사용해서 직접 조작 가능
        }





    }
}
