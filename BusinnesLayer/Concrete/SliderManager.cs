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
    public class SliderManager : ISliderService
    {
        ISliderDal _sliderDal;
        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public Slider GetByID(int id)
        {
            return _sliderDal.Get(x => x.Id == id);
        }

        public List<Slider> GetList()
        {
            return _sliderDal.List();
        }

        public void SliderAdd(Slider slider)
        {
            _sliderDal.Update(slider);
        }

        public void SliderDelete(Slider slider)
        {
            _sliderDal.Update(slider);
        }

        public void SliderUpdate(Slider slider)
        {
            _sliderDal.Update(slider);
        }
    }
}
