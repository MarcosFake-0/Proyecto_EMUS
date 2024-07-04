var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {

    dataTable = $('#tblData').DataTable({
        ajax: {
            "url": "/Medicine/Patient/GetAllPatients"

        },
        "columns": [
            { "data": "id", "width": "15%" },
            { "data": "firstName", "width": "15%" },
            { "data": "lastName", "width": "15%" },
            { "data": "lastAttendDate", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <a href="/Medicine/Patient/MedicalRecord/${data}" class="btn btn-primary mx-2">
                                <i class="bi bi-pencil-square"></i> Ver expediente
                            </a>
                          `
                }
            }
        ]
    });
}
