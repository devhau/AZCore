$(document).ready(function () {
    $("#FormCheckinCheckout").AZManager(function (ma) {
        $(ma.DataTable).find("input").on("change", function () {
            $(this).attr("is-change", "1");
        });
        $(ma.DataTable).find("input").on("blur", function () {
           
            if ($(this).attr("is-change") == "1") {
                var userId = $(this).parents("tr").attr("data-user-id");
                var dateDay = $(this).parents("td").attr("data-day");
                var valueInput = $(this).val();
                var url = ma.location.href + "&h=Over";
                ma.DoPost(url, { UserId: userId, DateDay: dateDay, ValueInput: valueInput }, function (item) {


                });
            }
            $(this).removeAttr("is-change");
        });
        $(ma.DataTable).find("select").on("change", function () {
            var userId = $(this).parents("tr").attr("data-user-id");
            var dateDay = $(this).parents("td").attr("data-day");
            var valueInput = $(this).val();
            var url = ma.location.href + "&h=Shift";
            ma.DoPost(url, { UserId: userId, DateDay: dateDay, ValueInput: valueInput }, function (item) {


            });
        });
    });
});