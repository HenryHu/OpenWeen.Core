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