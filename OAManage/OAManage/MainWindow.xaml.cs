using OAManage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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

namespace OAManage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 账号model
        /// </summary>
        private AccountModel accountModel;

        public MainWindow()
        {
            InitializeComponent();

            //设置数据上下文
            accountModel=new AccountModel();
            this.DataContext = accountModel;
        }
        

        ///// <summary>
        ///// 登录(单击登录按钮执行)
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void Btn_Login(object sender, RoutedEventArgs e)
        //{
        //    if (this.accountModel.Account == "longma" && this.accountModel.Pwd == "123")
        //    {
        //        MessageBox.Show("登录成功");
        //    }
        //    else
        //    {
        //        MessageBox.Show("登录失败");
        //        //清空账号 密码文本框
        //        this.accountModel.Account = "";
        //        this.accountModel.Pwd = "";
        //    }
        //}
    }
}
