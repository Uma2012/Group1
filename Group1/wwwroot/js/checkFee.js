function checkFee()
{
    var homedeliveryFee = document.querySelector('input[name="deliveryMethod"]:checked').value;
    var fee = 0;
    var subtotal = $(this).attr("TotalPrice").value;

    if (homedeliveryFee == 1) {
        fee = 50;
    }
    if (homedeliveryFee == 2) {
        fee = 0;
    }

    document.getElementById('shippingFee').value = fee;
    document.getElementById('shippingFee').innerText = document.getElementById('shippingFee').value + " SEK";
    var totalPrice = +subtotal + +fee;
    document.getElementById('totalPrice').innerText = totalPrice + " SEK"
}

function requiredCheck()
{
    var selectedDelivery = document.getElementsByName("deliveryMethod");
    var SelectedPayment = document.getElementsByName("paymentMethod");
    var i = 0;
    var selected = false;

    while (!selected && i < selectedDelivery.length)
    {
        if (selectedDelivery[i].checked) selected = true;
        i++;  
    }
    if (!selected) alert("Must check shipping!");


    i = 0;
    selected = false;
    while (!selected && i < SelectedPayment.length) {
        if (SelectedPayment[i].checked) selected = true;
        i++;
    }
    if (!selected) alert("Must check payment!");

    return selected;

}