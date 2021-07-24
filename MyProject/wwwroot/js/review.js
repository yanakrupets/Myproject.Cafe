$(document).ready(function () {
	$('.delete-review').click(function () {
		var reviewId = $(this).attr("name");
		var url = "/Review/RemoveReview?reviewId=" + reviewId;
		$.get(url)
			.done(function (answer) {
				location.reload();
			})
			.fail(function () {

			})
	})
});