<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="WMS.SystemManage.User.UserList" %>

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
            grid = $('#user_list_grid').datagrid({
                title: '',
                url: '../../datasorce/sy_user.ashx?action=getuser',
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
                    iconCls: 'icon-add',
                    text: '增加',
                    handler: function () {
                        openAdd();
                    }
                }, '-', {
                    iconCls: 'icon-save',
                    text: '查看',
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
                    iconCls: 'icon-edit',
                    text: '编辑',
                    handler: function () {
                        var row = grid.datagrid('getSelected');
                        if (row) {
                            openEdit(row.ID);
                        }
                        else {
                            parent.$.messager.alert('提示', "请选择行", "info");
                        }
                    }
                }, '-', {
                    iconCls: 'icon-cut',
                    text: '删除',
                    handler: function () {
                        alert('帮助按钮');
                    }
                }, '-', {
                    iconCls: 'ext-icon-cog',
                    text: '用户角色设置',
                    handler: function () {
                        var row = grid.datagrid('getSelected');
                        if (row) {
                            openAddRole(row.ID);
                        }
                        else {
                            parent.$.messager.alert('提示', "请选择行", "info");
                        }
                    }
                }],
                onBeforeLoad: function (param) {
                    parent.$.messager.progress({
                        text: '数据加载中....'
                    });
                },
                onLoadSuccess: function (data) {
                    parent.$.messager.progress('close');
                }
            });
        });

        var openAdd = function () {
            var dialog = parent.sy.modalDialog({
                iconCls: 'icon-add',
                title: '新增用户',
                width: 520,
                height: 430,
                url: 'SystemManage/User/UserAdd.aspx',
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-add',
                    handler: function () {
                        dialog.find('iframe').get(0).contentWindow.f_save(dialog, grid, parent.$);
                    }
                }]
            });
        };

        var openEdit = function (id) {
            var dialog = parent.sy.modalDialog({
                iconCls: 'icon-edit',
                title: '编辑用户',
                width: 520,
                height: 430,
                url: 'SystemManage/User/UserAdd.aspx?id=' + id + '',
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-add',
                    handler: function () {
                        dialog.find('iframe').get(0).contentWindow.f_save(dialog, grid, parent.$);
                    }
                }]
            });
        }

        var openView = function (id) {
            var dialog = parent.sy.modalDialog({
                iconCls: 'icon-save',
                title: '查看用户',
                width: 520,
                height: 400,
                url: 'SystemManage/User/UserAdd.aspx?id=' + id + '',
            });
        }

        var deleteMenu = function (id) {
            parent.$.messager.confirm('删除菜单', '你确定删除菜单吗?', function (r) {
                if (r) {
                    $.ajax({
                        url: "../../datasorce/sy_menu.ashx?action=deletemenu",
                        dataType: "json",
                        type: "post",
                        data: {
                            id: id
                        },
                        success: function (jsonresult) {
                            if (jsonresult.Success) {
                                parent.$.messager.alert('提示', jsonresult.Msg, 'info');
                                grid.datagrid('load');
                                grid.datagrid("unselectAll");
                                tree.tree("reload");
                            } else {
                                parent.$.messager.alert('提示', jsonresult.Msg, 'error');
                            }
                        }
                    })
                }
            });
        }

        var openAddRole = function (id) {
            var dialog = parent.sy.modalDialog({
                iconCls: 'ext-icon-cog',
                title: '角色设置',
                width: 600,
                height: 450,
                url: 'SystemManage/UserRole/UserRoleSet.aspx?id=' + id + '',
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-add',
                    handler: function () {
                        dialog.find('iframe').get(0).contentWindow.f_save_roles(dialog, parent.$);
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
