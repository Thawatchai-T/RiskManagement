/*
 * File: app/model/CorporationlModel.js
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

Ext.define('RiskManagement.model.CorporationlModel', {
    extend: 'Ext.data.Model',
    alias: 'model.corporationlmodel',

    requires: [
        'Ext.data.field.Integer',
        'Ext.data.field.Boolean',
        'Ext.data.field.String'
    ],

    fields: [
        {
            type: 'int',
            name: 'id'
        },
        {
            type: 'boolean',
            name: 'Individual'
        },
        {
            type: 'string',
            name: 'Nationality'
        },
        {
            type: 'int',
            name: 'RegistrationId'
        },
        {
            type: 'boolean',
            name: 'IsRegistrationThai'
        },
        {
            type: 'int',
            name: 'RegistrationType'
        },
        {
            type: 'string',
            name: 'CompanyName'
        },
        {
            name: 'OccupationCatelogy'
        },
        {
            name: 'OccupationGroup'
        },
        {
            name: 'OccupationType'
        },
        {
            name: 'Positon'
        },
        {
            name: 'BusinessType'
        },
        {
            name: 'SourceOfIncome'
        },
        {
            name: 'LocationIncome'
        },
        {
            name: 'LiveInCountry'
        },
        {
            type: 'boolean',
            name: 'IsPolitician'
        },
        {
            name: 'Tsic'
        },
        {
            name: 'File1'
        },
        {
            name: 'File2'
        },
        {
            type: 'boolean',
            name: 'IsAccept'
        },
        {
            name: 'Position'
        }
    ]
});