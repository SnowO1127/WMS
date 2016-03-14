using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SysMenuMap : EntityTypeConfiguration<SysMenu>
    {
        public SysMenuMap()
        {
            ToTable("Sys_Menu");
            HasKey(t => t.ID);
            HasMany(t => t.SysMenus).WithOptional(t => t.PSysMenu).HasForeignKey(t => t.ParentID);
        }
    }
}
