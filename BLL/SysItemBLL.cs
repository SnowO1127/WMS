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
    public class SysItemBLL
    {
        private readonly ISysItemDAL sysItemDal = DataAccess.CreateItem();

        public List<SysItem> GetIsTreeList()
        {
            return null;
        }

        public List<SysItem> GetList()
        {
            return sysItemDal.GetList();
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

                Dictionary<String, Object> attributes = new Dictionary<String, Object>();
                attributes.Add("istree", si.IsTree);
                attributes.Add("allowedit", si.AllowEdit);
                attributes.Add("allowdelete", si.AllowDelete);

                t.attributes = attributes;

                tlist.Add(t);
            }
            return tlist;
        }

        public void Insert(SysItem si)
        {
            sysItemDal.Insert(si);
        }

        //public List<Tree> GetIsTree()
        //{
        //    List<Tree> tlist = new List<Tree>();
        //    List<SysItem> list = GetIsTreeList();
        //    foreach (SysItem si in list)
        //    {
        //        Tree t = new Tree();
        //        t.id = si.ID;
        //        t.text = si.Name;

        //        tlist.Add(t);
        //    }
        //    return tlist;
        //}

        public SysItem GetOneItemByID(string id)
        {
            string where = "ID='" + id + "'";
            return sysItemDal.GetObjectByCondition(where);
        }

        public void UpdateItem(SysItem si)
        {
            sysItemDal.Update(si);
        }

        public SysItem GetOneItemByCode(string code)
        {
            string where = "Code='" + code + "'";
            return sysItemDal.GetObjectByCondition(where);
        }
    }
}
