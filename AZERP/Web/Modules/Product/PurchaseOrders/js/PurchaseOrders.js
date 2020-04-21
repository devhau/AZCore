$(".modal-dialog .az-data-table").hide();
$(".list-info-supplier").hide();
var valueNumber = 0, valueMoney = 0, valueMoneySum = 0;
function calMoney(number, price) {
    if (isNaN(number) && isNaN(price)) {
        return 0;
    }
    return (parseInt(number) * parseInt(price)).toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");
}

function caculatorAll() {
    valueNumber = 0, valueMoney = 0, valueMoneySum = 0;
    $(".modal-dialog .az-data-table table tbody tr").each(function () {
        valueNumber += parseInt($(this).children("td").eq(2).children("input").val());
        valueMoney += parseInt($(this).children("td").eq(4).children("label").text().replace(/,/g, ""));
    });
    let eleNumber = $(".modal-dialog .list-info-money .item-info-money").eq(0).children(".value");
    let eleMoney = $(".modal-dialog .list-info-money .item-info-money").eq(1).children(".value");
    let eleCost = $(".modal-dialog .list-info-money .item-info-money").eq(2).children(".value");
    let eleMoneySum = $(".modal-dialog .list-info-money .item-info-money").eq(3).children(".value");
    valueMoneySum = valueMoney + parseInt(eleCost.text());
    $(eleNumber).text(valueNumber.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,"));
    $(eleMoney).text(valueMoney.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,"));
    $(eleMoneySum).text(valueMoneySum.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,"));
}

$(".productClass").on('change', function () {
    let value = $(this).val();
    var dataItem = decodeURIComponent($(this).children("option:selected").attr("data-item"));
    if (dataItem != "") {
        dataItem = JSON.parse(dataItem);
    }
    if (value != "") {
        $(".modal-dialog .az-data-table").show();
        let inputID = "<input type='hidden' name='listDataOrder[].ProductId' value='" + dataItem.Id + "' />";
        let inputNumber = '<input type="number" name="listDataOrder[].ImportNumber" class="form-control" value="1">';
        let inputPrice = '<input type="number" name="listDataOrder[].ImportPrice" class="form-control" value="' + dataItem.ImportPrice + '"';
        $(".modal-dialog .az-data-table table > tbody:last-child").append("<tr><td>" + dataItem.Code + inputID+ "</td><td>" + dataItem.Name + "</td><td>" + inputNumber + "</td><td>" + inputPrice + "</td><td><label class='LabelThanhTien'>" + dataItem.ImportPrice.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,") + "</label></td><td><a href='javascript:'><i class='fa fa-minus-circle'></i></a></td></tr>");
        caculatorAll();
        $(".modal-dialog .az-data-table table input").on('input', function () {
            let number = $(this).parent().parent().children("td").eq(2).children("input").val();
            let price = $(this).parent().parent().children("td").eq(3).children("input").val();
            $(this).parent().parent().children("td").eq(5).children("label").text(calMoney(number, price));
            caculatorAll();
        });
        $(".modal-dialog .az-data-table table a").on('click', function () {
            $(this).parent().parent().remove();
            caculatorAll();
        });
    }
    $(this).val(null);
});

$(".supplierClass").on('change', function () {
    var dataItem = decodeURIComponent($(this).children("option:selected").attr("data-item"));
    if (dataItem != "") {
        $(".list-info-supplier").show();
        console.log(dataItem);
        dataItem = JSON.parse(dataItem);
        if (dataItem.AbbreviatedName == "") {
            $(".list-info-supplier .list-info-header").text(dataItem.Name);
        } else {
            $(".list-info-supplier .list-info-header").text(dataItem.Name + " - " + dataItem.AbbreviatedName);
        }
        $(".list-info-supplier .list-info-item .list-info-item-content").eq(0).text(dataItem.Address);
        $(".list-info-supplier .list-info-item .list-info-item-content").eq(1).text(dataItem.PhoneNumber);
    }
});
  