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
    public class SysItemBLL
    {
        private readonly SysItemDAL dal = new SysItemDAL();

        public List<SysItem> GetIsTreeList()
        {
            return dal.GetIsTreeList();
        }

        public List<SysItem> GetList()
        {
            return dal.GetList();
        }

        public List<Tree> GetItemTree()
        {
            List<Tree> tlist = new List<Tree>();
            List<SysItem> list = GetList();
            foreach (SysItem si in list)
            {
                Tree t = new Tree();
                t.id = si.ID;
                t.text = si.Name;
                t.pid = si.ParentID;

                tlist.Add(t);
            }
            return tlist;
        }

        public void AddItem(SysItem si)
        {
            dal.AddItem(si);
        }

        public List<Tree> GetIsTree()
        {
            List<Tree> tlist = new List<Tree>();
            List<SysItem> list = GetIsTreeList();
            foreach (SysItem si in list)
            {
                Tree t = new Tree();
                t.id = si.ID;
                t.text = si.Name;

                tlist.Add(t);
            }
            return tlist;
        }

        public SysItem GetOneItem(string id)
        {
            return dal.GetOneItem(id);
        }

        public void UpdateItem(SysItem si)
        {
            dal.UpdateItem(si);
        }

        public SysItem GetOneItemByCode(string code)
        {
            return dal.GetOneItemByCode(code);
        }
    }
}
