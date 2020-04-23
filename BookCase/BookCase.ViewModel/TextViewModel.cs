using BookCase.Common.IViewModels;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCase.ViewModel
{
    /// <summary>
    /// 测试ViewModel
    /// </summary>
    public class TextViewModel : ViewModelBase
    {
        public TextViewModel(IDataService dataService)
        {
            PageName = dataService.NextPage;
        }
        private string pageName = string.Empty;
        /// <summary>
        /// logo地址
        /// </summary>
        public string PageName
        {
            get
            {
                return pageName;
            }
            set
            {
                if (pageName != value)
                {
                    this.pageName = value;
                    RaisePropertyChanged("PageName");
                }
            }
        }
    }
}
