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
            this.Loaded += UTextBoxControl_Loaded;
        }

        private void UTextBoxControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.lblRedStar.Visibility = RedStarVisibility;
        }
        #region 暴露属性
        /// <summary>
        /// 红色标记星星是否显示
        /// </summary>
        public Visibility RedStarVisibility
        {
            get { return (Visibility)GetValue(RedStarVisibilityProperty); }
            set { SetValue(RedStarVisibilityProperty, value); }
        }
        #endregion
        #region 依赖属性
        /// <summary>
        /// 红色标记星星是否显示
        /// </summary>
        public static readonly DependencyProperty RedStarVisibilityProperty =
            DependencyProperty.Register("RedStarVisibility", typeof(Visibility), typeof(UTextBoxControl), new PropertyMetadata(Visibility.Collapsed));
        #endregion

    }
}
