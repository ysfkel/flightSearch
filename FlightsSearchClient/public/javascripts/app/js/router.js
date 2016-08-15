define(['app/modules/app', 'ui-router',
  'app/flights/js/resources/view'
], function (app, uiRouter, viewDoctor) {


    app.config(function ($stateProvider, $urlRouterProvider, $httpProvider) {

        $stateProvider
        .state('base', {
            abstract: true,
            templateUrl: '/javascripts/app/flights/templates/layout.html'
        })
        .state('base.flights', viewDoctor.details)

        $urlRouterProvider.otherwise('/not-found');

        //CORS SETTINGS
        delete $httpProvider.defaults.headers.common['X-Requested-With'];
        $httpProvider.defaults.headers.common["Access-Control-Allow-Origin"] = "*";
        $httpProvider.defaults.headers.common["Accept"] = "application/json";
        $httpProvider.defaults.headers.common["content-type"] = "application/json";
        $httpProvider.defaults.headers.common['Authorization'] = 'Basic WW91ckFwcElkOllvdXJBcHBTZWNyZXQ=';

    })

})
