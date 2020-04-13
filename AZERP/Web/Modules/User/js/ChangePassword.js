$(function () {
    let formChangePassword = $("#formChangePassword");
    $(formChangePassword).find(".btn-change-password").on("click", function () {
        let userId = $(formChangePassword).attr("data-user-id");
        let url = $(formChangePassword).parents(".az-modal").attr("link-popup");
        let password1 = $(formChangePassword).find("input[name=password]").val();
        let password2 = $(formChangePassword).find("input[name=password2]").val();
        if (password1 !== password2) {
            toastr.error("Nhập lại mật khẩu chưa chính xác");
            return;
        }
        UrlMain.DoPost(url, { pass: password1, id: userId }, function (item) { toastr.success(item.message); PopupMain.PopupCurrent().ClosePopup(); }, function () { });
    });
})