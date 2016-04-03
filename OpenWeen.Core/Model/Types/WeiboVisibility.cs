namespace OpenWeen.Core.Model.Types
{
    /// <summary>
    /// 微博的可见性
    /// </summary>
    public enum WeiboVisibility
    {
        /// <summary>
        /// 所有人能看
        /// </summary>
        All = 0,

        /// <summary>
        /// 仅自己可见
        /// </summary>
        OnlyMe,

        /// <summary>
        /// 密友可见
        /// </summary>
        OnlyFriends,

        /// <summary>
        /// 指定分组可见
        /// </summary>
        SpecifiedGroup = 3,
    }
}