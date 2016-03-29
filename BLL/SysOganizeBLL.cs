﻿using DAL;
using Model;
using PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SysOganizeBLL
    {
        private readonly SysOganizeDAL dal = new SysOganizeDAL();
        public List<SysOganize> GetList()
        {
            return dal.GetList();
        }

        public void AddOganize(SysOganize so)
        {
            dal.AddOganize(so);
        }

        public void UpdateOganize(SysOganize so)
        {
            dal.UpdateOganize(so);
        }

        public SysOganize GetOneOganize(string id)
        {
            return dal.GetOneOganize(id);
        }

        public List<Tree> GetOganizeTree()
        {
            List<Tree> tlist = new List<Tree>();
            List<SysOganize> solist = dal.GetList();
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

        public object GetListByPage(PageSysOganize pso)
        {
            return dal.GetListByPage(pso);
        }
    }
}