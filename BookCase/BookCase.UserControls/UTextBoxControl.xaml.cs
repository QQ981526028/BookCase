using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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

namespace BookCase.UserControls
{
    /// <summary>
    /// UTextBoxControl.xaml 的交互逻辑
    /// </summary>
    public partial class UTextBoxControl : UserControl
    {
        public UTextBoxControl()
        {
            InitializeComponent();
            lblErroeMessage.Content = string.Empty;
            lblTip.Visibility = Visibility.Collapsed;
            lblRedStar.Visibility = Visibility.Collapsed;
            txtInputBox.TextChanged += TxtInputBox_TextChanged;
        }

        private void TxtInputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var control = sender as TextBox;
            if (control == null)
            {
                return;
            }
            if (control.Text.Length > 0)
            {
                txtWaterMark.Visibility = Visibility.Collapsed;
                
            }
            else
            {
                txtWaterMark.Visibility = Visibility.Visible;
            }
        }

        #region 依赖属性
        /// <summary>
        /// 红色标记星星是否显示
        /// </summary>
        public Visibility RedStarVisibility
        {
            get { return (Visibility)GetValue(RedStarVisibilityProperty); }
            set { SetValue(RedStarVisibilityProperty, value); }
        }
        /// <summary>
        /// 红色标记星星是否显示
        /// </summary>
        public static readonly DependencyProperty RedStarVisibilityProperty =
            DependencyProperty.Register("RedStarVisibility", typeof(Visibility), typeof(UTextBoxControl), new PropertyMetadata(Visibility.Collapsed,new PropertyChangedCallback(OnRedStarVisibilityChanged)));

        private static void OnRedStarVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as UTextBoxControl;
            if (control == null)
            {
                return;
            }
            if ((Visibility)e.NewValue == Visibility.Visible)
            {
                control.lblRedStar.Visibility = Visibility.Visible;
            }
            else
            {
                control.lblRedStar.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// 红色标记星星字体大小
        /// </summary>
        public int RedStarFontSize
        {
            get { return (int)GetValue(RedStarFontSizeProperty); }
            set { SetValue(RedStarFontSizeProperty, value); }
        }
        /// <summary>
        /// 红色标记星星字体大小
        /// </summary>
        public static readonly DependencyProperty RedStarFontSizeProperty =
            DependencyProperty.Register("MyProperty", typeof(int), typeof(UTextBoxControl), new PropertyMetadata(25));

        /// <summary>
        /// 异常提示文字颜色
        /// </summary>
        public Color? ErrorMessageTextColor
        {
            get { return (Color)GetValue(ErrorMessageTextColorProperty); }
            set { SetValue(ErrorMessageTextColorProperty, value); }
        }

        /// <summary>
        /// 异常提示文字颜色
        /// </summary>
        public static readonly DependencyProperty ErrorMessageTextColorProperty =
            DependencyProperty.Register("ErrorMessageTextColor", typeof(Color?), typeof(UTextBoxControl), new PropertyMetadata(null));

        /// <summary>
        /// 异常消息内容
        /// </summary>
        public string ErrorMessageContent
        {
            get { return (string)GetValue(ErrorMessageContentProperty); }
            set { SetValue(ErrorMessageContentProperty, value); }
        }

        /// <summary>
        /// 异常消息内容
        /// </summary>
        public static readonly DependencyProperty ErrorMessageContentProperty =
            DependencyProperty.Register("ErrorMessage", typeof(string), typeof(UTextBoxControl), new PropertyMetadata(string.Empty,new PropertyChangedCallback(OnErrorMessageChanged)));

        private static void OnErrorMessageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as UTextBoxControl;
            if (control == null)
            {
                return;
            }
            if (string.IsNullOrEmpty((string)e.NewValue))
            {
                control.lblErroeMessage.Visibility = Visibility.Collapsed;
            }
            else
            {
                control.lblErroeMessage.Visibility = Visibility.Visible;
            }
            control.lblErroeMessage.Content = e.NewValue;
        }
        /// <summary>
        /// 必填提示文字是否显示
        /// </summary>
        public Visibility TipVisibility
        {
            get { return (Visibility)GetValue(TipVisibilityProperty); }
            set { SetValue(TipVisibilityProperty, value); }
        }
        /// <summary>
        /// 必填提示文字是否显示
        /// </summary>
        public static readonly DependencyProperty TipVisibilityProperty =
            DependencyProperty.Register("TipVisibility", typeof(Visibility), typeof(UTextBoxControl), new PropertyMetadata(Visibility.Collapsed, new PropertyChangedCallback(OnTipVisibilityChanged)));

        private static void OnTipVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as UTextBoxControl;
            if (control == null)
            {
                return;
            }
            if ((Visibility)e.NewValue == Visibility.Visible)
            {
                control.lblTip.Visibility = Visibility.Visible;
            }
            else
            {
                control.lblTip.Visibility = Visibility.Collapsed;
            }
        }


        /// <summary>
        /// 是否获取焦点
        /// </summary>
        public bool IsFocus
        {
            get { return (bool)GetValue(IsFocusProperty); }
            set { SetValue(IsFocusProperty, value); }
        }
        /// <summary>
        /// 是否获取焦点
        /// </summary>
        public static readonly DependencyProperty IsFocusProperty = 
            DependencyProperty.Register("IsFocus", typeof(bool), typeof(UTextBoxControl), new PropertyMetadata(false, IsFocusCallBack));
        /// <summary>
        /// 设置焦点
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void IsFocusCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as UTextBoxControl;
            control?.Dispatcher?.Invoke(() =>
            {
                control.txtInputBox.Focus(); //聚焦
            });
        }

        /// <summary>
        /// 水印
        /// </summary>
        public string WaterMark
        {
            get { return (string)GetValue(WaterMarkProperty); }
            set { SetValue(WaterMarkProperty, value); }
        }
        public static readonly DependencyProperty WaterMarkProperty = 
            DependencyProperty.Register("WaterMark", typeof(string), typeof(UTextBoxControl), new PropertyMetadata(string.Empty,new PropertyChangedCallback(OnWaterMarkChanged)));

        private static void OnWaterMarkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as UTextBoxControl;
            if (control == null)
            {
                return;
            }
            if (!string.IsNullOrEmpty((string)e.NewValue))
            {
                control.txtWaterMark.Text = e.NewValue.ToString();                
            }
                    
        }


        /// <summary>
        /// 输入值
        /// </summary>
        public string InputText
        {
            get { return (string)GetValue(InputTextProperty); }
            set { SetValue(InputTextProperty, value); }
        }
        
        public static readonly DependencyProperty InputTextProperty =
            DependencyProperty.Register("InputText", typeof(string), typeof(UTextBoxControl), new PropertyMetadata(string.Empty,new PropertyChangedCallback(OnInputTextChanged)));

        private static void OnInputTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as UTextBoxControl;
            if (control == null)
            {
                return;
            }
            if (string.IsNullOrEmpty((string)e.NewValue))
            {
                control.txtWaterMark.Visibility = Visibility.Visible;
            }
            else
            {
                control.txtWaterMark.Visibility = Visibility.Collapsed;
                control.txtInputBox.Text = e.NewValue.ToString();
            }
        }


        #endregion

    }
}
