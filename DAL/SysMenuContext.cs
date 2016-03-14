using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SysMenuContext : DbContext
    {
        public DbSet<SysMenu> SysMenus { get; set; }

        public SysMenuContext(string connection)
            : base("name=" + connection)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SysMenuMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
