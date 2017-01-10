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
    public class SysItemDetailBLL
    {
        private readonly ISysItemDetailDAL sysItemDetailDal = DataAccess.CreateItemDetail();

        public Grid<SysItemDetail> GetListByPage(int pageIndex, int pageSize, string sortName, string sortOrder, string itemid)
        {
            Grid<SysItemDetail> g = new Grid<SysItemDetail>();

            string twhere = "ItemID='" + itemid + "'";
            string rwhere = "ItemID='" + itemid + "' order by " + sortName + " " + sortOrder + "";

            g.total = sysItemDetailDal.GetCount(twhere);
            g.rows = sysItemDetailDal.GetList(pageIndex, pageSize, rwhere);

            return g;
        }

        public List<SysItemDetail> GetListByCode(string code)
        {
            string where = "Code='" + code + "'";
            return sysItemDetailDal.GetList(where);
        }

        public void Insert(SysItemDetail sysItemDetail)
        {
            sysItemDetailDal.Insert(sysItemDetail);
        }

        public SysItemDetail GetObjectByKey(string id)
        {
            string where = "ID='" + id + "'";
            return sysItemDetailDal.GetObjectByCondition(where);
        }

        public void Update(SysItemDetail sysItemDetail)
        {
            sysItemDetailDal.Update(sysItemDetail);
        }
    }
}
