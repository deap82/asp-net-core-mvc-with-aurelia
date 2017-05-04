var gulp = require('gulp');
var watch = require('gulp-watch');

gulp.task('watcher', ['copy-templates', 'typescript-compile', 'sass-bundle'], function () {
    watch('app/**/*.html', function () { gulp.start('copy-templates'); });
	watch('app/**/*.ts', function() { gulp.start('typescript-compile'); });
    watch('app/**/*.scss', function () { gulp.start('sass-bundle'); });
});
