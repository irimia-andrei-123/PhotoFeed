using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using d_PhotoFeed.DTO;

namespace e_PhotoFeed.Services.Interfaces
{
    public interface ISearchpageService
    {
        List<SearchImage> GetPicturesBasedOnTags(List<string> tags);
    }
}
