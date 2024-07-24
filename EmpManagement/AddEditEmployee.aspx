<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEditEmployee.aspx.cs" Inherits="EmpManagement.AddEditEmployee" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="w-100 m-auto">
        <div class="w-50 m-auto">
            <div class="mb-2">
                <asp:Label Text="First Name:" runat="server" CssClass="form-label fw-bold" AssociatedControlID="FirstName" />
                <asp:TextBox ID="FirstName" runat="server" ClientIDMode="Static" TabIndex="1" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="First Name is required" ControlToValidate="FirstName" runat="server" CssClass="text-danger" />
                <asp:RegularExpressionValidator ErrorMessage="Invalid first name" ControlToValidate="FirstName" runat="server" ValidationExpression="^[a-zA-Z]{3,50}$" CssClass="text-danger" />
            </div>
            <div class="mb-2">
                <asp:Label Text="Last Name:" runat="server" CssClass="form-label fw-bold" AssociatedControlID="LastName" />
                <asp:TextBox ID="LastName" runat="server" ClientIDMode="Static" TabIndex="2" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="Last Name is required" ControlToValidate="LastName" runat="server" CssClass="text-danger" />
                <asp:RegularExpressionValidator ErrorMessage="Invalid last name" ControlToValidate="LastName" runat="server" ValidationExpression="^[a-zA-Z]{3,50}$" CssClass="text-danger" />
            </div>
            <div class="mb-2">
                <asp:Label Text="Email:" runat="server" CssClass="form-label fw-bold" AssociatedControlID="Email" />
                <asp:TextBox ID="Email" runat="server" ClientIDMode="Static" TabIndex="3" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="Email is required" ControlToValidate="Email" runat="server" CssClass="text-danger" />
                <asp:RegularExpressionValidator ErrorMessage="Invalid Email" ControlToValidate="Email" runat="server" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" CssClass="text-danger" />
            </div>
            <div class="mb-2">
                <asp:Label Text="Phone Number:" runat="server" CssClass="form-label fw-bold" AssociatedControlID="Phone" />
                <asp:TextBox ID="Phone" runat="server" ClientIDMode="Static" TextMode="Phone" TabIndex="4" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="Phone number is required" ControlToValidate="Phone" runat="server" CssClass="text-danger" />
                <asp:RegularExpressionValidator ErrorMessage="Invalid Phone number..[Must be at 10 digits]" ControlToValidate="Phone" runat="server" ValidationExpression="^[0-9]{10,10}$" CssClass="text-danger" />
            </div>
            <div class="mb-2">
                <asp:Label Text="Hire Date:" runat="server" CssClass="form-label fw-bold" AssociatedControlID="HireDate" />
                <asp:TextBox ID="HireDate" runat="server" TextMode="Date" ClientIDMode="Static" TabIndex="5" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="Hire Date is required" ControlToValidate="HireDate" runat="server" CssClass="text-danger" />
                <asp:CustomValidator ErrorMessage="Hire date cannot be a future date" ControlToValidate="HireDate" ClientValidationFunction="ValidateHireDate" runat="server" CssClass="text-danger"/>
            </div>
            <div class="mb-2">
                <asp:Label Text="Position:" runat="server" CssClass="form-label fw-bold" AssociatedControlID="Position" />
                <asp:TextBox ID="Position" runat="server" ClientIDMode="Static" TabIndex="6" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="Position is required" ControlToValidate="Position" runat="server" CssClass="text-danger" />
                <asp:RegularExpressionValidator ErrorMessage="Invalid Position" ControlToValidate="Position" runat="server" ValidationExpression="^[a-zA-Z. -]{1,50}$" CssClass="text-danger" />
            </div>
            <div class="mb-2">
                <asp:Label Text="Salary:" runat="server" CssClass="form-label fw-bold" AssociatedControlID="Salary" />
                <asp:TextBox ID="Salary" runat="server" ClientIDMode="Static" TabIndex="7" CssClass="form-control" TextMode="Phone"/>
                <asp:RequiredFieldValidator ErrorMessage="Salary is required" ControlToValidate="Salary" runat="server" CssClass="text-danger" />
                <asp:CustomValidator ErrorMessage="Invalid Salary. [Must bu greater than than or eqal to 5000]" ControlToValidate="Salary" runat="server" ClientValidationFunction="ValidateSalary" CssClass="text-danger"/>
            </div>
            <div class="mb-2">
                <asp:Button ID="BtnSave" Text="Save" runat="server" OnClick="BtnSave_Click" CssClass="btn btn-success" Width="75px" />
                <asp:Button ID="BtnCancel" Text="Cancel" runat="server" OnClick="BtnCancel_Click" CssClass="btn btn-danger" Width="75px" CausesValidation="false" />
                <asp:Button ID="BtnEdit" Text="Edit" runat="server" OnClick="BtnEdit_Click" CausesValidation="false" CssClass="btn btn-info" Width="75px" />
            </div>
        </div>
        <asp:HiddenField ID="hdnEmpID" Value="0" ClientIDMode="Static" runat="server" />
    </main>
    <link href="/Content/AddEditEmployee.css" rel="stylesheet" />
    <script src="/Scripts/AddEditEmployee.js"></script>
</asp:Content>
