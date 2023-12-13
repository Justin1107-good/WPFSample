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

namespace WPFSample.frameworks.Users.UserControls
{
    /// <summary>
    /// LoginStylePageTwo.xaml 的交互逻辑
    /// </summary>
    public partial class LoginStylePageTwo : UserControl
    {
        public LoginStylePageTwo()
        {
            InitializeComponent();
        }

        private void PwdTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PwdTextBox.Password == "")
            {
                PasswordTip.Visibility = Visibility.Visible;
            }
            else
            {
                PasswordTip.Visibility = Visibility.Hidden;
            }
        }
    }
}
