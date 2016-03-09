using OpenWeen.Core.Model;
using OpenWeen.Core.Model.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Api.Favorites
{
    public class FavorList : Statuses.StatusesBase
    {
        public static async Task<MessageListModel> GetFavorList(int count, int page)
            => await Get(count, page, Constants.FAVORITES_LIST);
    }
}
