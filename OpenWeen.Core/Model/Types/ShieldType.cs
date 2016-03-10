using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model.Types
{
    /// <summary>
    /// 屏蔽微博类型
    /// </summary>
    public enum ShieldType
    {
        /// <summary>
        /// 仅屏蔽当前@提到我的微博
        /// </summary>
        CurrentOnly = 0,
        /// <summary>
        /// 屏蔽当前@提到我的微博，以及后续对其转发而引起的@提到我的微博
        /// </summary>
        WithFollowUp = 1,
    }
}
