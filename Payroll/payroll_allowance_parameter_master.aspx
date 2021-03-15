<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="payroll_allowance_parameter_master.aspx.cs" Inherits="PayRoll_payroll_allowance_parameter_master" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Components Master</td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">                
                &nbsp;</td>
            <td class="labelcells">
                <asp:Label ID="lblSrCode" runat="server" Text="SrCode" Visible="False"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="lbcodeid" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Component Type</td>
            <td class="NormalText">                
               <asp:DropDownList ID="ddlAlloawanceType" runat="server" AutoPostBack="True" 
                    CssClass="combobox" 
                    ToolTip="Specify The Type of Earnings" 
                    onselectedindexchanged="ddlAlloawanceType_SelectedIndexChanged">
                    <asp:ListItem>Earning</asp:ListItem>
                    <asp:ListItem>Reimbursement</asp:ListItem>
                    <asp:ListItem>Deduction</asp:ListItem>
                </asp:DropDownList>

        
            </td>
            <td class="labelcells">
                <asp:Label ID="lblComponentNature" runat="server" Text="Component Nature"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlComponentNature" runat="server" AutoPostBack="True" 
                    CssClass="combobox" 
                    ToolTip="Component Nature (Fix,Variable)">
                    <asp:ListItem>Fixed</asp:ListItem>
                    <asp:ListItem>Variable</asp:ListItem>
                    <asp:ListItem>Loan</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Component Name</td>
            <td class="NormalText">
                <asp:TextBox ID="txtdesc" runat="server" CssClass="textbox" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtdesc" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                Component Description</td>
            <td>
                <asp:TextBox ID="txtshortdesc" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtshortdesc" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Effective From</td>
            <td class="NormalText">
                <asp:TextBox ID="txteff_frm" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txteff_frm_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txteff_frm">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txteff_frm" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                Effective To</td>
            <td class="NormalText">
                <asp:TextBox runat="server" ID="txteff_to" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txteff_to_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txteff_to">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txteff_to" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonXL" Height="32px" OnClick="lnkexcel_Click"
                    Width="32px"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" 
                    onclick="lnksave_Click" ValidationGroup="A">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" 
                    onclick="lnkupdate_Click" ValidationGroup="A">Update</asp:LinkButton>
                <asp:LinkButton ID="lnkdel" runat="server" CssClass="buttonc" 
                    onclick="lnkdel_Click" ValidationGroup="A">Delete</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" 
                    onclick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
          <tr>
            <td class="NormalText" colspan="4">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" 
                    Visible="False" Width="1000px">
                    <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True" 
                    Width="100%" 
    onselectedindexchanged="grdDetail_SelectedIndexChanged">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>
            </td>
       
       
       
        </tr>
    </table>
</asp:Content>

