/*
 * File: app/view/CorporationlFormViewController.js
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

Ext.define('RiskManagement.view.CorporationlFormViewController', {
    extend: 'Ext.app.ViewController',
    alias: 'controller.corporationlform',

    onSave: function(button, e, eOpts) {
        var form = this.getReferences().form,
            values = form.getForm().getValues(),
            store = this.getStore('corporationlModels');

        // Valid
        if (form.isValid()) {

            // TODO: Assign the record's ID from data source
            // Normally, this value would be auto-generated,
            // or returned from the server
            values.id = store.count() + 1;

            // Save record
            store.add(values);

            // Commit changes
            store.commitChanges();

            // Complete
            form.close();

        }
    },

    onShareholdersClick: function(button, e, eOpts) {
        Ext.widget('shareholderswindow');
    },

    onCancel: function(button, e, eOpts) {
        var form = this.getReferences().form;
        form.close();
    }

});
