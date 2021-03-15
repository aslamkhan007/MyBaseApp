<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Payroll_Salary_Loans_Print.aspx.cs" Inherits="Payroll_Payroll_Salary_Loans_Print" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Loans Report:</td>
        </tr>
        <tr>
            <td class="labelcells">
                For the Month(Start)
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtfromdate" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>
                <cc1:CalendarExtender ID="txtfromdate_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txtfromdate">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfromdate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                For the Month(End)
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txttodate" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>
                <cc1:CalendarExtender ID="txttodate_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txttodate">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttodate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Plant
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                Location
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlLocation" runat="server" AutoPostBack="True" CssClass="combobox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Loans</td>
            <td class="NormalText">
<%--                <asp:DropDownList ID="ddlReportType" runat="server" CssClass="combobox" 
                    >                    
                </asp:DropDownList>--%>
                                <asp:DropDownList ID="ddlReportType" runat="server" CssClass="combobox"                     
                    AutoPostBack="True" onselectedindexchanged="ddlReportType_SelectedIndexChanged" 
                    >
                                    
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                <asp:Label ID="lblBankName" runat="server" Text="BankName" Visible="False"></asp:Label>
            </td>
            <td class="NormalText">
               
  <asp:DropDownList ID="ddlBankName" runat="server" CssClass="combobox" 
                    Visible="False">
                </asp:DropDownList>
               
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Card No</td>
            <td class="NormalText">
                <asp:TextBox ID="txtSaviorcardno" runat="server" AutoCompleteType="Disabled" 
                    CssClass="textbox" MaxLength="4" 
                    ToolTip="Card No. can contain only 4 numeric characters." Width="78px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="Flt1" runat="server" Enabled="True" 
                    FilterType="Numbers" TargetControlID="txtSaviorcardno">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td class="labelcells">
                <asp:Label ID="lblSummary_Detail" runat="server" Text="Report Type" ></asp:Label>
				</td>
            <td class="NormalText">
                
				                 <asp:DropDownList ID="ddlSummary_Detail" runat="server" CssClass="combobox" 
                    >
                     <asp:ListItem Selected="True">Summary</asp:ListItem>
                     <asp:ListItem>Detail</asp:ListItem>
                </asp:DropDownList>
				
				</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="lnkFetch_Click">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="tableheader" colspan="4">
            </td>
        </tr>
    </table>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
        GroupTreeImagesFolderUrl="" Height="1202px" ReportSourceID="CrystalReportSource1"
        ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="1104px" />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="Payroll_Salary_Loans.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>
