﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddForm.aspx.cs" Inherits="WoW_Toons.AddForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        div.header 
        {
            background-color:black;
            height:45px;
            padding-top:0px;
            padding-left:0px;
            padding-right:0px;
        }
        div.menu
        {
            background-color:bisque;
            top:50px;
            left:45px;
            height: 800px;
            width:150px;
            padding-top:5px;
            padding-left:10px;
        }
        div.main 
        {
            background-color:lightblue;
            margin-left:155px;
            margin-top:-182px;
            width:1738px;
            height: 800px;
            padding-top:20px;
            padding-left:20px;
        }
        table.center 
        {
            margin-left:auto; 
            margin-right:auto;
        }
        h1 { text-align:center; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header"></div>
        <div>
            <h1>WoW Toon Services</h1>
        </div>
        <div class="menu">
            <asp:LinkButton ID="lnkViewToons" runat="server" Font-Underline="False" Font-Size="Large" OnClick="lnkViewToons_Click">View Toons</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="lnkUpdateToons" runat="server" Font-Underline="False" Font-Size="Large" OnClick="lnkUpdateToons_Click">Update Toons</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="lnkAddToon" runat="server" Font-Underline="False" Font-Size="Large">Add Toon</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="lnkDeleteToon" runat="server" Font-Underline="False" Font-Size="Large" OnClick="lnkDeleteToon_Click">Delete Toon</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="lnkAdvSearch" runat="server" Font-Underline="False" Font-Size="Large" OnClick="lnkAdvSearch_Click">Advanced Search</asp:LinkButton>
            <div class="main">
                <table class="center">
                    <tr>
                        <td>Toon Name:</td>
                        <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox> </td>
                    </tr>
                    <tr>
                        <td>Server:</td>
                        <td><asp:TextBox ID="txtServer" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Faction:</td>
                        <td><asp:TextBox ID="txtFaction" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Race:</td>
                        <td><asp:TextBox ID="txtRace" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Class:</td>
                        <td><asp:TextBox ID="txtClass" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Level:</td>
                        <td><asp:TextBox ID="txtToonLevel" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Item Level:</td>
                        <td><asp:TextBox ID="txtItemLevel" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Gender:</td>
                        <td><asp:TextBox ID="txtGender" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Tank?:</td>
                        <td><asp:TextBox ID="txtCanTank" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Heal?:</td>
                        <td><asp:TextBox ID="txtCanHeal" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align:center"><asp:Label ID="lblMessage" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
