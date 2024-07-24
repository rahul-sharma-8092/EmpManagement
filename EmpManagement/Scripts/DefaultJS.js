$(document).ready(function () {
    $('#TxtSearch').attr("placeholder", "Search...");
});

function ddlAction_Changed(ddl, empId) {
    console.log("DDL :", ddl.value);
    console.log("EmpID :", empId);
    let selectedAction = ddl.value;
    $("#hdnEmpID").val('');

    if (selectedAction === "edit") {
        $("#hdnEmpID").val(empId);
        let URL = "/AddEditEmployee?id=" + empId + "&pagemode=edit";
        window.location.href = URL;
    }
    else if (selectedAction === "delete") {
        $("#hdnEmpID").val(empId);
        $("#BtnDelete").click();
    }
}

$('#TxtSearch').on("keypress", function (e) {
    if (e.which == 13) {
        $("#BtnSearch").click();
    }
})