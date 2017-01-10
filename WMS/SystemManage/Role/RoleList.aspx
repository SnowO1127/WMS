<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleList.aspx.cs" Inherits="WMS.SystemManage.Role.RoleList" %>

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
            grid = $('#role_list_grid').datagrid({
                title: '',
                url: '../../datasorce/sy_role.ashx?action=getListByPage',
                striped: true,
                rownumbers: true,
                pagination: true,
                singleSelect: true,
                idField: 'ID',
                sortName: 'OrderID',
                sortOrder: 'asc',
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
                    width: '80',
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
                    sortable: true,
                    formatter: function (value, row, index) {
                        if (row.AllowDelete) {
                            return "√";
                        } else {
                            return "×";
                        }
                    }
                }, {
                    width: '70',
                    title: '允许编辑',
                    field: 'AllowEdit',
                    align: 'center',
                    halign: 'center',
                    sortable: true,
                    formatter: function (value, row, index) {
                        if (row.AllowEdit) {
                            return "√";
                        } else {
                            return "×";
                        }
                    }
                }, {
                    width: '50',
                    title: '有效',
                    field: 'Enabled',
                    halign: 'center',
                    align: 'center',
                    sortable: true,
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
                    field: 'OrderID'
                }, {
                    width: '220',
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
                            if (row.AllowEdit) {
                                openEdit(row);
                            }
                            else {
                                parent.$.messager.alert('提示', "该角色无法编辑！", "info");
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
                                deleteRole(row);
                            }
                            else {
                                parent.$.messager.alert('提示', "该角色无法删除！", "info");
                            }
                        }
                        else {
                            parent.$.messager.alert('提示', "请选择行", "info");
                        }

                    }
                }],
                //onBeforeLoad: function (param) {
                //    parent.$.messager.progress({
                //        fit: true,
                //        text: '数据加载中....'
                //    });
                //},
                //onLoadSuccess: function () {
                //    parent.$.messager.progress('close');
                //},
                loadFilter: function (data) {
                    if (data.Success) {
                        return data.Obj;
                    }
                    else {
                        //parent.$.messager.progress('close');
                        parent.$.messager.alert('提示', data.Msg, 'error');
                    }
                }
            });
        });

        var openAdd = function () {
            var dialog = parent.sy.modalDialog({
                iconCls: 'icon-add',
                title: '新增角色',
                width: 520,
                height: 280,
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

        var openEdit = function (row) {
            var dialog = parent.sy.modalDialog({
                iconCls: 'icon-edit',
                title: '编辑角色【当前：' + row.Name + '】',
                width: 520,
                height: 280,
                url: 'SystemManage/Role/RoleAdd.aspx?roleid=' + row.ID + '',
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-add',
                    handler: function () {
                        dialog.find('iframe').get(0).contentWindow.f_save(dialog, grid, parent.$);
                    }
                }]
            });
        }

        var openView = function (row) {
            var dialog = parent.sy.modalDialog({
                iconCls: 'icon-save',
                title: '查看角色【当前：' + row.Name + '】',
                width: 520,
                height: 260,
                url: 'SystemManage/Role/RoleAdd.aspx?roleid=' + row.ID + '',
            });
        }

        var deleteRole = function (row) {
            parent.$.messager.confirm('删除角色', '你确定删除角色【' + row.Name + '】吗?', function (r) {
                if (r) {
                    $.ajax({
                        url: "../../datasorce/sy_role.ashx?action=deleterole",
                        dataType: "json",
                        type: "post",
                        data: {
                            roleid: row.ID
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
