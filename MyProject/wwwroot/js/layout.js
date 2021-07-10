$(document).ready(function () {
	$('.popup-cover').click(function () {
		$('.nice-popup').addClass('hide');
	});

	$('.log-in').click(function () {
		$('.nice-popup').removeClass('hide');
	});

	$('.lang-dropdown').mouseenter(function () {
		$('.lang-content').removeClass('hide');
	})

	$('.lang-dropdown').mouseleave(function () {
		$('.lang-content').addClass('hide');
	})

	//вынести в функцию
	$('.lang-content').find('.ru').click(function () {
		var language = "ru";
		var url = "/User/UpdateLang?lang=" + language;
		$.get(url)
			.done(function () {
				location.reload();
			})
			.fail(function () {

			})
	})

	$('.lang-content').find('.en').click(function () {
		var language = "en";
		var url = "/User/UpdateLang?lang=" + language;
		$.get(url)
			.done(function () {
				location.reload();
			})
			.fail(function () {

			})
	})
});
