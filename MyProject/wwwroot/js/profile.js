$(document).ready(function () {
    $('.avatar').mouseenter(function () {
        $('.avatar-form').removeClass('hide');
    })

    $('.avatar-form').mouseleave(function () {
        $('.avatar-form').addClass('hide');
    })
})