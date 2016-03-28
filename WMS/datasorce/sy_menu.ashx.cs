﻿using BLL;
using Common;
using Model;
using PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS.datasorce
{
    /// <summary>
    /// sy_menu 的摘要说明
    /// </summary>
    public class sy_menu : IHttpHandler
    {
        private readonly SysMenuBLL bll = new SysMenuBLL();
        private JsonResult jr;
        private SysMenu sm;
        private PageSysMenu psm;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;
            
            switch (request["action"])
            {
                case "getmenutree":
                    try
                    {
                        context.Response.Write(utils.SerializeObject(bll.GetMenuTree()));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "getmenu":
                    try
                    {
                        context.Response.Write(utils.SerializeObject(bll.GetList()));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    break;
                case "getmenubypage":
                    try
                    {
                        psm = utils.AutoWiredClass<PageSysMenu>(request, psm = new PageSysMenu());
                        context.Response.Write(utils.SerializeObject(bll.GetListByPage(psm)));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    break;
                case "getismenu":
                    try
                    {
                        context.Response.Write(utils.SerializeObject(bll.GetIsMenuTree()));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "addmenu":
                    jr = new JsonResult();
                    try
                    {
                        sm = utils.AutoWiredClass<SysMenu>(request, sm = new SysMenu());

                        sm.ID = Guid.NewGuid().ToString();
                        sm.CDate = DateTime.Now;


                        bll.AddMenu(sm);

                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(utils.SerializeObject(jr));
                    break;
                case "updatemenu":
                    jr = new JsonResult();
                    try
                    {
                        sm = utils.AutoWiredClass<SysMenu>(request, sm = new SysMenu());

                        bll.UpdateMenu(sm);
                        jr.Success = true;
                        jr.Msg = "保存成功！";
                    }
                    catch (Exception ex)
                    {
                        jr.Msg = ex.ToString();
                    }

                    context.Response.Write(utils.SerializeObject(jr));
                    break;
                case "getonemenu":
                    try
                    {
                        string id = request["id"];

                        sm = bll.GetOneMenu(id);

                        context.Response.Write(utils.SerializeObject(sm));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}