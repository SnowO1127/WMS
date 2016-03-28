<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WMS.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="library/jquery-1.9.1.min.js"></script>
    <script src="library/jquery.easyui.min.js"></script>
    <script src="library/easyui-lang-zh_CN.js"></script>
    <link id="easyuiTheme" href="library/themes/default/easyui.css" rel="stylesheet" />
    <link href="library/themes/icon.css" rel="stylesheet" />
    <link href="library/base_css/ui.css" rel="stylesheet" />
    <script src="library/jquery.cookie.js"></script>
    <script src="library/jquery-easyui-portal/jquery.portal.js"></script>
    <link href="library/jquery-easyui-portal/portal.css" rel="stylesheet" />
    <script src="library/My97DatePicker/WdatePicker.js"></script>
    <script src="library/xyEasyUI.js"></script>
    <script src="library/xyUtils.js"></script>
    <link href="library/syExtCss.css" rel="stylesheet" />
    <link href="library/syExtIcon.css" rel="stylesheet" /> 
    <title>库存管理系统</title>
      
    <script>
        var themeData =
             [//主题风格json格式
                 { id: 1, name: "默认(天空蓝,推荐)", path: "default" },
                 { id: 2, name: "金属黑(推荐)", path: "black" },
                 { id: 3, name: "银色(推荐)", path: "bootstrap" },
                 { id: 4, name: "灰霾(推荐)", path: "gray" },
                 { id: 5, name: "清泉", path: "jqueryui-cupertino", disabled: false },
                 { id: 6, name: "黑巢", path: "jqueryui-dark-hive", disabled: false },
                 { id: 7, name: "杏黄", path: "jqueryui-pepper-grinder", disabled: false },
                 { id: 8, name: "阳光", path: "jqueryui-sunny", disabled: false },
                 { id: 9, name: "磁贴（标准）", path: "metro-standard" },
                 { id: 10, name: "磁贴（蓝）", path: "metro-blue" },
                 { id: 11, name: "磁贴（灰）", path: "metro-gray" },
                 { id: 12, name: "磁贴（绿）", path: "metro-green" },
                 { id: 13, name: "磁贴（橙）", path: "metro-orange" },
                 { id: 14, name: "磁贴（红）", path: "metro-red" }
             ];

        var sy = $.extend({}, sy);//定义全局变量

        $(function () {
            var themeName = $.cookie("themeName"),
            themeCombo = $("#themeSelector").combobox({
                width: 140,
                editable: false,
                data: themeData,
                valueField: "path",
                textField: "name",
                value: themeName || themeData[0].path,
                onSelect: function (record) {
                    var opts = themeCombo.combobox("options");
                    sy.setTheme(record[opts.valueField]);
                }
            });

            if (themeName) {
                var $easyuiTheme = $('#easyuiTheme');
                var url = $easyuiTheme.attr('href');
                var href = url.substring(0, url.indexOf('themes')) + 'themes/' + themeName + '/easyui.css';
                $easyuiTheme.attr('href', href);
            }

            $('#mainPortal').portal({
                border: false,
                fit: true
            });

            sy.startTimer();
        });

        sy.setTheme = function (themeName) {
            var $easyuiTheme = $('#easyuiTheme');
            var url = $easyuiTheme.attr('href');
            var href = url.substring(0, url.indexOf('themes')) + 'themes/' + themeName + '/easyui.css';
            $easyuiTheme.attr('href', href);

            sy.getIframe($('iframe'), themeName);

            $.cookie('themeName', themeName, {
                expires: 7
            });
        };

        sy.getIframe = function (obj, themeName) {

            if (obj.length > 0) {
                for (var i = 0; i < obj.length; i++) {
                    var ifr = obj[i];
                    try {
                        var frameTheme = $(ifr).contents().find('#easyuiTheme');
                        var frameurl = frameTheme.attr('href');
                        var framehref = frameurl.substring(0, frameurl.indexOf('themes')) + 'themes/' + themeName + '/easyui.css';
                        frameTheme.attr('href', framehref);
                        if ($(ifr).contents().find('iframe')) {
                            sy.getIframe($(ifr).contents().find('iframe'), themeName);
                        }
                    } catch (e) {
                        try {
                            ifr.contentWindow.document.getElementById('easyuiTheme').href = href;
                        } catch (e) {
                        }
                    }
                }
            }

        }

        var timer = null;
        var timerRunning = false;

        sy.stopTimer = function () {//
            if (timerRunning)
                clearTimeout(timer);
            timerRunning = false;
        }

        sy.startTimer = function () {//
            sy.stopTimer();
            sy.showTime();
        }

        sy.showTime = function () {//时间显示
            var now = new Date();
            var hours = now.getHours();
            var minutes = now.getMinutes();
            var seconds = now.getSeconds();
            var week = now.getDay();
            var quarter = sy.getQuarter(now);
            var hoursArray = ["午夜", "凌晨", "早上", "上午", "中午", "下午", "傍晚", "晚上"];
            var weekArray = ["星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"];
            var quarterArray = ["春季", "夏季", "秋季", "冬季"];
            var timeValue = now.getFullYear() + "年" + (now.getMonth() + 1) + "月" + now.getDate() + "日 ";
            timeValue += weekArray[week] + " ";
            timeValue += quarterArray[quarter] + " ";
            timeValue += hoursArray[Math.floor(parseFloat(hours) / 3)] + " ";
            timeValue += ((hours > 12) ? hours - 12 : hours);
            timeValue += ((minutes < 10) ? ":0" : ":") + minutes;
            timeValue += ((seconds < 10) ? ":0" : ":") + seconds + " ";

            $("#timerSpan").text(timeValue);
            timer = setTimeout("sy.showTime()", 1000);
            timerRunning = true;
        }

        sy.getQuarter = function (date) {//季节
            date = sy.isDate(date) ? date : new Date(date);
            var m = date.getMonth();
            var q = 0;
            if (m >= 0 && m < 3) {
                q = 0;
            } else if (m >= 3 && m < 6) {
                q = 1;
            } else if (m >= 6 && m < 9) {
                q = 2;
            } else if (m >= 9 && m < 12) {
                q = 3;
            }
            return q;
        };

        sy.isDate = function (obj) {//判断是否为date类型
            return typeof (obj) == "date";
        };

        //$(function () {
        //    $("#xx").change(function () {
        //        $("#dx").val(toCHSnum($(this).val()));

        //    });

        //    $("#index_layout").layout("collapse", "east");
        //})

        //手风琴菜单加载
        $(function () {
            $('#index_accordion').accordion({
                fillSpace: true,
                fit: true,
                border: false,
                animate: false
            })

            $.ajax({
                url: 'datasorce/sy_menu.ashx?action=getmenutree',
                type: 'post',
                dataType: 'json',
                async: false,
                success: function (r) {
                    for (var i = 0; i < r.length; i++) {
                        var treeID = "tree" + i;
                        var divHtml = "";
                        var sub_menu = [];
                        if (r[i].pid == null) {
                            sy.GetChild(r[i].id, sub_menu, r);

                            $('#index_accordion').accordion('add', {
                                title: r[i].text,
                                content: "<ul id='" + treeID + "' ></ul>",
                                selected: true,
                                iconCls: r[i].iconCls//e.Icon
                            });


                            //divHtml = "<div title=" + r[i].text + "><ul id=" + treeID + " style='margin-top: 3px;'></div>";
                            //$('#index_accordion').append(divHtml);
                            $('#' + treeID).tree({
                                data: sub_menu,
                                parentField: 'pid',
                                lines: true,
                                onClick: function (node) {
                                    if (node.attributes.url) {
                                        sy.addTab(node.text, node.attributes.url, node.iconCls);
                                    }
                                }
                            });
                        }
                    }
                }
            });
        });

        sy.addTab = function (title, url, iconCls) {
            if ($('#index_tab').tabs('exists', title)) {
                $('#index_tab').tabs('select', title);
            } else {
                var content = '<iframe scrolling="false" frameborder="0"  src="' + url + '" style="width:100%;height:99.3%;overflow:hidden"></iframe>';
                $('#index_tab').tabs('add', {
                    title: title,
                    content: content,
                    closable: true,
                    iconCls: iconCls
                });
            }
        }

        sy.GetChild = function (id, sub_menu, r) {
            for (var j = 0; j < r.length; j++) {
                if (r[j].pid == id) {
                    sub_menu.push(r[j]);
                    sy.GetChild(r[j].id, sub_menu, r);
                }
            }
            return sub_menu;
        }
    </script>
    <style>
        body {
            font-size: 12px;
        }

        .top-left {
            position: absolute;
            width: 500px;
            height: 52px;
        }

        .top-right {
            position: absolute;
            width: 400px;
            height: 52px;
            right: 0px;
        }

            .top-right #timerSpan {
                position: absolute;
                padding-top: 5px;
                right: 10px;
            }

            .top-right #themeSpan {
                position: absolute;
                width: 350px;
                top: 24px;
                right: 5px;
                text-align: right;
            }

        #mainTab > div.tabs-header {
            border-right-width: 0px;
        }

        .floatSpan {
            float: right;
            padding-right: 5px;
            font-weight: bold;
        }

        #buttonbar {
            position: absolute;
            right: 5px;
            text-align: right;
        }

        #infobar {
            position: absolute;
            height: 20px;
            line-height: 20px;
            left: 10px;
        }
    </style>
