<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu_add.aspx.cs" Inherits="WMS.SystemManage.Menu.menu_add" %>

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
    <title></title>
</head>
<body>
    <div class="easyui-layout" fit="true">
        <form id="menu_add_form" style="font-size: 13px">
            <table>
                <tr>
                    <td>菜单名称</td>
                    <td>
                        <input name="MenuName" class="easyui-validatebox" type="text" data-options="required:true" />
                    </td>
                    <td>分类</td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td>上级菜单</td>
                    <td></td>
                    <td>地址</td>
                    <td></td>
                </tr>
                <tr>
                    <td>图标</td>
                    <td></td>
                    <td>是否公开</td>
                    <td></td>
                </tr>
                <tr>
                    <td>是否菜单</td>
                    <td></td>
                    <td>允许编辑</td>
                    <td></td>
                </tr>
                <tr>
                    <td>允许删除</td>
                    <td></td>
                    <td>有效</td>
                    <td></td>
                </tr>
                <tr>
                    <td>描述</td>
                    <td></td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
