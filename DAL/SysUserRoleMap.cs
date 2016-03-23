using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SysUserRoleMap : EntityTypeConfiguration<SysUserRole>
    {
        public SysUserRoleMap()
        {
            ToTable("SysUserRole");

            //配置组合主键
            HasKey(t => new { t.UserID, t.RoleID });

            Property(t => t.UserID).HasColumnOrder(0);
            Property(t => t.RoleID).HasColumnOrder(1);

            //这里是配置一对多关系
            HasRequired(t => t.User).WithMany(t => t.UserRoles).HasForeignKey(t => t.UserID);
            HasRequired(t => t.Role).WithMany(t => t.UserRoles).HasForeignKey(t => t.RoleID);
        }
    }
}
