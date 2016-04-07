using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SysItem
    {
        public string ID { get; set; }

        public string ParentID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public bool IsTree { get; set; }

        public bool AllowEdit { get; set; }

        public bool AllowDelete { get; set; }

        public bool Enabled { get; set; }

        public bool DeleteMark { get; set; }

        public int OrderID { get; set; }

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

        public List<SysItem> SysItems{ get; set; }

        public SysItem PSysItem { get; set; }

        public List<SysItemDetail> SysItemDetails { get; set; }
    }
}
