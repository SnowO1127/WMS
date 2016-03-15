<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="unit_add.aspx.cs" Inherits="WMS.SystemManage.Unit.unit_add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../../library/jquery-1.9.1.min.js"></script>
    <script src="../../library/jquery.easyui.min.js"></script>
    <script src="../../library/easyui-lang-zh_CN.js"></script>
    <script src="../../library/jquery.cookie.js"></script>
    <script src="../../library/xyEasyUI.js"></script>
    <script src="../../library/xyUtils.js"></script>
    <link id="easyuiTheme" href="../../library/themes/default/easyui.css" rel="stylesheet" />
    <link href="../../library/themes/icon.css" rel="stylesheet" />
    <link href="../../library/base_css/ui.css" rel="stylesheet" />
    <script>
        var id = "<%=id %>";
        var treeid = "<%=treeid %>";
        $(function () {
            if (id) {
                $.ajax({
                    url: "../../datasorce/sy_unit.ashx?action=getoneunit",
                    dataType: "json",
                    type: "post",
                    data: {
                        id: id
                    },
                    success: function (jsonresult) {
                        $("#unit_add_form").form('load', jsonresult);
                    }
                })
            }

            if (treeid) {
                $("#pid").combotree("setValue", treeid);
            }
        });


        var f_save = function ($treeid, $tree, $dialog, $grid, $pjq) {
            if ($('#unit_add_form').form('validate')) {
                var url;
                if (id) {
                    url = "../../datasorce/sy_unit.ashx?action=updateunit";
                } else {
                    url = "../../datasorce/sy_unit.ashx?action=addunit";
                }
                $.ajax({
                    url: url,
                    type: "post",
                    dataType: "json",
                    async: false,
                    data: $('#unit_add_form').serializeArray(),
                    success: function (jsonresult) {
                        if (id) {
                            if (jsonresult.success) {
                                $pjq.messager.alert('提示', jsonresult.msg, 'info');
                                $grid.datagrid('load');
                                $dialog.dialog('destroy');
                                // 更新选择的节点文本
                                var node = $tree.tree('find', jsonresult.obj.id);
                                if (node) {
                                    $tree.tree('update', {
                                        target: node.target,
                                        text: jsonresult.obj.name
                                    });
                                }
                            }
                            else {
                                $pjq.messager.alert('提示', jsonresult.msg, 'error');
                            }
                        }
                        else {
                            if (jsonresult.success) {
                                $pjq.messager.alert('提示', jsonresult.msg, 'info');
                                $grid.datagrid('load');
                                $dialog.dialog('destroy');
                                // 追加若干个节点并选中他们
                                var selected = $tree.tree('getSelected');
                                $tree.tree('append', {
                                    parent: selected.target,
                                    data: [{
                                        id: jsonresult.obj.id,
                                        text: jsonresult.obj.name
                                    }]
                                });
                            }
                            else {
                                $pjq.messager.alert('提示', jsonresult.msg, 'error');
                            }
                        }
                    }
                });
            }
        };

    </script>
</head>
<body>
    <div class="easyui-layout" fit="true">
        <form id="unit_add_form" style="font-size: 13px">
            <fieldset>
                <legend>单位信息</legend>
                <table>
                    <tr>
                        <td>名称</td>
                        <td>
                            <input name="id" type="hidden" />
                            <input name="name" class="easyui-validatebox" type="text" data-options="required:true" />
                        </td>
                        <td>上级单位</td>
                        <td>
                            <input id="pid" name="pid" class="easyui-combotree" data-options="panelHeight:150,editable:false,idField:'id',textField:'name',parentField:'pid',url:'../../datasorce/sy_unit.ashx?action=getallunit'" />
                            <img style="cursor: pointer; vertical-align: middle" src="../../library/themes/icons/no.png" onclick="$('#pid').combotree('clear')" title="清空" />
                        </td>
                    </tr>
                    <tr>
                        <td>单位类型</td>
                        <td>
                            <input id="type_id" name="type_id" class="easyui-combotree" data-options="panelHeight:120,editable:false,idField:'id',textField:'name',parentField:'pid',url:'../../datasorce/sy_unit.ashx?action=getunit'" />
                            <img style="cursor: pointer; vertical-align: middle" src="../../library/themes/icons/no.png" onclick="$('#type_id').combotree('clear')" title="清空" />
                        </td>
                        <td>邮编</td>
                        <td>
                            <input name="zipcode" class="easyui-validatebox" />
                        </td>
                    </tr>
                    <tr>
                        <td>地址</td>
                        <td colspan="3">
                            <input name="address" class="easyui-validatebox" style="width: 93%" />
                        </td>
                    </tr>
                    <tr>
                        <td>联系人</td>
                        <td>
                            <input name="contactor" class="easyui-validatebox" />
                        </td>
                        <td>联系电话</td>
                        <td>
                            <input name="contactorphone" class="easyui-validatebox" />
                        </td>
                    </tr>
                    <tr>
                        <td>传真</td>
                        <td>
                            <input name="fax" class="easyui-validatebox" />
                        </td>
                        <td>法人</td>
                        <td>
                            <input name="corporation" class="easyui-validatebox" />
                        </td>

                    </tr>
                    <tr>
                        <td>独立法人</td>
                        <td>
                            <select id="isincorporation" class="easyui-combobox" data-options="panelHeight:30,editable:false" name="isincorporation" style="width: 155px">
                                <option value="1">是</option>
                                <option value="0">否</option>
                            </select>
                        </td>
                        <td>排序号</td>
                        <td>
                            <input name="unitorder" class="easyui-validatebox" />
                        </td>
                    </tr>
                    <tr>
                        <td>备注</td>
                        <td colspan="3">
                            <input name="remark" class="easyui-validatebox" style="width: 93%" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </form>
    </div>
</body>
</html>
