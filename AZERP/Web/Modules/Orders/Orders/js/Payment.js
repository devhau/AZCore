function UpdateOrders($id) {
    var popup = PopupMain.Current();
    $($id).find(".btn-update-payment").on("click", function () {
        new AZAjax().DoPost(popup.link, { }, function (item) {
            if (item.statusCode) {
                if (item.statusCode == 200) {
                    UrlMain.loadHtml(location.href);
                    popup.ClosePopup();
                    toastr.success(item.message);
                } else {
                    toastr.error(item.message);
                }
            }
        }, function () {

        })
    });
}