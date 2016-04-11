using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
    public static class UrlPathHelper
    {
        /// <summary>
        /// 获取 完整url （协议名+域名+虚拟目录名+文件名+参数）url= http://www.test.com/aaa/bbb.aspx?id=5&amp;name=kelli
        /// </summary>
        /// <returns></returns>
        public static string GetFullUrlPath()
        {
            return HttpContext.Current.Request.Url.ToString();
        }

        /// <summary>
        /// 获取 虚拟目录名+页面名+参数 url= /aaa/bbb.aspx?id=5&amp;name=kelli
        /// 或者 HttpContext.Current.Request.Url.PathAndQuery
        /// </summary>
        /// <returns></returns>
        public static string GetVirtualUrlPathAnQuery()
        {
            return HttpContext.Current.Request.RawUrl;
        }

        /// <summary>
        /// 获取 虚拟目录名+页面名：url= /aaa/bbb.aspx
        /// 或者 HttpContext.Current.Request.Url.AbsolutePath
        /// </summary>
        /// <returns></returns>
        public static string GetVirtualUrlPath()
        {
            return HttpContext.Current.Request.Path;

        }
        /// <summary>
        /// 获取 域名：url= www.test.com
        /// </summary>
        /// <returns></returns>
        public static string GetUrlHost()
        {
            return HttpContext.Current.Request.Url.Host;
        }

        /// <summary>
        /// 获取 参数：url= ?id=5&amp;name=kelli
        /// Request.QueryString[&quot;id&quot;]和Request.QueryString[&quot;name&quot;]访问各参数
        /// Request.UrlReferrer可以获取客户端上次请求的url的有关信息， 这样我们就可以通过这个属性返回到&quot;上一页&quot;。
        /// 同样地，Request.UrlReferrer.Query可以获取客户端上次请求的url的有关参数部分
        /// </summary>
        /// <returns></returns>
        public static string GetUrlQuery()
        {
            return HttpContext.Current.Request.Url.Query;
        }
    }
}
