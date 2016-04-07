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
    public class AppUnitBLL
    {
        private readonly AppUnitDAL dal = new AppUnitDAL();

        public Grid<AppUnit> GetUnitByPage(PageAppUnit pau)
        {
            Grid<AppUnit> g = new Grid<AppUnit>();

            g.total = dal.GetCount();
            g.rows = dal.GetListByPage(pau);
            return g;
        }

        public AppUnit GetOneUnit(string id)
        {
            return dal.GetOneUnit(id);
        }

        public void AddUnit(AppUnit au)
        {
            dal.AddUnit(au);
        }

        public void UpdateUnit(AppUnit au)
        {
            dal.UpdateUnit(au);
        }

        public void DeleteUnit(string unitid)
        {
            dal.DeleteUnit(unitid);
        }
    }
}
