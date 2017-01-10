<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WMS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="library/jquery-1.9.1.min.js"></script>
    <script src="library/jquery.easyui.min.js"></script>
    <script src="library/easyui-lang-zh_CN.js"></script>
    <script src="library/jquery.cookie.js"></script>
    <script src="library/xyEasyUI.js"></script>
    <script src="library/xyUtils.js"></script>
    <link id="easyuiTheme" href="library/themes/bootstrap/easyui.css" rel="stylesheet" />
    <link href="library/themes/icon.css" rel="stylesheet" />
    <link href="library/login.css" rel="stylesheet" />
    <title><%=Common.Globe.SystemName %></title>
    <script type="text/javascript">
        $(function () {
            lntip = $('#LoginName').tooltip({
                position: 'right',
                content: '<span style="color:#fff">用户名不能为空！</span>',
                onShow: function () {
                    $(this).tooltip('tip').css({
                        backgroundColor: '#666',
                        borderColor: '#666'
                    });
                }
            });

            pwtip = $('#PassWord').tooltip({
                position: 'right',
                content: '<span style="color:#fff">密码不能为空！</span>',
                onShow: function () {
                    $(this).tooltip('tip').css({
                        backgroundColor: '#666',
                        borderColor: '#666'
                    });
                }
            });

            sctip = $('#SecurityCode').tooltip({
                position: 'right',
                content: '<span style="color:#fff">验证码不能为空！</span>',
                onShow: function () {
                    $(this).tooltip('tip').css({
                        backgroundColor: '#666',
                        borderColor: '#666'
                    });
                }
            });
        });

        var login = function () {
            if (!$('#SecurityCode').val()) {
                sctip.tooltip("update", '<span style="color:#fff">验证码不能为空！</span>');
                sctip.tooltip("show");
                return false;
            }

            if (!$('#LoginName').val()) {
                lntip.tooltip("update", '<span style="color:#fff">用户名不能为空！</span>');
                lntip.tooltip("show");
                return false;
            }

            if (!$('#PassWord').val()) {
                pwtip.tooltip("update", '<span style="color:#fff">密码不能为空！</span>');
                pwtip.tooltip("show");
                return false;
            }

            $.ajax({
                url: 'datasorce/sy_login.ashx?action=login',
                type: "post",
                dataType: "json",
                data: {
                    loginname: $('#LoginName').val(),
                    password: $('#PassWord').val(),
                    securitycode: $('#SecurityCode').val()
                },
                beforeSend: function () {
                    $.messager.progress({
                        title: "登录",
                        text: '正在登录,请稍候......'
                    });
                },
                success: function (jsonresult) {
                    $.messager.progress('close');
                    if (jsonresult.Success) {
                        window.location = jsonresult.Obj;
                    }
                    else {
                        if (jsonresult.Msg == "0") {
                            sctip.tooltip("update", '<span style="color:#fff">验证码超时,请重新填写验证！</span>');
                            sctip.tooltip("show");
                            $("#validate").click();
                        }
                        else if (jsonresult.Msg == "1") {
                            sctip.tooltip("update", '<span style="color:#fff">验证码错误！</span>');
                            sctip.tooltip("show");
                        }
                        else if (jsonresult.Msg == "2") {
                            lntip.tooltip("update", '<span style="color:#fff">用户名不存在！</span>');
                            lntip.tooltip("show");
                        }
                        else if (jsonresult.Msg == "3") {
                            lntip.tooltip("update", '<span style="color:#fff">用户不可用！</span>');
                            lntip.tooltip("show");
                        }
                        else if (jsonresult.Msg == "4") {
                            pwtip.tooltip("update", '<span style="color:#fff">密码错误！</span>');
                            pwtip.tooltip("show");
                        }
                    }
                }
            });
        }
    </script>
</head>
<body>
    <div id="login_center">
        <div id="login_area">
            <div id="login_form">
                <div id="login_tip">
                    用户登录&nbsp;&nbsp;UserLogin
                </div>
                <div>
                    <input type="text" id="LoginName" class="username" />
                </div>
                <div>
                    <input type="password" id="PassWord" class="pwd" />
                </div>
                <div id="btn_area">
                    <input type="button" name="submit" id="sub_btn" value="登&nbsp;&nbsp;录" onclick="login()" />&nbsp;&nbsp;
                    <input type="text" id="SecurityCode" class="verify" />
                    <img id="validate" onclick="this.src=this.src+'?'" src="/SecurityCode.aspx" style="cursor: pointer; border: 1px solid #ddd;" alt="看不清楚，换一张" title="看不清楚，换一张" />
                </div>
            </div>
        </div>
    </div>
    <div id="login_bottom">
        版权所有
    </div>
</body>
</html>
