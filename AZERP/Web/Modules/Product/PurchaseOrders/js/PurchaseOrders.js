$(".modal-dialog .az-data-table").hide();
function calMoney(number, price) {
    if (isNaN(number) && isNaN(price)) {
        return 0;
    }
    return (parseInt(number) * parseInt(price)).toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");
}

$("#InputProductCode").on('change', function () {
    let value = $("#InputProductCode").val();
    if (value != "") {
        $(".modal-dialog .az-data-table").show();
        let name = $("#InputProductCode option[value=" + value + "]").text();
        let inputNumber = '<input type="text" class="form-control" value="1" name="ImportNumber">';
        let inputPrice = '<input type="text" class="form-control" value="100000" name="inputPrice">';
        $(".modal-dialog .az-data-table table > tbody:last-child").append("<tr><td></td><td>" + name + "</td><td>" + inputNumber + "</td><td>" + inputPrice + "</td><td><label class='LabelThanhTien'>100,000</label></td></tr>");
        $(".modal-dialog .az-data-table table input").on('input', function () {
            console.log($(this).parent().parent().children("td").eq(2).children("input").val());

            let number = $(this).parent().parent().children("td").eq(2).children("input").val();
            let price = $(this).parent().parent().children("td").eq(3).children("input").val();
            $(this).parent().parent().children("td:last-child").children("label").text(calMoney(number, price));
        });
    }
});

