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
    <link href="../../library/syExtCss.css" rel="stylesheet" />
    <link href="../../library/syExtIcon.css" rel="stylesheet" />
    <title></title>
    <script>
        var sy = sy || {};
        sy.pixel_0 = '../../library/images/pixel_0.gif';//0像素的背景，一般用于占位

        var showIcons = function () {
            var dialog = parent.sy.modalDialog({
                title: '浏览小图标',
                url: 'icons.aspx',
                buttons: [{
                    text: '确定',
                    handler: function () {
                        dialog.find('iframe').get(0).contentWindow.selectIcon(dialog, $('#IconCls'));
                    }
                }]
            });
        };

        $(function () {
            $('.iconImg').attr('src', sy.pixel_0);
        })
    </script>
</head>
<body>
    <div class="easyui-layout" fit="true">
        <form id="menu_add_form" style="font-size: 13px; margin: 0 auto">
            <table>
                <tr>
                    <td style="width: 60px">菜单名称</td>
                    <td colspan="3">
                        <input name="MenuName" class="easyui-validatebox" type="text" data-options="required:true" style="width: 170px" />
                    </td>
                </tr>
                <tr>
                    <td>分类</td>
                    <td>
                        <select id="Category" class="easyui-combobox" data-options="panelHeight:50,editable:false" name="Category" style="width: 173px">
                            <option value="system">system</option>
                            <option value="application">application</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>上级菜单</td>
                    <td colspan="3">
                        <input id="pid" name="pid" class="easyui-combotree" data-options="panelHeight:150,editable:false,idField:'id',textField:'name',parentField:'pid',url:'../../datasorce/sy_menu.ashx?action=getallmenu'" />
                        <img style="cursor: pointer; vertical-align: middle" src="../../library/themes/icons/no.png" onclick="$('#pid').combotree('clear')" title="清空" />
                    </td>
                </tr>
                <tr>
                    <td>地址</td>
                    <td colspan="3">
                        <input name="Url" class="easyui-validatebox" type="text" style="width: 405px" />
                    </td>
                </tr>
                <tr>
                    <td>图标</td>
                    <td>
                        <input id="IconCls" name="IconCls" class="easyui-validatebox" readonly="readonly" style="padding-left: 30px; width: 136px;" />

                    </td>
                    <td>
                        <img class="iconImg ext-icon-zoom" onclick="showIcons();" title="浏览图标" />&nbsp;
                        <img class="iconImg ext-icon-cross" onclick="$('#iconCls').val('');$('#iconCls').attr('class','');" title="清空" /></td>
                </tr>
                <tr>
                    <td>有效</td>
                    <td>
                        <select id="Enabled" class="easyui-combobox" data-options="panelHeight:50,editable:false" name="Enabled" style="width: 170px">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </td>

                </tr>
                <tr>
                    <td>是否公开</td>
                    <td>
                        <select id="IsPublic" class="easyui-combobox" data-options="panelHeight:50,editable:false" name="IsPublic" style="width: 170px">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </td>
                    <td style="width: 60px">是否菜单</td>
                    <td>
                        <select id="IsMenu" class="easyui-combobox" data-options="panelHeight:50,editable:false" name="IsMenu" style="width: 170px">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>允许编辑</td>
                    <td>
                        <select id="AllowEdit" class="easyui-combobox" data-options="panelHeight:50,editable:false" name="AllowEdit" style="width: 170px">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </td>
                    <td>允许删除</td>
                    <td>
                        <select id="AllowDelete" class="easyui-combobox" data-options="panelHeight:50,editable:false" name="AllowDelete" style="width: 170px">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>描述</td>
                    <td colspan="3">
                        <textarea name="Description" id="Description" style="width: 405px; height: 50px"></textarea>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
