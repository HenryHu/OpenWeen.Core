using Newtonsoft.Json;

namespace OpenWeen.Core.Model.Status
{
    public class PictureModel
    {
        public PictureModel()
        {

        }
        public PictureModel(UserTimelineImageModel item)
        {
            if (item != null)
            {
                PicID = item.pic_id;
                ThumbnailPic = item.thumbnail.url;
                BmiddlePic = item.bmiddle.url;
                OriginalPic = item.original.url;
            }
        }
        public PictureModel(string id)
        {
            PicID = id;
            OriginalPic = $"http://ww1.sinaimg.cn/large/{id}.jpg";
            ThumbnailPic = $"http://ww1.sinaimg.cn/thumbnail/{id}.jpg";
            BmiddlePic = $"http://ww1.sinaimg.cn/bmiddle/{id}.jpg";
        }
        [JsonProperty("pic_id")]
        public string PicID { get; set; }

        [JsonProperty("thumbnail_pic")]
        public string ThumbnailPic { get; set; }

        [JsonProperty("bmiddle_pic")]
        public string BmiddlePic { get; set; }

        [JsonProperty("original_pic")]
        public string OriginalPic { get; set; }
        public string ToBmiddle => string.IsNullOrEmpty(BmiddlePic) ? ThumbnailPic.Replace("thumbnail", "bmiddle") : BmiddlePic;
    }
}