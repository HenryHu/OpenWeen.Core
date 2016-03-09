using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model
{
    public class UnReadModel
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
    }
}
