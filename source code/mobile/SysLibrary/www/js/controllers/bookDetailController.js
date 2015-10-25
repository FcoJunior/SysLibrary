/**
 * Created by FcoJunr on 25/10/2015.
 */
app.
  controller('BookDetailCtrl',['$scope', '$http', '$stateParams', 'config', function($scope, $http, $stateParams, config){
    $scope.book = {};
    $http.get(config.server + '/Obra/' + $stateParams.book_id)
      .success(function(data, statusCode){
        $scope.book = data;
      });

  }]);
