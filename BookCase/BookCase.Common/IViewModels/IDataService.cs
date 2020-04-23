using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCase.Common.IViewModels
{
    /// <summary>
    /// 公共变量服务器接口
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// 需要跳转的目标界面
        /// </summary>
        string NavigateToPage { get; set; }
        /// <summary>
        /// 是否是管理员登录
        /// </summary>
        bool IsAdminLogin { get; set; }
        /// <summary>
        /// 当前登录类型
        /// </summary>
        string CurrentLoginTag { get; set; }
        /// <summary>
        /// 要跳转的下一个界面
        /// </summary>
        string NextPage { get; set; }
        /// <summary>
        /// 几种登录方式
        /// </summary>
        bool IsOneLoginModel { get; set; }
    }
}
