using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WMS
{
    public class BasePage : System.Web.UI.Page
    {
        private readonly SysUserBLL bll = new SysUserBLL();
        public SysUser su
            ;
        public BasePage()
        {
            this.Load += new EventHandler(thisLoad);
        }

        void thisLoad(object sender, EventArgs e)
        {
            string url = UrlPathHelper.GetVirtualUrlPath();

            string lasturl = UrlPathHelper.GetVirtualUrlPathAnQuery();

            SessionHelper.SetSession(Globe.LastUrlSessionName, lasturl);

            su = bll.GetCurrentUser();

            if (su == null)
            {
                Response.Write("<script language='javascript'>window.location.href='/NoSession.aspx';</script>");
                Response.End();
            }
            else
            {
                if (!url.Equals("/Login.aspx") 
                 && !url.Equals("/Index.aspx") 
                 && !url.Equals("/NoSession.aspx") 
                 && !url.Equals("/NoPower.aspx"))
                {
                    List<SysMenu> smlist = bll.GetPessionMenus(su.ID);

                    List<string> urls = smlist.Select(x => x.MenuUrl).ToList();

                    if (!urls.Contains(url))
                    {
                        Response.Write("<script language='javascript'>window.location.href='/NoPower.aspx';</script>");
                        Response.End();
                    }
                }
            }
        }
    }
}

