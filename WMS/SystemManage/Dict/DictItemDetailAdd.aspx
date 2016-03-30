<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DictItemDetailAdd.aspx.cs" Inherits="WMS.SystemManage.Dict.DictItemDetailAdd" %>

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
        var itemid = "<%=itemid %>";

        $(function () {

            if (itemid) {
                $("#ItemID").val(itemid);
            }

            if (id) {
                $.ajax({
                    url: "../../datasorce/sy_itemdetail.ashx?action=getoneitemdetail",
                    dataType: "json",
                    type: "post",
                    data: {
                        id: id
                    },
                    success: function (jsonresult) {
                        $("#itemdetail_add_form").form('load', jsonresult);
                    }
                })
            }
        });

        var f_save = function ($dialog, $grid, $pjq) {
            if ($('#itemdetail_add_form').form('validate')) {
                var url;
                if (id) {
                    url = "../../datasorce/sy_itemdetail.ashx?action=updateitemdetail";
                } else {
                    url = "../../datasorce/sy_itemdetail.ashx?action=additemdetail";
                }
                $.ajax({
                    url: url,
                    type: "post",
                    dataType: "json",
                    data: $('#itemdetail_add_form').serializeArray(),
                    success: function (jsonresult) {
                        if (jsonresult.Success) {
                            $pjq.messager.alert('提示', jsonresult.Msg, 'info');
                            $grid.datagrid('load');
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
        <form id="itemdetail_add_form" style="font-size: 12px; padding-left: 25px; padding-top: 10px">
            <table>
                <tr>
                    <td style="width: 60px">名称</td>
                    <td colspan="3">
                        <input name="Name" class="easyui-validatebox" type="text" data-options="required:true" style="width: 170px" />
                        <input name="ID" type="hidden" />
                    </td>
                </tr>
                <tr>
                    <td>值</td>
                    <td>
                        <input name="Value" class="easyui-validatebox" type="text" data-options="required:true" style="width: 170px" />
                    </td>
                </tr>
                <tr>
                    <td>类别</td>
                    <td colspan="3">
                        <input id="ItemID" name="ItemID" readonly="readonly" type="text" style="width: 395px" />
                    </td>
                </tr>
                <tr>
                    <td>有效</td>
                    <td>
                        <select id="Enabled" class="easyui-combobox" data-options="panelHeight:50,editable:false" name="Enabled" style="width: 170px">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>允许编辑</td>
                    <td>
                        <select id="AllowEdit" class="easyui-combobox" data-options="panelHeight:50,editable:false" name="AllowEdit" style="width: 170px">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </td>
                    <td>允许删除</td>
                    <td>
                        <select id="AllowDelete" class="easyui-combobox" data-options="panelHeight:50,editable:false" name="AllowDelete" style="width: 170px">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </td>
                </tr>
                  <tr>
                    <td>排序号</td>
                    <td>
                        <input name="OrderID" class="easyui-validatebox" type="text" data-options="required:true" style="width: 170px" />
                    </td>
                </tr>
                <tr>
                    <td>备注</td>
                    <td colspan="3">
                        <textarea name="Description" id="Description" style="width: 395px; height: 50px"></textarea>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
