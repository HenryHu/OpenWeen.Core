using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model.Types
{
    /// <summary>
    /// 在转发的同时发表评论的类型
    /// </summary>
    public enum RepostType
    {
        /// <summary>
        /// 否
        /// </summary>
        None = 0,
        /// <summary>
        /// 评论给当前微博
        /// </summary>
        CommentCurrentWeibo,
        /// <summary>
        /// 评论给原微博
        /// </summary>
        CommentOriginWeibo,
        /// <summary>
        /// 都评论
        /// </summary>
        CommentAll = 3,
    }
}
