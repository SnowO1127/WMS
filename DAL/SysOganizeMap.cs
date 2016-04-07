using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SysOganizeMap : EntityTypeConfiguration<SysOganize>
    {
        public SysOganizeMap()
        {
            ToTable("Sys_Oganize");
            HasKey(t => t.ID);

            Property(t => t.Name).HasMaxLength(30);
            Property(t => t.Category).HasMaxLength(20);
            Property(t => t.Code).HasMaxLength(20);
            Property(t => t.ManagerID).HasMaxLength(128);
            Property(t => t.ManagerName).HasMaxLength(20);
            Property(t => t.AssistantManagerID).HasMaxLength(128);
            Property(t => t.AssistantManagerName).HasMaxLength(20);
            Property(t => t.Tel).HasMaxLength(20);
            Property(t => t.Fax).HasMaxLength(20);
            Property(t => t.WebUrl).HasMaxLength(30);
            Property(t => t.PostCode).HasMaxLength(20);
            Property(t => t.Address).HasMaxLength(50);
            Property(t => t.Description).HasMaxLength(300);

            Property(t => t.CUserID).HasMaxLength(128);
            Property(t => t.CUserName).HasMaxLength(20);
            Property(t => t.UUserID).HasMaxLength(128);
            Property(t => t.UUserName).HasMaxLength(20);

            HasMany(t => t.SysOganizes).WithOptional(t => t.PSysOganize).HasForeignKey(t => t.ParentID);
        }
    }
}
