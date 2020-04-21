using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace BookCase.Helpers
{
    /// <summary>
    /// 查找控件帮助类
    /// </summary>
    public class FindControlHelper
    {
        private static FindControlHelper findControlHelper;
        public static FindControlHelper Instance => findControlHelper ?? (findControlHelper = new FindControlHelper());

        /// <summary>
        /// 查找子控件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public T GetChildObject<T>(DependencyObject obj, string name) where T : FrameworkElement
        {
            for (var i = 0; i <= VisualTreeHelper.GetChildrenCount(obj) - 1; i++)
            {
                var child = VisualTreeHelper.GetChild(obj, i);

                var element = child as T;
                if (element != null && (element.Name == name | string.IsNullOrEmpty(name)))
                {
                    return element;
                }
                // 在下一级中没有找到指定名字的子控件，就再往下一级找
                var grandChild = GetChildObject<T>(child, name);
                if (grandChild != null)
                    return grandChild;
            }
            return null;
        }
    }
}
