using BookCase.Common;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Windows;
using System.Windows.Input;

namespace BookCase.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region 成员变量
        /// <summary>
        /// 导航服务类
        /// </summary>
        private INavigationService navigationService;
        #endregion
        #region 构造器
        public MainWindowViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
        #endregion
        #region Command
        /// <summary>
        /// Load
        /// </summary>
        public ICommand LoadCommand => new RelayCommand(Load);
        /// <summary>
        /// UnLoad
        /// </summary>
        public ICommand UnLoadCommand => new RelayCommand(UnLoad);
        #endregion
        /// <summary>
        /// 加载
        /// </summary>
        private void Load()
        {
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            navigationService.NavigateTo(ViewNames.HOMEPAGE_VIEW);
        }
        /// <summary>
        /// 卸载
        /// </summary>
        private void UnLoad()
        {
            
        }

    }
}
