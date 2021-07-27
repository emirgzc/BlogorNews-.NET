using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IIstatisticService
    {
        List<Istatistic> GetList();
        void IstatisticAdd(Istatistic ıstatistic);
        Istatistic GetByID(int id);
        void IstatisticDelete(Istatistic ıstatistic);
        void IstatisticUpdate(Istatistic ıstatistic);
    }
}
