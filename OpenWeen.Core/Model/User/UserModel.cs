using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model.User
{
    public class  UserModel : UserBaseModel
    {
        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("remark")]
        public string Remark { get; set; }
        [JsonProperty("province")]
        public string Province { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("profile_image_url")]
        public string ProfileImageUrl { get; set; }
        [JsonProperty("domain")]
        public string Domain { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("favourites_count")]
        public int FavouritesCount { get; set; } = 0;
        [JsonProperty("verified_type")]
        public int VerifiedType { get; set; }
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
        public DateTime CreateTime => DateTime.ParseExact(CreatedAt, "ddd MMM dd HH:mm:ss K yyyy", CultureInfo.InvariantCulture);
        [JsonProperty("following")]
        public bool Following { get; set; } = false;
        [JsonProperty("allow_all_act_msg")]
        public bool AllowAllActMsg { get; set; } = false;
        [JsonProperty("geo_enabled")]
        public bool GeoEnabled { get; set; } = false;
        [JsonProperty("verified")]
        public bool Verified { get; set; } = false;
        [JsonProperty("allow_all_comment")]
        public bool AllowAllComment { get; set; } = false;
        [JsonProperty("avatar_large")]
        public string AvatarLarge { get; set; }
        [JsonProperty("verified_reason")]
        public string VerifiedReason { get; set; }
        [JsonProperty("follow_me")]
        public bool FollowMe { get; set; } = false;
        [JsonProperty("online_status")]
        public int OnlineStatus { get; set; } = 0;
        [JsonProperty("bi_followers_count")]
        public int BiFollowersCount { get; set; } = 0;
        [JsonProperty("cover_image")]
        public string Coverimage { get; set; } = "";
        [JsonProperty("cover_image_phone")]
        public string CoverImagePhone { get; set; } = "";
        [JsonProperty("avatar_hd")]
        public string AvatarHD { get; set; } = "";
        [JsonProperty("weihao")]
        public string Weihao { get; set; }
        [JsonProperty("lang")]
        public string Lang { get; set; }
        [JsonProperty("level")]
        public int Level { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
