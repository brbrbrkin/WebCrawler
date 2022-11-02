using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webcrawler_2
{
    public class WcContext : DbContext
    {
      
        public void IniciarDB()
        {
            Debug.Write(Database.Connection.ConnectionString);
            this.Database.CreateIfNotExists();

        }

          public DbSet<Noticia> Noticias { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
        }
    }
}
