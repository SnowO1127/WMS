using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PermissionBLL
    {
        //private readonly UserDAL sudal = new UserDAL();
        //private readonly RoleDAL srdal = new RoleDAL();
        //private readonly MenuDAL smdal = new MenuDAL();
        //private readonly ButtonDAL sbdal = new ButtonDAL();


        ///// <summary>
        ///// 得到菜单跟按钮树
        ///// </summary>
        ///// <returns></returns>
        //public List<Tree> GetPermissionTree()
        //{
        //    List<Tree> tlist = new List<Tree>();

        //    List<SysMenu> smlist = smdal.GetList();
        //    List<SysButton> sblist = sbdal.GetList();

        //    List<SysPermission> splist = new List<SysPermission>();
        //    SysPermission sp;
        //    foreach (SysMenu sm in smlist)
        //    {
        //        sp = new SysPermission();
        //        sp.ID = sm.ID;
        //        sp.ParentID = sm.ParentID;
        //        sp.Category = Globe.MenuButtonCategory.MenuCategory;
        //        sp.IconCls = sm.IconCls;
        //        sp.Name = sm.MenuName;
        //        splist.Add(sp);
        //    }

        //    foreach (SysButton sb in sblist)
        //    {
        //        sp = new SysPermission();
        //        sp.ID = sb.ID;
        //        sp.ParentID = sb.MenuID;
        //        sp.Category = Globe.MenuButtonCategory.ButtonCategory;
        //        sp.Name = sb.Name;
        //        splist.Add(sp);
        //    }

        //    if (splist != null && splist.Count > 0)
        //    {
        //        foreach (SysPermission sper in splist)
        //        {
        //            Tree t = new Tree() { id = sper.ID, text = sper.Name, pid = sper.ParentID, iconCls = sper.IconCls };
        //            Dictionary<String, Object> attributes = new Dictionary<String, Object>();
        //            attributes.Add("category", sper.Category);
        //            t.attributes = attributes;
        //            tlist.Add(t);
        //        }
        //    }

        //    return tlist;
        //}

        ///// <summary>
        ///// 添加用户操作权限
        ///// </summary>
        ///// <param name="userid"></param>
        ///// <param name="jsonstr"></param>
        //public void AddUserPermission(string userid, string jsonstr)
        //{
        //    List<SysPermission> splist = Utils.DeserializeJsonToList<SysPermission>(jsonstr);

        //    List<SysMenu> smlist = new List<SysMenu>();
        //    List<SysButton> sblist = new List<SysButton>();

        //    foreach (SysPermission sp in splist)
        //    {
        //        if (sp.Category.Equals(Globe.MenuButtonCategory.MenuCategory))
        //        {
        //            SysMenu sm = new SysMenu() { ID = sp.ID };
        //            smlist.Add(sm);
        //        }
        //        else if (sp.Category.Equals(Globe.MenuButtonCategory.ButtonCategory))
        //        {
        //            SysButton sb = new SysButton() { ID = sp.ID };
        //            sblist.Add(sb);
        //        }
        //    }

        //    sudal.AddUserPermission(userid, smlist, sblist);
        //}

        ///// <summary>
        ///// 添加角色操作权限
        ///// </summary>
        ///// <param name="userid"></param>
        ///// <param name="jsonstr"></param>
        //public void AddRolePermission(string roleid, string jsonstr)
        //{
        //    List<SysPermission> splist = Utils.DeserializeJsonToList<SysPermission>(jsonstr);

        //    List<SysMenu> smlist = new List<SysMenu>();
        //    List<SysButton> sblist = new List<SysButton>();

        //    foreach (SysPermission sp in splist)
        //    {
        //        if (sp.Category.Equals(Globe.MenuButtonCategory.MenuCategory))
        //        {
        //            SysMenu sm = new SysMenu() { ID = sp.ID };
        //            smlist.Add(sm);
        //        }
        //        else if (sp.Category.Equals(Globe.MenuButtonCategory.ButtonCategory))
        //        {
        //            SysButton sb = new SysButton() { ID = sp.ID };
        //            sblist.Add(sb);
        //        }
        //    }

        //    srdal.AddRolePermission(roleid, smlist, sblist);
        //}

        ///// <summary>
        ///// 根据用户得到所有的菜单及按钮权限
        ///// </summary>
        ///// <param name="userid"></param>
        ///// <returns></returns>
        //public List<Tree> GetUserPermissionTree(string userid)
        //{
        //    List<Tree> tlist = GetPermissionTree();

        //    SysUser su = sudal.GetOneUserWithMany(userid);

        //    List<string> menuids = new List<string>();
        //    List<string> buttonids = new List<string>();

        //    foreach (SysMenu sm in su.Menus)
        //    {
        //        menuids.Add(sm.ID);
        //    }

        //    foreach (SysButton sb in su.Buttons)
        //    {
        //        buttonids.Add(sb.ID);
        //    }

        //    foreach (var tree in tlist)
        //    {
        //        Dictionary<String, Object> attributes = (Dictionary<String, Object>)tree.attributes;
        //        if (attributes["category"].Equals(Globe.MenuButtonCategory.MenuCategory))
        //        {
        //            if (menuids.Contains(tree.id))
        //            {
        //                tree.ischecked = true;
        //            }
        //            else
        //            {
        //                tree.ischecked = false;
        //            }
        //        }
        //        else if (attributes["category"].Equals(Globe.MenuButtonCategory.ButtonCategory))
        //        {
        //            if (buttonids.Contains(tree.id))
        //            {
        //                tree.ischecked = true;
        //            }
        //            else
        //            {
        //                tree.ischecked = false;
        //            }
        //        }
        //    }
        //    List<Tree> ptlist = tlist.FindAll(x => string.IsNullOrEmpty(x.pid));

        //    SetParentUnChecked(tlist, ptlist);


        //    return tlist;
        //}

        ///// <summary>
        ///// 递归
        ///// </summary>
        ///// <param name="tlist"></param>
        ///// <param name="ptlist"></param>
        ///// <returns></returns>
        //public List<Tree> SetParentUnChecked(List<Tree> tlist, List<Tree> ptlist)
        //{
        //    foreach (var ptree in ptlist)
        //    {
        //        List<Tree> ctlist = tlist.FindAll(x => !string.IsNullOrEmpty(x.pid) && x.pid.Equals(ptree.id));
        //        if (ctlist.Count > 0)
        //        {
        //            ptree.ischecked = false;
        //            SetParentUnChecked(tlist, ctlist);
        //        }
        //    }

        //    return tlist;
        //}

        ///// <summary>
        ///// 根据用户获得菜单及按钮权限树
        ///// </summary>
        ///// <param name="roleid"></param>
        ///// <returns></returns>
        //public List<Tree> GetRolePermissionTree(string roleid)
        //{
        //    List<Tree> tlist = GetPermissionTree();

        //    SysRole sr = srdal.GetOneRoleWithMany(roleid);

        //    List<string> menuids = new List<string>();
        //    List<string> buttonids = new List<string>();

        //    foreach (SysMenu sm in sr.Menus)
        //    {
        //        menuids.Add(sm.ID);
        //    }

        //    foreach (SysButton sb in sr.Buttons)
        //    {
        //        buttonids.Add(sb.ID);
        //    }

        //    foreach (var tree in tlist)
        //    {
        //        Dictionary<String, Object> attributes = (Dictionary<String, Object>)tree.attributes;
        //        if (attributes["category"].Equals(Globe.MenuButtonCategory.MenuCategory))
        //        {
        //            if (menuids.Contains(tree.id))
        //            {
        //                tree.ischecked = true;
        //            }
        //            else
        //            {
        //                tree.ischecked = false;
        //            }
        //        }
        //        else if (attributes["category"].Equals(Globe.MenuButtonCategory.ButtonCategory))
        //        {
        //            if (buttonids.Contains(tree.id))
        //            {
        //                tree.ischecked = true;
        //            }
        //            else
        //            {
        //                tree.ischecked = false;
        //            }
        //        }
        //    }
        //    List<Tree> ptlist = tlist.FindAll(x => string.IsNullOrEmpty(x.pid));

        //    SetParentUnChecked(tlist, ptlist);


        //    return tlist;
        //}
    }
}
