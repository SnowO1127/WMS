﻿using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SysContext : DbContext
    {
        public DbSet<SysMenu> SysMenus { get; set; }
        public DbSet<SysRole> SysRoles { get; set; }
        public DbSet<SysUser> SysUsers { get; set; }

        public SysContext(string connection)
            : base("name=" + connection)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SysMenuMap());
            modelBuilder.Configurations.Add(new SysUserMap());
            modelBuilder.Configurations.Add(new SysRoleMap());
            base.OnModelCreating(modelBuilder);
        }

        public class MigrationsContextFactory : IDbContextFactory<SysContext>
        {
            public SysContext Create()
            {
                return new SysContext("WmsContext");
            }
        }
    }
}