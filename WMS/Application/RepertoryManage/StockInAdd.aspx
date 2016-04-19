<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockInAdd.aspx.cs" Inherits="WMS.Application.RepertoryManage.StockInAdd" %>

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
</head>
<body>
    <div class="easyui-layout" fit="true">
        <form id="stockin_add_form" style="font-size: 12px; padding-left: 25px; padding-top: 10px">
            <table>
                <tr>
                    <td style="width: 80px">入库单号</td>
                    <td>保存时生成
                        <input name="ID" type="hidden" />
                    </td>
                </tr>
                <tr>
                    <td>移动类型</td>
                    <td>
                        <input name="Type" type="text" style="width: 140px" />
                    </td>
                </tr>
                <tr>
                    <td>日期</td>
                    <td>
                        <input name="BillDate" class="easyui-my97" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" style="width: 140px" />
                    </td>
                </tr>
                <tr>
                    <td>供应商<img class="iconImg ext-icon-zoom" onclick="showSupplier();" title="选择供应商" />
                    </td>
                    <td colspan="3">
                        <input name="SupplierID" class="easyui-validatebox" type="text" style="width: 140px" />

                        <input name="SupplierName" class="easyui-validatebox" type="text" style="width: 140px" />
                    </td>
                </tr>
                <tr>
                    <td>原始单号</td>
                    <td colspan="3">
                        <input name="OriginalBillID" class="easyui-validatebox" type="text" style="width: 140px" />
                    </td>
                </tr>
                <tr>
                    <td>备货单号</td>
                    <td colspan="3">
                        <input name="StockUpBillID" class="easyui-validatebox" type="text" style="width: 140px" />
                    </td>
                </tr>
                <tr>
                    <td>经手人<img class="iconImg ext-icon-zoom" onclick="showHandUser();" title="选择经手人" />
                    </td>
                    <td colspan="3">
                        <input name="HandUserID" class="easyui-validatebox" type="text" style="width: 140px" />
                        <input name="HandUserName" class="easyui-validatebox" type="text" style="width: 140px" />
                    </td>
                </tr>
                <tr>
                    <td>制单人</td>
                    <td colspan="3">
                        <input name="CUserName" disabled="disabled" class="easyui-validatebox" type="text" style="width: 140px" />
                    </td>
                </tr>
                <tr>
                    <td>制单时间</td>
                    <td colspan="3">
                        <input name="CDate" disabled="disabled" class="easyui-validatebox" type="text" style="width: 140px" />
                    </td>
                </tr>
                <tr>
                    <td>审核人</td>
                    <td colspan="3">
                        <input name="CheckUserName" disabled="disabled" class="easyui-validatebox" type="text" style="width: 140px" />
                    </td>
                </tr>
                <tr>
                    <td>审核时间</td>
                    <td colspan="3">
                        <input name="CheckDate"  disabled="disabled" class="easyui-validatebox" type="text" style="width: 140px" />
                    </td>
                </tr>
                <tr>
                    <td>备注</td>
                    <td colspan="3">
                        <textarea name="Description" id="Description" style="width: 375px; height: 50px"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>附件</td>
                    <td colspan="3">
                        <textarea name="Description" id="Textarea9" style="width: 375px; height: 50px"></textarea>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
