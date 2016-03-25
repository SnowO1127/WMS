using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SysUserMap : EntityTypeConfiguration<SysUser>
    {
        public SysUserMap()
        {
            ToTable("Sys_User");
            HasKey(t => t.ID);
            HasMany(t => t.Roles).WithMany(t => t.Users).Map(m =>
         {
             m.ToTable("Sys_UserRole");
             m.MapLeftKey("UserID");
             m.MapRightKey("RoleID");
         });
        }
    }
}
