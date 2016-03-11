using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SysUserMap : EntityTypeConfiguration<SysUser>
    {
        public SysUserMap()
        {
            HasKey(t => t.UserID).Property(t => t.UserID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("UserID");
        }
    }
}
