<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dept_list.aspx.cs" Inherits="WMS.SystemManage.Department.dept_list" %>

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
    <script>
        $(function () {
            $("#dept_unit_tree").tree({
                url: '../../datasorce/sy_unit.ashx?action=getunitdepttree',
                parentField: 'pid',
                lines: true,
                onClick: function (node) {
                    grid.datagrid("load", {
                        id: node.id,
                        type: node.attributes.type
                    });  // 在用户点击的时候提示
                }
            });

            grid = $('#dept_list_grid').datagrid({
                title: '',
                url: '../../datasorce/sy_dept.ashx?action=getdept',
                idField: 'id',
                //treeField: 'name',
                //parentField: 'pid',
                rownumbers: true,
                pagination: true,
                sortName: 'name',
                sortOrder: 'asc',
                view: myview,
                emptyMsg: '无数据',
                pageSize: 10,
                pageList: [10, 20, 30, 40, 50, 100, 200, 300, 400, 500],
                frozenColumns: [[{
                    field: 'id',
                    title: '编号',
                    width: 150,
                    checkbox: true
                }, {
                    width: '200',
                    title: '部门名称',
                    field: 'name',
                    sortable: true
                }]],
                columns: [[{
                    width: '100',
                    title: '电话',
                    field: 'rphone',
                    sortable: true
                }, {
                    width: '100',
                    title: '传真',
                    field: 'fax',
                    sortable: true
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
                        var row = grid.treegrid('getSelected');
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
                        var row = grid.treegrid('getSelected');
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
                }
            });
        });
    </script>

</head>
<body>
    <div class="easyui-layout" fit="true">
        <div data-options="region: 'west', border: true" title="分类树" style="overflow: hidden; padding: 1px; width: 200px">
            <div id="dept_unit_tree" fit="true">
            </div>
        </div>
        <div data-options="region: 'center', border: true" style="overflow: hidden; padding: 1px;">
            <div id="dept_list_grid" fit="true">
            </div>
        </div>
    </div>
</body>
</html>
