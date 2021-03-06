﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoPower.aspx.cs" Inherits="WMS.NoPower" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        .w-box {
            margin: 0 auto;
            background: none repeat scroll 0 0 #eef1f8;
            border: 1px solid #2a8cce;
            margin-top: 100px;
            padding: 50px 20px;
            width: 700px;
            height: 200px;
        }

            .w-box .tit {
                font-family: "微软雅黑";
                font-size: 18px;
                height: 80px;
                line-height: 80px;
                text-align: center;
            }

                .w-box .tit span {
                    display: inline-block;
                    vertical-align: middle;
                    padding-top: 20px;
                }

            .w-box p {
                font-family: "微软雅黑";
                font-size: 16px;
                line-height: 25px;
                text-align: center;
                color: red;
            }

        .footer {
            margin-top: 20px;
            font: normal 14px 'Microsoft YaHei','Segoe UI', Helvetica, 'Droid Sans', Tahoma, Geneva, sans-serif;
        }
    </style>
</head>
<body>
  <form id="form1" runat="server">
        <div class="w-box">
            <div class="tit">
                <span>
                    <img src="library/images/error.png" /></span> 您没有此页面的权限，请联系管理员获得权限！
            </div>
        </div>
        <div class="footer">
            <div style="text-align: center">
               <p>
                    <span>如有问题，请致电****-********</span>
                </p>
                <p>
                    <span>Copyright©2005-2014 **有限公司</span>
                </p>
            </div>
        </div>
    </form>
</body>
</html>
