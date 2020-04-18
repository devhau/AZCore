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
        var valueNumber = 0, valueMoney = 0, valueMoneySum = 0;
        $(".modal-dialog .az-data-table table tbody tr").each(function () {
            valueNumber += parseInt($(this).children("td").eq(2).children("input").val());
            valueMoney += parseInt($(this).children("td").eq(4).children("label").text().replace(",",""));
        });

        let eleNumber = $(".modal-dialog .list-info-money .item-info-money").eq(0).children(".value");
        let eleMoney = $(".modal-dialog .list-info-money .item-info-money").eq(1).children(".value");
        let eleCost = $(".modal-dialog .list-info-money .item-info-money").eq(2).children(".value");
        let eleMoneySum = $(".modal-dialog .list-info-money .item-info-money").eq(3).children(".value");

        valueMoneySum = valueMoney + parseInt(eleCost.text());
        $(eleNumber).text(valueNumber.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,"));
        $(eleMoney).text(valueMoney.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,"));
        $(eleMoneySum).text(valueMoneySum.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,"));
        $(".modal-dialog .az-data-table table input").on('input', function () {
            let number = $(this).parent().parent().children("td").eq(2).children("input").val();
            let price = $(this).parent().parent().children("td").eq(3).children("input").val();
            $(this).parent().parent().children("td:last-child").children("label").text(calMoney(number, price));

            valueNumber = 0, valueMoney = 0, valueMoneySum = 0;
            $(".modal-dialog .az-data-table table tbody tr").each(function () {
                valueNumber += parseInt($(this).children("td").eq(2).children("input").val());
                valueMoney += parseInt($(this).children("td").eq(4).children("label").text().replace(/,/g, ""));
                console.log(valueNumber);
                console.log(valueMoney);
            });
            valueMoneySum = valueMoney + parseInt(eleCost.text());
            $(eleNumber).text(valueNumber.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,"));
            $(eleMoney).text(valueMoney.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,"));
            $(eleMoneySum).text(valueMoneySum.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,"));
        });
    }
});

