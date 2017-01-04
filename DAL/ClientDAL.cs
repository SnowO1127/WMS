using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClientDAL
    {
        //public List<AppClient> GetList()
        //{
        //    List<AppClient> list = new List<AppClient>();
        //    using (var ctx = new Context(Globe.ConnectionString))
        //    {
        //        list = ctx.AppClients.ToList();
        //    }
        //    return list;
        //}

        //public int GetCount()
        //{
        //    int count = 0;
        //    using (var ctx = new Context(Globe.ConnectionString))
        //    {
        //        count = ctx.AppClients.Count();
        //    }
        //    return count;
        //}

        //public List<AppClient> GetListByPage(PageAppClient pac)
        //{
        //    List<AppClient> list = new List<AppClient>();
        //    using (var ctx = new Context(Globe.ConnectionString))
        //    {
        //        list = ctx.AppClients.Where(x => x.DeleteMark.Equals(false)).ToList();

        //    }
        //    list = pac.Order == "desc" ? list.OrderByDescending(p => Utils.GetPropertyValue(p, pac.Sort)).Skip(pac.Rows * (pac.Page - 1)).Take(pac.Rows).ToList() : list.OrderBy(p => Utils.GetPropertyValue(p, pac.Sort)).Skip(pac.Rows * (pac.Page - 1)).Take(pac.Rows).ToList();

        //    return list;
        //}

        //public void AddClient(AppClient ac)
        //{
        //    using (var ctx = new Context(Globe.ConnectionString))
        //    {
        //        ctx.AppClients.Add(ac);
        //        ctx.SaveChanges();
        //    }
        //}

        //public void UpdateClient(AppClient ac)
        //{
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        AppClient nac = new AppClient();
        //        nac = ctx.AppClients.Find(ac.ID);

        //        IEnumerable<string> ie = new List<string> { "ID", "CDate", "CUserName", "CUserID", "DDate", "DUserID", "DUserName", "DeleteMark" };

        //        Utils.Copy(nac, ac, ie);

        //        ctx.SaveChanges();
        //    }
        //}

        //public void DeleteClient(string clientid)
        //{
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        AppClient ac = new AppClient();
        //        ac = ctx.AppClients.Find(clientid);

        //        ac.DeleteMark = true;

        //        ctx.SaveChanges();
        //    }
        //}

        //public AppClient GetOneClient(string clientid)
        //{
        //    AppClient ac = new AppClient();
        //    using (Context ctx = new Context(Globe.ConnectionString))
        //    {
        //        ac = ctx.AppClients.Find(clientid);
        //    }
        //    return ac;
        //}
    }
}
