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

            $('#Category').combobox({
                url: '../../datasorce/sy_itemdetail.ashx?action=getcombox&code=RoleCategory',
                valueField: 'Value',
                textField: 'Name',
                width: 153,
                panelHeight: 100,
                editable: false,
                required: true
            });

            $('#Enabled').combobox({
                url: '../../datasorce/sy_itemdetail.ashx?action=getcombox&code=Enabled',
                valueField: 'Value',
                textField: 'Name',
                width: 153,
                panelHeight: 50,
                editable: false,
                required: true
            });

            $('#AllowEdit').combobox({
                url: '../../datasorce/sy_itemdetail.ashx?action=getcombox&code=AllowEdit',
                valueField: 'Value',
                textField: 'Name',
                width: 153,
                panelHeight: 50,
                editable: false,
                required: true
            });

            $('#AllowDelete').combobox({
                url: '../../datasorce/sy_itemdetail.ashx?action=getcombox&code=AllowDelete',
                valueField: 'Value',
                textField: 'Name',
                width: 153,
                panelHeight: 50,
                editable: false,
                required: true
            });

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
    <div class="easyui-layout" fit="true">
        <form id="role_add_form" runat="server" style="font-size: 12px; padding-left: 25px; padding-top: 10px">
            <table>
                <tr>
                    <td style="width: 60px">角色编号</td>
                    <td>
                        <input name="Code" class="easyui-validatebox" type="text" data-options="required:true" style="width: 150px" />
                        <input name="ID" type="hidden" />
                    </td>

                </tr>
                <tr>
                    <td>角色名称</td>
                    <td>
                        <input name="Name" class="easyui-validatebox" data-options="required:true" style="width: 150px" />
                    </td>
                </tr>
                <tr>
                    <td>角色分类</td>
                    <td>
                        <input name="Category" id="Category" type="text" />
                    </td>
                </tr>
                <tr>
                    <td>有效</td>
                    <td>
                        <input name="Enabled" id="Enabled" type="text" />
                    </td>
                    <td style="width: 60px">排序号</td>
                    <td>
                        <input name="OrderID" class="easyui-validatebox" data-options="validType:'integer',tipPosition:'left'" style="width: 150px" />
                    </td>
                </tr>
                <tr>
                    <td>允许编辑</td>
                    <td>
                        <input name="AllowEdit" id="AllowEdit" type="text" />
                    </td>
                    <td>允许删除</td>
                    <td>
                        <input name="AllowDelete" id="AllowDelete" type="text" />
                    </td>
                </tr>
                <tr>
                    <td>角色描述</td>
                    <td colspan="3">
                        <textarea name="Description" class="easyui-validatebox" style="width: 370px; height: 50px"></textarea>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
