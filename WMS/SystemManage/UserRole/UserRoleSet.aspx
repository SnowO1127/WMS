﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRoleSet.aspx.cs" Inherits="WMS.SystemManage.UserRole.UserRoleSet" %>

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
        var userid = "<%=id %>";

        $(function () {
            nogrid = $('#norole_grid').datagrid({
                title: '',
                url: '../../datasorce/sy_role.ashx?action=getnorole',
                striped: true,
                rownumbers: true,
                pagination: false,
                singleSelect: true,
                idField: 'ID',
                sortName: 'OrderID',
                sortOrder: 'desc',
                pageSize: 10,
                pageList: [10, 20, 30, 40, 50, 100, 200, 300, 400, 500],
                //frozenColumns: [[]],
                queryParams: {
                    userid: userid
                },
                columns: [[{
                    width: '90',
                    title: '角色编号',
                    field: 'Code',
                    halign: 'center',
                    sortable: true
                }, {
                    width: '100',
                    title: '角色名称',
                    field: 'Name',
                    halign: 'center',
                    sortable: true
                }, {
                    width: '80',
                    title: '角色类别',
                    halign: 'center',
                    field: 'Category',
                    align: 'center',
                    sortable: true
                }]],
                onBeforeLoad: function (param) {
                    parent.$.messager.progress({
                        fit: true,
                        text: '数据加载中....'
                    });
                },
                onLoadSuccess: function () {
                    parent.$.messager.progress('close');
                }
            });

            hasgrid = $('#hasrole_grid').datagrid({
                title: '',
                url: '../../datasorce/sy_role.ashx?action=gethasrole',
                striped: true,
                rownumbers: true,
                pagination: false,
                singleSelect: true,
                idField: 'ID',
                sortName: 'OrderID',
                sortOrder: 'desc',
                pageSize: 10,
                pageList: [10, 20, 30, 40, 50, 100, 200, 300, 400, 500],
                //frozenColumns: [[]],
                queryParams: {
                    userid: userid
                },
                columns: [[{
                    width: '90',
                    title: '角色编号',
                    field: 'Code',
                    halign: 'center',
                    sortable: true
                }, {
                    width: '100',
                    title: '角色名称',
                    field: 'Name',
                    halign: 'center',
                    sortable: true
                }, {
                    width: '80',
                    title: '角色类别',
                    halign: 'center',
                    field: 'Category',
                    align: 'center',
                    sortable: true
                }]],
                onBeforeLoad: function (param) {
                    parent.$.messager.progress({
                        fit: true,
                        text: '数据加载中....'
                    });
                },
                onLoadSuccess: function () {
                    parent.$.messager.progress('close');
                }
            });
        });
    </script>
</head>
<body>
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'west',split:true,collapsible:false" style="width: 360px;">
            <div class="easyui-layout" data-options="fit:true,border:false">
                <div data-options="region:'north',split:false,collapsible:false" style="height: 30px">
                    <form id="no_search_form">
                        角色名称:<input name="Name" class="easyui-validatebox" type="text" style="width: 110px" />
                        <a id="no_search_btn" class="easyui-linkbutton" data-options="plain: false, iconCls: 'icon-search'" onclick="unitSearch()">查找</a>
                        <a id="no_refresh_btn" class="easyui-linkbutton" data-options="plain: false, iconCls: 'icon-undo'" onclick="unitRefresh()">清空</a>
                    </form>
                </div>
                <div data-options="region:'center',split:true,title:'未选角色',collapsible:false" style="width: 330px;">
                    <div id="norole_grid" fit="true">
                    </div>
                </div>
            </div>
        </div>

        <div data-options="region:'center'" style="padding-top: 160px; padding-left: 12px;">
            <a href="javascript:void(0)" class="easyui-linkbutton" data-options="plain: false" style="width: 60px; margin-bottom: 20px;" onclick="moveIn()">《 移入</a>
            <a href="javascript:void(0)" class="easyui-linkbutton" data-options="plain: false" style="width: 60px" onclick="moveOut()">移出 》</a>
        </div>

        <div data-options="region:'east',split:true,collapsible:false" style="width: 360px;">
            <div class="easyui-layout" data-options="fit:true,border:false">
                <div data-options="region:'north',split:false,collapsible:false" style="height: 30px">
                    <form id="has_search_form">
                        角色名称:<input name="Name" class="easyui-validatebox" type="text" style="width: 110px" />
                        <a id="has_search_btn" class="easyui-linkbutton" data-options="plain: false, iconCls: 'icon-search'" onclick="unitSearch()">查找</a>
                        <a id="has_refresh_btn" class="easyui-linkbutton" data-options="plain: false, iconCls: 'icon-undo'" onclick="unitRefresh()">清空</a>
                    </form>
                </div>
                <div data-options="region:'center',split:true,title:'已选角色',collapsible:false" style="width: 330px;">
                    <div id="hasrole_grid" fit="true">
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>