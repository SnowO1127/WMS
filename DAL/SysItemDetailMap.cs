using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SysItemDetailMap : EntityTypeConfiguration<SysItemDetail>
    {

        public SysItemDetailMap()
        {
            ToTable("Sys_ItemDetail");
            HasKey(t => t.ID);

            Property(t => t.Name).HasMaxLength(20);
            Property(t => t.Value).HasMaxLength(20);
            Property(t => t.Description).HasMaxLength(300);

            Property(t => t.CUserID).HasMaxLength(128);
            Property(t => t.CUserName).HasMaxLength(20);
            Property(t => t.DUserID).HasMaxLength(128);
            Property(t => t.DUserName).HasMaxLength(20);
            Property(t => t.UUserID).HasMaxLength(128);
            Property(t => t.UUserName).HasMaxLength(20);
        }
    }
}
