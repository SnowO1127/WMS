﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu_list.aspx.cs" Inherits="WMS.SystemManage.Menu.menu_list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../../library/jquery-1.9.1.min.js"></script>
    <script src="../../library/jquery.easyui.min.js"></script>
    <script src="../../library/easyui-lang-zh_CN.js"></script>
    <script src="../../library/jquery.cookie.js"></script>
    <script src="../../library/xyEasyUI.js"></script>
    <script src="../../library/xyUtils.js"></script>
    <link id="easyuiTheme" href="../../library/themes/default/easyui.css" rel="stylesheet" />
    <link href="../../library/themes/icon.css" rel="stylesheet" />
    <link href="../../library/base_css/ui.css" rel="stylesheet" />
    <script>
        $(function () {
            treegrid = $('#menu_list_treegrid').treegrid({
                title: '',
                url: '../../datasorce/sy_menu.ashx?action=getmenu',
                striped: true,
                rownumbers: true,
                pagination: true,
                singleSelect: true,
                sortName: 'Order',
                sortOrder: 'asc',
                idField: 'ID',
                treeField: 'MenuName',
                pageSize: 10,
                pageList: [10, 20, 30, 40, 50, 100, 200, 300, 400, 500],
                frozenColumns: [[{
                    width: '150',
                    title: '菜单名',
                    field: 'MenuName',
                    halign:'center',
                    sortable: true
                }, {
                    width: '70',
                    title: '类别',
                    field: 'Category',
                    halign: 'center',
                    sortable: true
                }]],
                columns: [[{
                    width: '260',
                    title: '地址',
                    field: 'Url',
                    halign: 'center',
                    sortable: true
                }, {
                    width: '60',
                    title: '公开',
                    field: 'IsPublic',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '70',
                    title: '允许编辑',
                    field: 'AllowEdit',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '70',
                    title: '允许删除',
                    field: 'AllowDelete',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '60',
                    title: '有效',
                    field: 'Enabled',
                    halign: 'center',
                    align: 'center'
                }, {
                    width: '70',
                    title: '排序号',
                    field: 'Order',
                    halign: 'center',
                    align: 'center'
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
                        var row = treegrid.treegrid('getSelected');
                        if (row) {
                            openView(row.id);
                        }
                        else {
                            parent.$.messager.alert('提示', "请选择行", "info");
                        }
                    }
                }, '-', {
                    iconCls: 'icon-edit',
                    text: '编辑',
                    handler: function () {
                        var row = treegrid.treegrid('getSelected');
                        if (row) {
                            openEdit(row.id);
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

        var openEdit = function (id) {
            var dialog = parent.sy.modalDialog({
                title: '编辑菜单',
                width: 620,
                height: 300,
                url: 'menu_add.aspx?id=' + id + '',
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-add',
                    handler: function () {
                        dialog.find('iframe').get(0).contentWindow.f_save(dialog, treegrid, parent.$);
                    }
                }]
            });
        }

        var openView = function (id) {
            var dialog = parent.sy.modalDialog({
                title: '查看菜单',
                width: 620,
                height: 300,
                url: 'menu_add.aspx?id=' + id + '',
            });
        }


        var openAdd = function () {
            var dialog = parent.sy.modalDialog({
                title: '新增菜单',
                width: 620,
                height: 300,
                url: 'menu_add.aspx',
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-add',
                    handler: function () {
                        dialog.find('iframe').get(0).contentWindow.f_save(dialog, treegrid, parent.$);
                    }
                }]
            });
        };
    </script>
</head>
<body>
    <div class="easyui-layout" fit="true">
        <div data-options="region: 'center', border: false" style="overflow: hidden; padding: 1px;">
            <div id="menu_list_treegrid" fit="true">
            </div>
        </div>
    </div>
</body>
</html>
