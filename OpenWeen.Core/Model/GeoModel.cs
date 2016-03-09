using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model
{
    public class GeoModel
    {
        [JsonProperty("longitude")]
        public string Longitude { get; set; }
        [JsonProperty("latitude")]
        public string Latitude { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("province")]
        public string Province { get; set; }
        [JsonProperty("city_name")]
        public string CityName { get; set; }
        [JsonProperty("province_name")]
        public string ProvinceName { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("pinyin")]
        public string Pinyin { get; set; }
        [JsonProperty("more")]
        public string More { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
