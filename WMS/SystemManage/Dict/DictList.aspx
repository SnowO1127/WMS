<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DictList.aspx.cs" Inherits="WMS.SystemManage.Dict.DictList" %>

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
        <div data-options="region: 'west', border: true" title="字典类别" style="overflow: hidden; padding: 1px; width: 200px">
            <div id="dict_items_tree" fit="true">
            </div>
        </div>
        <div data-options="region: 'center', border: false" style="overflow: hidden; padding: 1px;">
            <div class="easyui-layout" fit="true">
                <div data-options="region: 'north', border: false" style="overflow: hidden; padding: 1px; height: 70px">
                    <fieldset>
                        <legend>查询条件</legend>
                        <form id="oganize_search_form">
                            <table>
                                <tr>
                                    <td>组织机构名称</td>
                                    <td>
                                        <input name="Name" class="easyui-validatebox" type="text" />
                                    </td>
                                    <td>
                                        <a id="unit_search_btn" class="easyui-linkbutton" data-options="plain: false, iconCls: 'icon-search'" onclick="oganizeSearch()">查找</a>
                                    </td>
                                    <td>
                                        <a id="unit_refresh_btn" class="easyui-linkbutton" data-options="plain: false, iconCls: 'icon-undo'" onclick="oganizeRefresh()">清空</a>
                                    </td>
                                </tr>
                            </table>
                        </form>
                    </fieldset>
                </div>
                <div data-options="region: 'center', border: false" style="overflow: hidden; padding: 1px;">
                    <div id="oganize_list_grid" fit="true">
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
