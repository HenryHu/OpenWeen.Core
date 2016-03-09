using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model.Types
{
    /// <summary>
    /// 作者类型
    /// </summary>
    public enum AuthorType
    {
        /// <summary>
        /// 全部
        /// </summary>
        All = 0,
        /// <summary>
        /// 我关注的人
        /// </summary>
        FollowedOnly,
        /// <summary>
        /// 陌生人
        /// </summary>
        Stranger = 2,
    }
}
