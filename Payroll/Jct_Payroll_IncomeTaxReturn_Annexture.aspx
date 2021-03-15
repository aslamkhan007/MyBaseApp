<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Jct_Payroll_IncomeTaxReturn_Annexture.aspx.cs" Inherits="Payroll_Jct_Payroll_IncomeTaxReturn_Annexture" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

 <style type="text/css">
        .buttonTxt
        {
            background-image: url('Image/txticon.jpg');
            background-repeat: no-repeat;
            width: 32px;
            height: 32px;
        }
    </style>

    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Annexture Details:
            </td>
        </tr>
         <tr>
            <td class="labelcells">
                <asp:Label ID="LblReportType" runat="server" Text="Type"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlReporttypes" runat="server" CssClass="combobox" OnSelectedIndexChanged="ddlReporttypes_SelectedIndexChanged"
                    AutoPostBack="True">
                    <asp:ListItem>FileBatch</asp:ListItem>
                    <asp:ListItem>ChallanDed</asp:ListItem>
                     <asp:ListItem Selected="True">Annexture</asp:ListItem>
                      <asp:ListItem >TaxReturn</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                YearMonth
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtMonth" runat="server" Style="text-transform: capitalize;" CssClass="textbox"
                    AutoPostBack="True" MaxLength="6" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtMonth"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                     <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True"
                    TargetControlID="txtMonth" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>

            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Plant
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlplant" runat="server" AutoPostBack="True" CssClass="combobox"
                    OnSelectedIndexChanged="ddlplant_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlplant"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                <asp:LinkButton ID="lnkexcel0" runat="server" CssClass="buttonXL" Height="32px" OnClick="lnkexcel_Click"
                    Width="32px"></asp:LinkButton>
            </td>
            <td class="NormalText">
             
            </td>
        </tr>
         <tr>
            <td colspan="4">
               <%--<asp:LinkButton ID="LnkExcel" runat="server" CssClass="buttonTxt" Height="50px" Width="50px"
                    ValidationGroup="A" title="TextFile Download" OnClick="LnkExcel_Click" Enabled="False"></asp:LinkButton>--%>
            </td>
        </tr>
   <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="lnkfetch_Click">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>

        
        <tr>
            <td class="NormalText" colspan="4">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" Visible="False"
                    Width="1000px">
                    <asp:GridView ID="grdDetail" runat="server" Width="100%" EmptyDataText="No Record Found">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>
                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>



