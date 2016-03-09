using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model.Types
{
    /// <summary>
    /// 来源类型
    /// </summary>
    public enum SourceType
    {
        /// <summary>
        /// 全部
        /// </summary>
        All = 0,
        /// <summary>
        /// 来自微博
        /// </summary>
        Weibo,
        /// <summary>
        /// 来自微群
        /// </summary>
        MicroGroup = 2,
    }
}
