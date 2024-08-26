<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpListReport.aspx.cs" Inherits="EmpManagement.Reports.EmpListReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #ReportEmpListViwer{
            margin: 0px auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportEmpListViwer" runat="server" CssClass="m-auto"></rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
