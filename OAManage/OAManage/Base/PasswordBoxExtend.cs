using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OAManage.Base
{
    /// <summary>
    /// 自定义PasswordBox属性
    /// </summary>
    internal class PasswordBoxExtend
    {
        //MyPwd 自定义属性名
        //附加属性(特殊的依赖属性)
        public static string GetMyPwd(DependencyObject obj)
        {
            return (string)obj.GetValue(MyPwdProperty);
        }

        /// <summary>
        /// MyPwd属性赋值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetMyPwd(DependencyObject obj, string value)
        {
            obj.SetValue(MyPwdProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyPwd.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPwdProperty =
            DependencyProperty.RegisterAttached("MyPwd", typeof(string), typeof(PasswordBoxExtend),new PropertyMetadata("",OnMyPwdChanged));//Alt+Enter

        /// <summary>
        /// MyPwd->Password 当MyPwd的值发生改变，给Password属性赋值
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void OnMyPwdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox pwdBox=d as PasswordBox;
            if (pwdBox != null)
            {
                pwdBox.Password = (string)e.NewValue;//当MyPwd的值发生改变，给Password属性赋值

                //将光标移动最后
                SetSelection(pwdBox, pwdBox.Password.Length,0);
            }
        }

        /// <summary>
        /// 设置光标位置
        /// </summary>
        /// <param name="passwordBox"></param>
        /// <param name="start">光标开始位置</param>
        /// <param name="length">选中长度</param>
        private static void SetSelection(PasswordBox passwordBox, int start, int length)
        {
            passwordBox.GetType()
                       .GetMethod("Select", BindingFlags.Instance | BindingFlags.NonPublic)
                       .Invoke(passwordBox, new object[] { start, length });
        }

        //Password发生变化，通知MyPwd也要变
        //1、如何知道Password
        //2、通知MyPwd也要变
        public static bool GetIsBind(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsBindProperty);
        }

        public static void SetIsBind(DependencyObject obj, bool value)
        {
            obj.SetValue(IsBindProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsBind.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsBindProperty =
            DependencyProperty.RegisterAttached("IsBind", typeof(bool), typeof(PasswordBoxExtend), new PropertyMetadata(false,OnPropChanged));

        private static void OnPropChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox pwdBox = d as PasswordBox;
            if (pwdBox != null)
            {
                //1、如何Passwrod属性变化了，则通知MyPwd也要变
                //2、如果Passwrod属性没有变，则不用通知MyPwd
                if ((bool)e.NewValue)//如果是新值  已经变了
                {
                    pwdBox.PasswordChanged += OnPasswordChanged;
                }
                if ((bool)e.OldValue)//如果是旧值  没有变 
                {
                    pwdBox.PasswordChanged-= OnPasswordChanged;
                }
            }
        }

       /// <summary>
       /// 赋值
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private static void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox pwdBox = sender as PasswordBox;
            if (pwdBox != null)
            {
                SetMyPwd(pwdBox, pwdBox.Password);
            }
        }
    }
}
