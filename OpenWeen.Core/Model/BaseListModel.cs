using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenWeen.Core.Model;

namespace OpenWeen.Core.Model
{
    public abstract class BaseListModel : BaseModel
    {
        [JsonProperty("ad")]
        public List<ADModel> AD { get; set; }
    }
}
