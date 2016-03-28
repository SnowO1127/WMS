using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SysItemDAL
    {
        public List<SysItem> GetList()
        {
            List<SysItem> list = new List<SysItem>();
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                list = ctx.SysItems.ToList();
            }
            return list;
        }

        public List<SysItem> GetIsTreeList()
        {
            List<SysItem> list = new List<SysItem>();
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                list = ctx.SysItems.Where(x => x.IsTree.Equals(true)).ToList();
            }
            return list;
        }

        public void AddItem(SysItem si)
        {
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
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
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                SysItem nsi = new SysItem();
                nsi = ctx.SysItems.Find(si.ID);

                IEnumerable<string> ie = new List<string> { "ID", "CDate", "CUserName", "CUserID", "UDate", "UUserID", "UUserName", "DDate", "DUserID", "DUserName", "DeleteMark" };

                utils.Copy(nsi, si, ie);

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
            using (SysContext ctx = new SysContext(Globe.ConnectionString))
            {
                sm = ctx.SysItems.Find(id);
            }

            return sm;
        }
    }
}
