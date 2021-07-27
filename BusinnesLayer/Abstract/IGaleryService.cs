using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGaleryService
    {
        List<Galery> GetList();
        void GaleryAdd(Galery galery);
        Galery GetByID(int id);
        void GaleryDelete(Galery galery);
        void GaleryUpdate(Galery galery);
    }
}
