﻿using Newtonsoft.Json;

namespace OpenWeen.Core.Model.User
{
    public class UserBaseModel
    {
        [JsonProperty("id")]
        public long ID { get; set; }

        [JsonProperty("idstr")]
        public string IDStr { get; set; }

        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; } = 0;

        [JsonProperty("friends_count")]
        public int FriendsCount { get; set; } = 0;

        [JsonProperty("statuses_count")]
        public int StatusesCount { get; set; } = 0;
    }
}