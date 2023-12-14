let tableData;
let rowSelected;

const BASIC_MODEL = {
    idProduct: 0,
    cusCode: "",
    invoiceName: "",
    shortName: "",
    idBank: 0,
    phoneNo: "",
    mobile: "",
    openingBalance: "",
    debit: "",
    address: "",
    isActive: 1,
    photo: ""
}


$(document).ready(function () {

    //var i = 1;
    //function childrenRow() {
    //    i++;
    //    $('#childTable').find('tbody').append('<tr><th scope="row">' + i + '</th><td class="col-sm-4"><input type="text" name="name" class="form-control" /></td><td><input type="text" name="school" class="form-control" /></td><td class="col-sm-2"><input type="text" name="year" class="form-control" /></td><td class="col-sm-2"><input type="text" name="age" class="form-control" /></td><td><input type="button" class="btn btn-block btn-default" id="addrow" onclick="childrenRow()" value="+" /></td></tr>');
    //}
    fetch("/Setup/GetBanks")
        .then(response => {
            return response.ok ? response.json() : Promise.reject(response);
        }).then(responseJson => {
            if (responseJson.data.length > 0) {

                responseJson.data.forEach((item) => {
                    $("#cboBank").append(
                        // $("<option>").val(item.idBank).text(item.description)
                        //$("<option>").val("Bank not defined").text("Select Bank")
                        $("<option>").val(item.idCategory).text(item.description)
                    )
                });

            }
        })
    ///////////////////////////////////////////////////////////////////////////////////

    //$.ajax({
    //    url: '/Setup/GetProducts',
    //    type: 'GET',
    //    dataType: 'json',
    //    success: function (data) {
    //        $('#datatable-table').dataTable({
    //            "sAjaxDataProp": "",
    //            "bProcessing": true,
    //            "aaData": data,
    //            "aoColumnDefs": [
    //                { "mData": "id" },
    //                { "mData": "bandname" },
    //                { "mData": "members" },
    //                { "mData": "bio" },
    //                { "mData": "songlist" }
    //            ]
    //        });
    //    },
    //    error: function () { console.log('error retrieving customers'); }
    //});
    ///////////////////////////////////////////////////////////////////////////////////

    tableData = $("#tbData").DataTable({
        responsive: true,
        "ajax": {
            "url": "/Setup/GetCustomers",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "registrationDate" },
            { "data": "idProduct" },
            { "data": "cusCode" },
            { "data": "invoiceName" },
            { "data": "shortName" },
            { "data": "nameCategory" },
            //{ "data": "nameCategory" },
            { "data": "phoneNo" },
            { "data": "debit" },

            { "data": "openingBalance" },
            {
                "data": "photoBase64", render: function (data) {
                    if (data == null)
                        return '<p style="font-size:12px;">NoImage</p>';
                    else
                        return `<img style="height:60px;" src="data:image/png;base64,${data}" class="rounded mx-auto d-block" />`;
                }
            },


            {
                "defaultContent": '<button class="btn btn-primary btn-edit btn-sm mr-2"><i class="mdi mdi-pencil"></i></button>' +
                    '<button class="btn btn-danger btn-delete btn-sm"><i class="mdi mdi-trash-can"></i></button>',
                "orderable": false,
                "searchable": false,
                "width": "90px"
            },
            {
                "data": "isActive", render: function (data) {
                    if (data == 1)
                        return '<span class="badge badge-info">Active</span>';
                    else
                        return '<span class="badge badge-danger">Inactive</span>';
                }
            },
            { "data": "mobile" },


            { "data": "address" }
        ],
        order: [[0, "desc"]],
        dom: "Bfrtip",
        buttons: [
            {
                text: 'Export Excel',
                extend: 'excelHtml5',
                title: '',
                filename: 'Report Products',
                exportOptions: {
                    columns: [2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                }
            }, 'pageLength'
        ]
    });
})

