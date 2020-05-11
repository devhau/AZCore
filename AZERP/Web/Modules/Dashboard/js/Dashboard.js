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

}