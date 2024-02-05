using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OAManage.CuestomControl
{
    /// <summary>
    /// 自定义按钮
    /// </summary>
    internal class CustomButton:Button
    {
        //增加圆角(依赖属性)
        /// <summary>
        /// 圆角属性(CornerRadius)
        /// </summary>
        public CornerRadius BtnRadius
        {
            get { return (CornerRadius)GetValue(BtnRadiusProperty); }
            set { SetValue(BtnRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BtnRadiusProperty =
            DependencyProperty.Register("BtnRadius", typeof(CornerRadius), typeof(CustomButton));

        /// <summary>
        /// 鼠标移入的时候 背景颜色值
        /// </summary>
        public Brush OverBackground
        {
            get { return (Brush)GetValue(OverBackgroundProperty); }
            set { SetValue(OverBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OverBackgroundProperty =
            DependencyProperty.Register("OverBackground", typeof(Brush), typeof(CustomButton));
    }
}
