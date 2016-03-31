<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPermissionSet.aspx.cs" Inherits="WMS.SystemManage.Permission.UserPermissionSet" %>

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
        var userid = "<%=userid %>";

        var treeid;
        $(function () {
            tree = $("#permission_tree").tree({
                url: '../../datasorce/sy_menu.ashx?action=getmenutree',
                parentField: 'pid',
                lines: true,
                onClick: function (node) {

                    treeid = node.text == "全部" ? "" : node.id;

                    var obj = sy.serializeObject($('#menu_search_form'));
                    sy.mergeObj(obj, { ID: treeid });

                    grid.datagrid("load", obj);  // 在用户点击的时候提示
                    grid.datagrid("unselectAll");
                },
                onLoadSuccess: function (node, data) {
                    if (treeid) {
                        var n = tree.tree("find", treeid);
                        tree.tree("select", n.target);
                    }
                    else {
                        var n = tree.tree("find", data[0].id);
                        tree.tree("select", n.target);
                    }
                }
            })
        })
    </script>
</head>
<body>
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'center',border:false" style="padding: 1px;">
            <div id="permission_tree" fit="true">
            </div>
        </div>
    </div>
</body>
</html>
