using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AppUnitConversion
    {
        public string ID { get; set; }

        public string Code { get; set; }

        public string MainUnitName { get; set; }

        public string AssistUnitName { get; set; }

        public int TranslateRate { get; set; }

        public int OrderID { get; set; }

        public bool Enabled { get; set; }

        public string Description { get; set; }

        public bool DeleteMark { get; set; }

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
    }
}
