<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RolePermission.aspx.cs" Inherits="WMS.SystemManage.Permission.RolePermission" %>

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
    <link id="easyuiTheme" href="../../library/themes/default/easyui.css" rel="stylesheet" />
    <link href="../../library/themes/icon.css" rel="stylesheet" />
    <link href="../../library/base_css/ui.css" rel="stylesheet" />
    <link href="../../library/syExtCss.css" rel="stylesheet" />
    <link href="../../library/syExtIcon.css" rel="stylesheet" />
    <title></title>
    <script>
        $(function () {
            grid = $('#role_list_grid').datagrid({
                title: '',
                url: '../../datasorce/sy_role.ashx?action=getrole',
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
                    width: '100',
                    title: '角色编号',
                    field: 'Code',
                    halign: 'center',
                    sortable: true
                }, {
                    width: '120',
                    title: '角色名称',
                    field: 'Name',
                    halign: 'center',
                    sortable: true
                }]],
                columns: [[{
                    width: '80',
                    title: '角色类别',
                    halign: 'center',
                    field: 'Category',
                    align: 'center',
                    sortable: true
                }, {
                    width: '70',
                    title: '允许删除',
                    field: 'AllowDelete',
                    align: 'center',
                    halign: 'center',
                    sortable: true,
                    formatter: function (value, row, index) {
                        if (row.AllowDelete) {
                            return "√";
                        } else {
                            return "×";
                        }
                    }
                }, {
                    width: '70',
                    title: '允许编辑',
                    field: 'AllowEdit',
                    align: 'center',
                    halign: 'center',
                    sortable: true,
                    formatter: function (value, row, index) {
                        if (row.AllowEdit) {
                            return "√";
                        } else {
                            return "×";
                        }
                    }
                }, {
                    width: '50',
                    title: '有效',
                    field: 'Enabled',
                    halign: 'center',
                    align: 'center',
                    sortable: true,
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
                }, {
                    width: '220',
                    title: '描述',
                    halign: 'center',
                    field: 'Description'
                }]],
                toolbar: [{
                    iconCls: 'icon-save',
                    text: '查看角色权限',
                    handler: function () {
                        var row = grid.datagrid('getSelected');
                        if (row) {
                            openView(row.ID);
                        }
                        else {
                            parent.$.messager.alert('提示', "请选择行", "info");
                        }
                    }
                }, '-', {
                    iconCls: 'icon-add',
                    text: '角色用户设置',
                    handler: function () {
                        var row = grid.datagrid('getSelected');
                        if (row) {
                            openAddUser(row);
                        }
                        else {
                            parent.$.messager.alert('提示', "请选择行", "info");
                        }
                    }
                }, '-', {
                    iconCls: 'icon-save',
                    text: '角色部门设置',
                    handler: function () {
                        var row = grid.datagrid('getSelected');
                        if (row) {
                            openAddOganize(row);
                        }
                        else {
                            parent.$.messager.alert('提示', "请选择行", "info");
                        }
                    }
                }, '-', {
                    iconCls: 'icon-edit',
                    text: '角色权限设置',
                    handler: function () {
                        var row = grid.datagrid('getSelected');
                        if (row) {
                            openAddRolePermission(row);
                        }
                        else {
                            parent.$.messager.alert('提示', "请选择行", "info");
                        }
                    }
                }],
                onBeforeLoad: function (param) {
                    parent.$.messager.progress({
                        fit: true,
                        text: '数据加载中....'
                    });
                },
                onLoadSuccess: function () {
                    parent.$.messager.progress('close');
                }
            });
        });

        var openView = function (row) {
            var dialog = parent.sy.modalDialog({
                iconCls: 'icon-add',
                title: '查看角色权限',
                width: 520,
                height: 280,
                url: 'SystemManage/Role/RoleAdd.aspx',
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-add',
                    handler: function () {
                        dialog.find('iframe').get(0).contentWindow.f_save(dialog, grid, parent.$);
                    }
                }]
            });
        };

        var openAddUser = function (row) {
            var dialog = parent.sy.modalDialog({
                iconCls: 'ext-icon-cog',
                title: '用户设置【当前角色：' + row.Name + '】',
                width: 520,
                height: 280,
                url: 'SystemManage/UserRole/RoleSetUser.aspx?roleid=' + row.ID + '',
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-add',
                    handler: function () {
                        dialog.find('iframe').get(0).contentWindow.f_save(dialog, grid, parent.$);
                    }
                }]
            });
        }

        var openAddRolePermission = function (row) {
            var dialog = parent.sy.modalDialog({
                iconCls: 'ext-icon-cog',
                title: '权限设置【当前用户：' + row.Name + '】',
                width: 300,
                height: 450,
                url: 'SystemManage/Permission/RolePermissionSet.aspx?roleid=' + row.ID + '',
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
            <div id="role_list_grid" fit="true">
            </div>
        </div>
    </div>
</body>
</html>
