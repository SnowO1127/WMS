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

            Property(t => t.MenuName).HasMaxLength(20);
            Property(t => t.Category).HasMaxLength(20);
            Property(t => t.IconCls).HasMaxLength(40);
            Property(t => t.MenuUrl).HasMaxLength(100);
            Property(t => t.Description).HasMaxLength(200);
            Property(t => t.CUserID).HasMaxLength(128);
            Property(t => t.CUserName).HasMaxLength(20);
            Property(t => t.UUserID).HasMaxLength(128);
            Property(t => t.UUserName).HasMaxLength(20);

            HasMany(t => t.SysMenus).WithOptional(t => t.PSysMenu).HasForeignKey(t => t.ParentID);

            HasMany(t => t.SysButtons).WithRequired(t => t.SysMenu).HasForeignKey(t => t.MenuID);
        }
    }
}
