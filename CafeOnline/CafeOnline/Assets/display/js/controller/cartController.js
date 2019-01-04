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
            if (confirm("Bạn muốn tất cả sản phẩm này?")) {
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
            } 
        });
        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            if (confirm("Bạn muốn xóa sản phẩm này?")) {
                $.ajax({
                    data: { id: $(this).data('id') },
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
            }
        });
        $('.cart-cancel').off('click').on('click', function (e) {
            e.preventDefault();
            if (confirm("Bạn muốn xóa sản phẩm này?")) {
                $.ajax({
                    data: { id: $(this).data('id') },
                    url: '/Cart/Delete',
                    dataType: 'json',
                    type: 'POST',
                    success: function (res) {
                        if (res.status == true) {
                            window.location.href = "/";
                        }
                        else {

                        }
                    }
                })
            } 
        });
        $('.minus').off('click').on('click', function (e) {
            e.preventDefault();
            var t = $('#pro-qunt').val();
            if (t > 1) {
                $('#pro-qunt').val(t - 1);
            } 
        });
        $('.plus').off('click').on('click', function (e) {
            e.preventDefault();
            var t = $('#pro-qunt').val();
            if (t < 10) {
                $('#pro-qunt').val(parseInt(t) + 1);
            }
           
        });
        
    }
}
cart.init();