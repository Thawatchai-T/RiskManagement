Ext.define('RiskManagement.model.MainUploads', {
    extend: 'Ext.data.Model',
    alias: 'model.mainuploads',

    requires: [
        'Ext.data.field.Number'
    ],

    fields: [
        {
            type: 'int',
            name: 'id'
        },
        {
            name: 'FileName'
        },
        {
            type: 'float',
            name: 'Status'
        },
        {
            type: 'int',
            name: 'CurrentRecode'
        },
        {
            type: 'int',
            name: 'Total'
        },
        {
            type: 'float',
            name: 'Active'
        }
    ]
});