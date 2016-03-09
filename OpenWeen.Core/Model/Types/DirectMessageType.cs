using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model.Types
{
    /// <summary>
    /// 私信类型
    /// </summary>
    public enum DirectMessageType
    {
        /// <summary>
        /// 发件箱
        /// </summary>
        Outbox = 0,
        /// <summary>
        /// 收件箱
        /// </summary>
        Inbox = 1,
    }
}
