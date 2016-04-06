using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
    public static class SessionHelper
    {
        /// <summary>
        /// 根据session名获取session对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static object GetSession(string name)
        {
            return HttpContext.Current.Session[name];
        }
        /// <summary>
        /// 设置session
        /// </summary>
        /// <param name="name">session 名</param>
        /// <param name="val">session 值</param>
        public static void SetSession(string name, object val)
        {
            HttpContext.Current.Session.Remove(name);
            HttpContext.Current.Session.Add(name, val);
        }

        /// <summary>
        /// 删除某个Session对象
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        public static void Del(string strSessionName)
        {
            HttpContext.Current.Session[strSessionName] = null;
        }
    }
}
