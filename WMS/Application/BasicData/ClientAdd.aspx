<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientAdd.aspx.cs" Inherits="WMS.Application.BasicData.ClientAdd" %>

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
        var clientid = "<%=clientid %>";

        $(function () {

            $('#Category').combobox({
                url: '../../datasorce/sy_itemdetail.ashx?action=getcombox&code=ClientCategory',
                valueField: 'Value',
                textField: 'Name',
                width: 143,
                panelHeight: 100,
                editable: false,
                required: true
            });

            if (clientid) {
                $.ajax({
                    url: "../../datasorce/ap_client.ashx?action=getoneclient",
                    dataType: "json",
                    type: "post",
                    data: {
                        clientid: clientid
                    },
                    success: function (jsonresult) {
                        $("#client_add_form").form('load', jsonresult.Obj);
                    }
                })
            }
        });

        var f_save = function ($dialog, $grid, $pjq) {
            if ($('#client_add_form').form('validate')) {
                var url;
                if (clientid) {
                    url = "../../datasorce/ap_client.ashx?action=updateclient";
                } else {
                    url = "../../datasorce/ap_client.ashx?action=addclient";
                }

                var data = sy.serializeObject($('#client_add_form'));

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
        <form id="client_add_form" style="font-size: 12px; padding-left: 25px; padding-top: 10px">
            <table>
                <tr>
                    <td style="width: 80px">编码
                    </td>
                    <td>
                        <input name="Code" id="Code" class="easyui-validatebox" data-options="required:true" style="width: 140px" type="text" />
                    </td>
                    <td style="width: 80px">名称</td>
                    <td>
                        <input name="Name" class="easyui-validatebox" type="text" data-options="required:true" style="width: 140px" />
                        <input name="ID" type="hidden" />
                    </td>
                </tr>
                <tr>
                    <td>分类</td>
                    <td>
                        <input name="Category" id="Category" type="text" />
                    </td>
                    <td>联系人
                    </td>
                    <td>
                        <input name="LinkMan" id="LinkMan" class="easyui-validatebox" style="width: 140px" type="text" />
                    </td>
                </tr>
                <tr>
                    <td>手机
                    </td>
                    <td>
                        <input name="Phone" class="easyui-validatebox" type="text" data-options="validType:'mobile'" style="width: 140px" />
                    </td>
                    <td>电话
                    </td>
                    <td>
                        <input name="Tel" class="easyui-validatebox" type="text" data-options="validType:'phone'" style="width: 140px" />
                    </td>
                </tr>
                <tr>
                    <td>传真
                    </td>
                    <td>
                        <input name="Fax" class="easyui-validatebox" type="text" data-options="validType:'faxno',tipPosition:'left'" style="width: 140px" />
                    </td>
                    <td>邮编
                    </td>
                    <td>
                        <input name="PostCode" class="easyui-validatebox" data-options="validType:'zip'" type="text" style="width: 140px" />
                    </td>
                </tr>
                <tr>
                    <td>经度
                    </td>
                    <td>
                        <input name="Longitude" class="easyui-validatebox" type="text" style="width: 140px" />
                    </td>
                    <td>纬度
                    </td>
                    <td>
                        <input name="Latitude" class="easyui-validatebox" type="text" style="width: 140px" />
                    </td>
                </tr>
                <tr>
                    <td>地址
                    </td>
                    <td colspan="3">
                        <input name="Address" class="easyui-validatebox" type="text" style="width: 375px" />
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
