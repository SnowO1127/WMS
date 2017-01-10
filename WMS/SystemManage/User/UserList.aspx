<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="WMS.SystemManage.User.UserList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../library/jquery.min.js"></script>
    <script src="../../library/jquery.easyui.min.js"></script>
    <script src="../../library/easyui-lang-zh_CN.js"></script>
    <script src="../../library/jquery.cookie.js"></script>
    <script src="../../library/xyEasyUI.js"></script>
    <script src="../../library/xyUtils.js"></script>
    <link id="easyuiTheme" href="../../library/themes/bootstrap/easyui.css" rel="stylesheet" />
    <link href="../../library/themes/icon.css" rel="stylesheet" />
    <link href="../../library/base_css/ui.css" rel="stylesheet" />
    <link href="../../library/syExtCss.css" rel="stylesheet" />
    <link href="../../library/syExtIcon.css" rel="stylesheet" />
    <title></title>
    <script>
        $(function () {
            grid = $('#user_list_grid').datagrid({
                title: '',
                url: '../../datasorce/sy_user.ashx?action=getuserlist',
                striped: true,
                rownumbers: true,
                pagination: true,
                singleSelect: true,
                autocolwidth: true,
                filterDelay: 400,
                filterRules: [],
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
                    width: '70',
                    title: '管理员',
                    field: 'IsAdmin',
                    halign: 'center',
                    align: 'center',
                    formatter: function (value, row, index) {
                        if (row.IsAdmin) {
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
                    halign: 'center',
                    align: 'center',
                    field: 'OrderID',
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
                            if (!row.IsAdmin) {
                                openEdit(row);
                            }
                            else {
                                parent.$.messager.alert('提示', "管理员无法编辑！", "info");
                            }
                        }
                        else {
                            parent.$.messager.alert('提示', "请选择行", "info");
                        }

                    }
                }, '-', {
                    iconCls: 'icon-edit',
                    text: '重置密码',
                    handler: function () {
                        var row = grid.datagrid('getSelected');

                        if (row) {
                            if (!row.IsAdmin) {
                                resetPassWord(row);
                            }
                            else {
                                parent.$.messager.alert('提示', "管理员无法重置密码！", "info");
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
                            if (!row.IsAdmin) {
                                deleteUser(row);
                            }
                            else {
                                parent.$.messager.alert('提示', "管理员无法删除！", "info");
                            }
                        }
                        else {
                            parent.$.messager.alert('提示', "请选择行", "info");
                        }

                    }
                }, '-', {
                    iconCls: 'ext-icon-cog',
                    text: '用户角色设置',
                    handler: function () {
                        var row = grid.datagrid('getSelected');

                        if (row) {
                            if (!row.IsAdmin) {
                                openAddRole(row);
                            }
                            else {
                                parent.$.messager.alert('提示', "管理员无法设置角色！", "info");
                            }
                        }
                        else {
                            parent.$.messager.alert('提示', "请选择行", "info");
                        }

                    }
                }],
                loadFilter: function (data) {
                    if (data.Success) {
                        return data.Obj;
                    } else {
                        parent.$.messager.alert('提示', data.Msg, 'error');
                    }
                }
            });
        });

        var openAdd = function () {
            var dialog = parent.sy.modalDialog({
                iconCls: 'icon-add',
                title: '新增用户',
                width: 520,
                height: 460,
                maximizable: true,
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

        var openEdit = function (row) {
            var dialog = parent.sy.modalDialog({
                iconCls: 'icon-edit',
                title: '编辑用户【当前：' + row.RealName + '】',
                width: 520,
                height: 460,
                url: 'SystemManage/User/UserAdd.aspx?userid=' + row.ID + '',
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-add',
                    handler: function () {
                        dialog.find('iframe').get(0).contentWindow.f_save(dialog, grid, parent.$);
                    }
                }]
            });
        }

        var resetPassWord = function (row) {
            parent.$.messager.confirm('重置密码', '你确定重置用户【' + row.RealName + '】的密码吗?', function (r) {
                if (r) {
                    $.ajax({
                        url: "../../datasorce/sy_user.ashx?action=resetpassword",
                        dataType: "json",
                        type: "post",
                        data: {
                            userid: row.ID
                        },
                        success: function (jsonresult) {
                            if (jsonresult.Success) {
                                parent.$.messager.alert('提示', jsonresult.Msg, 'info');
                            } else {
                                parent.$.messager.alert('提示', jsonresult.Msg, 'error');
                            }
                        }
                    })
                }
            });
        }

        var openView = function (row) {
            var dialog = parent.sy.modalDialog({
                iconCls: 'icon-save',
                title: '查看用户【当前：' + row.RealName + '】',
                width: 520,
                height: 440,
                url: 'SystemManage/User/UserAdd.aspx?userid=' + row.ID + '',
            });
        }

        var deleteUser = function (row) {
            parent.$.messager.confirm('删除用户', '你确定删除用户【' + row.RealName + '】吗?', function (r) {
                if (r) {
                    $.ajax({
                        url: "../../datasorce/sy_user.ashx?action=deleteuser",
                        dataType: "json",
                        type: "post",
                        data: {
                            userid: row.ID
                        },
                        success: function (jsonresult) {
                            if (jsonresult.Success) {
                                parent.$.messager.alert('提示', jsonresult.Msg, 'info');
                                grid.datagrid('load');
                                grid.datagrid("unselectAll");
                            } else {
                                parent.$.messager.alert('提示', jsonresult.Msg, 'error');
                            }
                        }
                    })
                }
            });
        }

        var openAddRole = function (row) {
            var dialog = parent.sy.modalDialog({
                iconCls: 'ext-icon-cog',
                title: '角色设置【当前：' + row.RealName + '】',
                width: 600,
                height: 450,
                url: 'SystemManage/UserRole/UserRoleSet.aspx?userid=' + row.ID + '',
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
