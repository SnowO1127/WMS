<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_list.aspx.cs" Inherits="WMS.SystemManage.User.user_list" %>

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
                idField: 'id',
                sortName: 'UserID',
                sortOrder: 'desc',
                pageSize: 10,
                pageList: [10, 20, 30, 40, 50, 100, 200, 300, 400, 500],
                frozenColumns: [[{
                    width: '100',
                    title: '登录名',
                    field: 'LoginName',
                    sortable: true
                }, {
                    width: '80',
                    title: '姓名',
                    field: 'UserName',
                    sortable: true
                }]],
                columns: [[{
                    width: '150',
                    title: '创建时间',
                    field: 'UserID',
                    sortable: true
                }, {
                    width: '150',
                    title: '修改时间',
                    field: 'PassWord',
                    sortable: true
                }, {
                    width: '50',
                    title: '性别',
                    field: 'UserName',
                    sortable: true
                }, {
                    width: '50',
                    title: '年龄',
                    field: 'UserName',
                    sortable: true
                }, {
                    width: '250',
                    title: '照片',
                    field: 'UserName'
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
                title: '编辑用户',
                width: 620,
                height: 300,
                url: 'SystemManage/User/user_add.aspx?id=' + id + '',
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
                title: '查看用户',
                width: 620,
                height: 300,
                url: 'SystemManage/User/user_add.aspx?id=' + id + '',
            });
        }


        //保存按钮
        var openAdd = function () {
            var dialog = parent.sy.modalDialog({
                title: '新增用户',
                width: 620,
                height: 300,
                url: 'SystemManage/User/user_add.aspx',
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
            <div id="user_list_grid" fit="true">
            </div>
        </div>
    </div>
</body>
</html>
