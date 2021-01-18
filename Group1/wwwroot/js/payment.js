function payment()
{
    var paymentMethod = document.querySelector('input[name="paymentMethod"]:checked').value;

    if (paymentMethod == 1) {
        return alert('Swish');
    }
    if (paymentMethod == 2) {
        return alert('Card');
    }
}