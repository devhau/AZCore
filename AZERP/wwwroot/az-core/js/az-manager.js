function AZManager() {
    $.extend(this, new AZAjax());
    $this = this;
    this.FormSize = $(this).data("form-size");
    this.ReLoad = function (callback) {

        new AZUrl().loadHtml(location.href, callback);
    }
    this.SaveData = function (url, scope) {
        $this.DoPost(url, scope.SerializeData(), function (item) {
            $this.ReLoad(function () {
            });
            scope.ClosePopup();
        }, function (error) {



        })
    }
    this.ShowFormUpdate = function ($Id) {
        var url = location.pathname + "?h=update";
        if ($Id) url = url + "&id=" + $Id;
        $this.DoGet(url, null, function (item) {
            var popup = new AZPopup();
            popup.ClearButton();
            popup.IsForm = true;
            popup.AddButton({
                value: "Lưu lại",
                icon: "far fa-save",
                cls: "btn btn-success az-btn az-btn-update",
                func: function (elem, scope) {
                    $this.SaveData(url, scope);
                }
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
        var $Id = $(this).parents("tr").attr("data-item-id");
        $this.ShowFormUpdate($Id);       
    });
    $(this).find(".az-btn-delete").on("click", function () {

        var $Id = $(this).parents("tr").attr("data-item-id");
        var popup = new AZPopup();
        popup.ClearButton();
        popup.IsForm = true;
        popup.AddButton({
            value: "Có",
            icon: "far fa-check-circle",
            cls: "btn btn-success az-btn",
            func: function (elem, scope) {
                var url = location.pathname + "?h=delete";
                if ($Id) url = url + "&id=" + $Id;
                $this.DoPost(url, {}, function (item) { $this.ReLoad(); scope.ClosePopup();});
            }
        });
        popup.AddButton({
            value: "Không",
            icon: "far fa-times-circle",
            cls: "btn btn-danger az-btn",
            func: function (elem, scope) {
                scope.ClosePopup();
            }
        });
        popup.setHtml("Bạn có muốn xóa bản ghi này không?");
        popup.setTitle("Thông báo");
        popup.ShowPopup();
       
    });
    $(this).find(".az-btn-export").on("click", function () {
        var href = location.href;
        if (href.indexOf("?") < 0) {
            href = href + "?";
        }
        location.href=href+"&h=download"
    });
    $(this).find(".az-btn-import").on("click", function () {
        alert("Đang phát triển!");
    });
    return this;
}

$.fn.AZManager = AZManager;