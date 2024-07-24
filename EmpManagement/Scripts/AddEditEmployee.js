let _firstName = $('#FirstName').val();
let _lastName = $('#LastName').val();
let _email = $('#Email').val();
let _phone = $('#Phone').val();
let _hireDate = $('#HireDate').val();
let _position = $('#Position').val();
let _salary = $('#Salary').val();


function ValidateSalary(sender, args) {
    let salary = parseFloat(args.Value);
    if (isNaN(salary) || salary < 5000) {
        args.IsValid = false;
    } else {
        args.IsValid = true;
    }
}

function ValidateHireDate(sender, args) {
    console.log(args.Value);
    let hireDate = new Date(args.Value);
    let currentDate = new Date();

    hireDate.setHours(0, 0, 0, 0);
    currentDate.setHours(0, 0, 0, 0);

    if (hireDate > currentDate) {
        args.IsValid = false;
    } else {
        args.IsValid = true;
    }
}