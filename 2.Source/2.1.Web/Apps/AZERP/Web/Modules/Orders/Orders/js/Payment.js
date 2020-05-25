function UpdateOrders($id) {
    var popup = PopupMain.Current();
    $($id).find(".btn-update-payment").on("click", function () {
        AjaxMain.DoPost(popup.link, { money: $("#txtMoney").attr("value") }, function (item) {
            if (item.statusCode) {
                if (item.statusCode == 200) {
                    UrlMain.loadHtml(location.href);
                    popup.ClosePopup();
                    PopupMain.Current().ReLoad();
                    toastr.success(item.message);
                } else {
                    toastr.error(item.message);
                }
            }
        }, function () {

        })
    });
}