function UpdatePurchaseOrders($id) {
    var popup = PopupMain.PopupCurrent();
    $($id).find(".az-import-store").on("click", function () {
        new AZAjax().DoPost(popup.link, { commit: 1 }, function (item) {
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

    $($id).find(".az-payment").on("click", function () {
        new AZAjax().DoPost(popup.link, { commit: 2 }, function (item) {
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