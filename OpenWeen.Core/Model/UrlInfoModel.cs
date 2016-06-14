using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OpenWeen.Core.Model
{
    public class UrlInfoListModel
    {
        [JsonProperty("urls")]
        public UrlInfoModel[] Urls { get; set; }
    }

    public class UrlInfoModel
    {
        [JsonProperty("result")]
        public bool Result { get; set; }
        [JsonProperty("last_modified")]
        public long LastModified { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("url_short")]
        public string UrlShort { get; set; }
        [JsonProperty("annotations")]
        internal object annotations;
        public List<AnnotationModel> AnnotationList => JsonConvert.DeserializeObject<List<AnnotationModel>>(annotations.ToString());
        public AnnotationModel Annotations => JsonConvert.DeserializeObject<AnnotationModel>(annotations.ToString());
        [JsonProperty("type")]
        public int Type { get; set; }//this is totally different from the document
    }
    public enum UrlType
    {
        WebLink = 0,
        Video,
        Music,
        Event,
        Vote = 5,
    }
    public class AnnotationModel
    {
        [JsonProperty("object")]
        public ObjectModel Item { get; set; }
    }

    public class ObjectModel
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        [JsonProperty("pic_ids")]
        public string[] PicIds { get; set; }
        [JsonProperty("object_type")]
        public string ObjectType { get; set; }
    }
}
