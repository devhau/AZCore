function AZPopup() {
	this.template = '<div class="az-modal modal fade show"  style="display: block;" aria-modal="true">\
						<div class="modal-dialog">\
							<div class="modal-content">\
								<div class="modal-header">\
									<h4 class="modal-title"></h4>\
									<button type="button" class="close az-btn-close" data-dismiss="modal" aria-label="Close">\
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
	this.Buttons = [{ value: "Đóng", cls: "btn btn-default az-btn az-btn-close",icon:"", func: function (elem, scope) { scope.CloseForm(); } }];
	this.Modal = $(this.template);
	this.ModalBody = $(this.Modal).find(".modal-body");
	this.ModalForm = $(this.Modal).find(".modal-body");
	this.ModalFooter = $(this.Modal).find(".modal-footer");
	this.ModalHeader = $(this.Modal).find(".modal-header");
	this.ModalClose = $(this.Modal).find(".modal-header").find(".close");
	this.ModalTitle = $(this.Modal).find(".modal-header").find(".modal-title");
	this.ModalSize = "az-modal-none";
	this.IsForm = false;
	this.setHtml = function ($data) {
		if ($this.IsForm === true) {
			$this.ModalForm = $("<form>");
			$($this.ModalForm).append($data)
			$($this.ModalBody).html(this.ModalForm);
		} else {
			$($this.ModalBody).html($data);
		}
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
		var btn = $("<button></button>");
		$(btn).html("<i class=\"" + btnInfo.icon + "\"></i> " + btnInfo.value);
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
	this.SerializeData = function () {
		$data = $(this.ModalForm).serializeArray();
		$(this.ModalForm).find('input[type="checkbox"]:not(:checked)').each(function () {
			if ($data.indexOf(this.name) < 0) {
				$data.push({ name: this.name, value: false });
			}
		});
		return $data;
	}
	
}