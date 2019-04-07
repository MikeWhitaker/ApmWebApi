(function () {
  "use strict";
  angular
    .module("productManagement")
    .controller("ProductListCtrl",
      ['productResource', ProductListCtrl]);

  function ProductListCtrl(productResource) {
    var vm = this;

    vm.searchCriteria = "GDN";

    //var queryParameter = {
    //  search: vm.searchCriteria
    //};

    //var queryParameter = {
    //  $skip: 1,
    //  $top: 3
    //};

    //var queryParameter = {
    //  $filter: "substringof('GDN', ProductCode) and Price lt 20",
    //  $orderby: "Price"
    //};

    var queryParameter = {};

    //productResource.query(queryParameter, function (data) {
    productResource.query(queryParameter, function (data) {
      vm.products = data;
    });
  }
}());
