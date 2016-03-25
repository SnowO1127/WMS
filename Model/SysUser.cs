using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SysUser
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 用户登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        ///// <summary>
        ///// 真实姓名
        ///// </summary>
        //public string RealName { get; set; }

        ///// <summary>
        ///// 真实姓名
        ///// </summary>
        //public string RealName { get; set; }

        ///// <summary>
        ///// 真实姓名
        ///// </summary>
        //public string RealName { get; set; }

        ///// <summary>
        ///// 真实姓名
        ///// </summary>
        //public string RealName { get; set; }

        ///// <summary>
        ///// 真实姓名
        ///// </summary>
        //public string RealName { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CDate { get; set; }

        /// <summary>
        /// 创建人id
        /// </summary>
        public string CUserID { get; set; }

        /// <summary>
        /// 创建人姓名
        /// </summary>
        public string CUserName { get; set; }

        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime? UDate { get; set; }

        /// <summary>
        /// 更新人id
        /// </summary>
        public string UUserID { get; set; }

        /// <summary>
        /// 更新人姓名
        /// </summary>
        public string UUserName { get; set; }

        /// <summary>
        /// 删除日期
        /// </summary>
        public DateTime? DDate { get; set; }

        /// <summary>
        /// 删除人id
        /// </summary>
        public string DUserID { get; set; }

        /// <summary>
        /// 删除人姓名
        /// </summary>
        public string DUserName { get; set; }

        public List<SysRole> Roles { get; set; }
    }
}
