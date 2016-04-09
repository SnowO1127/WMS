<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaterialAdd.aspx.cs" Inherits="WMS.Application.BasicData.MaterialAdd" %>

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
        var materialid = "<%=materialid %>";

        var sy = sy || {};
        sy.pixel_0 = '../../library/images/pixel_0.gif';//0像素的背景，一般用于占位

        $(function () {
            $('.iconImg').attr('src', sy.pixel_0);
        })

        var showUnitConversion = function () {
            var dialog = parent.sy.modalDialog({
                title: '选择计量单位换算',
                width: 600,
                height: 400,
                url: 'Application/BasicData/UnitConversionList.aspx',
                buttons: [{
                    text: '确定',
                    handler: function () {
                        dialog.find('iframe').get(0).contentWindow.setUnitConversion(dialog, $('#UnitConversionID'), $('#MainUnit'), $('#AssistUnit'), $('#TranslateRate'));
                    }
                }]
            });
        };

        var showMaterialCategory = function () {
            var dialog = parent.sy.modalDialog({
                title: '选择物料分类',
                width: 600,
                height: 400,
                url: 'Application/BasicData/MaterialCategoryList.aspx',
                buttons: [{
                    text: '确定',
                    handler: function () {
                        dialog.find('iframe').get(0).contentWindow.setMaterialCategory(dialog, $('#CategoryID'), $('#CategoryName'));
                    }
                }]
            });
        }

        $(function () {

            $('#Wrappage').combobox({
                url: '../../datasorce/sy_itemdetail.ashx?action=getcombox&code=Wrappage',
                valueField: 'Value',
                textField: 'Name',
                width: 143,
                panelHeight: 100,
                editable: false
                //required: true
            });

            if (materialid) {
                $.ajax({
                    url: "../../datasorce/ap_material.ashx?action=getonematerial",
                    dataType: "json",
                    type: "post",
                    data: {
                        materialid: materialid
                    },
                    success: function (jsonresult) {
                        $("#material_add_form").form('load', jsonresult.Obj);
                        $('#MainUnit').val(jsonresult.Obj.UnitConversion.MainUnitName);
                        $('#AssistUnit').val(jsonresult.Obj.UnitConversion.AssistUnitName);
                        $('#TranslateRate').val(jsonresult.Obj.UnitConversion.TranslateRate);

                        $('#CategoryName').val(jsonresult.Obj.MaterialCategory.Name);
                    }
                })
            }
        });

        var f_save = function ($dialog, $grid, $pjq) {
            if ($('#material_add_form').form('validate')) {
                var url;
                if (materialid) {
                    url = "../../datasorce/ap_material.ashx?action=updatematerial";
                } else {
                    url = "../../datasorce/ap_material.ashx?action=addmaterial";
                }

                var data = sy.serializeObject($('#material_add_form'));

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
        <form id="material_add_form" style="font-size: 12px; padding-left: 25px; padding-top: 10px">
            <table>
                <tr>
                    <td style="width: 80px">编码
                    </td>
                    <td>
                        <input name="Code" id="Code" class="easyui-validatebox" data-options="required:true" style="width: 140px" type="text" />
                    </td>
                    <td style="width: 80px">名称</td>
                    <td>
                        <input name="Name" class="easyui-validatebox" type="text" data-options="required:true,tipPosition:'left'" style="width: 140px" />
                        <input name="ID" type="hidden" />
                    </td>
                </tr>
                <tr>
                    <td>物料分类</td>
                    <td>
                        <input name="CategoryName" id="CategoryName" disabled="disabled" type="text" style="width: 140px" />
                        <input name="CategoryID" id="CategoryID" type="hidden" />
                    </td>
                    <td>
                        <img class="iconImg ext-icon-zoom" onclick="showMaterialCategory();" title="选择物料分类" />&nbsp;</td>
                </tr>
                <tr>
                    <td>计量单位换算  
                    </td>
                    <td>
                        <img class="iconImg ext-icon-zoom" onclick="showUnitConversion();" title="选择计量单位换算" />&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>主计量单位
                    </td>
                    <td>
                        <input name="UnitConversionID" id="UnitConversionID" type="hidden" />
                        <input name="MainUnit" id="MainUnit" disabled="disabled" type="text" style="width: 140px" />
                    </td>
                    <td>辅计量单位
                    </td>
                    <td>
                        <input name="AssistUnit" id="AssistUnit" disabled="disabled" type="text" style="width: 140px" />
                    </td>
                </tr>
                <tr>
                    <td>换算率
                    </td>
                    <td>
                        <input name="TranslateRate" id="TranslateRate" disabled="disabled" type="text" style="width: 140px" />
                    </td>
                </tr>
                <tr>
                    <td>助记码
                    </td>
                    <td>
                        <input name="Mnemonics" class="easyui-validatebox" type="text" style="width: 140px" />
                    </td>
                    <td>重量
                    </td>
                    <td>
                        <input name="Weight" class="easyui-validatebox" type="text" style="width: 140px" />
                    </td>
                </tr>
                <tr>
                    <td>长
                    </td>
                    <td>
                        <input name="Long" class="easyui-validatebox" type="text" style="width: 140px" />
                    </td>
                    <td>宽
                    </td>
                    <td>
                        <input name="Width" class="easyui-validatebox" type="text" style="width: 140px" />
                    </td>
                </tr>
                <tr>
                    <td>高
                    </td>
                    <td>
                        <input name="Height" class="easyui-validatebox" type="text" style="width: 140px" />
                    </td>
                    <td>体积
                    </td>
                    <td>
                        <input name="Volume" class="easyui-validatebox" type="text" style="width: 140px" />
                    </td>
                </tr>
                <tr>
                    <td>包装物
                    </td>
                    <td>
                        <input name="Wrappage" id="Wrappage" type="text" />
                    </td>
                </tr>
                <tr>
                    <td>质保期
                    </td>
                    <td>
                        <input name="WarrantyDays" class="easyui-validatebox" data-options="validType:'integer'" type="text" style="width: 140px" />
                    </td>
                    <td>质保期预警
                    </td>
                    <td>
                        <input name="WarrantyWarnDays" class="easyui-validatebox" data-options="validType:'integer',tipPosition:'left'" type="text" style="width: 140px" />
                    </td>
                </tr>
                <tr>
                    <td>启用批次管理</td>
                    <td>
                        <select id="IsBatch" class="easyui-combobox" data-options="panelHeight:50,editable:false" name="IsBatch" style="width: 143px">
                            <option value="true">是</option>
                            <option value="false">否</option>
                        </select>
                    </td>
                    <td colspan="2">
                        <span style="color: red">启用批次管理后,默认先进先出</span>
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
                    <td>排序号</td>
                    <td>
                        <input name="OrderID" class="easyui-validatebox" data-options="required:true,validType:'integer',tipPosition:'left'" style="width: 140px" />
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
