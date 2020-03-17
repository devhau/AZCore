function AZUrl() { }
AZUrl.prototype.loadHtml = function (url) {
    new AZAjax().DoGet(url, {}, function (d) {
        $("#ContentAZ").html(d.Html); if (d.JS) d.JS.forEach(function (item) { eval(item.Code) });
    }, function (e) { });
}
AZUrl.prototype.changeUrl = function (url) {
    this.loadHtml(url);
    window.history.pushState("data", "Title", url);
}
AZUrl.prototype.Init = function () {
    var $this = this;
    $("a.az-link").on("click", function (e) {
        e.preventDefault();
        $this.changeUrl($(this).attr("href"));
    });
    $(window).on('popstate', function (e) {
        $this.loadHtml(location.pathname + location.search);        
    });
}