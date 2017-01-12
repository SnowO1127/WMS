<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleAdd.aspx.cs" Inherits="WMS.SystemManage.Role.RoleAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../library/jquery-1.8.2.min.js"></script>
    <script src="../../library/jquery.easyui.min.js"></script>
    <script src="../../library/locale/easyui-lang-zh_CN.js"></script>
    <script src="../../library/jquery.cookie.js"></script>
    <script src="../../library/xyEasyUI.js"></script>
    <script src="../../library/xyUtils.js"></script>
    <link id="easyuiTheme" href="../../library/themes/bootstrap/easyui.css" rel="stylesheet" />
    <link href="../../library/themes/icon.css" rel="stylesheet" />
    <link href="../../library/MyCss.css" rel="stylesheet" />
    <title></title>
    <script>
        var roleid = "<%=roleid %>";

        $(function () {

            $('#Category').combobox({
                url: '../../datasorce/sy_itemdetail.ashx?action=getCombox&code=RoleCategory',
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

            if (roleid) {
                $.ajax({
                    url: "../../datasorce/sy_role.ashx?action=getRoleByID",
                    dataType: "json",
                    type: "post",
                    data: {
                        RoleID: roleid
                    },
                    success: function (jr) {
                        if (jr.Success) {
                            $("#role_add_form").form('load', jr.Obj);
                        }
                        else {
                            $.messager.alert("错误", jr.Msg, "error");
                        }
                    }
                })
            }
        });

        var f_save = function ($dialog, $grid, $pjq) {
            if ($('#role_add_form').form('validate')) {
                var url;
                if (roleid) {
                    url = "../../datasorce/sy_role.ashx?action=Update";
                } else {
                    url = "../../datasorce/sy_role.ashx?action=Insert";
                }
                $.ajax({
                    url: url,
                    type: "post",
                    dataType: "json",
                    data: sy.serializeObject($('#role_add_form')),
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
        <form id="role_add_form" runat="server" style="font-size: 13px; padding-top: 10px">
            <table style="width: 100%">
                <tr>
                    <td class="tb_td_lable" style="width: 80px">角色编号：</td>
                    <td class="tb_td">
                        <input name="Code" class="easyui-textbox" type="text" data-options="required:true" style="width: 150px; height: 26px" />
                        <input name="ID" type="hidden" />
                    </td>
                </tr>
                <tr>
                    <td class="tb_td_lable">角色名称：</td>
                    <td class="tb_td">
                        <input name="Name" class="easyui-textbox" data-options="required:true" style="width: 150px; height: 26px" />
                    </td>
                </tr>
                <tr>
                    <td class="tb_td_lable">角色分类：</td>
                    <td class="tb_td">
                        <input name="Category" id="Category" type="text" />
                    </td>
                </tr>
                <tr>
                    <td class="tb_td_lable">有效：</td>
                    <td class="tb_td">
                        <select id="Enabled" name="Enabled" class="easyui-combobox" data-options="panelHeight:50,editable:false" style="width: 150px; height: 26px">
                            <option value="true">是</option>
                            <option value="false">否</option>
                        </select>
                    </td>
                    <td class="tb_td_lable" style="width: 80px">排序号：</td>
                    <td class="tb_td">
                        <input name="OrderID" class="easyui-textbox" data-options="required:true,validType:'integer',tipPosition:'left'" style="width: 150px; height: 26px" />
                    </td>
                </tr>
                <tr>
                    <td class="tb_td_lable">允许编辑：</td>
                    <td class="tb_td">
                        <select id="AllowEdit" name="AllowEdit" class="easyui-combobox" data-options="panelHeight:50,editable:false" style="width: 150px; height: 26px">
                            <option value="true">是</option>
                            <option value="false">否</option>
                        </select>
                    </td>
                    <td class="tb_td_lable">允许删除：</td>
                    <td class="tb_td">
                        <select id="AllowDelete" name="AllowDelete" class="easyui-combobox" data-options="panelHeight:50,editable:false" style="width: 150px; height: 26px">
                            <option value="true">是</option>
                            <option value="false">否</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td class="tb_td_lable">角色描述：</td>
                    <td class="tb_td" colspan="3">
                        <input name="Description" class="easyui-textbox" data-options="multiline:true,height:50" style="width: 415px" />
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
