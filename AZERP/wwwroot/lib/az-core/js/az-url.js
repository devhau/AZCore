function AZUrl() { }
AZUrl.prototype.Init = function () {
    if (("onhashchange" in window) && navigator.userAgent.toLowerCase().indexOf('msie') == -1) {
        window.onhashchange = function () {
            alert(window.location.hash);
        }
        // Or $(window).bind( 'hashchange',function(e) {  
        //       alert(window.location.hash); 
        //   });              
    }
    else {
        var prevHash = window.location.hash;
        window.setInterval(function () {
            if (window.location.hash != prevHash) {
                prevHash = window.location.hash;
                alert(window.location.hash);
            }
        }, 100);
    }
}