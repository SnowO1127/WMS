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
            HasMany(t => t.SysOganizes).WithOptional(t => t.PSysOganize).HasForeignKey(t => t.ParentID);
        }
    }
}
