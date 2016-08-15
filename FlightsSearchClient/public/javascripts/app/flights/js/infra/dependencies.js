require.config({
    baseUrl: '/javascripts/',
    paths: {
        'domReady': 'libs/domReady',
        'angular': 'bower_components/angular/angular',
        'ui-router': 'bower_components/angular-ui-router/release/angular-ui-router.min'
    },
    shim: {

        'angular': {
            exports: 'angular'
        },
        'ui-router': {
            deps: ['angular'],
            exports: 'ui-router'
        }
    },
    deps: ['app/flights/js/infra/bootstrap']
})

