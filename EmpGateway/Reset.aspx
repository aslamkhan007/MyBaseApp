<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="Reset.aspx.vb" Inherits="Reset" Title="Reset" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td colspan="3" class="tableheader">
                <asp:Label ID="Label1" runat="server" Text="Reset Password" Width="99px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells" colspan="2">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                    BorderWidth="1px" CssClass="combobox" Height="28px" RepeatDirection="Horizontal"
                    TextAlign="Left" Width="193px">
                    <asp:ListItem Value="0">Salary Code</asp:ListItem>
                    <asp:ListItem Value="1">Card Number</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td rowspan="6"  class="labelcells" >
                <asp:Image ID="PictureBox1" runat="server" BorderStyle="None" Height="90%" ImageAlign="Middle"
                    ImageUrl="Image/2.JPG" Width="167px" />
            </td>
        </tr>
        <tr>
            <td  class="labelcells" style="width: 102px" valign="top">
                <asp:Label ID="Label3" runat="server" Text="Salary Code/Card No." Width="123px"></asp:Label>
            </td>
            <td  class="textcells" valign="top">
                <asp:TextBox ID="Card" runat="server" Width="188px" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 102px" valign="top">
                <asp:Label ID="Label2" runat="server" Font-Names="Tahoma" Font-Size="8pt" ForeColor="#404040"
                    Text="Employee Name" Width="94px"></asp:Label>
            </td>
            <td class="textcells" valign="top">
                <asp:TextBox ID="Name" runat="server" Width="188px" Font-Names="Tahoma"
                    Font-Size="8pt" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td
                valign="middle" class="labelcells" style="width: 102px">
                <asp:Label ID="Label4" runat="server" Font-Names="Tahoma" Font-Size="8pt" ForeColor="#404040"
                    Text="Initial Password" Width="93px"></asp:Label>
            </td>
            <td valign="top">
                <asp:TextBox ID="Password" runat="server" Width="188px"
                    CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr><td colspan="2" class="buttonbackbar" valign="top">
                <asp:Button ID="BtnGet" runat="server" Text="Get" CssClass="ButtonBack" BackColor="Black" /><asp:Button ID="BtnReset"
                    runat="server" Text="Reset" CssClass="ButtonBack" BackColor="Black" />
                <asp:Button ID="BtnClear" runat="server" Text="Clear" CssClass="ButtonBack" BackColor="Black"/>
                
            </td>
        </tr>
        <tr>
            <td colspan="2" >
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
