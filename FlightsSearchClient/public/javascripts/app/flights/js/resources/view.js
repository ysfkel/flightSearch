define([
'app/flights/js/resources/viewResource'

], function (
  viewResource
  ) {

    var details = {
        'url': '/index',
        views: {
            'view-container': viewResource.details
        }
    }

    return {

        details: details

    }

})

