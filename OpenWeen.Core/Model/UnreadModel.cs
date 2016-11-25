using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenWeen.Core.Model
{
    public class Ext
    {
        [JsonProperty("follower")]
        public int Follower { get; set; }
    }

    public class Follower
    {
        [JsonProperty("count")]
        public int Count { get; set; }
    }

    public class ExtNew
    {
        [JsonProperty("follower")]
        public Follower Follower { get; set; }
    }

    public class AppMessage
    {
        [JsonProperty("app_unreadcount")]
        public int AppUnreadcount { get; set; }

        [JsonProperty("apps")]
        public IList<object> Apps { get; set; }
    }

    public class UnReadModel
    {
        [JsonProperty("follower")]
        public int Follower { get; set; } = 0;

        [JsonProperty("cmt")]
        public int Cmt { get; set; } = 0;

        [JsonProperty("dm")]
        public int Dm { get; set; } = 0;

        [JsonProperty("chat_group_pc")]
        public int ChatGroupPc { get; set; } = 0;

        [JsonProperty("chat_group_client")]
        public int ChatGroupClient { get; set; } = 0;

        [JsonProperty("mention_status")]
        public int MentionStatus { get; set; } = 0;

        [JsonProperty("mention_cmt")]
        public int MentionCmt { get; set; } = 0;

        [JsonProperty("invite")]
        public int Invite { get; set; } = 0;

        [JsonProperty("badge")]
        public int Badge { get; set; } = 0;

        [JsonProperty("attitude")]
        public int Attitude { get; set; } = 0;

        [JsonProperty("tome")]
        public int Tome { get; set; } = 0;

        [JsonProperty("msgbox")]
        public int Msgbox { get; set; } = 0;

        [JsonProperty("page_follower")]
        public int PageFollower { get; set; } = 0;

        [JsonProperty("all_mention_status")]
        public int AllMentionStatus { get; set; } = 0;

        [JsonProperty("attention_mention_status")]
        public int AttentionMentionStatus { get; set; } = 0;

        [JsonProperty("all_mention_cmt")]
        public int AllMentionCmt { get; set; } = 0;

        [JsonProperty("attention_mention_cmt")]
        public int AttentionMentionCmt { get; set; } = 0;

        [JsonProperty("all_cmt")]
        public int AllCmt { get; set; } = 0;

        [JsonProperty("attention_cmt")]
        public int AttentionCmt { get; set; } = 0;

        [JsonProperty("all_follower")]
        public int AllFollower { get; set; } = 0;

        [JsonProperty("attention_follower")]
        public int AttentionFollower { get; set; } = 0;

        [JsonProperty("page_friends_to_me")]
        public int PageFriendsToMe { get; set; } = 0;

        [JsonProperty("page_group_to_me")]
        public int PageGroupToMe { get; set; } = 0;

        [JsonProperty("hot_status")]
        public int HotStatus { get; set; } = 0;

        [JsonProperty("chat_group_total")]
        public int ChatGroupTotal { get; set; } = 0;

        [JsonProperty("status")]
        public int Status { get; set; } = 0;

        [JsonProperty("ext")]
        public Ext Ext { get; set; }

        [JsonProperty("ext_new")]
        public ExtNew ExtNew { get; set; }

        [JsonProperty("sys_notice")]
        public int SysNotice { get; set; } = 0;

        [JsonProperty("app_message")]
        public AppMessage AppMessage { get; set; }
    }
    /*public class UnReadModel
    {
        [JsonProperty("status")]
        public int Status { get; set; } = 0;

        [JsonProperty("follower")]
        public int Follower { get; set; } = 0;

        [JsonProperty("cmt")]
        public int Cmt { get; set; } = 0;

        [JsonProperty("dm")]
        public int Dm { get; set; } = 0;

        [JsonProperty("mention_status")]
        public int MentionStatus { get; set; } = 0;

        [JsonProperty("mention_cmt")]
        public int MentionCmt { get; set; } = 0;

        [JsonProperty("group")]
        public int Group { get; set; } = 0;

        [JsonProperty("private_group")]
        public int PrivateGroup { get; set; } = 0;

        [JsonProperty("notice")]
        public int Notice { get; set; } = 0;

        [JsonProperty("invite")]
        public int Invite { get; set; } = 0;

        [JsonProperty("badge")]
        public int Badge { get; set; } = 0;

        [JsonProperty("photo")]
        public int Photo { get; set; } = 0;

        [JsonProperty("msgbox")]
        public int MsgBox { get; set; } = 0;

        public override string ToString()
            => $"{Follower}{Cmt}{Dm}{MentionStatus}{MentionCmt}{Group}{PrivateGroup}{Notice}{Invite}{Badge}{Photo}{MsgBox}";
    }*/
}