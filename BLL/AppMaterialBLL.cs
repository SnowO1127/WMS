﻿using DAL;
using Model;
using PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AppMaterialBLL
    {
        private readonly AppMaterialDAL dal = new AppMaterialDAL();

        public Grid<AppMaterial> GetMaterialByPage(PageAppMaterial pamc)
        {
            Grid<AppMaterial> g = new Grid<AppMaterial>();

            g.total = dal.GetCount();
            g.rows = dal.GetListByPage(pamc);
            return g;
        }

        public AppMaterial GetOneMaterial(string id)
        {
            return dal.GetOneMaterial(id);
        }

        public void AddMaterial(AppMaterial amc)
        {
            dal.AddMaterial(amc);
        }

        public void UpdateMaterial(AppMaterial amc)
        {
            dal.UpdateMaterial(amc);
        }

        public void DeleteMaterial(string Materialid)
        {
            dal.DeleteMaterial(Materialid);
        }
    }
}
