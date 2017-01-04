using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class WareHouseDAL
    {
        //public List<AppWareHouse> GetList()
        //{
        //    List<AppWareHouse> list = new List<AppWareHouse>();
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        list = ctx.AppWareHouses.Where(x => x.DeleteMark.Equals(false)).OrderBy(x => x.OrderID).ToList();
        //    }
        //    return list;
        //}

        //public List<AppWareHouse> GetListByPage(PageAppWareHouse pawh)
        //{
        //    List<AppWareHouse> list = new List<AppWareHouse>();
        //    using (var ctx = new Context(Globe.ConnectionString))
        //    {
        //        var query = ctx.AppWareHouses.Where(x => x.DeleteMark.Equals(false));

        //        if (!string.IsNullOrEmpty(pawh.ID))
        //        {
        //            query = query.Where(x => x.ParentID.Equals(pawh.ID));
        //        }
        //        else
        //        {
        //            query = query.Where(x => x.ParentID.Equals(null));
        //        }

        //        if (!string.IsNullOrEmpty(pawh.Name))
        //        {
        //            query = query.Where(x => x.Name.Contains(pawh.Name));
        //        }
        //        list = query.OrderBy(x => x.OrderID).ToList();

        //        list = pawh.Order == "desc" ? list.OrderByDescending(p => Utils.GetPropertyValue(p, pawh.Sort)).Skip(pawh.Rows * (pawh.Page - 1)).Take(pawh.Rows).ToList() : list.OrderBy(p => Utils.GetPropertyValue(p, pawh.Sort)).Skip(pawh.Rows * (pawh.Page - 1)).Take(pawh.Rows).ToList();
        //    }
        //    return list;
        //}

        //public void AddWareHouse(AppWareHouse awh)
        //{
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        if (!string.IsNullOrEmpty(awh.ParentID))
        //        {
        //            awh.PAppWareHouse = ctx.AppWareHouses.Find(awh.ParentID);
        //        }
        //        else
        //        {
        //            awh.ParentID = null;
        //        }

        //        ctx.AppWareHouses.Add(awh);
        //        ctx.SaveChanges();
        //    }
        //}

        //public void UpdateWareHouse(AppWareHouse awh)
        //{
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        AppWareHouse nawh = new AppWareHouse();
        //        nawh = ctx.AppWareHouses.Find(awh.ID);

        //        IEnumerable<string> ie = new List<string> { "ID", "CDate", "CUserName", "CUserID", "DDate", "DUserID", "DUserName", "DeleteMark" };

        //        Utils.Copy(nawh, awh, ie);

        //        if (!string.IsNullOrEmpty(nawh.ParentID))
        //        {
        //            nawh.PAppWareHouse = ctx.AppWareHouses.Find(nawh.ParentID);
        //        }
        //        else
        //        {
        //            nawh.ParentID = null;
        //        }

        //        ctx.SaveChanges();
        //    }
        //}

        //public AppWareHouse GetOneWareHouse(string warehouseid)
        //{
        //    AppWareHouse awh = new AppWareHouse();
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        awh = ctx.AppWareHouses.Find(warehouseid);
        //    }

        //    return awh;
        //}

        //public void DeleteWareHouse(string warehouseid)
        //{
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        AppWareHouse awh = new AppWareHouse();
        //        awh = ctx.AppWareHouses.Find(warehouseid);

        //        awh.DeleteMark = true;

        //        ctx.SaveChanges();
        //    }
        //}
    }
}
