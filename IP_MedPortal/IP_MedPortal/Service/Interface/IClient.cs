using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTransportCompany.Models;

namespace WebTransportCompany.Service.Interface
{
    public interface IClient: IMain
    {
        bool Authorization(Client client);
        bool Registrations(Client client);
    }
}
