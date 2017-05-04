var gulp = require('gulp');
var bundle = require('aurelia-bundler').bundle;

var config = {
	force: true,
	baseURL: './wwwroot/', // baseURL of the application
	configPath: './wwwroot/config.js', // config.js file. Must be within `baseURL`
	injectionConfigPath: './wwwroot/dist/config.js',
	bundles: {
		"dist/app": { // bundle name/path. Must be within `baseURL`. Final path is: `baseURL/dist/app-build.js`.
			includes: [
				'[./wwwroot/app/**/*.js]'
			],
			options: {
				inject: true,
				minify: true,
				rev: true
			}
		},
		"dist/libs": {
			includes: [
				'aurelia-bootstrapper',
				'aurelia-framework',
				'aurelia-pal-browser',
				'aurelia-router',
				'aurelia-templating-binding',
				'aurelia-templating-resources',
				'aurelia-templating-router',
				'aurelia-loader-default',
				'aurelia-history-browser',
				'aurelia-logging-console'
			],
			options: {
				inject: true,
				minify: true,
				rev: true
			}
		}
	}
};

gulp.task('script-bundle', ['typescript-compile'], function() {
	return bundle(config);
});