<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Jct_payroll_blood_master.aspx.cs" Inherits="Payroll_Jct_payroll_blood_master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table style="width: 100%" >
        <tr>
            <td class="tableheader" colspan="4">
                Blood Master</td>
        </tr>
        <tr>
            <td class="labelcells">
                Group Name</td>
            <td class="NormalText">
            
                <asp:TextBox ID="txtGroupName" runat="server" CssClass="textbox" 
                    Width="300px"></asp:TextBox>
            
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="txtGroupName" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            
            </td>
            <td class="labelcells">
                <asp:Label ID="lblGroupCode" runat="server" Text="Group Code" Visible="False"></asp:Label>
            </td>
            <td class="labelcells">
              
                <asp:Label ID="lbcodeid" runat="server" Visible="False"></asp:Label>
              
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

