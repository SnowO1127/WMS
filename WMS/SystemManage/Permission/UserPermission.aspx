<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPermission.aspx.cs" Inherits="WMS.SystemManage.Permission.UserPermission" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../library/jquery-1.9.1.min.js"></script>
    <script src="../../library/jquery.easyui.min.js"></script>
    <script src="../../library/easyui-lang-zh_CN.js"></script>
    <script src="../../library/jquery.cookie.js"></script>
    <script src="../../library/xyEasyUI.js"></script>
    <script src="../../library/xyUtils.js"></script>
    <link id="easyuiTheme" href="../../library/themes/bootstrap/easyui.css" rel="stylesheet" />
    <link href="../../library/themes/icon.css" rel="stylesheet" />
    <link href="../../library/base_css/ui.css" rel="stylesheet" />
    <link href="../../library/syExtCss.css" rel="stylesheet" />
    <link href="../../library/syExtIcon.css" rel="stylesheet" />
    <title></title>
    <script>
        $(function () {
            grid = $('#user_list_grid').datagrid({
                title: '',
                url: '../../datasorce/sy_user.ashx?action=getListByPage',
                striped: true,
                rownumbers: true,
                pagination: true,
                singleSelect: true,
                idField: 'ID',
                sortName: 'OrderID',
                sortOrder: 'asc',
                pageSize: 10,
                pageList: [10, 20, 30, 40, 50, 100, 200, 300, 400, 500],
                frozenColumns: [[{
                    width: '90',
                    title: '登录名',
                    field: 'LoginName',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '70',
                    title: '姓名',
                    field: 'RealName',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }]],
                columns: [[{
                    width: '60',
                    title: '编号',
                    field: 'Code',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '70',
                    title: '拼音简写',
                    field: 'SpellQuery',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '60',
                    title: '性别',
                    field: 'Sex',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '120',
                    title: '公司',
                    field: 'CompanyName',
                    halign: 'center',
                    sortable: true
                }, {
                    width: '90',
                    title: '部门',
                    field: 'DeptName',
                    halign: 'center',
                    sortable: true
                }, {
                    width: '90',
                    title: '生日',
                    halign: 'center',
                    align: 'center',
                    field: 'Birthday'
                }, {
                    width: '100',
                    title: '手机',
                    halign: 'center',
                    align: 'center',
                    field: 'PhoneNum'
                }, {
                    width: '80',
                    title: '岗位',
                    halign: 'center',
                    align: 'center',
                    field: 'Post'
                }, {
                    width: '220',
                    title: '地址',
                    halign: 'center',
                    field: 'Address'
                }, {
                    width: '70',
                    title: '管理员',
                    field: 'IsAdmin',
                    halign: 'center',
                    align: 'center',
                    formatter: function (value, row, index) {
                        if (row.IsAdmin) {
                            return "√";
                        } else {
                            return "×";
                        }
                    }
                }, {
                    width: '60',
                    title: '有效',
                    field: 'Enabled',
                    halign: 'center',
                    align: 'center',
                    formatter: function (value, row, index) {
                        if (row.Enabled) {
                            return "√";
                        } else {
                            return "×";
                        }
                    }
                }, {
                    width: '70',
                    title: '排序号',
                    halign: 'center',
                    align: 'center',
                    field: 'OrderID'
                }]],
                toolbar: [{
                    iconCls: 'icon-save',
                    text: '查看用户权限',
                    handler: function () {
                        var row = grid.datagrid('getSelected');
                        if (row) {
                            if (!row.IsAdmin) {
                                openAddRole(row);
                            }
                            else {
                                parent.$.messager.alert('提示', "管理员拥有所有权限,无法查看！", "info");
                            }
                        }
                        else {
                            parent.$.messager.alert('提示', "请选择行", "info");
                        }
                    }
                }, '-', {
                    iconCls: 'icon-add',
                    text: '用户角色设置',
                    handler: function () {
                        var row = grid.datagrid('getSelected');
                        if (row) {
                            if (!row.IsAdmin) {
                                openAddRole(row);
                            }
                            else {
                                parent.$.messager.alert('提示', "管理员无法设置角色！", "info");
                            }
                        }
                        else {
                            parent.$.messager.alert('提示', "请选择行", "info");
                        }
                    }
                }, '-', {
                    iconCls: 'icon-save',
                    text: '用户部门设置',
                    handler: function () {
                        var row = grid.datagrid('getSelected');
                        if (row) {
                            if (!row.IsAdmin) {
                                openAddOganize(row);
                            }
                            else {
                                parent.$.messager.alert('提示', "管理员无法设置部门！", "info");
                            }
                        }
                        else {
                            parent.$.messager.alert('提示', "请选择行", "info");
                        }
                    }
                }, '-', {
                    iconCls: 'icon-edit',
                    text: '用户权限设置',
                    handler: function () {
                        var row = grid.datagrid('getSelected');
                        if (row) {
                            if (!row.IsAdmin) {
                                openAddUserPermission(row);
                            }
                            else {
                                parent.$.messager.alert('提示', "管理员无法设置权限！", "info");
                            }
                        }
                        else {
                            parent.$.messager.alert('提示', "请选择行", "info");
                        }
                    }
                }],
                loadFilter: function (data) {
                    if (data.Success) {
                        return data.Obj;
                    } else {
                        parent.$.messager.alert('提示', data.Msg, 'error');
                    }
                }
            });
        });

        var openView = function (row) {
            var dialog = parent.sy.modalDialog({
                iconCls: 'icon-save',
                title: '查看用户权限',
                width: 520,
                height: 400,
                url: 'SystemManage/User/UserAdd.aspx?userid=' + row.ID + '',
            });
        }

        var openAddRole = function (row) {
            var dialog = parent.sy.modalDialog({
                iconCls: 'ext-icon-cog',
                title: '角色设置【当前用户：' + row.RealName + '】',
                width: 600,
                height: 450,
                url: 'SystemManage/UserRole/UserRoleSet.aspx?userid=' + row.ID + '',
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-add',
                    handler: function () {
                        dialog.find('iframe').get(0).contentWindow.f_save_roles(dialog, parent.$);
                    }
                }]
            });
        }

        var openAddUserPermission = function (row) {
            var dialog = parent.sy.modalDialog({
                iconCls: 'ext-icon-cog',
                title: '权限设置【当前用户：' + row.RealName + '】',
                width: 300,
                height: 450,
                url: 'SystemManage/Permission/UserPermissionSet.aspx?userid=' + row.ID + '',
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-add',
                    handler: function () {
                        dialog.find('iframe').get(0).contentWindow.f_save_permission(dialog, parent.$);
                    }
                }]
            });
        }
    </script>
</head>
<body>
    <div class="easyui-layout" fit="true">
        <div data-options="region: 'center', border: false" style="overflow: hidden; padding: 1px;">
            <div id="user_list_grid" fit="true">
            </div>
        </div>
    </div>
</body>
</html>
