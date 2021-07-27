using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();
        void WriterAdd(Writer about);
        Writer GetByID(int id);
        void WriterDelete(Writer about);
        void WriterUpdate(Writer about);
    }
}
