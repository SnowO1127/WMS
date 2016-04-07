<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientList.aspx.cs" Inherits="WMS.Application.BasicData.ClientList" %>

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
        $(function () {
            grid = $('#client_list_grid').datagrid({
                title: '',
                url: '../../datasorce/ap_client.ashx?action=getclientbypage',
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
                    width: '90',
                    title: '客户名称',
                    field: 'Name',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }]],
                columns: [[{
                    width: '60',
                    title: '联系人',
                    field: 'LinkMan',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '70',
                    title: '手机',
                    field: 'Phone',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '60',
                    title: '电话',
                    field: 'Tel',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '120',
                    title: '传真',
                    field: 'Fax',
                    halign: 'center',
                    sortable: true
                }, {
                    width: '90',
                    title: '邮编',
                    field: 'PostCode',
                    halign: 'center',
                    sortable: true
                }, {
                    width: '90',
                    title: '经度',
                    field: 'Longitude',
                    halign: 'center',
                    sortable: true
                }, {
                    width: '90',
                    title: '纬度',
                    field: 'Latitude',
                    halign: 'center',
                    sortable: true
                }, {
                    width: '220',
                    title: '地址',
                    halign: 'center',
                    field: 'Address'
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
                    field: 'OrderID'
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
                            deleteclient(row);
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
                title: '新增客户',
                width: 560,
                height: 350,
                url: 'Application/BasicData/ClientAdd.aspx',
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
                title: '编辑客户【当前：' + row.Name + '】',
                width: 560,
                height: 350,
                url: 'Application/BasicData/ClientAdd.aspx?clientid=' + row.ID + '',
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
                title: '查看客户【当前：' + row.Name + '】',
                width: 560,
                height: 330,
                url: 'Application/BasicData/ClientAdd.aspx?clientid=' + row.ID + '',
            });
        }

        var deleteclient = function (row) {
            parent.$.messager.confirm('删除客户', '你确定删除客户【' + row.Name + '】吗?', function (r) {
                if (r) {
                    $.ajax({
                        url: "../../datasorce/ap_client.ashx?action=deleteclient",
                        dataType: "json",
                        type: "post",
                        data: {
                            clientid: row.ID
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
    </script>
</head>
<body>
    <div class="easyui-layout" fit="true">
        <div data-options="region: 'center', border: false" style="overflow: hidden; padding: 1px;">
            <div id="client_list_grid" fit="true">
            </div>
        </div>
    </div>
</body>
</html>
