using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using d_PhotoFeed.DTO;

namespace e_PhotoFeed.Services.Interfaces
{
    public interface IContestProService
    {
        int AddContest(ContestProDTO newContestPro);
        ContestProDTO GetContestPro(int id);
        List<ContestProDTO> GetActiveContestsPro();
        List<ContestProDTO> GetInactiveContestsPro();
        void EndContest(int id);
    }
}
