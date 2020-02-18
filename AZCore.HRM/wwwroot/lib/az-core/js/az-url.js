function AZUrl() { }
AZUrl.prototype.Init = function () {
    $(window).on("pathchange", function (e) {
        e.preventDefault();
        alert("");
    })
}