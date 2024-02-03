using OAManage.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OAManage.Models
{
    /// <summary>
    /// 用户model  //问题:界面上修改了，后台能接收。后台改了，界面不知道(界面没有接收到通知，INotifyPropertyChanged解决)
    /// </summary>
    internal class AccountModel : INotifyPropertyChanged//INotifyPropertyChanged 属性改变通知接口
    {
        /// <summary>
        /// 属性改变事件
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// 账号
        /// </summary>
        private string _Account;

        /// <summary>
        /// 账号
        /// </summary>
        public string Account
        {
            get { return _Account; }
            set
            {
                _Account = value;
                //通知
                //PropertyChanged?.Invoke(this,new PropertyChangedEventArgs("Account"));
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Account"));
                }
            }
        }

        /// <summary>
        /// 密码
        /// </summary>
        private string _Pwd;

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd
        {
            get { return _Pwd; }
            set
            {
                _Pwd = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Pwd"));
                }
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        private void Login()
        {
            if (this.Account == "longma" && this.Pwd == "123")
            {
                MessageBox.Show("登录成功");
            }
            else
            {
                MessageBox.Show("登录失败");
                //清空账号 密码文本框
                this.Account = "";
                this.Pwd = "";
            }
        }

        /// <summary>
        /// 命令属性
        /// </summary>
        public ICommand Command
        {
            get
            {
                return new DoCommand(Login);
            }
        }
    }
}
