<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Jct_payroll_Designation_master.aspx.cs" Inherits="Payroll_Jct_payroll_Designation_master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table style="width: 100%" >
        <tr>
            <td class="tableheader" colspan="4">
                Designation Master</td>
        </tr>
        <tr>
            <td class="labelcells">
                Short Description</td>
            <td class="NormalText">
            
                <asp:TextBox ID="txtShortDescription" runat="server" CssClass="textbox" 
                    Width="70px"></asp:TextBox>
            
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="txtShortDescription" ErrorMessage="*" 
                    ValidationGroup="A"></asp:RequiredFieldValidator>
            
            </td>
            <td class="labelcells">
                <asp:Label ID="lblDesignationCode" runat="server" Text="Designation Code" 
                    Visible="False"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="lbcodeid" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Long&nbsp; Description</td>
            <td class="NormalText">
            
                <asp:TextBox ID="txtLongDescription" runat="server" CssClass="textbox" 
                    Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ControlToValidate="txtLongDescription" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Effective From</td>
            <td class="NormalText">
                
                <asp:TextBox ID="txtefffrm" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>

                <cc1:calendarextender ID="txtefffrm_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtefffrm">
                </cc1:calendarextender>
              
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtefffrm" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                Effective To</td>
            <td class="NormalText">
                <asp:TextBox ID="txteffto" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>
                <cc1:calendarextender ID="txteffto_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txteffto">
                </cc1:calendarextender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txteffto" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" 
                     ValidationGroup="A" onclick="lnkadd_Click">Add</asp:LinkButton>
                <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" 
                     ValidationGroup="A" onclick="lnkupdate_Click">Update</asp:LinkButton>
                <asp:LinkButton ID="lnkdelete" runat="server" CssClass="buttonc" 
                    ValidationGroup="A" onclick="lnkdelete_Click">Delete</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" 
                    onclick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
             <tr>
            <td class="NormalText" colspan="4">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" 
                    Visible="False" Width="1000px">
                    <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True" 
                    Width="100%" onselectedindexchanged="grdDetail_SelectedIndexChanged" 
  >
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

