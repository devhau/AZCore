﻿function AZPopup() {
	let $this = this;
	$this.scope = "popup"+ Math.ceil(Math.random() * 10)
	$this.template = '<div class="az-modal modal fade show"  style="display: block;" aria-modal="true">\
						<div class="modal-dialog">\
							<div class="modal-content">\
								<div class="modal-header">\
									<h4 class="modal-title"></h4>\
									<button type="button" class="close az-btn-close" data-dismiss="modal" aria-label="Close" data-cmd-key="esc">\
										<span aria-hidden="true">×</span>\
									</button>\
								</div>\
								<div class="modal-body">\
								</div>\
								<div class="modal-footer">\
								</div>\
							</div>\
					</div>\
				</div>';
	$this.Buttons = [{ value: "Đóng", cls: "btn btn-default az-btn az-btn-close", icon: "", func: function (elem, scope) { scope.CloseForm(); } }];
	$this.clsButtonDefault = "btn btn-default az-btn";
	$this.Modal = $($this.template);
	$this.ModalBody = $($this.Modal).find(".modal-body");
	$this.ModalForm = $($this.Modal).find(".modal-body");
	$this.ModalFooter = $($this.Modal).find(".modal-footer");
	$this.ModalHeader = $($this.Modal).find(".modal-header");
	$this.ModalClose = $($this.Modal).find(".modal-header").find(".close");
	$this.ModalTitle = $($this.Modal).find(".modal-header").find(".modal-title");
	$this.ModalSize = "az-modal-none";
	$this.IsForm = false;
	$this.id = undefined;
	$this.DataItem = undefined;
	$this.Manager = undefined;
	$this.link = "";
	$this.setDataItem = function (DataItem) {
		$this.DataItem = DataItem;
		if ($this.DataItem) {
			$($this.Modal).attr("data-item", $this.DataItem);
		}
	}
	$this.setId = function (id) {
		$this.id = id;
		if ($this.id) {
			$($this.Modal).attr("link-id", $this.id);
		}
	}
	$this.setLink = function (link) {
		$this.link = link;
		if ($this.link) {
			$($this.Modal).attr("link-popup", $this.link);
		}
	}
	$this.setHtml = function ($data) {
		if ($this.IsForm === true) {
			$this.ModalForm = $("<form>");
			$($this.ModalForm).append($data)
			$($this.ModalBody).html(this.ModalForm);
		} else {
			$($this.ModalBody).html($data);
		}
	}
	$this.setTitle = function ($data) {
		$($this.ModalTitle).html($data);
	}
	$this.ClearButton = function () {
		$this.Buttons = [];
	}
	$this.AddButton = function (btnInfo) {
		$this.Buttons.push(btnInfo);
	}
	$this.createButton = function (btnInfo) {
		let btn = $("<button></button>");
		$(btn).html("<i class=\"" + btnInfo.icon + "\"></i> " + btnInfo.value);
		btn.addClass(btnInfo.cls == undefined || btnInfo.cls == "" ? $this.clsButtonDefault : btnInfo.cls);
		if (btnInfo.cmd) {
			$(btn).attr("data-cmd-key", btnInfo.cmd);
			if (btnInfo.cmdfunc) {
				$(btn).attr("data-cmd-func", btnInfo.cmdfunc);
			}
		}
		btn.click(function () { btnInfo.func(btn, $this); });
		return btn;
	}
	$this.ClosePopup = function () {
		PopupMain.Remove();
		if (!PopupMain.isEmpty()) {
			PopupMain.Current().focusPopup();
		}
		HotKeyMain.Init();
	}
	$this.focusPopup = function () {
		$($this.Modal).focus();
		if ($this.ModalForm)
			$($this.ModalForm).find("*:input,select,textarea").filter(":not([readonly='readonly']):not([disabled='disabled']):not([type='hidden'])").first().focus();

	}
	$this.getPathName = function () {
		return AZCore.getLocation($this.link).pathname;
	}
	$this.ShowPopup = function (callbackClose) {
		let flg = false;
		$this.Buttons.forEach(function (item) { $($this.ModalFooter).append($this.createButton(item)); flg = true; });
		if (flg === false) {
			$($this.ModalFooter).remove();
		}
		$($this.Modal).addClass($this.ModalSize);
		
		$("body").append($this.Modal);
		$($this.ModalClose).click(function () { $this.ClosePopup(); if (callbackClose) callbackClose($this); });
		
		HotKeyMain.Init();
		$this.focusPopup();
		
	}
	$this.SerializeData = function () {
		var data = new FormData();
		var $data = $($this.ModalForm).serializeArray();
		$($this.ModalForm).find('input[type="checkbox"]:not(:checked)').each(function () {
			if ($data.indexOf(this.name) < 0) {
				$data.push({ name: this.name, value: false });
			}
		});
		$.each($data, function (key, input) {
			data.append(input.name, input.value);
		});
		$($this.ModalForm).find('input[type="file"]').each(function () {
			if ($data.indexOf(this.name) < 0) {
				var file_data = $(this)[0].files;
				if (file_data) {

					for (var i = 0; i < file_data.length; i++) {
						console.log(file_data[i]);
						data.append(this.name, file_data[i]);
					}
				}
			}
		});
		return data;
	}
	$this.destroy = function () {
		if ($this.Manager) ManagerMain.Remove();
		$($this.Modal).remove();
		delete $this;
		delete this;
		$this = undefined;
	}
	PopupMain.Push($this);
}
var PopupMain = new LinkedList();