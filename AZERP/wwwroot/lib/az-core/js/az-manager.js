
function AZManager() {
    $.extend(this, new AZAjax());
    $this = this;
    this.FormSize = $(this).data("form-size");
    this.ShowFormUpdate = function ($Id) {
        var url = location.pathname + "?h=update";
        if ($Id) url = url + "&id" + $Id;
        $this.DoGet(url, null, function (item) {
            var popup = new AZPopup();
            popup.ClearButton();
            popup.AddButton({
                value: "Cập nhật",
                cls: "btn btn-success az-btn az-btn-update",
                func: function (elem, scope) { alert("Lưu"); }
            });
            popup.setHtml(item.Html);
            popup.setTitle(item.Title);
            popup.ModalSize = $this.FormSize;
            popup.ShowPopup();
        });
    }
    $(this).find(".az-btn-add").on("click", function () {       
        $this.ShowFormUpdate();
    });
    $(this).find(".az-btn-edit").on("click", function (e) {
        var $Id = $(this).attr("data-id");
        $this.ShowFormUpdate($Id);       
    });
    $(this).find(".az-btn-delete").on("click", function () {
        alert("delete");
    });
    $(this).find(".az-btn-export").on("click", function () {
        alert("export");
    });
    $(this).find(".az-btn-import").on("click", function () {

        alert("import");
    });
    return this;
}

$.fn.AZManager = AZManager;