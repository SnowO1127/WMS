<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAdd.aspx.cs" Inherits="WMS.SystemManage.User.UserAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../library/jquery-1.8.2.min.js"></script>
    <script src="../../library/jquery.easyui.min.js"></script>
    <script src="../../library/easyui-lang-zh_CN.js"></script>
    <script src="../../library/jquery.cookie.js"></script>
    <script src="../../library/My97DatePicker/WdatePicker.js"></script>
    <script src="../../library/xyEasyUI.js"></script>
    <script src="../../library/xyUtils.js"></script>
    <link id="easyuiTheme" href="../../library/themes/default/easyui.css" rel="stylesheet" />
    <link href="../../library/themes/icon.css" rel="stylesheet" />
    <title></title>
    <script>
        var id = "<%=id %>";

        $(function () {

            $('#Post').combobox({
                url: '../../datasorce/sy_itemdetail.ashx?action=getcombox&code=Post',
                valueField: 'Value',
                textField: 'Name',
                width: 153,
                panelHeight: 100,
                editable: false,
                required: true
            });

            $('#Sex').combobox({
                url: '../../datasorce/sy_itemdetail.ashx?action=getcombox&code=Gender',
                valueField: 'Value',
                textField: 'Name',
                width: 153,
                panelHeight: 60,
                editable: false,
                required: true
            });

            if (id) {
                $.ajax({
                    url: "../../datasorce/sy_user.ashx?action=getoneuser",
                    dataType: "json",
                    type: "post",
                    data: {
                        id: id
                    },
                    success: function (jsonresult) {
                        console.info(jsonresult);
                        $("#user_add_form").form('load', jsonresult);
                    }
                })
            }
        });

        var f_save = function ($dialog, $grid, $pjq) {
            if ($('#user_add_form').form('validate')) {
                var url;
                if (id) {
                    url = "../../datasorce/sy_user.ashx?action=updateuser";
                } else {
                    url = "../../datasorce/sy_user.ashx?action=adduser";
                }

                var data = sy.serializeObject($('#user_add_form'));

                sy.mergeObj(data, {
                    CompanyName: $("#Company").combotree('tree').tree('getSelected').text,
                    ChildCompanyName: $("#ChildCompany").combotree('tree').tree('getSelected').text,
                    DeptName: $("#Dept").combotree('tree').tree('getSelected').text,
                    ChildDeptName: $("#ChildDept").combotree('tree').tree('getSelected').text,
                    ClassGroupName: $("#ClassGroup").combotree('tree').tree('getSelected').text,
                })

                $.ajax({
                    url: url,
                    type: "post",
                    dataType: "json",
                    data: data,
                    success: function (jsonresult) {
                        if (jsonresult.Success) {
                            $pjq.messager.alert('提示', jsonresult.Msg, 'info');
                            $grid.datagrid('load');
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
        <form id="user_add_form" runat="server" style="font-size: 12px; padding-left: 25px; padding-top: 10px">
            <table>
                <tr>
                    <td style="width: 60px">登录名</td>
                    <td>
                        <input name="LoginName" class="easyui-validatebox" type="text" data-options="required:true" style="width: 150px" />
                        <input name="ID" type="hidden" />
                    </td>
                    <td style="width: 60px">姓名</td>
                    <td>
                        <input name="RealName" class="easyui-validatebox" data-options="required:true,validType:'chinese',tipPosition:'left'" style="width: 150px" />
                    </td>
                </tr>
                <tr>
                    <td>编号</td>
                    <td>
                        <input name="Code" class="easyui-validatebox" data-options="required:true" style="width: 150px" />
                    </td>
                    <td>拼音简写</td>
                    <td>
                        <input name="SpellQuery" class="easyui-validatebox" data-options="required:true,tipPosition:'left'" style="width: 150px" />
                    </td>
                </tr>
                <tr>
                    <td>性别</td>
                    <td>
                        <input name="Sex" id="Sex" type="text" />
                    </td>
                </tr>
                <tr>
                    <td>公司</td>
                    <td>
                        <input id="Company" name="Company" class="easyui-combotree" style="width: 153px" data-options="panelHeight:190,editable:false,idField:'id',textField:'text',parentField:'pid',url:'../../datasorce/sy_oganize.ashx?action=getoganizetree'" />
                    </td>
                    <td>子公司</td>
                    <td>
                        <input id="ChildCompany" name="ChildCompany" class="easyui-combotree" style="width: 153px" data-options="panelHeight:190,editable:false,idField:'id',textField:'text',parentField:'pid',url:'../../datasorce/sy_oganize.ashx?action=getoganizetree'" />
                    </td>
                </tr>
                <tr>
                    <td>部门</td>
                    <td>
                        <input id="Dept" name="Dept" class="easyui-combotree" style="width: 153px" data-options="panelHeight:190,editable:false,idField:'id',textField:'text',parentField:'pid',url:'../../datasorce/sy_oganize.ashx?action=getoganizetree'" />
                    </td>
                    <td>子部门</td>
                    <td>
                        <input id="ChildDept" name="ChildDept" class="easyui-combotree" style="width: 153px" data-options="panelHeight:190,editable:false,idField:'id',textField:'text',parentField:'pid',url:'../../datasorce/sy_oganize.ashx?action=getoganizetree'" />
                    </td>
                </tr>
                <tr>
                    <td>组</td>
                    <td>
                        <input id="ClassGroup" name="ClassGroup" class="easyui-combotree" style="width: 153px" data-options="panelHeight:190,editable:false,idField:'id',textField:'text',parentField:'pid',url:'../../datasorce/sy_oganize.ashx?action=getoganizetree'" />
                    </td>
                </tr>
                <tr>
                    <td>出生日期</td>
                    <td>
                        <input name="Birthday" class="easyui-my97" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" style="width: 150px" />
                    </td>
                    <td>手机号码</td>
                    <td>
                        <input name="PhoneNum" class="easyui-validatebox" data-options="validType:'mobile',tipPosition:'left'" style="width: 150px" />
                    </td>
                </tr>
                <tr>
                    <td>岗位</td>
                    <td>
                        <input name="Post" id="Post" type="text" />
                    </td>
                    <td>电话号码</td>
                    <td>
                        <input name="Tel" class="easyui-validatebox" data-options="validType:'phone',tipPosition:'left'" style="width: 150px" />
                    </td>
                </tr>
                <tr>
                    <td>邮箱</td>
                    <td>
                        <input name="Email" class="easyui-validatebox" data-options="validType:'email'" style="width: 150px" />
                    </td>
                    <td>QQ号码</td>
                    <td>
                        <input name="QQ" class="easyui-validatebox" data-options="validType:'qq',tipPosition:'left'" style="width: 150px" />
                    </td>
                </tr>
                <tr>
                    <td>地址</td>
                    <td colspan="3">
                        <input name="Address" class="easyui-validatebox" style="width: 370px" />
                    </td>
                </tr>
                <tr>
                    <td>有效</td>
                    <td>
                        <select id="Enabled" name="Enabled" class="easyui-combobox" data-options="panelHeight:50,editable:false" style="width: 153px">
                            <option value="true">是</option>
                            <option value="false">否</option>
                        </select>
                    </td>
                    <td>排序号</td>
                    <td>
                        <input name="OrderID" class="easyui-validatebox" data-options="required:true,validType:'integer',tipPosition:'left'" style="width: 150px" />
                    </td>
                </tr>
                <tr>
                    <td>备注</td>
                    <td colspan="3">
                        <textarea name="Description" id="Memo" style="width: 370px; height: 50px"></textarea>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
