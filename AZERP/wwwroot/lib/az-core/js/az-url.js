function AZUrl() { }
AZUrl.prototype.Init = function () {
    $(window).on('hashchange', function (e) {
        let url_new = location.hash.slice(1);
        window.history.pushState("data", "Title", url_new);
        new AZAjax().DoGet(url_new, {}, function (d) { $("#ContentAZ").html(d.Html); }, function (e) { });
    });
}