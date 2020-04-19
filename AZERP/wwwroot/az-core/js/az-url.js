function AZUrl() {
    $.extend(this, new AZAjax());
}
AZUrl.prototype.loadHtml = function (url, callback) {
    this.DoGet(url, {}, function (itemData) {       
        if (itemData.statusCode && itemData.statusCode === 401) {
            window.history.back();
            return;
        }
        $("#ContentAZ").html(itemData.html);
        document.title = itemData.title;
        if (callback) callback();
        UrlMain.Init();
    }, function (e) { window.history.back(); toastr.error("Không thể đến đường dẫn này:" + url) });
}
AZUrl.prototype.changeUrl = function (url) {
    this.loadHtml(url);
    window.history.pushState("data", "Title", url);
}
AZUrl.prototype.Init = function () {
    let $this = this;
    $("a.az-link").off("click");
    $("a.az-link-popup").off("click");
    $(window).off('popstate');
    $("a.az-link").on("click", function (e) {
        e.preventDefault();
        $this.changeUrl($(this).attr("href"));
    });
    $("a.az-link-popup").on("click", function (e) {
        e.preventDefault();
        let ModalSize = $(this).attr("modal-size");
        let reload = $(this).attr("reload");
        let LinkHref = $(this).attr("href");
        let link = $(this).attr("href");
        if (LinkHref.indexOf("?") > 0) {
            LinkHref += "&ActionType=popup"
        } else
            LinkHref += "?ActionType=popup"
        $this.DoGet(LinkHref, null, function (item){
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
                if (reload && reload==='true') {
                    $this.loadHtml(location.href);
                }
            });
            UrlMain.Init();
        });
    });
    $(".az-change-ajax").on("change", function (e) {
        if ($(this).parents(".az-manager") === undefined) {
            e.preventDefault();
            $this.changeUrl($(this).attr("az-href") + "&" + $(this).attr("name") + "=" + $(this).val());
        }
        
    });
    $(window).on('popstate', function (e) {
        $this.loadHtml(location.pathname + location.search);        
    });
    HotKeyMain.Init();
}
let UrlMain = new AZUrl();
$(function () {
    UrlMain.Init();
});