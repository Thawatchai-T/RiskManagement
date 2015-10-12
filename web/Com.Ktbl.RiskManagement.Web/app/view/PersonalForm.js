Ext.define('RiskManagement.view.PersonalForm', {
    extend: 'Ext.panel.Panel',
    alias: 'widget.personalform',

    requires: [
        'RiskManagement.view.PersonalFormViewModel',
        'RiskManagement.view.PersonalFormViewController',
        'Ext.form.Panel',
        'Ext.form.field.Hidden',
        'Ext.form.field.Checkbox',
        'Ext.form.field.Number',
        'Ext.form.FieldContainer',
        'Ext.form.field.ComboBox',
        'Ext.form.field.File',
        'Ext.button.Button'
    ],

    controller: 'personalform',
    viewModel: {
        type: 'personalform'
    },
    autoShow: true,
    itemId: 'tab1',
    bodyPadding: 25,
    title: 'บุคคลธรรมดา',
    reference: 'window',

    items: [
        {
            xtype: 'form',
            reference: 'form',
            itemId: 'myForm1',
            width: 750,
            defaults: {
                labelWidth: 175,
                labelAlign: 'right',
                margin: '5 5 5 5',
                afterLabelTextTpl: '<span style="color:red;font-weight:bold" data-qtip="Required">*</span>',
                width: '95%'
            },
            bodyPadding: 10,
            title: 'สืบค้นบุคคลธรรมดา',
            titleAlign: 'center',
            layout: {
                type: 'table',
                columns: 2
            },
            items: [
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
                    reference: 'appkey',
                    name: 'AppKey'
                },
                {
                    xtype: 'hiddenfield',
                    reference: 'user',
                    name: 'UserId'
                },
                {
                    xtype: 'hiddenfield',
                    reference: 'requestno',
                    name: 'RequestNo'
                },
                {
                    xtype: 'checkboxfield',
                    colspan: 2,
                    fieldLabel: 'ประเภทบุคคล',
                    name: 'Individual',
                    checked: true,
                    readOnly: true
                },
                {
                    xtype: 'textfield',
                    colspan: 2,
                    width: 450,
                    fieldLabel: 'เลขที่บัตรประชาชน',
                    name: 'CitizenId',
                    allowBlank: false,
                    emptyText: ' บัตรประชาชน หรือ หนังสือเดินทาง',
                    //maxLength: 13,
                    //minLength: 1
                },
                {
                    xtype: 'fieldcontainer',
                    colspan: 2,
                    width: '100%',
                    layout: 'table',
                    fieldLabel: 'ชื่อ',
                    items: [
                        {
                            xtype: 'combobox',
                            margin: '0 5 0 0',
                            width: 93,
                            fieldLabel: 'คำนำหน้าชื่อ',
                            hideLabel: true,
                            queryMode: 'local',
                            name: 'TitleId',
                            allowBlank: false,
                            emptyText: '[ คำนำหน้า ]',
                            displayField: 'Name',
                            store: 'Combo.TitleNameStore',
                            valueField: 'Id'
                        },
                        {
                            xtype: 'textfield',
                            margin: '0 5 0 0',
                            fieldLabel: 'ชื่อจริง',
                            hideLabel: true,
                            name: 'FirstName',
                            allowBlank: false,
                            emptyText: '[ ชื่อจริง ]',
                            maxLength: 30,
                            minLength: 2
                        },
                        {
                            xtype: 'textfield',
                            margin: '0 5 0 0',
                            fieldLabel: 'นามสกุล',
                            hideLabel: true,
                            name: 'LastName',
                            allowBlank: false,
                            emptyText: '[ นามสกุล ]',
                            maxLength: 30,
                            minLength: 2
                        }
                    ]
                },
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
                    emptyText: '[ เลือกประเภทธุรกิจ ]',
                    displayField: 'Name',
                    queryMode: 'local',
                    store: 'Combo.BusinessTypeStore',
                    valueField: 'Id'
                },
                {
                    xtype: 'combobox',
                    fieldLabel: 'แหล่งที่มาของรายได้',
                    name: 'SourceOfIncome',
                    emptyText: '[ แหล่งที่มาของรายได้ ]',
                    displayField: 'Name',
                    store: 'Combo.SourceOfIncomeStore',
                    valueField: 'Id'
                },
                {
                    xtype: 'combobox',
                    fieldLabel: 'แหล่งที่ตั้งของรายได้',
                    name: 'LocationOfIncome',
                    emptyText: '[ แหล่งที่ตั้งของรายได้ ]',
                    queryMode: 'local',
                    displayField: 'Name',
                    store: 'Combo.RegionStore',
                    valueField: 'Id'
                },
                {
                    xtype: 'combobox',
                    fieldLabel: 'อาศัยอยู่ในประเทศ',
                    name: 'LiveInCountry',
                    emptyText: '[ เลือกประเทศ ]',
                    displayField: 'Name',
                    queryMode: 'local',
                    store: 'Combo.RegionStore',
                    valueField: 'Id'
                },
                {
                    xtype: 'combobox',
                    fieldLabel: 'ความสัมธ์กับนักการเมือง',
                    name: 'PoliticianRelationship',
                    colspan: 2,
                    emptyText: '[ ความสัมธ์กับนักการเมือง ]',
                    displayField: 'Name',
                    queryMode: 'local',
                    store: 'Combo.PoliticianRelationshipStore',
                    valueField: 'Id'
                },
                {
                    xtype: 'filefield',
                    reference: 'file1Field',
                    colspan: 2,
                    fieldLabel: 'หนังสือความยินยอม ในการเปิดเผยข้อมูล',
                    labelWidth: 300,
                    name: 'files',
                    emptyText: '[ File ]',
                    allowBlank: false,
                    listeners: {
                        change: function (comp, value, eOpts) {
                            var pos = value.lastIndexOf('.'),
                                ext = value.substring(pos);
                            comp.up().getForm().findField('Extension1').setValue(ext);
                        }
                    }
                },
                {
                    xtype: 'filefield',
                    colspan: 2,
                    reference: 'file2Field',
                    fieldLabel: 'เอกสารแนบ KYC/CDD',
                    name: 'files',
                    emptyText: '[ File ]',
                    allowBlank: false,
                    listeners: {
                        change: function (comp, value, eOpts) {
                            //console.log(String.inde value);
                            var pos = value.lastIndexOf('.'),
                                ext = value.substring(pos);
                            comp.up().getForm().findField('Extension2').setValue(ext);
                        }
                    }
                },
                {
                    xtype: 'radiogroup',
                    fieldLabel: 'ความยินยอม',
                    colspan: 2,
                    itemId:'is-accept',
                    items: [
                        {
                            xtype: 'radiofield',
                            name: 'IsAccept',
                            boxLabel: 'ยอมรับ',
                            varlue: 0,
                            margin: '0 5 0 5'
                        },
                        {
                            xtype: 'radiofield',
                            name: 'IsAccept',
                            boxLabel: 'ไม่ยอมรับ',
                            checked: true,
                            width: 150,
                            varlue:0,
                            margin: '0 5 0 5'
                        }
                    ]
                },
                //{
                //    xtype: 'checkboxfield',
                //    colspan: 2,
                //    fieldLabel: 'ความยินยอม',
                //    name: 'IsAccept'
                //},
                {
                    xtype: 'container',
                    colspan: 2,
                    padding: 10,
                    width: '100%',
                    layout: {
                        type: 'hbox',
                        align: 'bottom',
                        pack: 'center'
                    },
                    items: [
                        {
                            xtype: 'fieldcontainer',
                            minWidth: 250,
                            width: 250,
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
                                    text: 'Find',
                                    listeners: {
                                        click: 'onSave'
                                    }
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
            listeners: {
                beforerender: 'onBeforeRender'
            }
        }
    ]

});