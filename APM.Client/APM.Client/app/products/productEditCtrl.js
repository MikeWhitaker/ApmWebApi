(function () {
  "use strict";

  angular
    .module("productManagement")
    .controller("ProductEditCtrl",
      ProductEditCtrl);

  function ProductEditCtrl(productResource) {
    var vm = this;
    vm.product = {};
    vm.message = '';

    productResource.get({ id: 5 },
      function (data) {
        vm.product = data;
        vm.originalProduct = angular.copy(data);
      },
      function (responce) {
        vm.message = responce.statusText + '\r\n';
      }
    );

    if (vm.product && vm.product.productId) {
      vm.title = "Edit: " + vm.product.productName;
    }
    else {
      vm.title = "New Product";
    }

    vm.submit = function () {
      vm.message = '';
      if (vm.product.productId) {
        vm.product.$update({ id: vm.product.productId },
          saveMessage,
          displayReponceMessege
        );
      } else {
        vm.product.$save(
          saveMessage,
          displayReponceMessege
        );
      }
    };

    function saveMessage(data) {
      vm.originalProduct = angular.copy(data);
      vm.message = "... Save Complete";
    }

    function displayReponceMessege(responce) {
      vm.message = responce.statusText + "\r\n";
      if (responce.data.modelState) {
        for (var key in responce.data.modelState) {
          // interesting place to have a look at the data.
          debugger;
          vm.message += responce.data.modelState[key] + "\r\n";
        }
      }
      if (responce.data.exceptionMessage)
        vm.message += responce.data.exceptionMessage;
    }

    vm.cancel = function (editForm) {
      editForm.$setPristine();
      vm.product = angular.copy(vm.originalProduct);
      vm.message = "";
    };

  }
}());
