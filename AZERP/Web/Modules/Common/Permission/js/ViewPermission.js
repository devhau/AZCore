function ViewPermission($id, callback) {
    var flgCheck = false;
    $($id).find(".all-permission").off("change")
    $($id).find(".all-permission").on("change", function () {
        if (flgCheck) return;
        flgCheck = true;
        var ck = $(this).is(":checked");
        $(this).parents("tr").find(".az-permission-child input").prop('checked', ck);
        var codes=""
        $(this).parents("tr").find(".az-permission-child input").each(function (i, el) {
            codes += $(this).val()+ ","
        })
        UrlMain.DoPost(PopupMain.Current().link, { Codes: codes, flg: ck }, function (item) {
            if (item.statusCode == 200)
                toastr.success(item.message);
            else
                toastr.error(item.message);
        });
        flgCheck = false;
    });
    $($id).find(".az-permission-child input").off("change");
    $($id).find(".az-permission-child input").on("change", function () {
       
        if (flgCheck) return;
        flgCheck = true;
        var ck = $(this).is(":checked");
        UrlMain.DoPost(PopupMain.Current().link, { Code: $(this).val(), flg: ck }, function (item) {
            if (item.statusCode==200)
                toastr.success(item.message);
            else
                toastr.error(item.message);
        });
        if (ck) {
            $(this).parents("tr").find(".all-permission").prop("checked", true);
            $(this).parents("td").find("input").each(function (i, el) {
                if ($(this).is(":checked") == false) {
                    $(this).parents("tr").find(".all-permission").prop("checked",false);
                }
            });
        } else
            $(this).parents("tr").find(".all-permission").prop("checked",false);
       
        flgCheck = false;
    });
    $($id).find(".search-permssion form").find("*:input,select,textarea").on("change", function () {
        var url = PopupMain.Current().getPathName()+"?"+decodeURIComponent($.param($(this).parents("form").serializeArray()));
        UrlMain.DoGet(url, {}, function (item) {
            PopupMain.Current().setHtml(item.html);
            PopupMain.Current().setLink(url);
        });

    });
    $($id).find(".role-control select").on("select2:select", function (e) {
        console.log("select");
        console.log(e);
        UrlMain.DoPut(PopupMain.Current().link, { code: e.params.data.id, flg: true }, function (item) {
            toastr.success(item.message);
        });
    });
    $($id).find(".role-control select").on("select2:unselect", function (e) {
        console.log("unselect");
        console.log(e);
        UrlMain.DoPut(PopupMain.Current().link, { code: e.params.data.id, flg: false }, function (item) {
            toastr.success(item.message);
        });
    });
    if (callback) callback();
}