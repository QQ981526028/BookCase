using BookCase.Common.IViewModels;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookCase.Common
{
    public abstract class ReaderViewModelBase : ViewModelBase
    {
        /// <summary>
        /// 导航服务类
        /// </summary>
        protected INavigationService navigationService;
        /// <summary>
        /// 公共变量
        /// </summary>
        protected IDataService dataService;

        #region Command
        /// <summary>
        /// Load
        /// </summary>
        public ICommand LoadCommand => new RelayCommand(Loaded);
        /// <summary>
        /// UnLoad
        /// </summary>
        public ICommand UnLoadCommand => new RelayCommand(UnLoaded);
        #endregion
        #region 虚拟方法
        protected virtual void Loaded()
        {
            InitViewModel();
        }
        protected virtual void UnLoaded()
        {
            ResetViewModel();
        }
        #endregion
        #region 抽象方法
        /// <summary>
        /// 初始化VM
        /// </summary>
        protected abstract void InitViewModel();
        /// <summary>
        /// 重置VM
        /// </summary>
        protected abstract void ResetViewModel();
        #endregion
    }
}
