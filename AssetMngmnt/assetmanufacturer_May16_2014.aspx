<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="assetmanufacturer.aspx.cs" Inherits="AssetMngmnt_assetmanufacturer" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label18" runat="server" Text="Asset Manufacturer Master"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 175px" >
                Effective From</td>
            <td class="NormalText" style="width: 134px">
                <asp:TextBox ID="txtefffrm" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtefffrm_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtefffrm">
                </cc1:CalendarExtender>
            </td>
             
         
            <td class="NormalText" style="width: 137px">
                EffectiveTo</td>
             
         
            <td class="NormalText">
                <asp:TextBox ID="txteffto" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txteffto_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txteffto">
                </cc1:CalendarExtender>
            </td>
             
         
        </tr>
        <tr>
            <td class="NormalText" style="width: 175px" >
                Manufacturer Name</td>
            <td class="NormalText" colspan="3">
                <asp:TextBox ID="txtmanfactname" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtmanfactname" Display="Dynamic" ErrorMessage="**" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
         
        </tr>
        <tr>
            <td class="NormalText" style="width: 175px" >
                Manufacturer Description</td>
            <td class="NormalText" style="width: 134px">
                <asp:TextBox ID="txtmanufactdesc" runat="server" CssClass="textbox" Height="50px" TextMode="MultiLine" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtmanufactdesc" Display="Dynamic" ErrorMessage="**" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
       
            <td class="NormalText" style="width: 137px">
                Contact Number</td>
       
            <td class="NormalText">
                <asp:TextBox ID="txtcontactnum" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtcontactnum_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtcontactnum" 
                    ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
       
        </tr>
        <tr>
            <td class="NormalText" style="width: 175px" >
                Manufacturer Address</td>
            <td class="NormalText" style="width: 134px">
                <asp:TextBox ID="txtaddress" runat="server" CssClass="textbox" 
                    TextMode="MultiLine" Height="50px" Width="200px"></asp:TextBox>
            </td>
       
            <td class="NormalText" style="width: 137px">
                Manufacturer E-mail</td>
       
            <td class="NormalText">
                <asp:TextBox ID="txtemail" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtemail" Display="Dynamic" ErrorMessage="Invalid Email" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="A"></asp:RegularExpressionValidator>
            </td>
       
        </tr>
        <tr>
            <td class="NormalText" style="width: 175px" >
                Vendor Name</td>
            <td class="NormalText" style="width: 134px">
                <asp:TextBox ID="txtvendor" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
            </td>
       
            <td class="NormalText" style="width: 137px">
                Vendor Address/ContactNo.</td>
       
            <td class="NormalText">
                <asp:TextBox ID="txtvendoraddres" runat="server" CssClass="textbox" Height="50px" TextMode="MultiLine" Width="200px"></asp:TextBox>
            </td>
       
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" 
                    onclick="lnkadd_Click" ValidationGroup="A">Add</asp:LinkButton>
                <asp:LinkButton ID="lnkdel" runat="server" CssClass="buttonc" 
                    onclick="lnkdel_Click" ValidationGroup="A">Delete</asp:LinkButton>
                <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" 
                    onclick="lnkupdate_Click" ValidationGroup="A">Update</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" 
                    onclick="lnkreset_Click">Reset</asp:LinkButton>
                <asp:Label ID="lbid" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
       
 
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True" 
                    Width="100%" onselectedindexchanged="grdDetail_SelectedIndexChanged">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <PagerStyle CssClass="PageStyle" />
                    <RowStyle CssClass="GridItem" />
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>
            </td>
       
       
       
        </tr>
    </table>
</asp:Content>

