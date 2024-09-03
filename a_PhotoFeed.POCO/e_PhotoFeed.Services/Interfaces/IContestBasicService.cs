using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using d_PhotoFeed.DTO;

namespace e_PhotoFeed.Services.Interfaces
{
    public interface IContestBasicService
    {
        int AddContest(ContestBasicDTO newContestBasic);
        ContestBasicDTO GetContestBasic(int id);
        List<ContestBasicDTO> GetActiveContestsBasic();
        List<ContestBasicDTO> GetInactiveContestsBasic();
        void EndContest(int id);
    }
}
