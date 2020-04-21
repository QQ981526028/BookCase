using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCase.Common;
using BookCase.Helpers;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace BookCase.ViewModel
{
    /// <summary>
    /// 定位器：用于访问ViewModel
    /// </summary>
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainWindowViewModel>();//主窗口ViewModel
            //创建导航服务
            var navigationService = this.CreateNavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
        }
        /// <summary>
        /// 主窗口
        /// </summary>
        public MainWindowViewModel MainWindowViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainWindowViewModel>();
            }
        }
        /// <summary>
        /// 创建导航服务
        /// </summary>
        /// <returns></returns>
        private INavigationService CreateNavigationService()
        {
            var navigationService = new NavigationService();
            //框架页
            navigationService.Configure(ViewNames.MAIN_VIEW, new Uri("/MainWindow.xaml", UriKind.RelativeOrAbsolute));
            return navigationService;
        }
    }
}
