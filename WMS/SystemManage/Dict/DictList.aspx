﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DictList.aspx.cs" Inherits="WMS.SystemManage.Dict.DictList" %>

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
        var treeid;
        $(function () {
            tree = $("#dict_items_tree").tree({
                url: '../../datasorce/sy_item.ashx?action=getitemtree',
                parentField: 'pid',
                lines: true,
                onClick: function (node) {
                    treeid = node.id;
                    if (node.pid) {
                        //var obj = sy.serializeObject($('#menu_search_form'));
                        //sy.mergeObj(obj, { id: treeid });
                        grid.datagrid("load", { ItemId: treeid });  // 在用户点击的时候提示
                        grid.datagrid("unselectAll");
                    }
                },
                onLoadSuccess: function (node, data) {
                    $.each(data, function (i) {
                        if (data[i].pid) {
                            var n = tree.tree("find", data[i].id);
                            tree.tree("select", n.target);
                            treeid = data[i].id;
                        }
                    });
                }
            })

            grid = $('#dict_detaillist_grid').datagrid({
                title: '',
                url: '../../datasorce/sy_itemdetail.ashx?action=getitemdetailbypage',
                striped: true,
                rownumbers: true,
                pagination: true,
                singleSelect: true,
                sortName: 'OrderID',
                sortOrder: 'asc',
                idField: 'ID',
                pageSize: 10,
                pageList: [10, 20, 30, 40, 50, 100, 200, 300, 400, 500],
                queryParams: {
                    ID: treeid
                },
                frozenColumns: [[{
                    width: '90',
                    title: '名称',
                    field: 'Name',
                    halign: 'center',
                    sortable: true
                }, {
                    width: '90',
                    title: '值',
                    field: 'Value',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }]],
                columns: [[{
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
                    field: 'OrderID',
                    halign: 'center',
                    align: 'center'
                }
                , {
                    width: '220',
                    title: '备注',
                    field: 'Description',
                    halign: 'center'
                }]],
                toolbar: [{
                    iconCls: 'icon-add',
                    text: '增加',
                    handler: function () {
                        openItemDetailAdd();
                    }
                }, '-', {
                    iconCls: 'icon-save',
                    text: '查看',
                    handler: function () {
                        var row = grid.datagrid('getSelected');
                        if (row) {
                            openItemDetailView(row.ID);
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
                            openItemDetailEdit(row.ID);
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
        })

        var openItemDetailAdd = function () {
            var dialog = parent.sy.modalDialog({
                title: '新增选项明细',
                width: 545,
                height: 320,
                url: 'SystemManage/Dict/DictItemDetailAdd.aspx?itemid=' + treeid,
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-add',
                    handler: function () {
                        dialog.find('iframe').get(0).contentWindow.f_save(dialog, grid, parent.$);
                    }
                }]
            });
        }

        var openItemDetailEdit = function (id) {
            var dialog = parent.sy.modalDialog({
                title: '编辑选项明细',
                width: 545,
                height: 320,
                url: 'SystemManage/Dict/DictItemDetailAdd.aspx?id=' + id,
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-add',
                    handler: function () {
                        dialog.find('iframe').get(0).contentWindow.f_save(dialog, grid, parent.$);
                    }
                }]
            });
        }

        var openItemDetailView = function (id) {
            var dialog = parent.sy.modalDialog({
                title: '查看选项明细',
                width: 545,
                height: 300,
                url: 'SystemManage/Dict/DictItemDetailAdd.aspx?id=' + id
            });
        }

        var openItemAdd = function () {
            var dialog = parent.sy.modalDialog({
                title: '新增字典类别',
                width: 545,
                height: 370,
                url: 'SystemManage/Dict/DictItemAdd.aspx',
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-add',
                    handler: function () {
                        dialog.find('iframe').get(0).contentWindow.f_save(dialog, grid, parent.$);
                    }
                }]
            });
        }

        var openItemEdit = function () {
            var dialog = parent.sy.modalDialog({
                title: '编辑字典类别',
                width: 545,
                height: 370,
                url: 'SystemManage/Dict/DictItemAdd.aspx?itemid=' + treeid,
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-add',
                    handler: function () {
                        dialog.find('iframe').get(0).contentWindow.f_save(dialog, grid, parent.$);
                    }
                }]
            });
        }

        var openItemDelete = function () {

        }
    </script>
</head>
<body>
    <div class="easyui-layout" fit="true">
        <div data-options="region: 'west', border: true,title:'字典分类'" style="overflow: hidden; padding: 1px; width: 200px">
            <div class="easyui-panel" data-options="border:false">
                <a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-add'" onclick="openItemAdd()">添加</a>
                <a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-edit'" onclick="openItemEdit()">编辑</a>
                <a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-cut'" onclick="openItemDelete()">删除</a>
            </div>
            <div id="dict_items_tree" fit="true">
            </div>
        </div>
        <div data-options="region: 'center', border: false" style="overflow: hidden; padding: 1px;">
            <div id="dict_detaillist_grid" fit="true">
            </div>
        </div>
    </div>
</body>
</html>
