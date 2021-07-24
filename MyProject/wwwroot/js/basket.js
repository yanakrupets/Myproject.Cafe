$(document).ready(function () {
	$('.delete-dish').click(function () {
		var dishId = $(this).attr("name");
		var url = "/Cafe/RemoveDish?dishId=" + dishId;
		$.get(url)
			.done(function (answer) {
				location.reload();
			})
			.fail(function () {

			})
	})

	$('.dishes-in-order').find('.popup-cover').click(function () {
		$('.dishes-in-order').find('.nice-popup').addClass('hide');
	});

	$('.dishes-in-order').find('.basket-pay').click(function () {
		$('.dishes-in-order').find('.nice-popup').removeClass('hide');
	});
});