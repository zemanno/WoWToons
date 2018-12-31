<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WoW.aspx.cs" Inherits="WoW_Toons.WoW" %>

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
            height: 1500px;
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
            height: 1500px;
            padding-top:20px;
            padding-left:20px;
        }
        h1 { text-align:center; }
        .grid
        {
            text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header"></div>
        <div>
            <h1>WoW Toon Services</h1>
        </div>
        <div class="menu">
            <asp:LinkButton ID="lnkViewToons" runat="server" Font-Underline="False" Font-Size="Large">View Toons</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="lnkUpdateToons" runat="server" Font-Underline="False" Font-Size="Large" OnClick="lnkUpdateToons_Click">Update Toons</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="lnkAddToon" runat="server" Font-Underline="False" Font-Size="Large" OnClick="lnkAddToon_Click">Add Toon</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="lnkDeleteToon" runat="server" Font-Underline="False" Font-Size="Large" OnClick="lnkDeleteToon_Click">Delete Toon</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="lnkAdvSearch" runat="server" Font-Underline="False" Font-Size="Large" OnClick="lnkAdvSearch_Click">Advanced Search</asp:LinkButton>
            <div class="main">
                <asp:GridView ID="gridToons" runat="server" CellPadding="5" CssClass="grid"></asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
