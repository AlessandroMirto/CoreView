function AddToCart(id) {
    $.ajax({
        url: "Cart/AddToCart",
        data: {id: id},
        success: function (result) {
            $("#cart").html(result);
        }
    });
}

function RemoveFromCart(id) {
    $.ajax({
        url: "Cart/RemoveFromCart",
        data: { id: id },
        success: function (result) {
            $("#cart").html(result);
        }
    });
}

function DeleteItem(id) {
    $.ajax({
        url: "Cart/DeleteItem",
        data: { id: id },
        success: function (result) {
            $("#cart").html(result);
        }
    });
}