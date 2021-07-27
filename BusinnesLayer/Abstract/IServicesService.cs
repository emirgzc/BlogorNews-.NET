using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IServicesService
    {
        List<Service> GetList();
        List<Service> GetListByTrue();
        void ServiceAdd(Service service);
        Service GetByID(int id);
        void ServiceDelete(Service service);
        void ServiceUpdate(Service service);
    }
}
