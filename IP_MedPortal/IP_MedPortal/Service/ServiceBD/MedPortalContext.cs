using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebTransportCompany.Models;

namespace WebTransportCompany.Service.ServiceBD
{
    public class MedPortalContext: DbContext
    {
        public MedPortalContext() : base("MedPortalDB")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public static MedPortalContext Create()
        {
            return new MedPortalContext();
        }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Procedure> Procedures { get; set; }

        public virtual DbSet<Doctor> Doctors { get; set; }

        public virtual DbSet<Recall> Recalls { get; set; }

    }
}