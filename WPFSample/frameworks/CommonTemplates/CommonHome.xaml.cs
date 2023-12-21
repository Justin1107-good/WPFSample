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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFSample.frameworks.CommonTemplates
{
    /// <summary>
    /// CommonHome.xaml 的交互逻辑
    /// </summary>
    public partial class CommonHome : Window
    {
        public CommonHome()
        {
            InitializeComponent();
        }
        //private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        //{
        //    // 导航菜单展开时的操作
        //    //navigationMenu.Width = Double.NaN; // 设置宽度为自动，即展开状态
        //    //toggleButton.Margin = new Thickness(200, 10, 0, 0); // 调整按钮的位置
        //}

        //private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    // 导航菜单关闭时的操作
        //   // navigationMenu.Width = 0; // 设置宽度为0，即关闭状态
        //   // navigationMenu.Visibility= Visibility.Collapsed;
        //   // toggleButton.Margin = new Thickness(10, 10, 0, 0); // 调整按钮的位置
        //}
        //private void LoginMenuItem_Click(object sender, RoutedEventArgs e)
        //{
        //    // 处理登录逻辑
        //    MessageBox.Show("Login clicked");
        //}

        //private void LogoutMenuItem_Click(object sender, RoutedEventArgs e)
        //{
        //    // 处理退出逻辑
        //    MessageBox.Show("Logout clicked");
        //}

        #region 平面走动的时钟
        //private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        //{
        //    // 启动动画
        //    DoubleAnimation animation = new DoubleAnimation
        //    {
        //        To = 360,
        //        Duration = TimeSpan.FromSeconds(2),
        //        RepeatBehavior = RepeatBehavior.Forever
        //    };

        //    clockHandTransform.BeginAnimation(RotateTransform.AngleProperty, animation);
        //}

        //private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    // 停止动画
        //    clockHandTransform.BeginAnimation(RotateTransform.AngleProperty, null);
        //}
        #endregion
    }
}
