var SliderModule = angular.module('website', ['ngAnimate'])
    SliderModule.controller('SliderController', function ($scope) {
        $scope.slides = [
            { image: 'Images/coffee_shop_3.jpg', title: "Get Rewards", description: 'You can use your Leap Card in all your favorite shops.' },
			{ image: 'Images/coffee_shop_2.jpg', title: "Convenience", description: 'After you walk through the turnstiles, it only a short walk to discounted purchases!' },
            { image: 'Images/coffee_shop_1.jpg', title: "One card for all", description: 'Make more room in your wallet and discard all those paper loyalty cards' }
        ];
		
		$scope.currentIndex = 0;

        $scope.setCurrentSlideIndex = function (index) {
            $scope.currentIndex = index;
        };

        $scope.isCurrentSlideIndex = function (index) {
            return $scope.currentIndex === index;
        };

        $scope.prev = function () {
            $scope.currentIndex = ($scope.currentIndex < $scope.slides.length - 1) ? ++$scope.currentIndex : 0;
        };

        $scope.next = function () {
            $scope.currentIndex = ($scope.currentIndex > 0) ? --$scope.currentIndex : $scope.slides.length - 1;
        };
    });
	
    /*
    // create the module and name it scotchApp
	var SpaModule = angular.module("spaApp", ['ngRoute'])
	
	// configure our routes
	SpaModule.config(['$routeProvider', '$locationProvider', function($routeProvider, $locationProvider) {
		$routeProvider

			// route for the home page
			.when('/', {
				templateUrl : '/home.html',
				controller  : 'spaController'
			})

			// route for the about page
			.when('/about', {
				templateUrl : '/about.html',
				controller  : 'aboutController'
			})

			// route for the contact page
			.when('/contact', {
				templateUrl : '/contact.html',
				controller  : 'contactController'
			});
			
			
			// use the HTML5 History API
		
			$locationProvider.html5Mode(true)
	}]);

	// create the controller and inject Angular's $scope
	SpaModule.controller("spaController", function($scope) {
                    $scope.greeting = "How do you like them apples?";
                }
            );
			
	SpaModule.controller('aboutController', function($scope) {
		$scope.greeting = 'Look! I am an about page.';
	});

	SpaModule.controller('contactController', function($scope) {
		$scope.greeting = 'Contact us! JK. This is just a demo.';
	});

	angular.bootstrap(document.getElementById("main"),["spaApp"]);

	
	
	// .animation('.slide-animation', function () {
        // return {
            // addClass: function (element, className, done) {
                // if (className == 'ng-hide') {
                    // TweenMax.to(element, 0.5, {left: -element.parent().width(), onComplete: done });
                // }
                // else {
                    // done();
                // }
            // },
            // removeClass: function (element, className, done) {
                // if (className == 'ng-hide') {
                    // element.removeClass('ng-hide');

                    // TweenMax.set(element, { left: element.parent().width() });
                    // TweenMax.to(element, 0.5, {left: 0, onComplete: done });
                // }
                // else {
                    // done();
                // }
            // }
        // };
		// });
		*/
	