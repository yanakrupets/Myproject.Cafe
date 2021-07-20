$(document).ready(function () {
    $('.category-name').mouseenter(function () {
        $('.category-name').addClass('not-active');
        $(this).addClass('active');
    })

    $('.category-name').mouseleave(function () {
        $(this).removeClass('active');
        $('.category-name').removeClass('not-active');
    })

    $('.dish-size').click(function () {
        $('.dish-size').removeClass('selected-size');
        $(this).addClass('selected-size');
        var size = $(this).attr("value");
        $('.dish-size').closest('.size-price').find(`.price`).addClass('hide');
        $('.dish-size').closest('.size-price').find(`.weight`).addClass('hide');
        $(this).closest('.size-price').find(`.price[id='${size}']`).removeClass('hide');
        $(this).closest('.size-price').find(`.weight[id='${size}']`).removeClass('hide');
    })

    $('.category-name').click(function () {
        var elementClick = $(this).attr("href");
        var destination = $(elementClick).offset().top;
        $('html').animate({ scrollTop: destination - 85 }, 1100);
        return false;
    });
});