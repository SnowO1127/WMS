using DAL;
using Model;
using PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AppMaterialCategoryBLL
    {
        private readonly AppMaterialCategoryDAL dal = new AppMaterialCategoryDAL();

        public Grid<AppMaterialCategory> GetMaterialCategoryByPage(PageAppMaterialCategory pamc)
        {
            Grid<AppMaterialCategory> g = new Grid<AppMaterialCategory>();

            g.total = dal.GetCount();
            g.rows = dal.GetListByPage(pamc);
            return g;
        }

        public AppMaterialCategory GetOneMaterialCategory(string id)
        {
            return dal.GetOneMaterialCategory(id);
        }

        public void AddMaterialCategory(AppMaterialCategory amc)
        {
            dal.AddMaterialCategory(amc);
        }

        public void UpdateMaterialCategory(AppMaterialCategory amc)
        {
            dal.UpdateMaterialCategory(amc);
        }

        public void DeleteMaterialCategory(string materialcategoryid)
        {
            dal.DeleteMaterialCategory(materialcategoryid);
        }
    }
}
