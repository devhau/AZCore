if (!PopupMain.isEmpty() && PopupMain.Current().id === undefined) {
    $(".az-update-order .az-data-table").hide();
    $(".az-update-order .list-info-customer").hide();
}

addEvent();
var valueNumber = 0, valueMoney = 0, valueMoneySum = 0;

function calMoney(number, price) {
    if (isNaN(number) && isNaN(price)) {
        return 0;
    }
    return (parseInt(number) * parseInt(price)).toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");
}

function caculatorAll() {
    valueNumber = 0, valueMoney = 0, valueMoneySum = 0;
    $(".az-update-order .az-data-table table tbody tr").each(function () {
        valueNumber += parseInt($(this).children("td").eq(2).children("input").val());
        valueMoney += parseInt($(this).children("td").eq(4).children("label").text().replace(/,/g, ""));
    });
    let eleNumber = $(".az-update-order .list-info-money .item-info-money").eq(0).children(".value");
    let eleMoney = $(".az-update-order .list-info-money .item-info-money").eq(1).children(".value");
    let eleCost = $(".az-update-order .list-info-money .item-info-money").eq(2).children(".value");
    let eleMoneySum = $(".az-update-order .list-info-money .item-info-money").eq(3).children(".value");
    valueMoneySum = valueMoney + parseInt(eleCost.text());
    $(eleNumber).text(valueNumber.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,"));
    $(eleMoney).text(valueMoney.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,"));
    $(eleMoneySum).text(valueMoneySum.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,"));
}

function addEvent() {
    $(".az-update-order .az-data-table table input").on('input', function () {
        let number = $(this).parent().parent().children("td").eq(2).children("input").val();
        let price = $(this).parent().parent().children("td").eq(3).children("input").val();
        $(this).parent().parent().children("td").eq(4).children("label").text(calMoney(number, price));
        caculatorAll();
    });
    $(".az-update-order .az-data-table table a").on('click', function () {
        $(this).parent().parent().remove();
        caculatorAll();
    });
}

$(".az-update-order .productClass").on('change', function () {
    let value = $(this).val();
    var dataItem = decodeURIComponent($(this).children("option:selected").attr("data-item"));
    if (dataItem != "") {
        dataItem = JSON.parse(dataItem);
    }
    if (value != "") {
        $(".az-update-order .az-data-table").show();
        let inputID = "<input type='hidden' name='listDataOrder[].ProductId' value='" + dataItem.Id + "' />";
        let inputNumber = '<input type="number" name="listDataOrder[].ImportNumber" class="form-control" value="1">';
        let inputPrice = '<input type="number" name="listDataOrder[].ImportPrice" class="form-control" value="' + dataItem.RetailPrice + '"';
        $(".az-update-order .az-data-table table > tbody:last-child").
            append("<tr><td>" + dataItem.Code + inputID + "</td><td>" + dataItem.Name + "</td><td>" + inputNumber + "</td><td>" + inputPrice + "</td><td><label>" + dataItem.RetailPrice.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,") + "</label></td><td><a href='javascript:'><i class='fa fa-minus-circle'></i></a></td></tr>");
        addEvent();
        caculatorAll();   
    }
    $(this).val(null);
});

$(".az-update-order .customerClass").on('change', function () {
    var dataItem = decodeURIComponent($(this).children("option:selected").attr("data-item"));
    if (dataItem != "") {
        $(".az-update-order .list-info-customer").show();
        dataItem = JSON.parse(dataItem);
        $(".az-update-order .list-info-customer .list-info-header").text(dataItem.FullName);
        $(".az-update-order .list-info-customer .list-info-item .list-info-item-content").eq(0).text(dataItem.Address);
        $(".az-update-order .list-info-customer .list-info-item .list-info-item-content").eq(1).text(dataItem.PhoneNumber);
    }
});
  