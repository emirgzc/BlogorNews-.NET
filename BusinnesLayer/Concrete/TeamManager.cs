using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TeamManager : ITeamService
    {
        ITeamDal _teamDal;
        public TeamManager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }
        public Team GetByID(int id)
        {
            return _teamDal.Get(x => x.Id == id);
        }

        public List<Team> GetList()
        {
            return _teamDal.List();
        }

        public List<Team> GetListTrue()
        {
            return _teamDal.List(z => z.Status == true);
        }

        public void TeamAdd(Team contact)
        {
            _teamDal.Insert(contact);
        }

        public void TeamDelete(Team contact)
        {
            _teamDal.Update(contact);
        }

        public void TeamUpdate(Team contact)
        {
            _teamDal.Update(contact);
        }
    }
}
