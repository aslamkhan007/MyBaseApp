<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="PortalLeaveReports.aspx.cs" Inherits="Payroll_PortalLeaveReports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Leave Report:
            </td>
        </tr>

        <tr>
            <td class="labelcells">
                <%--Report Type--%>
                
                   Report Type
            </td>
            <td class="NormalText">


            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="combobox"
                    AppendDataBoundItems="True"                    
                    AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                    >
                     <asp:ListItem >Leave</asp:ListItem>
                    <asp:ListItem >EarnedLeave</asp:ListItem>                   

                </asp:DropDownList>




               
            </td>
            <td class="labelcells">
            Leave Nature
            </td>
            <td class="NormalText">
                               <asp:DropDownList ID="ddldedtype" runat="server" CssClass="combobox"
                    AppendDataBoundItems="True"                    
                    AutoPostBack="True" 
                    onselectedindexchanged="ddldedtype_SelectedIndexChanged">
<%--                     <asp:ListItem >Leave</asp:ListItem>
                    <asp:ListItem >EarnedLeave</asp:ListItem>                    --%>
                    <asp:ListItem>All</asp:ListItem>
                    <asp:ListItem>Casual Leave</asp:ListItem>
                    <asp:ListItem>Compensatory Leave</asp:ListItem>
                    <asp:ListItem>LWP</asp:ListItem>
                    <asp:ListItem>Official Duty</asp:ListItem>
                    <asp:ListItem>Privilege Leave</asp:ListItem>
                    <asp:ListItem>Short Leave</asp:ListItem>
                    <asp:ListItem>Sick Leave</asp:ListItem>
                    <asp:ListItem>Tour</asp:ListItem>
                     </asp:DropDownList>
            </td>
            

            
                <tr>
            <td class="labelcells">
                Effective From
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtefffrm" runat="server" CssClass="textbox" AutoPostBack="True" ontextchanged="txtefffrm_TextChanged"
                    ></asp:TextBox>
                <cc1:CalendarExtender ID="txtefffrm_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txtefffrm">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtefffrm"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                Effective To
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txteffto" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txteffto_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txteffto">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txteffto"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>


                        <tr>
            <td class="labelcells">
                Authorized FromDate
            </td>
            <td class="NormalText">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" AutoPostBack="True" ontextchanged="txtefffrm_TextChanged"
                    ></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                    TargetControlID="TextBox1">
                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox1"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                Authorized ToDate
            </td>
            <td class="NormalText">
                <asp:TextBox ID="TextBox2" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                    TargetControlID="TextBox2">
                </cc1:CalendarExtender>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox2"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>

            </td>
        </tr>

        </tr>

               <tr>
            <td class="labelcells">
                Plant
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlplant" runat="server" AutoPostBack="True" CssClass="combobox"
                    OnSelectedIndexChanged="ddlplant_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlplant"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                Status
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" CssClass="combobox">
                  <asp:ListItem Value="P" >Pending</asp:ListItem>
                  <asp:ListItem Value="A" >Authorized</asp:ListItem>                    
                </asp:DropDownList>                
            </td>
        </tr>

        <tr>
            <td class="NormalText">              
            </td>
            <td class="NormalText">
            </td>
            <td class="NormalText">
      
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonXL" Height="32px" Width="32px"
                    OnClick="lnkexcel_Click"></asp:LinkButton>
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>        
        <tr>
            <td class="buttonbackbar" colspan="4">                
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" OnClick="lnksave_Click"
                    ValidationGroup="A">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" CausesValidation="False"
                    ValidationGroup="A" OnClick="lnkreset_Click">Reset</asp:LinkButton>
         
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="950px">
                            <asp:GridView ID="grdDetail" runat="server" EnableModelValidation="True" Width="100%">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PageStyle" />
                                <RowStyle CssClass="Griditem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>




