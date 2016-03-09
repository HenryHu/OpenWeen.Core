using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model.Types
{
    /// <summary>
    /// 过滤类型
    /// </summary>
    public enum FeatureType
    {
        /// <summary>
        /// 全部
        /// </summary>
        All = 0,
        /// <summary>
        /// 原创
        /// </summary>
        Origin,
        /// <summary>
        /// 图片
        /// </summary>
        Picture,
        /// <summary>
        /// 视频
        /// </summary>
        Video,
        /// <summary>
        /// 音乐
        /// </summary>
        Music = 4,
    }
}
