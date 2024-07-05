var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        ajax: {
            "url": "/Admin/Doctor/getall",
            "dataSrc": "data"
        },
        "columns": [
            {
                "data": "urlImage",
                "render": function (data) {
                    return `<img src="/images/doctors/${data}" alt="Imagen del Doctor" class="img-thumbnail" height="100px" width="110px" />`;
                },
                "width": "20%"
            },
            { "data": "firstName", "width": "15%" },
            { "data": "lastName", "width": "15%" },           
            { "data": "gmcNumber", "width": "20%"},
            {
                "data": "gmcNumber",
                "render": function (data) {
                    return `
                        <div class="btn-group btn-lg">

                                <a href="/Admin/Doctor/upsert/${data}" class="btn btn-primary btn-lg"> 
							    <i class="bi bi-pencil-square"></i></a>
                                <a onClick=Delete(${data}) class="btn btn-danger btn-lg"> 
							    <i class="bi bi-trash"></i></a>
                            </div>
                                `

                },
                "width": "30%"
            }
        ]
    });
}

function Delete(_id) {
    Swal.fire({
        title: `¿Seguro desea eliminar al doctor(a) ${_id}?`,
        text: "No podrá deshacer la acción",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Sí, eliminar",
        cancelButtonText: "Cancelar"
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                url: "/Admin/Doctor/deleteDoctor/" + _id,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                },
                error: function () {
                    toastr.error("Error connecting to endpoint");
                }
            });
        }
    });
}