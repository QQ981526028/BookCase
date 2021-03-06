﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCase.Common;
using BookCase.Common.IViewModels;
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
            SimpleIoc.Default.Register<IDataService, DataService>();//公共变量交换器
            SimpleIoc.Default.Register<MainWindowViewModel>();//主窗口ViewModel
            SimpleIoc.Default.Register<TextViewModel>();//测试窗口ViewModel
            SimpleIoc.Default.Register<HomePageViewModel>();//首页ViewModel
            SimpleIoc.Default.Register<BorrowBookViewModel>();//借书ViewModel
            SimpleIoc.Default.Register<ReturnBookViewModel>();//还书ViewModel
            SimpleIoc.Default.Register<ReservationBookViewModel>();//预约ViewModel
            SimpleIoc.Default.Register<LoginViewModel>();//登陆ViewModel
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
        /// 测试窗口
        /// </summary>
        public TextViewModel TextViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TextViewModel>();
            }
        }
        /// <summary>
        /// 首页
        /// </summary>
        public HomePageViewModel HomePageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomePageViewModel>();
            }
        }
        /// <summary>
        /// 借书
        /// </summary>
        public BorrowBookViewModel BorrowBookViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BorrowBookViewModel>();
            }
        }
        /// <summary>
        /// 还书
        /// </summary>
        public ReturnBookViewModel ReturnBookViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ReturnBookViewModel>();
            }
        }
        /// <summary>
        /// 预约
        /// </summary>
        public ReservationBookViewModel ReservationBookViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ReservationBookViewModel>();
            }
        }
        /// <summary>
        /// 登陆
        /// </summary>
        public LoginViewModel LoginViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }
        /// <summary>
        /// 创建导航服务
        /// </summary>
        /// <returns></returns>
        private INavigationService CreateNavigationService()
        {
            var navigationService = new NavigationService();
            //主窗口
            navigationService.Configure(ViewNames.MAIN_VIEW, new Uri("/MainWindow.xaml", UriKind.RelativeOrAbsolute));
            //测试窗口页
            navigationService.Configure(ViewNames.TEXT_VIEW, new Uri("/TextView.xaml", UriKind.RelativeOrAbsolute));
            //首页
            navigationService.Configure(ViewNames.HOMEPAGE_VIEW, new Uri("/HomePageView.xaml", UriKind.RelativeOrAbsolute));
            //首页
            navigationService.Configure(ViewNames.BORROWBOOK_VIEW, new Uri("/BorrowBookView.xaml", UriKind.RelativeOrAbsolute));
            //首页
            navigationService.Configure(ViewNames.RETURNBOOK_VIEW, new Uri("/ReturnBookView.xaml", UriKind.RelativeOrAbsolute));
            //首页
            navigationService.Configure(ViewNames.RESERVATIONBOOK_VIEW, new Uri("/ReservationBookView.xaml", UriKind.RelativeOrAbsolute));
            //首页
            navigationService.Configure(ViewNames.LOGIN_VIEW, new Uri("/LoginView.xaml", UriKind.RelativeOrAbsolute));
            return navigationService;
        }
    }
}
