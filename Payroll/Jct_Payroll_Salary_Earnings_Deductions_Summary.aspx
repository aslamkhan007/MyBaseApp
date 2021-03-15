<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_Salary_Earnings_Deductions_Summary.aspx.cs" Inherits="Payroll_Jct_Payroll_Salary_Earnings_Deductions_Summary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Monthly Salary / Voucher:
            </td>
        
        </tr>

               <tr>
            <td class="labelcells">
            <asp:Label ID="LblReportType" runat="server" Text="Report Type"></asp:Label>
                
            </td>
            <td class="NormalText">
                     <asp:DropDownList ID="ddlReporttypes" runat="server" CssClass="combobox" 
                       onselectedindexchanged="ddlReporttypes_SelectedIndexChanged" AutoPostBack="True"
                    >
                    <asp:ListItem>Detail</asp:ListItem>
                    <asp:ListItem>Voucher</asp:ListItem>
                    <asp:ListItem>Designationwise NetSal.</asp:ListItem>
                    <asp:ListItem>Summary(Sap)</asp:ListItem>
                    
                </asp:DropDownList>  
            </td>
            <td class="labelcells">
            <asp:Label ID="LlbCalType" runat="server" Text="SalaryType" Visible="False"></asp:Label>
            </td>
            <td class="NormalText">
            <%--<asp:DropDownList ID="ddlCalType" runat="server" CssClass="combobox" 
                      AutoPostBack="True"
                    >
                    <asp:ListItem>Salary</asp:ListItem>
                    <asp:ListItem>Seprate Voucher</asp:ListItem>
                </asp:DropDownList>--%>
                  <asp:DropDownList ID="ddlSalaryType" runat="server" CssClass="combobox" 
                    Visible="False">
                            <asp:ListItem>Bank</asp:ListItem>
                            <asp:ListItem>Cash</asp:ListItem>
                        </asp:DropDownList>

            </td>
        </tr>

        <tr>
            <td class="labelcells">
                YearMonth
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txttodate" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttodate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                
            </td>
            <td class="NormalText">
                
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Plant
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlplant_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                
                <asp:Label ID="Label11" runat="server" Text="Location" ></asp:Label>
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlLocation" runat="server" AutoPostBack="True" CssClass="combobox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                
            </td>
            <td class="NormalText">
                
            </td>
            <td class="labelcells">
                
            </td>
            <td class="NormalText">
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonXL" Height="32px" OnClick="lnkexcel_Click"
                    Width="32px"></asp:LinkButton>
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
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="950px">
                            <asp:GridView ID="grdDetail" runat="server" EmptyDataText="No Record Found" 
                                EnableModelValidation="True" Width="100%">
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
