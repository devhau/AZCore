function DashboardForm($id) {
   
}

function AddWidget($id) {

    $($id).find(".widget-list li").on("click", function () {
        $($id).find(".widget-list li").removeClass("active");
        $(this).addClass("active");
        var widgetName = $(this).attr("widget");
        AjaxMain.DoGet("/?h=ViewSetting&WidgetName=" + widgetName, null, function (item) {
            $($id).find(".widget-setting").html(item.html);

        });
    });
    $($id).find(".btn-save-refresh").on("click", function () {
        var widgetActive = $($id).find(".widget-list li.active");
        if (widgetActive && widgetActive.length > 0) {
            var widgetName = $(widgetActive).attr("widget");
            AjaxMain.DoPost("/?h=ViewSetting&WidgetName=" + widgetName, $($id).find(".widget-setting").AZSerializeForm(), function (item) {
                $(widgetActive).removeClass("active");
                $($id).find(".widget-setting").html("");
                AZCore.ReLoad();

            });
        } else {
            toastr.error("Vui lòng chọn widget");
        }
    });
    $($id).find(".btn-save-close").on("click", function () {
        var widgetActive = $($id).find(".widget-list li.active");
        if (widgetActive && widgetActive.length > 0) {
            var widgetName = $(widgetActive).attr("widget");
            AjaxMain.DoPost("/?h=ViewSetting&WidgetName=" + widgetName, $($id).find(".widget-setting").AZSerializeForm(), function (item) {
                PopupMain.Current().ClosePopup();
                AZCore.ReLoad();
            });
        } else {
            toastr.error("Vui lòng chọn widget");
        }
    });

}