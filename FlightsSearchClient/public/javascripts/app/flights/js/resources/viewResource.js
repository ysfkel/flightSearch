define([
    'app/flights/js/controllers/details'
], function (detailsController) {
    var views = {
        details: {
            templateUrl: '/javascripts/app/flights/templates/details.html',
            controller: detailsController,

        }
    }
    return {
        details: views.details
    }
})
