
function AZManager() {
    $(this).find(".az-btn-add").on("click", function () {
        new AZPopup();
    });
    $(this).find(".az-btn-edit").on("click", function () {

        alert("edit");
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