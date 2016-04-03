using System;
using Newtonsoft.Json;

namespace OpenWeen.Core.Model
{
    public class LimitStatusModel
    {
        [JsonProperty("ip_limit")]
        public long IpLimit { get; set; }

        [JsonProperty("limit_time_unit")]
        public string LimitTimeUnit { get; set; }

        [JsonProperty("remaining_ip_hits")]
        public long RemainingIpHits { get; set; }

        [JsonProperty("remaining_user_hits")]
        public int RemainingUserHits { get; set; }

        [JsonProperty("reset_time")]
        public string ResetTimeValue { get; set; }

        public DateTime ResetTime => DateTime.Parse(ResetTimeValue);

        [JsonProperty("reset_time_in_seconds")]
        public long ResetTimeInSeconds { get; set; }

        [JsonProperty("user_limit")]
        public int UserLimit { get; set; }
    }
}