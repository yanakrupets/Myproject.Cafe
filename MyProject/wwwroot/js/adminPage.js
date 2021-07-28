$(document).ready(function () {
	$('.add-dish').click(function(){
		$(this).closest('.admin-context').find('.edit-page').addClass('hide');
		$(this).closest('.admin-context').find('.admin-add-dish').removeClass('hide');
	})

	$('.add-category').click(function () {
		$(this).closest('.admin-context').find('.edit-page').addClass('hide');
		$(this).closest('.admin-context').find('.admin-add-category').removeClass('hide');
	})

	$('.add-so').click(function () {
		$(this).closest('.admin-context').find('.edit-page').addClass('hide');
		$(this).closest('.admin-context').find('.admin-add-so').removeClass('hide');
	})

	$('.edit').click(function () {
		$(this).closest('.admin-context').find('.edit-page').addClass('hide');
		$(this).closest('.admin-context').find('.admin-edit').removeClass('hide');
	})
});