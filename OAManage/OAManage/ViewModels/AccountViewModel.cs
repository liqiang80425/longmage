using OAManage.Command;
using OAManage.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OAManage.ViewModels
{
    internal class AccountViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private AccountModel _AccountModel = new AccountModel();

        /// <summary>
        /// 账号
        /// </summary>
        public string Account
        {
            get
            {
                return _AccountModel.Account;
            }
            set
            {
                _AccountModel.Account = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Account"));
                }
            }
        }

        /// <summary>
        /// 账号
        /// </summary>
        public string Pwd
        {
            get
            {
                return _AccountModel.Pwd;
            }
            set
            {
                _AccountModel.Pwd = value;
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
            if (Account == "longma" && Pwd == "123")
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
