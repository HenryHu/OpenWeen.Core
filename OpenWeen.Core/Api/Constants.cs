namespace OpenWeen.Core.Api
{
    internal class Constants
    {

        public const string SINA_BASE_URL = "https://api.weibo.com/2/";

        // Login
        public const string OAUTH2_ACCESS_AUTHORIZE = "https://open.weibo.cn/oauth2/authorize";
        public const string OAUTH2_ACCESS_TOKEN = SINA_BASE_URL + "oauth2/access_token";

        // User / Account
        public const string GET_UID = SINA_BASE_URL + "account/get_uid.json";
        public const string USER_SHOW = SINA_BASE_URL + "users/show.json";

        // Statuses
        public const string HOME_TIMELINE = SINA_BASE_URL + "statuses/home_timeline.json";
        public const string USER_TIMELINE = SINA_BASE_URL + "statuses/user_timeline.json";
        public const string BILATERAL_TIMELINE = SINA_BASE_URL + "statuses/bilateral_timeline.json";
        public const string MENTIONS = SINA_BASE_URL + "statuses/mentions.json";
        public const string REPOST_TIMELINE = SINA_BASE_URL + "statuses/repost_timeline.json";
        public const string UPDATE = SINA_BASE_URL + "statuses/update.json";
        public const string UPLOAD = SINA_BASE_URL + "statuses/upload.json";
        public const string REPOST = SINA_BASE_URL + "statuses/repost.json";
        public const string DESTROY = SINA_BASE_URL + "statuses/destroy.json";
        public const string UPLOAD_PIC = SINA_BASE_URL + "statuses/upload_pic.json";
        public const string UPLOAD_URL_TEXT = SINA_BASE_URL + "statuses/upload_url_text.json";
        public const string QUERY_ID = SINA_BASE_URL + "statuses/queryid.json";
        public const string QUERY_MID = SINA_BASE_URL + "statuses/querymid.json";
        public const string SHOW = SINA_BASE_URL + "statuses/show.json";
        public const string EMOTIONS = SINA_BASE_URL + "emotions.json";

        // Comments
        public const string COMMENTS_TIMELINE = SINA_BASE_URL + "comments/timeline.json";
        public const string COMMENTS_MENTIONS = SINA_BASE_URL + "comments/mentions.json";
        public const string COMMENTS_TO_ME = SINA_BASE_URL + "comments/to_me.json";
        public const string COMMENTS_SHOW = SINA_BASE_URL + "comments/show.json";
        public const string COMMENTS_CREATE = SINA_BASE_URL + "comments/create.json";
        public const string COMMENTS_REPLY = SINA_BASE_URL + "comments/reply.json";
        public const string COMMENTS_DESTROY = SINA_BASE_URL + "comments/destroy.json";

        // Favorites
        public const string FAVORITES_CREATE = SINA_BASE_URL + "favorites/create.json";
        public const string FAVORITES_DESTROY = SINA_BASE_URL + "favorites/destroy.json";
        public const string FAVORITES_LIST = SINA_BASE_URL + "favorites.json";

        // Search
        public const string SEARCH_TOPICS = SINA_BASE_URL + "search/topics.json";
        public const string SEARCH_STATUSES = SINA_BASE_URL + "search/statuses.json";
        public const string SEARCH_USERS = SINA_BASE_URL + "search/users.json";
        public const string SEARCH_SUGGESTIONS_AT_USERS = SINA_BASE_URL + "search/suggestions/at_users.json";

        // Friendships
        public const string FRIENDSHIPS_FRIENDS = SINA_BASE_URL + "friendships/friends.json";
        public const string FRIENDSHIPS_FOLLOWERS = SINA_BASE_URL + "friendships/followers.json";
        public const string FRIENDSHIPS_CREATE = SINA_BASE_URL + "friendships/create.json";
        public const string FRIENDSHIPS_DESTROY = SINA_BASE_URL + "friendships/destroy.json";
        public const string FRIENDSHIPS_GROUPS = SINA_BASE_URL + "friendships/groups.json";
        public const string FRIENDSHIPS_GROUPS_IS_MEMBER = SINA_BASE_URL + "friendships/groups/is_member.json";
        public const string FRIENDSHIPS_GROUPS_TIMELINE = SINA_BASE_URL + "friendships/groups/timeline.json";
        public const string FRIENDSHIPS_GROUPS_CREATE = SINA_BASE_URL + "friendships/groups/create.json";
        public const string FRIENDSHIPS_GROUPS_DESTROY = SINA_BASE_URL + "friendships/groups/destroy.json";
        public const string FRIENDSHIPS_GROUPS_MEMBERS_ADD = SINA_BASE_URL + "friendships/groups/members/add.json";
        public const string FRIENDSHIPS_GROUPS_MEMBERS_DESTROY = SINA_BASE_URL + "friendships/groups/members/destroy.json";

        // Direct Message
        public const string DIRECT_MESSAGES = SINA_BASE_URL + "direct_messages.json";
        public const string DIRECT_MESSAGES_USER_LIST = SINA_BASE_URL + "direct_messages/user_list.json";
        public const string DIRECT_MESSAGES_CONVERSATION = SINA_BASE_URL + "direct_messages/conversation.json";
        public const string DIRECT_MESSAGES_SEND = SINA_BASE_URL + "direct_messages/new.json";
        public const string DIRECT_MESSAGES_THUMB_PIC = "https://upload.api.weibo.com/2/mss/msget_thumbnail?fid=%d&access_token=%s&high=%d&width=%d";//TODO: replace %d and %s
        public const string DIRECT_MESSAGES_ORIG_PIC = "https://upload.api.weibo.com/2/mss/msget?fid=%d&access_token=%s";//TODO: replace %d and %s
        public const string DIRECT_MESSAGES_UPLOAD_PIC = "https://upload.api.weibo.com/2/mss/upload.json?tuid=";

        // Remind
        public const string REMIND_UNREAD_COUNT = "https://rm.api.weibo.com/2/remind/unread_count.json";
        public const string REMIND_UNREAD_SET_COUNT = "https://rm.api.weibo.com/2/remind/set_count.json";

        // Attitude
        public const string ATTITUDE_CREATE = SINA_BASE_URL + "attitudes/create.json";
        public const string ATTITUDE_DESTROY = SINA_BASE_URL + "attitudes/destroy.json";

        // Short Url
        public const string SHORT_URL_SHORTEN = SINA_BASE_URL + "short_url/shorten.json";
        public const string SHORT_URL_EXPAND = SINA_BASE_URL + "short_url/expand.json";

    }
}
