<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnitConversionList.aspx.cs" Inherits="WMS.Application.BasicData.UnitConversionList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
          $(function () {
              grid = $('#unitconversion_list_grid').datagrid({
                  title: '',
                  url: '../../datasorce/ap_unitconversion.ashx?action=getunitconversionbypage',
                  striped: true,
                  rownumbers: true,
                  pagination: true,
                  singleSelect: true,
                  idField: 'ID',
                  sortName: 'OrderID',
                  sortOrder: 'asc',
                  pageSize: 10,
                  pageList: [10, 20, 30, 40, 50, 100, 200, 300, 400, 500],
                  frozenColumns: [[{
                      width: '90',
                      title: '编码',
                      field: 'Code',
                      halign: 'center',
                      align: 'center',
                      sortable: true
                  }]],
                  columns: [[{
                      width: '90',
                      title: '主计量单位',
                      field: 'MainUnitName',
                      halign: 'center',
                      align: 'center',
                      sortable: true
                  }, {
                      width: '90',
                      title: '辅计量单位',
                      field: 'AssistUnitName',
                      halign: 'center',
                      align: 'center',
                      sortable: true
                  }, {
                      width: '90',
                      title: '换算率',
                      field: 'TranslateRate',
                      halign: 'center',
                      align: 'center',
                      sortable: true
                  }, {
                      width: '220',
                      title: '描述',
                      halign: 'center',
                      field: 'Description'
                  }, {
                      width: '60',
                      title: '有效',
                      field: 'Enabled',
                      halign: 'center',
                      align: 'center',
                      formatter: function (value, row, index) {
                          if (row.Enabled) {
                              return "√";
                          } else {
                              return "×";
                          }
                      }
                  }, {
                      width: '70',
                      title: '排序号',
                      halign: 'center',
                      align: 'center',
                      field: 'OrderID'
                  }]],
                  toolbar: [{
                      iconCls: 'icon-add',
                      text: '增加',
                      handler: function () {
                          openAdd();
                      }
                  }, '-', {
                      iconCls: 'icon-save',
                      text: '查看',
                      handler: function () {
                          var row = grid.datagrid('getSelected');

                          if (row) {
                              openView(row);
                          }
                          else {
                              parent.$.messager.alert('提示', "请选择行", "info");
                          }
                      }
                  }, '-', {
                      iconCls: 'icon-edit',
                      text: '编辑',
                      handler: function () {
                          var row = grid.datagrid('getSelected');

                          if (row) {
                              openEdit(row);
                          }
                          else {
                              parent.$.messager.alert('提示', "请选择行", "info");
                          }

                      }
                  }, '-', {
                      iconCls: 'icon-cut',
                      text: '删除',
                      handler: function () {
                          var row = grid.datagrid('getSelected');

                          if (row) {
                              deleteunitconversion(row);
                          }
                          else {
                              parent.$.messager.alert('提示', "请选择行", "info");
                          }

                      }
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

          var openAdd = function () {
              var dialog = parent.sy.modalDialog({
                  iconCls: 'icon-add',
                  title: '新增计量单位换算',
                  width: 530,
                  height: 320,
                  url: 'Application/BasicData/UnitConversionAdd.aspx',
                  buttons: [{
                      text: '保存',
                      iconCls: 'icon-add',
                      handler: function () {
                          dialog.find('iframe').get(0).contentWindow.f_save(dialog, grid, parent.$);
                      }
                  }]
              });
          };

          var openEdit = function (row) {
              var dialog = parent.sy.modalDialog({
                  iconCls: 'icon-edit',
                  title: '编辑计量单位换算【当前：' + row.Code + '】',
                  width: 530,
                  height: 320,
                  url: 'Application/BasicData/UnitConversionAdd.aspx?unitconversionid=' + row.ID + '',
                  buttons: [{
                      text: '保存',
                      iconCls: 'icon-add',
                      handler: function () {
                          dialog.find('iframe').get(0).contentWindow.f_save(dialog, grid, parent.$);
                      }
                  }]
              });
          }

          var openView = function (row) {
              var dialog = parent.sy.modalDialog({
                  iconCls: 'icon-save',
                  title: '查看计量单位换算【当前：' + row.Code + '】',
                  width: 530,
                  height: 300,
                  url: 'Application/BasicData/UnitConversionAdd.aspx?unitconversionid=' + row.ID + '',
              });
          }

          var deleteunitconversion = function (row) {
              parent.$.messager.confirm('删除计量单位换算', '你确定删除计量单位换算【' + row.Code + '】吗?', function (r) {
                  if (r) {
                      $.ajax({
                          url: "../../datasorce/ap_unitconversion.ashx?action=deleteunitconversion",
                          dataType: "json",
                          type: "post",
                          data: {
                              unitconversionid: row.ID
                          },
                          success: function (jsonresult) {
                              if (jsonresult.Success) {
                                  parent.$.messager.alert('提示', jsonresult.Msg, 'info');
                                  grid.datagrid('load');
                                  grid.datagrid("unselectAll");
                              } else {
                                  parent.$.messager.alert('提示', jsonresult.Msg, 'error');
                              }
                          }
                      })
                  }
              });
          }

          var setUnitConversion = function ($dialog, $UnitConversionID, $MainUnit, $AssistUnit, $TranslateRate) {
              var row = grid.datagrid('getSelected');
              if (row) {
                  $UnitConversionID.val(row.ID);
                  $MainUnit.val(row.MainUnitName);
                  $AssistUnit.val(row.AssistUnitName);
                  $TranslateRate.val(row.TranslateRate);

                  $dialog.dialog('destroy');
              }
              else {
                  parent.$.messager.alert('提示', "请选择行", "info");
              }
          }
    </script>
</head>
<body>
   <div class="easyui-layout" fit="true">
        <div data-options="region: 'center', border: false" style="overflow: hidden; padding: 1px;">
            <div id="unitconversion_list_grid" fit="true">
            </div>
        </div>
    </div>
</body>
</html>
