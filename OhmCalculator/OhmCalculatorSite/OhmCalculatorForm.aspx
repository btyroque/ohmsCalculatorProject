<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OhmCalculatorForm.aspx.cs" Inherits="OhmCalculatorForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>Select the color of each band on the resistor:</p>
            <asp:DropDownList ID="bandAColorList" runat="server">
                <asp:ListItem>Brown</asp:ListItem>
                <asp:ListItem>Red</asp:ListItem>
                <asp:ListItem>Orange</asp:ListItem>
                <asp:ListItem>Yellow</asp:ListItem>
                <asp:ListItem>Green</asp:ListItem>
                <asp:ListItem>Blue</asp:ListItem>
                <asp:ListItem>Violet</asp:ListItem>
                <asp:ListItem>Grey</asp:ListItem>
                <asp:ListItem>White</asp:ListItem>
                <asp:ListItem>None</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="bandBColorList" runat="server" OnSelectedIndexChanged="bandBColorList_SelectedIndexChanged">
                <asp:ListItem>Black</asp:ListItem>
                <asp:ListItem>Brown</asp:ListItem>
                <asp:ListItem>Red</asp:ListItem>
                <asp:ListItem>Orange</asp:ListItem>
                <asp:ListItem>Yellow</asp:ListItem>
                <asp:ListItem>Green</asp:ListItem>
                <asp:ListItem>Blue</asp:ListItem>
                <asp:ListItem>Violet</asp:ListItem>
                <asp:ListItem>Grey</asp:ListItem>
                <asp:ListItem>White</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="MultiplierBandColorList" runat="server" OnSelectedIndexChanged="bandBColorList_SelectedIndexChanged">
                <asp:ListItem>Black</asp:ListItem>
                <asp:ListItem>Brown</asp:ListItem>
                <asp:ListItem>Red</asp:ListItem>
                <asp:ListItem>Orange</asp:ListItem>
                <asp:ListItem>Yellow</asp:ListItem>
                <asp:ListItem>Green</asp:ListItem>
                <asp:ListItem>Blue</asp:ListItem>
                <asp:ListItem>Violet</asp:ListItem>
                <asp:ListItem>None</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ToleranceBandColorList" runat="server" OnSelectedIndexChanged="bandBColorList_SelectedIndexChanged">
                <asp:ListItem>Brown</asp:ListItem>
                <asp:ListItem>Red</asp:ListItem>
                <asp:ListItem>Green</asp:ListItem>
                <asp:ListItem>Gold</asp:ListItem>
                <asp:ListItem>Silver</asp:ListItem>
                <asp:ListItem>None</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="calculateButton" runat="server" Text="Calculate" OnClick="calculateButton_Click" />
            <br />
            <br />
            <asp:Label ID="ResultLabel" runat="server" Text="Resistor Value:"></asp:Label>
            
        </div>
    </form>
</body>
</html>
