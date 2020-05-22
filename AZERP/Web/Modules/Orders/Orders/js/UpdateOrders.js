function UpdateOrders($id) {
    var popup = PopupMain.Current();
    $($id).find(".az-export-store").on("click", function () {
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

    $(".az-btn-payment").on("click", function (e) {
        if (e.stopPropagation) e.stopPropagation();
        if (e.preventDefault) e.preventDefault();
        let ModalSize = $(this).attr("modal-size");
        let reload = $(this).attr("reload");
        let LinkHref = $(this).attr("href");
        let link = $(this).attr("href");
        if (LinkHref.indexOf("?") > 0) {
            LinkHref += "&ActionType=popup"
        } else
            LinkHref += "?ActionType=popup"
        let listIdProduct = $(".az-commit-order .az-data-table tbody tr td input[type='hidden']").map(function () { return $(this).attr("value"); }).get();
        AjaxMain.DoGet(LinkHref, { data: listIdProduct.join(",") }, function (item) {
            if (item.statusCode && item.statusCode === 401) {
                return;
            }
            let popup = new AZPopup();
            popup.ClearButton();
            popup.setHtml(item.html);
            popup.setTitle(item.title);
            popup.setLink(link);
            popup.ModalSize = ModalSize;
            popup.ShowPopup(function () {
                if (reload && reload === 'true') {
                    $this.loadHtml(location.href);
                }
            });
        });
    })
}