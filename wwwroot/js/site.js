$(document).ready(function () {

    $('.animal_Quantity').on('textInput input', function () {
        var val = this.value;
        var $this = $(this);
        var priceunit = $this.attr("data-unitprice").replace(",", ".");
        $this.parent().parent().parent().find(".subTotalBuy").text(parseFloat(parseFloat(priceunit) * val).toFixed(2));
    });

    $('#Input_WithdrawAmount').on('textInput input', function () {
        var val = this.value;
        if (val.includes(",")) {
            this.value = val.replace(",",".");
        }
        $(".recieveAmout").text(parseFloat(val) - (parseFloat(val) * (5 / 100)).toFixed(2));
    });

});

