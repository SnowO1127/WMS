<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAdd.aspx.cs" Inherits="WMS.SystemManage.User.UserAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../library/jquery.min.js"></script>
    <script src="../../library/jquery.easyui.min.js"></script>
    <script src="../../library/locale/easyui-lang-zh_CN.js"></script>
    <script src="../../library/jquery.cookie.js"></script>
    <script src="../../library/My97DatePicker/WdatePicker.js"></script>
    <script src="../../library/xyEasyUI.js"></script>
    <script src="../../library/xyUtils.js"></script>
    <link id="easyuiTheme" href="../../library/themes/bootstrap/easyui.css" rel="stylesheet" />
    <link href="../../library/themes/icon.css" rel="stylesheet" />
    <link href="../../library/MyCss.css" rel="stylesheet" />
    <title></title>
    <script>
        var userid = "<%=userid %>";

        $(function () {

            $('#Post').combobox({
                url: '../../datasorce/sy_itemdetail.ashx?action=getCombox&code=Post',
                valueField: 'Value',
                textField: 'Name',
                width: 150,
                height: 26,
                panelHeight: 100,
                editable: false,
                required: true,
                loadFilter: function (data) {
                    if (data.Success) {
                        return data.Obj;
                    } else {
                        parent.$.messager.alert('提示', data.Msg, 'error');
                    }
                }
            });

            $('#Sex').combobox({
                url: '../../datasorce/sy_itemdetail.ashx?action=getCombox&code=Gender',
                valueField: 'Value',
                textField: 'Name',
                width: 150,
                height: 26,
                panelHeight: 60,
                editable: false,
                required: true,
                loadFilter: function (data) {
                    if (data.Success) {
                        return data.Obj;
                    } else {
                        parent.$.messager.alert('提示', data.Msg, 'error');
                    }
                }
            });

            $("#Company").combotree({
                url: '../../datasorce/sy_oganize.ashx?action=getOganizeTree',
                panelHeight: 190,
                editable: false,
                idField: 'id',
                textField: 'text',
                parentField: 'pid'
            })

            $("#ChildCompany").combotree({
                url: '../../datasorce/sy_oganize.ashx?action=getOganizeTree',
                panelHeight: 190,
                editable: false,
                idField: 'id',
                textField: 'text',
                parentField: 'pid'
            })

            $("#Dept").combotree({
                url: '../../datasorce/sy_oganize.ashx?action=getOganizeTree',
                panelHeight: 190,
                editable: false,
                idField: 'id',
                textField: 'text',
                parentField: 'pid'
            })

            $("#ChildDept").combotree({
                url: '../../datasorce/sy_oganize.ashx?action=getOganizeTree',
                panelHeight: 190,
                editable: false,
                idField: 'id',
                textField: 'text',
                parentField: 'pid'
            })

            $("#ClassGroup").combotree({
                url: '../../datasorce/sy_oganize.ashx?action=getOganizeTree',
                panelHeight: 190,
                editable: false,
                idField: 'id',
                textField: 'text',
                parentField: 'pid'
            })

            //$.ajax({
            //    url: '../../datasorce/sy_oganize.ashx?action=getOganizeTree',
            //    dataType: 'json',
            //    type: 'post',
            //    success: function (jr) {
            //        if (jr.Success) {

            //            $("#Company").combotree("loadData", jr.Obj);

            //            $("#ChildCompany").combotree("loadData", jr.Obj);

            //            $("#Dept").combotree("loadData", jr.Obj);

            //            $("#ChildDept").combotree("loadData", jr.Obj);

            //            $("#ClassGroup").combotree("loadData", jr.Obj);
            //        }
            //        else {
            //            $.messager.alert('错误', r.Msg, "error");
            //        }
            //    }
            //})

            if (userid) {
                $.ajax({
                    url: "../../datasorce/sy_user.ashx?action=getUserByID",
                    dataType: "json",
                    type: "post",
                    data: {
                        UserID: userid
                    },
                    success: function (jr) {
                        if (jr.Success) {
                            $("#user_add_form").form('load', jr.Obj);
                        }
                        else {
                            $.messager.alert('错误', jr.Msg, 'error');
                        }
                    }
                })
            }
        });

        

        var f_save = function ($dialog, $grid, $pjq) {
            if ($('#user_add_form').form('validate')) {
                var url;
                if (userid) {
                    url = "../../datasorce/sy_user.ashx?action=Update";
                } else {
                    url = "../../datasorce/sy_user.ashx?action=Insert";
                }

                var data = sy.serializeObject($('#user_add_form'));

                sy.mergeObj(data, {
                    CompanyName: $("#Company").combotree('tree').tree('getSelected').text,
                    ChildCompanyName: $("#ChildCompany").combotree('tree').tree('getSelected').text,
                    DeptName: $("#Dept").combotree('tree').tree('getSelected').text,
                    ChildDeptName: $("#ChildDept").combotree('tree').tree('getSelected').text,
                    ClassGroupName: $("#ClassGroup").combotree('tree').tree('getSelected').text,
                })

                $.ajax({
                    url: url,
                    type: "post",
                    dataType: "json",
                    data: data,
                    success: function (jsonresult) {
                        if (jsonresult.Success) {
                            $pjq.messager.alert('提示', jsonresult.Msg, 'info');
                            $grid.datagrid('load');
                            $dialog.dialog('destroy');
                        } else {
                            $pjq.messager.alert('提示', jsonresult.Msg, 'error');
                        }
                    }
                });
            }
        };
    </script>
