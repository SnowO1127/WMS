<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuAdd.aspx.cs" Inherits="WMS.SystemManage.Menu.MenuAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../library/jquery.min.js"></script>
    <script src="../../library/jquery.easyui.min.js"></script>
    <script src="../../library/locale/easyui-lang-zh_CN.js"></script>
    <script src="../../library/jquery.cookie.js"></script>
    <script src="../../library/xyEasyUI.js"></script>
    <script src="../../library/xyUtils.js"></script>
    <link id="easyuiTheme" href="../../library/themes/bootstrap/easyui.css" rel="stylesheet" />
    <link href="../../library/themes/icon.css" rel="stylesheet" />
    <link href="../../library/base_css/ui.css" rel="stylesheet" />
    <link href="../../library/syExtCss.css" rel="stylesheet" />
    <link href="../../library/syExtIcon.css" rel="stylesheet" />
    <link href="../../library/MyCss.css" rel="stylesheet" />
    <title></title>
    <script>
        var sy = sy || {};
        sy.pixel_0 = '../../library/images/pixel_0.gif';//0像素的背景，一般用于占位

        var menuid = "<%=menuid %>";

        var showIcons = function () {
            var dialog = parent.sy.modalDialog({
                title: '浏览小图标',
                url: 'SystemManage/Menu/Icons.aspx',
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

        $(function () {
            $('#Category').combobox({
                url: '../../datasorce/sy_itemdetail.ashx?action=getCombox&code=MenuCategory',
                valueField: 'Value',
                textField: 'Name',
                width: 150,
                height: 26,
                panelHeight: 60,
                required: true,
                loadFilter: function (data) {
                    if (data.Success) {
                        return data.Obj;
                    } else {
                        parent.$.messager.alert('提示', data.Msg, 'error');
                    }
                }
            });

            parentID = $("#ParentID").combotree({
                panelHeight: 190,
                editable: false,
                idField: 'id',
                textField: 'text',
                parentField: 'pid',
                icons: [{
                    iconCls: 'icon-clear',
                    handler: function (e) {
                        $(e.data.target).combotree('clear');
                    }
                }]
            });

            loadParentTree();

            if (menuid) {
                $.ajax({
                    url: "../../datasorce/sy_menu.ashx?action=getMenuByID",
                    dataType: "json",
                    type: "post",
                    data: {
                        MenuID: menuid
                    },
                    success: function (jr) {
                        if (jr.Success) {

                            $("#menu_add_form").form('load', jr.Obj);

                            $('#IconCls').attr('class', jr.Obj.IconCls);//设置背景图标

                            if (jr.Obj.ParentID) {
                                $('#ParentID').combotree('setValue', jr.Obj.ParentID);
                            }
                            else {
                                $('#ParentID').combotree('setValue', "");
                            }
                        }
                        else {
                            $.messager.alert("错误", jr.Msg, "error");
                        }
                    }
                })
            }
        });

        var loadParentTree = function () {
            $.ajax({
                url: '../../datasorce/sy_menu.ashx?action=getIsMenu',
                dataType: 'json',
                type: "post",
                beforeSend: function () {
                    $.messager.progress({
                        text: '正在加载......'
                    });
                },
                success: function (data) {
                    $.messager.progress('close');

                    if (data.Success) {
                        parentID.combotree("loadData", data.Obj);
                    }
                    else {
                        parent.$.messager.alert('错误', data.Msg, "error");
                    }
                }
            })
        }

        var f_save = function ($dialog, $grid, $loadMenuTree, $pjq) {
            if ($('#menu_add_form').form('validate')) {
                var url;
                if (menuid) {
                    url = "../../datasorce/sy_menu.ashx?action=Update";
                } else {
                    url = "../../datasorce/sy_menu.ashx?action=Insert";
                }
                $.ajax({
                    url: url,
                    type: "post",
                    dataType: "json",
                    data: sy.serializeObject($('#menu_add_form')),
                    success: function (jsonresult) {
                        if (jsonresult.Success) {
                            $pjq.messager.alert('提示', jsonresult.Msg, 'info');
                            $grid.datagrid('reload');
                            $loadMenuTree();
                            $dialog.dialog('destroy');
                        } else {
                            $pjq.messager.alert('提示', jsonresult.Msg, 'error');
                        }
                    }
                });
            }
        };
    </script>
</head>
<body>
    <div style="margin: 0 auto">
        <form id="menu_add_form" style="font-size: 13px; padding-top: 10px">
            <table style="width: 100%">
                <tr>
                    <td class="tb_td_lable" style="width: 80px">菜单名称</td>
                    <td class="tb_td" colspan="3">
                        <input name="MenuName" class="easyui-textbox" type="text" data-options="required:true" style="width: 150px; height: 26px" />
                        <input name="ID" type="hidden" />
                    </td>
                </tr>
                <tr>
                    <td class="tb_td_lable">分类</td>
                    <td class="tb_td">
                        <input name="Category" id="Category" type="text" style="width: 150px; height: 26px" />
                    </td>
                </tr>
                <tr>
                    <td class="tb_td_lable">上级菜单</td>
                    <td class="tb_td" colspan="3">
                        <input id="ParentID" name="ParentID" class="easyui-combotree" style="width: 150px; height: 26px" data-options="" />
                    </td>
                </tr>
                <tr>
                    <td class="tb_td_lable">地址</td>
                    <td class="tb_td" colspan="3">
                        <input name="MenuUrl" class="easyui-textbox" type="text" style="width: 415px; height: 26px" />
                    </td>
                </tr>
                <tr>
                    <td class="tb_td_lable">图标</td>
                    <td class="tb_td">
                        <input id="IconCls" name="IconCls" class="easyui-textbox" readonly="readonly" style="width: 150px; height: 26px" />
                    </td>
                    <td class="tb_td">
                        <img class="iconImg ext-icon-zoom" onclick="showIcons();" title="浏览图标" />&nbsp;
                        <img class="iconImg ext-icon-cross" onclick="$('#iconCls').val('');$('#iconCls').attr('class','');" title="清空" /></td>
                </tr>
                <tr>
                    <td class="tb_td_lable">有效</td>
                    <td class="tb_td">
                        <select id="Enabled" class="easyui-combobox" data-options="panelHeight:50,editable:false" name="Enabled" style="width: 150px; height: 26px">
                            <option value="true">是</option>
                            <option value="false">否</option>
                        </select>
                    </td>
                    <td class="tb_td_lable">排序号
                    </td>
                    <td class="tb_td">
                        <input id="OrderID" name="OrderID" class="easyui-textbox" data-options="required:true,validType:'integer',tipPosition:'left'" style="width: 150px; height: 26px" />
                    </td>
                </tr>
                <tr>
                    <td class="tb_td_lable">是否公开</td>
                    <td class="tb_td">
                        <select id="IsPublic" class="easyui-combobox" data-options="panelHeight:50,editable:false" name="IsPublic" style="width: 150px; height: 26px">
                            <option value="true">是</option>
                            <option value="false">否</option>
                        </select>
                    </td>
                    <td class="tb_td_lable" style="width: 80px">是否菜单</td>
                    <td class="tb_td">
                        <select id="IsMenu" class="easyui-combobox" data-options="panelHeight:50,editable:false" name="IsMenu" style="width: 150px; height: 26px">
                            <option value="true">是</option>
                            <option value="false">否</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td class="tb_td_lable">允许编辑</td>
                    <td class="tb_td">
                        <select id="AllowEdit" class="easyui-combobox" data-options="panelHeight:50,editable:false" name="AllowEdit" style="width: 150px; height: 26px">
                            <option value="true">是</option>
                            <option value="false">否</option>
                        </select>
                    </td>
                    <td class="tb_td_lable">允许删除</td>
                    <td class="tb_td">
                        <select id="AllowDelete" class="easyui-combobox" data-options="panelHeight:50,editable:false" name="AllowDelete" style="width: 150px; height: 26px">
                            <option value="true">是</option>
                            <option value="false">否</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td class="tb_td_lable">描述</td>
                    <td class="tb_td" colspan="3">
                        <input name="Description" class="easyui-textbox" data-options="multiline:true,height:50" style="width: 415px" />
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
