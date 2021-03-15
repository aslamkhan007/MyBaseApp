<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="payroll_Plant_master.aspx.cs" Inherits="Payroll_payroll_Plant_master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%" >
        <tr>
            <td class="tableheader" colspan="4">
                Plant Master</td>
        </tr>
        <tr>
            <td class="labelcells">
                PlantName</td>
            <td class="NormalText">
                <asp:TextBox ID="txtPlantName" runat="server" style="text-transform: uppercase" CssClass="textbox"></asp:TextBox>
              
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="txtPlantName" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                <asp:Label ID="lblPlantCode" runat="server" Text="Plant Code" Visible="False"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="lbcodeid" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Description</td>
            <td class="NormalText">
            
                <asp:TextBox ID="txtPlantDescription" runat="server" CssClass="textbox" style="text-transform: uppercase"
                    Width="300px"></asp:TextBox>
            
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="txtPlantDescription" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            
            </td>
            <td class="labelcells">
                Country</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlcountry" runat="server" CssClass="combobox">
                    <asp:ListItem Value="01">India</asp:ListItem>              
                </asp:DropDownList>
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
            <td class="labelcells">
                State</td>
            <td class="NormalText"> 
                 <asp:DropDownList ID="ddlstate" runat="server" CssClass="combobox" 
                    AutoPostBack="True"  DataSourceID="SqlDataSource1" DataTextField="state" 
                DataValueField="state" Height="30px"  
                    onselectedindexchanged="ddlstate_SelectedIndexChanged"  >                       
                </asp:DropDownList>
                   
               <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="SELECT DISTINCT state FROM JCTGEN..JCT_EPOR_STATE_MASTER  ">
                </asp:SqlDataSource>

       <%--    <asp:DropDownList ID="ddlCity" runat="server" CssClass="combobox" AutoPostBack="True"   DataSourceID="SqlDataSource2" DataTextField="City" 
              
                DataValueField="City" Height="30px"  >
                               
                </asp:DropDownList>
--%>

             
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                City</td>
            <td class="NormalText">
                 <asp:DropDownList ID="ddlCity" runat="server" 
                CssClass="combobox" >
                </asp:DropDownList>
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

