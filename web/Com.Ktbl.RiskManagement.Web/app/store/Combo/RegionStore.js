/*
 * File: app/store/Combo/RegionStore.js
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

Ext.define('RiskManagement.store.Combo.RegionStore', {
    extend: 'Ext.data.Store',

    requires: [
        'RiskManagement.model.Combo.RegionModel',
        'Ext.data.proxy.Memory'
    ],

    constructor: function(cfg) {
        var me = this;
        cfg = cfg || {};
        me.callParent([Ext.apply({
            storeId: 'Combo.RegionStore',
            model: 'RiskManagement.model.Combo.RegionModel',
            autoLoad: true,
            proxy: {
                type: 'rest',
                url: 'api/common/GetRegion',
                reader: {
                    type: 'json'
                }
            }
        }, cfg)]);
    }
});