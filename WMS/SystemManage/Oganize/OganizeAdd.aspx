<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OganizeAdd.aspx.cs" Inherits="WMS.SystemManage.Oganize.OganizeAdd" %>

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
        var oganizeid = "<%=oganizeid %>";

        $(function () {

            $('#Category').combobox({
                url: '../../datasorce/sy_itemdetail.ashx?action=getcombox&code=OganizeCategory',
                valueField: 'Value',
                textField: 'Name',
                width: 133,
                panelHeight: 100,
                editable: false,
                tipPosition: 'left',
                required: true
            });

            $('#ManagerID').combogrid({
                delay: 500,
                mode: 'remote',
                width: 133,
                panelWidth: 330,
                panelHeight: 155,
                idField: 'ID',
                textField: 'RealName',

                url: '../../datasorce/sy_user.ashx?action=getuserlistbyspell',
                striped: true,
                rownumbers: true,
                pagination: true,
                singleSelect: true,
                sortName: 'OrderID',
                sortOrder: 'asc',
                pageSize: 10,
                pageList: [10, 20, 30, 40, 50, 100, 200, 300, 400, 500],
                columns: [[{
                    width: '70',
                    title: '姓名',
                    field: 'RealName',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '60',
                    title: '编号',
                    field: 'Code',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '70',
                    title: '拼音简写',
                    field: 'SpellQuery',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '60',
                    title: '性别',
                    field: 'Sex',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }]]
            });

            $('#AssistantManagerID').combogrid({
                delay: 500,
                mode: 'remote',
                width: 133,
                panelWidth: 330,
                panelHeight: 155,
                idField: 'ID',
                textField: 'RealName',

                url: '../../datasorce/sy_user.ashx?action=getuserlistbyspell',
                striped: true,
                rownumbers: true,
                pagination: true,
                singleSelect: true,
                sortName: 'OrderID',
                sortOrder: 'asc',
                pageSize: 10,
                pageList: [10, 20, 30, 40, 50, 100, 200, 300, 400, 500],
                columns: [[{
                    width: '70',
                    title: '姓名',
                    field: 'RealName',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '60',
                    title: '编号',
                    field: 'Code',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '70',
                    title: '拼音简写',
                    field: 'SpellQuery',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }, {
                    width: '60',
                    title: '性别',
                    field: 'Sex',
                    halign: 'center',
                    align: 'center',
                    sortable: true
                }]]
            });


            if (oganizeid) {
                $.ajax({
                    url: "../../datasorce/sy_oganize.ashx?action=getoneoganize",
                    dataType: "json",
                    type: "post",
                    data: {
                        oganizeid: oganizeid
                    },
                    success: function (jsonresult) {
                        $("#oganize_add_form").form('load', jsonresult);

                        if (jsonresult.ParentID) {
                            $('#ParentID').combotree('setValue', jsonresult.ParentID);
                        }
                        else {
                            $('#ParentID').combotree('setValue', "");
                        }
                    }
                })
            }
        });

        var f_save = function ($dialog, $grid, $tree, $pjq) {
            if ($('#oganize_add_form').form('validate')) {
                var url;
                if (oganizeid) {
                    url = "../../datasorce/sy_oganize.ashx?action=updateoganize";
                } else {
                    url = "../../datasorce/sy_oganize.ashx?action=addoganize";
                }

                var data = sy.serializeObject($('#oganize_add_form'));

                sy.mergeObj(data, {
                    ManagerName: $("#ManagerID").combogrid('grid').datagrid('getSelected').RealName,
                    AssistantManagerName: $("#AssistantManagerID").combogrid('grid').datagrid('getSelected').RealName
                });

                $.ajax({
                    url: url,
                    type: "post",
                    dataType: "json",
                    data: data,
                    success: function (jsonresult) {
                        if (jsonresult.Success) {
                            $pjq.messager.alert('提示', jsonresult.Msg, 'info');
                            $grid.datagrid('load');
                            $tree.tree("reload");
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
    <div class="easyui-layout" fit="true">
        <form id="oganize_add_form" style="font-size: 12px; padding-left: 25px; padding-top: 10px">
            <table>
                <tr>
                    <td style="width: 80px">组织机构名称</td>
                    <td>
                        <input name="Name" class="easyui-validatebox" type="text" data-options="required:true" style="width: 130px" />
                        <input name="ID" type="hidden" />
                    </td>
                    <td style="width: 80px">分类</td>
                    <td>
                        <input name="Category" id="Category" type="text" />
                    </td>
                </tr>
                <tr>
                    <td>编码</td>
                    <td>
                        <input name="Code" class="easyui-validatebox" type="text" style="width: 130px" />
                    </td>
                    <td>父节点</td>
                    <td>
                        <input id="ParentID" name="ParentID" class="easyui-combotree" style="width: 133px" data-options="panelHeight:190,editable:false,idField:'id',textField:'text',parentField:'pid',url:'../../datasorce/sy_oganize.ashx?action=getoganizetree'" />
                        <img style="cursor: pointer; vertical-align: middle" src="../../library/themes/icons/no.png" onclick="$('#ParentID').combotree('clear')" title="清空" />
                    </td>
                </tr>
                <tr>
                    <td>主负责人
                    </td>
                    <td>
                        <input name="ManagerID" id="ManagerID" type="text" />
                    </td>
                    <td>副主管
                    </td>
                    <td>
                        <input name="AssistantManagerID" id="AssistantManagerID" type="text" />
                    </td>
                </tr>
                <tr>
                    <td>电话
                    </td>
                    <td>
                        <input name="Tel" class="easyui-validatebox" type="text" data-options="validType:'phone'" style="width: 130px" />
                    </td>
                    <td>传真
                    </td>
                    <td>
                        <input name="Fax" class="easyui-validatebox" type="text" data-options="validType:'faxno',tipPosition:'left'" style="width: 130px" />
                    </td>
                </tr>
                <tr>
                    <td>邮编
                    </td>
                    <td>
                        <input name="PostCode" class="easyui-validatebox" data-options="validType:'zip'" type="text" style="width: 130px" />
                    </td>
                    <td>网址
                    </td>
                    <td>
                        <input name="WebUrl" class="easyui-validatebox" type="text" style="width: 130px" />
                    </td>
                </tr>
                <tr>
                    <td>地址
                    </td>
                    <td colspan="3">
                        <input name="Address" class="easyui-validatebox" type="text" style="width: 350px" />
                    </td>
                </tr>
                <tr>
                    <td>有效</td>
                    <td>
                        <select id="Enabled" class="easyui-combobox" data-options="panelHeight:50,editable:false" name="Enabled" style="width: 133px">
                            <option value="true">是</option>
                            <option value="false">否</option>
                        </select>
                    </td>
                    <td>排序号</td>
                    <td>
                        <input name="OrderID" class="easyui-validatebox" data-options="required:true,validType:'integer',tipPosition:'left'" style="width: 130px" />
                    </td>
                </tr>
                <tr>
                    <td>描述</td>
                    <td colspan="3">
                        <textarea name="Description" id="Description" style="width: 350px; height: 50px"></textarea>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
