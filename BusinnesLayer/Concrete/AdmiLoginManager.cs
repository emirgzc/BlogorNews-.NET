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
    public class AdmiLoginManager : IAdminLoginService
    {
        IAdminDal _adminDal;

        public AdmiLoginManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public Admin GetAdmin(string username, string password)
        {
            return _adminDal.Get(x => x.Username == username && x.Password == password);
        }
    }
}
