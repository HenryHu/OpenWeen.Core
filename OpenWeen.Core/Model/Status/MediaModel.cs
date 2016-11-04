using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OpenWeen.Core.Model.Status
{
    public class MediaModel
    {
        public MediaModel(string id)
        {
            Fid = id;
        }
        [JsonProperty("bypass")]
        public string ByPass { get; set; } = "unistore.image";
        [JsonProperty("createtype")]
        public string CreateType { get; set; } = "localfile";
        [JsonProperty("filterName")]
        public string FilterName { get; set; } = "";
        [JsonProperty("stickerID")]
        public string StickerID { get; set; } = "";
        [JsonProperty("fid")]
        public string Fid { get; set; } = "";
        [JsonProperty("type")]
        public string Type { get; set; } = "pic";
        [JsonProperty("filterID")]
        public string FilterID { get; set; } = "";
        [JsonProperty("picStatus")]
        public int PicStatus { get; set; } = 0;
        public override string ToString() => $"[{JsonConvert.SerializeObject(this)}]";
    }
}
