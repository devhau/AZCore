function AZPopup(options) {
	let $this = this;
	$this.PopupId = "popup" + new Date().getTime();
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
	$($this.Modal).addClass(this.PopupId);
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
	$this.ReLoad = function (callback) {  
		AjaxMain.DoGet($this.link, {}, function (itemData) {
			$($this.ModalBody).html(itemData.html);
			if (callback) callback(true);
		}, function (e) { if (callback) callback(false); });
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
		if (options && options.eventClose !== undefined) options.eventClose();
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
		if ($($this.ModalBody).find(".az-manager").length > 0) {
			$($this.ModalBody).addClass("has-manage");
		}
		HotKeyMain.Init();
		$this.focusPopup();
		
	}
	$this.SerializeData = function () {		
		return $($this.ModalForm).AZSerializeForm();
	}
	$this.destroy = function () {
		if ($this.Manager === ManagerMain.Current()) ManagerMain.Remove();
		$($this.Modal).remove();
		delete $this;
		delete this;
		$this = undefined;
	}
	$this.SumitForm = function () {
		AjaxMain.DoPost($this.link, $this.SerializeData(), function (item) {
			if (item.statusCode == 200 || item.statusCode == 201) {
				$this.ClosePopup();
				toastr.success(item.message);
			} else {
				toastr.error(item.message);
			}
		}, function (error) {

		})
    }
	PopupMain.Push($this);
}
var PopupMain = new LinkedList();