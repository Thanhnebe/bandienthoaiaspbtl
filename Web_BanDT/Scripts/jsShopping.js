$(document).ready(function () {
    ShowCount();
    $('body').on('click', '.btnAddToCart', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var quatity = 1;
        var tQuantity = $('#quantity_value').text();
        if (tQuantity != '') {
            quatity = parseInt(tQuantity);
        }
        //alert(id + " " + quatity);
        //Ajax:gửi và nhận dữ liệu từ máy chủ mà không cần tải lại trang web
        //cho phép trang web tương tác với máy chủ một cách bất đồng bộ và cập nhật nội dung trang mà không gây làm mất dữ liệu người dùng
        $.ajax({
            url: '/ShoppingCart/ThemGioHang',
            type: 'POST',
            data: { id: id, quantity: quatity },
            success: function (rs) {
                if (rs.Success) {
                    $('#checkout_items').html(rs.Count);
                    alert(rs.msg);
                }
            }
        });
    });
    $('body').on('click', '.btnDelete', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var conf = confirm('Bạn có đồng ý xóa sản phẩm này khỏi giỏ hàng ?');
        if (conf == true) {
            $.ajax({
                url: '/ShoppingCart/DeleteSP',
                type: 'POST',
                data: { id: id },
                success: function (rs) {
                    if (rs.Success) {
                        $('#checkout_items').html(rs.Count);
                        $('#trow_' + id).remove();
                        LoadCart();
                    }
                }
            });
        }
    });

    $('body').on('click', '.btnUpdate', function (e) {
        e.preventDefault();
        debugger;
        var id = $(this).data("id");
        var quantity = $('#Quantity_'+id).val();
        upDate(id, quantity);

    });

  

});
// dùng để load lại giỏ hàng
function LoadCart() {
    $.ajax({
        url: '/ShoppingCart/GioHang',
        type: 'GET',
        success: function (rs) {
            $('#load_data').html(rs);
        }
    });
}


function ShowCount() {
    //Nó vẫn lưu lại, nhưng khi load lại không hiện thị
    $.ajax({
        url: '/ShoppingCart/ShowCount',
        type: 'GET',
        //success: lưu kết quả khi chạy thành công
        success: function (rs) {
            $('#checkout_items').html(rs.Count);
        }
    });
}
function upDate(id, quantity) {
    debugger;
    $.ajax({
        url: '/ShoppingCart/Update',
        type: 'POST',
        data: { id: id, quantity: quantity },
       
        success: function (rs) {
            if (rs.Success) {
                LoadCart();
            }
        }
    });
}
