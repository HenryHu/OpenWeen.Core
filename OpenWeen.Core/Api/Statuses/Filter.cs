﻿using Newtonsoft.Json;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Api.Statuses
{
    public class Filter
    {
        /// <summary>
        /// 屏蔽某条微博
        /// </summary>
        /// <param name="id">微博id。</param>
        /// <returns></returns>
        public static async Task<MessageModel> Create(long id)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(id), new StringContent(id.ToString()) },
            };
            return JsonConvert.DeserializeObject<MessageModel>(await HttpHelper.PostAsync(Constants.FILTER_CREATE, param));
        }
    }
}
