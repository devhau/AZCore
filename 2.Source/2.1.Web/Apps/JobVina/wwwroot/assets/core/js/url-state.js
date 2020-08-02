function UrlState(option) {
    let $this = this;
    if (!option) option = {};
    $this.option = {
        ContentMain:"#content-main",
        LinkAjax:".link-ajax"
    };
    $.extend($this.option, option);
    $this.OffEvent = function () {
        $($this.option.LinkAjax).off("click");
        $(window).off('popstate');

    }
    $this.Init = function () {
        $(window).on('popstate', function (e) {
            $this.LoadHtml(location.pathname + location.search);
        });
        $($this.option.LinkAjax).on("click", function (e) {
            e.preventDefault();
            $this.ChangeUrl($(this).attr("href"));
        });
    }
    $this.LoadHtml = function (url, callback) {
        AjaxMain.DoGet(url, {}, function (itemData) {
            if (itemData.statusCode && itemData.statusCode === 401) {
                if (callback) callback(false);
                return;
            }
            $($this.option.ContentMain).html(itemData.html);
            document.title = itemData.title;
            if (callback) callback(true);
        }, function (e) { if (callback) callback(false); toastr.error("Không thể đến đường dẫn này:" + url) });
    }
    $this.ChangeUrl = function (url) {
        this.LoadHtml(url, function (flg) {
            if (flg) {
                window.history.pushState("data", "Title", url);
            }
        });
    }
}
//var UrlMain = new UrlState();
//UrlMain.Init();