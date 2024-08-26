<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Setup2FA.aspx.cs" Inherits="EmpManagement.Setup2FA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button Text="Setup 2FA" ID="btnSetup2FA" OnClick="btnSetup2FA_Click" runat="server" />
            <div>
                Scan QR Code
            </div>
            <div>
                <asp:Image ID="qrCodeImage" ImageUrl="" Visible="false" runat="server" />
            </div>
            <hr />

            <asp:TextBox ID="txtOTP" runat="server" />
            <asp:Label ID="resultLabel" Text="" runat="server" />
            <asp:Button Text="Verify" ID="btnVerify" OnClick="btnVerify_Click" runat="server" />
        </div>
    </form>
</body>
</html>
