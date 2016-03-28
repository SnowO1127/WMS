using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SysOganize
    {

        /// <summary>
        /// 主键
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 父模块id/外键
        /// </summary>
        public string ParentID { get; set; }

        /// <summary>
        /// 组织名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 主管id
        /// </summary>
        public string ManagerID { get; set; }

        /// <summary>
        /// 主管姓名
        /// </summary>
        public string ManagerName { get; set; }

        /// <summary>
        /// 副主管id
        /// </summary>
        public string AssistantManagerID { get; set; }

        /// <summary>
        /// 副主管姓名
        /// </summary>
        public string AssistantManagerName { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// 网址
        /// </summary>
        public string WebUrl { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// 有效
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
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

        public List<SysOganize> SysOganizes { get; set; }

        public SysOganize PSysOganize { get; set; }

    }
}
