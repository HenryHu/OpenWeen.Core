using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenWeen.Core.Model;
using OpenWeen.Core.Model.Status;

namespace OpenWeen.Core.Api.Statuses
{
    public class Bilateral : StatusesBase
    {
        public static async Task<MessageListModel> GetBilateral(int count, int page)
            => await Get(count, page, Constants.BILATERAL_TIMELINE);
    }
}
