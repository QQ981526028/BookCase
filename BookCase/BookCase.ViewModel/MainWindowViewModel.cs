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
    public class MainWindowViewModel
    {
        private INavigationService cNavigationService;
        public MainWindowViewModel(INavigationService navigationService, IDataService dataService)
        {
            cNavigationService = navigationService;
            dataService.NextPage = "textView";
        }
        public ICommand LoadCommand => new RelayCommand(Load);
        private void Load()
        {
            cNavigationService.NavigateTo(ViewNames.TEXT_VIEW);
        }


    }
}