var countSno = 0;
const openModal = (model = BASIC_MODEL) => {
    $("#childTable tr").remove();
    countSno = 0;
    $('#childTable').find('thead').append('<tr><th scope="col">No.</th><th scope="col">Name</th><th scope="col">Description</th><th scope="col">Quantity</th><th scope="col">Remarks</th><th scope=""></th></tr>');


    if (model.debit === null || model.debit === '') {
        childrenRow();
    }
    else {
        var noOfRows = model.debit.split("|");
        for (let i = 1; i < noOfRows.length; i++) {
            var value = noOfRows[i-1].replace("|", "");
            var array = value.split(";");
            countSno++;
            $('#childTable').find('tbody').append('<tr><th scope="row">' + countSno + '</th><td class="col-sm-4"><input type="text" name="name" class="form-control" value=' + array[1] + ' /></td><td><input type="text" name="school" class="form-control" value=' + array[2] + ' /></td><td class="col-sm-2"><input type="text" name="year" class="form-control" value=' + array[3] + ' /></td><td class="col-sm-2"><input type="text" name="age"  class="form-control" value=' + array[4] + ' /></td><td><input type="button" class="btn btn-block btn-default" id="addrow" onclick="childrenRow()" value="+" /></td></tr>');

        }
    }


    $("#txtId").val(model.idProduct);
    $("#txtCusCode").val(model.cusCode);
    $("#txtInvoice").val(model.invoiceName);
    $("#txtShortName").val(model.shortName);
    $("#cboBank").val(model.idBank == 0 ? $("#cboBank option:first").val() : model.idBank);
    $("#txtPhoneNo").val(model.phoneNo);
    $("#txtMobile").val(model.mobile);
    $("#txtOpenBalance").val(model.openingBalance);
    $("#txtDebit").val(model.debit);
    $("#txtAddress").val(model.address);
    $("#cboState").val(model.isActive);
    $("#txtPhoto").val("");
    $("#imgProduct").attr("src", `data:image/png;base64,${model.photoBase64}`);

    $("#modalData").modal("show")

}

$("#btnNewProduct").on("click", function () {
    openModal()
})

$("#btnSave").on("click", function () {

    ///////////////////////////
    let targetTable = document.getElementById('childTable');
    let targetTableRows = targetTable.rows;
    let tableHeaders = targetTableRows[0];
    let valWithName = '';
    let val = '';

    // start from the second row as the first one only contains the table's headers
    for (let i = 1; i < targetTableRows.length; i++) {
        // loop over the contents of each row
        for (let j = 0; j < targetTableRows[i].cells.length; j++) {
            // something we could use to identify a given item
            let currColumn = tableHeaders.cells[j].innerHTML;
            // the current <td> element
            let currData = targetTableRows[i].cells[j];
            // the input field in the row
            let currDataInput = currData.querySelector('input');

            // is the current <td> element containing an input field? print its value.
            // Otherwise, print whatever is insside
            if (!currData.innerHTML.includes("+")) {

                //currDataInput ? console.log(`${currColumn}: ${currDataInput.value}`)
                //    : console.log(`${currColumn}: ${currData.innerHTML}`);

                valWithName += currDataInput ? currColumn + ":" + currDataInput.value + ";"
                    : currColumn + ":" + currData.innerHTML + ";";

                val += currDataInput ? currDataInput.value + ";"
                    : currData.innerHTML + ";";
            }
            //console.log(`${currColumn}: ${currDataInput.value}`);
        }
        valWithName += "|";
        val += "|";
    }
    ///////////////////////////

    console.log(val);

    const inputs = $("input.input-validate").serializeArray();
    const inputs_without_value = inputs.filter((item) => item.value.trim() == "")

    if (inputs_without_value.length > 0) {
        const msg = `You must complete the field : "${inputs_without_value[0].name}"`;
        toastr.warning(msg, "");
        $(`input[name="${inputs_without_value[0].name}"]`).focus();
        return;
    }

    const model = structuredClone(BASIC_MODEL);
    model["idProduct"] = parseInt($("#txtId").val());
    model["cusCode"] = $("#txtCusCode").val();
    model["invoiceName"] = $("#txtInvoice").val();
    model["shortName"] = $("#txtShortName").val();
    model["idBank"] = $("#cboBank").val();
    model["phoneNo"] = $("#txtPhoneNo").val();
    model["mobile"] = $("#txtMobile").val();
    // model["openingBalance"] = $("#txtOpenBalance").val();
    model["openingBalance"] = valWithName;
    model["debit"] = val;
    // model["debit"] = $("#txtDebit").val();
    model["address"] = $("#txtAddress").val();
    model["isActive"] = $("#cboState").val();
    const inputPhoto = document.getElementById('txtPhoto');

    const formData = new FormData();
    //formData.append('photo', inputPhoto.files[0]);
    formData.append('model', JSON.stringify(model));

    $("#modalData").find("div.modal-content").LoadingOverlay("show")


    if (model.idProduct == 0) {
        fetch("/Setup/CreateCustomer", {
            method: "POST",
            body: formData
        }).then(response => {
            $("#modalData").find("div.modal-content").LoadingOverlay("hide")
            return response.ok ? response.json() : Promise.reject(response);
        }).then(responseJson => {

            if (responseJson.state) {

                tableData.row.add(responseJson.object).draw(false);
                $("#modalData").modal("hide");
                swal("Successful!", "The Customer was created", "success");

            } else {
                swal("We're sorry", responseJson.message, "error");
            }
        }).catch((error) => {
            $("#modalData").find("div.modal-content").LoadingOverlay("hide")
        })
    } else {

        fetch("/Setup/EditCustomer", {
            method: "PUT",
            body: formData
        }).then(response => {
            $("#modalData").find("div.modal-content").LoadingOverlay("hide")
            return response.ok ? response.json() : Promise.reject(response);
        }).then(responseJson => {
            if (responseJson.state) {

                tableData.row(rowSelected).data(responseJson.object).draw(false);
                rowSelected = null;
                $("#modalData").modal("hide");
                swal("Successful!", "The Customer was modified", "success");

            } else {
                swal("We're sorry", responseJson.message, "error");
            }
        }).catch((error) => {
            $("#modalData").find("div.modal-content").LoadingOverlay("hide")
        })
    }

})

