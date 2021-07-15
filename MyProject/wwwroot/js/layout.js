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

	$('.lang-content .lang').click(function () {
		var language = $(this).attr("value");
		var url = "/User/UpdateLang?lang=" + language;
		$.get(url)
			.done(function (answer) {
				if (answer) {
					document.location.reload();
				} else {
					document.cookie = 'guestLang=' + language;
					document.location.reload();
                }
			})
			.fail(function () {

			})
	})
});
