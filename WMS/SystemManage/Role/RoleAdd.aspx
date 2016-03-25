<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleAdd.aspx.cs" Inherits="WMS.SystemManage.Role.RoleAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../library/jquery-1.8.2.min.js"></script>
    <script src="../../library/jquery.easyui.min.js"></script>
    <script src="../../library/easyui-lang-zh_CN.js"></script>
    <script src="../../library/jquery.cookie.js"></script>
    <script src="../../library/xyEasyUI.js"></script>
    <script src="../../library/xyUtils.js"></script>
    <link id="easyuiTheme" href="../../library/themes/default/easyui.css" rel="stylesheet" />
    <link href="../../library/themes/icon.css" rel="stylesheet" />
    <title></title>
    <script>
        var id = "<%=id %>";

        $(function () {
            if (id) {
                $.ajax({
                    url: "../../datasorce/sy_role.ashx?action=getonerole",
                    dataType: "json",
                    type: "post",
                    data: {
                        id: id
                    },
                    success: function (jsonresult) {
                        $("#role_add_form").form('load', jsonresult.Obj);
                    }
                })
            }
        });

        var f_save = function ($dialog, $grid, $pjq) {
            if ($('#role_add_form').form('validate')) {
                var url;
                if (id) {
                    url = "../../datasorce/sy_role.ashx?action=updaterole";
                } else {
                    url = "../../datasorce/sy_role.ashx?action=addrole";
                }
                $.ajax({
                    url: url,
                    type: "post",
                    dataType: "json",
                    data: $('#role_add_form').serializeArray(),
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
        <form id="role_add_form" runat="server" style="font-size: 12px; padding-left: 25px; padding-top: 10px">
            <table>
                <tr>
                    <td style="width: 60px">角色编号</td>
                    <td>
                        <input name="Code" class="easyui-validatebox" type="text" data-options="required:true" style="width: 210px" />
                        <input name="ID" type="hidden" />
                    </td>

                </tr>
                <tr>
                    <td>角色名称</td>
                    <td>
                        <input name="Name" class="easyui-validatebox" data-options="required:true" style="width: 210px" />
                    </td>
                </tr>
                <tr>
                    <td>角色分类</td>
                    <td>
                        <select id="Category" class="easyui-combobox" data-options="panelHeight:100,editable:false" name="Category" style="width: 213px">
                            <option value="管理员">管理员</option>
                            <option value="员工">员工</option>
                            <option value="经理">经理</option>
                            <option value="部长">部长</option>
                            <option value="总经理">总经理</option>
                        </select>
                    </td>
                    
                </tr>
                <tr>
                    <td>有效</td>
                    <td>
                        <select id="Enabled" class="easyui-combobox" data-options="required:true,panelHeight:50,editable:false" name="Enabled" style="width: 213px">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>允许编辑</td>
                    <td>
                        <select id="AllowEdit" class="easyui-combobox" data-options="required:true,panelHeight:50,editable:false" name="Enabled" style="width: 213px">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>允许删除</td>
                    <td>
                        <select id="AllowDelete" class="easyui-combobox" data-options="required:true,panelHeight:50,editable:false" name="Enabled" style="width: 213px">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>排序号</td>
                    <td>
                        <input name="OrderID" class="easyui-validatebox" style="width: 210px" />
                    </td>
                </tr>
                <tr>
                    <td>角色描述</td>
                    <td>
                        <textarea name="Description" class="easyui-validatebox" style="width: 208px; height: 40px"></textarea>
                    </td>

                </tr>
            </table>
        </form>
    </div>
</body>
</html>
