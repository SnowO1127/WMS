<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RolePermissionSet.aspx.cs" Inherits="WMS.SystemManage.Permission.RolePermissionSet" %>

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
        var roleid = "<%=roleid %>";

        $(function () {
            tree = $("#permission_tree").tree({
                url: '../../datasorce/sy_permission.ashx?action=getrolepermissiontree',
                parentField: 'pid',
                lines: true,
                checkbox: true,
                queryParams: { roleid: roleid }
            })
        })

        var checkAll = function (check) {
            var roots = tree.tree("getRoots");
            $(roots).each(function (i) {
                var node = tree.tree('find', roots[i].id);
                if (check) {
                    tree.tree('check', node.target);
                }
                else {
                    tree.tree('uncheck', node.target);
                }
            });
        }

        var f_save_permission = function ($dialog, $pjq) {
            var nodes = tree.tree('getChecked', ['checked', 'indeterminate']);

            var permission = [];

            $(nodes).each(function (i) {
                var o = {};
                o.ID = nodes[i].id;
                o.ParentID = nodes[i].pid;
                o.IconCls = nodes[i].iconCls;
                o.Name = nodes[i].text;
                o.Category = nodes[i].attributes.category;
                permission.push(o);
            });

            $.ajax({
                url: "../../datasorce/sy_permission.ashx?action=addrolepermission",
                type: "post",
                dataType: "json",
                data: {
                    roleid: roleid,
                    jsonstr: JSON.stringify(permission)
                },
                success: function (jsonresult) {
                    if (jsonresult.Success) {
                        $pjq.messager.alert('提示', jsonresult.Msg, 'info');
                        $dialog.dialog('destroy');
                    } else {
                        $pjq.messager.alert('提示', jsonresult.Msg, 'error');
                    }
                }
            })
        }
    </script>
</head>
<body>
   <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'center',border:false" style="padding: 1px;">
            <div class="easyui-panel" data-options="border:false">
                <a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-ok'" onclick="checkAll(true)">全选</a>
                <a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-cancel'" onclick="checkAll(false)">取消全选</a>
                <div id="permission_tree" fit="true">
                </div>
            </div>
        </div>
    </div>
</body>
</html>
