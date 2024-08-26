let firstname, lastname, email, phone, hiredate, position, salary;

function GetFormDetails() {
    firstname = $("#FirstName").val();
    lastname = $("#LastName").val();
    email = $("#Email").val();
    phone = $("#Phone").val();
    hiredate = $("#HireDate").val();
    position = $("#Position").val();
    salary = $("#Salary").val();
}
function ReqFieldValidation() {
    let IsValid = true;
    GetFormDetails();

    const nameRegex = /^[a-zA-Z ]{2,100}$/;
    const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    const phoneRegex = /^[0-9 ]{10}$/;
    const salaryRegex = /^\d+(\.\d{1,2})?$/;
    const positionRegex = /^[a-zA-Z- ]{2,100}$/;

    //First-Name
    if (firstname == "") {
        $("#reqFirstName").show();
        $("#regFirstName").hide();
        IsValid = false;
    }
    else if (!nameRegex.test(firstname)) {
        $("#regFirstName").show();
        $("#reqFirstName").hide();
        IsValid = false;
    }
    else {
        $("#reqFirstName").hide();
        $("#regFirstName").hide();
    }

    //Last-Name
    if (lastname == "") {
        $("#reqLastName").show();
        $("#regLastName").hide();
        IsValid = false;
    }
    else if (!nameRegex.test(lastname)) {
        $("#regLastName").show();
        $("#reqLastName").hide();
        IsValid = false;
    }
    else {
        $("#reqLastName").hide();
        $("#regLastName").hide();
    }

    //Email-ID
    if (email == "") {
        $("#reqEmail").show();
        $("#regEmail").hide();
        IsValid = false;
    }
    else if (!emailRegex.test(email)) {
        $("#regEmail").show();
        $("#reqEmail").hide();
        IsValid = false;
    }
    else {
        $("#reqEmail").hide();
        $("#regEmail").hide();
    }

    //Phone-Number
    if (phone == "") {
        $("#reqPhone").show();
        $("#regPhone").hide();
        IsValid = false;
    }
    else if (!phoneRegex.test(phone)) {
        $("#regPhone").show();
        $("#reqPhone").hide();
        IsValid = false;
    }
    else {
        $("#reqPhone").hide();
        $("#regPhone").hide();
    }

    //Hire-Date
    if (hiredate == "") {
        $("#reqHireDate").show();
        $("#regHireDate").hide();
        IsValid = false;
    }
    else {
        const currentDate = new Date();
        const hireDate1 = new Date(hiredate);

        if (hireDate1 > currentDate) {
            $("#regHireDate").show();
            $("#reqHireDate").hide();
            IsValid = false;
        }
        else {
            $("#regHireDate").hide();
            $("#reqHireDate").hide();
        }
    }

    //Positions
    if (position == "") {
        $("#reqPosition").show();
        $("#regPosition").hide();
        IsValid = false;
    }
    else if (!positionRegex.test(position)) {
        $("#regPosition").show();
        $("#reqPosition").hide();
        IsValid = false;
    }
    else {
        $("#reqPosition").hide();
        $("#regPosition").hide();
    }

    //Salary
    if (salary == "") {
        $("#reqSalary").show();
        $("#regSalary").hide();
        IsValid = false;
    }
    else if (!salaryRegex.test(salary)) {
        $("#regSalary").show();
        $("#reqSalary").hide();
        IsValid = false;
    }
    else {
        $("#regSalary").hide();
        $("#reqSalary").hide();
    }

    if (salary.includes('.')) {
        const parts = salary.split('.');
        if (parts[0] === '' || parts[1] === '') {
            $("#regSalary").show();
            $("#reqSalary").hide();
            IsValid = false;
        }
    }
    else {
        $("#regSalary").hide();
    }
    return IsValid;
}

$("#form1").on("submit", function (e) {
    e.preventDefault();
    const IsFormValid = ReqFieldValidation();

    let formData = {
        FirstName: firstname, LastName: lastname, Email: email, Phone: phone, HireDate: hiredate, Position: position, Salary: salary
    }

    if (IsFormValid) {
        $.ajax({
            type: "POST",
            url: "AddEditEmployee.aspx/SaveEmployee",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(formData),
            success: function (response) {
                console.log(JSON.parse(response));
            },
            error: function (err) {
                console.log(err);
            }
        })
    }
})