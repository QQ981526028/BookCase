using BookCase.Common.IViewModels;
using BookCase.Helpers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        private string leftText;
        public string LeftText
        {
            get
            {
                return leftText;
            }
            set
            {
                if (leftText != value)
                {
                    this.leftText = value;
                    RaisePropertyChanged("LeftText");
                }
            }
        }
        private string rightText;
        public string RightText
        {
            get
            {
                return rightText;
            }
            set
            {
                if (rightText != value)
                {
                    this.rightText = value;
                    RaisePropertyChanged("RightText");
                }
            }
        }

        public ICommand TurnToCommand => new RelayCommand(TurnTo);

        private void TurnTo()
        {
            ChineseStringHelper helper = new ChineseStringHelper();
            RightText = helper.GetShortName(LeftText);
        }
    }
}
