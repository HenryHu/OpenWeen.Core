using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenWeen.Core.Model.Comment
{
    public class CommentListModel : BaseListModel
    {
        [JsonProperty("comments")]
        public List<CommentModel> Comments { get; set; }
    }
}