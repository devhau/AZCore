function AZUrl() { }
AZUrl.prototype.changeUrl = function (url) {
    new AZAjax().DoGet(url, {}, function (d) { $("#ContentAZ").html(d.Html); }, function (e) { });
   
}
AZUrl.prototype.Init = function () {
    var $this = this;
    $("a.az-link").on("click", function (e) {
        e.preventDefault();
        var url = $(this).attr("href");
        window.history.pushState("data", "Title", url);
        $this.changeUrl(url);
    });
    $(window).on('popstate', function (e) {
        var url = location.pathname + location.search;
        $this.changeUrl(url);        
    });
}