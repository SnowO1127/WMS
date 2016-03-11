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
    public class SysUserDAL : DbContext
    {
        public DbSet<SysUser> SysUsers { get; set; }

        public SysUserDAL()
            : base("name=" + Globe.ConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SysUserMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
