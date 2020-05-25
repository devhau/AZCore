
$(".az-update-cashFlow .btnUpdateDetail").on('click', function () {
    var paymentDate = $("#InputCreateAt").val();
    var realmoney = $("#InputRealMoney").val();
    if (paymentDate == "") {
        alert("Real Payment Date is not input");
        return;
    }
    if (realmoney == "") {
        alert("Real Money is not input");
        return;
    }
    let inputNumber = '<input type="hidden" name="ListCashDetailModel[].CreateAt" class="form-control" value="' + paymentDate + '"/>';
    let inputPrice = '<input type="hidden" name="ListCashDetailModel[].RealMoney" class="form-control" value="' + realmoney + '"/>';
    let lbPaymentDate = '<label name="ListCashDetailModel[].CreateAt" >' + paymentDate + '</label>';
    let lbRealMoney = '<label name="ListCashDetailModel[].RealMoney" />' + realmoney + '</label>';
    $(".az-update-cashFlow .az-data-table table > tbody:last-child").
        append("<tr><td style='width: 60px'>" + lbPaymentDate + inputNumber + "</td><td>" + lbRealMoney + inputPrice + "</td><td><a href='javascript:'><i class='fa fa-minus-circle'></i></a></td></tr>");
    var totalCur = $('.lbTotalMoney').text();
    totalCur = totalCur.replace(',', '');
    var calTotal = Number(realmoney.replace(',', '')) + Number(totalCur);
    $('.lbTotalMoney').text(calTotal);
    $("#InputRealPaymentDate").val('');
    $("#InputRealMoney").val('');

});

$(".az-update-cashFlow .customerClass").on('change', function () {
    var dataItem = decodeURIComponent($(this).children("option:selected").attr("data-item"));
    if (dataItem != "") {
        $(".az-update-cashFlow .list-info-customer").show();
        dataItem = JSON.parse(dataItem);
        $(".az-update-cashFlow .list-info-customer .list-info-header").text(dataItem.FullName);
        $(".az-update-cashFlow .list-info-customer .list-info-item .list-info-item-content").eq(0).text(dataItem.Address);
        $(".az-update-cashFlow .list-info-customer .list-info-item .list-info-item-content").eq(1).text(dataItem.PhoneNumber);
    }
});
