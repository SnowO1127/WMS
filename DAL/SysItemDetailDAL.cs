using Common;
using Model;
using PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SysItemDetailDAL
    {
        public List<SysItemDetail> GetList()
        {
            List<SysItemDetail> list = new List<SysItemDetail>();
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                list = ctx.SysItemDetails.ToList();
            }
            return list;
        }

        public List<SysItemDetail> GetListByPage(PageSysItemDetail psid)
        {
            List<SysItemDetail> list = new List<SysItemDetail>();
            using (var ctx = new SysContext(Globe.ConnectionString))
            {
                var query = ctx.SysItemDetails.AsQueryable();

                if (!string.IsNullOrEmpty(psid.ItemID))
                {
                    query = query.Where(x => x.ItemID.Equals(psid.ItemID));
                }

                list = query.ToList();

                list = psid.Order == "desc" ? list.OrderByDescending(p => utils.GetPropertyValue(p, psid.Sort)).Skip(psid.Rows * (psid.Page - 1)).Take(psid.Rows).ToList() : list.OrderBy(p => utils.GetPropertyValue(p, psid.Sort)).Skip(psid.Rows * (psid.Page - 1)).Take(psid.Rows).ToList();
            }
            return list;
        }

        public void AddItemDetail(SysItemDetail sid)
        {
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                sid.SysItem = ctx.SysItems.Find(sid.ItemID);

                ctx.SysItemDetails.Add(sid);
                ctx.SaveChanges();
            }
        }

        public void UpdateItemDetail(SysItemDetail sid)
        {
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                SysItemDetail nsid = new SysItemDetail();
                nsid = ctx.SysItemDetails.Find(sid.ID);

                IEnumerable<string> ie = new List<string> { "ID", "CDate", "CUserName", "CUserID", "UDate", "UUserID", "UUserName", "DDate", "DUserID", "DUserName", "DeleteMark" };

                utils.Copy(nsid, sid, ie);

                nsid.UDate = DateTime.Now;

                nsid.SysItem = ctx.SysItems.Find(sid.ItemID);

                ctx.SaveChanges();
            }
        }

        public SysItemDetail GetOneItemDetail(string id)
        {
            SysItemDetail sm = new SysItemDetail();
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                sm = ctx.SysItemDetails.Find(id);
            }

            return sm;
        }
    }
}
