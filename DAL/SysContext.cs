using Model;
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
        public DbSet<SysButton> SysButtons { get; set; }
        public DbSet<SysUser> SysUsers { get; set; }
        public DbSet<SysOganize> SysOganizes { get; set; }
        public DbSet<SysItem> SysItems { get; set; }
        public DbSet<SysItemDetail> SysItemDetails { get; set; }
        public DbSet<AppWareHouse> AppWareHouses { get; set; }
        public DbSet<AppClient> AppClients { get; set; }
        public DbSet<AppSupplier> AppSuppliers { get; set; }
        public DbSet<AppMaterialCategory> AppMaterialCategorys { get; set; }
        public DbSet<AppUnit> AppUnits { get; set; }
        public DbSet<AppUnitConversion> AppUnitConversions { get; set; }
        public DbSet<AppMaterial> AppMaterials { get; set; }

        public SysContext(string connection)
            : base("name=" + connection)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SysMenuMap());
            modelBuilder.Configurations.Add(new SysUserMap());
            modelBuilder.Configurations.Add(new SysRoleMap());
            modelBuilder.Configurations.Add(new SysButtonMap());
            modelBuilder.Configurations.Add(new SysOganizeMap());
            modelBuilder.Configurations.Add(new SysItemMap());
            modelBuilder.Configurations.Add(new SysItemDetailMap());
            modelBuilder.Configurations.Add(new AppWareHouseMap());
            modelBuilder.Configurations.Add(new AppClientMap());
            modelBuilder.Configurations.Add(new AppSupplierMap());
            modelBuilder.Configurations.Add(new AppMaterialCategoryMap());
            modelBuilder.Configurations.Add(new AppUnitMap());
            modelBuilder.Configurations.Add(new AppUnitConversionMap());
            modelBuilder.Configurations.Add(new AppMaterialMap());
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
