using Newtonsoft.Json;
using OpenWeen.Core.Model.User;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model.DirectMessage
{
    public class DirectMessageModel
    {
        [JsonProperty("id")]
        public long ID { get; set; }
        [JsonProperty("idstr")]
        public string IDStr { get; set; }
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
        public DateTime CreateTime => DateTime.ParseExact(CreatedAt, "ddd MMM dd HH:mm:ss K yyyy", CultureInfo.InvariantCulture);
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("sender_id")]
        public long SenderID { get; set; }
        [JsonProperty("recipient_id")]
        public long RecipientID { get; set; }
        [JsonProperty("recipient")]
        public UserModel Recipient { get; set; }
        [JsonProperty("sender")]
        public UserModel Sender { get; set; }
        [JsonProperty("sender_screen_name")]
        public string SenderScreenName { get; set; }
        [JsonProperty("recipient_screen_name")]
        public string RecipientScreenName { get; set; }
        [JsonProperty("att_ids")]
        public long[] AttIDs { get; set; } = { 0, 0 };
    }
}
