﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleList.aspx.cs" Inherits="WMS.SystemManage.Role.RoleList" %>

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
                sortOrder: 'desc',
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
                    width: '120',
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
                    sortable: true
                }, {
                    width: '70',
                    title: '允许编辑',
                    field: 'AllowEdit',
                    align: 'center',
                    halign: 'center',
                    sortable: true
                }, {
                    width: '50',
                    title: '有效',
                    field: 'Enabled',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '70',
                    title: '排序号',
                    halign: 'center',
                    align: 'center',
                    field: 'OrderID'
                }, {
                    width: '250',
                    title: '描述',
                    halign: 'center',
                    field: 'Description'
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
                        var row = grid.datagrid('getSelected');
                        if (row) {
                            deleteRole(row.ID);
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

        var deleteRole = function (id) {
            parent.$.messager.confirm('删除角色', '你确定删除角色吗?', function (r) {
                if (r) {
                    $.ajax({
                        url: "../../datasorce/sy_role.ashx?action=deleterole",
                        dataType: "json",
                        type: "post",
                        data: {
                            id: id
                        },
                        success: function (jsonresult) {
                            if (jsonresult.Success) {
                                parent.$.messager.alert('提示', jsonresult.Msg, 'info');
                                grid.datagrid('load');
                            } else {
                                parent.$.messager.alert('提示', jsonresult.Msg, 'error');
                            }
                        }
                    })
                }
            });
        }

        var openEdit = function (id) {
            var dialog = parent.sy.modalDialog({
                title: '编辑角色',
                width: 370,
                height: 330,
                url: 'SystemManage/Role/RoleAdd.aspx?id=' + id + '',
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
                title: '查看角色',
                width: 370,
                height: 300,
                url: 'SystemManage/Role/RoleAdd.aspx?id=' + id + '',
            });
        }

        var openAdd = function () {
            var dialog = parent.sy.modalDialog({
                title: '新增角色',
                width: 370,
                height: 330,
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