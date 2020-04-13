$(document).ready(function () {
    $("#FormCheckinCheckout").AZManager(function (ma) {
        $(ma.DataTable).TableFreeze();
        $(ma.DataTable).find("input").on("blur", function () {
            console.log(this);
        });
    });
});