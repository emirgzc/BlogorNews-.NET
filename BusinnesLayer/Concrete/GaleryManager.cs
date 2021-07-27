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
    public class GaleryManager : IGaleryService
    {
        IGaleryDal _galeryDal;

        public GaleryManager(IGaleryDal galeryDal)
        {
            _galeryDal = galeryDal;
        }

        public void GaleryAdd(Galery contact)
        {
            _galeryDal.Insert(contact);
        }

        public void GaleryDelete(Galery contact)
        {
            _galeryDal.Delete(contact);
        }

        public void GaleryUpdate(Galery contact)
        {
            _galeryDal.Update(contact);
        }

        public Galery GetByID(int id)
        {
            return _galeryDal.Get(x => x.Id == id);
        }

        public List<Galery> GetList()
        {
            return _galeryDal.List();
        }
    }
}
