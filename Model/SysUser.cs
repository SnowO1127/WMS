using Common;
using Newtonsoft.Json;
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

        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 拼音简写
        /// </summary>
        public string SpellQuery { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string PhoneNum { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [JsonConverter(typeof(ChinaDateTimeConverter))]
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 岗位
        /// </summary>
        public string Post { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        public string QQ { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 公司id
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 子公司id
        /// </summary>
        public string ChildCompany { get; set; }

        /// <summary>
        /// 子公司名称
        /// </summary>
        public string ChildCompanyName { get; set; }

        /// <summary>
        /// 部门id
        /// </summary>
        public string Dept { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 子部门
        /// </summary>
        public string ChildDept { get; set; }

        /// <summary>
        /// 子部门名称
        /// </summary>
        public string ChildDeptName { get; set; }

        /// <summary>
        /// 组id
        /// </summary>
        public string ClassGroup { get; set; }

        /// <summary>
        /// 组名称
        /// </summary>
        public string ClassGroupName { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// 有效
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdmin { get; set; }

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

        /// <summary>
        /// 角色
        /// </summary>
        public List<SysRole> Roles { get; set; }

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
