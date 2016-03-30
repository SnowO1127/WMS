﻿using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SysButtonMap : EntityTypeConfiguration<SysButton>
    {
        public SysButtonMap()
        {
            ToTable("Sys_Button");
            HasKey(t => t.ID);

            Property(t => t.HtmlID).HasMaxLength(20);
            Property(t => t.Name).HasMaxLength(30);
            Property(t => t.Description).HasMaxLength(200);

            Property(t => t.CUserID).HasMaxLength(128);
            Property(t => t.CUserName).HasMaxLength(20);
            Property(t => t.DUserID).HasMaxLength(128);
            Property(t => t.DUserName).HasMaxLength(20);
            Property(t => t.UUserID).HasMaxLength(128);
            Property(t => t.UUserName).HasMaxLength(20);
        }
    }
}
