function AZUrl() { }
AZUrl.prototype.loadHtml = function (url, callback) {
    new AZAjax().DoGet(url, {}, function (d) {
        $("#ContentAZ").html(d.html);
        document.title = d.title;
        var CodeJS = "";
        if (d.js) d.js.forEach(function (item) { if (item.code) { CodeJS = CodeJS + " " + item.code; } });
        var CodeCss = "";
        if (d.css) d.css.forEach(function (item) { if (item.code) { CodeCss = CodeCss + " " + item.code; } });
        var style = $("<style></style>");
        $(style).html(CodeCss);
        $("html head").append(style);
        setTimeout(function () { eval(CodeJS); }, 1000);
        
        if (callback) callback();
        UrlMain.Init();
    }, function (e) { });
}
AZUrl.prototype.changeUrl = function (url) {
    this.loadHtml(url);
    window.history.pushState("data", "Title", url);
}
AZUrl.prototype.Init = function () {
    var $this = this;
    $("a.az-link").off("click");
    $(window).off('popstate');
    $(".az-change-ajax").off("change");
    $("a.az-link").on("click", function (e) {
        e.preventDefault();
        $this.changeUrl($(this).attr("href"));
    });
    $(".az-change-ajax").on("change", function (e) {
        e.preventDefault();
        $this.changeUrl($(this).attr("az-href") + "&" + $(this).attr("name") + "=" + $(this).val());
    });
    $(window).on('popstate', function (e) {
        $this.loadHtml(location.pathname + location.search);        
    });
}
var UrlMain = new AZUrl();
$(function () {
    UrlMain.Init();
});