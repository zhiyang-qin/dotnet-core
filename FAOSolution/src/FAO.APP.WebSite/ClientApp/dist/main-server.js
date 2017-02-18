(function(e, a) { for(var i in a) e[i] = a[i]; }(exports, /******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId])
/******/ 			return installedModules[moduleId].exports;
/******/
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			exports: {},
/******/ 			id: moduleId,
/******/ 			loaded: false
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.loaded = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "/dist/";
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(0);
/******/ })
/************************************************************************/
/******/ ([
/* 0 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	__webpack_require__(1);
	__webpack_require__(2);
	var core_1 = __webpack_require__(3);
	var angular2_universal_1 = __webpack_require__(4);
	var app_module_1 = __webpack_require__(5);
	core_1.enableProdMode();
	var platform = angular2_universal_1.platformNodeDynamic();
	function default_1(params) {
	    return new Promise(function (resolve, reject) {
	        var requestZone = Zone.current.fork({
	            name: 'angular-universal request',
	            properties: {
	                baseUrl: '/',
	                requestUrl: params.url,
	                originUrl: params.origin,
	                preboot: false,
	                // TODO: Render just the <app> component instead of wrapping it inside an extra HTML document
	                // Waiting on https://github.com/angular/universal/issues/347
	                document: '<!DOCTYPE html><html><head></head><body><app></app></body></html>'
	            },
	            onHandleError: function (parentZone, currentZone, targetZone, error) {
	                // If any error occurs while rendering the module, reject the whole operation
	                reject(error);
	                return true;
	            }
	        });
	        return requestZone.run(function () { return platform.serializeModule(app_module_1.AppModule); }).then(function (html) {
	            resolve({ html: html });
	        }, reject);
	    });
	}
	Object.defineProperty(exports, "__esModule", { value: true });
	exports.default = default_1;


/***/ },
/* 1 */
/***/ function(module, exports) {

	module.exports = require("angular2-universal-polyfills");

/***/ },
/* 2 */
/***/ function(module, exports) {

	module.exports = require("zone.js");

/***/ },
/* 3 */
/***/ function(module, exports) {

	module.exports = require("@angular/core");

/***/ },
/* 4 */
/***/ function(module, exports) {

	module.exports = require("angular2-universal");

/***/ },
/* 5 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
	    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
	    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
	    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
	    return c > 3 && r && Object.defineProperty(target, key, r), r;
	};
	var core_1 = __webpack_require__(3);
	var angular2_universal_1 = __webpack_require__(4);
	var app_component_1 = __webpack_require__(6);
	var navmenu_component_1 = __webpack_require__(11);
	var app_routing_module_1 = __webpack_require__(15);
	var assets_module_1 = __webpack_require__(25);
	var depreciate_module_1 = __webpack_require__(39);
	var tools_module_1 = __webpack_require__(46);
	var AppModule = (function () {
	    function AppModule() {
	    }
	    return AppModule;
	}());
	AppModule = __decorate([
	    core_1.NgModule({
	        imports: [
	            angular2_universal_1.UniversalModule,
	            assets_module_1.AssetsModule,
	            depreciate_module_1.DepreciateModule,
	            tools_module_1.ToolsModule,
	            app_routing_module_1.AppRoutingModule
	        ],
	        declarations: [
	            app_component_1.AppComponent,
	            navmenu_component_1.NavMenuComponent,
	            app_routing_module_1.routedComponents
	        ],
	        bootstrap: [app_component_1.AppComponent]
	    })
	], AppModule);
	exports.AppModule = AppModule;


/***/ },
/* 6 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
	    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
	    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
	    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
	    return c > 3 && r && Object.defineProperty(target, key, r), r;
	};
	var core_1 = __webpack_require__(3);
	var AppComponent = (function () {
	    function AppComponent() {
	    }
	    return AppComponent;
	}());
	AppComponent = __decorate([
	    core_1.Component({
	        selector: 'app',
	        template: __webpack_require__(7),
	        styles: [__webpack_require__(8)]
	    })
	], AppComponent);
	exports.AppComponent = AppComponent;


/***/ },
/* 7 */
/***/ function(module, exports) {

	module.exports = "<!-- Fixed navbar -->\r\n<nav-menu></nav-menu>\r\n\r\n<div class=\"container\" role=\"main\">\r\n    <router-outlet></router-outlet>\r\n</div>\r\n"

/***/ },
/* 8 */
/***/ function(module, exports, __webpack_require__) {

	
	        var result = __webpack_require__(9);
	
	        if (typeof result === "string") {
	            module.exports = result;
	        } else {
	            module.exports = result.toString();
	        }
	    

/***/ },
/* 9 */
/***/ function(module, exports, __webpack_require__) {

	exports = module.exports = __webpack_require__(10)();
	// imports
	
	
	// module
	exports.push([module.id, "@media (max-width: 767px) {\n    /* On small screens, the nav menu spans the full width of the screen. Leave a space for it. */\n    .body-content {\n        padding-top: 0px;\n    }\n}", ""]);
	
	// exports


/***/ },
/* 10 */
/***/ function(module, exports) {

	/*
		MIT License http://www.opensource.org/licenses/mit-license.php
		Author Tobias Koppers @sokra
	*/
	// css base code, injected by the css-loader
	module.exports = function() {
		var list = [];
	
		// return the list of modules as css string
		list.toString = function toString() {
			var result = [];
			for(var i = 0; i < this.length; i++) {
				var item = this[i];
				if(item[2]) {
					result.push("@media " + item[2] + "{" + item[1] + "}");
				} else {
					result.push(item[1]);
				}
			}
			return result.join("");
		};
	
		// import a list of modules into the list
		list.i = function(modules, mediaQuery) {
			if(typeof modules === "string")
				modules = [[null, modules, ""]];
			var alreadyImportedModules = {};
			for(var i = 0; i < this.length; i++) {
				var id = this[i][0];
				if(typeof id === "number")
					alreadyImportedModules[id] = true;
			}
			for(i = 0; i < modules.length; i++) {
				var item = modules[i];
				// skip already imported module
				// this implementation is not 100% perfect for weird media query combinations
				//  when a module is imported multiple times with different media queries.
				//  I hope this will never occur (Hey this way we have smaller bundles)
				if(typeof item[0] !== "number" || !alreadyImportedModules[item[0]]) {
					if(mediaQuery && !item[2]) {
						item[2] = mediaQuery;
					} else if(mediaQuery) {
						item[2] = "(" + item[2] + ") and (" + mediaQuery + ")";
					}
					list.push(item);
				}
			}
		};
		return list;
	};


/***/ },
/* 11 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
	    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
	    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
	    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
	    return c > 3 && r && Object.defineProperty(target, key, r), r;
	};
	var core_1 = __webpack_require__(3);
	var NavMenuComponent = (function () {
	    function NavMenuComponent() {
	    }
	    return NavMenuComponent;
	}());
	NavMenuComponent = __decorate([
	    core_1.Component({
	        selector: 'nav-menu',
	        template: __webpack_require__(12),
	        styles: [__webpack_require__(13)]
	    })
	], NavMenuComponent);
	exports.NavMenuComponent = NavMenuComponent;


/***/ },
/* 12 */
/***/ function(module, exports) {

	module.exports = "<nav class=\"navbar navbar-inverse \">\r\n    <div class=\"container\">\r\n        <!-- Brand and toggle get grouped for better mobile display -->\r\n        <div class=\"navbar-header\">\r\n            <button type=\"button\" class=\"navbar-toggle collapsed\" data-toggle=\"collapse\" data-target=\"#navbar\" aria-expanded=\"false\" aria-controls=\"navbar\">\r\n                <span class=\"sr-only\">Toggle navigation</span>\r\n                <span class=\"icon-bar\"></span>\r\n                <span class=\"icon-bar\"></span>\r\n                <span class=\"icon-bar\"></span>\r\n            </button>\r\n            <a class=\"navbar-brand\" href=\"\">FAO</a>\r\n        </div>\r\n\r\n        <div id=\"navbar\" class=\"navbar-collapse collapse\">\r\n            <ul class=\"nav navbar-nav\">\r\n                <li [routerLinkActive]=\"['link-active']\"><a [routerLink]=\"['/home']\"><span class='glyphicon glyphicon-home'></span> Home</a></li>\r\n                <li [routerLinkActive]=\"['link-active']\"><a [routerLink]=\"['/counter']\"><span class='glyphicon glyphicon-education'></span> Counter</a></li>\r\n                <li [routerLinkActive]=\"['link-active']\"><a [routerLink]=\"['/fetch-data']\"><span class='glyphicon glyphicon-th-list'></span> Fetch data</a></li>\r\n                <li class=\"dropdown\">\r\n                    <a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Asset <span class=\"caret\"></span></a>\r\n                    <ul class=\"dropdown-menu\">\r\n                        <li><a [routerLink]=\"['/assets/list']\">Asset List</a></li>\r\n                        <li><a [routerLink]=\"['/assets/detail']\">Asset Detail</a></li>\r\n                    </ul>\r\n                </li>\r\n                <li class=\"dropdown\">\r\n                    <a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Depreciation <span class=\"caret\"></span></a>\r\n                    <ul class=\"dropdown-menu\">\r\n                        <li><a [routerLink]=\"['/depreciate/projection']\">Projection</a></li>\r\n                        <li><a [routerLink]=\"['/depreciate/monthlyprojection']\">Monthly Projection</a></li>\r\n                        <li><a href=\"#\">Something else here</a></li>\r\n                        <li role=\"separator\" class=\"divider\"></li>\r\n                        <li class=\"dropdown-header\">Nav header</li>\r\n                        <li><a href=\"#\">Separated link</a></li>\r\n                        <li><a href=\"#\">One more separated link</a></li>\r\n                    </ul>\r\n                </li>\r\n                <li class=\"dropdown\">\r\n                    <a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Tools <span class=\"caret\"></span></a>\r\n                    <ul class=\"dropdown-menu\">\r\n                        <li><a [routerLink]=\"['/tools/depreciate']\">Depreciate</a></li>\r\n                        <li><a [routerLink]=\"['/tools/projection']\">Projection</a></li>\r\n                    </ul>\r\n                </li>\r\n            </ul>\r\n        </div><!--/.nav-collapse -->\r\n    </div>\r\n</nav>\r\n    <!--\r\n            </div>\r\n            <div class='clearfix'></div>\r\n            <div class='navbar-collapse collapse'>\r\n                <ul class='nav navbar-nav'>\r\n                    <li [routerLinkActive]=\"['link-active']\">\r\n                        <a [routerLink]=\"['/home']\">\r\n                            <span class='glyphicon glyphicon-home'></span> Home\r\n                        </a>\r\n                    </li>\r\n                    <li [routerLinkActive]=\"['link-active']\">\r\n                        <a [routerLink]=\"['/counter']\">\r\n                            <span class='glyphicon glyphicon-education'></span> Counter\r\n                        </a>\r\n                    </li>\r\n                    <li [routerLinkActive]=\"['link-active']\">\r\n                        <a [routerLink]=\"['/fetch-data']\">\r\n                            <span class='glyphicon glyphicon-th-list'></span> Fetch data\r\n                        </a>\r\n                    </li>\r\n                </ul>\r\n            </div>\r\n        </nav>\r\n        -->\r\n"

/***/ },
/* 13 */
/***/ function(module, exports, __webpack_require__) {

	
	        var result = __webpack_require__(14);
	
	        if (typeof result === "string") {
	            module.exports = result;
	        } else {
	            module.exports = result.toString();
	        }
	    

/***/ },
/* 14 */
/***/ function(module, exports, __webpack_require__) {

	exports = module.exports = __webpack_require__(10)();
	// imports
	
	
	// module
	exports.push([module.id, "li .glyphicon {\n    margin-right: 10px;\n}\n\n/* Highlighting rules for nav menu items */\nli.link-active a,\nli.link-active a:hover,\nli.link-active a:focus {\n    background-color: #4189C7;\n    color: white;\n}\n\n/* Keep the nav menu independent of scrolcol-sm-9ling and on top of other items */\n.main-nav {\n    position: fixed;\n    top: 0;\n    left: 0;\n    right: 0;\n    z-index: 1;\n}\n\n@media (min-width: 768px) {\n    /* On small screens, convert the nav menu to a vertical sidebar */\n}\n", ""]);
	
	// exports


/***/ },
/* 15 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
	    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
	    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
	    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
	    return c > 3 && r && Object.defineProperty(target, key, r), r;
	};
	var core_1 = __webpack_require__(3);
	var router_1 = __webpack_require__(16);
	var home_component_1 = __webpack_require__(17);
	var fetchdata_component_1 = __webpack_require__(19);
	var counter_component_1 = __webpack_require__(22);
	var not_found_component_1 = __webpack_require__(24);
	exports.routes = [
	    { path: 'home', component: home_component_1.HomeComponent },
	    { path: 'counter', component: counter_component_1.CounterComponent },
	    { path: 'fetch-data', component: fetchdata_component_1.FetchDataComponent },
	    //{
	    //    path: 'depreciate', loadChildren: () => new Promise(resolve => {
	    //        (require as any).ensure([], require => {
	    //            resolve(require('app/depreciate/depreciate.module').DepreciateModule);
	    //        })
	    //    })
	    //},
	    //{ path: 'depreciate01', loadChildren: () => System.import('app/depreciate/depreciate.module').then(mod => mod.ModuleName),
	    //{ path: 'depreciate', loadChildren: 'app/depreciate/depreciate.module#DepreciateModule' },
	    { path: '', redirectTo: 'home', pathMatch: 'full' },
	    { path: '**', component: not_found_component_1.PageNotFoundComponent }
	];
	var AppRoutingModule = (function () {
	    function AppRoutingModule() {
	    }
	    return AppRoutingModule;
	}());
	AppRoutingModule = __decorate([
	    core_1.NgModule({
	        imports: [router_1.RouterModule.forRoot(exports.routes)],
	        exports: [router_1.RouterModule]
	    })
	], AppRoutingModule);
	exports.AppRoutingModule = AppRoutingModule;
	exports.routedComponents = [home_component_1.HomeComponent, counter_component_1.CounterComponent, fetchdata_component_1.FetchDataComponent, not_found_component_1.PageNotFoundComponent];


/***/ },
/* 16 */
/***/ function(module, exports) {

	module.exports = require("@angular/router");

/***/ },
/* 17 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
	    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
	    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
	    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
	    return c > 3 && r && Object.defineProperty(target, key, r), r;
	};
	var core_1 = __webpack_require__(3);
	var HomeComponent = (function () {
	    function HomeComponent() {
	    }
	    return HomeComponent;
	}());
	HomeComponent = __decorate([
	    core_1.Component({
	        selector: 'home',
	        template: __webpack_require__(18)
	    })
	], HomeComponent);
	exports.HomeComponent = HomeComponent;


/***/ },
/* 18 */
/***/ function(module, exports) {

	module.exports = "<h1>Hello, world!</h1>\r\n<p>Welcome to your new single-page application, built with:</p>\r\n<ul>\r\n    <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li>\r\n    <li><a href='https://angular.io/'>Angular 2</a> and <a href='http://www.typescriptlang.org/'>TypeScript</a> for client-side code</li>\r\n    <li><a href='https://webpack.github.io/'>Webpack</a> for building and bundling client-side resources</li>\r\n    <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li>\r\n</ul>\r\n<p>To help you get started, we've also set up:</p>\r\n<ul>\r\n    <li><strong>Client-side navigation</strong>. For example, click <em>Counter</em> then <em>Back</em> to return here.</li>\r\n    <li><strong>Server-side prerendering</strong>. For faster initial loading and improved SEO, your Angular 2 app is prerendered on the server. The resulting HTML is then transferred to the browser where a client-side copy of the app takes over.</li>\r\n    <li><strong>Webpack dev middleware</strong>. In development mode, there's no need to run the <code>webpack</code> build tool. Your client-side resources are dynamically built on demand. Updates are available as soon as you modify any file.</li>\r\n    <li><strong>Hot module replacement</strong>. In development mode, you don't even need to reload the page after making most changes. Within seconds of saving changes to files, your Angular 2 app will be rebuilt and a new instance injected is into the page.</li>\r\n    <li><strong>Efficient production builds</strong>. In production mode, development-time features are disabled, and the <code>webpack</code> build tool produces minified static CSS and JavaScript files.</li>\r\n</ul>\r\n"

/***/ },
/* 19 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
	    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
	    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
	    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
	    return c > 3 && r && Object.defineProperty(target, key, r), r;
	};
	var __metadata = (this && this.__metadata) || function (k, v) {
	    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
	};
	var core_1 = __webpack_require__(3);
	var http_1 = __webpack_require__(20);
	var FetchDataComponent = (function () {
	    function FetchDataComponent(http) {
	        var _this = this;
	        http.get('/api/SampleData/WeatherForecasts').subscribe(function (result) {
	            _this.forecasts = result.json();
	        });
	    }
	    return FetchDataComponent;
	}());
	FetchDataComponent = __decorate([
	    core_1.Component({
	        selector: 'fetchdata',
	        template: __webpack_require__(21)
	    }),
	    __metadata("design:paramtypes", [http_1.Http])
	], FetchDataComponent);
	exports.FetchDataComponent = FetchDataComponent;


/***/ },
/* 20 */
/***/ function(module, exports) {

	module.exports = require("@angular/http");

/***/ },
/* 21 */
/***/ function(module, exports) {

	module.exports = "<h1>Weather forecast</h1>\r\n<p>This component demonstrates fetching data from the server.</p>\r\n<p *ngIf=\"!forecasts\"><em>Loading...</em></p>\r\n<table class='table' *ngIf=\"forecasts\">\r\n    <thead>\r\n        <tr>\r\n            <th>Date</th>\r\n            <th>Temp. (C)</th>\r\n            <th>Temp. (F)</th>\r\n            <th>Summary</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n        <tr *ngFor=\"let forecast of forecasts\">\r\n            <td>{{ forecast.dateFormatted }}</td>\r\n            <td>{{ forecast.temperatureC }}</td>\r\n            <td>{{ forecast.temperatureF }}</td>\r\n            <td>{{ forecast.summary }}</td>\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n"

/***/ },
/* 22 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
	    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
	    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
	    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
	    return c > 3 && r && Object.defineProperty(target, key, r), r;
	};
	var core_1 = __webpack_require__(3);
	var CounterComponent = (function () {
	    function CounterComponent() {
	        this.currentCount = 0;
	    }
	    CounterComponent.prototype.incrementCounter = function () {
	        this.currentCount++;
	    };
	    return CounterComponent;
	}());
	CounterComponent = __decorate([
	    core_1.Component({
	        selector: 'counter',
	        template: __webpack_require__(23)
	    })
	], CounterComponent);
	exports.CounterComponent = CounterComponent;


/***/ },
/* 23 */
/***/ function(module, exports) {

	module.exports = "<h2>Counter</h2>\r\n<p>This is a simple example of an Angular 2 component.</p>\r\n<p>Current count: <strong>{{ currentCount }}</strong></p>\r\n<button (click)=\"incrementCounter()\">Increment</button>"

/***/ },
/* 24 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
	    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
	    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
	    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
	    return c > 3 && r && Object.defineProperty(target, key, r), r;
	};
	var core_1 = __webpack_require__(3);
	var PageNotFoundComponent = (function () {
	    function PageNotFoundComponent() {
	    }
	    return PageNotFoundComponent;
	}());
	PageNotFoundComponent = __decorate([
	    core_1.Component({
	        template: '<h2>Page not found</h2>'
	    })
	], PageNotFoundComponent);
	exports.PageNotFoundComponent = PageNotFoundComponent;


/***/ },
/* 25 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
	    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
	    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
	    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
	    return c > 3 && r && Object.defineProperty(target, key, r), r;
	};
	var core_1 = __webpack_require__(3);
	var common_1 = __webpack_require__(26);
	var forms_1 = __webpack_require__(27);
	var assets_list_component_1 = __webpack_require__(28);
	var assets_update_component_1 = __webpack_require__(36);
	var assets_service_1 = __webpack_require__(29);
	var assets_routing_module_1 = __webpack_require__(38);
	var AssetsModule = (function () {
	    function AssetsModule() {
	    }
	    return AssetsModule;
	}());
	AssetsModule = __decorate([
	    core_1.NgModule({
	        imports: [common_1.CommonModule, forms_1.FormsModule, assets_routing_module_1.AssetsRoutingModule],
	        declarations: [assets_list_component_1.AssetsListComponent, assets_update_component_1.AssetsUpdateComponent],
	        providers: [assets_service_1.AssetsService]
	    })
	], AssetsModule);
	exports.AssetsModule = AssetsModule;


/***/ },
/* 26 */
/***/ function(module, exports) {

	module.exports = require("@angular/common");

/***/ },
/* 27 */
/***/ function(module, exports) {

	module.exports = require("@angular/forms");

/***/ },
/* 28 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
	    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
	    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
	    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
	    return c > 3 && r && Object.defineProperty(target, key, r), r;
	};
	var __metadata = (this && this.__metadata) || function (k, v) {
	    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
	};
	var core_1 = __webpack_require__(3);
	var assets_service_1 = __webpack_require__(29);
	var AssetsListComponent = (function () {
	    function AssetsListComponent(assetsService) {
	        this.assetsService = assetsService;
	        this.assets = [];
	    }
	    AssetsListComponent.prototype.ngOnInit = function () {
	        this.getAssetList();
	    };
	    AssetsListComponent.prototype.getAssetList = function () {
	        var _this = this;
	        this.assetsService.getAssetList()
	            .subscribe(function (items) {
	            _this.assets = items;
	        }, function (error) { console.log(error); });
	    };
	    return AssetsListComponent;
	}());
	AssetsListComponent = __decorate([
	    core_1.Component({
	        template: __webpack_require__(35)
	    }),
	    __metadata("design:paramtypes", [assets_service_1.AssetsService])
	], AssetsListComponent);
	exports.AssetsListComponent = AssetsListComponent;


/***/ },
/* 29 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
	    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
	    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
	    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
	    return c > 3 && r && Object.defineProperty(target, key, r), r;
	};
	var __metadata = (this && this.__metadata) || function (k, v) {
	    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
	};
	var core_1 = __webpack_require__(3);
	var http_1 = __webpack_require__(20);
	var Observable_1 = __webpack_require__(30);
	__webpack_require__(31);
	__webpack_require__(32);
	__webpack_require__(33);
	var app_settings_1 = __webpack_require__(34);
	var AssetsService = (function () {
	    function AssetsService(http) {
	        this.http = http;
	        this.assetListUrl = 'api/' + app_settings_1.AppSettings.TENANT_ID + '/companies/' + app_settings_1.AppSettings.COMPANY_ID + '/assets';
	    }
	    AssetsService.prototype.getAssetList = function () {
	        return this.http.get(this.assetListUrl)
	            .map(this.extractData)
	            .catch(this.handleError);
	    };
	    AssetsService.prototype.extractData = function (res) {
	        var body = res.json();
	        return body || {};
	    };
	    AssetsService.prototype.handleError = function (error) {
	        // In a real world app, we might use a remote logging infrastructure
	        var errMsg;
	        if (error instanceof http_1.Response) {
	            var body = error.json() || '';
	            var err = body.error || JSON.stringify(body);
	            errMsg = error.status + " - " + (error.statusText || '') + " " + err;
	        }
	        else {
	            errMsg = error.message ? error.message : error.toString();
	        }
	        console.error(errMsg);
	        return Observable_1.Observable.throw(errMsg);
	    };
	    return AssetsService;
	}());
	AssetsService = __decorate([
	    core_1.Injectable(),
	    __metadata("design:paramtypes", [http_1.Http])
	], AssetsService);
	exports.AssetsService = AssetsService;


/***/ },
/* 30 */
/***/ function(module, exports) {

	module.exports = require("rxjs/Observable");

/***/ },
/* 31 */
/***/ function(module, exports) {

	module.exports = require("rxjs/add/operator/catch");

/***/ },
/* 32 */
/***/ function(module, exports) {

	module.exports = require("rxjs/add/operator/map");

/***/ },
/* 33 */
/***/ function(module, exports) {

	module.exports = require("rxjs/Rx");

/***/ },
/* 34 */
/***/ function(module, exports) {

	"use strict";
	var AppSettings = (function () {
	    function AppSettings() {
	    }
	    return AppSettings;
	}());
	AppSettings.API_ENDPOINT = 'http://127.0.0.1:6666/api/';
	AppSettings.TENANT_ID = '00000000-0000-0000-0000-000000000001';
	AppSettings.COMPANY_ID = '00000001-0000-0000-0000-000000000000';
	exports.AppSettings = AppSettings;


/***/ },
/* 35 */
/***/ function(module, exports) {

	module.exports = "<h1>Assets</h1>\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>ID</th>\r\n            <th>PropType</th>\r\n            <th>Description</th>\r\n            <th>Location</th>\r\n            <th>Department</th>\r\n            <th>\r\n                <a href=\"\" [routerLink]=\"['/AssetCreate']\">\r\n                    Add\r\n                </a>\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n        <tr *ngIf=\"!assets.length\">\r\n            <td colspan=\"5\">Loading...</td>\r\n        </tr>\r\n        <tr *ngFor=\"let asset of assets\">\r\n            <td>{{asset.assetId}}</td>\r\n            <td>{{asset.propType}}</td>\r\n            <td>{{asset.description}}</td>\r\n            <td>{{asset.location}}</td>\r\n            <td>{{asset.department}}</td>\r\n            <td>\r\n                <a href=\"\" [routerLink]=\"['/assets', asset.assetId]\">\r\n                    Edit\r\n                </a>\r\n                <!--<a href=\"javascript:void(0)\" (click)=\"deleteModel(asset)\">\r\n                    Delete\r\n                </a>-->\r\n            </td>\r\n        </tr>\r\n    </tbody>\r\n</table>"

/***/ },
/* 36 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
	    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
	    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
	    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
	    return c > 3 && r && Object.defineProperty(target, key, r), r;
	};
	var __metadata = (this && this.__metadata) || function (k, v) {
	    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
	};
	var core_1 = __webpack_require__(3);
	//import { Asset, AssetsService }     from './assets.service';
	var AssetsUpdateComponent = (function () {
	    function AssetsUpdateComponent() {
	    }
	    AssetsUpdateComponent.prototype.ngOnInit = function () {
	    };
	    return AssetsUpdateComponent;
	}());
	AssetsUpdateComponent = __decorate([
	    core_1.Component({
	        template: __webpack_require__(37)
	    }),
	    __metadata("design:paramtypes", [])
	], AssetsUpdateComponent);
	exports.AssetsUpdateComponent = AssetsUpdateComponent;


/***/ },
/* 37 */
/***/ function(module, exports) {

	module.exports = "<h1>Update Asset</h1>\r\n\r\n"

/***/ },
/* 38 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
	    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
	    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
	    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
	    return c > 3 && r && Object.defineProperty(target, key, r), r;
	};
	var core_1 = __webpack_require__(3);
	var router_1 = __webpack_require__(16);
	var assets_list_component_1 = __webpack_require__(28);
	var assets_update_component_1 = __webpack_require__(36);
	var AssetsRoutingModule = (function () {
	    function AssetsRoutingModule() {
	    }
	    return AssetsRoutingModule;
	}());
	AssetsRoutingModule = __decorate([
	    core_1.NgModule({
	        imports: [router_1.RouterModule.forChild([
	                { path: 'assets/list', component: assets_list_component_1.AssetsListComponent },
	                { path: 'assets/:id', component: assets_update_component_1.AssetsUpdateComponent }
	            ])],
	        exports: [router_1.RouterModule]
	    })
	], AssetsRoutingModule);
	exports.AssetsRoutingModule = AssetsRoutingModule;


/***/ },
/* 39 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
	    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
	    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
	    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
	    return c > 3 && r && Object.defineProperty(target, key, r), r;
	};
	var core_1 = __webpack_require__(3);
	var common_1 = __webpack_require__(26);
	var forms_1 = __webpack_require__(27);
	var depreciate_projection_component_1 = __webpack_require__(40);
	var depreciate_monthlyprojection_component_1 = __webpack_require__(43);
	var depreciate_service_1 = __webpack_require__(44);
	var depreciate_routing_module_1 = __webpack_require__(45);
	var DepreciateModule = (function () {
	    function DepreciateModule() {
	    }
	    return DepreciateModule;
	}());
	DepreciateModule = __decorate([
	    core_1.NgModule({
	        imports: [common_1.CommonModule, forms_1.FormsModule, depreciate_routing_module_1.DepreciateRoutingModule],
	        declarations: [depreciate_projection_component_1.DepreciateProjectionComponent, depreciate_monthlyprojection_component_1.DepreciateMonthlyProjectionComponent],
	        //exports: [DepreciateProjectionComponent, DepreciateMonthlyProjectionComponent],
	        providers: [depreciate_service_1.DepreciateService]
	    })
	], DepreciateModule);
	exports.DepreciateModule = DepreciateModule;


/***/ },
/* 40 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
	    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
	    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
	    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
	    return c > 3 && r && Object.defineProperty(target, key, r), r;
	};
	var __metadata = (this && this.__metadata) || function (k, v) {
	    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
	};
	var core_1 = __webpack_require__(3);
	var hero_1 = __webpack_require__(41);
	var DepreciateProjectionComponent = (function () {
	    function DepreciateProjectionComponent() {
	        this.powers = ['Really Smart', 'Super Flexible',
	            'Super Hot', 'Weather Changer'];
	        this.model = new hero_1.Hero(18, 'Dr IQ', this.powers[0], 'Chuck Overstreet');
	        this.submitted = false;
	    }
	    DepreciateProjectionComponent.prototype.ngOnInit = function () {
	    };
	    DepreciateProjectionComponent.prototype.onSubmit = function () { this.submitted = true; };
	    DepreciateProjectionComponent.prototype.newHero = function () {
	        this.model = new hero_1.Hero(42, '', '');
	    };
	    return DepreciateProjectionComponent;
	}());
	DepreciateProjectionComponent = __decorate([
	    core_1.Component({
	        //moduleId: module.id,
	        //selector: 'home',
	        //template: `
	        //<h3 highlight>Depreciate Projection</h3>
	        //`
	        //templateUrl: './depreciate-projection.component.html',
	        template: __webpack_require__(42)
	    }),
	    __metadata("design:paramtypes", [])
	], DepreciateProjectionComponent);
	exports.DepreciateProjectionComponent = DepreciateProjectionComponent;


/***/ },
/* 41 */
/***/ function(module, exports) {

	"use strict";
	var Hero = (function () {
	    function Hero(id, name, power, alterEgo) {
	        this.id = id;
	        this.name = name;
	        this.power = power;
	        this.alterEgo = alterEgo;
	    }
	    return Hero;
	}());
	exports.Hero = Hero;


/***/ },
/* 42 */
/***/ function(module, exports) {

	module.exports = "<div class=\"container\">\r\n    <div [hidden]=\"submitted\">\r\n        <h1>Hero Form</h1>\r\n        <form (ngSubmit)=\"onSubmit()\" #heroForm=\"ngForm\">\r\n            <div class=\"form-group\">\r\n                <label for=\"name\">Name</label>\r\n                <input type=\"text\" class=\"form-control\" id=\"name\"\r\n                       required\r\n                       [(ngModel)]=\"model.name\" name=\"name\"\r\n                       #name=\"ngModel\">\r\n                <div [hidden]=\"name.valid || name.pristine\"\r\n                     class=\"alert alert-danger\">\r\n                    Name is required\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <label for=\"alterEgo\">Alter Ego</label>\r\n                <input type=\"text\" class=\"form-control\" id=\"alterEgo\"\r\n                       [(ngModel)]=\"model.alterEgo\" name=\"alterEgo\">\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <label for=\"power\">Hero Power</label>\r\n                <select class=\"form-control\" id=\"power\"\r\n                        required\r\n                        [(ngModel)]=\"model.power\" name=\"power\"\r\n                        #power=\"ngModel\">\r\n                    <option *ngFor=\"let pow of powers\" [value]=\"pow\">{{pow}}</option>\r\n                </select>\r\n                <div [hidden]=\"power.valid || power.pristine\" class=\"alert alert-danger\">\r\n                    Power is required\r\n                </div>\r\n            </div>\r\n            <button type=\"submit\" class=\"btn btn-success\" [disabled]=\"!heroForm.form.valid\">Submit</button>\r\n            <button type=\"button\" class=\"btn btn-default\" (click)=\"newHero(); heroForm.reset()\">New Hero</button>\r\n        </form>\r\n    </div>\r\n    <div [hidden]=\"!submitted\">\r\n        <h2>You submitted the following:</h2>\r\n        <div class=\"row\">\r\n            <div class=\"col-xs-3\">Name</div>\r\n            <div class=\"col-xs-9  pull-left\">{{ model.name }}</div>\r\n        </div>\r\n        <div class=\"row\">\r\n            <div class=\"col-xs-3\">Alter Ego</div>\r\n            <div class=\"col-xs-9 pull-left\">{{ model.alterEgo }}</div>\r\n        </div>\r\n        <div class=\"row\">\r\n            <div class=\"col-xs-3\">Power</div>\r\n            <div class=\"col-xs-9 pull-left\">{{ model.power }}</div>\r\n        </div>\r\n        <br>\r\n        <button class=\"btn btn-primary\" (click)=\"submitted=false\">Edit</button>\r\n    </div>\r\n</div>\r\n"

/***/ },
/* 43 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
	    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
	    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
	    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
	    return c > 3 && r && Object.defineProperty(target, key, r), r;
	};
	var __metadata = (this && this.__metadata) || function (k, v) {
	    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
	};
	var core_1 = __webpack_require__(3);
	var DepreciateMonthlyProjectionComponent = (function () {
	    function DepreciateMonthlyProjectionComponent() {
	    }
	    DepreciateMonthlyProjectionComponent.prototype.ngOnInit = function () {
	    };
	    return DepreciateMonthlyProjectionComponent;
	}());
	DepreciateMonthlyProjectionComponent = __decorate([
	    core_1.Component({
	        template: "\n    <h3 highlight>Depreciate Monthly Projection</h3>\n    "
	    }),
	    __metadata("design:paramtypes", [])
	], DepreciateMonthlyProjectionComponent);
	exports.DepreciateMonthlyProjectionComponent = DepreciateMonthlyProjectionComponent;


/***/ },
/* 44 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
	    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
	    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
	    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
	    return c > 3 && r && Object.defineProperty(target, key, r), r;
	};
	var core_1 = __webpack_require__(3);
	var Crisis = (function () {
	    function Crisis(id, name) {
	        this.id = id;
	        this.name = name;
	    }
	    return Crisis;
	}());
	exports.Crisis = Crisis;
	var DepreciateService = (function () {
	    function DepreciateService() {
	    }
	    return DepreciateService;
	}());
	DepreciateService = __decorate([
	    core_1.Injectable()
	], DepreciateService);
	exports.DepreciateService = DepreciateService;


/***/ },
/* 45 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
	    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
	    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
	    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
	    return c > 3 && r && Object.defineProperty(target, key, r), r;
	};
	var core_1 = __webpack_require__(3);
	var router_1 = __webpack_require__(16);
	var depreciate_projection_component_1 = __webpack_require__(40);
	var depreciate_monthlyprojection_component_1 = __webpack_require__(43);
	var DepreciateRoutingModule = (function () {
	    function DepreciateRoutingModule() {
	    }
	    return DepreciateRoutingModule;
	}());
	DepreciateRoutingModule = __decorate([
	    core_1.NgModule({
	        imports: [router_1.RouterModule.forChild([
	                { path: 'depreciate/projection', component: depreciate_projection_component_1.DepreciateProjectionComponent },
	                { path: 'depreciate/monthlyprojection', component: depreciate_monthlyprojection_component_1.DepreciateMonthlyProjectionComponent }
	            ])],
	        exports: [router_1.RouterModule]
	    })
	], DepreciateRoutingModule);
	exports.DepreciateRoutingModule = DepreciateRoutingModule;


/***/ },
/* 46 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
	    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
	    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
	    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
	    return c > 3 && r && Object.defineProperty(target, key, r), r;
	};
	var core_1 = __webpack_require__(3);
	var common_1 = __webpack_require__(26);
	var forms_1 = __webpack_require__(27);
	var tools_depreciate_component_1 = __webpack_require__(47);
	var tools_projection_component_1 = __webpack_require__(48);
	var tools_service_1 = __webpack_require__(49);
	var tools_routing_module_1 = __webpack_require__(52);
	var ToolsModule = (function () {
	    function ToolsModule() {
	    }
	    return ToolsModule;
	}());
	ToolsModule = __decorate([
	    core_1.NgModule({
	        imports: [common_1.CommonModule, forms_1.FormsModule, tools_routing_module_1.ToolsRoutingModule],
	        declarations: [tools_depreciate_component_1.ToolsDepreciateComponent, tools_projection_component_1.ToolsProjectionComponent],
	        providers: [tools_service_1.ToolsService]
	    })
	], ToolsModule);
	exports.ToolsModule = ToolsModule;


/***/ },
/* 47 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
	    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
	    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
	    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
	    return c > 3 && r && Object.defineProperty(target, key, r), r;
	};
	var __metadata = (this && this.__metadata) || function (k, v) {
	    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
	};
	var core_1 = __webpack_require__(3);
	var ToolsDepreciateComponent = (function () {
	    function ToolsDepreciateComponent() {
	    }
	    ToolsDepreciateComponent.prototype.ngOnInit = function () {
	    };
	    return ToolsDepreciateComponent;
	}());
	ToolsDepreciateComponent = __decorate([
	    core_1.Component({
	        template: "\n    <h3 highlight>Tool - Depreciate</h3>\n    "
	    }),
	    __metadata("design:paramtypes", [])
	], ToolsDepreciateComponent);
	exports.ToolsDepreciateComponent = ToolsDepreciateComponent;


/***/ },
/* 48 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
	    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
	    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
	    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
	    return c > 3 && r && Object.defineProperty(target, key, r), r;
	};
	var __metadata = (this && this.__metadata) || function (k, v) {
	    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
	};
	var core_1 = __webpack_require__(3);
	var tools_service_1 = __webpack_require__(49);
	var book_1 = __webpack_require__(50);
	var ToolsProjectionComponent = (function () {
	    function ToolsProjectionComponent(toolsService) {
	        this.toolsService = toolsService;
	        this.powers = ['Really Smart', 'Super Flexible', 'Super Hot', 'Weather Changer'];
	        this.model = new book_1.Book('P', '2000-01-01', 10000.00, 'MF200', '10 yrs 00 mns');
	    }
	    ToolsProjectionComponent.prototype.ngOnInit = function () {
	        this.getPropTypeList();
	    };
	    ToolsProjectionComponent.prototype.PostProject = function () {
	        var _this = this;
	        var deprBook = new tools_service_1.DepreciableBookDto("P", "2010-01-01", 10000.00, "SL", 0, 10, 0, 0, 0, 0, 0, "", "2015-12-31", "1899-12-31", "1899-12-31");
	        this.toolsService.postProject(deprBook)
	            .subscribe(function (items) {
	            _this.prdDeprItems = items;
	        }, function (error) { console.log(error); });
	    };
	    ToolsProjectionComponent.prototype.getPropTypeList = function () {
	        var _this = this;
	        this.toolsService.getPropTypeList()
	            .subscribe(function (ruleItems) {
	            _this.propTypeList = ruleItems;
	        }, function (error) { console.log(error); });
	    };
	    ToolsProjectionComponent.prototype.getDeprMethodList = function (propType, pisDate) {
	        var _this = this;
	        this.toolsService.getDeprMehodList(propType, pisDate)
	            .subscribe(function (ruleItems) {
	            _this.deprMethodList = ruleItems;
	        }, function (error) { console.log(error); });
	    };
	    ToolsProjectionComponent.prototype.getEstLifeList = function (propType, pisDate, deprMethod) {
	        var _this = this;
	        this.toolsService.getEstLifeList(propType, pisDate, deprMethod)
	            .subscribe(function (ruleItems) {
	            _this.estLifeList = ruleItems;
	        }, function (error) { console.log(error); });
	    };
	    ToolsProjectionComponent.prototype.onBlur_propType = function () {
	    };
	    ToolsProjectionComponent.prototype.onBlur_pisDate = function () {
	        this.getDeprMethodList(this.model.propType, this.model.pisDate);
	    };
	    ToolsProjectionComponent.prototype.onBlur_acqValue = function () {
	    };
	    ToolsProjectionComponent.prototype.onBlur_deprMethod = function () {
	        this.getEstLifeList(this.model.propType, this.model.pisDate, this.model.deprMethod);
	    };
	    ToolsProjectionComponent.prototype.onBlur_estLife = function () {
	    };
	    ToolsProjectionComponent.prototype.onSubmit = function () {
	        this.PostProject();
	    };
	    return ToolsProjectionComponent;
	}());
	ToolsProjectionComponent = __decorate([
	    core_1.Component({
	        template: __webpack_require__(51)
	    }),
	    __metadata("design:paramtypes", [tools_service_1.ToolsService])
	], ToolsProjectionComponent);
	exports.ToolsProjectionComponent = ToolsProjectionComponent;


/***/ },
/* 49 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
	    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
	    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
	    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
	    return c > 3 && r && Object.defineProperty(target, key, r), r;
	};
	var __metadata = (this && this.__metadata) || function (k, v) {
	    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
	};
	var core_1 = __webpack_require__(3);
	var http_1 = __webpack_require__(20);
	var http_2 = __webpack_require__(20);
	var Observable_1 = __webpack_require__(30);
	__webpack_require__(31);
	__webpack_require__(32);
	__webpack_require__(33);
	var RuleItemDto = (function () {
	    function RuleItemDto(id, name, value) {
	        this.id = id;
	        this.name = name;
	        this.value = value;
	    }
	    return RuleItemDto;
	}());
	exports.RuleItemDto = RuleItemDto;
	var DepreciableBookDto = (function () {
	    function DepreciableBookDto(PropertyType, PlaceInServiceDate, AcquiredValue, DepreciateMethod, DepreciatePercent, EstimatedLife, Section179, ITCAmount, ITCReduce, SalvageDeduction, Bonus911Percent, Convention, RunDate, MPStartDate, MPEndDate) {
	        this.PropertyType = PropertyType;
	        this.PlaceInServiceDate = PlaceInServiceDate;
	        this.AcquiredValue = AcquiredValue;
	        this.DepreciateMethod = DepreciateMethod;
	        this.DepreciatePercent = DepreciatePercent;
	        this.EstimatedLife = EstimatedLife;
	        this.Section179 = Section179;
	        this.ITCAmount = ITCAmount;
	        this.ITCReduce = ITCReduce;
	        this.SalvageDeduction = SalvageDeduction;
	        this.Bonus911Percent = Bonus911Percent;
	        this.Convention = Convention;
	        this.RunDate = RunDate;
	        this.MPStartDate = MPStartDate;
	        this.MPEndDate = MPEndDate;
	    }
	    return DepreciableBookDto;
	}());
	exports.DepreciableBookDto = DepreciableBookDto;
	var PeriodDeprItemDto = (function () {
	    function PeriodDeprItemDto(FiscalYearStartDate, FiscalYearEndDate, FiscalYearBeginAccum, FiscalYearEndAccum, FiscalYearDeprAmount, PeriodStartDate, PeriodEndDate, PeriodBeginAccum, PeriodEndAccum, PeriodDeprAmount, CalcFlags, AdjustmentAmt) {
	        this.FiscalYearStartDate = FiscalYearStartDate;
	        this.FiscalYearEndDate = FiscalYearEndDate;
	        this.FiscalYearBeginAccum = FiscalYearBeginAccum;
	        this.FiscalYearEndAccum = FiscalYearEndAccum;
	        this.FiscalYearDeprAmount = FiscalYearDeprAmount;
	        this.PeriodStartDate = PeriodStartDate;
	        this.PeriodEndDate = PeriodEndDate;
	        this.PeriodBeginAccum = PeriodBeginAccum;
	        this.PeriodEndAccum = PeriodEndAccum;
	        this.PeriodDeprAmount = PeriodDeprAmount;
	        this.CalcFlags = CalcFlags;
	        this.AdjustmentAmt = AdjustmentAmt;
	    }
	    return PeriodDeprItemDto;
	}());
	exports.PeriodDeprItemDto = PeriodDeprItemDto;
	var ToolsService = (function () {
	    function ToolsService(http) {
	        this.http = http;
	        this.propertyTypeListUrl = 'api/rules/proptypes';
	        this.deprMehodListtUrl = 'api/rules/deprmethods';
	        this.estLifeListUrl = 'api/rules/estlifes';
	        this.projectUrl = 'api/calcs/project';
	    }
	    ToolsService.prototype.getPropTypeList = function () {
	        return this.http.get(this.propertyTypeListUrl)
	            .map(this.extractData)
	            .catch(this.handleError);
	    };
	    ToolsService.prototype.getDeprMehodList = function (propType, pisDate) {
	        var params = new http_1.URLSearchParams();
	        params.set('propertyType', propType);
	        params.set('pisDate', pisDate);
	        return this.http.get(this.deprMehodListtUrl, { search: params })
	            .map(this.extractData)
	            .catch(this.handleError);
	    };
	    ToolsService.prototype.getEstLifeList = function (propType, pisDate, deprMethod) {
	        var params = new http_1.URLSearchParams();
	        params.set('propertyType', propType);
	        params.set('pisDate', pisDate);
	        params.set('deprMethod', deprMethod);
	        return this.http.get(this.estLifeListUrl, { search: params })
	            .map(this.extractData)
	            .catch(this.handleError);
	    };
	    ToolsService.prototype.postProject = function (deprBook) {
	        var headers = new http_2.Headers({ 'Content-Type': 'application/json' });
	        var options = new http_2.RequestOptions({ headers: headers });
	        return this.http.post(this.projectUrl, deprBook, options)
	            .map(this.extractData)
	            .catch(this.handleError);
	    };
	    ToolsService.prototype.extractData = function (res) {
	        var body = res.json();
	        return body || {};
	    };
	    ToolsService.prototype.handleError = function (error) {
	        // In a real world app, we might use a remote logging infrastructure
	        var errMsg;
	        if (error instanceof http_1.Response) {
	            var body = error.json() || '';
	            var err = body.error || JSON.stringify(body);
	            errMsg = error.status + " - " + (error.statusText || '') + " " + err;
	        }
	        else {
	            errMsg = error.message ? error.message : error.toString();
	        }
	        console.error(errMsg);
	        return Observable_1.Observable.throw(errMsg);
	    };
	    return ToolsService;
	}());
	ToolsService = __decorate([
	    core_1.Injectable(),
	    __metadata("design:paramtypes", [http_1.Http])
	], ToolsService);
	exports.ToolsService = ToolsService;


/***/ },
/* 50 */
/***/ function(module, exports) {

	"use strict";
	var Book = (function () {
	    function Book(propType, pisDate, acqValue, deprMethod, estLife) {
	        this.propType = propType;
	        this.pisDate = pisDate;
	        this.acqValue = acqValue;
	        this.deprMethod = deprMethod;
	        this.estLife = estLife;
	    }
	    return Book;
	}());
	exports.Book = Book;


/***/ },
/* 51 */
/***/ function(module, exports) {

	module.exports = "<div class=\"container\">\r\n    <div>\r\n        <h1>T - D</h1>\r\n        <div class=\"col-sm-5\">\r\n            <form novalidate  (ngSubmit)=\"onSubmit()\" #heroForm=\"ngForm\">\r\n                <div class=\"form-group row\">\r\n                    <label for=\"propType\" class=\"col-sm-4 col-form-label\">Prop Type</label>\r\n                    <div class=\"col-sm-8\">\r\n                        <select class=\"form-control\" id=\"propType\" name=\"propType\" [(ngModel)]=\"model.propType\" (blur)=\"onBlur_propType()\" required>\r\n                            <option *ngFor=\"let item of propTypeList\" [value]=\"item.name\">{{item.name}}</option>\r\n                        </select>\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group row\">\r\n                    <label for=\"pisDate\" class=\"col-sm-4 col-form-label\">Place-in-Service</label>\r\n                    <div class=\"col-sm-8\">\r\n                        <input type=\"date\" class=\"form-control\" id=\"pisDate\" name=\"pisDate\" [(ngModel)]=\"model.pisDate\" (blur)=\"onBlur_pisDate()\" >\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group row\">\r\n                    <label for=\"acqValue\" class=\"col-sm-4 col-form-label\">Acquisition Value</label>\r\n                    <div class=\"col-sm-8\">\r\n                        <input type=\"number\" class=\"form-control\" id=\"acqValue\" name=\"acqValue\" [(ngModel)]=\"model.acqValue\" (blur)=\"onBlur_acqValue()\" >\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group row\">\r\n                    <label for=\"deprMethod\" class=\"col-sm-4 col-form-label\">Depr Method</label>\r\n                    <div class=\"col-sm-8\">\r\n                        <select class=\"form-control\" id=\"deprMethod\" name=\"deprMethod\" [(ngModel)]=\"model.deprMethod\" (blur)=\"onBlur_deprMethod()\" required>\r\n                            <option *ngFor=\"let item of deprMethodList\" [value]=\"item.name\">{{item.name}}</option>\r\n                        </select>\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group row\">\r\n                    <label for=\"estLife\" class=\"col-sm-4 col-form-label\">Est Life</label>\r\n                    <div class=\"col-sm-8\">\r\n                        <select class=\"form-control\" id=\"estLife\" name=\"estLife\" [(ngModel)]=\"model.estLife\" (blur)=\"onBlur_estLife()\" required>\r\n                            <option *ngFor=\"let item of estLifeList\" [value]=\"item.name\">{{item.name}}</option>\r\n                        </select>\r\n                    </div>\r\n                </div>\r\n                <button type=\"submit\" class=\"btn btn-success\" [disabled]=\"!heroForm.form.valid\">Calculate</button>\r\n                <button type=\"button\" class=\"btn btn-default\" (click)=\"newHero(); heroForm.reset()\">Reset</button>\r\n            </form>\r\n        </div>\r\n        <div class=\"col-sm-7\">\r\n            <p>Property Type: {{ model.propType }}</p>\r\n            <p>Placed-in-service: {{ model.pisDate }}</p>\r\n            <p>Acquisition Value: {{ model.acqValue }}</p>\r\n            <p>Depr Method: {{ model.deprMethod }}</p>\r\n            <p>Est Life: {{ model.estLife }}</p>\r\n\r\n            <table class=\"table\">\r\n                <thead>\r\n                    <tr>\r\n                        <th>Fiscal Yr Start</th>\r\n                        <th>Fiscal Yr End</th>\r\n                        <th>Period Start</th>\r\n                        <th>Period End</th>\r\n                        <th>Begin Accum</th>\r\n                        <th>End Accum</th>\r\n                        <th>Depr Amount</th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n                    <tr *ngFor=\"let item of prdDeprItems\">\r\n                        <td>{{item.fiscalYearStartDate}}</td>\r\n                        <td>{{item.fiscalYearEndDate}}</td>\r\n                        <td>{{item.periodStartDate}}</td>\r\n                        <td>{{item.periodEndDate}}</td>\r\n                        <td>{{item.periodBeginAccum}}</td>\r\n                        <td>{{item.periodEndAccum}}</td>\r\n                        <td>{{item.periodDeprAmount}}</td>\r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n"

/***/ },
/* 52 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
	    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
	    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
	    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
	    return c > 3 && r && Object.defineProperty(target, key, r), r;
	};
	var core_1 = __webpack_require__(3);
	var router_1 = __webpack_require__(16);
	var tools_depreciate_component_1 = __webpack_require__(47);
	var tools_projection_component_1 = __webpack_require__(48);
	var ToolsRoutingModule = (function () {
	    function ToolsRoutingModule() {
	    }
	    return ToolsRoutingModule;
	}());
	ToolsRoutingModule = __decorate([
	    core_1.NgModule({
	        imports: [router_1.RouterModule.forChild([
	                { path: 'tools/depreciate', component: tools_depreciate_component_1.ToolsDepreciateComponent },
	                { path: 'tools/projection', component: tools_projection_component_1.ToolsProjectionComponent }
	            ])],
	        exports: [router_1.RouterModule]
	    })
	], ToolsRoutingModule);
	exports.ToolsRoutingModule = ToolsRoutingModule;


/***/ }
/******/ ])));
//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlYnBhY2s6Ly8vd2VicGFjay9ib290c3RyYXAgYzdhYzA4ZjI2Mzc3MzUyZjEzYzciLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL2Jvb3Qtc2VydmVyLnRzIiwid2VicGFjazovLy9leHRlcm5hbCBcImFuZ3VsYXIyLXVuaXZlcnNhbC1wb2x5ZmlsbHNcIiIsIndlYnBhY2s6Ly8vZXh0ZXJuYWwgXCJ6b25lLmpzXCIiLCJ3ZWJwYWNrOi8vL2V4dGVybmFsIFwiQGFuZ3VsYXIvY29yZVwiIiwid2VicGFjazovLy9leHRlcm5hbCBcImFuZ3VsYXIyLXVuaXZlcnNhbFwiIiwid2VicGFjazovLy8uL0NsaWVudEFwcC9hcHAvYXBwLm1vZHVsZS50cyIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvYXBwL2NvbXBvbmVudHMvYXBwL2FwcC5jb21wb25lbnQudHMiLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL2FwcC9jb21wb25lbnRzL2FwcC9hcHAuY29tcG9uZW50Lmh0bWwiLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL2FwcC9jb21wb25lbnRzL2FwcC9hcHAuY29tcG9uZW50LmNzcz9kZGMzIiwid2VicGFjazovLy8uL0NsaWVudEFwcC9hcHAvY29tcG9uZW50cy9hcHAvYXBwLmNvbXBvbmVudC5jc3MiLCJ3ZWJwYWNrOi8vLy4vfi9jc3MtbG9hZGVyL2xpYi9jc3MtYmFzZS5qcyIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvYXBwL2NvbXBvbmVudHMvbmF2bWVudS9uYXZtZW51LmNvbXBvbmVudC50cyIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvYXBwL2NvbXBvbmVudHMvbmF2bWVudS9uYXZtZW51LmNvbXBvbmVudC5odG1sIiwid2VicGFjazovLy8uL0NsaWVudEFwcC9hcHAvY29tcG9uZW50cy9uYXZtZW51L25hdm1lbnUuY29tcG9uZW50LmNzcz85ZjY0Iiwid2VicGFjazovLy8uL0NsaWVudEFwcC9hcHAvY29tcG9uZW50cy9uYXZtZW51L25hdm1lbnUuY29tcG9uZW50LmNzcyIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvYXBwL2FwcC1yb3V0aW5nLm1vZHVsZS50cyIsIndlYnBhY2s6Ly8vZXh0ZXJuYWwgXCJAYW5ndWxhci9yb3V0ZXJcIiIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvYXBwL2NvbXBvbmVudHMvaG9tZS9ob21lLmNvbXBvbmVudC50cyIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvYXBwL2NvbXBvbmVudHMvaG9tZS9ob21lLmNvbXBvbmVudC5odG1sIiwid2VicGFjazovLy8uL0NsaWVudEFwcC9hcHAvY29tcG9uZW50cy9mZXRjaGRhdGEvZmV0Y2hkYXRhLmNvbXBvbmVudC50cyIsIndlYnBhY2s6Ly8vZXh0ZXJuYWwgXCJAYW5ndWxhci9odHRwXCIiLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL2FwcC9jb21wb25lbnRzL2ZldGNoZGF0YS9mZXRjaGRhdGEuY29tcG9uZW50Lmh0bWwiLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL2FwcC9jb21wb25lbnRzL2NvdW50ZXIvY291bnRlci5jb21wb25lbnQudHMiLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL2FwcC9jb21wb25lbnRzL2NvdW50ZXIvY291bnRlci5jb21wb25lbnQuaHRtbCIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvYXBwL2NvbXBvbmVudHMvbm90LWZvdW5kLmNvbXBvbmVudC50cyIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvYXBwL2ZlYXR1cmUtbW9kdWxlcy9hc3NldHMvYXNzZXRzLm1vZHVsZS50cyIsIndlYnBhY2s6Ly8vZXh0ZXJuYWwgXCJAYW5ndWxhci9jb21tb25cIiIsIndlYnBhY2s6Ly8vZXh0ZXJuYWwgXCJAYW5ndWxhci9mb3Jtc1wiIiwid2VicGFjazovLy8uL0NsaWVudEFwcC9hcHAvZmVhdHVyZS1tb2R1bGVzL2Fzc2V0cy9hc3NldHMtbGlzdC5jb21wb25lbnQudHMiLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL2FwcC9mZWF0dXJlLW1vZHVsZXMvYXNzZXRzL2Fzc2V0cy5zZXJ2aWNlLnRzIiwid2VicGFjazovLy9leHRlcm5hbCBcInJ4anMvT2JzZXJ2YWJsZVwiIiwid2VicGFjazovLy9leHRlcm5hbCBcInJ4anMvYWRkL29wZXJhdG9yL2NhdGNoXCIiLCJ3ZWJwYWNrOi8vL2V4dGVybmFsIFwicnhqcy9hZGQvb3BlcmF0b3IvbWFwXCIiLCJ3ZWJwYWNrOi8vL2V4dGVybmFsIFwicnhqcy9SeFwiIiwid2VicGFjazovLy8uL0NsaWVudEFwcC9hcHAvYXBwLXNldHRpbmdzLnRzIiwid2VicGFjazovLy8uL0NsaWVudEFwcC9hcHAvZmVhdHVyZS1tb2R1bGVzL2Fzc2V0cy9hc3NldHMtbGlzdC5jb21wb25lbnQuaHRtbCIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvYXBwL2ZlYXR1cmUtbW9kdWxlcy9hc3NldHMvYXNzZXRzLXVwZGF0ZS5jb21wb25lbnQudHMiLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL2FwcC9mZWF0dXJlLW1vZHVsZXMvYXNzZXRzL2Fzc2V0cy11cGRhdGUuY29tcG9uZW50Lmh0bWwiLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL2FwcC9mZWF0dXJlLW1vZHVsZXMvYXNzZXRzL2Fzc2V0cy1yb3V0aW5nLm1vZHVsZS50cyIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvYXBwL2ZlYXR1cmUtbW9kdWxlcy9kZXByZWNpYXRlL2RlcHJlY2lhdGUubW9kdWxlLnRzIiwid2VicGFjazovLy8uL0NsaWVudEFwcC9hcHAvZmVhdHVyZS1tb2R1bGVzL2RlcHJlY2lhdGUvZGVwcmVjaWF0ZS1wcm9qZWN0aW9uLmNvbXBvbmVudC50cyIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvYXBwL2ZlYXR1cmUtbW9kdWxlcy9kZXByZWNpYXRlL2hlcm8udHMiLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL2FwcC9mZWF0dXJlLW1vZHVsZXMvZGVwcmVjaWF0ZS9kZXByZWNpYXRlLXByb2plY3Rpb24uY29tcG9uZW50Lmh0bWwiLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL2FwcC9mZWF0dXJlLW1vZHVsZXMvZGVwcmVjaWF0ZS9kZXByZWNpYXRlLW1vbnRobHlwcm9qZWN0aW9uLmNvbXBvbmVudC50cyIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvYXBwL2ZlYXR1cmUtbW9kdWxlcy9kZXByZWNpYXRlL2RlcHJlY2lhdGUuc2VydmljZS50cyIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvYXBwL2ZlYXR1cmUtbW9kdWxlcy9kZXByZWNpYXRlL2RlcHJlY2lhdGUtcm91dGluZy5tb2R1bGUudHMiLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL2FwcC9mZWF0dXJlLW1vZHVsZXMvdG9vbHMvdG9vbHMubW9kdWxlLnRzIiwid2VicGFjazovLy8uL0NsaWVudEFwcC9hcHAvZmVhdHVyZS1tb2R1bGVzL3Rvb2xzL3Rvb2xzLWRlcHJlY2lhdGUuY29tcG9uZW50LnRzIiwid2VicGFjazovLy8uL0NsaWVudEFwcC9hcHAvZmVhdHVyZS1tb2R1bGVzL3Rvb2xzL3Rvb2xzLXByb2plY3Rpb24uY29tcG9uZW50LnRzIiwid2VicGFjazovLy8uL0NsaWVudEFwcC9hcHAvZmVhdHVyZS1tb2R1bGVzL3Rvb2xzL3Rvb2xzLnNlcnZpY2UudHMiLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL2FwcC9mZWF0dXJlLW1vZHVsZXMvdG9vbHMvYm9vay50cyIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvYXBwL2ZlYXR1cmUtbW9kdWxlcy90b29scy90b29scy1wcm9qZWN0aW9uLmNvbXBvbmVudC5odG1sIiwid2VicGFjazovLy8uL0NsaWVudEFwcC9hcHAvZmVhdHVyZS1tb2R1bGVzL3Rvb2xzL3Rvb2xzLXJvdXRpbmcubW9kdWxlLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7QUFBQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQSx1QkFBZTtBQUNmO0FBQ0E7QUFDQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBOzs7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aEIsZUFBVSxHQUFWLFVBQVUsQ0FBUTtTQUNsQixZQUFPLEdBQVAsT0FBTyxDQUFRO0tBQ3RCLENBQUM7S0FDVCxXQUFDO0FBQUQsRUFBQztBQVJZLHFCQUFJOzs7Ozs7O0FDQWpCLG1wQkFBa3BCLFdBQVcsbTVDQUFtNUMsV0FBVywwaUJBQTBpQixXQUFXLDRUQUE0VCxtSkFBbUosa0JBQWtCLDRDQUE0QyxpQkFBaUIsNENBQTRDLGtCQUFrQixzQ0FBc0Msb0JBQW9CLG1DQUFtQyxpQkFBaUIsZ25CQUFnbkIsMEJBQTBCLHVDQUF1Qyx3QkFBd0IsdUNBQXVDLHNCQUFzQix1Q0FBdUMsb0JBQW9CLHVDQUF1Qyx1QkFBdUIsdUNBQXVDLHFCQUFxQix1Q0FBdUMsdUJBQXVCLHFJOzs7Ozs7Ozs7Ozs7O0FDQW56SSxxQ0FBb0Q7QUFDcEQsd0NBQXNEO0FBRXRELDREQUEyRTtBQUMzRSw0REFBeUU7QUFTekUsS0FBYSxrQkFBa0I7S0FBL0I7S0FBa0MsQ0FBQztLQUFELHlCQUFDO0FBQUQsRUFBQztBQUF0QixtQkFBa0I7S0FQOUIsZUFBUSxDQUFDO1NBQ04sT0FBTyxFQUFFLENBQUMscUJBQVksQ0FBQyxRQUFRLENBQUM7aUJBQzVCLEVBQUUsSUFBSSxFQUFFLGtCQUFrQixFQUFFLFNBQVMsRUFBRSxxREFBd0IsRUFBRTtpQkFDakUsRUFBRSxJQUFJLEVBQUUsa0JBQWtCLEVBQUUsU0FBUyxFQUFFLHFEQUF3QixFQUFFO2NBQ3BFLENBQUMsQ0FBQztTQUNILE9BQU8sRUFBRSxDQUFDLHFCQUFZLENBQUM7TUFDMUIsQ0FBQztJQUNXLGtCQUFrQixDQUFJO0FBQXRCLGlEQUFrQiIsImZpbGUiOiJtYWluLXNlcnZlci5qcyIsInNvdXJjZXNDb250ZW50IjpbIiBcdC8vIFRoZSBtb2R1bGUgY2FjaGVcbiBcdHZhciBpbnN0YWxsZWRNb2R1bGVzID0ge307XG5cbiBcdC8vIFRoZSByZXF1aXJlIGZ1bmN0aW9uXG4gXHRmdW5jdGlvbiBfX3dlYnBhY2tfcmVxdWlyZV9fKG1vZHVsZUlkKSB7XG5cbiBcdFx0Ly8gQ2hlY2sgaWYgbW9kdWxlIGlzIGluIGNhY2hlXG4gXHRcdGlmKGluc3RhbGxlZE1vZHVsZXNbbW9kdWxlSWRdKVxuIFx0XHRcdHJldHVybiBpbnN0YWxsZWRNb2R1bGVzW21vZHVsZUlkXS5leHBvcnRzO1xuXG4gXHRcdC8vIENyZWF0ZSBhIG5ldyBtb2R1bGUgKGFuZCBwdXQgaXQgaW50byB0aGUgY2FjaGUpXG4gXHRcdHZhciBtb2R1bGUgPSBpbnN0YWxsZWRNb2R1bGVzW21vZHVsZUlkXSA9IHtcbiBcdFx0XHRleHBvcnRzOiB7fSxcbiBcdFx0XHRpZDogbW9kdWxlSWQsXG4gXHRcdFx0bG9hZGVkOiBmYWxzZVxuIFx0XHR9O1xuXG4gXHRcdC8vIEV4ZWN1dGUgdGhlIG1vZHVsZSBmdW5jdGlvblxuIFx0XHRtb2R1bGVzW21vZHVsZUlkXS5jYWxsKG1vZHVsZS5leHBvcnRzLCBtb2R1bGUsIG1vZHVsZS5leHBvcnRzLCBfX3dlYnBhY2tfcmVxdWlyZV9fKTtcblxuIFx0XHQvLyBGbGFnIHRoZSBtb2R1bGUgYXMgbG9hZGVkXG4gXHRcdG1vZHVsZS5sb2FkZWQgPSB0cnVlO1xuXG4gXHRcdC8vIFJldHVybiB0aGUgZXhwb3J0cyBvZiB0aGUgbW9kdWxlXG4gXHRcdHJldHVybiBtb2R1bGUuZXhwb3J0cztcbiBcdH1cblxuXG4gXHQvLyBleHBvc2UgdGhlIG1vZHVsZXMgb2JqZWN0IChfX3dlYnBhY2tfbW9kdWxlc19fKVxuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5tID0gbW9kdWxlcztcblxuIFx0Ly8gZXhwb3NlIHRoZSBtb2R1bGUgY2FjaGVcbiBcdF9fd2VicGFja19yZXF1aXJlX18uYyA9IGluc3RhbGxlZE1vZHVsZXM7XG5cbiBcdC8vIF9fd2VicGFja19wdWJsaWNfcGF0aF9fXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLnAgPSBcIi9kaXN0L1wiO1xuXG4gXHQvLyBMb2FkIGVudHJ5IG1vZHVsZSBhbmQgcmV0dXJuIGV4cG9ydHNcbiBcdHJldHVybiBfX3dlYnBhY2tfcmVxdWlyZV9fKDApO1xuXG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIHdlYnBhY2svYm9vdHN0cmFwIGM3YWMwOGYyNjM3NzM1MmYxM2M3IiwiaW1wb3J0ICdhbmd1bGFyMi11bml2ZXJzYWwtcG9seWZpbGxzJztcbmltcG9ydCAnem9uZS5qcyc7XG5pbXBvcnQgeyBlbmFibGVQcm9kTW9kZSB9IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuaW1wb3J0IHsgcGxhdGZvcm1Ob2RlRHluYW1pYyB9IGZyb20gJ2FuZ3VsYXIyLXVuaXZlcnNhbCc7XG5pbXBvcnQgeyBBcHBNb2R1bGUgfSBmcm9tICcuL2FwcC9hcHAubW9kdWxlJztcblxuZW5hYmxlUHJvZE1vZGUoKTtcbmNvbnN0IHBsYXRmb3JtID0gcGxhdGZvcm1Ob2RlRHluYW1pYygpO1xuXG5leHBvcnQgZGVmYXVsdCBmdW5jdGlvbiAocGFyYW1zOiBhbnkpIDogUHJvbWlzZTx7IGh0bWw6IHN0cmluZywgZ2xvYmFscz86IGFueSB9PiB7XG4gICAgcmV0dXJuIG5ldyBQcm9taXNlKChyZXNvbHZlLCByZWplY3QpID0+IHtcbiAgICAgICAgY29uc3QgcmVxdWVzdFpvbmUgPSBab25lLmN1cnJlbnQuZm9yayh7XG4gICAgICAgICAgICBuYW1lOiAnYW5ndWxhci11bml2ZXJzYWwgcmVxdWVzdCcsXG4gICAgICAgICAgICBwcm9wZXJ0aWVzOiB7XG4gICAgICAgICAgICAgICAgYmFzZVVybDogJy8nLFxuICAgICAgICAgICAgICAgIHJlcXVlc3RVcmw6IHBhcmFtcy51cmwsXG4gICAgICAgICAgICAgICAgb3JpZ2luVXJsOiBwYXJhbXMub3JpZ2luLFxuICAgICAgICAgICAgICAgIHByZWJvb3Q6IGZhbHNlLFxuICAgICAgICAgICAgICAgIC8vIFRPRE86IFJlbmRlciBqdXN0IHRoZSA8YXBwPiBjb21wb25lbnQgaW5zdGVhZCBvZiB3cmFwcGluZyBpdCBpbnNpZGUgYW4gZXh0cmEgSFRNTCBkb2N1bWVudFxuICAgICAgICAgICAgICAgIC8vIFdhaXRpbmcgb24gaHR0cHM6Ly9naXRodWIuY29tL2FuZ3VsYXIvdW5pdmVyc2FsL2lzc3Vlcy8zNDdcbiAgICAgICAgICAgICAgICBkb2N1bWVudDogJzwhRE9DVFlQRSBodG1sPjxodG1sPjxoZWFkPjwvaGVhZD48Ym9keT48YXBwPjwvYXBwPjwvYm9keT48L2h0bWw+J1xuICAgICAgICAgICAgfSxcbiAgICAgICAgICAgIG9uSGFuZGxlRXJyb3I6IChwYXJlbnRab25lLCBjdXJyZW50Wm9uZSwgdGFyZ2V0Wm9uZSwgZXJyb3IpID0+IHtcbiAgICAgICAgICAgICAgICAvLyBJZiBhbnkgZXJyb3Igb2NjdXJzIHdoaWxlIHJlbmRlcmluZyB0aGUgbW9kdWxlLCByZWplY3QgdGhlIHdob2xlIG9wZXJhdGlvblxuICAgICAgICAgICAgICAgIHJlamVjdChlcnJvcik7XG4gICAgICAgICAgICAgICAgcmV0dXJuIHRydWU7XG4gICAgICAgICAgICB9XG4gICAgICAgIH0pO1xuXG4gICAgICAgIHJldHVybiByZXF1ZXN0Wm9uZS5ydW48UHJvbWlzZTxzdHJpbmc+PigoKSA9PiBwbGF0Zm9ybS5zZXJpYWxpemVNb2R1bGUoQXBwTW9kdWxlKSkudGhlbihodG1sID0+IHtcbiAgICAgICAgICAgIHJlc29sdmUoeyBodG1sOiBodG1sIH0pO1xuICAgICAgICB9LCByZWplY3QpO1xuICAgIH0pO1xufVxuXG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL2Jvb3Qtc2VydmVyLnRzIiwibW9kdWxlLmV4cG9ydHMgPSByZXF1aXJlKFwiYW5ndWxhcjItdW5pdmVyc2FsLXBvbHlmaWxsc1wiKTtcblxuXG4vLy8vLy8vLy8vLy8vLy8vLy9cbi8vIFdFQlBBQ0sgRk9PVEVSXG4vLyBleHRlcm5hbCBcImFuZ3VsYXIyLXVuaXZlcnNhbC1wb2x5ZmlsbHNcIlxuLy8gbW9kdWxlIGlkID0gMVxuLy8gbW9kdWxlIGNodW5rcyA9IDAiLCJtb2R1bGUuZXhwb3J0cyA9IHJlcXVpcmUoXCJ6b25lLmpzXCIpO1xuXG5cbi8vLy8vLy8vLy8vLy8vLy8vL1xuLy8gV0VCUEFDSyBGT09URVJcbi8vIGV4dGVybmFsIFwiem9uZS5qc1wiXG4vLyBtb2R1bGUgaWQgPSAyXG4vLyBtb2R1bGUgY2h1bmtzID0gMCIsIm1vZHVsZS5leHBvcnRzID0gcmVxdWlyZShcIkBhbmd1bGFyL2NvcmVcIik7XG5cblxuLy8vLy8vLy8vLy8vLy8vLy8vXG4vLyBXRUJQQUNLIEZPT1RFUlxuLy8gZXh0ZXJuYWwgXCJAYW5ndWxhci9jb3JlXCJcbi8vIG1vZHVsZSBpZCA9IDNcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwibW9kdWxlLmV4cG9ydHMgPSByZXF1aXJlKFwiYW5ndWxhcjItdW5pdmVyc2FsXCIpO1xuXG5cbi8vLy8vLy8vLy8vLy8vLy8vL1xuLy8gV0VCUEFDSyBGT09URVJcbi8vIGV4dGVybmFsIFwiYW5ndWxhcjItdW5pdmVyc2FsXCJcbi8vIG1vZHVsZSBpZCA9IDRcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwiaW1wb3J0IHsgTmdNb2R1bGUgfSBmcm9tICdAYW5ndWxhci9jb3JlJztcbmltcG9ydCB7IFJvdXRlck1vZHVsZSB9IGZyb20gJ0Bhbmd1bGFyL3JvdXRlcic7XG5pbXBvcnQgeyBVbml2ZXJzYWxNb2R1bGUgfSBmcm9tICdhbmd1bGFyMi11bml2ZXJzYWwnO1xuXG5pbXBvcnQgeyBBcHBDb21wb25lbnQgfSBmcm9tICcuL2NvbXBvbmVudHMvYXBwL2FwcC5jb21wb25lbnQnXG5pbXBvcnQgeyBOYXZNZW51Q29tcG9uZW50IH0gZnJvbSAnLi9jb21wb25lbnRzL25hdm1lbnUvbmF2bWVudS5jb21wb25lbnQnO1xuaW1wb3J0IHsgQXBwUm91dGluZ01vZHVsZSwgcm91dGVkQ29tcG9uZW50cyB9IGZyb20gJy4vYXBwLXJvdXRpbmcubW9kdWxlJztcblxuaW1wb3J0IHsgQXNzZXRzTW9kdWxlIH0gZnJvbSAnLi9mZWF0dXJlLW1vZHVsZXMvYXNzZXRzL2Fzc2V0cy5tb2R1bGUnXG5pbXBvcnQgeyBEZXByZWNpYXRlTW9kdWxlIH0gZnJvbSAnLi9mZWF0dXJlLW1vZHVsZXMvZGVwcmVjaWF0ZS9kZXByZWNpYXRlLm1vZHVsZSdcbmltcG9ydCB7IFRvb2xzTW9kdWxlIH0gZnJvbSAnLi9mZWF0dXJlLW1vZHVsZXMvdG9vbHMvdG9vbHMubW9kdWxlJ1xuXG5ATmdNb2R1bGUoe1xuICAgIGltcG9ydHM6IFtcbiAgICAgICAgVW5pdmVyc2FsTW9kdWxlLCAvLyBNdXN0IGJlIGZpcnN0IGltcG9ydC4gVGhpcyBhdXRvbWF0aWNhbGx5IGltcG9ydHMgQnJvd3Nlck1vZHVsZSwgSHR0cE1vZHVsZSwgYW5kIEpzb25wTW9kdWxlIHRvby5cbiAgICAgICAgQXNzZXRzTW9kdWxlLFxuICAgICAgICBEZXByZWNpYXRlTW9kdWxlLFxuICAgICAgICBUb29sc01vZHVsZSxcbiAgICAgICAgQXBwUm91dGluZ01vZHVsZVxuICAgIF0sXG4gICAgZGVjbGFyYXRpb25zOiBbXG4gICAgICAgIEFwcENvbXBvbmVudCxcbiAgICAgICAgTmF2TWVudUNvbXBvbmVudCxcbiAgICAgICAgcm91dGVkQ29tcG9uZW50c1xuICAgIF0sXG4gICAgYm9vdHN0cmFwOiBbQXBwQ29tcG9uZW50XVxufSlcbmV4cG9ydCBjbGFzcyBBcHBNb2R1bGUge1xufVxuXG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL2FwcC9hcHAubW9kdWxlLnRzIiwiaW1wb3J0IHsgQ29tcG9uZW50IH0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5cbkBDb21wb25lbnQoe1xuICAgIHNlbGVjdG9yOiAnYXBwJyxcbiAgICB0ZW1wbGF0ZTogcmVxdWlyZSgnLi9hcHAuY29tcG9uZW50Lmh0bWwnKSxcbiAgICBzdHlsZXM6IFtyZXF1aXJlKCcuL2FwcC5jb21wb25lbnQuY3NzJyldXG59KVxuZXhwb3J0IGNsYXNzIEFwcENvbXBvbmVudCB7XG59XG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL2FwcC9jb21wb25lbnRzL2FwcC9hcHAuY29tcG9uZW50LnRzIiwibW9kdWxlLmV4cG9ydHMgPSBcIjwhLS0gRml4ZWQgbmF2YmFyIC0tPlxcclxcbjxuYXYtbWVudT48L25hdi1tZW51PlxcclxcblxcclxcbjxkaXYgY2xhc3M9XFxcImNvbnRhaW5lclxcXCIgcm9sZT1cXFwibWFpblxcXCI+XFxyXFxuICAgIDxyb3V0ZXItb3V0bGV0Pjwvcm91dGVyLW91dGxldD5cXHJcXG48L2Rpdj5cXHJcXG5cIlxuXG5cbi8vLy8vLy8vLy8vLy8vLy8vL1xuLy8gV0VCUEFDSyBGT09URVJcbi8vIC4vQ2xpZW50QXBwL2FwcC9jb21wb25lbnRzL2FwcC9hcHAuY29tcG9uZW50Lmh0bWxcbi8vIG1vZHVsZSBpZCA9IDdcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwiXG4gICAgICAgIHZhciByZXN1bHQgPSByZXF1aXJlKFwiISEuLy4uLy4uLy4uLy4uL25vZGVfbW9kdWxlcy9jc3MtbG9hZGVyL2luZGV4LmpzIS4vYXBwLmNvbXBvbmVudC5jc3NcIik7XG5cbiAgICAgICAgaWYgKHR5cGVvZiByZXN1bHQgPT09IFwic3RyaW5nXCIpIHtcbiAgICAgICAgICAgIG1vZHVsZS5leHBvcnRzID0gcmVzdWx0O1xuICAgICAgICB9IGVsc2Uge1xuICAgICAgICAgICAgbW9kdWxlLmV4cG9ydHMgPSByZXN1bHQudG9TdHJpbmcoKTtcbiAgICAgICAgfVxuICAgIFxuXG5cbi8vLy8vLy8vLy8vLy8vLy8vL1xuLy8gV0VCUEFDSyBGT09URVJcbi8vIC4vQ2xpZW50QXBwL2FwcC9jb21wb25lbnRzL2FwcC9hcHAuY29tcG9uZW50LmNzc1xuLy8gbW9kdWxlIGlkID0gOFxuLy8gbW9kdWxlIGNodW5rcyA9IDAiLCJleHBvcnRzID0gbW9kdWxlLmV4cG9ydHMgPSByZXF1aXJlKFwiLi8uLi8uLi8uLi8uLi9ub2RlX21vZHVsZXMvY3NzLWxvYWRlci9saWIvY3NzLWJhc2UuanNcIikoKTtcbi8vIGltcG9ydHNcblxuXG4vLyBtb2R1bGVcbmV4cG9ydHMucHVzaChbbW9kdWxlLmlkLCBcIkBtZWRpYSAobWF4LXdpZHRoOiA3NjdweCkge1xcbiAgICAvKiBPbiBzbWFsbCBzY3JlZW5zLCB0aGUgbmF2IG1lbnUgc3BhbnMgdGhlIGZ1bGwgd2lkdGggb2YgdGhlIHNjcmVlbi4gTGVhdmUgYSBzcGFjZSBmb3IgaXQuICovXFxuICAgIC5ib2R5LWNvbnRlbnQge1xcbiAgICAgICAgcGFkZGluZy10b3A6IDBweDtcXG4gICAgfVxcbn1cIiwgXCJcIl0pO1xuXG4vLyBleHBvcnRzXG5cblxuXG4vLy8vLy8vLy8vLy8vLy8vLy9cbi8vIFdFQlBBQ0sgRk9PVEVSXG4vLyAuL34vY3NzLWxvYWRlciEuL0NsaWVudEFwcC9hcHAvY29tcG9uZW50cy9hcHAvYXBwLmNvbXBvbmVudC5jc3Ncbi8vIG1vZHVsZSBpZCA9IDlcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwiLypcclxuXHRNSVQgTGljZW5zZSBodHRwOi8vd3d3Lm9wZW5zb3VyY2Uub3JnL2xpY2Vuc2VzL21pdC1saWNlbnNlLnBocFxyXG5cdEF1dGhvciBUb2JpYXMgS29wcGVycyBAc29rcmFcclxuKi9cclxuLy8gY3NzIGJhc2UgY29kZSwgaW5qZWN0ZWQgYnkgdGhlIGNzcy1sb2FkZXJcclxubW9kdWxlLmV4cG9ydHMgPSBmdW5jdGlvbigpIHtcclxuXHR2YXIgbGlzdCA9IFtdO1xyXG5cclxuXHQvLyByZXR1cm4gdGhlIGxpc3Qgb2YgbW9kdWxlcyBhcyBjc3Mgc3RyaW5nXHJcblx0bGlzdC50b1N0cmluZyA9IGZ1bmN0aW9uIHRvU3RyaW5nKCkge1xyXG5cdFx0dmFyIHJlc3VsdCA9IFtdO1xyXG5cdFx0Zm9yKHZhciBpID0gMDsgaSA8IHRoaXMubGVuZ3RoOyBpKyspIHtcclxuXHRcdFx0dmFyIGl0ZW0gPSB0aGlzW2ldO1xyXG5cdFx0XHRpZihpdGVtWzJdKSB7XHJcblx0XHRcdFx0cmVzdWx0LnB1c2goXCJAbWVkaWEgXCIgKyBpdGVtWzJdICsgXCJ7XCIgKyBpdGVtWzFdICsgXCJ9XCIpO1xyXG5cdFx0XHR9IGVsc2Uge1xyXG5cdFx0XHRcdHJlc3VsdC5wdXNoKGl0ZW1bMV0pO1xyXG5cdFx0XHR9XHJcblx0XHR9XHJcblx0XHRyZXR1cm4gcmVzdWx0LmpvaW4oXCJcIik7XHJcblx0fTtcclxuXHJcblx0Ly8gaW1wb3J0IGEgbGlzdCBvZiBtb2R1bGVzIGludG8gdGhlIGxpc3RcclxuXHRsaXN0LmkgPSBmdW5jdGlvbihtb2R1bGVzLCBtZWRpYVF1ZXJ5KSB7XHJcblx0XHRpZih0eXBlb2YgbW9kdWxlcyA9PT0gXCJzdHJpbmdcIilcclxuXHRcdFx0bW9kdWxlcyA9IFtbbnVsbCwgbW9kdWxlcywgXCJcIl1dO1xyXG5cdFx0dmFyIGFscmVhZHlJbXBvcnRlZE1vZHVsZXMgPSB7fTtcclxuXHRcdGZvcih2YXIgaSA9IDA7IGkgPCB0aGlzLmxlbmd0aDsgaSsrKSB7XHJcblx0XHRcdHZhciBpZCA9IHRoaXNbaV1bMF07XHJcblx0XHRcdGlmKHR5cGVvZiBpZCA9PT0gXCJudW1iZXJcIilcclxuXHRcdFx0XHRhbHJlYWR5SW1wb3J0ZWRNb2R1bGVzW2lkXSA9IHRydWU7XHJcblx0XHR9XHJcblx0XHRmb3IoaSA9IDA7IGkgPCBtb2R1bGVzLmxlbmd0aDsgaSsrKSB7XHJcblx0XHRcdHZhciBpdGVtID0gbW9kdWxlc1tpXTtcclxuXHRcdFx0Ly8gc2tpcCBhbHJlYWR5IGltcG9ydGVkIG1vZHVsZVxyXG5cdFx0XHQvLyB0aGlzIGltcGxlbWVudGF0aW9uIGlzIG5vdCAxMDAlIHBlcmZlY3QgZm9yIHdlaXJkIG1lZGlhIHF1ZXJ5IGNvbWJpbmF0aW9uc1xyXG5cdFx0XHQvLyAgd2hlbiBhIG1vZHVsZSBpcyBpbXBvcnRlZCBtdWx0aXBsZSB0aW1lcyB3aXRoIGRpZmZlcmVudCBtZWRpYSBxdWVyaWVzLlxyXG5cdFx0XHQvLyAgSSBob3BlIHRoaXMgd2lsbCBuZXZlciBvY2N1ciAoSGV5IHRoaXMgd2F5IHdlIGhhdmUgc21hbGxlciBidW5kbGVzKVxyXG5cdFx0XHRpZih0eXBlb2YgaXRlbVswXSAhPT0gXCJudW1iZXJcIiB8fCAhYWxyZWFkeUltcG9ydGVkTW9kdWxlc1tpdGVtWzBdXSkge1xyXG5cdFx0XHRcdGlmKG1lZGlhUXVlcnkgJiYgIWl0ZW1bMl0pIHtcclxuXHRcdFx0XHRcdGl0ZW1bMl0gPSBtZWRpYVF1ZXJ5O1xyXG5cdFx0XHRcdH0gZWxzZSBpZihtZWRpYVF1ZXJ5KSB7XHJcblx0XHRcdFx0XHRpdGVtWzJdID0gXCIoXCIgKyBpdGVtWzJdICsgXCIpIGFuZCAoXCIgKyBtZWRpYVF1ZXJ5ICsgXCIpXCI7XHJcblx0XHRcdFx0fVxyXG5cdFx0XHRcdGxpc3QucHVzaChpdGVtKTtcclxuXHRcdFx0fVxyXG5cdFx0fVxyXG5cdH07XHJcblx0cmV0dXJuIGxpc3Q7XHJcbn07XHJcblxuXG5cbi8vLy8vLy8vLy8vLy8vLy8vL1xuLy8gV0VCUEFDSyBGT09URVJcbi8vIC4vfi9jc3MtbG9hZGVyL2xpYi9jc3MtYmFzZS5qc1xuLy8gbW9kdWxlIGlkID0gMTBcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwiaW1wb3J0IHsgQ29tcG9uZW50IH0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5cbkBDb21wb25lbnQoe1xuICAgIHNlbGVjdG9yOiAnbmF2LW1lbnUnLFxuICAgIHRlbXBsYXRlOiByZXF1aXJlKCcuL25hdm1lbnUuY29tcG9uZW50Lmh0bWwnKSxcbiAgICBzdHlsZXM6IFtyZXF1aXJlKCcuL25hdm1lbnUuY29tcG9uZW50LmNzcycpXVxufSlcbmV4cG9ydCBjbGFzcyBOYXZNZW51Q29tcG9uZW50IHtcbn1cblxuXG5cbi8vIFdFQlBBQ0sgRk9PVEVSIC8vXG4vLyAuL0NsaWVudEFwcC9hcHAvY29tcG9uZW50cy9uYXZtZW51L25hdm1lbnUuY29tcG9uZW50LnRzIiwibW9kdWxlLmV4cG9ydHMgPSBcIjxuYXYgY2xhc3M9XFxcIm5hdmJhciBuYXZiYXItaW52ZXJzZSBcXFwiPlxcclxcbiAgICA8ZGl2IGNsYXNzPVxcXCJjb250YWluZXJcXFwiPlxcclxcbiAgICAgICAgPCEtLSBCcmFuZCBhbmQgdG9nZ2xlIGdldCBncm91cGVkIGZvciBiZXR0ZXIgbW9iaWxlIGRpc3BsYXkgLS0+XFxyXFxuICAgICAgICA8ZGl2IGNsYXNzPVxcXCJuYXZiYXItaGVhZGVyXFxcIj5cXHJcXG4gICAgICAgICAgICA8YnV0dG9uIHR5cGU9XFxcImJ1dHRvblxcXCIgY2xhc3M9XFxcIm5hdmJhci10b2dnbGUgY29sbGFwc2VkXFxcIiBkYXRhLXRvZ2dsZT1cXFwiY29sbGFwc2VcXFwiIGRhdGEtdGFyZ2V0PVxcXCIjbmF2YmFyXFxcIiBhcmlhLWV4cGFuZGVkPVxcXCJmYWxzZVxcXCIgYXJpYS1jb250cm9scz1cXFwibmF2YmFyXFxcIj5cXHJcXG4gICAgICAgICAgICAgICAgPHNwYW4gY2xhc3M9XFxcInNyLW9ubHlcXFwiPlRvZ2dsZSBuYXZpZ2F0aW9uPC9zcGFuPlxcclxcbiAgICAgICAgICAgICAgICA8c3BhbiBjbGFzcz1cXFwiaWNvbi1iYXJcXFwiPjwvc3Bhbj5cXHJcXG4gICAgICAgICAgICAgICAgPHNwYW4gY2xhc3M9XFxcImljb24tYmFyXFxcIj48L3NwYW4+XFxyXFxuICAgICAgICAgICAgICAgIDxzcGFuIGNsYXNzPVxcXCJpY29uLWJhclxcXCI+PC9zcGFuPlxcclxcbiAgICAgICAgICAgIDwvYnV0dG9uPlxcclxcbiAgICAgICAgICAgIDxhIGNsYXNzPVxcXCJuYXZiYXItYnJhbmRcXFwiIGhyZWY9XFxcIlxcXCI+RkFPPC9hPlxcclxcbiAgICAgICAgPC9kaXY+XFxyXFxuXFxyXFxuICAgICAgICA8ZGl2IGlkPVxcXCJuYXZiYXJcXFwiIGNsYXNzPVxcXCJuYXZiYXItY29sbGFwc2UgY29sbGFwc2VcXFwiPlxcclxcbiAgICAgICAgICAgIDx1bCBjbGFzcz1cXFwibmF2IG5hdmJhci1uYXZcXFwiPlxcclxcbiAgICAgICAgICAgICAgICA8bGkgW3JvdXRlckxpbmtBY3RpdmVdPVxcXCJbJ2xpbmstYWN0aXZlJ11cXFwiPjxhIFtyb3V0ZXJMaW5rXT1cXFwiWycvaG9tZSddXFxcIj48c3BhbiBjbGFzcz0nZ2x5cGhpY29uIGdseXBoaWNvbi1ob21lJz48L3NwYW4+IEhvbWU8L2E+PC9saT5cXHJcXG4gICAgICAgICAgICAgICAgPGxpIFtyb3V0ZXJMaW5rQWN0aXZlXT1cXFwiWydsaW5rLWFjdGl2ZSddXFxcIj48YSBbcm91dGVyTGlua109XFxcIlsnL2NvdW50ZXInXVxcXCI+PHNwYW4gY2xhc3M9J2dseXBoaWNvbiBnbHlwaGljb24tZWR1Y2F0aW9uJz48L3NwYW4+IENvdW50ZXI8L2E+PC9saT5cXHJcXG4gICAgICAgICAgICAgICAgPGxpIFtyb3V0ZXJMaW5rQWN0aXZlXT1cXFwiWydsaW5rLWFjdGl2ZSddXFxcIj48YSBbcm91dGVyTGlua109XFxcIlsnL2ZldGNoLWRhdGEnXVxcXCI+PHNwYW4gY2xhc3M9J2dseXBoaWNvbiBnbHlwaGljb24tdGgtbGlzdCc+PC9zcGFuPiBGZXRjaCBkYXRhPC9hPjwvbGk+XFxyXFxuICAgICAgICAgICAgICAgIDxsaSBjbGFzcz1cXFwiZHJvcGRvd25cXFwiPlxcclxcbiAgICAgICAgICAgICAgICAgICAgPGEgaHJlZj1cXFwiI1xcXCIgY2xhc3M9XFxcImRyb3Bkb3duLXRvZ2dsZVxcXCIgZGF0YS10b2dnbGU9XFxcImRyb3Bkb3duXFxcIiByb2xlPVxcXCJidXR0b25cXFwiIGFyaWEtaGFzcG9wdXA9XFxcInRydWVcXFwiIGFyaWEtZXhwYW5kZWQ9XFxcImZhbHNlXFxcIj5Bc3NldCA8c3BhbiBjbGFzcz1cXFwiY2FyZXRcXFwiPjwvc3Bhbj48L2E+XFxyXFxuICAgICAgICAgICAgICAgICAgICA8dWwgY2xhc3M9XFxcImRyb3Bkb3duLW1lbnVcXFwiPlxcclxcbiAgICAgICAgICAgICAgICAgICAgICAgIDxsaT48YSBbcm91dGVyTGlua109XFxcIlsnL2Fzc2V0cy9saXN0J11cXFwiPkFzc2V0IExpc3Q8L2E+PC9saT5cXHJcXG4gICAgICAgICAgICAgICAgICAgICAgICA8bGk+PGEgW3JvdXRlckxpbmtdPVxcXCJbJy9hc3NldHMvZGV0YWlsJ11cXFwiPkFzc2V0IERldGFpbDwvYT48L2xpPlxcclxcbiAgICAgICAgICAgICAgICAgICAgPC91bD5cXHJcXG4gICAgICAgICAgICAgICAgPC9saT5cXHJcXG4gICAgICAgICAgICAgICAgPGxpIGNsYXNzPVxcXCJkcm9wZG93blxcXCI+XFxyXFxuICAgICAgICAgICAgICAgICAgICA8YSBocmVmPVxcXCIjXFxcIiBjbGFzcz1cXFwiZHJvcGRvd24tdG9nZ2xlXFxcIiBkYXRhLXRvZ2dsZT1cXFwiZHJvcGRvd25cXFwiIHJvbGU9XFxcImJ1dHRvblxcXCIgYXJpYS1oYXNwb3B1cD1cXFwidHJ1ZVxcXCIgYXJpYS1leHBhbmRlZD1cXFwiZmFsc2VcXFwiPkRlcHJlY2lhdGlvbiA8c3BhbiBjbGFzcz1cXFwiY2FyZXRcXFwiPjwvc3Bhbj48L2E+XFxyXFxuICAgICAgICAgICAgICAgICAgICA8dWwgY2xhc3M9XFxcImRyb3Bkb3duLW1lbnVcXFwiPlxcclxcbiAgICAgICAgICAgICAgICAgICAgICAgIDxsaT48YSBbcm91dGVyTGlua109XFxcIlsnL2RlcHJlY2lhdGUvcHJvamVjdGlvbiddXFxcIj5Qcm9qZWN0aW9uPC9hPjwvbGk+XFxyXFxuICAgICAgICAgICAgICAgICAgICAgICAgPGxpPjxhIFtyb3V0ZXJMaW5rXT1cXFwiWycvZGVwcmVjaWF0ZS9tb250aGx5cHJvamVjdGlvbiddXFxcIj5Nb250aGx5IFByb2plY3Rpb248L2E+PC9saT5cXHJcXG4gICAgICAgICAgICAgICAgICAgICAgICA8bGk+PGEgaHJlZj1cXFwiI1xcXCI+U29tZXRoaW5nIGVsc2UgaGVyZTwvYT48L2xpPlxcclxcbiAgICAgICAgICAgICAgICAgICAgICAgIDxsaSByb2xlPVxcXCJzZXBhcmF0b3JcXFwiIGNsYXNzPVxcXCJkaXZpZGVyXFxcIj48L2xpPlxcclxcbiAgICAgICAgICAgICAgICAgICAgICAgIDxsaSBjbGFzcz1cXFwiZHJvcGRvd24taGVhZGVyXFxcIj5OYXYgaGVhZGVyPC9saT5cXHJcXG4gICAgICAgICAgICAgICAgICAgICAgICA8bGk+PGEgaHJlZj1cXFwiI1xcXCI+U2VwYXJhdGVkIGxpbms8L2E+PC9saT5cXHJcXG4gICAgICAgICAgICAgICAgICAgICAgICA8bGk+PGEgaHJlZj1cXFwiI1xcXCI+T25lIG1vcmUgc2VwYXJhdGVkIGxpbms8L2E+PC9saT5cXHJcXG4gICAgICAgICAgICAgICAgICAgIDwvdWw+XFxyXFxuICAgICAgICAgICAgICAgIDwvbGk+XFxyXFxuICAgICAgICAgICAgICAgIDxsaSBjbGFzcz1cXFwiZHJvcGRvd25cXFwiPlxcclxcbiAgICAgICAgICAgICAgICAgICAgPGEgaHJlZj1cXFwiI1xcXCIgY2xhc3M9XFxcImRyb3Bkb3duLXRvZ2dsZVxcXCIgZGF0YS10b2dnbGU9XFxcImRyb3Bkb3duXFxcIiByb2xlPVxcXCJidXR0b25cXFwiIGFyaWEtaGFzcG9wdXA9XFxcInRydWVcXFwiIGFyaWEtZXhwYW5kZWQ9XFxcImZhbHNlXFxcIj5Ub29scyA8c3BhbiBjbGFzcz1cXFwiY2FyZXRcXFwiPjwvc3Bhbj48L2E+XFxyXFxuICAgICAgICAgICAgICAgICAgICA8dWwgY2xhc3M9XFxcImRyb3Bkb3duLW1lbnVcXFwiPlxcclxcbiAgICAgICAgICAgICAgICAgICAgICAgIDxsaT48YSBbcm91dGVyTGlua109XFxcIlsnL3Rvb2xzL2RlcHJlY2lhdGUnXVxcXCI+RGVwcmVjaWF0ZTwvYT48L2xpPlxcclxcbiAgICAgICAgICAgICAgICAgICAgICAgIDxsaT48YSBbcm91dGVyTGlua109XFxcIlsnL3Rvb2xzL3Byb2plY3Rpb24nXVxcXCI+UHJvamVjdGlvbjwvYT48L2xpPlxcclxcbiAgICAgICAgICAgICAgICAgICAgPC91bD5cXHJcXG4gICAgICAgICAgICAgICAgPC9saT5cXHJcXG4gICAgICAgICAgICA8L3VsPlxcclxcbiAgICAgICAgPC9kaXY+PCEtLS8ubmF2LWNvbGxhcHNlIC0tPlxcclxcbiAgICA8L2Rpdj5cXHJcXG48L25hdj5cXHJcXG4gICAgPCEtLVxcclxcbiAgICAgICAgICAgIDwvZGl2PlxcclxcbiAgICAgICAgICAgIDxkaXYgY2xhc3M9J2NsZWFyZml4Jz48L2Rpdj5cXHJcXG4gICAgICAgICAgICA8ZGl2IGNsYXNzPSduYXZiYXItY29sbGFwc2UgY29sbGFwc2UnPlxcclxcbiAgICAgICAgICAgICAgICA8dWwgY2xhc3M9J25hdiBuYXZiYXItbmF2Jz5cXHJcXG4gICAgICAgICAgICAgICAgICAgIDxsaSBbcm91dGVyTGlua0FjdGl2ZV09XFxcIlsnbGluay1hY3RpdmUnXVxcXCI+XFxyXFxuICAgICAgICAgICAgICAgICAgICAgICAgPGEgW3JvdXRlckxpbmtdPVxcXCJbJy9ob21lJ11cXFwiPlxcclxcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICA8c3BhbiBjbGFzcz0nZ2x5cGhpY29uIGdseXBoaWNvbi1ob21lJz48L3NwYW4+IEhvbWVcXHJcXG4gICAgICAgICAgICAgICAgICAgICAgICA8L2E+XFxyXFxuICAgICAgICAgICAgICAgICAgICA8L2xpPlxcclxcbiAgICAgICAgICAgICAgICAgICAgPGxpIFtyb3V0ZXJMaW5rQWN0aXZlXT1cXFwiWydsaW5rLWFjdGl2ZSddXFxcIj5cXHJcXG4gICAgICAgICAgICAgICAgICAgICAgICA8YSBbcm91dGVyTGlua109XFxcIlsnL2NvdW50ZXInXVxcXCI+XFxyXFxuICAgICAgICAgICAgICAgICAgICAgICAgICAgIDxzcGFuIGNsYXNzPSdnbHlwaGljb24gZ2x5cGhpY29uLWVkdWNhdGlvbic+PC9zcGFuPiBDb3VudGVyXFxyXFxuICAgICAgICAgICAgICAgICAgICAgICAgPC9hPlxcclxcbiAgICAgICAgICAgICAgICAgICAgPC9saT5cXHJcXG4gICAgICAgICAgICAgICAgICAgIDxsaSBbcm91dGVyTGlua0FjdGl2ZV09XFxcIlsnbGluay1hY3RpdmUnXVxcXCI+XFxyXFxuICAgICAgICAgICAgICAgICAgICAgICAgPGEgW3JvdXRlckxpbmtdPVxcXCJbJy9mZXRjaC1kYXRhJ11cXFwiPlxcclxcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICA8c3BhbiBjbGFzcz0nZ2x5cGhpY29uIGdseXBoaWNvbi10aC1saXN0Jz48L3NwYW4+IEZldGNoIGRhdGFcXHJcXG4gICAgICAgICAgICAgICAgICAgICAgICA8L2E+XFxyXFxuICAgICAgICAgICAgICAgICAgICA8L2xpPlxcclxcbiAgICAgICAgICAgICAgICA8L3VsPlxcclxcbiAgICAgICAgICAgIDwvZGl2PlxcclxcbiAgICAgICAgPC9uYXY+XFxyXFxuICAgICAgICAtLT5cXHJcXG5cIlxuXG5cbi8vLy8vLy8vLy8vLy8vLy8vL1xuLy8gV0VCUEFDSyBGT09URVJcbi8vIC4vQ2xpZW50QXBwL2FwcC9jb21wb25lbnRzL25hdm1lbnUvbmF2bWVudS5jb21wb25lbnQuaHRtbFxuLy8gbW9kdWxlIGlkID0gMTJcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwiXG4gICAgICAgIHZhciByZXN1bHQgPSByZXF1aXJlKFwiISEuLy4uLy4uLy4uLy4uL25vZGVfbW9kdWxlcy9jc3MtbG9hZGVyL2luZGV4LmpzIS4vbmF2bWVudS5jb21wb25lbnQuY3NzXCIpO1xuXG4gICAgICAgIGlmICh0eXBlb2YgcmVzdWx0ID09PSBcInN0cmluZ1wiKSB7XG4gICAgICAgICAgICBtb2R1bGUuZXhwb3J0cyA9IHJlc3VsdDtcbiAgICAgICAgfSBlbHNlIHtcbiAgICAgICAgICAgIG1vZHVsZS5leHBvcnRzID0gcmVzdWx0LnRvU3RyaW5nKCk7XG4gICAgICAgIH1cbiAgICBcblxuXG4vLy8vLy8vLy8vLy8vLy8vLy9cbi8vIFdFQlBBQ0sgRk9PVEVSXG4vLyAuL0NsaWVudEFwcC9hcHAvY29tcG9uZW50cy9uYXZtZW51L25hdm1lbnUuY29tcG9uZW50LmNzc1xuLy8gbW9kdWxlIGlkID0gMTNcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwiZXhwb3J0cyA9IG1vZHVsZS5leHBvcnRzID0gcmVxdWlyZShcIi4vLi4vLi4vLi4vLi4vbm9kZV9tb2R1bGVzL2Nzcy1sb2FkZXIvbGliL2Nzcy1iYXNlLmpzXCIpKCk7XG4vLyBpbXBvcnRzXG5cblxuLy8gbW9kdWxlXG5leHBvcnRzLnB1c2goW21vZHVsZS5pZCwgXCJsaSAuZ2x5cGhpY29uIHtcXG4gICAgbWFyZ2luLXJpZ2h0OiAxMHB4O1xcbn1cXG5cXG4vKiBIaWdobGlnaHRpbmcgcnVsZXMgZm9yIG5hdiBtZW51IGl0ZW1zICovXFxubGkubGluay1hY3RpdmUgYSxcXG5saS5saW5rLWFjdGl2ZSBhOmhvdmVyLFxcbmxpLmxpbmstYWN0aXZlIGE6Zm9jdXMge1xcbiAgICBiYWNrZ3JvdW5kLWNvbG9yOiAjNDE4OUM3O1xcbiAgICBjb2xvcjogd2hpdGU7XFxufVxcblxcbi8qIEtlZXAgdGhlIG5hdiBtZW51IGluZGVwZW5kZW50IG9mIHNjcm9sY29sLXNtLTlsaW5nIGFuZCBvbiB0b3Agb2Ygb3RoZXIgaXRlbXMgKi9cXG4ubWFpbi1uYXYge1xcbiAgICBwb3NpdGlvbjogZml4ZWQ7XFxuICAgIHRvcDogMDtcXG4gICAgbGVmdDogMDtcXG4gICAgcmlnaHQ6IDA7XFxuICAgIHotaW5kZXg6IDE7XFxufVxcblxcbkBtZWRpYSAobWluLXdpZHRoOiA3NjhweCkge1xcbiAgICAvKiBPbiBzbWFsbCBzY3JlZW5zLCBjb252ZXJ0IHRoZSBuYXYgbWVudSB0byBhIHZlcnRpY2FsIHNpZGViYXIgKi9cXG59XFxuXCIsIFwiXCJdKTtcblxuLy8gZXhwb3J0c1xuXG5cblxuLy8vLy8vLy8vLy8vLy8vLy8vXG4vLyBXRUJQQUNLIEZPT1RFUlxuLy8gLi9+L2Nzcy1sb2FkZXIhLi9DbGllbnRBcHAvYXBwL2NvbXBvbmVudHMvbmF2bWVudS9uYXZtZW51LmNvbXBvbmVudC5jc3Ncbi8vIG1vZHVsZSBpZCA9IDE0XG4vLyBtb2R1bGUgY2h1bmtzID0gMCIsImltcG9ydCB7IE5nTW9kdWxlIH0gZnJvbSAnQGFuZ3VsYXIvY29yZSdcclxuaW1wb3J0IHsgUm91dGVzLCBSb3V0ZXJNb2R1bGUgfSBmcm9tICdAYW5ndWxhci9yb3V0ZXInXHJcblxyXG5pbXBvcnQgeyBIb21lQ29tcG9uZW50IH0gZnJvbSAnLi9jb21wb25lbnRzL2hvbWUvaG9tZS5jb21wb25lbnQnO1xuaW1wb3J0IHsgRmV0Y2hEYXRhQ29tcG9uZW50IH0gZnJvbSAnLi9jb21wb25lbnRzL2ZldGNoZGF0YS9mZXRjaGRhdGEuY29tcG9uZW50JztcbmltcG9ydCB7IENvdW50ZXJDb21wb25lbnQgfSBmcm9tICcuL2NvbXBvbmVudHMvY291bnRlci9jb3VudGVyLmNvbXBvbmVudCc7XG5pbXBvcnQgeyBQYWdlTm90Rm91bmRDb21wb25lbnQgfSBmcm9tICcuL2NvbXBvbmVudHMvbm90LWZvdW5kLmNvbXBvbmVudCc7XG5cbmV4cG9ydCBjb25zdCByb3V0ZXM6IFJvdXRlcyA9IFtcclxuICAgIHsgcGF0aDogJ2hvbWUnLCBjb21wb25lbnQ6IEhvbWVDb21wb25lbnQgfSxcbiAgICB7IHBhdGg6ICdjb3VudGVyJywgY29tcG9uZW50OiBDb3VudGVyQ29tcG9uZW50IH0sXG4gICAgeyBwYXRoOiAnZmV0Y2gtZGF0YScsIGNvbXBvbmVudDogRmV0Y2hEYXRhQ29tcG9uZW50IH0sXG4gICAgLy97XHJcbiAgICAvLyAgICBwYXRoOiAnZGVwcmVjaWF0ZScsIGxvYWRDaGlsZHJlbjogKCkgPT4gbmV3IFByb21pc2UocmVzb2x2ZSA9PiB7XHJcbiAgICAvLyAgICAgICAgKHJlcXVpcmUgYXMgYW55KS5lbnN1cmUoW10sIHJlcXVpcmUgPT4ge1xyXG4gICAgLy8gICAgICAgICAgICByZXNvbHZlKHJlcXVpcmUoJ2FwcC9kZXByZWNpYXRlL2RlcHJlY2lhdGUubW9kdWxlJykuRGVwcmVjaWF0ZU1vZHVsZSk7XHJcbiAgICAvLyAgICAgICAgfSlcclxuICAgIC8vICAgIH0pXG4gICAgLy99LFxuXG4gICAgLy97IHBhdGg6ICdkZXByZWNpYXRlMDEnLCBsb2FkQ2hpbGRyZW46ICgpID0+IFN5c3RlbS5pbXBvcnQoJ2FwcC9kZXByZWNpYXRlL2RlcHJlY2lhdGUubW9kdWxlJykudGhlbihtb2QgPT4gbW9kLk1vZHVsZU5hbWUpLFxuXG4gICAgLy97IHBhdGg6ICdkZXByZWNpYXRlJywgbG9hZENoaWxkcmVuOiAnYXBwL2RlcHJlY2lhdGUvZGVwcmVjaWF0ZS5tb2R1bGUjRGVwcmVjaWF0ZU1vZHVsZScgfSxcbiAgICB7IHBhdGg6ICcnLCByZWRpcmVjdFRvOiAnaG9tZScsIHBhdGhNYXRjaDogJ2Z1bGwnIH0sXG4gICAgeyBwYXRoOiAnKionLCBjb21wb25lbnQ6IFBhZ2VOb3RGb3VuZENvbXBvbmVudCAgfVxuXTtcclxuXHJcbkBOZ01vZHVsZSh7XHJcbiAgICBpbXBvcnRzOiBbUm91dGVyTW9kdWxlLmZvclJvb3Qocm91dGVzKV0sXHJcbiAgICBleHBvcnRzOiBbUm91dGVyTW9kdWxlXVxyXG59KVxyXG5leHBvcnQgY2xhc3MgQXBwUm91dGluZ01vZHVsZSB7IH1cclxuXHJcbmV4cG9ydCBjb25zdCByb3V0ZWRDb21wb25lbnRzID0gW0hvbWVDb21wb25lbnQsIENvdW50ZXJDb21wb25lbnQsIEZldGNoRGF0YUNvbXBvbmVudCwgUGFnZU5vdEZvdW5kQ29tcG9uZW50XTtcblxuXG4vLyBXRUJQQUNLIEZPT1RFUiAvL1xuLy8gLi9DbGllbnRBcHAvYXBwL2FwcC1yb3V0aW5nLm1vZHVsZS50cyIsIm1vZHVsZS5leHBvcnRzID0gcmVxdWlyZShcIkBhbmd1bGFyL3JvdXRlclwiKTtcblxuXG4vLy8vLy8vLy8vLy8vLy8vLy9cbi8vIFdFQlBBQ0sgRk9PVEVSXG4vLyBleHRlcm5hbCBcIkBhbmd1bGFyL3JvdXRlclwiXG4vLyBtb2R1bGUgaWQgPSAxNlxuLy8gbW9kdWxlIGNodW5rcyA9IDAiLCJpbXBvcnQgeyBDb21wb25lbnQgfSBmcm9tICdAYW5ndWxhci9jb3JlJztcblxuQENvbXBvbmVudCh7XG4gICAgc2VsZWN0b3I6ICdob21lJyxcbiAgICB0ZW1wbGF0ZTogcmVxdWlyZSgnLi9ob21lLmNvbXBvbmVudC5odG1sJylcbn0pXG5leHBvcnQgY2xhc3MgSG9tZUNvbXBvbmVudCB7XG59XG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL2FwcC9jb21wb25lbnRzL2hvbWUvaG9tZS5jb21wb25lbnQudHMiLCJtb2R1bGUuZXhwb3J0cyA9IFwiPGgxPkhlbGxvLCB3b3JsZCE8L2gxPlxcclxcbjxwPldlbGNvbWUgdG8geW91ciBuZXcgc2luZ2xlLXBhZ2UgYXBwbGljYXRpb24sIGJ1aWx0IHdpdGg6PC9wPlxcclxcbjx1bD5cXHJcXG4gICAgPGxpPjxhIGhyZWY9J2h0dHBzOi8vZ2V0LmFzcC5uZXQvJz5BU1AuTkVUIENvcmU8L2E+IGFuZCA8YSBocmVmPSdodHRwczovL21zZG4ubWljcm9zb2Z0LmNvbS9lbi11cy9saWJyYXJ5LzY3ZWY4c2JkLmFzcHgnPkMjPC9hPiBmb3IgY3Jvc3MtcGxhdGZvcm0gc2VydmVyLXNpZGUgY29kZTwvbGk+XFxyXFxuICAgIDxsaT48YSBocmVmPSdodHRwczovL2FuZ3VsYXIuaW8vJz5Bbmd1bGFyIDI8L2E+IGFuZCA8YSBocmVmPSdodHRwOi8vd3d3LnR5cGVzY3JpcHRsYW5nLm9yZy8nPlR5cGVTY3JpcHQ8L2E+IGZvciBjbGllbnQtc2lkZSBjb2RlPC9saT5cXHJcXG4gICAgPGxpPjxhIGhyZWY9J2h0dHBzOi8vd2VicGFjay5naXRodWIuaW8vJz5XZWJwYWNrPC9hPiBmb3IgYnVpbGRpbmcgYW5kIGJ1bmRsaW5nIGNsaWVudC1zaWRlIHJlc291cmNlczwvbGk+XFxyXFxuICAgIDxsaT48YSBocmVmPSdodHRwOi8vZ2V0Ym9vdHN0cmFwLmNvbS8nPkJvb3RzdHJhcDwvYT4gZm9yIGxheW91dCBhbmQgc3R5bGluZzwvbGk+XFxyXFxuPC91bD5cXHJcXG48cD5UbyBoZWxwIHlvdSBnZXQgc3RhcnRlZCwgd2UndmUgYWxzbyBzZXQgdXA6PC9wPlxcclxcbjx1bD5cXHJcXG4gICAgPGxpPjxzdHJvbmc+Q2xpZW50LXNpZGUgbmF2aWdhdGlvbjwvc3Ryb25nPi4gRm9yIGV4YW1wbGUsIGNsaWNrIDxlbT5Db3VudGVyPC9lbT4gdGhlbiA8ZW0+QmFjazwvZW0+IHRvIHJldHVybiBoZXJlLjwvbGk+XFxyXFxuICAgIDxsaT48c3Ryb25nPlNlcnZlci1zaWRlIHByZXJlbmRlcmluZzwvc3Ryb25nPi4gRm9yIGZhc3RlciBpbml0aWFsIGxvYWRpbmcgYW5kIGltcHJvdmVkIFNFTywgeW91ciBBbmd1bGFyIDIgYXBwIGlzIHByZXJlbmRlcmVkIG9uIHRoZSBzZXJ2ZXIuIFRoZSByZXN1bHRpbmcgSFRNTCBpcyB0aGVuIHRyYW5zZmVycmVkIHRvIHRoZSBicm93c2VyIHdoZXJlIGEgY2xpZW50LXNpZGUgY29weSBvZiB0aGUgYXBwIHRha2VzIG92ZXIuPC9saT5cXHJcXG4gICAgPGxpPjxzdHJvbmc+V2VicGFjayBkZXYgbWlkZGxld2FyZTwvc3Ryb25nPi4gSW4gZGV2ZWxvcG1lbnQgbW9kZSwgdGhlcmUncyBubyBuZWVkIHRvIHJ1biB0aGUgPGNvZGU+d2VicGFjazwvY29kZT4gYnVpbGQgdG9vbC4gWW91ciBjbGllbnQtc2lkZSByZXNvdXJjZXMgYXJlIGR5bmFtaWNhbGx5IGJ1aWx0IG9uIGRlbWFuZC4gVXBkYXRlcyBhcmUgYXZhaWxhYmxlIGFzIHNvb24gYXMgeW91IG1vZGlmeSBhbnkgZmlsZS48L2xpPlxcclxcbiAgICA8bGk+PHN0cm9uZz5Ib3QgbW9kdWxlIHJlcGxhY2VtZW50PC9zdHJvbmc+LiBJbiBkZXZlbG9wbWVudCBtb2RlLCB5b3UgZG9uJ3QgZXZlbiBuZWVkIHRvIHJlbG9hZCB0aGUgcGFnZSBhZnRlciBtYWtpbmcgbW9zdCBjaGFuZ2VzLiBXaXRoaW4gc2Vjb25kcyBvZiBzYXZpbmcgY2hhbmdlcyB0byBmaWxlcywgeW91ciBBbmd1bGFyIDIgYXBwIHdpbGwgYmUgcmVidWlsdCBhbmQgYSBuZXcgaW5zdGFuY2UgaW5qZWN0ZWQgaXMgaW50byB0aGUgcGFnZS48L2xpPlxcclxcbiAgICA8bGk+PHN0cm9uZz5FZmZpY2llbnQgcHJvZHVjdGlvbiBidWlsZHM8L3N0cm9uZz4uIEluIHByb2R1Y3Rpb24gbW9kZSwgZGV2ZWxvcG1lbnQtdGltZSBmZWF0dXJlcyBhcmUgZGlzYWJsZWQsIGFuZCB0aGUgPGNvZGU+d2VicGFjazwvY29kZT4gYnVpbGQgdG9vbCBwcm9kdWNlcyBtaW5pZmllZCBzdGF0aWMgQ1NTIGFuZCBKYXZhU2NyaXB0IGZpbGVzLjwvbGk+XFxyXFxuPC91bD5cXHJcXG5cIlxuXG5cbi8vLy8vLy8vLy8vLy8vLy8vL1xuLy8gV0VCUEFDSyBGT09URVJcbi8vIC4vQ2xpZW50QXBwL2FwcC9jb21wb25lbnRzL2hvbWUvaG9tZS5jb21wb25lbnQuaHRtbFxuLy8gbW9kdWxlIGlkID0gMThcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwiaW1wb3J0IHsgQ29tcG9uZW50IH0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5pbXBvcnQgeyBIdHRwIH0gZnJvbSAnQGFuZ3VsYXIvaHR0cCc7XG5cbkBDb21wb25lbnQoe1xuICAgIHNlbGVjdG9yOiAnZmV0Y2hkYXRhJyxcbiAgICB0ZW1wbGF0ZTogcmVxdWlyZSgnLi9mZXRjaGRhdGEuY29tcG9uZW50Lmh0bWwnKVxufSlcbmV4cG9ydCBjbGFzcyBGZXRjaERhdGFDb21wb25lbnQge1xuICAgIHB1YmxpYyBmb3JlY2FzdHM6IFdlYXRoZXJGb3JlY2FzdFtdO1xuXG4gICAgY29uc3RydWN0b3IoaHR0cDogSHR0cCkge1xuICAgICAgICBodHRwLmdldCgnL2FwaS9TYW1wbGVEYXRhL1dlYXRoZXJGb3JlY2FzdHMnKS5zdWJzY3JpYmUocmVzdWx0ID0+IHtcbiAgICAgICAgICAgIHRoaXMuZm9yZWNhc3RzID0gcmVzdWx0Lmpzb24oKTtcbiAgICAgICAgfSk7XG4gICAgfVxufVxuXG5pbnRlcmZhY2UgV2VhdGhlckZvcmVjYXN0IHtcbiAgICBkYXRlRm9ybWF0dGVkOiBzdHJpbmc7XG4gICAgdGVtcGVyYXR1cmVDOiBudW1iZXI7XG4gICAgdGVtcGVyYXR1cmVGOiBudW1iZXI7XG4gICAgc3VtbWFyeTogc3RyaW5nO1xufVxuXG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL2FwcC9jb21wb25lbnRzL2ZldGNoZGF0YS9mZXRjaGRhdGEuY29tcG9uZW50LnRzIiwibW9kdWxlLmV4cG9ydHMgPSByZXF1aXJlKFwiQGFuZ3VsYXIvaHR0cFwiKTtcblxuXG4vLy8vLy8vLy8vLy8vLy8vLy9cbi8vIFdFQlBBQ0sgRk9PVEVSXG4vLyBleHRlcm5hbCBcIkBhbmd1bGFyL2h0dHBcIlxuLy8gbW9kdWxlIGlkID0gMjBcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwibW9kdWxlLmV4cG9ydHMgPSBcIjxoMT5XZWF0aGVyIGZvcmVjYXN0PC9oMT5cXHJcXG48cD5UaGlzIGNvbXBvbmVudCBkZW1vbnN0cmF0ZXMgZmV0Y2hpbmcgZGF0YSBmcm9tIHRoZSBzZXJ2ZXIuPC9wPlxcclxcbjxwICpuZ0lmPVxcXCIhZm9yZWNhc3RzXFxcIj48ZW0+TG9hZGluZy4uLjwvZW0+PC9wPlxcclxcbjx0YWJsZSBjbGFzcz0ndGFibGUnICpuZ0lmPVxcXCJmb3JlY2FzdHNcXFwiPlxcclxcbiAgICA8dGhlYWQ+XFxyXFxuICAgICAgICA8dHI+XFxyXFxuICAgICAgICAgICAgPHRoPkRhdGU8L3RoPlxcclxcbiAgICAgICAgICAgIDx0aD5UZW1wLiAoQyk8L3RoPlxcclxcbiAgICAgICAgICAgIDx0aD5UZW1wLiAoRik8L3RoPlxcclxcbiAgICAgICAgICAgIDx0aD5TdW1tYXJ5PC90aD5cXHJcXG4gICAgICAgIDwvdHI+XFxyXFxuICAgIDwvdGhlYWQ+XFxyXFxuICAgIDx0Ym9keT5cXHJcXG4gICAgICAgIDx0ciAqbmdGb3I9XFxcImxldCBmb3JlY2FzdCBvZiBmb3JlY2FzdHNcXFwiPlxcclxcbiAgICAgICAgICAgIDx0ZD57eyBmb3JlY2FzdC5kYXRlRm9ybWF0dGVkIH19PC90ZD5cXHJcXG4gICAgICAgICAgICA8dGQ+e3sgZm9yZWNhc3QudGVtcGVyYXR1cmVDIH19PC90ZD5cXHJcXG4gICAgICAgICAgICA8dGQ+e3sgZm9yZWNhc3QudGVtcGVyYXR1cmVGIH19PC90ZD5cXHJcXG4gICAgICAgICAgICA8dGQ+e3sgZm9yZWNhc3Quc3VtbWFyeSB9fTwvdGQ+XFxyXFxuICAgICAgICA8L3RyPlxcclxcbiAgICA8L3Rib2R5PlxcclxcbjwvdGFibGU+XFxyXFxuXCJcblxuXG4vLy8vLy8vLy8vLy8vLy8vLy9cbi8vIFdFQlBBQ0sgRk9PVEVSXG4vLyAuL0NsaWVudEFwcC9hcHAvY29tcG9uZW50cy9mZXRjaGRhdGEvZmV0Y2hkYXRhLmNvbXBvbmVudC5odG1sXG4vLyBtb2R1bGUgaWQgPSAyMVxuLy8gbW9kdWxlIGNodW5rcyA9IDAiLCJpbXBvcnQgeyBDb21wb25lbnQgfSBmcm9tICdAYW5ndWxhci9jb3JlJztcblxuQENvbXBvbmVudCh7XG4gICAgc2VsZWN0b3I6ICdjb3VudGVyJyxcbiAgICB0ZW1wbGF0ZTogcmVxdWlyZSgnLi9jb3VudGVyLmNvbXBvbmVudC5odG1sJylcbn0pXG5leHBvcnQgY2xhc3MgQ291bnRlckNvbXBvbmVudCB7XG4gICAgcHVibGljIGN1cnJlbnRDb3VudCA9IDA7XG5cbiAgICBwdWJsaWMgaW5jcmVtZW50Q291bnRlcigpIHtcbiAgICAgICAgdGhpcy5jdXJyZW50Q291bnQrKztcbiAgICB9XG59XG5cblxuXG4vLyBXRUJQQUNLIEZPT1RFUiAvL1xuLy8gLi9DbGllbnRBcHAvYXBwL2NvbXBvbmVudHMvY291bnRlci9jb3VudGVyLmNvbXBvbmVudC50cyIsIm1vZHVsZS5leHBvcnRzID0gXCI8aDI+Q291bnRlcjwvaDI+XFxyXFxuPHA+VGhpcyBpcyBhIHNpbXBsZSBleGFtcGxlIG9mIGFuIEFuZ3VsYXIgMiBjb21wb25lbnQuPC9wPlxcclxcbjxwPkN1cnJlbnQgY291bnQ6IDxzdHJvbmc+e3sgY3VycmVudENvdW50IH19PC9zdHJvbmc+PC9wPlxcclxcbjxidXR0b24gKGNsaWNrKT1cXFwiaW5jcmVtZW50Q291bnRlcigpXFxcIj5JbmNyZW1lbnQ8L2J1dHRvbj5cIlxuXG5cbi8vLy8vLy8vLy8vLy8vLy8vL1xuLy8gV0VCUEFDSyBGT09URVJcbi8vIC4vQ2xpZW50QXBwL2FwcC9jb21wb25lbnRzL2NvdW50ZXIvY291bnRlci5jb21wb25lbnQuaHRtbFxuLy8gbW9kdWxlIGlkID0gMjNcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwiaW1wb3J0IHsgQ29tcG9uZW50IH0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XHJcbkBDb21wb25lbnQoe1xyXG4gICAgdGVtcGxhdGU6ICc8aDI+UGFnZSBub3QgZm91bmQ8L2gyPidcclxufSlcclxuZXhwb3J0IGNsYXNzIFBhZ2VOb3RGb3VuZENvbXBvbmVudCB7IH1cblxuXG4vLyBXRUJQQUNLIEZPT1RFUiAvL1xuLy8gLi9DbGllbnRBcHAvYXBwL2NvbXBvbmVudHMvbm90LWZvdW5kLmNvbXBvbmVudC50cyIsImltcG9ydCB7IE5nTW9kdWxlIH0gICAgICBmcm9tICdAYW5ndWxhci9jb3JlJztcbmltcG9ydCB7IENvbW1vbk1vZHVsZSB9ICBmcm9tICdAYW5ndWxhci9jb21tb24nO1xuaW1wb3J0IHsgRm9ybXNNb2R1bGUgfSAgICAgICAgZnJvbSAnQGFuZ3VsYXIvZm9ybXMnO1xuXG5pbXBvcnQgeyBBc3NldHNMaXN0Q29tcG9uZW50IH0gICAgZnJvbSAnLi9hc3NldHMtbGlzdC5jb21wb25lbnQnO1xuaW1wb3J0IHsgQXNzZXRzVXBkYXRlQ29tcG9uZW50IH0gIGZyb20gJy4vYXNzZXRzLXVwZGF0ZS5jb21wb25lbnQnO1xuaW1wb3J0IHsgQXNzZXRzU2VydmljZSB9ICAgICAgICAgIGZyb20gJy4vYXNzZXRzLnNlcnZpY2UnO1xuaW1wb3J0IHsgQXNzZXRzUm91dGluZ01vZHVsZSB9ICAgZnJvbSAnLi9hc3NldHMtcm91dGluZy5tb2R1bGUnO1xuXG5ATmdNb2R1bGUoe1xuICAgIGltcG9ydHM6IFtDb21tb25Nb2R1bGUsIEZvcm1zTW9kdWxlLCBBc3NldHNSb3V0aW5nTW9kdWxlXSxcbiAgICBkZWNsYXJhdGlvbnM6IFtBc3NldHNMaXN0Q29tcG9uZW50LCBBc3NldHNVcGRhdGVDb21wb25lbnRdLFxuICAgIHByb3ZpZGVyczogW0Fzc2V0c1NlcnZpY2VdXG59KVxuZXhwb3J0IGNsYXNzIEFzc2V0c01vZHVsZSB7IH1cblxuXG4vLyBXRUJQQUNLIEZPT1RFUiAvL1xuLy8gLi9DbGllbnRBcHAvYXBwL2ZlYXR1cmUtbW9kdWxlcy9hc3NldHMvYXNzZXRzLm1vZHVsZS50cyIsIm1vZHVsZS5leHBvcnRzID0gcmVxdWlyZShcIkBhbmd1bGFyL2NvbW1vblwiKTtcblxuXG4vLy8vLy8vLy8vLy8vLy8vLy9cbi8vIFdFQlBBQ0sgRk9PVEVSXG4vLyBleHRlcm5hbCBcIkBhbmd1bGFyL2NvbW1vblwiXG4vLyBtb2R1bGUgaWQgPSAyNlxuLy8gbW9kdWxlIGNodW5rcyA9IDAiLCJtb2R1bGUuZXhwb3J0cyA9IHJlcXVpcmUoXCJAYW5ndWxhci9mb3Jtc1wiKTtcblxuXG4vLy8vLy8vLy8vLy8vLy8vLy9cbi8vIFdFQlBBQ0sgRk9PVEVSXG4vLyBleHRlcm5hbCBcIkBhbmd1bGFyL2Zvcm1zXCJcbi8vIG1vZHVsZSBpZCA9IDI3XG4vLyBtb2R1bGUgY2h1bmtzID0gMCIsImltcG9ydCB7IENvbXBvbmVudCwgT25Jbml0IH0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5pbXBvcnQgeyBBc3NldHNTZXJ2aWNlIH0gICAgIGZyb20gJy4vYXNzZXRzLnNlcnZpY2UnO1xuaW1wb3J0IHtBc3NldH0gZnJvbSAnLi4vLi4vbW9kZWxzL2Fzc2V0JztcblxuQENvbXBvbmVudCh7XG4gICAgdGVtcGxhdGU6IHJlcXVpcmUoJy4vYXNzZXRzLWxpc3QuY29tcG9uZW50Lmh0bWwnKVxuXG59KVxuZXhwb3J0IGNsYXNzIEFzc2V0c0xpc3RDb21wb25lbnQgaW1wbGVtZW50cyBPbkluaXQge1xuXG4gICAgYXNzZXRzOiBBc3NldFtdID0gW107XHJcblxuICAgIGNvbnN0cnVjdG9yKHByaXZhdGUgYXNzZXRzU2VydmljZTogQXNzZXRzU2VydmljZSkgeyB9XG5cbiAgICBuZ09uSW5pdCgpIHtcbiAgICAgICAgdGhpcy5nZXRBc3NldExpc3QoKTtcbiAgICB9XG5cbiAgICBnZXRBc3NldExpc3QoKSB7XG4gICAgICAgIHRoaXMuYXNzZXRzU2VydmljZS5nZXRBc3NldExpc3QoKVxuICAgICAgICAgICAgLnN1YnNjcmliZShcbiAgICAgICAgICAgIGl0ZW1zID0+IHtcbiAgICAgICAgICAgICAgICB0aGlzLmFzc2V0cyA9IGl0ZW1zO1xyXG4gICAgICAgICAgICB9LFxuICAgICAgICAgICAgZXJyb3IgPT4geyBjb25zb2xlLmxvZyhlcnJvcik7IH0pO1xuICAgIH1cblxufVxuXG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL2FwcC9mZWF0dXJlLW1vZHVsZXMvYXNzZXRzL2Fzc2V0cy1saXN0LmNvbXBvbmVudC50cyIsImltcG9ydCB7IEluamVjdGFibGUgfSBmcm9tICdAYW5ndWxhci9jb3JlJztcbmltcG9ydCB7IEh0dHAsIFJlc3BvbnNlLCBIZWFkZXJzLCBSZXF1ZXN0T3B0aW9ucywgVVJMU2VhcmNoUGFyYW1zIH0gZnJvbSAnQGFuZ3VsYXIvaHR0cCc7XG5pbXBvcnQgeyBPYnNlcnZhYmxlIH0gZnJvbSAncnhqcy9PYnNlcnZhYmxlJztcbmltcG9ydCAncnhqcy9hZGQvb3BlcmF0b3IvY2F0Y2gnO1xuaW1wb3J0ICdyeGpzL2FkZC9vcGVyYXRvci9tYXAnO1xuaW1wb3J0ICdyeGpzL1J4JztcblxuaW1wb3J0IHtBcHBTZXR0aW5nc30gZnJvbSAnLi4vLi4vYXBwLXNldHRpbmdzJztcbmltcG9ydCB7QXNzZXR9IGZyb20gJy4uLy4uL21vZGVscy9hc3NldCc7XG5cbkBJbmplY3RhYmxlKClcbmV4cG9ydCBjbGFzcyBBc3NldHNTZXJ2aWNlIHtcbiAgICBwcml2YXRlIGFzc2V0TGlzdFVybCA9ICdhcGkvJyArIEFwcFNldHRpbmdzLlRFTkFOVF9JRCArICcvY29tcGFuaWVzLycgKyBBcHBTZXR0aW5ncy5DT01QQU5ZX0lEICsgJy9hc3NldHMnO1xuXG4gICAgY29uc3RydWN0b3IocHJpdmF0ZSBodHRwOiBIdHRwKSB7IH1cblxuICAgIGdldEFzc2V0TGlzdCgpOiBPYnNlcnZhYmxlPEFzc2V0W10+IHtcbiAgICAgICAgcmV0dXJuIHRoaXMuaHR0cC5nZXQodGhpcy5hc3NldExpc3RVcmwpXG4gICAgICAgICAgICAubWFwKHRoaXMuZXh0cmFjdERhdGEpXG4gICAgICAgICAgICAuY2F0Y2godGhpcy5oYW5kbGVFcnJvcik7XG4gICAgfVxuXG4gICAgcHJpdmF0ZSBleHRyYWN0RGF0YShyZXM6IFJlc3BvbnNlKSB7XG4gICAgICAgIGxldCBib2R5ID0gcmVzLmpzb24oKTtcbiAgICAgICAgcmV0dXJuIGJvZHkgfHwge307XG4gICAgfVxuXG4gICAgcHJpdmF0ZSBoYW5kbGVFcnJvcihlcnJvcjogUmVzcG9uc2UgfCBhbnkpIHtcbiAgICAgICAgLy8gSW4gYSByZWFsIHdvcmxkIGFwcCwgd2UgbWlnaHQgdXNlIGEgcmVtb3RlIGxvZ2dpbmcgaW5mcmFzdHJ1Y3R1cmVcbiAgICAgICAgbGV0IGVyck1zZzogc3RyaW5nO1xuICAgICAgICBpZiAoZXJyb3IgaW5zdGFuY2VvZiBSZXNwb25zZSkge1xuICAgICAgICAgICAgY29uc3QgYm9keSA9IGVycm9yLmpzb24oKSB8fCAnJztcbiAgICAgICAgICAgIGNvbnN0IGVyciA9IGJvZHkuZXJyb3IgfHwgSlNPTi5zdHJpbmdpZnkoYm9keSk7XG4gICAgICAgICAgICBlcnJNc2cgPSBgJHtlcnJvci5zdGF0dXN9IC0gJHtlcnJvci5zdGF0dXNUZXh0IHx8ICcnfSAke2Vycn1gO1xuICAgICAgICB9IGVsc2Uge1xuICAgICAgICAgICAgZXJyTXNnID0gZXJyb3IubWVzc2FnZSA/IGVycm9yLm1lc3NhZ2UgOiBlcnJvci50b1N0cmluZygpO1xuICAgICAgICB9XG4gICAgICAgIGNvbnNvbGUuZXJyb3IoZXJyTXNnKTtcbiAgICAgICAgcmV0dXJuIE9ic2VydmFibGUudGhyb3coZXJyTXNnKTtcbiAgICB9XG5cbn1cblxuXG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL2FwcC9mZWF0dXJlLW1vZHVsZXMvYXNzZXRzL2Fzc2V0cy5zZXJ2aWNlLnRzIiwibW9kdWxlLmV4cG9ydHMgPSByZXF1aXJlKFwicnhqcy9PYnNlcnZhYmxlXCIpO1xuXG5cbi8vLy8vLy8vLy8vLy8vLy8vL1xuLy8gV0VCUEFDSyBGT09URVJcbi8vIGV4dGVybmFsIFwicnhqcy9PYnNlcnZhYmxlXCJcbi8vIG1vZHVsZSBpZCA9IDMwXG4vLyBtb2R1bGUgY2h1bmtzID0gMCIsIm1vZHVsZS5leHBvcnRzID0gcmVxdWlyZShcInJ4anMvYWRkL29wZXJhdG9yL2NhdGNoXCIpO1xuXG5cbi8vLy8vLy8vLy8vLy8vLy8vL1xuLy8gV0VCUEFDSyBGT09URVJcbi8vIGV4dGVybmFsIFwicnhqcy9hZGQvb3BlcmF0b3IvY2F0Y2hcIlxuLy8gbW9kdWxlIGlkID0gMzFcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwibW9kdWxlLmV4cG9ydHMgPSByZXF1aXJlKFwicnhqcy9hZGQvb3BlcmF0b3IvbWFwXCIpO1xuXG5cbi8vLy8vLy8vLy8vLy8vLy8vL1xuLy8gV0VCUEFDSyBGT09URVJcbi8vIGV4dGVybmFsIFwicnhqcy9hZGQvb3BlcmF0b3IvbWFwXCJcbi8vIG1vZHVsZSBpZCA9IDMyXG4vLyBtb2R1bGUgY2h1bmtzID0gMCIsIm1vZHVsZS5leHBvcnRzID0gcmVxdWlyZShcInJ4anMvUnhcIik7XG5cblxuLy8vLy8vLy8vLy8vLy8vLy8vXG4vLyBXRUJQQUNLIEZPT1RFUlxuLy8gZXh0ZXJuYWwgXCJyeGpzL1J4XCJcbi8vIG1vZHVsZSBpZCA9IDMzXG4vLyBtb2R1bGUgY2h1bmtzID0gMCIsImV4cG9ydCBjbGFzcyBBcHBTZXR0aW5ncyB7XHJcbiAgICBwdWJsaWMgc3RhdGljIEFQSV9FTkRQT0lOVCA9ICdodHRwOi8vMTI3LjAuMC4xOjY2NjYvYXBpLyc7XHJcbiAgICBwdWJsaWMgc3RhdGljIFRFTkFOVF9JRCA9ICcwMDAwMDAwMC0wMDAwLTAwMDAtMDAwMC0wMDAwMDAwMDAwMDEnO1xyXG4gICAgcHVibGljIHN0YXRpYyBDT01QQU5ZX0lEID0gJzAwMDAwMDAxLTAwMDAtMDAwMC0wMDAwLTAwMDAwMDAwMDAwMCc7XHJcbn1cblxuXG4vLyBXRUJQQUNLIEZPT1RFUiAvL1xuLy8gLi9DbGllbnRBcHAvYXBwL2FwcC1zZXR0aW5ncy50cyIsIm1vZHVsZS5leHBvcnRzID0gXCI8aDE+QXNzZXRzPC9oMT5cXHJcXG5cXHJcXG5cXHJcXG48dGFibGUgY2xhc3M9XFxcInRhYmxlXFxcIj5cXHJcXG4gICAgPHRoZWFkPlxcclxcbiAgICAgICAgPHRyPlxcclxcbiAgICAgICAgICAgIDx0aD5JRDwvdGg+XFxyXFxuICAgICAgICAgICAgPHRoPlByb3BUeXBlPC90aD5cXHJcXG4gICAgICAgICAgICA8dGg+RGVzY3JpcHRpb248L3RoPlxcclxcbiAgICAgICAgICAgIDx0aD5Mb2NhdGlvbjwvdGg+XFxyXFxuICAgICAgICAgICAgPHRoPkRlcGFydG1lbnQ8L3RoPlxcclxcbiAgICAgICAgICAgIDx0aD5cXHJcXG4gICAgICAgICAgICAgICAgPGEgaHJlZj1cXFwiXFxcIiBbcm91dGVyTGlua109XFxcIlsnL0Fzc2V0Q3JlYXRlJ11cXFwiPlxcclxcbiAgICAgICAgICAgICAgICAgICAgQWRkXFxyXFxuICAgICAgICAgICAgICAgIDwvYT5cXHJcXG4gICAgICAgICAgICA8L3RoPlxcclxcbiAgICAgICAgPC90cj5cXHJcXG4gICAgPC90aGVhZD5cXHJcXG4gICAgPHRib2R5PlxcclxcbiAgICAgICAgPHRyICpuZ0lmPVxcXCIhYXNzZXRzLmxlbmd0aFxcXCI+XFxyXFxuICAgICAgICAgICAgPHRkIGNvbHNwYW49XFxcIjVcXFwiPkxvYWRpbmcuLi48L3RkPlxcclxcbiAgICAgICAgPC90cj5cXHJcXG4gICAgICAgIDx0ciAqbmdGb3I9XFxcImxldCBhc3NldCBvZiBhc3NldHNcXFwiPlxcclxcbiAgICAgICAgICAgIDx0ZD57e2Fzc2V0LmFzc2V0SWR9fTwvdGQ+XFxyXFxuICAgICAgICAgICAgPHRkPnt7YXNzZXQucHJvcFR5cGV9fTwvdGQ+XFxyXFxuICAgICAgICAgICAgPHRkPnt7YXNzZXQuZGVzY3JpcHRpb259fTwvdGQ+XFxyXFxuICAgICAgICAgICAgPHRkPnt7YXNzZXQubG9jYXRpb259fTwvdGQ+XFxyXFxuICAgICAgICAgICAgPHRkPnt7YXNzZXQuZGVwYXJ0bWVudH19PC90ZD5cXHJcXG4gICAgICAgICAgICA8dGQ+XFxyXFxuICAgICAgICAgICAgICAgIDxhIGhyZWY9XFxcIlxcXCIgW3JvdXRlckxpbmtdPVxcXCJbJy9hc3NldHMnLCBhc3NldC5hc3NldElkXVxcXCI+XFxyXFxuICAgICAgICAgICAgICAgICAgICBFZGl0XFxyXFxuICAgICAgICAgICAgICAgIDwvYT5cXHJcXG4gICAgICAgICAgICAgICAgPCEtLTxhIGhyZWY9XFxcImphdmFzY3JpcHQ6dm9pZCgwKVxcXCIgKGNsaWNrKT1cXFwiZGVsZXRlTW9kZWwoYXNzZXQpXFxcIj5cXHJcXG4gICAgICAgICAgICAgICAgICAgIERlbGV0ZVxcclxcbiAgICAgICAgICAgICAgICA8L2E+LS0+XFxyXFxuICAgICAgICAgICAgPC90ZD5cXHJcXG4gICAgICAgIDwvdHI+XFxyXFxuICAgIDwvdGJvZHk+XFxyXFxuPC90YWJsZT5cIlxuXG5cbi8vLy8vLy8vLy8vLy8vLy8vL1xuLy8gV0VCUEFDSyBGT09URVJcbi8vIC4vQ2xpZW50QXBwL2FwcC9mZWF0dXJlLW1vZHVsZXMvYXNzZXRzL2Fzc2V0cy1saXN0LmNvbXBvbmVudC5odG1sXG4vLyBtb2R1bGUgaWQgPSAzNVxuLy8gbW9kdWxlIGNodW5rcyA9IDAiLCJpbXBvcnQgeyBDb21wb25lbnQsIE9uSW5pdCB9IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuXG5pbXBvcnQgeyBBc3NldHNTZXJ2aWNlIH0gICAgIGZyb20gJy4vYXNzZXRzLnNlcnZpY2UnO1xuLy9pbXBvcnQgeyBBc3NldCwgQXNzZXRzU2VydmljZSB9ICAgICBmcm9tICcuL2Fzc2V0cy5zZXJ2aWNlJztcblxuQENvbXBvbmVudCh7XG4gICAgdGVtcGxhdGU6IHJlcXVpcmUoJy4vYXNzZXRzLXVwZGF0ZS5jb21wb25lbnQuaHRtbCcpXG59KVxuZXhwb3J0IGNsYXNzIEFzc2V0c1VwZGF0ZUNvbXBvbmVudCBpbXBsZW1lbnRzIE9uSW5pdCB7XG5cbiAgICBjb25zdHJ1Y3RvcigpIHsgfVxuXG4gICAgbmdPbkluaXQoKSB7XG4gICAgfVxufVxuXG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL2FwcC9mZWF0dXJlLW1vZHVsZXMvYXNzZXRzL2Fzc2V0cy11cGRhdGUuY29tcG9uZW50LnRzIiwibW9kdWxlLmV4cG9ydHMgPSBcIjxoMT5VcGRhdGUgQXNzZXQ8L2gxPlxcclxcblxcclxcblwiXG5cblxuLy8vLy8vLy8vLy8vLy8vLy8vXG4vLyBXRUJQQUNLIEZPT1RFUlxuLy8gLi9DbGllbnRBcHAvYXBwL2ZlYXR1cmUtbW9kdWxlcy9hc3NldHMvYXNzZXRzLXVwZGF0ZS5jb21wb25lbnQuaHRtbFxuLy8gbW9kdWxlIGlkID0gMzdcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwiaW1wb3J0IHsgTmdNb2R1bGUgfSAgICAgICAgICAgIGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuaW1wb3J0IHsgUm91dGVyTW9kdWxlIH0gICAgICAgIGZyb20gJ0Bhbmd1bGFyL3JvdXRlcic7XG5cbmltcG9ydCB7IEFzc2V0c0xpc3RDb21wb25lbnQgfSAgICBmcm9tICcuL2Fzc2V0cy1saXN0LmNvbXBvbmVudCc7XG5pbXBvcnQgeyBBc3NldHNVcGRhdGVDb21wb25lbnQgfSAgZnJvbSAnLi9hc3NldHMtdXBkYXRlLmNvbXBvbmVudCc7XG5cbkBOZ01vZHVsZSh7XG4gICAgaW1wb3J0czogW1JvdXRlck1vZHVsZS5mb3JDaGlsZChbXG4gICAgICAgIHsgcGF0aDogJ2Fzc2V0cy9saXN0JywgY29tcG9uZW50OiBBc3NldHNMaXN0Q29tcG9uZW50IH0sXG4gICAgICAgIHsgcGF0aDogJ2Fzc2V0cy86aWQnLCBjb21wb25lbnQ6IEFzc2V0c1VwZGF0ZUNvbXBvbmVudCB9XG4gICAgXSldLFxuICAgIGV4cG9ydHM6IFtSb3V0ZXJNb2R1bGVdXG59KVxuZXhwb3J0IGNsYXNzIEFzc2V0c1JvdXRpbmdNb2R1bGUgeyB9XG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL2FwcC9mZWF0dXJlLW1vZHVsZXMvYXNzZXRzL2Fzc2V0cy1yb3V0aW5nLm1vZHVsZS50cyIsImltcG9ydCB7IE5nTW9kdWxlIH0gICAgICBmcm9tICdAYW5ndWxhci9jb3JlJztcbmltcG9ydCB7IENvbW1vbk1vZHVsZSB9ICBmcm9tICdAYW5ndWxhci9jb21tb24nO1xuaW1wb3J0IHsgRm9ybXNNb2R1bGUgfSAgICAgICAgZnJvbSAnQGFuZ3VsYXIvZm9ybXMnO1xuXG5pbXBvcnQgeyBEZXByZWNpYXRlUHJvamVjdGlvbkNvbXBvbmVudCB9ICAgIGZyb20gJy4vZGVwcmVjaWF0ZS1wcm9qZWN0aW9uLmNvbXBvbmVudCc7XG5pbXBvcnQgeyBEZXByZWNpYXRlTW9udGhseVByb2plY3Rpb25Db21wb25lbnQgfSAgZnJvbSAnLi9kZXByZWNpYXRlLW1vbnRobHlwcm9qZWN0aW9uLmNvbXBvbmVudCc7XG5pbXBvcnQgeyBEZXByZWNpYXRlU2VydmljZSB9ICAgICAgICAgIGZyb20gJy4vZGVwcmVjaWF0ZS5zZXJ2aWNlJztcbmltcG9ydCB7IERlcHJlY2lhdGVSb3V0aW5nTW9kdWxlIH0gICBmcm9tICcuL2RlcHJlY2lhdGUtcm91dGluZy5tb2R1bGUnO1xuXG5ATmdNb2R1bGUoe1xuICAgIGltcG9ydHM6IFtDb21tb25Nb2R1bGUsIEZvcm1zTW9kdWxlLCBEZXByZWNpYXRlUm91dGluZ01vZHVsZV0sXG4gICAgZGVjbGFyYXRpb25zOiBbRGVwcmVjaWF0ZVByb2plY3Rpb25Db21wb25lbnQsIERlcHJlY2lhdGVNb250aGx5UHJvamVjdGlvbkNvbXBvbmVudF0sXG4gICAgLy9leHBvcnRzOiBbRGVwcmVjaWF0ZVByb2plY3Rpb25Db21wb25lbnQsIERlcHJlY2lhdGVNb250aGx5UHJvamVjdGlvbkNvbXBvbmVudF0sXG4gICAgcHJvdmlkZXJzOiBbRGVwcmVjaWF0ZVNlcnZpY2VdXG59KVxuZXhwb3J0IGNsYXNzIERlcHJlY2lhdGVNb2R1bGUgeyB9XG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL2FwcC9mZWF0dXJlLW1vZHVsZXMvZGVwcmVjaWF0ZS9kZXByZWNpYXRlLm1vZHVsZS50cyIsImltcG9ydCB7IENvbXBvbmVudCwgT25Jbml0IH0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5cbmltcG9ydCB7IENyaXNpcywgRGVwcmVjaWF0ZVNlcnZpY2UgfSAgICAgZnJvbSAnLi9kZXByZWNpYXRlLnNlcnZpY2UnO1xuXG5pbXBvcnQgeyBIZXJvIH0gICAgZnJvbSAnLi9oZXJvJztcblxuQENvbXBvbmVudCh7XG4gICAgLy9tb2R1bGVJZDogbW9kdWxlLmlkLFxuICAgIC8vc2VsZWN0b3I6ICdob21lJyxcbiAgICAvL3RlbXBsYXRlOiBgXG4gICAgLy88aDMgaGlnaGxpZ2h0PkRlcHJlY2lhdGUgUHJvamVjdGlvbjwvaDM+XG4gICAgLy9gXG4gICAgLy90ZW1wbGF0ZVVybDogJy4vZGVwcmVjaWF0ZS1wcm9qZWN0aW9uLmNvbXBvbmVudC5odG1sJyxcbiAgICB0ZW1wbGF0ZTogcmVxdWlyZSgnLi9kZXByZWNpYXRlLXByb2plY3Rpb24uY29tcG9uZW50Lmh0bWwnKVxuXG59KVxuZXhwb3J0IGNsYXNzIERlcHJlY2lhdGVQcm9qZWN0aW9uQ29tcG9uZW50IGltcGxlbWVudHMgT25Jbml0IHtcbiAgICBwb3dlcnMgPSBbJ1JlYWxseSBTbWFydCcsICdTdXBlciBGbGV4aWJsZScsXHJcbiAgICAgICAgJ1N1cGVyIEhvdCcsICdXZWF0aGVyIENoYW5nZXInXTtcclxuICAgIG1vZGVsID0gbmV3IEhlcm8oMTgsICdEciBJUScsIHRoaXMucG93ZXJzWzBdLCAnQ2h1Y2sgT3ZlcnN0cmVldCcpO1xyXG4gICAgc3VibWl0dGVkID0gZmFsc2U7XG5cbiAgICBjb25zdHJ1Y3RvcigpIHsgfVxuXG4gICAgbmdPbkluaXQoKSB7XG4gICAgfVxuXHJcbiAgICBvblN1Ym1pdCgpIHsgdGhpcy5zdWJtaXR0ZWQgPSB0cnVlOyB9XHJcbiAgICBuZXdIZXJvKCkge1xyXG4gICAgICAgIHRoaXMubW9kZWwgPSBuZXcgSGVybyg0MiwgJycsICcnKTtcclxuICAgIH1cbn1cblxuXG5cbi8vIFdFQlBBQ0sgRk9PVEVSIC8vXG4vLyAuL0NsaWVudEFwcC9hcHAvZmVhdHVyZS1tb2R1bGVzL2RlcHJlY2lhdGUvZGVwcmVjaWF0ZS1wcm9qZWN0aW9uLmNvbXBvbmVudC50cyIsImV4cG9ydCBjbGFzcyBIZXJvIHtcclxuICAgIGNvbnN0cnVjdG9yKFxyXG4gICAgICAgIHB1YmxpYyBpZDogbnVtYmVyLFxyXG4gICAgICAgIHB1YmxpYyBuYW1lOiBzdHJpbmcsXHJcbiAgICAgICAgcHVibGljIHBvd2VyOiBzdHJpbmcsXHJcbiAgICAgICAgcHVibGljIGFsdGVyRWdvPzogc3RyaW5nXHJcbiAgICApIHsgfVxyXG59XG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL2FwcC9mZWF0dXJlLW1vZHVsZXMvZGVwcmVjaWF0ZS9oZXJvLnRzIiwibW9kdWxlLmV4cG9ydHMgPSBcIjxkaXYgY2xhc3M9XFxcImNvbnRhaW5lclxcXCI+XFxyXFxuICAgIDxkaXYgW2hpZGRlbl09XFxcInN1Ym1pdHRlZFxcXCI+XFxyXFxuICAgICAgICA8aDE+SGVybyBGb3JtPC9oMT5cXHJcXG4gICAgICAgIDxmb3JtIChuZ1N1Ym1pdCk9XFxcIm9uU3VibWl0KClcXFwiICNoZXJvRm9ybT1cXFwibmdGb3JtXFxcIj5cXHJcXG4gICAgICAgICAgICA8ZGl2IGNsYXNzPVxcXCJmb3JtLWdyb3VwXFxcIj5cXHJcXG4gICAgICAgICAgICAgICAgPGxhYmVsIGZvcj1cXFwibmFtZVxcXCI+TmFtZTwvbGFiZWw+XFxyXFxuICAgICAgICAgICAgICAgIDxpbnB1dCB0eXBlPVxcXCJ0ZXh0XFxcIiBjbGFzcz1cXFwiZm9ybS1jb250cm9sXFxcIiBpZD1cXFwibmFtZVxcXCJcXHJcXG4gICAgICAgICAgICAgICAgICAgICAgIHJlcXVpcmVkXFxyXFxuICAgICAgICAgICAgICAgICAgICAgICBbKG5nTW9kZWwpXT1cXFwibW9kZWwubmFtZVxcXCIgbmFtZT1cXFwibmFtZVxcXCJcXHJcXG4gICAgICAgICAgICAgICAgICAgICAgICNuYW1lPVxcXCJuZ01vZGVsXFxcIj5cXHJcXG4gICAgICAgICAgICAgICAgPGRpdiBbaGlkZGVuXT1cXFwibmFtZS52YWxpZCB8fCBuYW1lLnByaXN0aW5lXFxcIlxcclxcbiAgICAgICAgICAgICAgICAgICAgIGNsYXNzPVxcXCJhbGVydCBhbGVydC1kYW5nZXJcXFwiPlxcclxcbiAgICAgICAgICAgICAgICAgICAgTmFtZSBpcyByZXF1aXJlZFxcclxcbiAgICAgICAgICAgICAgICA8L2Rpdj5cXHJcXG4gICAgICAgICAgICA8L2Rpdj5cXHJcXG4gICAgICAgICAgICA8ZGl2IGNsYXNzPVxcXCJmb3JtLWdyb3VwXFxcIj5cXHJcXG4gICAgICAgICAgICAgICAgPGxhYmVsIGZvcj1cXFwiYWx0ZXJFZ29cXFwiPkFsdGVyIEVnbzwvbGFiZWw+XFxyXFxuICAgICAgICAgICAgICAgIDxpbnB1dCB0eXBlPVxcXCJ0ZXh0XFxcIiBjbGFzcz1cXFwiZm9ybS1jb250cm9sXFxcIiBpZD1cXFwiYWx0ZXJFZ29cXFwiXFxyXFxuICAgICAgICAgICAgICAgICAgICAgICBbKG5nTW9kZWwpXT1cXFwibW9kZWwuYWx0ZXJFZ29cXFwiIG5hbWU9XFxcImFsdGVyRWdvXFxcIj5cXHJcXG4gICAgICAgICAgICA8L2Rpdj5cXHJcXG4gICAgICAgICAgICA8ZGl2IGNsYXNzPVxcXCJmb3JtLWdyb3VwXFxcIj5cXHJcXG4gICAgICAgICAgICAgICAgPGxhYmVsIGZvcj1cXFwicG93ZXJcXFwiPkhlcm8gUG93ZXI8L2xhYmVsPlxcclxcbiAgICAgICAgICAgICAgICA8c2VsZWN0IGNsYXNzPVxcXCJmb3JtLWNvbnRyb2xcXFwiIGlkPVxcXCJwb3dlclxcXCJcXHJcXG4gICAgICAgICAgICAgICAgICAgICAgICByZXF1aXJlZFxcclxcbiAgICAgICAgICAgICAgICAgICAgICAgIFsobmdNb2RlbCldPVxcXCJtb2RlbC5wb3dlclxcXCIgbmFtZT1cXFwicG93ZXJcXFwiXFxyXFxuICAgICAgICAgICAgICAgICAgICAgICAgI3Bvd2VyPVxcXCJuZ01vZGVsXFxcIj5cXHJcXG4gICAgICAgICAgICAgICAgICAgIDxvcHRpb24gKm5nRm9yPVxcXCJsZXQgcG93IG9mIHBvd2Vyc1xcXCIgW3ZhbHVlXT1cXFwicG93XFxcIj57e3Bvd319PC9vcHRpb24+XFxyXFxuICAgICAgICAgICAgICAgIDwvc2VsZWN0PlxcclxcbiAgICAgICAgICAgICAgICA8ZGl2IFtoaWRkZW5dPVxcXCJwb3dlci52YWxpZCB8fCBwb3dlci5wcmlzdGluZVxcXCIgY2xhc3M9XFxcImFsZXJ0IGFsZXJ0LWRhbmdlclxcXCI+XFxyXFxuICAgICAgICAgICAgICAgICAgICBQb3dlciBpcyByZXF1aXJlZFxcclxcbiAgICAgICAgICAgICAgICA8L2Rpdj5cXHJcXG4gICAgICAgICAgICA8L2Rpdj5cXHJcXG4gICAgICAgICAgICA8YnV0dG9uIHR5cGU9XFxcInN1Ym1pdFxcXCIgY2xhc3M9XFxcImJ0biBidG4tc3VjY2Vzc1xcXCIgW2Rpc2FibGVkXT1cXFwiIWhlcm9Gb3JtLmZvcm0udmFsaWRcXFwiPlN1Ym1pdDwvYnV0dG9uPlxcclxcbiAgICAgICAgICAgIDxidXR0b24gdHlwZT1cXFwiYnV0dG9uXFxcIiBjbGFzcz1cXFwiYnRuIGJ0bi1kZWZhdWx0XFxcIiAoY2xpY2spPVxcXCJuZXdIZXJvKCk7IGhlcm9Gb3JtLnJlc2V0KClcXFwiPk5ldyBIZXJvPC9idXR0b24+XFxyXFxuICAgICAgICA8L2Zvcm0+XFxyXFxuICAgIDwvZGl2PlxcclxcbiAgICA8ZGl2IFtoaWRkZW5dPVxcXCIhc3VibWl0dGVkXFxcIj5cXHJcXG4gICAgICAgIDxoMj5Zb3Ugc3VibWl0dGVkIHRoZSBmb2xsb3dpbmc6PC9oMj5cXHJcXG4gICAgICAgIDxkaXYgY2xhc3M9XFxcInJvd1xcXCI+XFxyXFxuICAgICAgICAgICAgPGRpdiBjbGFzcz1cXFwiY29sLXhzLTNcXFwiPk5hbWU8L2Rpdj5cXHJcXG4gICAgICAgICAgICA8ZGl2IGNsYXNzPVxcXCJjb2wteHMtOSAgcHVsbC1sZWZ0XFxcIj57eyBtb2RlbC5uYW1lIH19PC9kaXY+XFxyXFxuICAgICAgICA8L2Rpdj5cXHJcXG4gICAgICAgIDxkaXYgY2xhc3M9XFxcInJvd1xcXCI+XFxyXFxuICAgICAgICAgICAgPGRpdiBjbGFzcz1cXFwiY29sLXhzLTNcXFwiPkFsdGVyIEVnbzwvZGl2PlxcclxcbiAgICAgICAgICAgIDxkaXYgY2xhc3M9XFxcImNvbC14cy05IHB1bGwtbGVmdFxcXCI+e3sgbW9kZWwuYWx0ZXJFZ28gfX08L2Rpdj5cXHJcXG4gICAgICAgIDwvZGl2PlxcclxcbiAgICAgICAgPGRpdiBjbGFzcz1cXFwicm93XFxcIj5cXHJcXG4gICAgICAgICAgICA8ZGl2IGNsYXNzPVxcXCJjb2wteHMtM1xcXCI+UG93ZXI8L2Rpdj5cXHJcXG4gICAgICAgICAgICA8ZGl2IGNsYXNzPVxcXCJjb2wteHMtOSBwdWxsLWxlZnRcXFwiPnt7IG1vZGVsLnBvd2VyIH19PC9kaXY+XFxyXFxuICAgICAgICA8L2Rpdj5cXHJcXG4gICAgICAgIDxicj5cXHJcXG4gICAgICAgIDxidXR0b24gY2xhc3M9XFxcImJ0biBidG4tcHJpbWFyeVxcXCIgKGNsaWNrKT1cXFwic3VibWl0dGVkPWZhbHNlXFxcIj5FZGl0PC9idXR0b24+XFxyXFxuICAgIDwvZGl2PlxcclxcbjwvZGl2PlxcclxcblwiXG5cblxuLy8vLy8vLy8vLy8vLy8vLy8vXG4vLyBXRUJQQUNLIEZPT1RFUlxuLy8gLi9DbGllbnRBcHAvYXBwL2ZlYXR1cmUtbW9kdWxlcy9kZXByZWNpYXRlL2RlcHJlY2lhdGUtcHJvamVjdGlvbi5jb21wb25lbnQuaHRtbFxuLy8gbW9kdWxlIGlkID0gNDJcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwiaW1wb3J0IHsgQ29tcG9uZW50LCBPbkluaXQgfSBmcm9tICdAYW5ndWxhci9jb3JlJztcblxuaW1wb3J0IHsgQ3Jpc2lzLCBEZXByZWNpYXRlU2VydmljZSB9ICAgICBmcm9tICcuL2RlcHJlY2lhdGUuc2VydmljZSc7XG5cbkBDb21wb25lbnQoe1xuICAgIHRlbXBsYXRlOiBgXG4gICAgPGgzIGhpZ2hsaWdodD5EZXByZWNpYXRlIE1vbnRobHkgUHJvamVjdGlvbjwvaDM+XG4gICAgYFxufSlcbmV4cG9ydCBjbGFzcyBEZXByZWNpYXRlTW9udGhseVByb2plY3Rpb25Db21wb25lbnQgaW1wbGVtZW50cyBPbkluaXQge1xuXG4gICAgY29uc3RydWN0b3IoKSB7IH1cblxuICAgIG5nT25Jbml0KCkge1xuICAgIH1cbn1cblxuXG5cbi8vIFdFQlBBQ0sgRk9PVEVSIC8vXG4vLyAuL0NsaWVudEFwcC9hcHAvZmVhdHVyZS1tb2R1bGVzL2RlcHJlY2lhdGUvZGVwcmVjaWF0ZS1tb250aGx5cHJvamVjdGlvbi5jb21wb25lbnQudHMiLCJpbXBvcnQgeyBJbmplY3RhYmxlIH0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5cbmV4cG9ydCBjbGFzcyBDcmlzaXMge1xuICAgIGNvbnN0cnVjdG9yKHB1YmxpYyBpZDogbnVtYmVyLCBwdWJsaWMgbmFtZTogc3RyaW5nKSB7IH1cbn1cblxuQEluamVjdGFibGUoKVxuZXhwb3J0IGNsYXNzIERlcHJlY2lhdGVTZXJ2aWNlIHtcblxufVxuXG5cblxuXG4vLyBXRUJQQUNLIEZPT1RFUiAvL1xuLy8gLi9DbGllbnRBcHAvYXBwL2ZlYXR1cmUtbW9kdWxlcy9kZXByZWNpYXRlL2RlcHJlY2lhdGUuc2VydmljZS50cyIsImltcG9ydCB7IE5nTW9kdWxlIH0gICAgICAgICAgICBmcm9tICdAYW5ndWxhci9jb3JlJztcbmltcG9ydCB7IFJvdXRlck1vZHVsZSB9ICAgICAgICBmcm9tICdAYW5ndWxhci9yb3V0ZXInO1xuXG5pbXBvcnQgeyBEZXByZWNpYXRlUHJvamVjdGlvbkNvbXBvbmVudCB9ICAgIGZyb20gJy4vZGVwcmVjaWF0ZS1wcm9qZWN0aW9uLmNvbXBvbmVudCc7XG5pbXBvcnQgeyBEZXByZWNpYXRlTW9udGhseVByb2plY3Rpb25Db21wb25lbnQgfSAgZnJvbSAnLi9kZXByZWNpYXRlLW1vbnRobHlwcm9qZWN0aW9uLmNvbXBvbmVudCc7XG5cbkBOZ01vZHVsZSh7XG4gICAgaW1wb3J0czogW1JvdXRlck1vZHVsZS5mb3JDaGlsZChbXG4gICAgICAgIHsgcGF0aDogJ2RlcHJlY2lhdGUvcHJvamVjdGlvbicsIGNvbXBvbmVudDogRGVwcmVjaWF0ZVByb2plY3Rpb25Db21wb25lbnQgfSxcbiAgICAgICAgeyBwYXRoOiAnZGVwcmVjaWF0ZS9tb250aGx5cHJvamVjdGlvbicsIGNvbXBvbmVudDogRGVwcmVjaWF0ZU1vbnRobHlQcm9qZWN0aW9uQ29tcG9uZW50IH1cbiAgICBdKV0sXG4gICAgZXhwb3J0czogW1JvdXRlck1vZHVsZV1cbn0pXG5leHBvcnQgY2xhc3MgRGVwcmVjaWF0ZVJvdXRpbmdNb2R1bGUgeyB9XG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL2FwcC9mZWF0dXJlLW1vZHVsZXMvZGVwcmVjaWF0ZS9kZXByZWNpYXRlLXJvdXRpbmcubW9kdWxlLnRzIiwiaW1wb3J0IHsgTmdNb2R1bGUgfSAgICAgIGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuaW1wb3J0IHsgQ29tbW9uTW9kdWxlIH0gIGZyb20gJ0Bhbmd1bGFyL2NvbW1vbic7XG5pbXBvcnQgeyBGb3Jtc01vZHVsZSB9ICAgICAgICBmcm9tICdAYW5ndWxhci9mb3Jtcyc7XG5cbmltcG9ydCB7IFRvb2xzRGVwcmVjaWF0ZUNvbXBvbmVudCB9ICAgIGZyb20gJy4vdG9vbHMtZGVwcmVjaWF0ZS5jb21wb25lbnQnO1xuaW1wb3J0IHsgVG9vbHNQcm9qZWN0aW9uQ29tcG9uZW50IH0gIGZyb20gJy4vdG9vbHMtcHJvamVjdGlvbi5jb21wb25lbnQnO1xuaW1wb3J0IHsgVG9vbHNTZXJ2aWNlIH0gICAgICAgICAgZnJvbSAnLi90b29scy5zZXJ2aWNlJztcbmltcG9ydCB7IFRvb2xzUm91dGluZ01vZHVsZSB9ICAgZnJvbSAnLi90b29scy1yb3V0aW5nLm1vZHVsZSc7XG5cbkBOZ01vZHVsZSh7XG4gICAgaW1wb3J0czogW0NvbW1vbk1vZHVsZSwgRm9ybXNNb2R1bGUsIFRvb2xzUm91dGluZ01vZHVsZV0sXG4gICAgZGVjbGFyYXRpb25zOiBbVG9vbHNEZXByZWNpYXRlQ29tcG9uZW50LCBUb29sc1Byb2plY3Rpb25Db21wb25lbnRdLFxuICAgIHByb3ZpZGVyczogW1Rvb2xzU2VydmljZV1cbn0pXG5leHBvcnQgY2xhc3MgVG9vbHNNb2R1bGUgeyB9XG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL2FwcC9mZWF0dXJlLW1vZHVsZXMvdG9vbHMvdG9vbHMubW9kdWxlLnRzIiwiaW1wb3J0IHsgQ29tcG9uZW50LCBPbkluaXQgfSBmcm9tICdAYW5ndWxhci9jb3JlJztcblxuaW1wb3J0IHsgUnVsZUl0ZW1EdG8sIFRvb2xzU2VydmljZSB9ICAgICBmcm9tICcuL3Rvb2xzLnNlcnZpY2UnO1xuXG5AQ29tcG9uZW50KHtcbiAgICB0ZW1wbGF0ZTogYFxuICAgIDxoMyBoaWdobGlnaHQ+VG9vbCAtIERlcHJlY2lhdGU8L2gzPlxuICAgIGBcbn0pXG5leHBvcnQgY2xhc3MgVG9vbHNEZXByZWNpYXRlQ29tcG9uZW50IGltcGxlbWVudHMgT25Jbml0IHtcblxuICAgIGNvbnN0cnVjdG9yKCkgeyB9XG5cbiAgICBuZ09uSW5pdCgpIHtcbiAgICB9XG59XG5cblxuXG4vLyBXRUJQQUNLIEZPT1RFUiAvL1xuLy8gLi9DbGllbnRBcHAvYXBwL2ZlYXR1cmUtbW9kdWxlcy90b29scy90b29scy1kZXByZWNpYXRlLmNvbXBvbmVudC50cyIsImltcG9ydCB7IENvbXBvbmVudCwgT25Jbml0IH0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5cbmltcG9ydCB7IFJ1bGVJdGVtRHRvLCBEZXByZWNpYWJsZUJvb2tEdG8sIFBlcmlvZERlcHJJdGVtRHRvLCBUb29sc1NlcnZpY2UgfSAgICAgZnJvbSAnLi90b29scy5zZXJ2aWNlJztcblxuaW1wb3J0IHsgQm9vayB9ICAgIGZyb20gJy4vYm9vayc7XG5cbkBDb21wb25lbnQoe1xuICAgIHRlbXBsYXRlOiByZXF1aXJlKCcuL3Rvb2xzLXByb2plY3Rpb24uY29tcG9uZW50Lmh0bWwnKVxufSlcbmV4cG9ydCBjbGFzcyBUb29sc1Byb2plY3Rpb25Db21wb25lbnQgaW1wbGVtZW50cyBPbkluaXQge1xuICAgIHByb3BUeXBlTGlzdDogUnVsZUl0ZW1EdG9bXTtcbiAgICBkZXByTWV0aG9kTGlzdDogUnVsZUl0ZW1EdG9bXTtcbiAgICBlc3RMaWZlTGlzdDogUnVsZUl0ZW1EdG9bXTtcblxuICAgIHByZERlcHJJdGVtczogUGVyaW9kRGVwckl0ZW1EdG9bXTtcblxuICAgIGVycm9yTWVzc2FnZTogc3RyaW5nO1xuICAgIHBvd2VycyA9IFsnUmVhbGx5IFNtYXJ0JywgJ1N1cGVyIEZsZXhpYmxlJywgJ1N1cGVyIEhvdCcsICdXZWF0aGVyIENoYW5nZXInXTtcclxuICAgIG1vZGVsID0gbmV3IEJvb2soJ1AnLCAnMjAwMC0wMS0wMScsIDEwMDAwLjAwLCAnTUYyMDAnLCAnMTAgeXJzIDAwIG1ucycpO1xyXG5cbiAgICBjb25zdHJ1Y3Rvcihwcml2YXRlIHRvb2xzU2VydmljZTogVG9vbHNTZXJ2aWNlKSB7IH1cblxuICAgIG5nT25Jbml0KCkge1xuICAgICAgICB0aGlzLmdldFByb3BUeXBlTGlzdCgpO1xuICAgIH1cblxuICAgIFBvc3RQcm9qZWN0KCkge1xuICAgICAgICBsZXQgZGVwckJvb2sgPSBuZXcgRGVwcmVjaWFibGVCb29rRHRvKFwiUFwiLCBcIjIwMTAtMDEtMDFcIiwgMTAwMDAuMDAsIFwiU0xcIiwgMCwgMTAsIDAsIDAsIDAsIDAsIDAsIFwiXCIsIFwiMjAxNS0xMi0zMVwiLCBcIjE4OTktMTItMzFcIiwgXCIxODk5LTEyLTMxXCIpO1xyXG5cbiAgICAgICAgdGhpcy50b29sc1NlcnZpY2UucG9zdFByb2plY3QoZGVwckJvb2spXG4gICAgICAgICAgICAuc3Vic2NyaWJlKFxuICAgICAgICAgICAgaXRlbXMgPT4ge1xuICAgICAgICAgICAgICAgIHRoaXMucHJkRGVwckl0ZW1zID0gaXRlbXM7XHJcbiAgICAgICAgICAgIH0sXG4gICAgICAgICAgICBlcnJvciA9PiB7IGNvbnNvbGUubG9nKGVycm9yKTsgfSk7XHJcblxyXG4gICAgfVxuXG4gICAgZ2V0UHJvcFR5cGVMaXN0KCkge1xuICAgICAgICB0aGlzLnRvb2xzU2VydmljZS5nZXRQcm9wVHlwZUxpc3QoKVxuICAgICAgICAgICAgLnN1YnNjcmliZShcbiAgICAgICAgICAgIHJ1bGVJdGVtcyA9PiB7XG4gICAgICAgICAgICAgICAgdGhpcy5wcm9wVHlwZUxpc3QgPSBydWxlSXRlbXM7XHJcbiAgICAgICAgICAgIH0sXG4gICAgICAgICAgICBlcnJvciA9PiB7IGNvbnNvbGUubG9nKGVycm9yKTsgfSk7XG4gICAgfVxuXG4gICAgZ2V0RGVwck1ldGhvZExpc3QocHJvcFR5cGU6c3RyaW5nLCBwaXNEYXRlOnN0cmluZykge1xuICAgICAgICB0aGlzLnRvb2xzU2VydmljZS5nZXREZXByTWVob2RMaXN0KHByb3BUeXBlLCBwaXNEYXRlKVxuICAgICAgICAgICAgLnN1YnNjcmliZShcbiAgICAgICAgICAgIHJ1bGVJdGVtcyA9PiB7XG4gICAgICAgICAgICAgICAgdGhpcy5kZXByTWV0aG9kTGlzdCA9IHJ1bGVJdGVtcztcclxuICAgICAgICAgICAgfSxcbiAgICAgICAgICAgIGVycm9yID0+IHsgY29uc29sZS5sb2coZXJyb3IpOyB9KTtcbiAgICB9XG5cbiAgICBnZXRFc3RMaWZlTGlzdChwcm9wVHlwZTogc3RyaW5nLCBwaXNEYXRlOiBzdHJpbmcsIGRlcHJNZXRob2Q6c3RyaW5nKSB7XG4gICAgICAgIHRoaXMudG9vbHNTZXJ2aWNlLmdldEVzdExpZmVMaXN0KHByb3BUeXBlLCBwaXNEYXRlLCBkZXByTWV0aG9kKVxuICAgICAgICAgICAgLnN1YnNjcmliZShcbiAgICAgICAgICAgIHJ1bGVJdGVtcyA9PiB7XG4gICAgICAgICAgICAgICAgdGhpcy5lc3RMaWZlTGlzdCA9IHJ1bGVJdGVtcztcclxuICAgICAgICAgICAgfSxcbiAgICAgICAgICAgIGVycm9yID0+IHsgY29uc29sZS5sb2coZXJyb3IpOyB9KTtcbiAgICB9XG5cbiAgICBvbkJsdXJfcHJvcFR5cGUoKSB7XG5cbiAgICB9XG5cbiAgICBvbkJsdXJfcGlzRGF0ZSgpIHtcbiAgICAgICAgdGhpcy5nZXREZXByTWV0aG9kTGlzdCh0aGlzLm1vZGVsLnByb3BUeXBlLCB0aGlzLm1vZGVsLnBpc0RhdGUpO1xuICAgIH1cblxuICAgIG9uQmx1cl9hY3FWYWx1ZSgpIHtcblxuICAgIH1cblxuICAgIG9uQmx1cl9kZXByTWV0aG9kKCkge1xuICAgICAgICB0aGlzLmdldEVzdExpZmVMaXN0KHRoaXMubW9kZWwucHJvcFR5cGUsIHRoaXMubW9kZWwucGlzRGF0ZSwgdGhpcy5tb2RlbC5kZXByTWV0aG9kKTtcbiAgICB9XG5cbiAgICBvbkJsdXJfZXN0TGlmZSgpIHtcblxuICAgIH1cblxuICAgIG9uU3VibWl0KCkge1xuICAgICAgICB0aGlzLlBvc3RQcm9qZWN0KCk7XG4gICAgfVxufVxuXG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL2FwcC9mZWF0dXJlLW1vZHVsZXMvdG9vbHMvdG9vbHMtcHJvamVjdGlvbi5jb21wb25lbnQudHMiLCJpbXBvcnQgeyBJbmplY3RhYmxlIH0gICAgICAgICAgICAgIGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuaW1wb3J0IHsgSHR0cCwgUmVzcG9uc2UsIFVSTFNlYXJjaFBhcmFtcyB9ICAgICAgICAgIGZyb20gJ0Bhbmd1bGFyL2h0dHAnO1xuaW1wb3J0IHsgSGVhZGVycywgUmVxdWVzdE9wdGlvbnMgfSBmcm9tICdAYW5ndWxhci9odHRwJztcblxuaW1wb3J0IHsgT2JzZXJ2YWJsZSB9IGZyb20gJ3J4anMvT2JzZXJ2YWJsZSc7XG5pbXBvcnQgJ3J4anMvYWRkL29wZXJhdG9yL2NhdGNoJztcbmltcG9ydCAncnhqcy9hZGQvb3BlcmF0b3IvbWFwJztcbmltcG9ydCAncnhqcy9SeCc7XG5cbmV4cG9ydCBjbGFzcyBSdWxlSXRlbUR0byB7XG4gICAgY29uc3RydWN0b3IocHVibGljIGlkOiBudW1iZXIsIHB1YmxpYyBuYW1lOiBzdHJpbmcsIHB1YmxpYyB2YWx1ZTogc3RyaW5nKSB7IH1cbn1cblxuZXhwb3J0IGNsYXNzIERlcHJlY2lhYmxlQm9va0R0byB7XG4gICAgY29uc3RydWN0b3IoXG4gICAgICAgIHB1YmxpYyBQcm9wZXJ0eVR5cGU6IHN0cmluZyxcbiAgICAgICAgcHVibGljIFBsYWNlSW5TZXJ2aWNlRGF0ZTogc3RyaW5nLFxuICAgICAgICBwdWJsaWMgQWNxdWlyZWRWYWx1ZTogbnVtYmVyLFxuICAgICAgICBwdWJsaWMgRGVwcmVjaWF0ZU1ldGhvZDogc3RyaW5nLFxuICAgICAgICBwdWJsaWMgRGVwcmVjaWF0ZVBlcmNlbnQ6IG51bWJlcixcbiAgICAgICAgcHVibGljIEVzdGltYXRlZExpZmU6IG51bWJlcixcbiAgICAgICAgcHVibGljIFNlY3Rpb24xNzk6IG51bWJlcixcbiAgICAgICAgcHVibGljIElUQ0Ftb3VudDogbnVtYmVyLFxuICAgICAgICBwdWJsaWMgSVRDUmVkdWNlOiBudW1iZXIsXG4gICAgICAgIHB1YmxpYyBTYWx2YWdlRGVkdWN0aW9uOiBudW1iZXIsXG4gICAgICAgIHB1YmxpYyBCb251czkxMVBlcmNlbnQ6IG51bWJlcixcbiAgICAgICAgcHVibGljIENvbnZlbnRpb246IHN0cmluZyxcbiAgICAgICAgcHVibGljIFJ1bkRhdGU6IHN0cmluZyxcbiAgICAgICAgcHVibGljIE1QU3RhcnREYXRlOiBzdHJpbmcsXG4gICAgICAgIHB1YmxpYyBNUEVuZERhdGU6IHN0cmluZylcbiAgICB7IH1cbn1cblxuZXhwb3J0IGNsYXNzIFBlcmlvZERlcHJJdGVtRHRvIHtcbiAgICBjb25zdHJ1Y3RvcihcbiAgICAgICAgcHVibGljIEZpc2NhbFllYXJTdGFydERhdGU6IHN0cmluZyxcbiAgICAgICAgcHVibGljIEZpc2NhbFllYXJFbmREYXRlOiBzdHJpbmcsXG5cbiAgICAgICAgcHVibGljIEZpc2NhbFllYXJCZWdpbkFjY3VtOiBudW1iZXIsXG4gICAgICAgIHB1YmxpYyBGaXNjYWxZZWFyRW5kQWNjdW06IG51bWJlcixcbiAgICAgICAgcHVibGljIEZpc2NhbFllYXJEZXByQW1vdW50OiBudW1iZXIsXG5cbiAgICAgICAgcHVibGljIFBlcmlvZFN0YXJ0RGF0ZTogc3RyaW5nLFxuICAgICAgICBwdWJsaWMgUGVyaW9kRW5kRGF0ZTogc3RyaW5nLFxuICAgICAgICBwdWJsaWMgUGVyaW9kQmVnaW5BY2N1bTogbnVtYmVyLFxuICAgICAgICBwdWJsaWMgUGVyaW9kRW5kQWNjdW06IG51bWJlcixcbiAgICAgICAgcHVibGljIFBlcmlvZERlcHJBbW91bnQ6IG51bWJlcixcbiAgICAgICAgcHVibGljIENhbGNGbGFnczogc3RyaW5nLFxuICAgICAgICBwdWJsaWMgQWRqdXN0bWVudEFtdDogbnVtYmVyKVxuICAgIHsgfVxufVxuXG5cbkBJbmplY3RhYmxlKClcbmV4cG9ydCBjbGFzcyBUb29sc1NlcnZpY2Uge1xuICAgIHByaXZhdGUgcHJvcGVydHlUeXBlTGlzdFVybCA9ICdhcGkvcnVsZXMvcHJvcHR5cGVzJztcbiAgICBwcml2YXRlIGRlcHJNZWhvZExpc3R0VXJsID0gJ2FwaS9ydWxlcy9kZXBybWV0aG9kcyc7XG4gICAgcHJpdmF0ZSBlc3RMaWZlTGlzdFVybCA9ICdhcGkvcnVsZXMvZXN0bGlmZXMnO1xuXG4gICAgcHJpdmF0ZSBwcm9qZWN0VXJsID0gJ2FwaS9jYWxjcy9wcm9qZWN0JztcblxuXG4gICAgY29uc3RydWN0b3IocHJpdmF0ZSBodHRwOiBIdHRwKSB7IH1cblxuICAgIGdldFByb3BUeXBlTGlzdCgpOiBPYnNlcnZhYmxlPFJ1bGVJdGVtRHRvW10+IHtcbiAgICAgICAgcmV0dXJuIHRoaXMuaHR0cC5nZXQodGhpcy5wcm9wZXJ0eVR5cGVMaXN0VXJsKVxuICAgICAgICAgICAgLm1hcCh0aGlzLmV4dHJhY3REYXRhKVxuICAgICAgICAgICAgLmNhdGNoKHRoaXMuaGFuZGxlRXJyb3IpO1xuICAgIH1cblxuICAgIGdldERlcHJNZWhvZExpc3QocHJvcFR5cGU6IHN0cmluZywgcGlzRGF0ZTogc3RyaW5nKTogT2JzZXJ2YWJsZTxSdWxlSXRlbUR0b1tdPiB7XG4gICAgICAgIGxldCBwYXJhbXM6IFVSTFNlYXJjaFBhcmFtcyA9IG5ldyBVUkxTZWFyY2hQYXJhbXMoKTtcclxuICAgICAgICBwYXJhbXMuc2V0KCdwcm9wZXJ0eVR5cGUnLCBwcm9wVHlwZSk7XHJcbiAgICAgICAgcGFyYW1zLnNldCgncGlzRGF0ZScsIHBpc0RhdGUpO1xuXG4gICAgICAgIHJldHVybiB0aGlzLmh0dHAuZ2V0KHRoaXMuZGVwck1laG9kTGlzdHRVcmwsIHsgc2VhcmNoOiBwYXJhbXMgfSlcbiAgICAgICAgICAgIC5tYXAodGhpcy5leHRyYWN0RGF0YSlcbiAgICAgICAgICAgIC5jYXRjaCh0aGlzLmhhbmRsZUVycm9yKTtcbiAgICB9XG5cbiAgICBnZXRFc3RMaWZlTGlzdChwcm9wVHlwZTogc3RyaW5nLCBwaXNEYXRlOiBzdHJpbmcsIGRlcHJNZXRob2Q6c3RyaW5nKTogT2JzZXJ2YWJsZTxSdWxlSXRlbUR0b1tdPiB7XG4gICAgICAgIGxldCBwYXJhbXM6IFVSTFNlYXJjaFBhcmFtcyA9IG5ldyBVUkxTZWFyY2hQYXJhbXMoKTtcclxuICAgICAgICBwYXJhbXMuc2V0KCdwcm9wZXJ0eVR5cGUnLCBwcm9wVHlwZSk7XHJcbiAgICAgICAgcGFyYW1zLnNldCgncGlzRGF0ZScsIHBpc0RhdGUpO1xuICAgICAgICBwYXJhbXMuc2V0KCdkZXByTWV0aG9kJywgZGVwck1ldGhvZCk7XG5cbiAgICAgICAgcmV0dXJuIHRoaXMuaHR0cC5nZXQodGhpcy5lc3RMaWZlTGlzdFVybCwgeyBzZWFyY2g6IHBhcmFtcyB9KVxuICAgICAgICAgICAgLm1hcCh0aGlzLmV4dHJhY3REYXRhKVxuICAgICAgICAgICAgLmNhdGNoKHRoaXMuaGFuZGxlRXJyb3IpO1xuICAgIH1cblxuXG4gICAgcG9zdFByb2plY3QoZGVwckJvb2s6IERlcHJlY2lhYmxlQm9va0R0byk6IE9ic2VydmFibGU8UGVyaW9kRGVwckl0ZW1EdG9bXT4ge1xuICAgICAgICBsZXQgaGVhZGVycyA9IG5ldyBIZWFkZXJzKHsgJ0NvbnRlbnQtVHlwZSc6ICdhcHBsaWNhdGlvbi9qc29uJyB9KTtcclxuICAgICAgICBsZXQgb3B0aW9ucyA9IG5ldyBSZXF1ZXN0T3B0aW9ucyh7IGhlYWRlcnM6IGhlYWRlcnMgfSk7XG5cbiAgICAgICAgcmV0dXJuIHRoaXMuaHR0cC5wb3N0KHRoaXMucHJvamVjdFVybCwgZGVwckJvb2ssIG9wdGlvbnMpXG4gICAgICAgICAgICAubWFwKHRoaXMuZXh0cmFjdERhdGEpXG4gICAgICAgICAgICAuY2F0Y2godGhpcy5oYW5kbGVFcnJvcik7XG4gICAgfVxuXG4gICAgcHJpdmF0ZSBleHRyYWN0RGF0YShyZXM6IFJlc3BvbnNlKSB7XG4gICAgICAgIGxldCBib2R5ID0gcmVzLmpzb24oKTtcbiAgICAgICAgcmV0dXJuIGJvZHkgfHwge307XG4gICAgfVxuXG4gICAgcHJpdmF0ZSBoYW5kbGVFcnJvcihlcnJvcjogUmVzcG9uc2UgfCBhbnkpIHtcbiAgICAgICAgLy8gSW4gYSByZWFsIHdvcmxkIGFwcCwgd2UgbWlnaHQgdXNlIGEgcmVtb3RlIGxvZ2dpbmcgaW5mcmFzdHJ1Y3R1cmVcbiAgICAgICAgbGV0IGVyck1zZzogc3RyaW5nO1xuICAgICAgICBpZiAoZXJyb3IgaW5zdGFuY2VvZiBSZXNwb25zZSkge1xuICAgICAgICAgICAgY29uc3QgYm9keSA9IGVycm9yLmpzb24oKSB8fCAnJztcbiAgICAgICAgICAgIGNvbnN0IGVyciA9IGJvZHkuZXJyb3IgfHwgSlNPTi5zdHJpbmdpZnkoYm9keSk7XG4gICAgICAgICAgICBlcnJNc2cgPSBgJHtlcnJvci5zdGF0dXN9IC0gJHtlcnJvci5zdGF0dXNUZXh0IHx8ICcnfSAke2Vycn1gO1xuICAgICAgICB9IGVsc2Uge1xuICAgICAgICAgICAgZXJyTXNnID0gZXJyb3IubWVzc2FnZSA/IGVycm9yLm1lc3NhZ2UgOiBlcnJvci50b1N0cmluZygpO1xuICAgICAgICB9XG4gICAgICAgIGNvbnNvbGUuZXJyb3IoZXJyTXNnKTtcbiAgICAgICAgcmV0dXJuIE9ic2VydmFibGUudGhyb3coZXJyTXNnKTtcbiAgICB9XG59XG5cblxuXG5cbi8vIFdFQlBBQ0sgRk9PVEVSIC8vXG4vLyAuL0NsaWVudEFwcC9hcHAvZmVhdHVyZS1tb2R1bGVzL3Rvb2xzL3Rvb2xzLnNlcnZpY2UudHMiLCJleHBvcnQgY2xhc3MgQm9vayB7XHJcbiAgICBjb25zdHJ1Y3RvcihcclxuICAgICAgICBwdWJsaWMgcHJvcFR5cGU6IHN0cmluZyxcclxuICAgICAgICBwdWJsaWMgcGlzRGF0ZTogc3RyaW5nLFxyXG4gICAgICAgIHB1YmxpYyBhY3FWYWx1ZTogbnVtYmVyLFxyXG4gICAgICAgIHB1YmxpYyBkZXByTWV0aG9kOiBzdHJpbmcsXHJcbiAgICAgICAgcHVibGljIGVzdExpZmU6IHN0cmluZ1xyXG4gICAgKSB7IH1cclxufVxuXG5cbi8vIFdFQlBBQ0sgRk9PVEVSIC8vXG4vLyAuL0NsaWVudEFwcC9hcHAvZmVhdHVyZS1tb2R1bGVzL3Rvb2xzL2Jvb2sudHMiLCJtb2R1bGUuZXhwb3J0cyA9IFwiPGRpdiBjbGFzcz1cXFwiY29udGFpbmVyXFxcIj5cXHJcXG4gICAgPGRpdj5cXHJcXG4gICAgICAgIDxoMT5UIC0gRDwvaDE+XFxyXFxuICAgICAgICA8ZGl2IGNsYXNzPVxcXCJjb2wtc20tNVxcXCI+XFxyXFxuICAgICAgICAgICAgPGZvcm0gbm92YWxpZGF0ZSAgKG5nU3VibWl0KT1cXFwib25TdWJtaXQoKVxcXCIgI2hlcm9Gb3JtPVxcXCJuZ0Zvcm1cXFwiPlxcclxcbiAgICAgICAgICAgICAgICA8ZGl2IGNsYXNzPVxcXCJmb3JtLWdyb3VwIHJvd1xcXCI+XFxyXFxuICAgICAgICAgICAgICAgICAgICA8bGFiZWwgZm9yPVxcXCJwcm9wVHlwZVxcXCIgY2xhc3M9XFxcImNvbC1zbS00IGNvbC1mb3JtLWxhYmVsXFxcIj5Qcm9wIFR5cGU8L2xhYmVsPlxcclxcbiAgICAgICAgICAgICAgICAgICAgPGRpdiBjbGFzcz1cXFwiY29sLXNtLThcXFwiPlxcclxcbiAgICAgICAgICAgICAgICAgICAgICAgIDxzZWxlY3QgY2xhc3M9XFxcImZvcm0tY29udHJvbFxcXCIgaWQ9XFxcInByb3BUeXBlXFxcIiBuYW1lPVxcXCJwcm9wVHlwZVxcXCIgWyhuZ01vZGVsKV09XFxcIm1vZGVsLnByb3BUeXBlXFxcIiAoYmx1cik9XFxcIm9uQmx1cl9wcm9wVHlwZSgpXFxcIiByZXF1aXJlZD5cXHJcXG4gICAgICAgICAgICAgICAgICAgICAgICAgICAgPG9wdGlvbiAqbmdGb3I9XFxcImxldCBpdGVtIG9mIHByb3BUeXBlTGlzdFxcXCIgW3ZhbHVlXT1cXFwiaXRlbS5uYW1lXFxcIj57e2l0ZW0ubmFtZX19PC9vcHRpb24+XFxyXFxuICAgICAgICAgICAgICAgICAgICAgICAgPC9zZWxlY3Q+XFxyXFxuICAgICAgICAgICAgICAgICAgICA8L2Rpdj5cXHJcXG4gICAgICAgICAgICAgICAgPC9kaXY+XFxyXFxuICAgICAgICAgICAgICAgIDxkaXYgY2xhc3M9XFxcImZvcm0tZ3JvdXAgcm93XFxcIj5cXHJcXG4gICAgICAgICAgICAgICAgICAgIDxsYWJlbCBmb3I9XFxcInBpc0RhdGVcXFwiIGNsYXNzPVxcXCJjb2wtc20tNCBjb2wtZm9ybS1sYWJlbFxcXCI+UGxhY2UtaW4tU2VydmljZTwvbGFiZWw+XFxyXFxuICAgICAgICAgICAgICAgICAgICA8ZGl2IGNsYXNzPVxcXCJjb2wtc20tOFxcXCI+XFxyXFxuICAgICAgICAgICAgICAgICAgICAgICAgPGlucHV0IHR5cGU9XFxcImRhdGVcXFwiIGNsYXNzPVxcXCJmb3JtLWNvbnRyb2xcXFwiIGlkPVxcXCJwaXNEYXRlXFxcIiBuYW1lPVxcXCJwaXNEYXRlXFxcIiBbKG5nTW9kZWwpXT1cXFwibW9kZWwucGlzRGF0ZVxcXCIgKGJsdXIpPVxcXCJvbkJsdXJfcGlzRGF0ZSgpXFxcIiA+XFxyXFxuICAgICAgICAgICAgICAgICAgICA8L2Rpdj5cXHJcXG4gICAgICAgICAgICAgICAgPC9kaXY+XFxyXFxuICAgICAgICAgICAgICAgIDxkaXYgY2xhc3M9XFxcImZvcm0tZ3JvdXAgcm93XFxcIj5cXHJcXG4gICAgICAgICAgICAgICAgICAgIDxsYWJlbCBmb3I9XFxcImFjcVZhbHVlXFxcIiBjbGFzcz1cXFwiY29sLXNtLTQgY29sLWZvcm0tbGFiZWxcXFwiPkFjcXVpc2l0aW9uIFZhbHVlPC9sYWJlbD5cXHJcXG4gICAgICAgICAgICAgICAgICAgIDxkaXYgY2xhc3M9XFxcImNvbC1zbS04XFxcIj5cXHJcXG4gICAgICAgICAgICAgICAgICAgICAgICA8aW5wdXQgdHlwZT1cXFwibnVtYmVyXFxcIiBjbGFzcz1cXFwiZm9ybS1jb250cm9sXFxcIiBpZD1cXFwiYWNxVmFsdWVcXFwiIG5hbWU9XFxcImFjcVZhbHVlXFxcIiBbKG5nTW9kZWwpXT1cXFwibW9kZWwuYWNxVmFsdWVcXFwiIChibHVyKT1cXFwib25CbHVyX2FjcVZhbHVlKClcXFwiID5cXHJcXG4gICAgICAgICAgICAgICAgICAgIDwvZGl2PlxcclxcbiAgICAgICAgICAgICAgICA8L2Rpdj5cXHJcXG4gICAgICAgICAgICAgICAgPGRpdiBjbGFzcz1cXFwiZm9ybS1ncm91cCByb3dcXFwiPlxcclxcbiAgICAgICAgICAgICAgICAgICAgPGxhYmVsIGZvcj1cXFwiZGVwck1ldGhvZFxcXCIgY2xhc3M9XFxcImNvbC1zbS00IGNvbC1mb3JtLWxhYmVsXFxcIj5EZXByIE1ldGhvZDwvbGFiZWw+XFxyXFxuICAgICAgICAgICAgICAgICAgICA8ZGl2IGNsYXNzPVxcXCJjb2wtc20tOFxcXCI+XFxyXFxuICAgICAgICAgICAgICAgICAgICAgICAgPHNlbGVjdCBjbGFzcz1cXFwiZm9ybS1jb250cm9sXFxcIiBpZD1cXFwiZGVwck1ldGhvZFxcXCIgbmFtZT1cXFwiZGVwck1ldGhvZFxcXCIgWyhuZ01vZGVsKV09XFxcIm1vZGVsLmRlcHJNZXRob2RcXFwiIChibHVyKT1cXFwib25CbHVyX2RlcHJNZXRob2QoKVxcXCIgcmVxdWlyZWQ+XFxyXFxuICAgICAgICAgICAgICAgICAgICAgICAgICAgIDxvcHRpb24gKm5nRm9yPVxcXCJsZXQgaXRlbSBvZiBkZXByTWV0aG9kTGlzdFxcXCIgW3ZhbHVlXT1cXFwiaXRlbS5uYW1lXFxcIj57e2l0ZW0ubmFtZX19PC9vcHRpb24+XFxyXFxuICAgICAgICAgICAgICAgICAgICAgICAgPC9zZWxlY3Q+XFxyXFxuICAgICAgICAgICAgICAgICAgICA8L2Rpdj5cXHJcXG4gICAgICAgICAgICAgICAgPC9kaXY+XFxyXFxuICAgICAgICAgICAgICAgIDxkaXYgY2xhc3M9XFxcImZvcm0tZ3JvdXAgcm93XFxcIj5cXHJcXG4gICAgICAgICAgICAgICAgICAgIDxsYWJlbCBmb3I9XFxcImVzdExpZmVcXFwiIGNsYXNzPVxcXCJjb2wtc20tNCBjb2wtZm9ybS1sYWJlbFxcXCI+RXN0IExpZmU8L2xhYmVsPlxcclxcbiAgICAgICAgICAgICAgICAgICAgPGRpdiBjbGFzcz1cXFwiY29sLXNtLThcXFwiPlxcclxcbiAgICAgICAgICAgICAgICAgICAgICAgIDxzZWxlY3QgY2xhc3M9XFxcImZvcm0tY29udHJvbFxcXCIgaWQ9XFxcImVzdExpZmVcXFwiIG5hbWU9XFxcImVzdExpZmVcXFwiIFsobmdNb2RlbCldPVxcXCJtb2RlbC5lc3RMaWZlXFxcIiAoYmx1cik9XFxcIm9uQmx1cl9lc3RMaWZlKClcXFwiIHJlcXVpcmVkPlxcclxcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICA8b3B0aW9uICpuZ0Zvcj1cXFwibGV0IGl0ZW0gb2YgZXN0TGlmZUxpc3RcXFwiIFt2YWx1ZV09XFxcIml0ZW0ubmFtZVxcXCI+e3tpdGVtLm5hbWV9fTwvb3B0aW9uPlxcclxcbiAgICAgICAgICAgICAgICAgICAgICAgIDwvc2VsZWN0PlxcclxcbiAgICAgICAgICAgICAgICAgICAgPC9kaXY+XFxyXFxuICAgICAgICAgICAgICAgIDwvZGl2PlxcclxcbiAgICAgICAgICAgICAgICA8YnV0dG9uIHR5cGU9XFxcInN1Ym1pdFxcXCIgY2xhc3M9XFxcImJ0biBidG4tc3VjY2Vzc1xcXCIgW2Rpc2FibGVkXT1cXFwiIWhlcm9Gb3JtLmZvcm0udmFsaWRcXFwiPkNhbGN1bGF0ZTwvYnV0dG9uPlxcclxcbiAgICAgICAgICAgICAgICA8YnV0dG9uIHR5cGU9XFxcImJ1dHRvblxcXCIgY2xhc3M9XFxcImJ0biBidG4tZGVmYXVsdFxcXCIgKGNsaWNrKT1cXFwibmV3SGVybygpOyBoZXJvRm9ybS5yZXNldCgpXFxcIj5SZXNldDwvYnV0dG9uPlxcclxcbiAgICAgICAgICAgIDwvZm9ybT5cXHJcXG4gICAgICAgIDwvZGl2PlxcclxcbiAgICAgICAgPGRpdiBjbGFzcz1cXFwiY29sLXNtLTdcXFwiPlxcclxcbiAgICAgICAgICAgIDxwPlByb3BlcnR5IFR5cGU6IHt7IG1vZGVsLnByb3BUeXBlIH19PC9wPlxcclxcbiAgICAgICAgICAgIDxwPlBsYWNlZC1pbi1zZXJ2aWNlOiB7eyBtb2RlbC5waXNEYXRlIH19PC9wPlxcclxcbiAgICAgICAgICAgIDxwPkFjcXVpc2l0aW9uIFZhbHVlOiB7eyBtb2RlbC5hY3FWYWx1ZSB9fTwvcD5cXHJcXG4gICAgICAgICAgICA8cD5EZXByIE1ldGhvZDoge3sgbW9kZWwuZGVwck1ldGhvZCB9fTwvcD5cXHJcXG4gICAgICAgICAgICA8cD5Fc3QgTGlmZToge3sgbW9kZWwuZXN0TGlmZSB9fTwvcD5cXHJcXG5cXHJcXG4gICAgICAgICAgICA8dGFibGUgY2xhc3M9XFxcInRhYmxlXFxcIj5cXHJcXG4gICAgICAgICAgICAgICAgPHRoZWFkPlxcclxcbiAgICAgICAgICAgICAgICAgICAgPHRyPlxcclxcbiAgICAgICAgICAgICAgICAgICAgICAgIDx0aD5GaXNjYWwgWXIgU3RhcnQ8L3RoPlxcclxcbiAgICAgICAgICAgICAgICAgICAgICAgIDx0aD5GaXNjYWwgWXIgRW5kPC90aD5cXHJcXG4gICAgICAgICAgICAgICAgICAgICAgICA8dGg+UGVyaW9kIFN0YXJ0PC90aD5cXHJcXG4gICAgICAgICAgICAgICAgICAgICAgICA8dGg+UGVyaW9kIEVuZDwvdGg+XFxyXFxuICAgICAgICAgICAgICAgICAgICAgICAgPHRoPkJlZ2luIEFjY3VtPC90aD5cXHJcXG4gICAgICAgICAgICAgICAgICAgICAgICA8dGg+RW5kIEFjY3VtPC90aD5cXHJcXG4gICAgICAgICAgICAgICAgICAgICAgICA8dGg+RGVwciBBbW91bnQ8L3RoPlxcclxcbiAgICAgICAgICAgICAgICAgICAgPC90cj5cXHJcXG4gICAgICAgICAgICAgICAgPC90aGVhZD5cXHJcXG4gICAgICAgICAgICAgICAgPHRib2R5PlxcclxcbiAgICAgICAgICAgICAgICAgICAgPHRyICpuZ0Zvcj1cXFwibGV0IGl0ZW0gb2YgcHJkRGVwckl0ZW1zXFxcIj5cXHJcXG4gICAgICAgICAgICAgICAgICAgICAgICA8dGQ+e3tpdGVtLmZpc2NhbFllYXJTdGFydERhdGV9fTwvdGQ+XFxyXFxuICAgICAgICAgICAgICAgICAgICAgICAgPHRkPnt7aXRlbS5maXNjYWxZZWFyRW5kRGF0ZX19PC90ZD5cXHJcXG4gICAgICAgICAgICAgICAgICAgICAgICA8dGQ+e3tpdGVtLnBlcmlvZFN0YXJ0RGF0ZX19PC90ZD5cXHJcXG4gICAgICAgICAgICAgICAgICAgICAgICA8dGQ+e3tpdGVtLnBlcmlvZEVuZERhdGV9fTwvdGQ+XFxyXFxuICAgICAgICAgICAgICAgICAgICAgICAgPHRkPnt7aXRlbS5wZXJpb2RCZWdpbkFjY3VtfX08L3RkPlxcclxcbiAgICAgICAgICAgICAgICAgICAgICAgIDx0ZD57e2l0ZW0ucGVyaW9kRW5kQWNjdW19fTwvdGQ+XFxyXFxuICAgICAgICAgICAgICAgICAgICAgICAgPHRkPnt7aXRlbS5wZXJpb2REZXByQW1vdW50fX08L3RkPlxcclxcbiAgICAgICAgICAgICAgICAgICAgPC90cj5cXHJcXG4gICAgICAgICAgICAgICAgPC90Ym9keT5cXHJcXG4gICAgICAgICAgICA8L3RhYmxlPlxcclxcbiAgICAgICAgPC9kaXY+XFxyXFxuICAgIDwvZGl2PlxcclxcbjwvZGl2PlxcclxcblwiXG5cblxuLy8vLy8vLy8vLy8vLy8vLy8vXG4vLyBXRUJQQUNLIEZPT1RFUlxuLy8gLi9DbGllbnRBcHAvYXBwL2ZlYXR1cmUtbW9kdWxlcy90b29scy90b29scy1wcm9qZWN0aW9uLmNvbXBvbmVudC5odG1sXG4vLyBtb2R1bGUgaWQgPSA1MVxuLy8gbW9kdWxlIGNodW5rcyA9IDAiLCJpbXBvcnQgeyBOZ01vZHVsZSB9ICAgICAgICAgICAgZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5pbXBvcnQgeyBSb3V0ZXJNb2R1bGUgfSAgICAgICAgZnJvbSAnQGFuZ3VsYXIvcm91dGVyJztcblxuaW1wb3J0IHsgVG9vbHNEZXByZWNpYXRlQ29tcG9uZW50IH0gICAgZnJvbSAnLi90b29scy1kZXByZWNpYXRlLmNvbXBvbmVudCc7XG5pbXBvcnQgeyBUb29sc1Byb2plY3Rpb25Db21wb25lbnQgfSAgZnJvbSAnLi90b29scy1wcm9qZWN0aW9uLmNvbXBvbmVudCc7XG5cbkBOZ01vZHVsZSh7XG4gICAgaW1wb3J0czogW1JvdXRlck1vZHVsZS5mb3JDaGlsZChbXG4gICAgICAgIHsgcGF0aDogJ3Rvb2xzL2RlcHJlY2lhdGUnLCBjb21wb25lbnQ6IFRvb2xzRGVwcmVjaWF0ZUNvbXBvbmVudCB9LFxuICAgICAgICB7IHBhdGg6ICd0b29scy9wcm9qZWN0aW9uJywgY29tcG9uZW50OiBUb29sc1Byb2plY3Rpb25Db21wb25lbnQgfVxuICAgIF0pXSxcbiAgICBleHBvcnRzOiBbUm91dGVyTW9kdWxlXVxufSlcbmV4cG9ydCBjbGFzcyBUb29sc1JvdXRpbmdNb2R1bGUgeyB9XG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIC4vQ2xpZW50QXBwL2FwcC9mZWF0dXJlLW1vZHVsZXMvdG9vbHMvdG9vbHMtcm91dGluZy5tb2R1bGUudHMiXSwic291cmNlUm9vdCI6IiJ9