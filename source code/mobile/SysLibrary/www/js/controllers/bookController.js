/**
 * Created by FcoJunr on 25/10/2015.
 */
app.
  controller('BookCtrl',['$scope', '$http', 'config', function($scope, $http, config){
    $scope.books = [];

    $http.get(config.server + '/Obra')
      .success(function(data, statusCode){
        $scope.books = data.Obras.$values;
      });

    $scope.refresh = function(){
      $http.get(config.server + '/Obra')
        .success(function(data, statusCode){
          $scope.books = data.Obras.$values;
        }).finally(function(){
          $scope.$broadcast('scroll.refreshComplete');
        });
    }
  }]);
