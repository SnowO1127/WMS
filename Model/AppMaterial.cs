﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AppMaterial
    {
        public string ID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string CategoryID { get; set; }

        public string UnitConversionID { get; set; }

        public string Mnemonics { get; set; }

        public decimal Weight { get; set; }

        public decimal Long { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public decimal Volume { get; set; }

        public string Wrappage { get; set; }

        public int WarrantyDays { get; set; }

        public int WarrantyWarnDays { get; set; }

        public string Description { get; set; }

        public int OrderID { get; set; }

        public bool IsBatch { get; set; }

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


        public AppUnitConversion UnitConversion { get; set; }

        public AppMaterialCategory MaterialCategory { get; set; }
    }
}
