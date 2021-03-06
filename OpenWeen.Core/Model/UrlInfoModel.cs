﻿using System;
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
        [JsonProperty("url_long")]
        public string UrlLong { get; set; }
        [JsonProperty("annotations")]
        internal object annotations;
        public List<AnnotationModel> AnnotationList => annotations != null ? JsonConvert.DeserializeObject<List<AnnotationModel>>(annotations.ToString()) : null;
        public AnnotationModel Annotations => annotations != null ? JsonConvert.DeserializeObject<AnnotationModel>(annotations.ToString()) : null;
        [JsonProperty("type")]
        public int Type { get; set; }//this is totally different from the document
    }
    public enum UrlType
    {
        WebLink = 0,
        Video = 1,
        Music = 2,
        Event = 3,
        Vote = 5,
    }
    public class AnnotationModel
    {
        [JsonProperty("object")]
        public object ObjectItem { get; set; }

        public ObjectModel Item => JsonConvert.DeserializeObject<ObjectModel>(ObjectItem.ToString());
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
        [JsonProperty("object")]
        public object UrlObject { get; set; }
        [JsonProperty("original_url")]
        public string OriginalUrl { get; set; }
        [JsonProperty("stream")]
        public StreamModel Stream { get; set; }
    }
    public class StreamModel
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
