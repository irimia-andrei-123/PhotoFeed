using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using a_PhotoFeed.POCO;
using AutoMapper;
using c_PhotoFeed.Repository.Interfaces;
using d_PhotoFeed.DTO;
using e_PhotoFeed.Services.Interfaces;

namespace e_PhotoFeed.Services.Implementations
{
    public class ContestProService : IContestProService
    {
        private readonly IUnitOfWork _uow;

        public ContestProService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public int AddContest(ContestProDTO newContestPro)
        {
            var newContestProInfo = Mapper.Map<ContestProDTO, ContestPro>(newContestPro);
            _uow.ContestProes.Add(newContestProInfo);
            _uow.ContestProes.Save();
            return newContestProInfo.IdContestPro;
        }

        public ContestProDTO GetContestPro(int id)
        {
            var contestPro = _uow.ContestProes.Where(x => x.IdContestPro == id).SingleOrDefault();
            return Mapper.Map<ContestPro, ContestProDTO>(contestPro);
        }

        public List<ContestProDTO> GetActiveContestsPro()
        {
            var activeContestPro= _uow.ContestProes.Find(x => x.Closed == 0).ToList();
            return Mapper.Map<List<ContestPro>, List<ContestProDTO>>(activeContestPro);
        }

        public List<ContestProDTO> GetInactiveContestsPro()
        {
            var activeContestPro = _uow.ContestProes.Find(x => x.Closed == 1).ToList();
            return Mapper.Map<List<ContestPro>, List<ContestProDTO>>(activeContestPro);
        }

        public void EndContest(int id)
        {
            var contest = _uow.ContestProes.Where(x => x.IdContestPro == id).SingleOrDefault();
            contest.Closed = 1;
            _uow.ContestProes.Save();

            var contestSubmissions = _uow.PhotoProContests.Where(x => x.IdProContest == id)
                .OrderByDescending(x => x.Rating).Take(10).ToList();


            for (int i = 0; i < contestSubmissions.Count(); i++)
            {
                var userId = contestSubmissions[i].IdUser;
                var user = _uow.Users.Where(x => x.IdUser == userId).SingleOrDefault();
                switch (i)
                {
                    case 0:
                    {
                        user.Points = user.Points + 1000;
                        _uow.WinnerProes.Add(new WinnerPro()
                        {
                            IdProContest = id,
                            IdWinnerUser = userId,
                            PositionPlaced = 1
                        });
                        _uow.WinnerProes.Save();
                        break;
                    }
                    case 1:
                    {
                        user.Points = user.Points + 750;
                        break;
                    }
                    case 2:
                    {
                        user.Points = user.Points + 500;
                        break;
                    }

                    default:
                    {
                        user.Points = user.Points + 100;
                        break;
                    }
                }

                _uow.Users.Save();
            }
        }
    }
}
