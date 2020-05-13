function DashboardForm($id) {
    $($id).find(".az-widget .az-widget-setting").on("click", function () {
        var widgetId = $(this).parents(".az-widget").attr("widget-id");
        var url = "/?h=ViewSetting&id=" + widgetId;
        AjaxMain.DoGet(url, null, function (item) {
            if (item.statusCode && item.statusCode === 401) {
                return;
            }
            var popup = new AZPopup();
            popup.ClearButton();
            popup.setLink(url);
            popup.setId(widgetId);
            popup.IsForm = true;
            popup.AddButton({
                value: "Xóa (F3)",
                icon: "far fa-delete",
                cls: "btn btn-danger az-btn az-btn-delete",
                cmd: "f3",
                func: function (elem, scope) {
                    AjaxMain.DoDelete(url, scope.SerializeData(), function () {
                        toastr.success("Xóa thành công");
                        scope.ClosePopup();
                        AZCore.ReLoad();
                    });
                }
            });
            popup.AddButton({
                value: "Lưu lại (F2)",
                icon: "far fa-save",
                cls: "btn btn-success az-btn az-btn-update",
                cmd: "f2",
                func: function (elem, scope) {
                    AjaxMain.DoPost(url, scope.SerializeData(), function () {
                        toastr.success("Thiết lập thành công");
                        scope.ClosePopup();
                        AZCore.ReLoad();
                    });
                }
            });
          
            popup.setHtml(item.html);
            $icon = '<i class="fas fa-edit"></i> ';
            if (item.icon && item.icon != "") {
                $icon = '<i class="' + item.icon + '"></i> ';
            }
            popup.setTitle($icon + item.title);
            popup.ModalSize = "az-modal-xl";
            popup.ShowPopup();
        });
    });
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