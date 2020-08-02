function UrlState(option) {
    let $this = this;
    if (!option) option = {};
    $this.option = {
        ContentMain:"#content-main",
        LinkAjax: ".link-ajax",
        Sidebar:"#my-admin-sidebar"
    };
    $.extend($this.option, option);
    $this.OffEvent = function () {
        $($this.option.LinkAjax).off("click");
        $(window).off('popstate');

    }
    $this.CheckAndActiveSidebar = function () {
        let link = location.href;
        $($this.option.Sidebar).find('.nav-link.active').each(function (index, item) {
            $(item).parents('.nav-treeview').css('display', 'none');
            $(item).parents('.has-treeview').removeClass('menu-open');
        });
        $($this.option.Sidebar).find('.menu-open').each(function (index, item) {
            $(item).find('.nav-treeview').css('display', 'none');
            $(item).removeClass('menu-open');
        });
        $($this.option.Sidebar).find('.nav-link.active').removeClass("active");
        $($this.option.Sidebar).find('.nav-link').each(function (index, item) {
            if (link.indexOf($(item).attr("href"))>=0) {
                $(item).addClass("active");
            }
        })
        $($this.option.Sidebar).find('.nav-link.active').each(function (index, item) {
            $(item).parents('.nav-treeview').css('display', 'block');
            $(item).parents('.has-treeview').addClass('menu-open');
        });
    }
    $this.Init = function () {
        $(window).on('popstate', function (e) {
            $this.LoadHtml(location.pathname + location.search);
        });
        $($this.option.LinkAjax).on("click", function (e) {
            e.preventDefault();
            if ($(this).attr("href")!="#") $this.ChangeUrl($(this).attr("href"));
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
                $this.CheckAndActiveSidebar();
            }
        });
    }
}
var UrlMain = new UrlState();
UrlMain.Init();