using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BookCase.Helpers
{
    public class NavigationService : ViewModelBase, INavigationService
    {
        #region 成员变量
        /// <summary>
        /// 历史列表
        /// </summary>
        private readonly List<string> historic;
        /// <summary>
        /// 当前导航页
        /// </summary>
        private string currentPageKey;
        /// <summary>
        /// 是否正在导航
        /// </summary>
        private bool isNavigating;
        /// <summary>
        /// 导航页面地址Key
        /// </summary>
        private readonly Dictionary<string, Uri> pageUrlByKey;
        /// <summary>
        /// 导航页单例Key
        /// </summary>
        private readonly Dictionary<string, Page> pageInstancesByKey;
        /// <summary>
        /// 当前框架容器
        /// </summary>
        private Frame currentFrame = null;
        /// <summary>
        /// 导航参数
        /// </summary>
        public object Parameter { get; private set; }
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public NavigationService()
        {
            pageUrlByKey = new Dictionary<string, Uri>();
            pageInstancesByKey = new Dictionary<string, Page>();
            historic = new List<string>();
            //LogManagers.Logger.Log("NavigationService已实例化！");
        }

        /// <summary>
        /// 当前导航页面Key
        /// </summary>
        public string CurrentPageKey
        {
            get
            {
                return currentPageKey;
            }

            private set
            {
                Set(() => CurrentPageKey, ref currentPageKey, value);
            }
        }
        /// <summary>
        /// 回退
        /// </summary>
        public void GoBack()
        {
            if (historic.Count > 1)
            {
                historic.RemoveAt(historic.Count - 1);

                NavigateTo(historic.Last(), "Back");
            }
        }
        /// <summary>
        /// 跳转
        /// </summary>
        /// <param name="pageKey"></param>
        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, "Next");
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            if (isNavigating)
            {
                return;
            }
            isNavigating = true;
            try
            {
                lock (pageUrlByKey)
                {
                    if (!pageUrlByKey.ContainsKey(pageKey))
                    {
                        throw new ArgumentException(string.Format("No such page: {0} ", pageKey), "pageKey");
                    }
                    if (currentFrame == null)
                    {
                        var frame = FindControlHelper.Instance.GetChildObject<Frame>(Application.Current.MainWindow, "MainFrame");
                        if (frame != null)
                        {
                            this.currentFrame = frame;
                            this.currentFrame.Navigated -= CurrentFrame_Navigated;
                            this.currentFrame.Navigated += CurrentFrame_Navigated;
                        }
                        else
                        {
                            throw new Exception("frame is null");
                        }
                    }
                    bool reloadPage = false;
                    if (parameter != null)
                    {
                        bool.TryParse(parameter.ToString(), out reloadPage);
                    }
                    if (this.currentFrame != null)
                    {
                        if (this.pageInstancesByKey.ContainsKey(pageKey) && reloadPage == false)
                        {
                            this.currentFrame.NavigationService.Navigate(this.pageInstancesByKey[pageKey]);
                        }
                        else
                        {
                            this.currentFrame.Source = pageUrlByKey[pageKey];
                            this.CurrentPageKey = pageKey;
                        }
                    }
                    Parameter = parameter;
                    if (parameter.ToString().Equals("Next"))
                    {
                        historic.Add(pageKey);
                    }
                    CurrentPageKey = pageKey;
                }
            }
            finally
            {
                isNavigating = false;
            }
        }
        /// <summary>
        /// 配置导航页面地址与Key值字典
        /// </summary>
        /// <param name="key">Key值</param>
        /// <param name="pageType">地址</param>
        public void Configure(string key, Uri pageType)
        {
            lock (pageUrlByKey)
            {
                if (pageUrlByKey.ContainsKey(key))
                {
                    pageUrlByKey[key] = pageType;
                }
                else
                {
                    pageUrlByKey.Add(key, pageType);
                }
            }
        }
        #region 辅助方法
        private void CurrentFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            Page page = e.Content as Page;
            this.AddPageInstance(CurrentPageKey, page);
        }
        private void AddPageInstance(string key, Page instance)
        {
            lock (pageInstancesByKey)
            {
                if (!pageInstancesByKey.ContainsKey(key) && instance != null)
                {
                    if (this.Parameter == null)
                    {
                        pageInstancesByKey.Add(key, instance);
                    }
                    else
                    {
                        bool reloadPage = false;
                        bool.TryParse(this.Parameter.ToString(), out reloadPage);
                        if (!reloadPage)
                        {
                            pageInstancesByKey.Add(key, instance);
                        }
                    }
                }
            }
        }
        private FrameworkElement GetDescendantFromName(DependencyObject parent, string name)
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);

            if (count < 1)
            {
                return null;
            }

            for (var i = 0; i < count; i++)
            {
                var frameworkElement = VisualTreeHelper.GetChild(parent, i) as FrameworkElement;
                if (frameworkElement != null)
                {
                    if (frameworkElement.Name == name)
                    {
                        return frameworkElement;
                    }

                    frameworkElement = GetDescendantFromName(frameworkElement, name);
                    if (frameworkElement != null)
                    {
                        return frameworkElement;
                    }
                }
            }
            return null;
        }
        #endregion
    }
}
