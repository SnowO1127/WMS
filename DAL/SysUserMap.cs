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

            Property(t => t.LoginName).HasMaxLength(20);
            Property(t => t.PassWord).HasMaxLength(20);
            Property(t => t.RealName).HasMaxLength(20);
            Property(t => t.Code).HasMaxLength(10);
            Property(t => t.SpellQuery).HasMaxLength(20);
            Property(t => t.Sex).HasMaxLength(5);
            Property(t => t.PhoneNum).HasMaxLength(20);
            Property(t => t.Tel).HasMaxLength(20);
            Property(t => t.Post).HasMaxLength(20);
            Property(t => t.QQ).HasMaxLength(15);
            Property(t => t.Email).HasMaxLength(50);
            Property(t => t.Address).HasMaxLength(80);
            Property(t => t.Company).HasMaxLength(128);
            Property(t => t.ChildCompany).HasMaxLength(128);
            Property(t => t.Dept).HasMaxLength(128);
            Property(t => t.ChildDept).HasMaxLength(128);
            Property(t => t.ClassGroup).HasMaxLength(128);
            Property(t => t.Description).HasMaxLength(300);

            Property(t => t.CUserID).HasMaxLength(128);
            Property(t => t.CUserName).HasMaxLength(20);
            Property(t => t.DUserID).HasMaxLength(128);
            Property(t => t.DUserName).HasMaxLength(20);
            Property(t => t.UUserID).HasMaxLength(128);
            Property(t => t.UUserName).HasMaxLength(20);

            HasMany(t => t.Roles).WithMany(t => t.Users).Map(m =>
         {
             m.ToTable("Sys_UserRole");
             m.MapLeftKey("UserID");
             m.MapRightKey("RoleID");
         });

        }
    }
}
