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
        var dishId = $(this).attr("name");
        $(`.dish-size[name='${dishId}']`).removeClass('selected-size');
        $(this).addClass('selected-size');
        var size = $(this).attr("value");
        $('.dish-size').closest('.size-price').find(`.price[name='${dishId}'`).addClass('hide');
        $('.dish-size').closest('.size-price').find(`.weight[name='${dishId}'`).addClass('hide');
        $(this).closest('.size-price').find(`.price[id='${size}']`).removeClass('hide');
        $(this).closest('.size-price').find(`.weight[id='${size}']`).removeClass('hide');
    })

    $('.category-name').click(function () {
        var elementClick = $(this).attr("href");
        var destination = $(elementClick).offset().top;
        $('html').animate({ scrollTop: destination - 85 }, 1100);
        return false;
    });

    $('.dish-block').mouseenter(function () {
        $('.dish-block').find('.button').addClass('hide');
        $(this).find('.button').removeClass('hide');
    })

    $('.dish-block').mouseleave(function () {
        $(this).find('.button').addClass('hide');
    })

    $('.dish-block').find('.button').click(function () {
        var dishId = $(this).closest('.dish-block').find('[name=dishId]').val();
        var dishSize = $(this).closest('.dish-block').find('.selected-size').attr("value");
        var url = "/Cafe/AddToBasket?dishId=" + dishId + "&dishSize=" + dishSize;
        $.get(url)
            .done(function (answer) {

            })
            .fail(function () {

            })
    })
});