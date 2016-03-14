using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SysUserContext : DbContext
    {
        public DbSet<SysUser> SysUsers { get; set; }

        public SysUserContext(string connection)
            : base("name=" + connection)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SysUserMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
