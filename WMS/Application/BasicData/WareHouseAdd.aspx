<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WareHouseAdd.aspx.cs" Inherits="WMS.Application.BasicData.WareHouseAdd" %>

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
        var warehouseid = "<%=warehouseid %>";

        $(function () {

            $('#ManagerID').combogrid({
                delay: 500,
                mode: 'remote',
                width: 173,
                panelWidth: 330,
                panelHeight: 155,
                idField: 'ID',
                textField: 'RealName',

                url: '../../datasorce/sy_user.ashx?action=getuserlistbyspell',
                striped: true,
                rownumbers: true,
                pagination: true,
                singleSelect: true,
                sortName: 'OrderID',
                sortOrder: 'asc',
                pageSize: 10,
                pageList: [10, 20, 30, 40, 50, 100, 200, 300, 400, 500],
                columns: [[{
                    width: '70',
                    title: '姓名',
                    field: 'RealName',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
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
                }]]
            });


            if (warehouseid) {
                $.ajax({
                    url: "../../datasorce/ap_warehouse.ashx?action=getonewarehouse",
                    dataType: "json",
                    type: "post",
                    data: {
                        warehouseid: warehouseid
                    },
                    success: function (jsonresult) {
                        if (jsonresult.Success) {
                            $("#warehouse_add_form").form('load', jsonresult.Obj);

                            if (jsonresult.Obj.ParentID) {
                                $('#ParentID').combotree('setValue', jsonresult.Obj.ParentID);
                            }
                            else {
                                $('#ParentID').combotree('setValue', "");
                            }
                        }
                        else {
                            $.messager.alert('提示', jsonresult.Msg, 'error');
                        }
                    }
                })
            }
        });

        var f_save = function ($dialog, $grid, $tree, $pjq) {
            if ($('#warehouse_add_form').form('validate')) {
                var url;
                if (warehouseid) {
                    url = "../../datasorce/ap_warehouse.ashx?action=updatewarehouse";
                } else {
                    url = "../../datasorce/ap_warehouse.ashx?action=addwarehouse";
                }

                var data = sy.serializeObject($('#warehouse_add_form'));

                sy.mergeObj(data, {
                    ManagerName: $("#ManagerID").combogrid('grid').datagrid('getSelected').RealName
                });

                $.ajax({
                    url: url,
                    type: "post",
                    dataType: "json",
                    data: data,
                    success: function (jsonresult) {
                        if (jsonresult.Success) {
                            $pjq.messager.alert('提示', jsonresult.Msg, 'info');
                            $grid.datagrid('load');
                            $tree.tree("reload");
                            $dialog.dialog('destroy');
                        } else {
                            $pjq.messager.alert('提示', jsonresult.Msg, 'error');
                        }
                    }
                });
            }
        };
    </script>
</head>
<body>
    <div class="easyui-layout" fit="true">
        <form id="warehouse_add_form" style="font-size: 12px; padding-left: 25px; padding-top: 10px">
            <table>
                <tr>
                    <td style="width: 80px">仓库名称</td>
                    <td>
                        <input name="Name" class="easyui-validatebox" type="text" data-options="required:true" style="width: 170px" />
                        <input name="ID" type="hidden" />
                    </td>
                </tr>
                <tr>
                    <td>编码</td>
                    <td>
                        <input name="Code" class="easyui-validatebox" type="text" style="width: 170px"  data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>负责人
                    </td>
                    <td>
                        <input name="ManagerID" id="ManagerID" type="text" />
                    </td>
                </tr>
                <tr>
                    <td>父节点</td>
                    <td>
                        <input id="ParentID" name="ParentID" class="easyui-combotree" style="width: 173px" data-options="panelHeight:130,editable:false,idField:'id',textField:'text',parentField:'pid',url:'../../datasorce/ap_warehouse.ashx?action=getwarehousetree'" />
                        <img style="cursor: pointer; vertical-align: middle" src="../../library/themes/icons/no.png" onclick="$('#ParentID').combotree('clear')" title="清空" />
                    </td>
                </tr>
                <tr>
                    <td>有效</td>
                    <td>
                        <select id="Enabled" class="easyui-combobox" data-options="panelHeight:50,editable:false" name="Enabled" style="width: 173px">
                            <option value="true">是</option>
                            <option value="false">否</option>
                        </select>
                    </td>

                </tr>
                <tr>
                    <td>排序号</td>
                    <td>
                        <input name="OrderID" class="easyui-validatebox" data-options="required:true,validType:'integer'" style="width: 170px" />
                    </td>
                </tr>
                <tr>
                    <td>描述</td>
                    <td colspan="3">
                        <textarea name="Description" id="Description" style="width: 350px; height: 50px"></textarea>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
