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

namespace 委托事件
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 租房/Model登录  给子窗口/中介执行
        /// </summary>
        public void F1()
        {
            this.txtTest.Text = "成功";
            //return 1;
        }

        public void F2()
        {
            this.txtTest.Text = "成功";
            //return 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            SonWin sonWin = new SonWin();
            sonWin.Dele += F1;//将方法传给子窗口
            //sonWin.Dele += F2;//将方法传给子窗口
            sonWin.Show();//打开窗口
        }
    }
}
