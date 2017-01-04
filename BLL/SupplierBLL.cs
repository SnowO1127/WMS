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
    public class SupplierBLL
    {
        private readonly SupplierDAL dal = new SupplierDAL();

        public Grid<AppSupplier> GetSupplierByPage(PageAppSupplier pasu)
        {
            Grid<AppSupplier> g = new Grid<AppSupplier>();

            g.total = dal.GetCount();
            g.rows = dal.GetListByPage(pasu);
            return g;
        }

        public AppSupplier GetOneSupplier(string supplierid)
        {
            return dal.GetOneSupplier(supplierid);
        }

        public void AddSupplier(AppSupplier asu)
        {
            dal.AddSupplier(asu);
        }

        public void UpdateSupplier(AppSupplier asu)
        {
            dal.UpdateSupplier(asu);
        }

        public void DeleteSupplier(string supplierid)
        {
            dal.DeleteSupplier(supplierid);
        }
    }
}
