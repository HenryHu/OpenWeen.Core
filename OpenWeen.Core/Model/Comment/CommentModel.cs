using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using OpenWeen.Core.Model.Status;
using System.Reflection;

namespace OpenWeen.Core.Model.Comment
{
    public class CommentModel : BaseModel
    {
        [JsonProperty("source_allowclick")]
        public int SourceAllowClick { get; set; }

        [JsonProperty("source_type")]
        public int SourceType { get; set; }

        [JsonProperty("status")]
        public MessageModel Status { get; set; }

        [JsonProperty("reply_comment")]
        public CommentModel ReplyComment { get; set; }

        [JsonProperty("pic_infos")]
        [JsonConverter(typeof(PicInfosConverter))]
        public IDictionary<string, PicInfoModel> PicInfos { get; set; }

        //public IDictionary<string, PicInfoModel> PicInfos 
        //    => (from structs in UrlStruct from item in structs.PicInfos select new KeyValuePair<string, PicInfoModel>(item.Key, item.Value)).ToDictionary(x => x.Key, x => x.Value);


        [JsonProperty("pic_ids")]
        public string[] PicIds { get; set; }

    }

    internal class PicInfosConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType  != JsonToken.StartArray && reader.TokenType != JsonToken.EndArray)
            {
                return serializer.Deserialize<IDictionary<string, PicInfoModel>>(reader);
            }
            else
            {
                serializer.Deserialize<List<string>>(reader);
            }
            return new Dictionary<string,PicInfoModel>();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }


}