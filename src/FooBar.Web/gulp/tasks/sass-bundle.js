var gulp = require('gulp');
var sass = require('gulp-sass');
var concatCss = require('gulp-concat-css');
var autoprefixer = require('gulp-autoprefixer');
var del = require('del');

var CacheBust = require('../cache-bust');
var cacheBust = new CacheBust();

gulp.task('sass-bundle', function () {
    del('wwwroot/dist/site.*.css');
	gulp
		.src('app/**/*.scss')
		.pipe(sass({ includePaths: ['node_modules/material-components-web', 'node_modules']}).on('error', sass.logError))
		.pipe(concatCss('site.css'))
		.pipe(autoprefixer({browsers: ['> 0%'], cascade: false, grid: false }))
        .pipe(cacheBust.bust())
		.pipe(gulp.dest('./wwwroot/dist/'));
});