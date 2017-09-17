/// <binding ProjectOpened='web-projectopen' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var del = require('del');
var requireDir = require('require-dir');
var runSequence = require('run-sequence');

requireDir('./gulp/tasks', { recurse: true });

gulp.task('web-projectopen', function (cb) {
    require('child_process').execSync('npm install');
    require('child_process').execSync('jspm install -y');
    runSequence('watcher', cb);
});

gulp.task('clean', function() {
    return del(['wwwroot/app/**/*', 'wwwroot/dist/**/*.js', 'wwwroot/dist/**/*.json', 'wwwroot/dist/**/*.css']);
});

gulp.task('debug', ['clean'], function(cb) {
    runSequence(
        'copy-templates',
		'typescript-compile',
		'sass-bundle',
		cb);
});

gulp.task('copy-templates',
    function () {
        gulp.src('app/**/*.html').pipe(gulp.dest('wwwroot/app'));
    });