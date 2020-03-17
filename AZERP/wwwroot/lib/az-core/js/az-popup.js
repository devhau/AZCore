function AZPopup() {
	this.template = '<div class="az-modal modal fade show"  style="display: block;" aria-modal="true">\
						<div class="modal-dialog">\
							<div class="modal-content">\
								<div class="modal-header">\
									<h4 class="modal-title"></h4>\
									<button type="button" class="close" data-dismiss="modal" aria-label="Close">\
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
	var $this = this;
	this.Buttons = [{ value: "Đóng", cls: "btn btn-default az-btn az-btn-close", func: function (elem, scope) { scope.CloseForm(); } }];
	this.Modal = $(this.template);
	this.ModalBody = $(this.Modal).find(".modal-body");
	this.ModalFooter = $(this.Modal).find(".modal-footer");
	this.ModalHeader = $(this.Modal).find(".modal-header");
	this.ModalClose = $(this.Modal).find(".modal-header").find(".close");
	this.ModalTitle = $(this.Modal).find(".modal-header").find(".modal-title");
	this.ModalSize = "az-modal-none";
	this.setHtml = function ($data) {
		$($this.ModalBody).html($data);
	}
	this.setTitle = function ($data) {
		$($this.ModalTitle).html($data);
	}
	this.ClearButton = function () {
		this.Buttons = [];
	}
	this.AddButton = function (btnInfo) {
		this.Buttons.push(btnInfo);
	}
	this.createButton = function (btnInfo) {
		var $this = this;
		var btn = $("<input type='button'>");
		btn.attr("value", btnInfo.value);
		btn.addClass(btnInfo.cls == null || btnInfo.cls == "" ? clsButtonDefault : btnInfo.cls);
		btn.click(function () { btnInfo.func(this, $this); });
		return btn;
	}
	this.ClosePopup = function () {
		$($this.Modal).remove();
	}
	this.ShowPopup = function () {
		$this.Buttons.forEach(function (item) { $($this.ModalFooter).append($this.createButton(item)); });
		$($this.Modal).addClass($this.ModalSize);
		$("body").append($this.Modal);
		$($this.ModalClose).click($this.ClosePopup);
	}
	
}