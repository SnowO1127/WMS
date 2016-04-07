using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SysRoleMap : EntityTypeConfiguration<SysRole>
    {
        public SysRoleMap()
        {
            ToTable("Sys_Role");
            HasKey(t => t.ID);

            Property(t => t.Code).HasMaxLength(20);
            Property(t => t.Name).HasMaxLength(30);
            Property(t => t.Category).HasMaxLength(20);
            Property(t => t.Description).HasMaxLength(300);

            Property(t => t.CUserID).HasMaxLength(128);
            Property(t => t.CUserName).HasMaxLength(20);
            Property(t => t.UUserID).HasMaxLength(128);
            Property(t => t.UUserName).HasMaxLength(20);

            HasMany(t => t.Menus).WithMany(t => t.Roles).Map(m =>
            {
                m.ToTable("Sys_RoleMenu");
                m.MapLeftKey("RoleID");
                m.MapRightKey("MenuID");
            });

            HasMany(t => t.Buttons).WithMany(t => t.Roles).Map(m =>
            {
                m.ToTable("Sys_RoleButton");
                m.MapLeftKey("RoleID");
                m.MapRightKey("ButtonID");
            });
        }
    }
}
