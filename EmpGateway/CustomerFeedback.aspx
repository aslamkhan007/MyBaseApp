<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="CustomerFeedback.aspx.vb" Inherits="CustomerFeedback" Title="Customer Feedback " %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td colspan="3" class="tableheader">
                &nbsp;<asp:Label ID="Label6" runat="server" Text="History" Width="104px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label1" runat="server" Text="Customer Code"
                    Width="96px"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="txtCustCode" runat="server" Width="376px" AutoPostBack="True"  
                      TabIndex="1"></asp:TextBox>
            </td>
            <td class="labelcells" >
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label2" runat="server"      
                    Text="Customer Name Or Part of Name" Width="96px">
                </asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="txtFindName" runat="server" Width="376px" AutoPostBack="True"  
                      TabIndex="2"></asp:TextBox>
                <br />
                <asp:ListBox ID="LstName" runat="server" Visible="False" Width="384px" AutoPostBack="True"
                        TabIndex="3"></asp:ListBox>
            </td>
            <td class="labelcells">
                <asp:Button ID="BtnGetNames" runat="server" CssClass="ButtonBack" 
                    Text="Get Names" />
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label3" runat="server"      
                    Text="Coments" Width="96px"></asp:Label>
            </td>
            <td   class="textcells">
                <asp:TextBox ID="txtComent" runat="server" Height="64px" TextMode="MultiLine" Width="376px"
                        TabIndex="4" MaxLength="1000"></asp:TextBox>
            </td>
            <td class="labelcells" >
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 174px">
                <asp:Label ID="Label4" runat="server"      
                    Text="History" Width="96px"></asp:Label>
            </td>
            <td colspan="2" style="height: 174px" >
                <ew:CollapsablePanel ID="CollapsablePanel1" runat="server" CollapseImageUrl="Image/DNARROW.JPG"
                    CollapserAlign="Left" ExpandImageUrl="Image/UPARROW.JPG" Height="153px" 
                    Width="100%">
                    <asp:TextBox ID="txtHistory" runat="server"   Font-Size="10pt"
                        Height="152px" TextMode="MultiLine" Width="608px" ReadOnly="True"></asp:TextBox></ew:CollapsablePanel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="3">
                <asp:Button ID="BtnApply" runat="server" CssClass="ButtonBack" Text="Apply"
                    TabIndex="5" />
                <asp:Button ID="Button1" runat="server" CssClass="ButtonBack" Text="Reset"
                    TabIndex="6" />
            </td>
        </tr>
    </table>
</asp:Content>
