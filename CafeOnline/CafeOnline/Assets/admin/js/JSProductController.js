var config = {
    page: 1,
    filter: ''
};
var productController = {
    init: function () {
        productController.loadData();
        productController.registerEvent();
    },
    registerEvent: function () {
        //change status
        $('.btn-status').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);

            var id = btn.data('id');
            var text = btn.text() === "Kích hoạt" ? "khóa" : "kích hoạt";
            bootbox.confirm({
                message: 'Bạn muốn ' + text + ' sản phẩm này?',
                size: 'small',
                title: 'Thông báo',
                callback: function (result) {
                    if (result) {
                        $.ajax({
                            type: 'POST',
                            url: '/Admin/Product/ChangeStatus',
                            data: { id: config.page },
                            dataType: 'json',
                            success: function (response) {
                                if (response) {
                                    btn.attr('class', 'label label-success');
                                    btn.text('Kích hoạt');
                                } else {
                                    btn.attr('class', 'label label-danger');
                                    btn.text('Khóa');
                                }
                            },
                            error: function (response) {
                                bootbox.alert({
                                    message: response.message,
                                    size: 'small'
                                });
                            }
                        });
                    }
                }
            });
        });

        //delete
        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);

            var id = btn.data('id');

            bootbox.confirm({
                message: 'Bạn muốn xóa sản phẩm này?',
                size: 'small',
                title: 'Thông báo',
                callback: function (result) {
                    if (result) {
                        $.ajax({
                            type: 'POST',
                            url: '/Admin/Product/Delete',
                            data: { id: id },
                            dataType: 'json',
                            success: function (response) {
                                if (response) {
                                    $('#row_' + id).remove();
                                }
                            },
                            error: function (response) {
                                bootbox.alert({
                                    message: response.message,
                                    size: 'small'
                                });
                            }
                        });
                    }
                }
            });
        });


    paging: function (totalPages, totalRows, callback) {
        $('#pagination').twbsPagination({
            first: 'Đầu',
            prev: 'Trước',
            last: 'Cuối',
            next: 'Tiếp',
            totalPages: totalPages,
            visiblePages: 5,
            onPageClick: function (event, page) {
                config.page = page;
                setTimeout(callback, 200);
            }
        });

        $('#totalRows').text(totalRows);
    }
};

productController.init();