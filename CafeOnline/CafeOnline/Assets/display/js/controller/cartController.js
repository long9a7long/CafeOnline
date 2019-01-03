var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').on('click', function () {
            window.location.href = "/";
        });
        $('#btnPayment').on('click', function () {
            window.location.href = "/Cart/Payment";
        });
        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.txtCount');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Count: $(item).val(),
                    Product: {
                        ProdID: $(item).data('id')
                    }
                });
            });
            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart"; 
                    }
                    else
                    {

                    }
                }
            })
        });
        $('#btnDeleteAll').off('click').on('click', function () {
            $.ajax({
                url: '/Cart/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }
                    else {

                    }
                }
            })
        });
        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: {id:$(this).data('id')},
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }
                    else {

                    }
                }
            })
        });
    }
}
cart.init();