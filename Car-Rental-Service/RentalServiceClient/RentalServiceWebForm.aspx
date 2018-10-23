﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RentalServiceWebForm.aspx.cs" Inherits="RentalServiceClient.RentalServiceWebForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form2 {
            height: 478px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <table style="font-family: Arial">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Font-Bold="true">reg number</asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Font-Bold="true">brand</asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Font-Bold="true">year</asp:Label>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Font-Bold="true">model</asp:Label>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="Add Car"
                        OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
