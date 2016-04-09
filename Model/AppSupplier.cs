using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AppSupplier
    {
        public string ID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string LinkMan { get; set; }

        public string Tel { get; set; }

        public string Fax { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string PostCode { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public string Longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public string Latitude { get; set; }

        public int OrderID { get; set; }

        public bool Enabled { get; set; }

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
