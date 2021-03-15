<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="payroll_accommodation_master.aspx.cs" Inherits="PayRoll_payroll_accommodation_master" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Accomodation Master</td>
        </tr>
       <tr>
            <td class="labelcells">
                Plant
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" 
                    AutoPostBack="True" onselectedindexchanged="ddlplant_SelectedIndexChanged" >
                </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="ddlplant" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
             <td class="labelcells">
                <asp:Label ID="PlantCode" runat="server" Text="Plant Code" Visible="False"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="plantid" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
       
        <tr>
            <td class="labelcells">
                Accomodation Type</td>
            <td class="NormalText">
                <asp:TextBox ID="txtaccomodation" runat="server" 
                    style="text-transform: uppercase" CssClass="textbox" 
                    MaxLength="15"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtaccomodation" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                <asp:Label ID="SrCode" runat="server" Text="Sr No" Visible="False"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="SrId" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
         <tr>
            <td class="labelcells">
                Accomodation Description</td>
            <td class="NormalText" colspan="3">
                <asp:TextBox ID="DescText" runat="server" style="text-transform: uppercase" CssClass="textbox" 
                    MaxLength="35" Width="220px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="DescText" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
       
        </tr>
        <tr>
            <td class="labelcells">
                Start HouseNo</td>
            <td class="NormalText">
                <asp:TextBox ID="txtstart" runat="server" CssClass="textbox" MaxLength="3"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtstart_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtstart" 
                    ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtstart" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                End HouseNo</td>
            <td class="NormalText">
                <asp:TextBox ID="txtend" runat="server" CssClass="textbox" ValidationGroup="A" 
                    MaxLength="3"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtend_FilteredTextBoxExtender" runat="server" 
                    Enabled="True" TargetControlID="txtend" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtend" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Effective From
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txteff_from" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txteff_from_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txteff_from">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txteff_from" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                &nbsp;Effective To&nbsp;</td>
            <td class="NormalText">
                <asp:TextBox ID="txteff_to" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txteff_to_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txteff_to">
                </cc1:CalendarExtender>
            </td>
        </tr>
             <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" 
                    onclick="lnkadd_Click" ValidationGroup="A">Add</asp:LinkButton>
                <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" 
                    onclick="lnkupdate_Click" ValidationGroup="A">Update</asp:LinkButton>
                <asp:LinkButton ID="lnkdelete" runat="server" CssClass="buttonc" 
                    onclick="lnkdelete_Click" >Delete</asp:LinkButton>
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

