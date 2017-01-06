using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class WareHouseBLL
    {
        //private readonly WareHouseDAL dal = new WareHouseDAL();

        //public object GetHeadTree()
        //{
        //    List<Tree> tlist = new List<Tree>();

        //    Tree headtree = new Tree();
        //    headtree.id = Guid.NewGuid().ToString();
        //    headtree.text = "全部";

        //    tlist.Add(headtree);

        //    List<AppWareHouse> awhlist = dal.GetList();
        //    if (awhlist != null && awhlist.Count > 0)
        //    {
        //        foreach (AppWareHouse awh in awhlist)
        //        {
        //            Tree t = new Tree() { id = awh.ID, text = awh.Name, pid = string.IsNullOrEmpty(awh.ParentID) ? headtree.id : awh.ParentID };
        //            tlist.Add(t);
        //        }
        //    }
        //    return tlist;
        //}

        //public List<AppWareHouse> GetListByPage(PageAppWareHouse pawh)
        //{
        //    return dal.GetListByPage(pawh);
        //}

        //public List<Tree> GetWareHouseTree()
        //{
        //    List<Tree> tlist = new List<Tree>();
        //    List<AppWareHouse> awhlist = dal.GetList();
        //    if (awhlist != null && awhlist.Count > 0)
        //    {
        //        foreach (AppWareHouse so in awhlist)
        //        {
        //            Tree t = new Tree() { id = so.ID, text = so.Name, pid = so.ParentID };
        //            tlist.Add(t);
        //        }
        //    }
        //    return tlist;
        //}

        //public void AddWareHouse(AppWareHouse awh)
        //{
        //    dal.AddWareHouse(awh);
        //}

        //public void UpdateWareHouse(AppWareHouse awh)
        //{
        //    dal.UpdateWareHouse(awh);
        //}

        //public AppWareHouse GetOneWareHouse(string warehouseid)
        //{
        //    return dal.GetOneWareHouse(warehouseid);
        //}

        //public void DeleteWareHouse(string warehouseid)
        //{
        //    dal.DeleteWareHouse(warehouseid);
        //}
    }
}
