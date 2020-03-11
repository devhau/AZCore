function AZPopup() {
	this.template = '<div class="modal fade show" id="modal-xl" style="display: block; padding-right: 17px;" aria-modal="true">\
		<div class="modal-dialog modal-xl">\
			<div class="modal-content">\
				<div class="modal-header">\
					<h4 class="modal-title">Extra Large Modal</h4>\
					<button type="button" class="close" data-dismiss="modal" aria-label="Close">\
						<span aria-hidden="true">×</span>\
					</button>\
				</div>\
				<div class="modal-body">\
					<p>One fine body…</p>\
				</div>\
				<div class="modal-footer justify-content-between">\
					<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>\
					<button type="button" class="btn btn-primary">Save changes</button>\
				</div>\
			</div>\
	</div>\
</div>';
	this.modal = $(this.template); $("body").append(this.modal);


}