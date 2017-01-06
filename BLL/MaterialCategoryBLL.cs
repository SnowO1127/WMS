using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MaterialCategoryBLL
    {
        //private readonly MaterialCategoryDAL dal = new MaterialCategoryDAL();

        //public Grid<AppMaterialCategory> GetMaterialCategoryByPage(PageAppMaterialCategory pamc)
        //{
        //    Grid<AppMaterialCategory> g = new Grid<AppMaterialCategory>();

        //    g.total = dal.GetCount();
        //    g.rows = dal.GetListByPage(pamc);
        //    return g;
        //}

        //public AppMaterialCategory GetOneMaterialCategory(string id)
        //{
        //    return dal.GetOneMaterialCategory(id);
        //}

        //public void AddMaterialCategory(AppMaterialCategory amc)
        //{
        //    dal.AddMaterialCategory(amc);
        //}

        //public void UpdateMaterialCategory(AppMaterialCategory amc)
        //{
        //    dal.UpdateMaterialCategory(amc);
        //}

        //public void DeleteMaterialCategory(string materialcategoryid)
        //{
        //    dal.DeleteMaterialCategory(materialcategoryid);
        //}

        //public List<Tree> GetHeadTree()
        //{
        //    List<Tree> tlist = new List<Tree>();

        //    Tree headtree = new Tree();
        //    headtree.id = Guid.NewGuid().ToString();
        //    headtree.text = "物料分类";

        //    tlist.Add(headtree);

        //    List<AppMaterialCategory> amclist = dal.GetList();
        //    if (amclist != null && amclist.Count > 0)
        //    {
        //        foreach (AppMaterialCategory amc in amclist)
        //        {
        //            Tree t = new Tree() { id = amc.ID, text = amc.Name, pid = headtree.id };
        //            tlist.Add(t);
        //        }
        //    }
        //    return tlist;
        //}
    }
}
