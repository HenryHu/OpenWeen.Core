using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model.Status
{
    public class PictureModel
    {
        [JsonProperty("pic_id")]
        public string PicID { get; set; }
        [JsonProperty("thumbnail_pic")]
        public string ThumbnailPic { get; set; }
        [JsonProperty("bmiddle_pic")]
        public string BmiddlePic { get; set; }
        [JsonProperty("original_pic")]
        public string OriginalPic { get; set; }
    }
}
