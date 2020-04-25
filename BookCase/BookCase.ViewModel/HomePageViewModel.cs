using BookCase.Common;
using BookCase.Common.IViewModels;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookCase.ViewModel
{
    public class HomePageViewModel : ReaderViewModelBase
    {
        public HomePageViewModel(INavigationService navigationService, IDataService dataService)
        {
            base.navigationService = navigationService;
            base.dataService = dataService;
        }
        #region 重写父类
        protected override void InitViewModel()
        {
            
        }

        protected override void ResetViewModel()
        {
            
        }
        #endregion
        #region Command
        /// <summary>
        /// 借书
        /// </summary>
        public ICommand LendCommand => new RelayCommand(LendBook);
        /// <summary>
        /// 还书
        /// </summary>
        public ICommand ReturnCommand => new RelayCommand(ReturnBook);
        /// <summary>
        /// 预约
        /// </summary>
        public ICommand ReservationCommand => new RelayCommand(ReservationBook);
        /// <summary>
        /// 登陆
        /// </summary>
        public ICommand LoginCommand => new RelayCommand(LoginBook);
        #endregion
        #region 方法
        /// <summary>
        /// 借书
        /// </summary>
        private void LendBook()
        {

        }
        /// <summary>
        /// 还书
        /// </summary>
        private void ReturnBook()
        {

        }
        /// <summary>
        /// 预约
        /// </summary>
        private void ReservationBook()
        {

        }
        /// <summary>
        /// 登陆
        /// </summary>
        private void LoginBook()
        {

        }
        #endregion
    }
}
