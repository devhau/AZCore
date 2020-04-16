﻿function AZManager($callback) {
    let $this = $(this).hasClass("az-manager") ? this : $(this).find(".az-manager");
    $.extend($this, new AZAjax());
    $this.FormSize = $($this).data("form-size");
    $this.FormSearch = $($this).find(".az-search-form");
    $this.DataTable = $($this).find("table");
    $this.Modal = $($this).parents('.az-modal');
    $this.IsModal = $this.Modal.length > 0;
    if ($this.IsModal) {
        $this.ModalContent = $($this).parents(".modal-body");
        $this.location = AZCore.getLocation($($this.Modal).attr("link-popup"));
    } else {
        $this.location = location;
    }
    $this.ReLoad = function (callback) {
        $this.LoadLink($this.location.href, callback);
    }
    $this.LoadLink = function (link, callback) {
        if ($this.IsModal) {
            $($this.Modal).attr("link-popup", link);
            if (link.indexOf("ActionType=popup") < 0) {
                if (link.indexOf("?") > 0) {
                    link += "&ActionType=popup"
                } else
                    link += "?ActionType=popup"
            }
            $this.DoGet(link, {}, function (itemData) {
                $($this.ModalContent).html(itemData.html);
                if (callback) callback(true);
            }, function (e) { if (callback) callback(false); });

        } else {
            new AZUrl().changeUrl(link);
            if (callback) callback(true);
        }
    }
    $this.SaveData = function (url, scope) {
        $this.DoPost(url, scope.SerializeData(), function (item) {
            $this.ReLoad(function () {});
            scope.ClosePopup();
            toastr.success(item.message);
        }, function (error) {

        })
    }
    $this.ShowFormUpdate = function ($Id) {
        var url = $this.location.pathname + "?h=update";
        if ($Id) url = url + "&id=" + $Id;
        $this.DoGet(url, null, function (item) {
            var popup = new AZPopup();
            popup.ClearButton();
            popup.IsForm = true;
            popup.AddButton({
                value: "Lưu lại (F2)",
                icon: "far fa-save",
                cls: "btn btn-success az-btn az-btn-update",
                cmd: "f2",
                func: function (elem, scope) {
                    $this.SaveData(url, scope);
                }
            });
            popup.setHtml(item.html);
            popup.setTitle(item.title);
            popup.ModalSize = $this.FormSize;
            popup.ShowPopup();
        });
    }
    $($this).find(".az-btn-add").on("click", function () {       
        $this.ShowFormUpdate();
    });
    $($this).find("table tbody tr").on("dblclick", function () {
        var $Id = $(this).attr("data-item-id");
        $this.ShowFormUpdate($Id);    
    });
    $($this).find(".az-btn-edit").on("click", function (e) {    
        var $Id = $(this).parents("tr").attr("data-item-id");
        $this.ShowFormUpdate($Id);       
    });
    $($this).find(".az-btn-delete").on("click", function () {

        var $Id = $(this).parents("tr").attr("data-item-id");
        var popup = new AZPopup();
        popup.ClearButton();
        popup.IsForm = true;
        popup.AddButton({
            value: "[C]ó",
            cmd: "c",
            icon: "far fa-check-circle",
            cls: "btn btn-success az-btn",            
            func: function (elem, scope) {
                var url = $this.location.pathname + "?h=delete";
                if ($Id) url = url + "&id=" + $Id;
                $this.DoPost(url, {}, function (item) { $this.ReLoad(); scope.ClosePopup(); toastr.info(item.message);});
            }
        });
        popup.AddButton({
            value: "[K]hông",
            icon: "far fa-times-circle",
            cls: "btn btn-danger az-btn",
            cmd: "k",
            func: function (elem, scope) {
                scope.ClosePopup();
            }
        });
        popup.setHtml("Bạn có muốn xóa bản ghi này không?");
        popup.setTitle("Thông báo");
        popup.ShowPopup();
       
    });
    $($this).find(".az-btn-export").on("click", function () {

        var href = $this.location.href;
        if (href.indexOf("?") < 0) {
            href = href + "?";
        }
        location.href=href+"&h=download"
    });
    $($this).find(".az-btn-import").on("click", function () {
        var popup = new AZPopup();
        popup.ClearButton();
        popup.setHtml("<h3>Đang phát triển chức năng này</h3>");
        popup.setTitle("Nhập từ excel");
        popup.ModalSize = $this.FormSize;
        popup.ShowPopup();
    });
    $($this).find(".az-search-form .az-input-change-search").on("change", function () {
            $data = $(this).parents(".az-search-form").serializeArray();
            $(this).parents(".az-search-form").find('input[type="checkbox"]:not(:checked)').each(function () {
                if ($data.indexOf(this.name) < 0) {
                    $data.push({ name: this.name, value: false });
                }
            });
            var notSearch = $(this).attr("data-not-search")
            if (notSearch)
                notSearch = notSearch.split(",");
            hrefSearch = "";
            $.each($data, function (index, item) {
                if (notSearch != undefined && notSearch.indexOf(item.name) > -1) {
                } else {
                    if (hrefSearch !== "")
                        hrefSearch += "&";
                    if (item.value !== "")
                    {
                        hrefSearch += item.name + "=" + encodeURIComponent(item.value);
                    }else 
                    if (item.value === false) {
                        hrefSearch += item.name + "=False";
                    }
                }  
            });
            if (hrefSearch != "") {
                hrefSearch = $this.location.pathname + "?" + hrefSearch;
                $this.LoadLink(hrefSearch, function (flg) {
                    if (flg) {
                        toastr.info("Đã tìm kiếm thành công");
                    } else {
                        toastr.error("Lỗi không tìm được");
                    }
                });               
            } else {
                toastr.error("Lỗi không tìm được");
            }
        })
    $($this).find(".az-btn-search").on("click", function () {
            $data = $($this.FormSearch).serializeArray();
            hrefSearch = "";
            $.each($data, function (index, item) {
                if (item.value != "") {
                    if (hrefSearch != "")
                        hrefSearch += "&";
                    hrefSearch += item.name + "=" + encodeURIComponent(item.value);
                }
            });
            if (hrefSearch != "") {
                hrefSearch = $this.location.pathname + "?" + hrefSearch;
                $this.LoadLink(hrefSearch, function (flg) {
                    if (flg) {
                        toastr.info("Đã tìm kiếm thành công");
                    } else {
                        toastr.error("Lỗi không tìm được");
                    }
                });
            } else {
                toastr.error("Lỗi không tìm được");
            }
    });
    $($this).find(".az-change-ajax").on("change", function () {
        hrefSearch = $this.location.pathname + "?" + $(this).attr("name") + "=" + $(this).val()
        $this.LoadLink(hrefSearch, function (flg) {
            if (flg) {
                toastr.info("Đã thay đổi bảng dữ liệu");
            } else {
                toastr.error("Lỗi không tìm được");
            }
        });
    });
        $($this).find(".az-link").on("click", function (e) {
            e.preventDefault();
            $this.LoadLink($(this).attr("href"), function (flg) {
                if (flg) {
                    toastr.info("Đã thay đổi bảng dữ liệu");
                } else {
                    toastr.error("Lỗi không tìm được");
                }
            });
        });
    if ($($this.DataTable).hasClass("table-freeze"))
        $($this.DataTable).TableFreeze();
    if ($this.FormSearch)
        $($this.FormSearch).find("*:input,select,textarea").filter(":not([readonly='readonly']):not([disabled='disabled']):not([type='hidden'])").first().focus();
    if ($callback) $callback($this);
}

$.fn.AZManager = AZManager;