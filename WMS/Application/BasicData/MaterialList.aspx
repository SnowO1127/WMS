<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaterialList.aspx.cs" Inherits="WMS.Application.BasicData.MaterialList" %>

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
            grid = $('#material_list_grid').datagrid({
                title: '',
                url: '../../datasorce/ap_material.ashx?action=getmaterialbypage',
                striped: true,
                rownumbers: true,
                pagination: true,
                singleSelect: true,
                sortName: 'OrderID',
                sortOrder: 'asc',
                idField: 'ID',
                pageSize: 10,
                pageList: [10, 20, 30, 40, 50, 100, 200, 300, 400, 500],
                frozenColumns: [[{
                    width: '70',
                    title: '编码',
                    field: 'Code',
                    halign: 'center',
                    sortable: true
                }, {
                    width: '90',
                    title: '名称',
                    field: 'Name',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }]],
                columns: [[{
                    width: '70',
                    title: '物料',
                    halign: 'center',
                    field: 'MaterialCategoryName',
                    align: 'center',
                    sortable: true,
                    formatter: function (value, row, index) {
                        return row.MaterialCategory.Name;
                    }
                }, {
                    width: '80',
                    title: '主计量单位',
                    field: 'MainUnitName',
                    halign: 'center',
                    align: 'center',
                    sortable: true,
                    formatter: function (value, row, index) {
                        return row.UnitConversion.MainUnitName;
                    }
                }, {
                    width: '80',
                    title: '辅计量单位',
                    field: 'AssistUnitName',
                    halign: 'center',
                    align: 'center',
                    sortable: true,
                    formatter: function (value, row, index) {
                        return row.UnitConversion.AssistUnitName;
                    }
                }, {
                    width: '60',
                    title: '转换率',
                    field: 'TranslateRate',
                    halign: 'center',
                    align: 'center',
                    sortable: true,
                    formatter: function (value, row, index) {
                        return row.UnitConversion.TranslateRate;
                    }
                }, {
                    width: '60',
                    title: '助记码',
                    field: 'Mnemonics',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '50',
                    title: '重量',
                    field: 'Weight',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '40',
                    title: '长',
                    field: 'Long',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '40',
                    title: '宽',
                    field: 'Width',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '40',
                    title: '高',
                    field: 'Height',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '50',
                    title: '体积',
                    field: 'Volume',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '70',
                    title: '包装物',
                    field: 'Wrappage',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '70',
                    title: '质保期',
                    field: 'WarrantyDays',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '90',
                    title: '质保期预警',
                    field: 'WarrantyWarnDays',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '95',
                    title: '启用批次管理',
                    field: 'IsBatch',
                    halign: 'center',
                    align: 'center',
                    sortable: true,
                    formatter: function (value, row, index) {
                        if (row.IsBatch) {
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
                            deleteMaterial(row);
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
                    console.info(data);
                    parent.$.messager.progress('close');
                }
            });
        });

        var openAdd = function () {
            var dialog = parent.sy.modalDialog({
                iconCls: 'icon-add',
                title: '新增物料明细',
                width: 560,
                height: 450,
                url: 'Application/BasicData/MaterialAdd.aspx',
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-add',
                    handler: function () {
                        dialog.find('iframe').get(0).contentWindow.f_save(dialog, grid, parent.$);
                    }
                }]
            });
        }

        var openEdit = function (row) {
            var dialog = parent.sy.modalDialog({
                iconCls: 'icon-edit',
                title: '编辑物料明细【当前：' + row.Name + '】',
                width: 560,
                height: 450,
                url: 'Application/BasicData/MaterialAdd.aspx?materialid=' + row.ID,
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
                title: '查看物料明细【当前：' + row.Name + '】',
                width: 560,
                height: 430,
                url: 'Application/BasicData/MaterialAdd.aspx?materialid=' + row.ID
            });
        }

        var deleteMaterial = function (row) {
            parent.$.messager.confirm('删除物料', '你确定删除物料【' + row.Name + '】吗?', function (r) {
                if (r) {
                    $.ajax({
                        url: "../../datasorce/ap_material.ashx?action=deletematerial",
                        dataType: "json",
                        type: "post",
                        data: {
                            materialid: row.ID
                        },
                        success: function (jsonresult) {
                            if (jsonresult.Success) {
                                parent.$.messager.alert('提示', jsonresult.Msg, 'info');
                                grid.datagrid("load");
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
            <div id="material_list_grid" fit="true">
            </div>
        </div>
    </div>
</body>
</html>
