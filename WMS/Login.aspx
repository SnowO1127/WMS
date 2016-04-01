<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WMS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="library/jquery-1.9.1.min.js"></script>
    <script src="library/jquery.easyui.min.js"></script>
    <script src="library/easyui-lang-zh_CN.js"></script>
    <link id="easyuiTheme" href="library/themes/default/easyui.css" rel="stylesheet" />
    <title></title>
    <style>
        body {
            background: #ebebeb;
            font-family: "Helvetica Neue","Hiragino Sans GB","Microsoft YaHei","\9ED1\4F53",Arial,sans-serif;
            color: #222;
            font-size: 12px;
        }

        * {
            padding: 0px;
            margin: 0px;
        }

        .top_div {
            background: #008ead;
            width: 100%;
            height: 400px;
        }

        .ipt {
            border: 1px solid #d3d3d3;
            padding: 10px 10px;
            width: 290px;
            border-radius: 4px;
            padding-left: 35px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
        }

            .ipt:focus {
                border-color: #66afe9;
                outline: 0;
                -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6);
                box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6);
            }

        .u_logo {
            background: url("library/images/login/username.png") no-repeat;
            padding: 10px 10px;
            position: absolute;
            top: 43px;
            left: 40px;
        }

        .p_logo {
            background: url("library/images/login/password.png") no-repeat;
            padding: 10px 10px;
            position: absolute;
            top: 12px;
            left: 40px;
        }

        a {
            text-decoration: none;
        }

        .tou {
            background: url("library/images/login/tou.png") no-repeat;
            width: 97px;
            height: 92px;
            position: absolute;
            top: -87px;
            left: 140px;
        }

        .left_hand {
            background: url("library/images/login/left_hand.png") no-repeat;
            width: 32px;
            height: 37px;
            position: absolute;
            top: -38px;
            left: 150px;
        }

        .right_hand {
            background: url("library/images/login/right_hand.png") no-repeat;
            width: 32px;
            height: 37px;
            position: absolute;
            top: -38px;
            right: -64px;
        }

        .initial_left_hand {
            background: url("library/images/login//hand.png") no-repeat;
            width: 30px;
            height: 20px;
            position: absolute;
            top: -12px;
            left: 100px;
        }

        .initial_right_hand {
            background: url("library/images/login//hand.png") no-repeat;
            width: 30px;
            height: 20px;
            position: absolute;
            top: -12px;
            right: -112px;
        }

        .left_handing {
            background: url("library/images/login//left-handing.png") no-repeat;
            width: 30px;
            height: 20px;
            position: absolute;
            top: -24px;
            left: 139px;
        }

        .right_handinging {
            background: url("library/images/login//right_handing.png") no-repeat;
            width: 30px;
            height: 20px;
            position: absolute;
            top: -21px;
            left: 210px;
        }
    </style>

    <script type="text/javascript">
        $(function () {
            //得到焦点
            $("#password").focus(function () {
                $("#left_hand").animate({
                    left: "150",
                    top: " -38"
                }, {
                    step: function () {
                        if (parseInt($("#left_hand").css("left")) > 140) {
                            $("#left_hand").attr("class", "left_hand");
                        }
                    }
                }, 2000);
                $("#right_hand").animate({
                    right: "-64",
                    top: "-38px"
                }, {
                    step: function () {
                        if (parseInt($("#right_hand").css("right")) > -70) {
                            $("#right_hand").attr("class", "right_hand");
                        }
                    }
                }, 2000);
            });
            //失去焦点
            $("#password").blur(function () {
                $("#left_hand").attr("class", "initial_left_hand");
                $("#left_hand").attr("style", "left:100px;top:-12px;");
                $("#right_hand").attr("class", "initial_right_hand");
                $("#right_hand").attr("style", "right:-112px;top:-12px");
            });
        });


        $(function () {
            lntip = $('#LoginName').tooltip({
                position: 'right',
                content: '<span style="color:red;font-size:13px">用户名必填！</span>',
                onShow: function () {
                    $(this).tooltip('tip').css({
                        height: 20,
                        width: 110,
                        position: 'absolute',
                        borderColor: '#d3d3d3'
                    });
                }
            });

            pwtip = $('#PassWord').tooltip({
                position: 'right',
                content: '<span style="color:red;font-size:13px">密码必填！</span>',
                onShow: function () {
                    $(this).tooltip('tip').css({
                        height: 20,
                        width: 110,
                        position: 'absolute',
                        borderColor: '#d3d3d3'
                    });
                }
            });
        });

        var Login = function () {
            if (!$('#LoginName').val()) {
                lntip.tooltip("show");
                return false;
            }

            if (!$('#PassWord').val()) {
                pwtip.tooltip("show");
                return false;
            }

            $.ajax({
                url: 'datasorce/sy_login.ashx?action=login',
                type: "post",
                dataType: "json",
                data: {
                    loginname: $('#LoginName').val(),
                    password: $('#PassWord').val()
                },
                success: function (jsonresult) {
                    if (jsonresult.Success) {
                        $.messager.alert('提示', jsonresult.Msg, 'info');
                    } else {
                        $.messager.alert('提示', jsonresult.Msg, 'error');
                    }
                }
            });
        }
    </script>
</head>
<body>
    <div class="top_div"></div>
    <div style="background: rgb(255, 255, 255); margin: -100px auto auto; border: 1px solid rgb(231, 231, 231); border-image: none; width: 400px; height: 200px; text-align: center;">
        <div style="width: 165px; height: 96px; position: absolute;">
            <div class="tou"></div>
            <div class="initial_left_hand" id="left_hand"></div>
            <div class="initial_right_hand" id="right_hand"></div>
        </div>
        <p style="padding: 30px 0px 10px; position: relative; color: aqua">
            <span class="u_logo"></span>
            <input class="ipt" id="LoginName" type="text" placeholder="请输入用户名" value="" />
        </p>
        <p style="position: relative;">
            <span class="p_logo"></span>
            <input class="ipt" id="PassWord" type="password" placeholder="请输入密码" />
        </p>
        <div style="height: 50px; line-height: 50px; margin-top: 30px; border-top-color: rgb(231, 231, 231); border-top-width: 1px; border-top-style: solid;">
            <p style="margin: 0px 35px 20px 45px;">
                <span style="float: left;"><a style="color: rgb(204, 204, 204);"
                    href="#">忘记密码?</a></span>
                <span style="float: right;">
                    <a style="background: rgb(0, 142, 173); padding: 7px 10px; border-radius: 4px; border: 1px solid rgb(26, 117, 152); border-image: none; color: rgb(255, 255, 255); font-weight: bold;"
                        href="#" onclick="Login()">登录</a>
                </span>
            </p>
        </div>
    </div>
</body>
</html>
