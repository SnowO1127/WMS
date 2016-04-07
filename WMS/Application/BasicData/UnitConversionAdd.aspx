<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnitConversionAdd.aspx.cs" Inherits="WMS.Application.BasicData.UnitConversionAdd" %>

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
        var unitconversionid = "<%=unitconversionid %>";

        $(function () {

            $('#MainUnitName').combobox({
                url: '../../datasorce/ap_unit.ashx?action=getunit',
                valueField: 'Name',
                textField: 'Name',
                width: 143,
                panelHeight: 100,
                editable: false,
                required: true
            });

            $('#AssistUnitName').combobox({
                url: '../../datasorce/ap_unit.ashx?action=getunit',
                valueField: 'Name',
                textField: 'Name',
                width: 143,
                panelHeight: 100,
                editable: false,
                required: true
            });

            if (unitconversionid) {
                $.ajax({
                    url: "../../datasorce/ap_unitconversion.ashx?action=getoneunitconversion",
                    dataType: "json",
                    type: "post",
                    data: {
                        unitconversionid: unitconversionid
                    },
                    success: function (jsonresult) {
                        $("#unitconversion_add_form").form('load', jsonresult.Obj);
                    }
                })
            }
        });

        var f_save = function ($dialog, $grid, $pjq) {
            if ($('#unitconversion_add_form').form('validate')) {
                var url;
                if (unitconversionid) {
                    url = "../../datasorce/ap_unitconversion.ashx?action=updateunitconversion";
                } else {
                    url = "../../datasorce/ap_unitconversion.ashx?action=addunitconversion";
                }

                var data = sy.serializeObject($('#unitconversion_add_form'));

                $.ajax({
                    url: url,
                    type: "post",
                    dataType: "json",
                    data: data,
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
        <form id="unitconversion_add_form" style="font-size: 12px; padding-left: 25px; padding-top: 10px">
            <table>
                <tr>
                    <td style="width: 80px">编码</td>
                    <td>
                        <input name="Code" class="easyui-validatebox" type="text" data-options="required:true" style="width: 140px" />
                        <input name="ID" type="hidden" />
                    </td>
                </tr>
                <tr>
                    <td>主计量单位
                    </td>
                    <td>
                       <input name="MainUnitName" id="MainUnitName" type="text" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 80px">辅计量单位
                    </td>
                    <td>
                        <input name="AssistUnitName" id="AssistUnitName" type="text" />
                    </td>
                </tr>
                <tr>
                    <td>换算率
                    </td>
                    <td>
                        <input name="TranslateRate" class="easyui-validatebox" type="text" data-options="validType:'integer'" style="width: 140px" />
                    </td>
                </tr>
                <tr>
                    <td>有效</td>
                    <td>
                        <select id="Enabled" class="easyui-combobox" data-options="panelHeight:50,editable:false" name="Enabled" style="width: 143px">
                            <option value="true">是</option>
                            <option value="false">否</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>排序号</td>
                    <td>
                        <input name="OrderID" class="easyui-validatebox" data-options="required:true,validType:'integer'" style="width: 140px" />
                    </td>
                </tr>
                <tr>
                    <td>描述</td>
                    <td colspan="3">
                        <textarea name="Description" id="Description" style="width: 375px; height: 50px"></textarea>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
