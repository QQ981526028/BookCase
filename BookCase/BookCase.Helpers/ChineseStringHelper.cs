using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyPinyin.Core;

namespace BookCase.Helpers
{
    /// <summary>
    /// 中文字符串帮助类
    /// </summary>
    public class ChineseStringHelper
    {
        /// <summary>
        /// 获取中文字符串汉字首字母拼音
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetShortName(string name)
        {
            StringBuilder shortTitleBuilder = new StringBuilder();
            var shortName = PinyinHelper.GetPinyin(name, ",").Trim().Split(',');
            foreach (var item in shortName)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    shortTitleBuilder.Append(item.First());
                }
            }
            return shortTitleBuilder.ToString().ToLower();
        }
    }
}
