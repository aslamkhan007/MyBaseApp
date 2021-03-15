<%@ Page Title="" Language="C#" MasterPageFile="~/exportdoc/MasterPage.master" AutoEventWireup="true" CodeFile="TransportMode.aspx.cs" Inherits="exportdoc_TransportMode" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="height: 250px; width: 100%" >
       
        <tr>
            <td colspan="4" class="tableheader">     
                Transport Mode:</td>
        </tr>
        <tr>
            <td class="labelcells" >
                <asp:Label ID="lblModeCode" runat="server" Text="ShortDescription"></asp:Label>                
            </td>
            <td>
                  <asp:TextBox ID="txtModeCode" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="labelcells" >           
                <asp:Label ID="lblSrNo" runat="server" Text="SrNo" ForeColor="#FF5050"></asp:Label>
            </td>
            <td >
                <asp:Label ID="lblserialno" runat="server" ForeColor="#FF6666"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="lblDescription" runat="server" Text="Long Description"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtDescription" runat="server" CssClass="textbox"  Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="lblTransModeCode" runat="server" Text="TransModeCode"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtTransModeCode" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="lblEfecFrom" runat="server" Text="Effective From  "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txteffefrom" runat="server" CssClass="textbox" Width="68px"></asp:TextBox>                                       
                <cc1:CalendarExtender ID="txteffefrom_CalendarExtender" runat="server" 
                    TargetControlID="txteffefrom">
                </cc1:CalendarExtender>
            </td>
            <td style="width: 86px" class="labelcells" >
                <asp:Label ID="lblEfectTo" runat="server" Text="Effective To"></asp:Label>
            </td>
            <td >
                <asp:TextBox ID="txtEfecTo" runat="server" Width="68px" CssClass="textbox" ></asp:TextBox>             
                <cc1:CalendarExtender ID="txtEfecTo_CalendarExtender" runat="server" 
                    TargetControlID="txtEfecTo">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="buttonbackbar">
                <asp:LinkButton ID="lnkbtnSave" runat="server" onclick="lnkbtnSave_Click" 
                    CssClass="buttonc">Save</asp:LinkButton>
                     <asp:LinkButton ID="lnkbtnReset" runat="server"
                    CssClass="buttonc" onclick="lnkbtnReset_Click">RESET</asp:LinkButton>
                <asp:LinkButton ID="lnkbtnEditUpdate" runat="server" 
                    onclick="lnkbtnEditUpdate_Click" CssClass="buttonc">Update</asp:LinkButton>
                <asp:LinkButton ID="lnkBtnDelete" runat="server" CssClass="buttonc" 
                    onclick="lnkBtnDelete_Click">Delete</asp:LinkButton>
            </td>
        </tr>
        <tr >
        <td colspan="4">
          <asp:GridView ID="grdTransportMode" runat="server" Width="100%" 
                EnableModelValidation="True" 
                AllowPaging="True" 
                onselectedindexchanged="grdTransportMode_SelectedIndexChanged">
              <Columns>
                  <asp:CommandField ShowHeader="True" 
                      ShowSelectButton="True" />
              </Columns>
                <HeaderStyle CssClass="GridHeader" />
              <PagerStyle CssClass="PagerStyle" />
              <RowStyle CssClass="GridItem" />
                </asp:GridView>
        </td>
        </tr>
        
    </table>
</asp:Content>

