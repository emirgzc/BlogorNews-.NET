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
    public class ServicesManager : IServicesService
    {
        IServiceDal _servicesDal;
        public ServicesManager(IServiceDal servicesDal)
        {
            _servicesDal = servicesDal;
        }
        public Service GetByID(int id)
        {
            return _servicesDal.Get(x => x.Id == id);
        }

        public List<Service> GetList()
        {
            return _servicesDal.List();
        }

        public List<Service> GetListByTrue()
        {
            return _servicesDal.List(x => x.Status == true);
        }

        public void ServiceAdd(Service service)
        {
            _servicesDal.Insert(service);
        }

        public void ServiceDelete(Service service)
        {
            _servicesDal.Delete(service);
        }

        public void ServiceUpdate(Service service)
        {
            _servicesDal.Update(service);
        }
    }
}
