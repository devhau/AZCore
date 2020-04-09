﻿function AZAjax() {
    var $this = this;
    this.AzType = "modules";
    this.DoGet =  function (methodServer, data, callback, onerror) { return this.DoAjax("GET", methodServer, data, callback, onerror); };
    this.DoPost = function (methodServer, data, callback, onerror) {  return this.DoAjax("POST", methodServer, data, callback, onerror); };
    this.DoPut =  function (methodServer, data, callback, onerror) { return this.DoAjax("PUT", methodServer, data, callback, onerror); };
    this.DoAjax = function (methodAjax, methodServer, data, callback, onerror) {
        
        urlRequest = methodServer
        // kiểm tra xem data có phải là một function lấy data hay không
        // nếu là một function lấy data thì thực hiện lấy data
        var dataPost = typeof (data) == "function" ? data() : data;
        if (dataPost == null) dataPost = {};
       // dataPost.path = window.location.pathname + window.location.search;
        dataPost.time = new Date().getTime();
        //var request ajax
        var request = $.ajax(
            {
                // Url thực hiện request
                url: urlRequest,

                // method post hoặc get
                type: methodAjax,

                // data cần truyền đi
                data: dataPost,

                // ContentType dữ liệu trả về
                dataType: "json"
            });

        // Nếu như request thực hiện thành công
        request.done(
            function (res) {
                // Nếu có xử lý sau khi kết thúc request theo ý người lập trình
                if (callback != null) callback(res);

                // Thực hiện xử lý javascript mà server gửi về cho client
                $this.Extends(res);
            }
        );
        request.fail(function (error) {
            if (onerror != null) onerror(error);
        });
        return request;
    }
    this.Extends = function (itemData) {
        var CodeJS = "";
        if (itemData.js) itemData.js.forEach(function (item) { if (item.code) { CodeJS = CodeJS + " " + item.code; } });
        var CodeCss = "";
        if (itemData.css) itemData.css.forEach(function (item) { if (item.code) { CodeCss = CodeCss + " " + item.code; } });
        var style = $("<style></style>");
        $(style).html(CodeCss);
        $("html head").append(style);
        setTimeout(function () { eval(CodeJS); }, 1000);
    }
    
}

jQuery.cachedScript = function (url, options) {

    // Allow user to set any option except for dataType, cache, and url
    options = $.extend(options || {}, {
        dataType: "script",
        cache: true,
        url: url
    });

    // Use $.ajax() since it is more flexible than $.getScript
    // Return the jqXHR object so we can chain callbacks
    return jQuery.ajax(options);
};

//$.fn.serializeData = function () {
//    var form = $("<form>");
//    return JSON.stringify(form.append(this.html()).serializeArray());
//}