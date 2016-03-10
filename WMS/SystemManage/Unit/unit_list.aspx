<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="unit_list.aspx.cs" Inherits="WMS.SystemManage.Unit.unit_list" %>

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
    <title></title>
    <script>

        var treeid;
        $(function () {
            tree = $("#unit_tree").tree({
                url: '../../datasorce/sy_unit.ashx?action=getunittree',
                parentField: 'pid',
                lines: true,
                onClick: function (node) {
                    treeid = node.id;
                    var obj = sy.serializeObject($('#unit_search_form'));
                    sy.mergeObj(obj, { id: treeid });
                    grid.datagrid("load", obj);  // 在用户点击的时候提示
                    grid.datagrid("unselectAll");
                },
                onLoadSuccess: function (node, data) {
                    $.each(data, function (i) {
                        if (data[i].pid == "") {
                            var n = tree.tree("find", data[i].id);
                            tree.tree("select", n.target);
                            treeid = data[i].id;
                        }
                    });

                    grid = $('#user_list_grid').datagrid({
                        title: '',
                        url: '../../datasorce/sy_unit.ashx?action=getunit',
                        idField: 'id',
                        //treeField: 'name',
                        //parentField: 'pid',
                        rownumbers: true,
                        pagination: true,
                        sortName: 'unitorder',
                        view: myview,
                        singleSelect: true,
                        emptyMsg: '无数据',
                        sortOrder: 'asc',
                        //striped: true,
                        pageSize: 10,
                        pageList: [10, 20, 30, 40, 50, 100, 200, 300, 400, 500],
                        queryParams: {
                            id: treeid
                        },
                        frozenColumns: [[{
                            field: 'id',
                            title: '编号',
                            width: 150,
                            checkbox: true
                        }, {
                            width: '200',
                            title: '单位名称',
                            field: 'name',
                            sortable: true
                        }]],
                        columns: [[{
                            width: '200',
                            title: '地址',
                            field: 'address',
                            sortable: true
                        }, {
                            width: '100',
                            title: '邮编',
                            field: 'zipcode',
                            sortable: true
                        }, {
                            width: '100',
                            title: '联系人',
                            field: 'contactor',
                            sortable: true
                        }, {
                            width: '100',
                            title: '联系人电话',
                            field: 'contactorphone',
                            sortable: true
                        }, {
                            width: '100',
                            title: '传真',
                            field: 'fax',
                            sortable: true
                        }, {
                            width: '100',
                            title: '法人',
                            field: 'contactor',
                            sortable: true
                        }, {
                            width: '100',
                            title: '是否独立法人',
                            field: 'isincorporation',
                            sortable: true,
                            formatter: function (value, row) {
                                if (value == true) {
                                    return '是';
                                }
                                else if (value == false) {
                                    return '否';
                                }
                            }
                        }, {
                            width: '60',
                            title: '排序',
                            field: 'unitorder',
                            sortable: true
                        }]],
                        toolbar: [{
                            iconCls: 'icon-add',
                            text: '增加',
                            handler: function () {
                                var selectTree = tree.tree("getSelected");
                                if (selectTree) {
                                    openAdd(selectTree.id);
                                }
                                else {
                                    openAdd("");
                                }
                            }
                        }, '-', {
                            iconCls: 'icon-save',
                            text: '查看',
                            handler: function () {
                                var row = grid.datagrid('getSelected');
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
                                var row = grid.datagrid('getSelected');
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
                        onBeforeLoad: function (row, param) {
                            parent.$.messager.progress({
                                text: '数据加载中....'
                            });
                        },
                        onLoadSuccess: function (row, data) {
                            parent.$.messager.progress('close');
                            grid.datagrid("tooltip");
                        }
                    });
                }
            });
        });

        var openEdit = function (id) {
            var dialog = parent.sy.modalDialog({
                title: '编辑单位',
                width: 620,
                height: 300,
                url: 'SystemManage/Unit/unit_add.aspx?id=' + id + '',
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-add',
                    handler: function () {
                        dialog.find('iframe').get(0).contentWindow.f_save(treeid, tree, dialog, grid, parent.$);
                    }
                }]
            });
        }

        var openView = function (id) {
            var dialog = parent.sy.modalDialog({
                title: '查看单位',
                width: 620,
                height: 300,
                url: 'SystemManage/Unit/unit_add.aspx?id=' + id + '',
            });
        }

        var openAdd = function (treeid) {
            var url;
            if (treeid) {
                url = 'SystemManage/Unit/unit_add.aspx?treeid=' + treeid + ''
            }
            else {
                url = 'SystemManage/Unit/unit_add.aspx';
            }
            var dialog = parent.sy.modalDialog({
                title: '新增单位',
                width: 620,
                height: 300,
                url: url,
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-add',
                    handler: function () {
                        dialog.find('iframe').get(0).contentWindow.f_save(treeid, tree, dialog, grid, parent.$);
                    }
                }]
            });
        };

        var f_reload = function () {
            grid.datagrid('load');
            grid.datagrid("unselectAll");
        }

        var unitSearch = function () {
            var obj = sy.serializeObject($('#unit_search_form'));
            sy.mergeObj(obj, { id: treeid });
            grid.datagrid('load', obj);
        }

        var unitRefresh = function () {
            var obj = {};
            sy.mergeObj(obj, { id: treeid });
            $('#unit_search_form input[name=name]').val('');
            grid.datagrid('load', obj);
            grid.datagrid("unselectAll");
        }
    </script>
</head>
<body>
    <div class="easyui-layout" fit="true">
        <div data-options="region: 'west', border: true" title="分类树" style="overflow: hidden; padding: 1px; width: 200px">
            <div id="unit_tree" fit="true">
            </div>
        </div>
        <div data-options="region: 'center', border: false" style="overflow: hidden; padding: 1px;">
            <div class="easyui-layout" fit="true">
                <div data-options="region: 'north', border: false" style="overflow: hidden; padding: 1px; height: 70px">
                    <fieldset>
                        <legend>查询条件</legend>
                        <form id="unit_search_form">
                            <table>
                                <tr>
                                    <td>单位名称</td>
                                    <td>
                                        <input name="name" class="easyui-validatebox" type="text" />
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
                    <div id="user_list_grid" fit="true">
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