$("#tbData tbody").on("click", ".btn-edit", function () {

    if ($(this).closest('tr').hasClass('child')) {
        rowSelected = $(this).closest('tr').prev();
    } else {
        rowSelected = $(this).closest('tr');
    }

    const data = tableData.row(rowSelected).data();

    openModal(data);
})



$("#tbData tbody").on("click", ".btn-delete", function () {


    let row;

    if ($(this).closest('tr').hasClass('child')) {
        row = $(this).closest('tr').prev();
    } else {
        row = $(this).closest('tr');
    }
    const data = tableData.row(row).data();

    swal({
        title: "¿Are you sure?",
        text: `Delete the Customer "${data.description}"`,
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Yes, delete",
        cancelButtonText: "No, cancel",
        closeOnConfirm: false,
        closeOnCancel: true
    },
        function (respuesta) {

            if (respuesta) {

                $(".showSweetAlert").LoadingOverlay("show")

                fetch(`/Setup/DeleteCustomer?IdProduct=${data.idProduct}`, {
                    method: "DELETE"
                }).then(response => {
                    $(".showSweetAlert").LoadingOverlay("hide")
                    return response.ok ? response.json() : Promise.reject(response);
                }).then(responseJson => {
                    if (responseJson.state) {

                        tableData.row(row).remove().draw();
                        swal("Successful!", "Customer was deleted", "success");

                    } else {
                        swal("We're sorry", responseJson.message, "error");
                    }
                })
                    .catch((error) => {
                        $(".showSweetAlert").LoadingOverlay("hide")
                    })
            }
        });
})


//$("#addrow").on("click", function () {
//    childrenRow();
//})

function childrenRow() {
    countSno++;
    $('#childTable').find('tbody').append('<tr><th scope="row">' + countSno + '</th><td class="col-sm-4"><input type="text" name="name" class="form-control" /></td><td><input type="text" name="school" class="form-control" /></td><td class="col-sm-2"><input type="text" name="year" class="form-control" /></td><td class="col-sm-2"><input type="text" name="age" class="form-control" /></td><td><input type="button" class="btn btn-block btn-default" id="addrow" onclick="childrenRow()" value="+" /></td></tr>');

}