<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DictItemAdd.aspx.cs" Inherits="WMS.SystemManage.Dict.DictItemAdd" %>

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
        var id = "<%=id %>";

        $(function () {

            $('#Category').combobox({
                url: '../../datasorce/sy_itemdetail.ashx?action=getcombox&code=DictCategory',
                valueField: 'Value',
                textField: 'Name',
                width: 173,
                panelHeight: 100,
                editable: false,
                required: true
            });

            if (id) {
                $.ajax({
                    url: "../../datasorce/sy_item.ashx?action=getoneitem",
                    dataType: "json",
                    type: "post",
                    data: {
                        id: id
                    },
                    success: function (jsonresult) {
                        $("#item_add_form").form('load', jsonresult);
                        if (jsonresult.ParentID) {
                            $('#ParentID').combotree('setValue', jsonresult.ParentID);
                        }
                        else {
                            $('#ParentID').combotree('setValue', "");
                        }
                    }
                })
            }
        });

        var f_save = function ($dialog, $grid, $tree, $pjq) {
            if ($('#item_add_form').form('validate')) {
                var url;
                if (id) {
                    url = "../../datasorce/sy_item.ashx?action=updateitem";
                } else {
                    url = "../../datasorce/sy_item.ashx?action=additem";
                }
                $.ajax({
                    url: url,
                    type: "post",
                    dataType: "json",
                    data: $('#item_add_form').serializeArray(),
                    success: function (jsonresult) {
                        if (jsonresult.Success) {
                            $pjq.messager.alert('提示', jsonresult.Msg, 'info');
                            $grid.datagrid('load');
                            $tree.tree('reload');
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
        <form id="item_add_form" style="font-size: 12px; padding-left: 25px; padding-top: 10px">
            <table>
                <tr>
                    <td style="width: 60px">名称</td>
                    <td colspan="3">
                        <input name="Name" class="easyui-validatebox" type="text" data-options="required:true" style="width: 170px" />
                        <input name="ID" type="hidden" />
                    </td>
                </tr>
                <tr>
                    <td>分类</td>
                    <td>
                        <input name="Category" id="Category" type="text" />
                    </td>
                </tr>
                <tr>
                    <td>编号</td>
                    <td colspan="3">
                        <input name="Code" class="easyui-validatebox" data-options="required:true" type="text" style="width: 170px" />
                    </td>
                </tr>
                <tr>
                    <td>上级</td>
                    <td colspan="3">
                        <input id="ParentID" name="ParentID" class="easyui-combotree" style="width: 173px" data-options="panelHeight:130,editable:false,idField:'id',textField:'text',parentField:'pid',url:'../../datasorce/sy_item.ashx?action=getistree'" />
                        <img style="cursor: pointer; vertical-align: middle" src="../../library/themes/icons/no.png" onclick="$('#ParentID').combotree('clear')" title="清空" />
                    </td>
                </tr>
                <tr>
                    <td>是否树形</td>
                    <td>
                        <select id="IsTree" class="easyui-combobox" data-options="panelHeight:50,editable:false" name="IsTree" style="width: 170px">
                            <option value="true">是</option>
                            <option value="false">否</option>
                        </select>
                    </td>
                    <td>有效</td>
                    <td>
                        <select id="Enabled" class="easyui-combobox" data-options="panelHeight:50,editable:false" name="Enabled" style="width: 170px">
                            <option value="true">是</option>
                            <option value="false">否</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>允许编辑</td>
                    <td>
                        <select id="AllowEdit" class="easyui-combobox" data-options="panelHeight:50,editable:false" name="AllowEdit" style="width: 170px">
                            <option value="true">是</option>
                            <option value="false">否</option>
                        </select>
                    </td>
                    <td>允许删除</td>
                    <td>
                        <select id="AllowDelete" class="easyui-combobox" data-options="panelHeight:50,editable:false" name="AllowDelete" style="width: 170px">
                            <option value="true">是</option>
                            <option value="false">否</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>排序号</td>
                    <td colspan="3">
                        <input name="OrderID" class="easyui-validatebox" data-options="required:true,validType:'integer'" type="text" style="width: 170px" />
                    </td>
                </tr>
                <tr>
                    <td>描述</td>
                    <td colspan="3">
                        <textarea name="Description" id="Description" style="width: 395px; height: 50px"></textarea>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
