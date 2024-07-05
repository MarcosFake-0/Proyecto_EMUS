var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        ajax: {
            "url": "/Medicine/Treatment/getall"
        },
        "columns": [
            { "data": "name", "width": "25%" },
            { "data": "description", "width": "50%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="btn-group btn-lg">

                                <a href="/Medicine/Treatment/upsert/${data}" class="btn btn-primary btn-lg">
							    <i class="bi bi-pencil-square"></i></a>
                                <a onClick=Delete('${data}') class="btn btn-danger btn-lg"> 
							    <i class="bi bi-trash"></i></a>
                            </div>
                          `
                }
            }
        ]
    });
}

function Delete(_id) {
    Swal.fire({
        title: "¿Seguro desea eliminar?",
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
                url: "/Medicine/Treatment/delete/" + _id,
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