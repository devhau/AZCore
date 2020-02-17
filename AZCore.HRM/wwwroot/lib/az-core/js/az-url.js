function AZUrl() {
    var $this = this;
    $this.init = function () {
        $.pathchange.init({});
        $(window).bind("pathchange", function (e) {
            alert("");
            window.history.back(); 
        });
    }
}
