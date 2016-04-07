using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SysItemMap : EntityTypeConfiguration<SysItem>
    {
        public SysItemMap()
        {
            ToTable("Sys_Item");
            HasKey(t => t.ID);

            Property(t => t.Code).HasMaxLength(20);
            Property(t => t.Name).HasMaxLength(30);
            Property(t => t.Category).HasMaxLength(30);
            Property(t => t.Description).HasMaxLength(300);

            Property(t => t.CUserID).HasMaxLength(128);
            Property(t => t.CUserName).HasMaxLength(20);
            Property(t => t.UUserID).HasMaxLength(128);
            Property(t => t.UUserName).HasMaxLength(20);

            HasMany(t => t.SysItems).WithOptional(t => t.PSysItem).HasForeignKey(t => t.ParentID);
            HasMany(x => x.SysItemDetails).WithRequired(x => x.SysItem).HasForeignKey(x => x.ItemID);
        }
    }
}
