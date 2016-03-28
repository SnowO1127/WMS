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

            HasMany(t => t.SysItems).WithOptional(t => t.PSysItem).HasForeignKey(t => t.ParentID);

            HasMany(x => x.SysItemDetails).WithRequired(x => x.SysItem).HasForeignKey(x => x.ItemID);
        }
    }
}
