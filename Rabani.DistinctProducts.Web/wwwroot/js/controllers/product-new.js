$(document).ready(function () {
    $('table').DataTable({
        "pageLength": 25,
        language: {
            "sEmptyTable": "هیچ داده‌ای در جدول وجود ندارد",
            "sInfo": "نمایش _START_ تا _END_ از _TOTAL_ ردیف",
            "sInfoEmpty": "نمایش 0 تا 0 از 0 ردیف",
            "sInfoFiltered": "(فیلتر شده از _MAX_ ردیف)",
            "sInfoPostFix": "",
            "sInfoThousands": ",",
            "sLengthMenu": "نمایش _MENU_ ردیف",
            "sLoadingRecords": "در حال بارگزاری...",
            "sProcessing": "در حال پردازش...",
            "sSearch": "جستجو:",
            "sZeroRecords": "رکوردی با این مشخصات پیدا نشد",
            "oPaginate": {
                "sFirst": "برگه‌ی نخست",
                "sLast": "برگه‌ی آخر",
                "sNext": "بعدی",
                "sPrevious": "قبلی"
            },
            "oAria": {
                "sSortAscending": ": فعال سازی نمایش به صورت صعودی",
                "sSortDescending": ": فعال سازی نمایش به صورت نزولی"
            }
        }
    });
});

$("button[name='buttonConfirm']").click(function () {
    var element = $(this);
    Swal.fire({
        icon: 'question',
        showDenyButton: true,
        showCancelButton: false,
        denyButtonText: `انصراف`,
        confirmButtonText: `بله، تایید میشود`,
        text: 'آیا جهت تایید فایل اطمینان دارید؟',
    }).then((result) => {
        if (result.isConfirmed) {
            $.post("/products/confirm", { csvFileName: element.attr("data-csv"), isPublish: true }, function () {
                element.remove();
                Swal.fire('موفقیت آمیز', 'تایید محصول جدید جهت نمایش انجام گردید', 'success');
            })
        }
    })
})