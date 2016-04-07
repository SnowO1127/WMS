using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AppUnitConversionMap : EntityTypeConfiguration<AppUnitConversion>
    {
        public AppUnitConversionMap()
        {
            ToTable("App_UnitConversion");
            HasKey(t => t.ID);

            Property(t => t.Code).HasMaxLength(20);
            Property(t => t.MainUnitName).HasMaxLength(20);
            Property(t => t.AssistUnitName).HasMaxLength(20);
            Property(t => t.Description).HasMaxLength(300);

            Property(t => t.CUserID).HasMaxLength(128);
            Property(t => t.CUserName).HasMaxLength(20);
            Property(t => t.UUserID).HasMaxLength(128);
            Property(t => t.UUserName).HasMaxLength(20);
        }
    }
}
