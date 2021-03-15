﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Payroll_lacation_master.aspx.cs" Inherits="PayRoll_Payroll_lacation_master" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   
    <script type="text/javascript">
        function SetContextKey()
        { var x = document.GetelementbyId("txtstate"); $find('txtcity_AutoCompleteExtender').set_contextKey(x.value); return; }
        </script> 
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
            Location Master</td>
        </tr>
        <tr>
            <td class="labelcells">
                Plant</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" 
                    onselectedindexchanged="ddlplant_SelectedIndexChanged" AutoPostBack="True">
                     </asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="ddlplant" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
                        <td class="labelcells"></td>
            <td class="NormalText"> </td>
            </tr>
            <tr>
             <td class="labelcells">
                State</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlstate" runat="server" AutoPostBack="True" 
                    CssClass="combobox" Height="30px" 
                    onselectedindexchanged="ddlstate_SelectedIndexChanged">
                </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="ddlstate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
             <td class="labelcells"></td>
            <td class="NormalText"> </td>
            </tr>
            <tr>
            <td class="labelcells">
                City</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlcity" runat="server" CssClass="combobox" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlcity_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ControlToValidate="ddlcity" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
             <td class="labelcells">
                <asp:Label ID="lblCode" runat="server" Text="Sr No" Visible="False"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="lblocid" runat="server" Visible="False"></asp:Label>
            </td>
            </tr>
        <tr>
            <td class="labelcells">
                Location Description</td>
            <td class="NormalText">
                <asp:TextBox ID="txtlocdesc" runat="server" style="text-transform: uppercase" CssClass="textbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtlocdesc" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
           <td class="labelcells">
                <asp:Label ID="lbloctext" runat="server" Text="LocationCode" Visible="False"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="lbcodeid" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                PF No</td>
            <td class="NormalText">
                <asp:TextBox ID="txtPFNo" runat="server" CssClass="textbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtPFNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                ESI No</td>
            <td class="NormalText">
                <asp:TextBox ID="txtEsiNo" runat="server" CssClass="textbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="txtEsiNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Address</td>
            <td class="NormalText">
                <asp:TextBox ID="txtaddress" runat="server" TextMode="MultiLine" style="text-transform: uppercase"
                    CssClass="textbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtaddress" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells"></td>
            <td class="NormalText"> </td>
        </tr>
        <tr>
            <td class="labelcells">
                Effective From</td>
            <td class="NormalText">
                <asp:TextBox ID="txtefffrm" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtefffrm_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtefffrm">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtefffrm" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                Effective To</td>
            <td class="NormalText">
                <asp:TextBox ID="txteffto" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txteffto_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txteffto">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txteffto" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
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

