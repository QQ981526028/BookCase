using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCase.Common.IViewModels
{
    public class DataService : IDataService
    {
        public string NavigateToPage { get ; set ; }
        public bool IsAdminLogin { get ; set ; }
        public string CurrentLoginTag { get ; set ; }
        public string NextPage { get ; set ; }
        public bool IsOneLoginModel { get ; set ; }
    }
}
