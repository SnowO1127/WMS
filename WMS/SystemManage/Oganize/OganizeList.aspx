<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OganizeList.aspx.cs" Inherits="WMS.SystemManage.Oganize.OganizeList" %>

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
            tree = $("#oganize_tree").tree({
                url: '../../datasorce/sy_oganize.ashx?action=getheadtree',
                parentField: 'pid',
                lines: true,
                onClick: function (node) { // 在用户点击的时候提示

                    treeid = node.text == "全部" ? "" : node.id;

                    var obj = sy.serializeObject($('#oganize_search_form'));
                    sy.mergeObj(obj, { ID: treeid });

                    grid.datagrid("load", obj);
                    grid.datagrid("unselectAll");
                },
                onLoadSuccess: function (node, data) { // 加载成功
                    if (treeid) {
                        var n = tree.tree("find", treeid);
                        tree.tree("select", n.target);
                    }
                    else {
                        var n = tree.tree("find", data[0].id);
                        tree.tree("select", n.target);
                    }
                }
            })

            grid = $('#oganize_list_grid').datagrid({
                title: '',
                url: '../../datasorce/sy_oganize.ashx?action=getoganizebypage',
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
                    width: '120',
                    title: '组织机构名称',
                    field: 'Name',
                    halign: 'center',
                    sortable: true
                }]],
                columns: [[{
                    width: '100',
                    title: '编码',
                    field: 'Code',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '70',
                    title: '类别',
                    field: 'Category',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '80',
                    title: '主负责人',
                    field: 'ManagerName',
                    halign: 'center',
                    sortable: true
                }, {
                    width: '80',
                    title: '电话',
                    field: 'Tel',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '80',
                    title: '传真',
                    field: 'Fax',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '70',
                    title: '排序号',
                    field: 'OrderID',
                    halign: 'center',
                    align: 'center',
                    sortable: true
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
                    width: '240',
                    title: '备注',
                    field: 'Description',
                    halign: 'center'
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
                            openView(row);
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
                            openEdit(row);
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
                            deleteOganize(row);
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
                title: '新增组织机构',
                width: 530,
                height: 330,
                url: 'SystemManage/Oganize/OganizeAdd.aspx',
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-add',
                    handler: function () {
                        dialog.find('iframe').get(0).contentWindow.f_save(dialog, grid, tree, parent.$);
                    }
                }]
            });
        };

        var openEdit = function (row) {
            var dialog = parent.sy.modalDialog({
                iconCls: 'icon-edit',
                title: '编辑组织机构【当前组织机构：' + row.Name + '】',
                width: 530,
                height: 330,
                url: 'SystemManage/Oganize/OganizeAdd.aspx?oganizeid=' + row.ID + '',
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-add',
                    handler: function () {
                        dialog.find('iframe').get(0).contentWindow.f_save(dialog, grid, tree, parent.$);
                    }
                }]
            });
        }

        var openView = function (row) {
            var dialog = parent.sy.modalDialog({
                iconCls: 'icon-save',
                title: '查看组织机构【当前组织机构：' + row.Name + '】',
                width: 530,
                height: 310,
                url: 'SystemManage/Oganize/OganizeAdd.aspx?oganizeid=' + row.ID + '',
            });
        }

        var deleteOganize = function (row) {
            parent.$.messager.confirm('删除组织机构', '你确定删除组织机构【' + row.Name + '】吗?', function (r) {
                if (r) {
                    $.ajax({
                        url: "../../datasorce/sy_oganize.ashx?action=deleteoganize",
                        dataType: "json",
                        type: "post",
                        data: {
                            oganizeid: row.ID
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

        var oganizeSearch = function () {
            var obj = sy.serializeObject($('#oganize_search_form'));
            sy.mergeObj(obj, { id: treeid });
            grid.datagrid('load', obj);
        }

        var oganizeRefresh = function () {
            var obj = {};
            sy.mergeObj(obj, { id: treeid });
            $('#oganize_search_form input[name=Name]').val('');
            grid.datagrid('load', obj);
        }
    </script>
</head>
<body>
    <div class="easyui-layout" fit="true">
        <div data-options="region: 'west', border: true" title="分类树" style="overflow: hidden; padding: 1px; width: 200px">
            <div id="oganize_tree" fit="true">
            </div>
        </div>
        <div data-options="region: 'center', border: false" style="overflow: hidden; padding: 1px;">
            <div class="easyui-layout" fit="true">
                <div data-options="region: 'north', border: false" style="overflow: hidden; padding: 1px; height: 70px">
                    <fieldset>
                        <legend>查询条件</legend>
                        <form id="oganize_search_form">
                            <table>
                                <tr>
                                    <td>组织机构名称</td>
                                    <td>
                                        <input name="Name" class="easyui-validatebox" type="text" style="width: 110px" />
                                    </td>
                                    <td>
                                        <a id="unit_search_btn" class="easyui-linkbutton" data-options="plain: false, iconCls: 'icon-search'" onclick="oganizeSearch()">查找</a>
                                    </td>
                                    <td>
                                        <a id="unit_refresh_btn" class="easyui-linkbutton" data-options="plain: false, iconCls: 'icon-undo'" onclick="oganizeRefresh()">清空</a>
                                    </td>
                                </tr>
                            </table>
                        </form>
                    </fieldset>
                </div>
                <div data-options="region: 'center', border: false" style="overflow: hidden; padding: 1px;">
                    <div id="oganize_list_grid" fit="true">
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
