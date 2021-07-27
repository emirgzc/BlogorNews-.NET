using BusinnesLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Concrete
{
    public class SubscribeManager:ISubscribeService
    {
        ISubscribeDal _subscribeDal;
        public SubscribeManager(ISubscribeDal subscribeDal)
        {
            _subscribeDal = subscribeDal;
        }

        public Subscribe GetByID(int id)
        {
            return _subscribeDal.Get(x => x.Id == id);
        }

        public List<Subscribe> GetList()
        {
            return _subscribeDal.List();
        }

        public void SubscribeAdd(Subscribe subscribe)
        {
            _subscribeDal.Insert(subscribe);
        }

        public void SubscribeDelete(Subscribe subscribe)
        {
            _subscribeDal.Delete(subscribe);
        }

        public void SubscribeUpdate(Subscribe subscribe)
        {
            _subscribeDal.Update(subscribe);
        }
    }
}
