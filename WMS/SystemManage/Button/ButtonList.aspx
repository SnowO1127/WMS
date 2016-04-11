<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ButtonList.aspx.cs" Inherits="WMS.SystemManage.Button.ButtonList" %>

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
        var treenode;
        $(function () {
            tree = $("#menu_tree").tree({
                url: '../../datasorce/sy_menu.ashx?action=getenabledheadtree',
                parentField: 'pid',
                lines: true,
                onClick: function (node) {

                    treenode = node;

                    if (treenode.attributes && !treenode.attributes.ismenu) {
                        grid.datagrid("load", { MenuID: treenode.id });  // 在用户点击的时候提示
                        grid.datagrid("unselectAll");
                    }
                }
            })

            grid = $('#button_list_grid').datagrid({
                title: '',
                url: '../../datasorce/sy_button.ashx?action=getbuttonbypage',
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
                    MenuID: !treenode || treenode.attributes.ismenu ? "" : treenode.id
                },
                frozenColumns: [[{
                    width: '90',
                    title: '按钮名称',
                    field: 'Name',
                    halign: 'center',
                    sortable: true
                }, {
                    width: '80',
                    title: '按钮id',
                    field: 'HtmlID',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }]],
                columns: [[{
                    width: '60',
                    title: '公开',
                    field: 'IsPublic',
                    halign: 'center',
                    align: 'center',
                    sortable: true,
                    formatter: function (value, row, index) {
                        if (row.IsPublic) {
                            return "√";
                        } else {
                            return "×";
                        }
                    }
                }, {
                    width: '70',
                    title: '允许编辑',
                    field: 'AllowEdit',
                    halign: 'center',
                    align: 'center',
                    sortable: true,
                    formatter: function (value, row, index) {
                        if (row.AllowEdit) {
                            return "√";
                        } else {
                            return "×";
                        }
                    }
                }, {
                    width: '70',
                    title: '允许删除',
                    field: 'AllowDelete',
                    halign: 'center',
                    align: 'center',
                    sortable: true,
                    formatter: function (value, row, index) {
                        if (row.AllowDelete) {
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
                    field: 'OrderID',
                    halign: 'center',
                    align: 'center'
                }
                , {
                    width: '220',
                    title: '描述',
                    field: 'Description',
                    halign: 'center'
                }]],
                toolbar: [{
                    iconCls: 'icon-add',
                    text: '增加',
                    handler: function () {
                        if (treenode)
                            if (treenode.attributes && !treenode.attributes.ismenu) {
                                openAdd(treenode);
                            }
                            else {
                                parent.$.messager.alert('提示', "菜单节点无法添加按钮！", "info");
                            }
                        else {
                            parent.$.messager.alert('提示', "请选择菜单！", "info");
                        }
                    }
                }, '-', {
                    iconCls: 'icon-save',
                    text: '查看',
                    handler: function () {
                        var row = grid.datagrid('getSelected');
                        if (row) {
                            openView(row, treenode);
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
                            if (row.AllowEdit) {
                                openEdit(row, treenode);
                            }
                            else {
                                parent.$.messager.alert('提示', "该按钮无法编辑！", "info");
                            }
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
                            if (row.AllowDelete) {
                                deleteMenu(row, treenode);
                            }
                            else {
                                parent.$.messager.alert('提示', "该按钮无法删除！", "info");
                            }
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

        var openAdd = function (node) {
            var dialog = parent.sy.modalDialog({
                iconCls: 'icon-add',
                title: '新增按钮【当前所选菜单：' + node.text + '】',
                width: 545,
                height: 310,
                url: 'SystemManage/Button/ButtonAdd.aspx?menuid=' + node.id,
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-add',
                    handler: function () {
                        dialog.find('iframe').get(0).contentWindow.f_save(dialog, grid, parent.$);
                    }
                }]
            });
        };

        var openEdit = function (row, node) {
            var dialog = parent.sy.modalDialog({
                iconCls: 'icon-edit',
                title: '编辑按钮【当前所选菜单：' + node.text + ',当前按钮：' + row.Name + '】',
                width: 545,
                height: 310,
                url: 'SystemManage/Button/ButtonAdd.aspx?buttonid=' + row.ID + '',
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-add',
                    handler: function () {
                        dialog.find('iframe').get(0).contentWindow.f_save(dialog, grid, parent.$);
                    }
                }]
            });
        }

        var openView = function (row, node) {
            var dialog = parent.sy.modalDialog({
                iconCls: 'icon-save',
                title: '查看按钮【当前所选菜单：' + node.text + ',当前按钮：' + row.Name + '】',
                width: 545,
                height: 280,
                url: 'SystemManage/Button/ButtonAdd.aspx?buttonid=' + row.ID + '',
            });
        }

        var deleteMenu = function (row, node) {
            parent.$.messager.confirm('删除按钮', '你确定删除菜单【' + node.text + '】的按钮【' + row.Name + '】吗?', function (r) {
                if (r) {
                    $.ajax({
                        url: "../../datasorce/sy_button.ashx?action=deletebutton",
                        dataType: "json",
                        type: "post",
                        data: {
                            buttonid: row.ID
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
    </script>
</head>
<body>
    <div class="easyui-layout" fit="true">
        <div data-options="region: 'west', border: true" title="菜单树" style="overflow: hidden; padding: 1px; width: 200px">
            <div id="menu_tree" fit="true">
            </div>
        </div>
        <div data-options="region: 'center', border: false" style="overflow: hidden; padding: 1px;">
            <div id="button_list_grid" fit="true">
            </div>
        </div>
    </div>
</body>
</html>
