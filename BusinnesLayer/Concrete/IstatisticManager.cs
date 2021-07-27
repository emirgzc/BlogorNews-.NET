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
    public class IstatisticManager : IIstatisticService
    {
        IIstatisticDal _ıstatisticDal;
        public IstatisticManager(IIstatisticDal ıstatisticDal)
        {
            _ıstatisticDal = ıstatisticDal;
        }
        public Istatistic GetByID(int id)
        {
            return _ıstatisticDal.Get(x => x.Id == id);
        }

        public List<Istatistic> GetList()
        {
            return _ıstatisticDal.List();
        }

        public void IstatisticAdd(Istatistic contact)
        {
            _ıstatisticDal.Insert(contact);
        }

        public void IstatisticDelete(Istatistic contact)
        {
            _ıstatisticDal.Delete(contact);
        }

        public void IstatisticUpdate(Istatistic contact)
        {
            _ıstatisticDal.Update(contact);
        }
    }
}
