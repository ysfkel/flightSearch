
define([
	'app/modules/app'
], function (app) {
    'use strict';
    var resource = app.factory('flightsService', ['$http', function ($http) {
        var uri = 'http://localhost:3978/api/messages';
        return $http({
            url: uri,
            method: 'POST',
            data: data
        }).then(function (res) {
            console.log('res service', res)
            return res;
        })
    }]);
});
