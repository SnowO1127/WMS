using Common;
using DalFactory;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SysButtonBLL
    {
        private readonly ISysButtonDAL sysButtonDal = DataAccess.CreatButton();
        public Grid<SysButton> GetListByPage(int pageIndex, int pageSize, string sortName, string sortOrder, string menuID)
        {
            Grid<SysButton> g = new Grid<SysButton>();

            string rwhere = "MenuID = '" + menuID + "' order by " + sortName + " " + sortOrder + "";
            string twhere = "MenuID = '" + menuID + "'";

            g.total = sysButtonDal.GetCount(twhere);
            g.rows = sysButtonDal.GetList(pageIndex, pageSize, rwhere);

            return g;
        }

        public void AddButton(SysButton sb)
        {

        }

        public void UpdateButton(SysButton sb)
        {

        }

        public SysButton GetOneButton(string id)
        {
            return null;
        }

        public void DeleteButton(string id)
        {

        }
    }
}
