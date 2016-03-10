<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fullcalendar.aspx.cs" Inherits="WMS.CommonTools.fullcalendar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../library/jquery-1.8.2.min.js"></script>
    <script src="../library/jquery.easyui.min.js"></script>
    <link id="easyuiTheme" href="../library/themes/default/easyui.css" rel="stylesheet" />
    <link href="../library/themes/icon.css" rel="stylesheet" />
    <script src="../library/jquery.cookie.js"></script>
    <script src="../library/xyEasyUI.js"></script>
    <title></title>

</head>
<body>
    <div class="easyui-layout" fit="true">
        <div data-options="region: 'center', border: false" style="overflow: hidden; padding: 1px;" fit="true">
            <div class="easyui-fullCalendar" fit="true"></div>
        </div>
    </div>
</body>
</html>
