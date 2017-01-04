using Common;
using Model;
using PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class ItemDetailDAL
    {
        public List<SysItemDetail> GetList()
        {
            List<SysItemDetail> list = new List<SysItemDetail>();
            using (Context ctx = new Context(Globe.ConnectionString))
            {
                list = ctx.SysItemDetails.ToList();
            }
            return list;
        }

        public List<SysItemDetail> GetListByPage(PageSysItemDetail psid)
        {
            List<SysItemDetail> list = new List<SysItemDetail>();

            if (!string.IsNullOrEmpty(psid.ItemID))
            {
                using (var ctx = new Context(Globe.ConnectionString))
                {
                    list = ctx.SysItemDetails.Where(x => x.DeleteMark.Equals(false) && x.ItemID.Equals(psid.ItemID)).ToList();

                    list = psid.Order == "desc" ? list.OrderByDescending(p => Utils.GetPropertyValue(p, psid.Sort)).Skip(psid.Rows * (psid.Page - 1)).Take(psid.Rows).ToList() : list.OrderBy(p => Utils.GetPropertyValue(p, psid.Sort)).Skip(psid.Rows * (psid.Page - 1)).Take(psid.Rows).ToList();
                }
            }

            return list;
        }

        public void AddItemDetail(SysItemDetail sid)
        {
            using (Context ctx = new Context(Globe.ConnectionString))
            {
                sid.SysItem = ctx.SysItems.Find(sid.ItemID);

                ctx.SysItemDetails.Add(sid);
                ctx.SaveChanges();
            }
        }

        public void UpdateItemDetail(SysItemDetail sid)
        {
            using (Context ctx = new Context(Globe.ConnectionString))
            {
                SysItemDetail nsid = new SysItemDetail();
                nsid = ctx.SysItemDetails.Find(sid.ID);

                IEnumerable<string> ie = new List<string> { "ID", "CDate", "CUserName", "CUserID", "UDate", "UUserID", "UUserName", "DDate", "DUserID", "DUserName", "DeleteMark" };

                Utils.Copy(nsid, sid, ie);

                nsid.UDate = DateTime.Now;

                nsid.SysItem = ctx.SysItems.Find(sid.ItemID);

                ctx.SaveChanges();
            }
        }

        public SysItemDetail GetOneItemDetail(string id)
        {
            SysItemDetail sm = new SysItemDetail();
            using (Context ctx = new Context(Globe.ConnectionString))
            {
                sm = ctx.SysItemDetails.Find(id);
            }

            return sm;
        }

        public List<SysItemDetail> GetItemDetailsByCode(string code)
        {
            List<SysItemDetail> list = new List<SysItemDetail>();
            using (Context ctx = new Context(Globe.ConnectionString))
            {
                list = ctx.SysItemDetails.Include(x => x.SysItem).Where(x => x.SysItem.Code.Equals(code)).OrderBy(x => x.OrderID).ToList();
            }

            return list;
        }

        public void DeleteItemDetail(string itemdetailid)
        {
            using (Context ctx = new Context(Globe.ConnectionString))
            {
                SysItemDetail sid = new SysItemDetail();
                sid = ctx.SysItemDetails.Find(itemdetailid);

                sid.DeleteMark = true;
                ctx.SaveChanges();
            }
        }
    }
}
