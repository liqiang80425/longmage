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
using System.Windows.Shapes;

namespace 委托事件
{
    /// <summary>
    /// SonWin.xaml 的交互逻辑
    /// </summary>
    public partial class SonWin : Window
    {
        ////先定义委托
        //public delegate void del();//delegate 返回值类型 del(int i,string str);

        //public event del Dele;//委托类型属性   接收主窗口传过来的方法  event: 事件

        //系统委托/预置委托  Aciton、Func
        //Aciton:没有返回值
        //Func:必须要有返回值
        //public Action<int,string> Dele;

        //public Func<int, int, string> Dele1;//第一个是返回值类型。从第二个开始时方法参数（如果方法没有参数，则没有第二个）

        //事件：特殊的委托

        public event Action Dele;

        public SonWin()
        {
            InitializeComponent();
            //this._Dele = Dele;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Dele != null)
            {
                Dele();
            }
        }
    }
}
