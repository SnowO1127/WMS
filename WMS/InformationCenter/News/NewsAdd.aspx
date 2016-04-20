<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsAdd.aspx.cs" Inherits="WMS.InformationCenter.News.NewsAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../library/jquery-1.9.1.min.js"></script>
    <script src="../../library/jquery.cookie.js"></script>
    <script src="../../library/jquery.easyui.min.js"></script>
    <script src="../../library/easyui-lang-zh_CN.js"></script>
    <script src="../../library/xyEasyUI.js"></script>
    <link id="easyuiTheme" href="../../library/themes/default/easyui.css" rel="stylesheet" />
    <link href="../../library/themes/icon.css" rel="stylesheet" />
    <script src="../../library/ueditor1_4_3-utf8-net/ueditor.config.js"></script>
    <script src="../../library/ueditor1_4_3-utf8-net/ueditor.all.min.js"></script>
    <script src="../../library/ueditor1_4_3-utf8-net/lang/zh-cn/zh-cn.js"></script>
    <link href="../../library/ueditor1_4_3-utf8-net/themes/default/css/ueditor.min.css" rel="stylesheet" />
    <title></title>
    <script>

        $(function () {
            UE.getEditor('content', {
                initialFrameWidth: 600, initialFrameHeight: 350, toolbars: [
               ['source', '|', 'undo', 'redo', '|',
                'bold', 'italic', 'underline', 'strikethrough', 'superscript', 'subscript', 'removeformat', 'formatmatch', 'autotypeset', 'blockquote', 'pasteplain', '|', 'forecolor', 'backcolor', 'insertorderedlist', 'insertunorderedlist', 'selectall', 'cleardoc', '|',
                'rowspacingtop', 'rowspacingbottom', 'lineheight', '|',
                'customstyle', 'paragraph', 'fontfamily', 'fontsize', '|',
                'directionalityltr', 'directionalityrtl', 'indent', '|',
                'justifyleft', 'justifycenter', 'justifyright', 'justifyjustify', '|', 'touppercase', 'tolowercase', '|',
                'imagenone', 'imageleft', 'imageright', 'imagecenter', '|',
                'insertimage', 'emotion', 'pagebreak', 'template', 'background', '|',
                'horizontal', 'date', 'time', 'spechars', '|',
                'inserttable', 'deletetable', 'insertparagraphbeforetable', 'insertrow', 'deleterow', 'insertcol', 'deletecol', 'mergecells', 'mergeright', 'mergedown', 'splittocells', 'splittorows', 'splittocols', '|',
                'preview', 'searchreplace']
                ],
                autoHeightEnabled: false
            });
        });

    </script>
</head>
<body>
    <div class="easyui-layout" fit="true">
        <form id="news_add_form">
            <div data-options="region: 'center', border: false" style="overflow: hidden; padding: 1px;">
                <div>
                    <label>新闻标题:</label>
                    <input name="tittle" class="easyui-validatebox" type="text" data-options="required:true" />
                </div>
                <textarea id="content" name="content" style="width: 600px;"></textarea>
            </div>
        </form>
    </div>
</body>
</html>
