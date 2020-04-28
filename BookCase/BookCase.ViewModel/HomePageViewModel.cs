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
        public ICommand BorrowCommand => new RelayCommand(BorrowBook);
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
        public ICommand LoginCommand => new RelayCommand(Login);
        #endregion
        #region 方法
        /// <summary>
        /// 借书
        /// </summary>
        private void BorrowBook()
        {
            navigationService.NavigateTo(ViewNames.BORROWBOOK_VIEW);
        }
        /// <summary>
        /// 还书
        /// </summary>
        private void ReturnBook()
        {
            navigationService.NavigateTo(ViewNames.RETURNBOOK_VIEW);
        }
        /// <summary>
        /// 预约
        /// </summary>
        private void ReservationBook()
        {
            navigationService.NavigateTo(ViewNames.RESERVATIONBOOK_VIEW);
        }
        /// <summary>
        /// 登陆
        /// </summary>
        private void Login()
        {
            navigationService.NavigateTo(ViewNames.LOGIN_VIEW);
        }
        #endregion
    }
}
