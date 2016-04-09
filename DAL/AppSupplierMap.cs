using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AppSupplierMap : EntityTypeConfiguration<AppSupplier>
    {
        public AppSupplierMap()
        {
            ToTable("App_Supplier");
            HasKey(t => t.ID);

            Property(t => t.Code).HasMaxLength(10);
            Property(t => t.Name).HasMaxLength(30);
            Property(t => t.LinkMan).HasMaxLength(20);
            Property(t => t.Tel).HasMaxLength(20);
            Property(t => t.Fax).HasMaxLength(20);
            Property(t => t.Phone).HasMaxLength(20);
            Property(t => t.PostCode).HasMaxLength(20);
            Property(t => t.Longitude).HasMaxLength(20);
            Property(t => t.Latitude).HasMaxLength(20);
            Property(t => t.Address).HasMaxLength(60);
            Property(t => t.Description).HasMaxLength(300);

            Property(t => t.CUserID).HasMaxLength(128);
            Property(t => t.CUserName).HasMaxLength(20);
            Property(t => t.UUserID).HasMaxLength(128);
            Property(t => t.UUserName).HasMaxLength(20);
        }
    }
}
