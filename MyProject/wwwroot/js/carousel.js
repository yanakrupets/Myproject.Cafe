$(document).ready(function () {
    $.get('/Home/ImageForCarousel')
        .done(function (answer) {
            carouselModule.initialize(
                '.animate-block',
                '.animate-block-dots',
                answer,
                {
                    time: 2000
                });
        })
        .fail(function () {

        });
});