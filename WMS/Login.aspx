<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WMS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="library/jquery-1.9.1.min.js"></script>
    <script src="library/bootstrap.min.js"></script>
    <link href="library/bootstrap.css" rel="stylesheet" />
    <title></title>
    <style>
        body {
            background: #0066A8;
        }

        .tit {
            margin: auto;
            margin-top: 170px;
            text-align: center;
            width: 350px;
            padding-bottom: 20px;
        }

        .login-wrap {
            width: 220px;
            padding: 30px 50px 0 330px;
            height: 220px;
            background: #fff url(library/images/20150212154319.jpg) no-repeat 30px 40px;
            margin: auto;
            overflow: hidden;
        }

        .login_input {
            display: block;
            width: 210px;
        }

        .login_user {
            background: url(library/images/input_icon_1.png) no-repeat 200px center;
            font-family: "Lucida Sans Unicode", "Lucida Grande", sans-serif;
        }

        .login_password {
            background: url(library/images/input_icon_2.png) no-repeat 200px center;
            font-family: "Courier New", Courier, monospace;
        }

        .btn-login {
            background: #40454B;
            box-shadow: none;
            text-shadow: none;
            color: #fff;
            border: none;
            height: 35px;
            line-height: 26px;
            font-size: 14px;
            font-family: "microsoft yahei";
        }

            .btn-login:hover {
                background: #333;
                color: #fff;
            }

        .copyright {
            margin: auto;
            margin-top: 10px;
            text-align: center;
            width: 370px;
            color: #CCC;
        }

        @media (max-height: 700px) {
            .tit {
                margin: auto;
                margin-top: 100px;
            }
        }

        @media (max-height: 500px) {
            .tit {
                margin: auto;
                margin-top: 50px;
            }
        }
    </style>
    <script type="text/javascript">

        //var Login = function () {
        //    if (!$('#LoginName').val()) {
        //        lntip.tooltip("show");
        //        return false;
        //    }

        //    if (!$('#PassWord').val()) {
        //        pwtip.tooltip("show");
        //        return false;
        //    }

        //    $.ajax({
        //        url: 'datasorce/sy_login.ashx?action=login',
        //        type: "post",
        //        dataType: "json",
        //        data: {
        //            loginname: $('#LoginName').val(),
        //            password: $('#PassWord').val()
        //        },
        //        success: function (jsonresult) {
        //            if (jsonresult.Success) {
        //                $.messager.alert('提示', jsonresult.Msg, 'info');
        //            } else {
        //                $.messager.alert('提示', jsonresult.Msg, 'error');
        //            }
        //        }
        //    });
        //}
    </script>
</head>
<body>
    <div class="tit">
       <%--库存管理系统--%>
    </div>
    <div class="login-wrap">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="25" valign="bottom">用户名：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" class="login_input login_user" value="admin" /></td>
            </tr>
            <tr>
                <td height="35" valign="bottom">密  码：</td>
            </tr>
            <tr>
                <td>
                    <input type="password" class="login_input login_password" value="12345678" /></td>
            </tr>
            <tr>
                <td height="60" valign="bottom"><a href="开票界面.html" class="btn btn-block btn-login">登录</a></td>
            </tr>

        </table>
    </div>
    <div class="copyright">copyright</div>
</body>
</html>
