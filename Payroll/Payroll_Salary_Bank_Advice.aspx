<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Payroll_Salary_Bank_Advice.aspx.cs" Inherits="Payroll_Payroll_Salary_Bank_Advice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Bank Advice
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 25px">
                YearMonth
            </td>
            <td class="NormalText" style="height: 25px">
                <asp:TextBox ID="txtMonth" runat="server" Style="text-transform: capitalize;" CssClass="textbox"
                    AutoPostBack="True" MaxLength="10" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMonth"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells" style="height: 25px">
                Category
            </td>
            <td class="NormalText" style="height: 25px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="combobox" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                            <asp:ListItem>Salary</asp:ListItem>
                            <asp:ListItem>CarAllowance</asp:ListItem>
                            <asp:ListItem>ScooterAllowance</asp:ListItem>
                            <asp:ListItem>Overtime</asp:ListItem>
                            <asp:ListItem>Bonus</asp:ListItem>
                            <asp:ListItem>SalaryAdvance</asp:ListItem>
                            <asp:ListItem>LeaveEncashment</asp:ListItem>
                            <asp:ListItem>LTA</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 25px">
                Plant
            </td>
            <td class="NormalText" style="height: 25px">
                <%--    <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" 
                    AutoPostBack="True" Width="200px" 
                    onselectedindexchanged="ddlplant_SelectedIndexChanged">
                     </asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="ddlplant" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlplant_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="labelcells" style="height: 25px">
                Location
            </td>
            <td class="NormalText" style="height: 25px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlLocation" runat="server" CssClass="combobox" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlLocation"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                BankName
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlbank" runat="server" CssClass="combobox" Width="200px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlbank"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Department
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updatedepartment" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddldepartment" runat="server" CssClass="combobox">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbldesignation" runat="server" Text="Designation" Visible="False"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddldesignation" runat="server" AutoPostBack="True" CssClass="combobox"
                            Visible="False">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:UpdatePanel ID="UpdatePaneasdasdl6" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Doj" Visible="False"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel6sdas" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddldojtype" runat="server" CssClass="combobox" Visible="False">
                            <asp:ListItem>Before 1Jan2020</asp:ListItem>
                            <asp:ListItem>After 1Jan2020</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="lnkfetch_Click">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
                <asp:LinkButton ID="LnkExcel" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="LnkExcel_Click" Enabled="False">Excel</asp:LinkButton>
                <%--<asp:LinkButton ID="lnkPrint" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="lnkPrint_Click">Print</asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" Visible="False"
                    Width="1000px">
                    <asp:GridView ID="grdDetail" runat="server" Width="100%" PageSize="30" EmptyDataText="No Record..">
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
