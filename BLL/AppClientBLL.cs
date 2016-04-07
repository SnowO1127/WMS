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
    public class AppClientBLL
    {
        private readonly AppClientDAL dal = new AppClientDAL();

        public Grid<AppClient> GetClientByPage(PageAppClient pac)
        {
            Grid<AppClient> g = new Grid<AppClient>();

            g.total = dal.GetCount();
            g.rows = dal.GetListByPage(pac);
            return g;
        }

        public AppClient GetOneClient(string id)
        {
            return dal.GetOneClient(id);
        }

        public void AddClient(AppClient ac)
        {
            dal.AddClient(ac);
        }

        public void UpdateClient(AppClient ac)
        {
            dal.UpdateClient(ac);
        }

        public void DeleteClient(string clientid)
        {
            dal.DeleteClient(clientid);
        }
    }
}
