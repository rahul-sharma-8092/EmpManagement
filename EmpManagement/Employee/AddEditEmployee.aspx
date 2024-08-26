<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEditEmployee.aspx.cs" Inherits="EmpManagement.Employee.AddEditEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <main>
        <form id="form1" runat="server">
            <div class="w-50 m-auto">
                <div class="mb-2">
                    <asp:Label Text="First Name:" runat="server" CssClass="form-label fw-bold" AssociatedControlID="FirstName" />
                    <asp:TextBox ID="FirstName" runat="server" ClientIDMode="Static" TabIndex="1" CssClass="form-control" />
                    <span id="reqFirstName" class="text-danger dnone">First name is required.</span>
                    <span id="regFirstName" class="text-danger dnone">First name only contains alphabet letter.</span>
                </div>
                <div class="mb-2">
                    <asp:Label Text="Last Name:" runat="server" CssClass="form-label fw-bold" AssociatedControlID="LastName" />
                    <asp:TextBox ID="LastName" runat="server" ClientIDMode="Static" TabIndex="2" CssClass="form-control" />
                    <span id="reqLastName" class="text-danger dnone">Last name is required.</span>
                    <span id="regLastName" class="text-danger dnone">Last name only contains alphabet letter.</span>
                </div>
                <div class="mb-2">
                    <asp:Label Text="Email:" runat="server" CssClass="form-label fw-bold" AssociatedControlID="Email" />
                    <asp:TextBox ID="Email" runat="server" ClientIDMode="Static" TabIndex="3" CssClass="form-control" />
                    <span id="reqEmail" class="text-danger dnone">Email ID is required.</span>
                    <span id="regEmail" class="text-danger dnone">Email ID is Invalid.</span>
                </div>
                <div class="mb-2">
                    <asp:Label Text="Phone Number:" runat="server" CssClass="form-label fw-bold" AssociatedControlID="Phone" />
                    <asp:TextBox ID="Phone" runat="server" ClientIDMode="Static" TextMode="Phone" TabIndex="4" CssClass="form-control" />
                    <span id="reqPhone" class="text-danger dnone">Phone number is required.</span>
                    <span id="regPhone" class="text-danger dnone">Phone number must be of 10 digits.</span>
                </div>
                <div class="mb-2">
                    <asp:Label Text="Hire Date:" runat="server" CssClass="form-label fw-bold" AssociatedControlID="HireDate" />
                    <asp:TextBox ID="HireDate" runat="server" TextMode="Date" ClientIDMode="Static" TabIndex="5" CssClass="form-control" />
                    <span id="reqHireDate" class="text-danger dnone">Hire date is required.</span>
                    <span id="regHireDate" class="text-danger dnone">Hire Date can not be a future date.</span>
                </div>
                <div class="mb-2">
                    <asp:Label Text="Position:" runat="server" CssClass="form-label fw-bold" AssociatedControlID="Position" />
                    <asp:TextBox ID="Position" runat="server" ClientIDMode="Static" TabIndex="6" CssClass="form-control" />
                    <span id="reqPosition" class="text-danger dnone">Position is required.</span>
                    <span id="regPosition" class="text-danger dnone">Positions only contains alphabet letter.</span>
                </div>
                <div class="mb-2">
                    <asp:Label Text="Salary:" runat="server" CssClass="form-label fw-bold" AssociatedControlID="Salary" />
                    <asp:TextBox ID="Salary" runat="server" ClientIDMode="Static" TabIndex="7" CssClass="form-control" TextMode="Phone" />
                    <span id="reqSalary" class="text-danger dnone">Salary is required.</span>
                    <span id="regSalary" class="text-danger dnone">Salary must be a decimal.</span>
                </div>
                <div class="mb-2">
                    <asp:Button ID="BtnSave" Text="Save" runat="server" CssClass="btn btn-success" Width="75px" ClientIDMode="Static"/>
                    <asp:Button ID="BtnCancel" Text="Cancel" UseSubmitBehavior="false" runat="server" CssClass="btn btn-danger" Width="75px" ClientIDMode="Static"/>
                    <asp:Button ID="BtnEdit" Text="Edit" runat="server" UseSubmitBehavior="false" CssClass="btn btn-info" Width="75px" ClientIDMode="Static"/>
                </div>
            </div>
        </form>
    </main>
    <%: System.Web.Optimization.Styles.Render("~/bundles/JqueryBootstrapCSS") %>
    <%: System.Web.Optimization.Scripts.Render("~/bundles/JqueryJS") %>
    <link href="Css/AddEditEmployeeCss.css" rel="stylesheet" />
    <script src="./Js/AddEditEmployee.js" type="text/javascript"></script>
</body>
</html>
