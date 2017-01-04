using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class ItemDAL
    {
        public List<SysItem> GetList()
        {
            List<SysItem> list = new List<SysItem>();
            using (Context ctx = new Context(Globe.ConnectionString))
            {
                list = ctx.SysItems.Where(x=>x.DeleteMark.Equals(false)).OrderBy(x => x.OrderID).ToList();
            }
            return list;
        }

        public List<SysItem> GetIsTreeList()
        {
            List<SysItem> list = new List<SysItem>();
            using (Context ctx = new Context(Globe.ConnectionString))
            {
                list = ctx.SysItems.Where(x => x.IsTree.Equals(true)).OrderBy(x => x.OrderID).ToList();
            }
            return list;
        }

        public void AddItem(SysItem si)
        {
            using (Context ctx = new Context(Globe.ConnectionString))
            {
                if (!string.IsNullOrEmpty(si.ParentID))
                {
                    si.PSysItem = ctx.SysItems.Find(si.ParentID);
                }
                else
                {
                    si.ParentID = null;
                }

                ctx.SysItems.Add(si);
                ctx.SaveChanges();
            }
        }

        public void UpdateItem(SysItem si)
        {
            using (Context ctx = new Context(Globe.ConnectionString))
            {
                SysItem nsi = new SysItem();
                nsi = ctx.SysItems.Find(si.ID);

                IEnumerable<string> ie = new List<string> { "ID", "CDate", "CUserName", "CUserID", "UDate", "UUserID", "UUserName", "DDate", "DUserID", "DUserName", "DeleteMark" };

                Utils.Copy(nsi, si, ie);

                nsi.UDate = DateTime.Now;

                if (!string.IsNullOrEmpty(nsi.ParentID))
                {
                    nsi.PSysItem = ctx.SysItems.Find(nsi.ParentID);
                }
                else
                {
                    nsi.ParentID = null;
                }

                ctx.SaveChanges();
            }
        }

        public SysItem GetOneItem(string id)
        {
            SysItem sm = new SysItem();
            using (Context ctx = new Context(Globe.ConnectionString))
            {
                sm = ctx.SysItems.Find(id);
            }

            return sm;
        }

        public SysItem GetOneItemByCode(string code)
        {
            SysItem sm = new SysItem();
            using (Context ctx = new Context(Globe.ConnectionString))
            {
                sm = ctx.SysItems.Include(x => x.SysItemDetails).Where(x => x.Code.Equals(code)).FirstOrDefault();
            }

            return sm;
        }

        public void DeleteItem(string itemid)
        {
            using (Context ctx = new Context(Globe.ConnectionString))
            {
                SysItem si = new SysItem();
                si = ctx.SysItems.Find(itemid);

                si.DeleteMark = true;

                ctx.SaveChanges();
            }
        }
    }
}
