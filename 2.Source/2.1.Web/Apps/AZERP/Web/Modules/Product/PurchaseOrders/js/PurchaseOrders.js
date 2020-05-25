if (!PopupMain.isEmpty() && PopupMain.Current().id===undefined) {
    $(".az-update-purchase-order .az-data-table").hide();
    $(".az-update-purchase-order .list-info-supplier").hide();
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
    $(".az-update-purchase-order .az-data-table table tbody tr").each(function () {
        valueNumber += parseInt($(this).children("td").eq(3).children("input").val());
        valueMoney += parseInt($(this).children("td").eq(5).children("label").text().replace(/,/g, ""));
    });
    let eleNumber = $(".az-update-purchase-order .list-info-money .item-info-money").eq(0).children(".value");
    let eleMoney = $(".az-update-purchase-order .list-info-money .item-info-money").eq(1).children(".value");
    let eleCost = $(".az-update-purchase-order .list-info-money .item-info-money").eq(2).children(".value");
    let eleMoneySum = $(".az-update-purchase-order .list-info-money .item-info-money").eq(3).children(".value");
    valueMoneySum = valueMoney + parseInt(eleCost.text());
    $(eleNumber).text(valueNumber.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,"));
    $(eleMoney).text(valueMoney.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,"));
    $(eleMoneySum).text(valueMoneySum.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,"));
}

function addEvent() {
    $(".az-update-purchase-order .az-data-table table input.form-control").on('input', function () {
        let number = $(this).parent().parent().children("td").eq(3).children("input").val();
        let price = $(this).parent().parent().children("td").eq(4).children("input").val();
        $(this).parent().parent().children("td").eq(5).children("label").text(calMoney(number, price));
        caculatorAll();
    });
    $(".az-update-purchase-order .az-data-table table a").on('click', function () {
        $(this).parent().parent().remove();
        if ($(".az-update-purchase-order .az-data-table table tbody tr").length == 0) {
            $(".az-update-purchase-order .az-data-table").hide();
        }
        caculatorAll();
    });
}

$(".az-update-purchase-order .productClass").on('change', function () {
    let value = $(this).val();
    var dataItem = decodeURIComponent($(this).children("option:selected").attr("data-item"));
    if (dataItem != "") {
        dataItem = JSON.parse(dataItem);
    }
    if (value != "") {
        $(".az-update-purchase-order .az-data-table").show();
        let img = "<img style='width: 100%' src='" + dataItem.Picture + "'>"
        let inputID = "<input type='hidden' name='listDataOrder[].ProductId' value='" + dataItem.Id + "' />";
        let inputNumber = '<input type="number" name="listDataOrder[].ImportNumber" class="form-control" value="1">';
        let inputPrice = '<input type="number" name="listDataOrder[].ImportPrice" class="form-control" value="' + dataItem.ImportPrice + '"';
        $(".az-update-purchase-order .az-data-table table > tbody:last-child")
            .append("<tr><td style='width: 60px'>" + img + "</td>><td>" + dataItem.Code + inputID + "</td><td>" + dataItem.Name + "</td><td>" + inputNumber + "</td><td>" + inputPrice + "</td><td><label>" + dataItem.ImportPrice.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,") + "</label></td><td><a href='javascript:'><i class='fa fa-minus-circle'></i></a></td></tr>");
        addEvent();
        caculatorAll();
    }
    $(this).val(null);
});

$(".az-update-purchase-order .supplierClass").on('change', function () {
    var dataItem = decodeURIComponent($(this).children("option:selected").attr("data-item"));
    if (dataItem != "") {
        $(".az-update-purchase-order .list-info-supplier").show();
        dataItem = JSON.parse(dataItem);
        if (dataItem.AbbreviatedName == "") {
            $(".az-update-purchase-order .list-info-supplier .list-info-header").text(dataItem.Name);
        } else {
            $(".az-update-purchase-order .list-info-supplier .list-info-header").text(dataItem.Name + " - " + dataItem.AbbreviatedName);
        }
        $(".az-update-purchase-order .list-info-supplier .list-info-item .list-info-item-content").eq(0).text(dataItem.Address);
        $(".az-update-purchase-order .list-info-supplier .list-info-item .list-info-item-content").eq(1).text(dataItem.PhoneNumber);
    }
});
  