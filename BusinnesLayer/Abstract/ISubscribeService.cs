using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Abstract
{
    public interface ISubscribeService
    {
        List<Subscribe> GetList();
        void SubscribeAdd(Subscribe subscribe);
        Subscribe GetByID(int id);
        void SubscribeDelete(Subscribe subscribe);
        void SubscribeUpdate(Subscribe subscribe);
    }
}
