<%@ Page Title="" Language="C#" MasterPageFile="~/AssetMngmnt/MasterPage.master" AutoEventWireup="true" CodeFile="test1.aspx.cs" Inherits="AssetMngmnt_test1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width:100%;">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 26px">
                </td>
            <td style="height: 26px">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="textcells_s"></asp:TextBox>


                <cc1:MaskedEditValidator ID="MEV1" runat="server" ControlExtender="MEE1" 
                    ControlToValidate="TextBox1" Display="Dynamic" EmptyValueMessage="ENTER DATE!!" 
                    ErrorMessage="MEV1" InvalidValueMessage="INVALID DATE" 
                    TooltipMessage="MM/DD/YYYY" ValidationGroup="mandatory" 
                    IsValidEmpty="False"></cc1:MaskedEditValidator>

                         <cc1:MaskedEditExtender ID="MEE1" runat="server" Mask="99/99/9999" 
                    MaskType="Date" TargetControlID="TextBox1">
                </cc1:MaskedEditExtender>

        
                <cc1:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" 
                    TargetControlID="TextBox1">
                </cc1:CalendarExtender>
                <br />
                <asp:GridView ID="GridView1" runat="server">
                   <AlternatingRowStyle CssClass="GridAI" />
                     <HeaderStyle CssClass="HeaderStyle" />

                </asp:GridView>
            </td>
            <td style="height: 26px">
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonc" 
                    onclick="LinkButton1_Click" ValidationGroup="mandatory">LinkButton</asp:LinkButton>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

</asp:Content>


