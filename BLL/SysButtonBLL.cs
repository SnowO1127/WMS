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
    public class SysButtonBLL
    {
        private readonly SysButtonDAL dal = new SysButtonDAL();
        public List<SysButton> GetListByPage(PageSysButton psb)
        {
            return dal.GetListByPage(psb);
        }

        public void AddButton(SysButton sb)
        {
            dal.AddButton(sb);
        }

        public void UpdateButton(SysButton sb)
        {
            dal.UpdateButton(sb);
        }

        public SysButton GetOneButton(string id)
        {
            return dal.GetOneButton(id);
        }

        public void DeleteButton(string id)
        {
            dal.DeleteButton(id);
        }
    }
}
