$(document).ready(function () {
    var trtlBalanceExist = $(".trtlBalanceWrapper").length;
    if (trtlBalanceExist > 0) {
        getCurrentUserTRTLBalance();
        //setInterval(function () {
        //    getCurrentUserTRTLBalance();
        //}, 60000);
    }


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



function getCurrentUserTRTLBalance() {
    $.ajax({
        type: "GET",
        url: "/home/getCurrentUserTRTLBalance",
        dataType: "html",
        success: function (data) {
            $(".trtlBalanceWrapper").html(data);
        },
        error: function (response) {
            
        }
    });
    
}

function getAmountFee(amount, element) {
    $.ajax({
        type: "GET",
        url: "/market/getAmountFee",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: {
            amount: amount
        },
        success: function (data) {
            element.closest(".subTotalBuy").text(data);
        },
        error: function (response) {
        }
    });

}
