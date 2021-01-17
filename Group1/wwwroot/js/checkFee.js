function checkFee()
{
    var homedeliveryFee = document.querySelector('input[name="deliveryMethod"]:checked').value;
    var fee = 0;
    if (homedeliveryFee == 1) {
        fee = 50;
    }
    if (homedeliveryFee == 2) {
        fee = 0;
    }

    document.getElementById('shippingFee').value = fee;
    document.getElementById('shippingFee').innerText = document.getElementById('shippingFee').value + " SEK";
}