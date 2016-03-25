<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuList.aspx.cs" Inherits="WMS.SystemManage.Menu.MenuList" %>

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
    <link href="../../library/syExtCss.css" rel="stylesheet" />
    <link href="../../library/syExtIcon.css" rel="stylesheet" />
    <script>

        var treeid;
        $(function () {
            tree = $("#menu_tree").tree({
                url: '../../datasorce/sy_menu.ashx?action=getmenutree',
                parentField: 'pid',
                lines: true,
                onClick: function (node) {
                    treeid = node.id;
                    var obj = sy.serializeObject($('#menu_search_form'));
                    sy.mergeObj(obj, { id: treeid });
                    grid.datagrid("load", obj);  // 在用户点击的时候提示
                    grid.datagrid("unselectAll");
                },
                onLoadSuccess: function (node, data) {
                    $.each(data, function (i) {
                        if (data[i].pid == null) {
                            var n = tree.tree("find", data[i].id);
                            tree.tree("select", n.target);
                            treeid = data[i].id;
                        }
                    });
                }
            })

            grid = $('#menu_list_grid').datagrid({
                title: '',
                url: '../../datasorce/sy_menu.ashx?action=getmenubypage',
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
                    width: '150',
                    title: '菜单名',
                    field: 'MenuName',
                    halign: 'center',
                    sortable: true
                }, {
                    width: '70',
                    title: '类别',
                    field: 'Category',
                    halign: 'center',
                    align: 'center',
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
                    field: 'OrderID',
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
                width: 545,
                height: 370,
                url: 'SystemManage/Menu/MenuAdd.aspx?id=' + id + '',
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
                title: '查看菜单',
                width: 545,
                height: 370,
                url: 'SystemManage/Menu/MenuAdd.aspx?id=' + id + '',
            });
        }

        var openAdd = function () {
            var dialog = parent.sy.modalDialog({
                title: '新增菜单',
                width: 545,
                height: 370,
                url: 'MenuAdd.aspx',
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
        <div data-options="region: 'west', border: true" title="分类树" style="overflow: hidden; padding: 1px; width: 200px">
            <div id="menu_tree" fit="true">
            </div>
        </div>
        <div data-options="region: 'center', border: false" style="overflow: hidden; padding: 1px;">
            <div class="easyui-layout" fit="true">
                <div data-options="region: 'north', border: false" style="overflow: hidden; padding: 1px; height: 70px">
                    <fieldset>
                        <legend>查询条件</legend>
                        <form id="menu_search_form">
                            <table>
                                <tr>
                                    <td>菜单名称</td>
                                    <td>
                                        <input name="MenuName" class="easyui-validatebox" type="text" />
                                    </td>
                                    <td>
                                        <a id="unit_search_btn" class="easyui-linkbutton" data-options="plain: false, iconCls: 'icon-search'" onclick="unitSearch()">查找</a>
                                    </td>
                                    <td>
                                        <a id="unit_refresh_btn" class="easyui-linkbutton" data-options="plain: false, iconCls: 'icon-undo'" onclick="unitRefresh()">清空</a>
                                    </td>
                                </tr>
                            </table>
                        </form>
                    </fieldset>
                </div>
                <div data-options="region: 'center', border: false" style="overflow: hidden; padding: 1px;">
                    <div id="menu_list_grid" fit="true">
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
