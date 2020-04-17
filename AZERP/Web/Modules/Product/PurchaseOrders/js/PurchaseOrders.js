function calMoney(number, price) {
    if (isNaN(number) && isNaN(price)) {
        return 0;
    }
    return (parseInt(number) * parseInt(price)).toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");
}

$("#InputImportNumber").on('input', function () {
    $("#LabelThanhTien").text(calMoney($("#InputImportNumber").val(), $("#InputImportPrice").val()));
});

$("#InputImportPrice").on('input', function () {
    $("#LabelThanhTien").text(calMoney($("#InputImportNumber").val(), $("#InputImportPrice").val()));
});