(function () {
  'use strict';

  angular
    .module('productManagement')
    .controller('MainCtrl', mainController);

  mainController.$inject = ['userAccount'];

  function mainController(userAccount) {
    /* jshint validthis:true */
    var vm = this;

    vm.isLoggedIn = false;

    vm.message = '';
    vm.userData = {
      userName: '',
      email: '',
      password: '',
      confirmPassword: ''
    };

    vm.registerUser = function () {
      vm.userData.confirmPassword = vm.userData.password;

      userAccount.registerUser(vm.userData,
        function (data) {
          vm.userData.confirmPassword = "",
            vm.message = "... Registration successful";
          vm.login();
        },
        function (responce) {
          vm.isLoggedIn = false;
          vm.message = responce.statusText + "\r\n";
          if (!responce.data)
            return;

          if (responce.data.exceptionMessage)
            vm.message += responce.data.exceptionMessage;

          // Validation errors
          if (responce.data.modelState) {
            for (var key in responce.data.modelState) {
              vm.message += responce.data.modelState[key] + "\r\n";
            }
          }
        }

       
      );
    };

    vm.login = function () {
    };


    activate();

    function activate() { }
  }
})();
