using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITeamService
    {
        List<Team> GetList();
        List<Team> GetListTrue();
        void TeamAdd(Team team);
        Team GetByID(int id);
        void TeamDelete(Team team);
        void TeamUpdate(Team team);
    }
}
