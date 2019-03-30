(function () {
    "use strict";
    angular
        .module("productManagement")
        .controller("ProductListCtrl",
                     ['productResource', ProductListCtrl]);

    function ProductListCtrl(productResource) {
      var vm = this;

      vm.searchCriteria = "GDN";

      var queryParameter = {
        search: vm.searchCriteria
      };

      productResource.query(queryParameter, function (data) {
        vm.products = data;
      });
    }
}());
