/********************************************************
 *                                                      *
 *  File: manager.js                                    *
 *  Description:là tính năng quản lý dữ liệu            *
 *  Author: nguyen van hau                              *
 *  Email: nguyenvanhaudev@gmail.com                    *
 *                                                      *
 ********************************************************/
$.fn.Manager =  function(option) {
    if (!option) option = {};
    let $this = this;
    $this.Manage = $(this).hasClass("az-manager") ? this : $(this).find("az-manage");
    $this.option = {
        FormEditSize:"az-modal-none",
        Edit: {
            Buttons: [
                {
                    Text: "Lưu lại (F2)",
                    Key: "f2",
                    Class: "btn btn-success az-btn az-btn-update",
                    Icon: "far fa-save",
                    func: function (elem, scope,self) {
                    }
                }
            ]
        },
        Add: {
            Buttons: [
                {
                    Text: "Lưu lại (F2)",
                    Key: "f2",
                    Class: "btn btn-success az-btn az-btn-update",
                    Icon: "far fa-save",
                    func: function (elem, scope, self) {
                    }
                }
            ]
        }
    }
    $.extend($this.option, option);
    // Init
    $this.Init = function () {
        $this.MvcGrid = new MvcGrid($($this).find(".mvc-grid")[0]);
        $this.DataTable = $($this).find("table");
        $this.Modal = $($this).parents('.az-modal');
        $this.IsModal = $this.Modal.length > 0;
        if ($this.IsModal) {
            $this.ModalContent = $($this).parents(".modal-body");
            $this.location = CoreMain.getLocation($($this.Modal).attr("link-popup"));
        } else {
            $this.location = location;
        }
        $this.InitEvent();
    }
    $this.InitEvent = function () {
        $($this).find('.btn-edit').off("click");
        $($this).find('.btn-edit').on("click", function () {
            $this.FormEdit($(this).data("id"));
        });
    }
    $this.FormEdit = function ($Id, $DataItem) {
        let url = $this.location.pathname + "?h=update";
        if ($Id) url = url + "&id=" + $Id;
        AjaxMain.DoGet(url, null, function (item) {
            if (item.statusCode && item.statusCode === 401) {
                return;
            }
            var popup = new Popup();
            popup.setLink(url).setId($Id).setDataItem($DataItem).ClearButton();
            popup.IsForm = true;
            if ($Id) {
                $.each($this.option.Edit.Buttons, function (index, el) {
                    popup.AddButton({
                        value: el.Text,
                        icon: el.Icon,
                        cls: el.Class,
                        cmd: item.Key,
                        func: function (elem, scope) {
                            if (el.func)
                                el.func(elem, scope, $this);
                        }
                    });

                });
            } else {
                $.each($this.option.Add.Buttons, function (index, el) {
                    popup.AddButton({
                        value: el.Text,
                        icon: el.Icon,
                        cls: el.Class,
                        cmd: el.Key,
                        func: function (elem, scope) {
                            if (el.func)
                                el.func(elem, scope, $this);
                        }
                    });

                });
            }
            popup.setHtml(item.html);
            $icon = '<i class="fas fa-edit"></i> ';
            if (item.icon && item.icon != "") {
                $icon = '<i class="' + item.icon + '"></i> ';
            }
            popup.setTitle($icon + item.title);
            popup.ModalSize = $this.option.FormEditSize;
            popup.ShowPopup();
        });
    }
    $this.Init();
}