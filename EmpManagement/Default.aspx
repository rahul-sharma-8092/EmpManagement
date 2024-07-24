<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmpManagement._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>

        <div>
            <div class="float-end">
                <asp:TextBox ID="TxtSearch" Text="" CssClass="px-2 mb-1" ClientIDMode="Static" CausesValidation="false" runat="server" />
            </div>
            <table class="table table-hover table-bordered">
                <asp:Repeater runat="server" ID="RptEmployee">
                    <HeaderTemplate>
                        <thead class="table-dark">
                            <tr>
                                <th class="d-none">EmpID</th>
                                <th>FirstName</th>
                                <th>LastName</th>
                                <th>Email</th>
                                <th class="text-center">Phone</th>
                                <th class="text-center">HireDate</th>
                                <th>Position</th>
                                <th>Salary</th>
                                <th class="text-center">Action</th>
                            </tr>
                        </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td class="d-none">
                                <%# Eval("EmpID") %>
                            </td>
                            <td>
                                <%# Eval("FirstName") %>
                            </td>
                            <td>
                                <%# Eval("LastName") %>
                            </td>
                            <td>
                                <%# Eval("Email") %>
                            </td>
                            <td class="text-center">
                                <%# Eval("Phone") %>
                            </td>
                            <td class="text-center">
                                <%# Convert.ToDateTime(Eval("HireDate")).ToString("dd-MM-yyyy") %>
                            </td>
                            <td>
                                <%# Eval("Position") %>
                            </td>
                            <td>
                                <%# Eval("Salary") %>
                            </td>
                            <td class="text-center">
                                <select onchange="ddlAction_Changed(this, '<%# Eval("EmpID") %>')">
                                    <option value="">Action</option>
                                    <option value="edit">Edit</option>
                                    <option value="delete">Delete</option>
                                </select>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tfoot>
                    <tr>
                        <td id="SpnNoRecord" runat="server" colspan="8" class="text-danger text-xl-center fw-bold">No Employees Found</td>
                    </tr>
                </tfoot>
            </table>
            <div class="d-flex align-items-center gap-3">
                <div>
                    PageSize:
                            <asp:DropDownList ID="ddlPageSize" runat="server" ClientIDMode="Static" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="5" Value="5" Selected="True" />
                                <asp:ListItem Text="7" Value="7" />
                                <asp:ListItem Text="12" Value="12" />
                                <asp:ListItem Text="15" Value="15" />
                                <asp:ListItem Text="50" Value="50" />
                                <asp:ListItem Text="100" Value="100" />
                            </asp:DropDownList>
                </div>
                <div>
                    <asp:Repeater runat="server" ID="PageRepeater">
                        <ItemTemplate>
                            <asp:Button ID="BtnPagination" Text='<%# Eval("Text") %>' OnClick="BtnPagination_Click" Enabled='<%# Eval("Enabled") %>' runat="server" CommandArgument='<%# Eval("Value") %>' />
                        </ItemTemplate>
                    </asp:Repeater>
                    <span>Total Rows: <span id="rowsCount" runat="server" class="fw-bold"></span></span>
                </div>
            </div>
        </div>

        <asp:HiddenField ID="hdnEmpID" runat="server" Value="" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnPageSize" runat="server" Value="5" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnPageIndex" runat="server" Value="1" ClientIDMode="Static" />
        <asp:Button ID="BtnDelete" CssClass="d-none" runat="server" OnClick="BtnDelete_Click" ClientIDMode="Static" />
        <asp:Button ID="BtnSearch" CssClass="d-none" runat="server" OnClick="BtnSearch_Click" ClientIDMode="Static" />
    </main>
    <script src="/Scripts/DefaultJS.js"></script>
</asp:Content>
