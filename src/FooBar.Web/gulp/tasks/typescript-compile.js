var gulp = require('gulp');
var ts = require('gulp-typescript');
var tsProject = ts.createProject('tsconfig.json');

gulp.task('typescript-compile', function() {
	var tsResult = gulp
        .src(['app/**/*.ts'])
		.pipe(tsProject());

	return tsResult.js.pipe(gulp.dest('./wwwroot/app/'));
});