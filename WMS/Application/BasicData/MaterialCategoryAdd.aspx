<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaterialCategoryAdd.aspx.cs" Inherits="WMS.Application.BasicData.MaterialCategoryAdd" %>

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
        var materialcategoryid = "<%=materialcategoryid %>";

        $(function () {

            if (materialcategoryid) {
                $.ajax({
                    url: "../../datasorce/ap_materialcategory.ashx?action=getonematerialcategory",
                    dataType: "json",
                    type: "post",
                    data: {
                        materialcategoryid: materialcategoryid
                    },
                    success: function (jsonresult) {
                        $("#materialcategory_add_form").form('load', jsonresult.Obj);
                    }
                })
            }
        });

        var f_save = function ($dialog, $grid, $pjq) {
            if ($('#materialcategory_add_form').form('validate')) {
                var url;
                if (materialcategoryid) {
                    url = "../../datasorce/ap_materialcategory.ashx?action=updatematerialcategory";
                } else {
                    url = "../../datasorce/ap_materialcategory.ashx?action=addmaterialcategory";
                }

                var data = sy.serializeObject($('#materialcategory_add_form'));

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
        <form id="materialcategory_add_form" style="font-size: 12px; padding-left: 25px; padding-top: 10px">
            <table>
                <tr>
                    <td style="width: 80px">物料分类</td>
                    <td>
                        <input name="Name" class="easyui-validatebox" type="text" data-options="required:true" style="width: 140px" />
                        <input name="ID" type="hidden" />
                    </td>
                </tr>
                <tr>
                    <td>编码
                    </td>
                    <td>
                        <input name="Code" id="LinkMan" class="easyui-validatebox" style="width: 140px" type="text" />
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
