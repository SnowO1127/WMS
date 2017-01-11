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
    public class SysOganizeBLL
    {
        private readonly ISysOganizeDAL sysOganizeDal = DataAccess.CreateOganize();
        public List<SysOganize> GetList()
        {
            return sysOganizeDal.GetList();
        }

        //public void AddOganize(SysOganize so)
        //{
        //    dal.AddOganize(so);
        //}

        //public void UpdateOganize(SysOganize so)
        //{
        //    dal.UpdateOganize(so);
        //}

        //public SysOganize GetOneOganize(string id)
        //{
        //    return dal.GetOneOganize(id);
        //}

        public List<Tree> GetOganizeTree()
        {
            List<Tree> tlist = new List<Tree>();
            List<SysOganize> solist = GetList();
            if (solist != null && solist.Count > 0)
            {
                foreach (SysOganize so in solist)
                {
                    Tree t = new Tree() { id = so.ID, text = so.Name, pid = so.ParentID };
                    tlist.Add(t);
                }
            }
            return tlist;
        }

        public Grid<SysOganize> GetListByPage(int pageIndex, int pageSize, string sortName, string sortOrder, string parentID)
        {
            Grid<SysOganize> g = new Grid<SysOganize>();

            string rwhere = string.Empty;
            string twhere = string.Empty;

            if (!string.IsNullOrEmpty(parentID))
            {
                rwhere = "ParentID = '" + parentID + "' order by " + sortName + " " + sortOrder + "";
                twhere = "ParentID = '" + parentID + "'";
            }
            else
            {
                rwhere = "ParentID is null order by " + sortName + " " + sortOrder + "";
                twhere = "ParentID is null ";
            }

            g.total = sysOganizeDal.GetCount(twhere);
            g.rows = sysOganizeDal.GetList(pageIndex, pageSize, rwhere);

            return g;
        }

        public List<Tree> GetHeadTree()
        {
            List<Tree> tlist = new List<Tree>();

            Tree headtree = new Tree();
            headtree.id = Guid.NewGuid().ToString();
            headtree.text = "全部";

            tlist.Add(headtree);

            List<SysOganize> solist = GetList();
            if (solist != null && solist.Count > 0)
            {
                foreach (SysOganize so in solist)
                {
                    Tree t = new Tree() { id = so.ID, text = so.Name, pid = string.IsNullOrEmpty(so.ParentID) ? headtree.id : so.ParentID };
                    tlist.Add(t);
                }
            }
            return tlist;
        }

        //public void DeleteOganize(string oganizeid)
        //{
        //    dal.DeleteOganize(oganizeid);
        //}
    }
}
