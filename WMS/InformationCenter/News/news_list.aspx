<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="news_list.aspx.cs" Inherits="WMS.InformationCenter.News.news_list" %>

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
    <title></title>
    <script>
        $(function () {
            grid = $('#news_list_grid').datagrid({
                title: '',
                url: '../../datasorce/sy_news.ashx?action=getnews',
                striped: true,
                rownumbers: true,
                pagination: true,
                singleSelect: true,
                idField: 'id',
                sortName: 'pubtime',
                sortOrder: 'desc',
                pageSize: 10,
                pageList: [10, 20, 30, 40, 50, 100, 200, 300, 400, 500],
                columns: [[{
                    width: '150',
                    title: '标题',
                    field: 'tittle',
                    sortable: true
                }, {
                    width: '150',
                    title: '发布时间',
                    field: 'pubtime',
                    sortable: true
                }]],
                toolbar: [{
                    iconCls: 'icon-add',
                    text: '增加',
                    handler: function () {
                        open();
                    }
                }, '-', {
                    iconCls: 'icon-help',
                    text: '帮助',
                    handler: function () { alert('帮助按钮') }
                }],
                onBeforeLoad: function (param) {
                    parent.$.messager.progress({
                        text: '数据加载中....'
                    });
                },
                onLoadSuccess: function (data) {
                    parent.$.messager.progress('close');
                }
            });
        });


        function open() {
            $("#add_news_dialog").dialog({
                title: '新增新闻',
                width: 620,
                height: 600,
                closed: false,
                cache: false,
                content: '<iframe scrolling="auto" frameborder="0"  src="news_add.aspx" style="width:100%;height:98%;"></iframe>',
                modal: true,
                buttons: [{
                    text: '增加',
                    iconCls: 'icon-add',
                    handler: function () {
                        alert(1);
                    }
                }]
            })
        }
    </script>
</head>
<body>
    <div class="easyui-layout" fit="true">
        <div data-options="region: 'center', border: false" style="overflow: hidden; padding: 1px;">
            <div id="news_list_grid" fit="true">
            </div>
        </div>
    </div>

    <div id="add_news_dialog"></div>
</body>
</html>
