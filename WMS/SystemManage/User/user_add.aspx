<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_add.aspx.cs" Inherits="WMS.SystemManage.User.user_add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../library/jquery-1.8.2.min.js"></script>
    <script src="../../library/jquery.easyui.min.js"></script>
    <script src="../../library/easyui-lang-zh_CN.js"></script>
    <link href="../../library/themes/default/easyui.css" rel="stylesheet" />
    <link href="../../library/themes/icon.css" rel="stylesheet" />
    <title></title>
    <script>
        var id = "<%=id %>";

        $(function () {
            if (id) {
                $.ajax({
                    url: "../../datasorce/sy_user.ashx?action=getoneuser",
                    dataType: "json",
                    type: "post",
                    data: {
                        id: id
                    },
                    success: function (jsonresult) {
                        $("#user_add_form").form('load', jsonresult);
                    }
                })
            }
        });

        var f_save = function ($dialog, $grid, $pjq) {
            if ($('#unit_add_form').form('validate')) {
                var url;
                if (id) {
                    url = "../../datasorce/sy_unit.ashx?action=updateunit";
                } else {
                    url = "../../datasorce/sy_unit.ashx?action=addunit";
                }
                $.ajax({
                    url: url,
                    type: "post",
                    dataType: "json",
                    data: $('#unit_add_form').serializeArray(),
                    success: function (jsonresult) {
                        if (jsonresult.success) {
                            $pjq.messager.alert('提示', jsonresult.msg, 'info');
                            $grid.treegrid('load');
                            $dialog.dialog('destroy');
                        } else {
                            $pjq.messager.alert('提示', jsonresult.msg, 'error');
                        }
                    }
                });
            }
        };
    </script>
</head>
<body>
    <div class="easyui-layout" fit="true">
        <form id="user_add_form" runat="server" style="font-size: 13px">
            <fieldset>
                <legend>基本信息</legend>
                <input name="loginname" />
                <input name="pwd" />
                <input name="sex" />
                <input name="name" />
                <input name="age" />
                <input name="photo" />
            </fieldset>

        </form>
    </div>
</body>
</html>
