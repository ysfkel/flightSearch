define(['app/flights/models/conversation'], function (Conversation) {

    var controller = function ($scope, $http) {

        $scope.controller = {};
   
        $scope.message = new Conversation($http);
        $scope.conversation = [];
        $scope.formData = { text: '' };
        $scope.searching = false;
        $scope.controller.getFlights = function (e) {
            if (e.keyCode === 13) {
                resetSearch();
                $scope.message.data.text = $scope.formData.text;
                $scope.message.send().then(function (res) {
   
                    var newData, text;
                    if (res.data.text.charAt(0) === '[') {
                        newData = JSON.parse(res.data.text);

                        switch (newData.length > 0) {
                            case true:
                                $scope.flights = newData;
                                break;
                            case false:
                                $scope.flights = [];
                                break;
                        }
                       


                    }
                    $scope.searching = false;
                })

            }

            function resetSearch() {
                $scope.searching = true;
                $scope.flights = [];
            }


        }
    }

    return controller;

})

