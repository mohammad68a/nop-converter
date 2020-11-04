var productIds = [];
$(function () {
    $("#button-create").click(function () {
        if (productIds.length == 0) {
            alert("محصولی انتخاب نشده است!")
            return;
        }
        $("#modal-submit").html("ایجاد محصول");

        $.post("/products/select", { productIds }, function (partial) {
            $("#modal .modal-title").html("تایید انتخاب محصولات");
            $("#modal .modal-body").html(partial);
            $("#modal").modal();
        })
    })

    $("#modal-submit").click(function () {

        // Get all products
        var products = [];
        var specificProductIds = [];
        $('.product-row').each(function () {
            var el = $(this);
            products.push({
                productId: parseInt(el.find('input:hidden').val()),
                colorName: el.find('input[name="inputName"]').val(),
                skuCode: el.find('input[name="inputSku"]').val(),
            })
            specificProductIds.push(parseInt(el.find('input:hidden').val()))
        });

        // Get main product
        var mainItem = $("#modal input:checked");
        if (!mainItem.length) {
            Swal.fire('خطا', 'محصول اصلی انتخاب نشده است!', 'warning');
            return;
        }
        var primaryId = parseInt(mainItem.attr("data-id"));
        
        $.ajax({
            type: "POST",
            url: "/products/create",
            data: {
                specificProducts: products,
                masterProductId: primaryId,
                masterProductNewSku: $("#inputMasterNewSku").val(),
                masterProductNewName: $("#inputMasterNewName").val(),
            },
            beforeSend: function () {
                $("#modal-buttons").hide();
                $("#modal-sending").show();
                $("#modal button.close").hide();
            },
            error: function (e) {
                console.log(e)
                Swal.fire('خطا', e.responseText, 'error')
            },
            success: function (res) {
                var link = '<a href="' + res.baseUrl + '/Admin/Product/Edit/' + res.newProductId + '" target="_blank">' + res.newProductId + '</a>';
                Swal.fire({
                    title: 'تایید میشود؟',
                    text: 'محصول جدید با کد ' + link + ' ایجاد گردید.',
                    icon: 'question',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'تایید محصول جدید',
                    cancelButtonText: 'انصراف'
                }).then((result) => {
                    if (result.isConfirmed) {
                        $.post("/products/confirm", { specificProductIds: selectedProductIds, newProductId: newProductId }, function () {
                            Swal.fire('موفقیت آمیز!', 'محصول با موفقیت تایید گردید!', 'success')
                        })
                    }
                })
            },
            complete: function () {
                $("#modal").modal('toggle');
                $("#modal-buttons").show();
                $("#modal-sending").hide();
                $("#modal button.close").show();
            }
        });
    })
})

function onChange(e) {
    productIds = this.selectedKeyNames().map(x => Number.parseInt(x, 10));
    checkproductIds();
}

function checkproductIds() {
    if (productIds.length === 0) {
        $("#button-create").addClass("disabled");
    }
    else {
        $("#button-create").removeClass("disabled");
    }
}

function switchPrimary(rowIndex, productId) {
    var primarySku = $("input[name='inputSku']").eq(rowIndex).val();
    var primaryName = $("input[name='inputName']").eq(rowIndex).val();
    $("#modal #inputMasterNewSku").val(primarySku);
    $("#modal #inputMasterNewName").val(primaryName);
}