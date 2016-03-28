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
        }
    }
}
