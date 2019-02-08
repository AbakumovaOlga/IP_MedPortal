using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTransportCompany.Models;

namespace WebTransportCompany.Service.Interface
{
    public interface IMain
    {
        BaseModel GetElement(int id);
        
        List<BaseModel> GetList();

        void AddElement(BaseModel model);

        void DelElement(int id);

        void UpdateElement(BaseModel model);
    }
}
