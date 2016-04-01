using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SysButton
    {
        public string ID { get; set; }

        public string MenuID { get; set; }

        public string HtmlID { get; set; }

        public string Name { get; set; }

        public int OrderID { get; set; }

        public bool IsPublic { get; set; }

        public bool Enabled { get; set; }

        public bool AllowEdit { get; set; }

        public bool AllowDelete { get; set; }

        public bool DeleteMark { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

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

        public SysMenu SysMenu { get; set; }

        public List<SysUser> Users { get; set; }

        public List<SysRole> Roles { get; set; }
    }
}
