using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Entities;

namespace TelefonRehberi.DataAccessLayer.EntityFramework
{
    public class DatabaseContext : DbContext // DbContext EntityFramework'ten geliyor.
    {
        //Entities' deki class'larımıza karşılık gelen ve veritabanında oluşacak tablolar/DBSetler
        public DbSet<Calisan> TblCalisan { get; set; } 

        public DbSet<Departman> TblDepartman { get; set; }

        public DbSet<Admin> TblAdmin { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new MyInitializer());
        }
    }
}
