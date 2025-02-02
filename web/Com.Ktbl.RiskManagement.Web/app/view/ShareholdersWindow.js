/*
 * File: app/view/ShareholdersWindow.js
 *
 * This file was generated by Sencha Architect version 3.2.0.
 * http://www.sencha.com/products/architect/
 *
 * This file requires use of the Ext JS 5.1.x library, under independent license.
 * License of Sencha Architect does not include license for Ext JS 5.1.x. For more
 * details see http://www.sencha.com/license or contact license@sencha.com.
 *
 * This file will be auto-generated each and everytime you save your project.
 *
 * Do NOT hand edit this file.
 */

Ext.define('RiskManagement.view.ShareholdersWindow', {
    extend: 'Ext.window.Window',
    alias: 'widget.shareholderswindow',

    requires: [
        'RiskManagement.view.ShareholdersWindowViewModel',
        'RiskManagement.view.ShareholdersWindowViewController',
        'Ext.form.Panel',
        'Ext.form.field.Hidden',
        'Ext.form.field.ComboBox',
        'Ext.form.FieldContainer',
        'Ext.form.field.Checkbox',
        'Ext.form.field.File',
        'Ext.button.Button',
        'Ext.grid.Panel',
        'Ext.view.Table',
        'Ext.grid.column.Column',
        'Ext.selection.CheckboxModel',
        'Ext.toolbar.Paging',
        'Ext.grid.plugin.BufferedRenderer'
    ],

    controller: 'shareholderswindow',
    viewModel: {
        type: 'shareholderswindow'
    },
    autoShow: true,
    height: 768,
    width: 780,
    layout: 'anchor',
    title: 'บริหารจัดการกรรมการและผู้ถือหุ้น',
    bodyPadding: 10,
    dockedItems: [
        {
            xtype: 'form',
            dock: 'top',
            reference: 'form',
            itemId: 'myform2',
            defaults: {
                labelAlign: 'right',
                labelWidth: 175,
                afterLabelTextTpl: '<span style="color:red;font-weight:bold" data-qtip="Required">*</span>',
                width: '100%'
            },
            bodyPadding: 10,
            title: '',
            layout: {
                type: 'table',
                columns: 2
            },
            items: [
                {
                    xtype: 'hiddenfield',
                    fieldLabel: 'ID',
                    name: 'Id',
                    value:"0"
                },
                {
                    xtype: 'hiddenfield',
                    name: 'Extension1'
                },
                {
                    xtype: 'hiddenfield',
                    name: 'Extension2'
                },
                {
                    xtype: 'hiddenfield',
                    //TODO: DEGUB
                    //xtype: 'textfield',
                    //colspan: 2,
                    fieldLabel: 'Corporation Id',
                    name: 'CorporationId'
                },
                {
                    xtype: 'combobox',
                    fieldLabel: 'ประเภทกรรมการ',
                    name: 'CommitteeType',
                    allowBlank: false,
                    autoLoadOnValue: true,
                    emptyText: '[ กรุณาเลือก ]',
                    displayField: 'Name',
                    store: 'Combo.CommitteeTypeStore',
                    valueField: 'Id'
                },
                {
                    xtype: 'textfield',
                    fieldLabel: 'เลขที่บัตรประชน',
                    name: 'CitizenId',
                    allowBlank: false,
                    emptyText: '[ 1234567890123 ]',
                    regex: /^[0-9]{13}$/
                },
                {
                    xtype: 'fieldcontainer',
                    colspan: 2,
                    width: '100%',
                    layout: 'table',
                    fieldLabel: 'ชื่อ - นามสกุล',
                    items: [
                        {
                            xtype: 'combobox',
                            margin: '0 5 0 0',
                            fieldLabel: 'คำนำหน้า',
                            hideLabel: true,
                            name: 'TitleId',
                            allowBlank: false,
                            autoLoadOnValue: true,
                            emptyText: '[ กรุณาเลือก ]',
                            displayField: 'Name',
                            store: 'Combo.TitleNameStore',

                            valueField: 'Id'
                        },
                        {
                            xtype: 'textfield',
                            margin: '0 5 0 0',
                            fieldLabel: 'ชื่อ',
                            hideLabel: true,
                            name: 'FirstName',
                            allowBlank: false,
                            emptyText: '[ ชื่อจริง ]'
                        },
                        {
                            xtype: 'textfield',
                            margin: '0 5 0 0',
                            fieldLabel: 'นามสกุล',
                            hideLabel: true,
                            name: 'LastName',
                            allowBlank: false,
                            emptyText: '[ นามสกุล ]'
                        }
                    ]
                },
                //{
                //    xtype: 'combobox',
                //    fieldLabel: 'กลุ่มอาชีพ',
                //    name: 'OccupationGroup',
                //    allowBlank: false,
                //    emptyText: '[ กรุณาเลือก ]',
                //    displayField: 'Name',
                //    store: 'Combo.OccupationGroupStore',
                //    valueField: 'Id'
                //},
                //{
                //    xtype: 'combobox',
                //    fieldLabel: 'ประเภทอาชีพ',
                //    name: 'OccupationType',
                //    allowBlank: false,
                //    emptyText: '[ กรุณาเลือก ]',
                //    displayField: 'Name',
                //    store: 'Combo.OccupationTypeStore',
                //    valueField: 'id'
                //},
                //{
                //    xtype: 'combobox',
                //    fieldLabel: 'ตำแหน่ง',
                //    name: 'Position',
                //    allowBlank: false,
                //    emptyText: '[ กรุณาเลือก ]',
                //    displayField: 'Name',
                //    store: 'Combo.PositionStore',
                //    valueField: 'Id'
                //},
                {
                    xtype: 'combobox',
                    reference: 'catelogyField',
                    fieldLabel: 'หมวดอาชีพ',
                    name: 'OccupationCategoryId',
                    emptyText: '[ เลือกหมวดอาชีพ ]',
                    displayField: 'Name',
                    editable: false,
                    store: 'Combo.OccupationCatelogyStore',
                    valueField: 'Id',
                    autoLoadOnValue: true,
                    listeners: {
                        change: 'onCatelogyChange'
                    }
                },
                {
                    xtype: 'combobox',
                    fieldLabel: 'กลุ่มอาชีพ',
                    reference: 'groupField',
                    name: 'OccupationGroupId',
                    emptyText: '[ เลือกกลุ่มอาชีพ ]',
                    displayField: 'Name',
                    store: 'Combo.OccupationGroupStore',
                    valueField: 'Id',
                    editable: false,
                    autoLoadOnValue: true,
                    listeners: {
                        change: 'onGroupChange'
                    }
                },
                {
                    xtype: 'combobox',
                    fieldLabel: 'ประเภทอาชีพ',
                    reference: 'typeField',
                    name: 'OccupationTypeId',
                    emptyText: '[ เลือกประเภทอาชีพ ]',
                    displayField: 'Name',
                    store: 'Combo.OccupationTypeStore',
                    valueField: 'Id',
                    editable: false,
                    autoLoadOnValue: true,
                    listeners: {
                        change: 'onTypeChange'
                    }
                },
                {
                    xtype: 'combobox',
                    fieldLabel: 'ตำแหน่ง',
                    reference: 'positionField',
                    name: 'PositionId',
                    emptyText: '[ เลือกตำแหน่ง ]',
                    displayField: 'Name',
                    store: 'Combo.PositionStore',
                    valueField: 'Id',
                    editable: false
                },
                {
                    xtype: 'combobox',
                    fieldLabel: 'ประเภทธุรกิจ',
                    name: 'BusinessId',
                    allowBlank: false,
                    autoLoadOnValue: true,
                    emptyText: '[ กรุณาเลือก ]',
                    displayField: 'Name',
                    store: 'Combo.BusinessTypeStore',
                    valueField: 'Id'
                },
                {
                    xtype: 'combobox',
                    fieldLabel: 'แหล่งที่มาของรายได้',
                    name: 'SourceOfIncome',
                    allowBlank: false,
                    autoLoadOnValue: true,
                    emptyText: '[ กรุณาเลือก ]',
                    displayField: 'Name',
                    store: 'Combo.SourceOfIncomeStore',
                    valueField: 'Id'
                },
                {
                    xtype: 'combobox',
                    fieldLabel: 'แหล่งที่ตั้งของรายได้',
                    name: 'LocationOfIncome',
                    allowBlank: false,
                    autoLoadOnValue: true,
                    emptyText: '[ กรุณาเลือก ]',
                    displayField: 'Name',
                    store: 'Combo.RegionStore',
                    valueField: 'Id'
                },
                {
                    xtype: 'combobox',
                    fieldLabel: 'ประเทศปัจจุบันที่พักอาศัย',
                    name: 'LiveInCountry',
                    allowBlank: false,
                    autoLoadOnValue: true,
                    emptyText: '[ กรุณาเลือก ]',
                    displayField: 'Name',
                    store: 'Combo.RegionStore',
                    valueField: 'Id'
                },
                //{
                //    xtype: 'checkboxfield',
                //    fieldLabel: 'มีความสัมพันธ์กับนักการเมือง',
                //    name: 'IsPolitician'
                //},
                {
                    xtype: 'combobox',
                    colspan: 2,
                    fieldLabel: 'ความสัมธ์กับนักการเมือง',
                    name: 'PoliticianRelationship',
                    emptyText: '[ ความสัมธ์กับนักการเมือง ]',
                    displayField: 'Name',
                    store: 'Combo.PoliticianRelationshipStore',
                    valueField: 'Id'
                },
                {
                    xtype: 'filefield',
                    colspan: 2,
                    width: '100%',
                    fieldLabel: 'หนังสือให้ความยินยอมเปิดเผยข้อมูล',
                    labelWidth: 250,
                    name: 'PathFile',
                    allowBlank: false,
                    emptyText: '[ File ]',
                    change: function (comp, value, eOpts) {
                        console.log(value);
                        console.log(comp.up('Extension2'))
                    }
                },
                {
                    xtype: 'filefield',
                    colspan: 2,
                    width: '100%',
                    fieldLabel: 'เอกสารแนบ KYC/CDD',
                    name: 'PathFile1',
                    allowBlank: false,
                    emptyText: '[ File ]',
                    change: function (comp, value, eOpts) {
                        console.log(value);
                        console.log(comp.up('Extension2'))
                    }
                },
                {
                    xtype: 'checkboxfield',
                    colspan: 2,
                    fieldLabel: 'ความยินยอม',
                    name: 'IsAccept'
                },
                {
                    xtype: 'container',
                    padding: 10,
                    layout: {
                        type: 'hbox',
                        align: 'middle',
                        pack: 'center'
                    },
                    items: [
                        {
                            xtype: 'button',
                            flex: 1,
                            formBind: true,
                            itemId: 'saveButton',
                            margin: 5,
                            text: 'Save',
                            listeners: {
                                click: 'onSave'
                            }
                        },
                        {
                            xtype: 'button',
                            flex: 1,
                            text: 'กรรมการผู้ถือหุ้น',
                            hidden: true,
                            tooltip: 'บันทึกข้อมูลกรรมการและผู้ถือหุ้น'
                        },
                        {
                            xtype: 'button',
                            flex: 1,
                            itemId: 'cancelButton',
                            margin: 5,
                            text: 'Cancel',
                            listeners: {
                                click: 'onCancel'
                            }
                        }
                    ]
                }
            ]
        }
    ],
    items: [
        {
            xtype: 'gridpanel',
            height: 350,
            scrollable: true,
            reference: 'grid',
            bind: {
                store: '{shareholdersGridViews}'
            },
            dockedItems: [
                {
                    xtype: 'toolbar',
                    dock: 'top',
                    liquidLayout: true,
                    ui: 'footer',
                    items: [
                        {
                            xtype: 'button',
                            width: 75,
                            text: 'แก้ไข',
                            listeners: {
                                click: 'onEditClick'
                            }
                        },
                        {
                            xtype: 'button',
                            width: 75,
                            text: 'ลบ',
                            listeners: {
                                click: 'onDeleteClick'
                            }
                        }
                    ]
                },
                {
                    xtype: 'pagingtoolbar',
                    dock: 'bottom',
                    width: 360,
                    displayInfo: true,
                    bind: {
                        store: '{shareholdersGridViews}'
                    }
                }
            ],
            columns: [
                {
                    xtype: 'gridcolumn',
                    width: 150,
                    dataIndex: 'CommitteeTypeName',
                    text: 'ประเภทกรรมการ'
                },
                {
                    xtype: 'gridcolumn',
                    dataIndex: 'CitizenId',
                    text: 'เลขที่บัตรประชน'
                },
                {
                    xtype: 'gridcolumn',
                    dataIndex: 'BusinessName',
                    text: 'ประเภทธุรกิจ'
                },
                {
                    xtype: 'gridcolumn',
                    dataIndex: 'OccupationTypeName',
                    text: 'ประเภทอาชีพ',
                    flex: -1
                },
                {
                    xtype: 'gridcolumn',
                    dataIndex: 'SourceOfIncomeName',
                    text: 'ที่ตั้งแหล่งที่มาของรายได้'
                },
                {
                    xtype: 'gridcolumn',
                    dataIndex: 'PoliticianRelationshipName',
                    text: 'ความสัมพันธ์กับนัการเมือง'
                }
            ],
            selModel: {
                selType: 'checkboxmodel'
            },
            plugins: [
                {
                    ptype: 'bufferedrenderer'
                }
            ],
            listeners: {
                itemdblclick: 'onGridItemDblClick'
            }
        }
    ]

});