<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TicTacToe.ascx.cs" Inherits="TicTacToe.TicTacToe" %>
<table border="1">
<tr>
<td>
    <asp:Button ID="r1c1" runat="server"  Width="50px" Height="35px" 
        onclick="r1c1_Click" Text=" " Font-Size="Large" />
    </td>
<td>
    <asp:Button ID="r1c2" runat="server" Width="50px" Height="35px" 
        onclick="r1c2_Click" Text=" " Font-Size="Large" />
    </td>
<td>
    <asp:Button ID="r1c3" runat="server"  Width="50px" Height="35px" 
        onclick="r1c3_Click" Text=" " Font-Size="Large" />
    </td>
</tr>
<tr>
<td>
    <asp:Button ID="r2c1" runat="server"  Width="50px" Height="35px" 
        onclick="r2c1_Click" Text=" " Font-Size="Large" />
    </td>
<td>
    <asp:Button ID="r2c2" runat="server"  Width="50px" Height="35px" 
        onclick="r2c2_Click" Text=" " Font-Size="Large" />
    </td>
<td>
    <asp:Button ID="r2c3" runat="server" Width="50px" Height="35px" 
        onclick="r2c3_Click" Text=" " Font-Size="Large" />
    </td>
</tr>
<tr>
<td>
    <asp:Button ID="r3c1" runat="server"  Width="50px" Height="35px" 
        onclick="r3c1_Click" Text=" " Font-Size="Large" />
    </td>
<td>
    <asp:Button ID="r3c2" runat="server" Width="50px" Height="35px" 
        onclick="r3c2_Click" Text=" " Font-Size="Large" />
    </td>
<td>
    <asp:Button ID="r3c3" runat="server"  Width="50px" Height="35px" 
        onclick="r3c3_Click" Text=" " Font-Size="Large" />
    </td>
</tr>
<tr>
<td colspan="3">
    &nbsp;</td>
</tr>
<tr>
<td colspan="3">
    <asp:Label ID="lblStatus" runat="server" Text="Status: "></asp:Label>
    </td>
</tr>
<tr>
<td>
    &nbsp;</td>
<td>
    &nbsp;</td>
<td>
    &nbsp;</td>
</tr>
<tr>
<td colspan="3">
    <asp:CheckBox ID="ChkFirst" runat="server" Text="Go first" />
    </td>
</tr>
<tr>
<td colspan="3">
&nbsp;
    &nbsp;
    &nbsp;
    <asp:Button ID="btnStart" runat="server" Text="Start" onclick="Button1_Click" />
    &nbsp;<asp:Label ID="lblSymbol" runat="server" Text="X" Visible="False"></asp:Label>
    &nbsp;<asp:Label ID="lblTurn" runat="server" Text="Turn:" Visible="False"></asp:Label>
    </td>
</tr>
</table>