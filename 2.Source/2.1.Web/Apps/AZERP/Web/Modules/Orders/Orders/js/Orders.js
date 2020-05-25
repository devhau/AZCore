if (!PopupMain.isEmpty() && PopupMain.Current().id === undefined) {
    $(".az-update-order .az-data-table").hide();
    $(".az-update-order .list-info-customer").hide();
}

addEvent();
var valueNumber = 0, valueMoney = 0, valueMoneySum = 0;

$(".az-btn-check-store").on("click", function (e) {
    if (e.stopPropagation) e.stopPropagation();
    if (e.preventDefault) e.preventDefault();
    let table = $(".az-update-order .az-data-table tbody tr");
    if (table.length <= 0) {
        toastr.error("Không có sản phẩm để kiểm tra");
    } else {
        let ModalSize = $(this).attr("modal-size");
        let reload = $(this).attr("reload");
        let LinkHref = $(this).attr("href");
        let link = $(this).attr("href");
        if (LinkHref.indexOf("?") > 0) {
            LinkHref += "&ActionType=popup"
        } else
            LinkHref += "?ActionType=popup"
        let listIdProduct = $(".az-update-order .az-data-table tbody tr td input[type='hidden']").map(function () { return $(this).attr("value"); }).get();
        AjaxMain.DoGet(LinkHref, { data: listIdProduct.join(",") }, function (item) {
            if (item.statusCode && item.statusCode === 401) {
                return;
            }
            let popup = new AZPopup();
            popup.ClearButton();
            popup.setHtml(item.html);
            popup.setTitle(item.title);
            popup.setLink(link);
            popup.ModalSize = ModalSize;
            popup.ShowPopup(function () {
                if (reload && reload === 'true') {
                    $this.loadHtml(location.href);
                }
            });
        });
    }
})

function calMoney(number, price) {
    if (isNaN(number) && isNaN(price)) {
        return 0;
    }
    return (parseInt(number) * parseInt(price)).toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");
}

function caculatorAll() {
    valueNumber = 0, valueMoney = 0, valueMoneySum = 0;
    $(".az-update-order .az-data-table table tbody tr").each(function () {
        valueNumber += parseInt($(this).children("td").eq(3).children("input").val());
        valueMoney += parseInt($(this).children("td").eq(5).children("label").text().replace(/,/g, ""));
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
        let number = $(this).parent().parent().children("td").eq(3).children("input").val();
        let price = $(this).parent().parent().children("td").eq(4).children("input").val();
        $(this).parent().parent().children("td").eq(5).children("label").text(calMoney(number, price));
        caculatorAll();
    });
    $(".az-update-order .az-data-table table a").on('click', function () {
        $(this).parent().parent().remove();
        if ($(".az-update-order .az-data-table table tbody tr").length == 0) {
            $(".az-update-order .az-data-table").hide();
        }
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
        let img = "<img style='width: 100%' src='" + dataItem.Picture + "'>"
        let inputID = "<input type='hidden' name='ListDataOrder[].ProductId' value='" + dataItem.Id + "' />";
        let inputNumber = '<input type="number" name="ListDataOrder[].ImportNumber" class="form-control" value="1">';
        let inputPrice = '<input type="number" name="ListDataOrder[].ImportPrice" class="form-control" value="' + dataItem.RetailPrice + '"';
        $(".az-update-order .az-data-table table > tbody:last-child").
            append("<tr><td style='width: 60px'>" + img + "</td><td>" + dataItem.Code + inputID + "</td><td>" + dataItem.Name + "</td><td>" + inputNumber + "</td><td>" + inputPrice + "</td><td><label>" + dataItem.RetailPrice.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,") + "</label></td><td><a href='javascript:'><i class='fa fa-minus-circle'></i></a></td></tr>");
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
  