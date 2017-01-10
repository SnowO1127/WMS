using Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IDAL;

namespace DalFactory
{
    public sealed class DataAccess//<t>
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DALPath"];
        /// <summary>
        /// 创建对象或从缓存获取
        /// </summary>
        public static object CreateObject(string AssemblyPath, string ClassNamespace)
        {
            object objType = DataCache.GetCache(ClassNamespace);//从缓存读取
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(ClassNamespace);//反射创建
                    DataCache.SetCache(ClassNamespace, objType);// 写入缓存
                }
                catch
                { }
            }
            return objType;
        }
        /// <summary>
        /// 创建数据层接口
        /// </summary>
        //public static t Create(string ClassName)
        //{
        //string ClassNamespace = AssemblyPath +"."+ ClassName;
        //object objType = CreateObject(AssemblyPath, ClassNamespace);
        //return (t)objType;
        //}
        /// <summary>
        /// 创建User数据层接口。
        /// </summary>
        public static ISysUserDAL CreateUser()
        {
            string ClassNamespace = AssemblyPath + ".SysUserDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISysUserDAL)objType;
        }

        public static ISysMenuDAL CreateMenu()
        {
            string ClassNamespace = AssemblyPath + ".SysMenuDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISysMenuDAL)objType;
        }

        public static ISysItemDAL CreateItem()
        {
            string ClassNamespace = AssemblyPath + ".SysItemDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISysItemDAL)objType;
        }

        public static ISysItemDetailDAL CreateItemDetail()
        {
            string ClassNamespace = AssemblyPath + ".SysItemDetailDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISysItemDetailDAL)objType;
        }

        public static ISysRoleDAL CreateRole()
        {
            string ClassNamespace = AssemblyPath + ".SysRoleDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISysRoleDAL)objType;
        }
    }
}
