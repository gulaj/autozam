using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Autozam.Models
{
    public class AutozamContext : DbContext
    {
        public AutozamContext()
            : base("AutozamConnectionString")
        {
        }
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<Autozam.Models.AutozamContext>());

        public DbSet<Autozam.Models.Departament> Departaments { get; set; }

        public DbSet<Autozam.Models.Category> Categories { get; set; }

        public DbSet<Autozam.Models.Product> Products { get; set; }

        public DbSet<Autozam.Models.Image> Images { get; set; }
    }
}