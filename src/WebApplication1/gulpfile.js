/// <binding AfterBuild='default' Clean='clean' />
var gulp = require('gulp'),
    uglify = require('gulp-uglify'),
    concat = require('gulp-concat');//,
    ngAnnotate = require('gulp-ng-annotate'),
    minifyCss = require('gulp-minify-css'),
    del = require('del');

gulp.task('minify-css', function () {
    gulp.src('./Styles/*.css')
        .pipe(minifyCss())
        .pipe(gulp.dest('./wwwroot/css'));
});

gulp.task('buildjs', function () {
    gulp.src('./Scripts/**/*.js')
        .pipe(concat('webapplication1.js'))
        .pipe(ngAnnotate())
        .pipe(uglify())
        .pipe(gulp.dest('./wwwroot/js'));
});

gulp.task('clean', function () {
    return del([
        './wwwroot/js/*.js',
        './wwwroot/css/*.css'
    ]);
});

gulp.task('watch', function () {
    gulp.watch('./Styles/*.css', ['minify-css']);
    gulp.watch('./Scripts/**/*.js', ['buildjs']);
});

gulp.task('default', ['buildjs', 'minify-css']);