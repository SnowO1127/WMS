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
    public class ItemDetailBLL
    {
        private readonly ItemDetailDAL dal = new ItemDetailDAL();

        public List<SysItemDetail> GetListByPage(PageSysItemDetail psid)
        {
            return dal.GetListByPage(psid);
        }

        public void AddItemDetail(SysItemDetail sid)
        {
            dal.AddItemDetail(sid);
        }

        public SysItemDetail GetOneItemDetail(string id)
        {
            return dal.GetOneItemDetail(id);
        }

        public void UpdateItemDetail(SysItemDetail sid)
        {
            dal.UpdateItemDetail(sid);
        }

        public List<SysItemDetail> GetItemDetailsByCode(string code)
        {
            return dal.GetItemDetailsByCode(code);
        }

        public void DeleteItemDetail(string itemdetailid)
        {
            dal.DeleteItemDetail(itemdetailid);
        }
    }
}
