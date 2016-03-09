namespace OpenWeen.Core.Api
{
    internal class Constants
    {

        public const string SINA_BASE_URL = "https://api.weibo.com/2/";

        // Login
        public const string OAUTH2_ACCESS_AUTHORIZE = "https://open.weibo.cn/oauth2/authorize";
        public const string OAUTH2_ACCESS_TOKEN = SINA_BASE_URL + "oauth2/access_token";

        // User / Account
        public const string GET_UID = SINA_BASE_URL + "account/get_uid.json";//Account.GetUid
        public const string USER_SHOW = SINA_BASE_URL + "users/show.json";//User.GetUser,User.GetUserByName
        public const string USER_COUNTS = SINA_BASE_URL + "users/counts.json";//User.GetUserInfo

        // Statuses
        public const string PUBLIC_TIMELINE = SINA_BASE_URL + "statuses/public_timeline";//Public.GetPublicTimeline
        public const string HOME_TIMELINE = SINA_BASE_URL + "statuses/home_timeline.json";//Home.GetTimeline
        public const string USER_TIMELINE = SINA_BASE_URL + "statuses/user_timeline.json";//UserTimeline.GetUserTimeline
        public const string BILATERAL_TIMELINE = SINA_BASE_URL + "statuses/bilateral_timeline.json";//Bilateral.GetBilateral
        public const string TIMELINE_BATCH = SINA_BASE_URL + "statuses/timeline_batch.json";//Timeline.GetTimelineBatch
        public const string MENTIONS = SINA_BASE_URL + "statuses/mentions.json";//Mentions.GetMentions,Mentions.GetMentionsSince
        public const string REPOST_TIMELINE = SINA_BASE_URL + "statuses/repost_timeline.json";//Repost.GetRepost
        public const string UPDATE = SINA_BASE_URL + "statuses/update.json";//Helpers.Post
        public const string UPLOAD = SINA_BASE_URL + "statuses/upload.json";//Helpers.PostWithPic
        public const string REPOST = SINA_BASE_URL + "statuses/repost.json";//Helpers.Post
        public const string DESTROY = SINA_BASE_URL + "statuses/destroy.json";//Helpers.DeletePost
        public const string UPLOAD_PIC = SINA_BASE_URL + "statuses/upload_pic.json";//Helpers.UploadPicture
        public const string UPLOAD_URL_TEXT = SINA_BASE_URL + "statuses/upload_url_text.json";//Helpers.PostWithMultiPics
        public const string QUERY_ID = SINA_BASE_URL + "statuses/queryid.json";//Query.QueryID
        public const string QUERY_MID = SINA_BASE_URL + "statuses/querymid.json";//Query.QueryMID
        public const string SHOW = SINA_BASE_URL + "statuses/show.json";//Query.GetStatus
        public const string SHOW_BATCH = SINA_BASE_URL + "statuses/show_batch.json";//Query.GetStatus
        public const string EMOTIONS = SINA_BASE_URL + "emotions.json";//Emotions.GetEmotions

        // Comments
        public const string COMMENTS_TIMELINE = SINA_BASE_URL + "comments/timeline.json";//Comment.GetComment,Comment.GetCommentSince
        public const string COMMENTS_MENTIONS = SINA_BASE_URL + "comments/mentions.json";//Comment.GetCommentMentions
        public const string COMMENTS_TO_ME = SINA_BASE_URL + "comments/to_me.json";//Comment.GetCommentToMe
        public const string COMMENTS_SHOW = SINA_BASE_URL + "comments/show.json";//Comment.GetCommentStatus
        public const string COMMENTS_CREATE = SINA_BASE_URL + "comments/create.json";//Comment.PostComment
        public const string COMMENTS_REPLY = SINA_BASE_URL + "comments/reply.json";//Comment.Reply
        public const string COMMENTS_DESTROY = SINA_BASE_URL + "comments/destroy.json";//Comment.Delete

        // Favorites
        public const string FAVORITES_CREATE = SINA_BASE_URL + "favorites/create.json";//Helpers.AddFavor
        public const string FAVORITES_DESTROY = SINA_BASE_URL + "favorites/destroy.json";//Helpers.RemoveFavor
        public const string FAVORITES_LIST = SINA_BASE_URL + "favorites.json";//FavorList.GetFavorList

        // Search
        public const string SEARCH_TOPICS = SINA_BASE_URL + "search/topics.json";//Topics.GetSearchTopics
        public const string SEARCH_STATUSES = SINA_BASE_URL + "search/statuses.json";//Search.SearchStatus
        public const string SEARCH_USERS = SINA_BASE_URL + "search/users.json";//Search.SearchUsers
        public const string SEARCH_SUGGESTIONS_AT_USERS = SINA_BASE_URL + "search/suggestions/at_users.json";//Search.SuggestAtUser

        // Friendships
        public const string FRIENDSHIPS_FRIENDS = SINA_BASE_URL + "friendships/friends.json";//Friends.GetFriendsOf
        public const string FRIENDSHIPS_FOLLOWERS = SINA_BASE_URL + "friendships/followers.json";//Friends.GetFollowersOf
        public const string FRIENDSHIPS_CREATE = SINA_BASE_URL + "friendships/create.json";//Friends.Follow
        public const string FRIENDSHIPS_DESTROY = SINA_BASE_URL + "friendships/destroy.json";//Friends.UnFollow
        public const string FRIENDSHIPS_GROUPS = SINA_BASE_URL + "friendships/groups.json";//Groups.GetGroups
        public const string FRIENDSHIPS_GROUPS_IS_MEMBER = SINA_BASE_URL + "friendships/groups/is_member.json";//Groups.IsMember
        public const string FRIENDSHIPS_GROUPS_TIMELINE = SINA_BASE_URL + "friendships/groups/timeline.json";//Groups.GetGroupTimeline
        public const string FRIENDSHIPS_GROUPS_CREATE = SINA_BASE_URL + "friendships/groups/create.json";//Groups.CreateGroup
        public const string FRIENDSHIPS_GROUPS_DESTROY = SINA_BASE_URL + "friendships/groups/destroy.json";//Groups.DeleteGroup
        public const string FRIENDSHIPS_GROUPS_MEMBERS_ADD = SINA_BASE_URL + "friendships/groups/members/add.json";//Groups.AddToGroup
        public const string FRIENDSHIPS_GROUPS_MEMBERS_DESTROY = SINA_BASE_URL + "friendships/groups/members/destroy.json";//Groups.RemoveFromGroup

        // Direct Message
        public const string DIRECT_MESSAGES = SINA_BASE_URL + "direct_messages.json";//DirectMessages.GetDirectMessages
        public const string DIRECT_MESSAGES_USER_LIST = SINA_BASE_URL + "direct_messages/user_list.json";//DirectMessage.GetUserList
        public const string DIRECT_MESSAGES_CONVERSATION = SINA_BASE_URL + "direct_messages/conversation.json";//DirectMessage.GetConversation
        public const string DIRECT_MESSAGES_SEND = SINA_BASE_URL + "direct_messages/new.json";//DirectMessage.Send
        public const string DIRECT_MESSAGES_THUMB_PIC = "https://upload.api.weibo.com/2/mss/msget_thumbnail?fid=%d&access_token=%s&high=%d&width=%d";//TODO: replace %d and %s
        public const string DIRECT_MESSAGES_ORIG_PIC = "https://upload.api.weibo.com/2/mss/msget?fid=%d&access_token=%s";//TODO: replace %d and %s
        public const string DIRECT_MESSAGES_UPLOAD_PIC = "https://upload.api.weibo.com/2/mss/upload.json?tuid=";//DirectMessage.SendPicture

        // Remind
        public const string REMIND_UNREAD_COUNT = "https://rm.api.weibo.com/2/remind/unread_count.json";//Remind.GetUnRead
        public const string REMIND_UNREAD_SET_COUNT = "https://rm.api.weibo.com/2/remind/set_count.json";//Remind.ClearUnRead

        // Attitude
        public const string ATTITUDE_CREATE = SINA_BASE_URL + "attitudes/create.json";//Attitudes.Like
        public const string ATTITUDE_DESTROY = SINA_BASE_URL + "attitudes/destroy.json";//Attitudes.UnLike

        // Short Url
        public const string SHORT_URL_SHORTEN = SINA_BASE_URL + "short_url/shorten.json";//ShortUrl.Shorten
        public const string SHORT_URL_EXPAND = SINA_BASE_URL + "short_url/expand.json";//ShortUrl.Expand

    }
}
