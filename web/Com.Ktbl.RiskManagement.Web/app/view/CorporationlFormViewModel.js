/*
 * File: app/view/CorporationlFormViewModel.js
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

Ext.define('RiskManagement.view.CorporationlFormViewModel', {
    extend: 'Ext.app.ViewModel',
    alias: 'viewmodel.corporationlform',

    requires: [
        'Ext.data.Store',
        'Ext.data.proxy.Memory'
    ],

    stores: {
        corporationlModels: {
            model: 'RiskManagement.model.CorporationlModel',
            data: [
                {
                    id: 674,
                    Individual: true,
                    Nationality: 'non',
                    RegistrationId: 153,
                    IsRegistrationThai: false,
                    RegistrationType: 861,
                    CompanyName: 'possimus',
                    OccupationCatelogy: 'dicta',
                    OccupationGroup: 'cupiditate',
                    OccupationType: 'sapiente',
                    Positon: 'vel',
                    BusinessType: 'animi',
                    SourceOfIncome: 'laborum',
                    LocationIncome: 'soluta',
                    LiveInCountry: 'itaque',
                    IsPolitician: false,
                    Tsic: 'impedit',
                    File1: 'qui',
                    File2: 'doloribus',
                    IsAccept: false
                },
                {
                    id: 734,
                    Individual: false,
                    Nationality: 'eos',
                    RegistrationId: 477,
                    IsRegistrationThai: true,
                    RegistrationType: 874,
                    CompanyName: 'ab',
                    OccupationCatelogy: 'perferendis',
                    OccupationGroup: 'similique',
                    OccupationType: 'quae',
                    Positon: 'vel',
                    BusinessType: 'illum',
                    SourceOfIncome: 'commodi',
                    LocationIncome: 'dolore',
                    LiveInCountry: 'quos',
                    IsPolitician: true,
                    Tsic: 'nulla',
                    File1: 'beatae',
                    File2: 'eos',
                    IsAccept: false
                },
                {
                    id: 620,
                    Individual: true,
                    Nationality: 'quasi',
                    RegistrationId: 306,
                    IsRegistrationThai: false,
                    RegistrationType: 325,
                    CompanyName: 'sit',
                    OccupationCatelogy: 'amet',
                    OccupationGroup: 'nisi',
                    OccupationType: 'esse',
                    Positon: 'sint',
                    BusinessType: 'reprehenderit',
                    SourceOfIncome: 'deserunt',
                    LocationIncome: 'eveniet',
                    LiveInCountry: 'necessitatibus',
                    IsPolitician: true,
                    Tsic: 'veniam',
                    File1: 'dolores',
                    File2: 'pariatur',
                    IsAccept: false
                },
                {
                    id: 449,
                    Individual: true,
                    Nationality: 'voluptatem',
                    RegistrationId: 662,
                    IsRegistrationThai: false,
                    RegistrationType: 392,
                    CompanyName: 'aut',
                    OccupationCatelogy: 'earum',
                    OccupationGroup: 'et',
                    OccupationType: 'voluptates',
                    Positon: 'occaecati',
                    BusinessType: 'est',
                    SourceOfIncome: 'maiores',
                    LocationIncome: 'incidunt',
                    LiveInCountry: 'dignissimos',
                    IsPolitician: true,
                    Tsic: 'laboriosam',
                    File1: 'alias',
                    File2: 'delectus',
                    IsAccept: false
                },
                {
                    id: 824,
                    Individual: false,
                    Nationality: 'est',
                    RegistrationId: 274,
                    IsRegistrationThai: false,
                    RegistrationType: 532,
                    CompanyName: 'id',
                    OccupationCatelogy: 'inventore',
                    OccupationGroup: 'numquam',
                    OccupationType: 'architecto',
                    Positon: 'labore',
                    BusinessType: 'praesentium',
                    SourceOfIncome: 'saepe',
                    LocationIncome: 'reiciendis',
                    LiveInCountry: 'sit',
                    IsPolitician: true,
                    Tsic: 'dolores',
                    File1: 'est',
                    File2: 'voluptas',
                    IsAccept: false
                },
                {
                    id: 85,
                    Individual: true,
                    Nationality: 'nobis',
                    RegistrationId: 667,
                    IsRegistrationThai: false,
                    RegistrationType: 324,
                    CompanyName: 'quia',
                    OccupationCatelogy: 'commodi',
                    OccupationGroup: 'et',
                    OccupationType: 'voluptate',
                    Positon: 'tempore',
                    BusinessType: 'perspiciatis',
                    SourceOfIncome: 'et',
                    LocationIncome: 'et',
                    LiveInCountry: 'quaerat',
                    IsPolitician: true,
                    Tsic: 'enim',
                    File1: 'reprehenderit',
                    File2: 'aliquam',
                    IsAccept: true
                },
                {
                    id: 844,
                    Individual: false,
                    Nationality: 'illum',
                    RegistrationId: 419,
                    IsRegistrationThai: false,
                    RegistrationType: 34,
                    CompanyName: 'voluptas',
                    OccupationCatelogy: 'quis',
                    OccupationGroup: 'vitae',
                    OccupationType: 'dolores',
                    Positon: 'omnis',
                    BusinessType: 'quae',
                    SourceOfIncome: 'dolor',
                    LocationIncome: 'necessitatibus',
                    LiveInCountry: 'labore',
                    IsPolitician: false,
                    Tsic: 'et',
                    File1: 'illum',
                    File2: 'eveniet',
                    IsAccept: true
                },
                {
                    id: 134,
                    Individual: true,
                    Nationality: 'qui',
                    RegistrationId: 353,
                    IsRegistrationThai: true,
                    RegistrationType: 669,
                    CompanyName: 'est',
                    OccupationCatelogy: 'dolorem',
                    OccupationGroup: 'sed',
                    OccupationType: 'distinctio',
                    Positon: 'placeat',
                    BusinessType: 'similique',
                    SourceOfIncome: 'et',
                    LocationIncome: 'ut',
                    LiveInCountry: 'consequatur',
                    IsPolitician: false,
                    Tsic: 'tempora',
                    File1: 'voluptatem',
                    File2: 'deserunt',
                    IsAccept: true
                },
                {
                    id: 376,
                    Individual: false,
                    Nationality: 'asperiores',
                    RegistrationId: 711,
                    IsRegistrationThai: false,
                    RegistrationType: 215,
                    CompanyName: 'earum',
                    OccupationCatelogy: 'expedita',
                    OccupationGroup: 'voluptatum',
                    OccupationType: 'voluptatibus',
                    Positon: 'aperiam',
                    BusinessType: 'animi',
                    SourceOfIncome: 'labore',
                    LocationIncome: 'recusandae',
                    LiveInCountry: 'accusamus',
                    IsPolitician: true,
                    Tsic: 'voluptatem',
                    File1: 'voluptates',
                    File2: 'et',
                    IsAccept: true
                },
                {
                    id: 897,
                    Individual: false,
                    Nationality: 'sunt',
                    RegistrationId: 263,
                    IsRegistrationThai: false,
                    RegistrationType: 131,
                    CompanyName: 'laudantium',
                    OccupationCatelogy: 'ut',
                    OccupationGroup: 'perferendis',
                    OccupationType: 'et',
                    Positon: 'non',
                    BusinessType: 'et',
                    SourceOfIncome: 'nobis',
                    LocationIncome: 'rerum',
                    LiveInCountry: 'eveniet',
                    IsPolitician: true,
                    Tsic: 'ea',
                    File1: 'omnis',
                    File2: 'provident',
                    IsAccept: false
                }
            ],
            proxy: {
                type: 'memory'
            }
        }
    }

});