$(function () {
    //when click on filter button
    $('#FillterButton').click(function (e) {

        var id = $('#FillterData').selected().val(); //get value of select option
        window.location = "/Products/Index?id=" + id;  //to call index page with id
        console.log(id);
    });
    //var nnn = $('#FillterData').selected().val();
    //var l = abp.localization.getResource('ProductApp');
    //var dataTable = $('#ProductsTable').DataTable(
    //    abp.libs.datatables.normalizeConfiguration({
    //        serverSide: true,
    //        paging: true,
    //        retrieve: true,
    //        destroy: true,
    //        order: [[1, "asc"]],
    //        searching: true,
    //        scrollX: true,
    //        ajax: abp.libs.datatables.createAjax(acme.productApp.products.product.getList),
    //        columnDefs: [
    //            {
    //                title: l('Title'),
    //                data: "title"
    //            },
    //            {
    //                title: l('Description'),
    //                data: "description"
    //            },
    //            {
    //                title: l('Price'),
    //                data: "price"
    //            },
    //            {
    //                title: l('Category'),
    //                data: "categoryTitle",

    //            },
    //            {
    //                title: l('CreationTime'), data: "creationTime",
    //                render: function (data) {
    //                    return luxon
    //                        .DateTime
    //                        .fromISO(data, {
    //                            locale: abp.localization.currentCulture.name
    //                        }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
    //                }
    //            },
    //            {
    //                rowAction: {
    //                    items:
    //                        [
    //                            {
    //                                text: l('Edit'),
    //                                action: function (data) {
    //                                    var id = data.record.id
    //                                    window.location = "/Products/EditModal?id=" + id;

                                       
    //                                }
    //                            }
    //                        ]
    //                }
    //            },
    //            {
    //                rowAction: {
    //                    items:
    //                        [
    //                            {
    //                                text: l('Delete'),
    //                                confirmMessage: function (data) {
    //                                    return l(
    //                                        'ProductDeletionConfirmationMessage',
    //                                        data.record.name
    //                                    );
    //                                },
    //                                action: function (data) {
    //                                    acme.productApp.products.product
    //                                        .delete(data.record.id)
    //                                        .then(function () {
    //                                            abp.notify.info(
    //                                                l('SuccessfullyDeleted')
    //                                            );
    //                                            dataTable.ajax.reload();
    //                                        });
    //                                }
    //                            }
    //                        ]

    //                }
    //            }
    //        ]
    //    })
    //);

    

    

    

});
