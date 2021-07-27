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
    public class SettingManager : ISettingsService
    {
        ISettingsDal _settingsDal;
        public SettingManager(ISettingsDal settingsDal)
        {
            _settingsDal = settingsDal;
        }
        public Settings GetByID(int id)
        {
            return _settingsDal.Get(x => x.Id == id);
        }

        public List<Settings> GetList()
        {
            return _settingsDal.List();
        }

        public void SettingsAdd(Settings contact)
        {
            _settingsDal.Insert(contact);
        }

        public void SettingsDelete(Settings contact)
        {
            _settingsDal.Delete(contact);
        }

        public void SettingsUpdate(Settings contact)
        {
            _settingsDal.Update(contact);
        }
    }
}
