using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AppStockInBill
    {
        public string ID { get; set; }

        public DateTime BillDate { get; set; }

        public string BillCode { get; set; }

        public string MoveType { get; set; }

        public string SupplierID { get; set; }

        public string SupplierName { get; set; }

        public string OriginalBillID { get; set; }

        public string StockUpBillID { get; set; }

        public string HandUserID { get; set; }

        public string HandUserName { get; set; }

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
        /// 审核日期
        /// </summary>
        public DateTime? CheckDate { get; set; }

        /// <summary>
        /// 审核人id
        /// </summary>
        public string CheckUserID { get; set; }

        /// <summary>
        /// 审核人姓名
        /// </summary>
        public string CheckUserName { get; set; }
    }
}