</head>
<body class="easyui-layout" fit="true">
    <form id="form1" runat="server">
        <div data-options="region:'north'" style="height: 80px; overflow: hidden">
            <div class="easyui-layout" fit="true">
                <div data-options="region:'north',border:false" style="height: 70px">
                    <div class="top-left">
                        <h1 style="margin-left: 10px; margin-top: 10px;">库存管理系统</h1>
                    </div>
                    <div class="top-right">
                        <div id="timerSpan">
                        </div>
                        <div id="themeSpan">
                            <span>更换皮肤风格：</span>
                            <select class="easyui-combobox" id="themeSelector" style="width: 150px;">
                            </select>
                        </div>
                    </div>
                </div>
                <div data-options="region:'south',border:true" style="height: 30px">
                    <div class="panel-header panel-header-noborder top-toolbar" style="height: 30px;">
                        <div id="infobar">
                            <span class="icon-hamburg-user" style="padding-left: 25px; background-position: left center;">此处可以放置登录用户账户信息
                            </span>
                        </div>
                        <div id="buttonbar">
                            <a id="btnContact" class="easyui-linkbutton easyui-tooltip" title="前往作者关于该插件集合的博客专文；可以进行问题反馈提交或留言操作。" data-options="plain: true, iconCls: 'icon-ok'">博客留言</a>
                            <a id="btn2" class="easyui-linkbutton" data-options="plain: true, iconCls: 'icon-reload'">按钮2</a>
                            <a id="btn3" class="easyui-linkbutton" data-options="plain: true, iconCls: 'icon-print'">按钮3</a>
                            <a id="btnFullScreen" class="easyui-linkbutton" data-options="plain: true, iconCls: 'icon-help'" onclick="fullScreen()">全屏切换</a>
                            <a id="btnExit" class="easyui-linkbutton" data-options="plain: true, iconCls: 'icon-back'">退出系统</a>
                            <a id="btnShowNorth" class="easyui-linkbutton" data-options="plain: true, iconCls: 'layout-button-down'" style="display: none;"></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div data-options="region:'south',split:false,border:false" style="height: 50px;">
            <div style="color: #4e5766; padding: 6px 0px 0px 0px; margin: 0px auto; text-align: center; font-size: 12px; font-family: 微软雅黑;">
                @2014 Copyright: XiangYang Personal.
               <br />
                建议使用&nbsp;
                <a href="http://windows.microsoft.com/zh-CN/internet-explorer/products/ie/home" target="_blank" style="text-decoration: none;">IE(Version 9/10/11)</a>/
                <a href="https://www.google.com/intl/zh-CN/chrome/browser/" target="_blank" style="text-decoration: none;">Chrome</a>/
                <a href="http://firefox.com.cn/download/" target="_blank" style="text-decoration: none;">Firefox</a>
                &nbsp;系列浏览器。
            </div>
        </div>
        <%--<div data-options="region:'east',split:true" title="日历" iconcls="icon-standard-date" style="width: 180px;">
            <div class="easyui-layout" fit="true">
                <div data-options="region: 'north', split: false, border: false" style="height: 180px;">
                    <div class="easyui-calendar" data-options="fit: true"></div>
                </div>
                <div id="linkPanel" data-options="region: 'center', title: '在线用户', iconCls: 'icon-hamburg-link'">
                    <ul id="linkList" class="portlet-list link-list"></ul>
                </div>
            </div>
        </div>--%>
        <div data-options="region:'west',split:true" title="菜单导航" iconcls="icon-standard-map" style="width: 200px; overflow: auto">
            <div id="index_accordion">
            </div>
        </div>
        <div id="index_center" data-options="region: 'center', border: false" style="padding: 1px;">
            <div id="index_tab" class="easyui-tabs" border="false" fit="true">
                <div title="主页">
                    <div class="easyui-layout" fit="true">
                        <div region="south" border="false" style="height: 30px; text-align: center">
                            <div class="panel-header panel-header-noborder top-toolbar" style="height: 20px">
                                <div>
                                </div>
                            </div>
                        </div>
                        <div region="center" border="false">
                            <div id="mainPortal" style="position: relative">
                                <div style="width: 33%;">
                                    <div data-options="title: '项目信息', height: 260, collapsible: true, closable: true" style="height: 260px;">
                                        aaa
                                    </div>
                                    <div title="最新新闻" style="height: 260px; padding: 5px;">
                                        <input class="easyui-my97" type="text" />
                                    </div>
                                    <div title="最新公告" style="height: 260px; padding: 5px;">
                                        <input id="xx" class="easyui-validatebox" type="text" data-options="required:true" />
                                        <input id="dx" class="easyui-validatebox" type="text" />
                                    </div>
                                </div>
                                <div style="width: 33%;">
                                    <div title="我的待办" style="height: 260px; padding: 5px;">
                                    </div>
                                    <div title="我的日程" style="height: 260px; padding: 5px;">
                                        aa
                                    </div>
                                    <div title="最新新闻" style="height: 260px; padding: 5px;">
                                        aaa
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
