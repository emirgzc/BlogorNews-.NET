using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Abstract
{
    public interface ISliderService
    {
        List<Slider> GetList();
        void SliderAdd(Slider slider);
        Slider GetByID(int id);
        void SliderDelete(Slider slider);
        void SliderUpdate(Slider slider);
    }
}
