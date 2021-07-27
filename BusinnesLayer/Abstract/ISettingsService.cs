using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISettingsService
    {
        List<Settings> GetList();
        void SettingsAdd(Settings settings);
        Settings GetByID(int id);
        void SettingsDelete(Settings settings);
        void SettingsUpdate(Settings settings);
    }
}
