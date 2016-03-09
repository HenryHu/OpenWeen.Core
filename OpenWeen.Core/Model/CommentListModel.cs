using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model
{
    public class CommentListModel : BaseListModel
    {
        [JsonProperty("comments")]
        public List<CommentModel> Comments { get; set; }
    }
}
