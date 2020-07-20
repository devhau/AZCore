$(function () {
    $('#my-admin-sidebar').find('.nav-link.active').each(function (index,item) {
        $(item).parents('.nav-treeview').css('display', 'block');
        $(item).parents('.has-treeview').addClass('menu-open');
    });
});