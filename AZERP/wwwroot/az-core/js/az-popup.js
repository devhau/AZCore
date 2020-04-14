function AZPopup() {
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
	$this.Buttons = [{ value: "Đóng", cls: "btn btn-default az-btn az-btn-close",icon:"", func: function (elem, scope) { scope.CloseForm(); } }];
	$this.Modal = $($this.template);
	$this.ModalBody = $($this.Modal).find(".modal-body");
	$this.ModalForm = $($this.Modal).find(".modal-body");
	$this.ModalFooter = $($this.Modal).find(".modal-footer");
	$this.ModalHeader = $($this.Modal).find(".modal-header");
	$this.ModalClose = $($this.Modal).find(".modal-header").find(".close");
	$this.ModalTitle = $($this.Modal).find(".modal-header").find(".modal-title");
	$this.ModalSize = "az-modal-none";
	$this.IsForm = false;
	$this.link = "";
	$this.setLink = function (link) {
		$this.link = link;
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
		btn.addClass(btnInfo.cls == null || btnInfo.cls == "" ? clsButtonDefault : btnInfo.cls);
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
		$($this.Modal).remove();
		PopupMain.ClosePopup();
		console.log("ClosePopup");
		console.log(PopupMain.PopupCurrent());
		if (!PopupMain.isEmpty()) {
			PopupMain.PopupCurrent().focusPopup();
		}
		HotKeyMain.Init();
	}
	$this.focusPopup = function () {
		$($this.Modal).focus();
		if ($this.ModalForm)
			$($this.ModalForm).find("*:input,select,textarea").filter(":not([readonly='readonly']):not([disabled='disabled']):not([type='hidden'])").first().focus();

	}
	$this.ShowPopup = function (callbackClose) {
		let flg = false;
		$this.Buttons.forEach(function (item) { $($this.ModalFooter).append($this.createButton(item)); flg = true; });
		if (flg === false) {
			$($this.ModalFooter).remove();
		}
		$($this.Modal).addClass($this.ModalSize);
		if ($this.link) {
			$($this.Modal).attr("link-popup", $this.link);
		}
		$("body").append($this.Modal);
		$($this.ModalClose).click(function () { $this.ClosePopup(); if (callbackClose) callbackClose($this); });
		
		HotKeyMain.Init();
		$this.focusPopup();
		
	}
	$this.SerializeData = function () {
		$data = $($this.ModalForm).serializeArray();
		$($this.ModalForm).find('input[type="checkbox"]:not(:checked)').each(function () {
			if ($data.indexOf(this.name) < 0) {
				$data.push({ name: this.name, value: false });
			}
		});
		return $data;
	}
	PopupMain.PushPopup($this);
}
function ManagerPopup() {
	this.data = {};
	this.size = 0;
	this.isEmpty = function () {
		return this.size === 0;
	}
	this.PopupCurrent = function () {	
		if (this.isEmpty()) return undefined;
		return this.data[this.size-1];
	}
	this.PushPopup = function (popup) {
		this.data[this.size] = popup;
		this.size++;
		return true;
	}
	this.ClosePopup = function () {
		if (this.isEmpty()) return false;
		delete this.data[this.size - 1];
		this.size--;
		return true;
	}
	this.clear = function () {
		while (!this.isEmpty()) this.ClosePopup();
		this.size = 0;
	}
}
var PopupMain = new ManagerPopup();