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
    public class ContestBasicService: IContestBasicService
    {
        private readonly IUnitOfWork _uow;

        public ContestBasicService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public int AddContest(ContestBasicDTO newContestBasic)
        {
            var newContestBasicInfo = Mapper.Map<ContestBasicDTO, ContestBasic>(newContestBasic);
            _uow.ContestBasics.Add(newContestBasicInfo);
            _uow.ContestBasics.Save();
            return newContestBasicInfo.IdContestBasic;
        }

        public ContestBasicDTO GetContestBasic(int id)
        {
            var contestBasic = _uow.ContestBasics.Where(x => x.IdContestBasic == id).SingleOrDefault();
            return Mapper.Map<ContestBasic, ContestBasicDTO>(contestBasic);
        }

        public List<ContestBasicDTO> GetActiveContestsBasic()
        {
            var activeContestBasic = _uow.ContestBasics.Find(x => x.Closed == 0).ToList();
            return Mapper.Map<List<ContestBasic>, List<ContestBasicDTO>>(activeContestBasic);
        }

        public void EndContest(int id)
        {
            var contest = _uow.ContestBasics.Where(x => x.IdContestBasic == id).SingleOrDefault();
            contest.Closed = 1;
            _uow.ContestBasics.Save();

            var contestSubmissions = _uow.PhotoBasicContests.Where(x => x.IdBasicContest == id)
                .OrderByDescending(x => x.Rating).Take(10).ToList();

            for (int i = 0; i < contestSubmissions.Count(); i++)
            {
                var userId = contestSubmissions[i].IdUser;
                var user = _uow.Users.Where(x => x.IdUser == userId).SingleOrDefault();
                switch (i)
                {
                    case 0:
                    {
                        user.Points = user.Points + 200;
                        _uow.WinnerBasics.Add(new WinnerBasic()
                        {
                            IdBasicContest = id,
                            IdWinnerUser = userId,
                            PositionPlaced = 1
                        });
                        _uow.WinnerBasics.Save();
                        break;
                    }
                    case 1:
                    {
                        user.Points = user.Points + 150;
                        break;
                    }
                    case 2:
                    {
                        user.Points = user.Points + 100;
                        break;
                    }

                    default:
                    {
                        user.Points = user.Points + 25;
                        break;
                    }
                }

                _uow.Users.Save();
            }
        }

        public List<ContestBasicDTO> GetInactiveContestsBasic()
        {
            var inactiveContestBasic = _uow.ContestBasics.Find(x => x.Closed == 1).ToList();
            return Mapper.Map<List<ContestBasic>, List<ContestBasicDTO>>(inactiveContestBasic);
        }
    }
}
