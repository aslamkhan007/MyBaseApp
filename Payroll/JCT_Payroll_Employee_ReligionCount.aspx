<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="JCT_Payroll_Employee_ReligionCount.aspx.cs" Inherits="Payroll_JCT_Payroll_Employee_ReligionCount" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                               Employee Heads:
            </td>
        </tr>

        <tr>
            <td class="labelcells">
                Report Type
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddldedtype" runat="server" CssClass="combobox"
                    OnSelectedIndexChanged="ddldedtype_SelectedIndexChanged" AppendDataBoundItems="True"
                    DataTextField="Deduction_Short_Description" 
                    DataValueField="Deduction_code" AutoPostBack="True">
                    <asp:ListItem >PlantLocationCount</asp:ListItem>
                    <asp:ListItem >GenderCount</asp:ListItem>
                    <asp:ListItem >JobTypeCount</asp:ListItem>
                    <asp:ListItem Selected="True">ReligionCount</asp:ListItem>
                    <asp:ListItem>WorkAreaCount</asp:ListItem>
                    <asp:ListItem>SalaryTypeCount</asp:ListItem>
                    <asp:ListItem>DepartmentCount</asp:ListItem>
                    <asp:ListItem>DesignationCount</asp:ListItem>
                    <asp:ListItem>GenderCount</asp:ListItem>
                    <asp:ListItem>EmployeeDetail</asp:ListItem>


                    <%--<asp:ListItem>Increment</asp:ListItem>--%>
                </asp:DropDownList>
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
                Location
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlLocation" runat="server" AutoPostBack="True" CssClass="combobox">
                </asp:DropDownList>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlLocation"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>

         <tr>
            <td class="labelcells">
               Type
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddl1" runat="server" CssClass="combobox"
                    >

                     <asp:ListItem Selected="True">Detail</asp:ListItem>
                    <asp:ListItem>Count</asp:ListItem>
                </asp:DropDownList>
                
            </td>
            <td class="labelcells">
                Jobtype
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddl2" runat="server"  CssClass="combobox">

                <asp:ListItem Selected="True">All</asp:ListItem>
                    <asp:ListItem>Christian</asp:ListItem>
                    <asp:ListItem>Hindu</asp:ListItem>
                    <asp:ListItem>Muslim</asp:ListItem>
                    <asp:ListItem>Sikh</asp:ListItem>                                        
                    

                </asp:DropDownList>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlLocation"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>

        <tr>
            <td class="NormalText">
                <%--    Reimbursement Type--%>
            </td>
            <td class="NormalText">
                <%--        <asp:DropDownList ID="ddldedtype" runat="server" AutoPostBack="True" CssClass="combobox"
                    OnSelectedIndexChanged="ddldedtype_SelectedIndexChanged" AppendDataBoundItems="True"
                    DataTextField="Deduction_Short_Description" DataValueField="Deduction_code">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddldedtype"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            </td>
            <td class="NormalText">
                <%--<asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonXL" Height="32px" Width="32px"
                    OnClick="lnkexcel_Click"></asp:LinkButton>--%>
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonXL" Height="32px" Width="32px"
                    OnClick="lnkexcel_Click"></asp:LinkButton>
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <%-- <tr>
            <td class="NormalText">
                Number Of Months
            </td>
            <td class="NormalText">
                <asp:Label ID="lblMonths" runat="server"></asp:Label>
                <br />
            </td>
            <td class="NormalText">
                Amount
            </td>
            <td class="NormalText">
                <asp:Label ID="lbldedamount" runat="server"></asp:Label>
            </td>
        </tr>--%>
        <tr>
            <td class="buttonbackbar" colspan="4">                
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" OnClick="lnksave_Click"
                    ValidationGroup="A">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" CausesValidation="False"
                    ValidationGroup="A" OnClick="lnkreset_Click">Reset</asp:LinkButton>
                <%--<asp:LinkButton ID="lnkUpdate" runat="server" CssClass="buttonc" CausesValidation="False"
                    OnClick="lnkUpdate_Click" Visible="False">Update</asp:LinkButton>--%>
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




