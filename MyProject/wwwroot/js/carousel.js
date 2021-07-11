$(document).ready(function () {
    $.get('/Home/ImageForCarousel')
        .done(function (answer) {
            carouselModule.initialize(
                '.animate-block',
                '.animate-block-dots',
                answer,
                {
                    width: $('.animate-block').width(),
                    height: $('.animate-block').height(),
                    time: 2000
                });
        })
        .fail(function () {

        });
});