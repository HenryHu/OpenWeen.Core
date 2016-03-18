using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model;

namespace OpenWeen.Core.Api.Statuses
{
    /// <summary>
    /// 表情
    /// </summary>
    public class Emotions
    {
        /// <summary>
        /// 获取表情
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<EmotionModel>> GetEmotions()
            => JsonConvert.DeserializeObject<IEnumerable<EmotionModel>>(await HttpHelper.GetStringAsync(Constants.EMOTIONS, null));
    }
}