</head>
<body>
    <div style="margin: 0 auto">
        <form id="user_add_form" runat="server" style="font-size: 13px; padding-top: 10px;">
            <table style="width: 100%">
                <tr>
                    <td class="tb_td_lable" style="width: 80px">登录名：</td>
                    <td class="tb_td" style="width: 180px">
                        <input name="LoginName" class="easyui-textbox" type="text" data-options="required:true" style="width: 150px; height: 26px" />
                        <input name="ID" type="hidden" />
                    </td>
                    <td class="tb_td_lable" style="width: 80px">姓名：</td>
                    <td class="tb_td" style="width: 180px">
                        <input name="RealName" class="easyui-textbox" data-options="required:true,validType:'chinese',tipPosition:'left'" style="width: 150px; height: 26px" />
                    </td>
                </tr>
                <tr>
                    <td class="tb_td_lable">编号：</td>
                    <td class="tb_td">
                        <input name="Code" class="easyui-textbox" data-options="required:true" style="width: 150px; height: 26px" />
                    </td>
                    <td class="tb_td_lable">拼音简写：</td>
                    <td class="tb_td">
                        <input name="SpellQuery" class="easyui-textbox" data-options="required:true,tipPosition:'left'" style="width: 150px; height: 26px" />
                    </td>
                </tr>
                <tr>
                    <td class="tb_td_lable">性别：</td>
                    <td class="tb_td">
                        <input name="Sex" id="Sex" type="text" />
                    </td>
                </tr>
                <tr>
                    <td class="tb_td_lable">公司：</td>
                    <td class="tb_td">
                        <input id="Company" name="Company" class="easyui-combotree" style="width: 150px; height: 26px" data-options="" />
                    </td>
                    <td class="tb_td_lable">子公司：</td>
                    <td class="tb_td">
                        <input id="ChildCompany" name="ChildCompany" class="easyui-combotree" style="width: 150px; height: 26px" data-options="panelHeight:190,editable:false,idField:'id',textField:'text',parentField:'pid',url:'../../datasorce/sy_oganize.ashx?action=getoganizetree'" />
                    </td>
                </tr>
                <tr>
                    <td class="tb_td_lable">部门：</td>
                    <td class="tb_td">
                        <input id="Dept" name="Dept" class="easyui-combotree" style="width: 150px; height: 26px" data-options="panelHeight:190,editable:false,idField:'id',textField:'text',parentField:'pid',url:'../../datasorce/sy_oganize.ashx?action=getoganizetree'" />
                    </td>
                    <td class="tb_td_lable">子部门：</td>
                    <td class="tb_td">
                        <input id="ChildDept" name="ChildDept" class="easyui-combotree" style="width: 150px; height: 26px" data-options="panelHeight:190,editable:false,idField:'id',textField:'text',parentField:'pid',url:'../../datasorce/sy_oganize.ashx?action=getoganizetree'" />
                    </td>
                </tr>
                <tr>
                    <td class="tb_td_lable">组：</td>
                    <td class="tb_td">
                        <input id="ClassGroup" name="ClassGroup" class="easyui-combotree" style="width: 150px; height: 26px" data-options="panelHeight:190,editable:false,idField:'id',textField:'text',parentField:'pid',url:'../../datasorce/sy_oganize.ashx?action=getoganizetree'" />
                    </td>
                </tr>
                <tr>
                    <td class="tb_td_lable">出生日期：</td>
                    <td class="tb_td">
                        <input name="Birthday" class="easyui-datebox" style="width: 150px; height: 26px" />
                    </td>
                    <td class="tb_td_lable">手机号码：</td>
                    <td class="tb_td">
                        <input name="PhoneNum" class="easyui-textbox" data-options="validType:'mobile',tipPosition:'left'" style="width: 150px; height: 26px" />
                    </td>
                </tr>
                <tr>
                    <td class="tb_td_lable">岗位：</td>
                    <td class="tb_td">
                        <input name="Post" id="Post" type="text" style="width: 150px; height: 26px" />
                    </td>
                    <td class="tb_td_lable">电话号码：</td>
                    <td class="tb_td">
                        <input name="Tel" class="easyui-textbox" data-options="validType:'phone',tipPosition:'left'" style="width: 150px; height: 26px" />
                    </td>
                </tr>
                <tr>
                    <td class="tb_td_lable">邮箱：</td>
                    <td class="tb_td">
                        <input name="Email" class="easyui-textbox" data-options="validType:'email'" style="width: 150px; height: 26px" />
                    </td>
                    <td class="tb_td_lable">QQ号码：</td>
                    <td class="tb_td">
                        <input name="QQ" class="easyui-textbox" data-options="validType:'qq',tipPosition:'left'" style="width: 150px; height: 26px" />
                    </td>
                </tr>
                <tr>
                    <td class="tb_td_lable">地址：</td>
                    <td class="tb_td" colspan="3">
                        <input name="Address" class="easyui-textbox" style="width: 415px; height: 26px" />
                    </td>
                </tr>
                <tr>
                    <td class="tb_td_lable">有效：</td>
                    <td class="tb_td">
                        <select id="Enabled" name="Enabled" class="easyui-combobox" data-options="panelHeight:50,editable:false,required:true" style="width: 150px; height: 26px">
                            <option value="true">是</option>
                            <option value="false">否</option>
                        </select>
                    </td>
                    <td class="tb_td_lable">管理员：</td>
                    <td class="tb_td">
                        <select id="IsAdmin" name="IsAdmin" class="easyui-combobox" data-options="panelHeight:50,editable:false,required:true" style="width: 150px; height: 26px">
                            <option value="true">是</option>
                            <option value="false">否</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td class="tb_td_lable">排序号：</td>
                    <td class="tb_td">
                        <input name="OrderID" class="easyui-textbox" data-options="required:true,validType:'integer'" style="width: 150px; height: 26px" />
                    </td>
                </tr>
                <tr>
                    <td class="tb_td_lable">备注：</td>
                    <td class="tb_td" colspan="3">
                        <input name="Description" class="easyui-textbox" data-options="multiline:true,height:50" style="width: 415px" />
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
