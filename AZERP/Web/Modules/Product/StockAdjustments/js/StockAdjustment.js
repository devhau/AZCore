$(".modal-dialog .az-data-table").hide();
function difference(before, after) {
    if (isNaN(after) && isNaN(before)) {
        return 0;
    }
    return (parseInt(after) - parseInt(before)).toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");
}

$("#InputProductCode").on('change', function () {
    let value = $(this).val();
    if (value != "") {
        $(".modal-dialog .az-data-table").show();
        let name = $("#InputProductCode option[value=" + value + "]").text();
        let inputAfter = '<input type="text" class="form-control test" value="1">';
        let inputNote = '<input type="text" class="form-control">';
        $(".modal-dialog .az-data-table table > tbody:last-child").append("<tr><td></td><td>" + name + "</td><td>10</td><td>-9</td><td>" + inputAfter + "</td><td>" + inputNote + "</td></tr>");
        var valueAfter = 0, valueSum = 0;
        $(".modal-dialog .az-data-table table tbody tr").each(function () {
            valueAfter += parseInt($(this).children("td").eq(4).children("input").val());
            valueSum += Math.abs(parseInt($(this).children("td").eq(3).text()));
        });

        let eleAfter = $(".modal-dialog .list-info-money .item-info-money").eq(0).children(".value");
        let eleSum = $(".modal-dialog .list-info-money .item-info-money").eq(1).children(".value");

        $(eleAfter).text(valueAfter);
        $(eleSum).text(valueSum);

        $(".modal-dialog .az-data-table table input.test").on('input', function () {
            let before = $(this).parent().parent().children("td").eq(2).text();
            let after = $(this).parent().parent().children("td").eq(4).children("input").val();
            let result = $(this).parent().parent().children("td").eq(3);
            result.text(difference(before, after));

            valueAfter = 0, valueSum = 0;
            $(".modal-dialog .az-data-table table tbody tr").each(function () {
                valueAfter += parseInt($(this).children("td").eq(4).children("input").val());
                valueSum += Math.abs(parseInt($(this).children("td").eq(3).text()));
            });
            $(eleAfter).text(valueAfter);
            $(eleSum).text(valueSum);
        });

    }
});
