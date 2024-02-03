using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OAManage.Command
{
    /// <summary>
    /// 命令
    /// </summary>
    internal class DoCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// 具体要执行的事情
        /// </summary>
        private Action _execute;//委托

        /// <summary>
        /// 构造函数
        /// </summary>
        public DoCommand(Action execute)
        { 
            this._execute = execute;
        }

        /// <summary>
        /// 能否执行
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        /// <summary>
        /// 执行的事情
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object? parameter)
        {
            if (_execute != null)
            {
                _execute();
            }
        }
    }
}
