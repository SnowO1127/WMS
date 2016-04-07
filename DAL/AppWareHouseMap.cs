using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AppWareHouseMap : EntityTypeConfiguration<AppWareHouse>
    {
        public AppWareHouseMap()
        {
            ToTable("App_WareHouse");
            HasKey(t => t.ID);

            Property(t => t.Name).HasMaxLength(30);
            Property(t => t.Code).HasMaxLength(10);
            Property(t => t.ManagerID).HasMaxLength(128);
            Property(t => t.ManagerName).HasMaxLength(20);
            Property(t => t.Description).HasMaxLength(300);

            Property(t => t.CUserID).HasMaxLength(128);
            Property(t => t.CUserName).HasMaxLength(20);
            Property(t => t.UUserID).HasMaxLength(128);
            Property(t => t.UUserName).HasMaxLength(20);

            HasMany(t => t.AppWareHouses).WithOptional(t => t.PAppWareHouse).HasForeignKey(t => t.ParentID);
        }
    }
}
