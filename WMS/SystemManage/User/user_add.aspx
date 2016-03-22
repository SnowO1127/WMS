<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_add.aspx.cs" Inherits="WMS.SystemManage.User.user_add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../library/jquery-1.8.2.min.js"></script>
    <script src="../../library/jquery.easyui.min.js"></script>
    <script src="../../library/easyui-lang-zh_CN.js"></script>
    <link href="../../library/themes/default/easyui.css" rel="stylesheet" />
    <link href="../../library/themes/icon.css" rel="stylesheet" />
    <title></title>
    <script>
        var id = "<%=id %>";

        $(function () {
            if (id) {
                $.ajax({
                    url: "../../datasorce/sy_user.ashx?action=getoneuser",
                    dataType: "json",
                    type: "post",
                    data: {
                        id: id
                    },
                    success: function (jsonresult) {
                        $("#user_add_form").form('load', jsonresult);
                    }
                })
            }
        });

        var f_save = function ($dialog, $grid, $pjq) {
            if ($('#unit_add_form').form('validate')) {
                var url;
                if (id) {
                    url = "../../datasorce/sy_user.ashx?action=updateuser";
                } else {
                    url = "../../datasorce/sy_user.ashx?action=adduser";
                }
                $.ajax({
                    url: url,
                    type: "post",
                    dataType: "json",
                    data: $('#user_add_form').serializeArray(),
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
    <div class="easyui-layout" fit="true">
        <form id="user_add_form" runat="server" style="font-size: 13px">
            <table>
                <tr>
                    <td style="width: 60px">登录名</td>
                    <td>
                        <input name="LoginName" class="easyui-validatebox" type="text" data-options="required:true" style="width: 150px" />
                        <input name="UserID" type="hidden" />
                    </td>
                    <td style="width: 60px">姓名</td>
                    <td>
                        <input name="UserName" class="easyui-validatebox" data-options="required:true" style="width: 150px" />
                    </td>
                </tr>
                <tr>
                    <td>编号</td>
                    <td>
                        <input name="UserNum" class="easyui-validatebox" data-options="required:true" style="width: 150px" />
                    </td>
                    <td>性别</td>
                    <td>
                        <select id="Sex" class="easyui-combobox" data-options="required:true,panelHeight:50,editable:false" name="Sex" style="width: 150px">
                            <option value="男">男</option>
                            <option value="女">女</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>手机号码</td>
                    <td>
                        <input name="PhoneNum" class="easyui-validatebox" style="width: 150px" />
                    </td>
                    <td>出生日期</td>
                    <td>
                        <input name="Birthday" class="easyui-validatebox" style="width: 150px" />
                    </td>
                </tr>
                <tr>
                    <td>电话号码</td>
                    <td>
                        <input name="Tel" class="easyui-validatebox" style="width: 150px" />
                    </td>
                    <td>岗位</td>
                    <td>
                        <select id="Post" class="easyui-combobox" data-options="panelHeight:100,editable:false" name="Post" style="width: 150px">
                            <option value="员工">员工</option>
                            <option value="经理">经理</option>
                            <option value="部长">部长</option>
                            <option value="总经理">总经理</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>QQ号码</td>
                    <td>
                        <input name="QQ" class="easyui-validatebox" style="width: 150px" />
                    </td>
                    <td>邮箱</td>
                    <td>
                        <input name="Email" class="easyui-validatebox" style="width: 150px" />
                    </td>
                </tr>
                <tr>
                    <td>地址</td>
                    <td colspan="3">
                        <input name="Address" class="easyui-validatebox" style="width: 150px" />
                    </td>
                </tr>
                <tr>
                    <td>公司</td>
                    <td>
                        <input name="Company" class="easyui-validatebox" style="width: 150px" />
                    </td>
                    <td>子公司</td>
                    <td>
                        <input name="ChildCompany" class="easyui-validatebox" style="width: 150px" />
                    </td>
                </tr>
                <tr>
                    <td>部门</td>
                    <td>
                        <input name="Dept" class="easyui-validatebox" style="width: 150px" />
                    </td>
                    <td>子部门</td>
                    <td>
                        <input name="ChildDept" class="easyui-validatebox" style="width: 150px" />
                    </td>
                </tr>
                <tr>
                    <td>组</td>
                    <td>
                        <input name="ClassGroup" class="easyui-validatebox" style="width: 150px" />
                    </td>
                </tr>
                <tr>
                    <td>备注</td>
                    <td colspan="3">
                        <textarea name="Memo" id="Memo" style="width: 300px; height: 50px"></textarea>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
