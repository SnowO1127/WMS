using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SysRole
    {
        /// <summary>
        /// 角色号
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 角色编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 角色类别
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 有效
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 允许删除
        /// </summary>
        public bool AllowDelete { get; set; }

        /// <summary>
        /// 允许编辑
        /// </summary>
        public bool AllowEdit { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
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

        public  List<SysUser> Users { get; set; }

        /// <summary>
        /// 菜单
        /// </summary>
        public List<SysMenu> Menus { get; set; }

        /// <summary>
        /// 按钮
        /// </summary>
        public List<SysButton> Buttons { get; set; }
    }
}
