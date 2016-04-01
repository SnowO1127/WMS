<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ButtonAdd.aspx.cs" Inherits="WMS.SystemManage.Button.ButtonAdd" %>

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

        var buttonid = "<%=buttonid %>";
        var menuid = "<%=menuid %>";

        $(function () {
            if (menuid)
                $('#MenuID').combotree('setValue', menuid);

            if (buttonid) {
                $.ajax({
                    url: "../../datasorce/sy_button.ashx?action=getonebutton",
                    dataType: "json",
                    type: "post",
                    data: {
                        buttonid: buttonid
                    },
                    success: function (jsonresult) {
                        $("#button_add_form").form('load', jsonresult);
                    }
                })
            }
        });

        var f_save = function ($dialog, $grid, $pjq) {
            if ($('#button_add_form').form('validate')) {
                var url;
                if (buttonid) {
                    url = "../../datasorce/sy_button.ashx?action=updatebutton";
                } else {
                    url = "../../datasorce/sy_button.ashx?action=addbutton";
                }
                $.ajax({
                    url: url,
                    type: "post",
                    dataType: "json",
                    data: sy.serializeObject($('#button_add_form')),
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
        <form id="button_add_form" style="font-size: 12px; padding-left: 25px; padding-top: 10px">
            <table>
                <tr>
                    <td style="width: 60px">按钮名称</td>
                    <td colspan="3">
                        <input name="Name" class="easyui-validatebox" type="text" data-options="required:true" style="width: 170px" />
                        <input name="ID" type="hidden" />
                    </td>
                </tr>
                <tr>
                    <td>按钮id</td>
                    <td>
                        <input name="HtmlID" id="HtmlID" type="text" style="width: 170px" />
                    </td>
                </tr>
                <tr>
                    <td>菜单</td>
                    <td colspan="3">
                        <input id="MenuID" name="MenuID" class="easyui-combotree" style="width: 173px" data-options="disabled:true,panelHeight:140,editable:false,idField:'id',textField:'text',parentField:'pid',url:'../../datasorce/sy_menu.ashx?action=getmenutree'" />
                    </td>
                </tr>
                <tr>
                    <td>有效</td>
                    <td>
                        <select id="Enabled" class="easyui-combobox" data-options="panelHeight:50,editable:false" name="Enabled" style="width: 170px">
                            <option value="true">是</option>
                            <option value="false">否</option>
                        </select>
                    </td>
                    <td>是否公开</td>
                    <td>
                        <select id="IsPublic" class="easyui-combobox" data-options="panelHeight:50,editable:false" name="IsPublic" style="width: 170px">
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
                    <td>排序号
                    </td>
                    <td>
                        <input id="OrderID" name="OrderID" class="easyui-validatebox" data-options="required:true,validType:'integer'" style="width: 170px" />
                    </td>
                </tr>
                <tr>
                    <td>描述</td>
                    <td colspan="3">
                        <textarea name="Description" id="Description" style="width: 405px; height: 50px"></textarea>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
