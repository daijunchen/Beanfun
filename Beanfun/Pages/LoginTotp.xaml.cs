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

namespace Beanfun
{
    /// <summary>
    /// LoginTotp.xaml 的交互逻辑
    /// </summary>
    public partial class LoginTotp : Page
    {

        private void otp1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // 检查是否是粘贴操作（Ctrl + V）
            if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                // 获取剪贴板中的文本
                if (Clipboard.ContainsText())
                {
                    string clipboardText = Clipboard.GetText();

                    // 如果粘贴的内容是六位字符
                    if (clipboardText.Length == 6)
                    {
                        otp1.Text = clipboardText[0].ToString();
                        otp2.Text = clipboardText[1].ToString();
                        otp3.Text = clipboardText[2].ToString();
                        otp4.Text = clipboardText[3].ToString();
                        otp5.Text = clipboardText[4].ToString();
                        otp6.Text = clipboardText[5].ToString();
                        btn_login.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                        e.Handled = true;  // 阻止默认粘贴行为
                    }
                    else
                    {
                        // 如果粘贴的内容不是六位字符，只粘贴第一个字符到 otp1
                        otp1.Text = clipboardText[0].ToString();
                        otp2.Focus();  // 聚焦到 otp2
                        e.Handled = true;  // 阻止默认粘贴行为
                    }
                }
            }
        }

        public LoginTotp()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            btn_login.IsEnabled = false;
            btn_cancel.IsEnabled = false;
            App.MainWnd.do_Totp();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            App.MainWnd.frame.Content = App.MainWnd.loginPage;
        }

        private void otp1_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if(otp1.Text.Length > 0)
            {
                otp2.Focus();
            }
        }

        private void otp2_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (otp2.Text.Length > 0)
            {
                otp3.Focus();
            }
        }

        private void otp3_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (otp3.Text.Length > 0)
            {
                otp4.Focus();
            }
        }

        private void otp4_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (otp4.Text.Length > 0)
            {
                otp5.Focus();
            }
        }

        private void otp5_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (otp5.Text.Length > 0)
            {
                otp6.Focus();
            }
        }

        private void otp6_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (otp1.Text.Length > 0 && otp2.Text.Length > 0 && otp3.Text.Length > 0 && otp4.Text.Length > 0 && otp5.Text.Length > 0 && otp6.Text.Length > 0)
            {
                btn_login.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void otp_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.SelectAll();
        }
    }
}
