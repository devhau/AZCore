function CheckinCheckout($this) {
    $($this).AZManager(function (ma) {
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
                    toastr.success(item.message);

                });
            }
            $(this).removeAttr("is-change");
        });
        $(ma.DataTable).find("select").on("change", function () {
            var userId = $(this).parents("tr").attr("data-user-id");
            var dateDay = $(this).parents("td").attr("data-day");
            var valueInput = $(this).val();
            var url = ma.location.href + "&h=Shift";
            $this = this;
            ma.DoPost(url, { UserId: userId, DateDay: dateDay, ValueInput: valueInput }, function (item) {
                $($this).find('option').get(0).remove();
                $($this).select2({ theme: 'bootstrap4', width: 'resolve' });
                toastr.success(item.message);
            });
        });
    });
}