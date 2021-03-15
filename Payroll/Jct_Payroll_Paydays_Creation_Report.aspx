<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Jct_Payroll_Paydays_Creation_Report.aspx.cs" Inherits="Payroll_Jct_Payroll_Paydays_Creation_Report" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Employee Muster :
            </td>
        </tr>

   <%--     <tr>
            <td class="labelcells">
                Report Type
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddldedtype" runat="server" CssClass="combobox"
                    AppendDataBoundItems="True"    onselectedindexchanged="ddldedtype_SelectedIndexChanged"                    
                    AutoPostBack="True">

                     <asp:ListItem >BloodGroup</asp:ListItem>
                    <asp:ListItem >JobTypeWise Attendance</asp:ListItem>
                    <asp:ListItem >AreaWise Attendance</asp:ListItem>
                    <asp:ListItem Selected="True">DepartmentWise Attendance</asp:ListItem>
                    <asp:ListItem>ShiftWise Attendance</asp:ListItem>
                    <asp:ListItem >Employee PayDays</asp:ListItem>  


<asp:ListItem >ShortDuty</asp:ListItem>  

                    
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>--%>
        
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
                From Date</td>
            <td class="NormalText">
                <asp:TextBox ID="txtefffrm" runat="server" CssClass="textbox" 
                    ontextchanged="txtefffrm_TextChanged" AutoPostBack="True"
                    ></asp:TextBox>
                <cc1:CalendarExtender ID="txtefffrm_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txtefffrm">
                </cc1:CalendarExtender>
            </td>
            <td class="labelcells">
                To Date</td>
            <td class="NormalText">
                <asp:TextBox ID="txteffto" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txteffto_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txteffto">
                </cc1:CalendarExtender>
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
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>             
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" OnClick="lnksave_Click"
                    ValidationGroup="A">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" CausesValidation="False"
                    ValidationGroup="A" OnClick="lnkreset_Click">Reset</asp:LinkButton>
                <%--<asp:LinkButton ID="lnkUpdate" runat="server" CssClass="buttonc" CausesValidation="False"
                    OnClick="lnkUpdate_Click" Visible="False">Update</asp:LinkButton>--%>
                        <asp:LinkButton ID="lnkPrint" runat="server" CausesValidation="False" 
                            CssClass="buttonc"  ValidationGroup="A" onclick="lnkPrint_Click" 
                            Visible="False">Print</asp:LinkButton>
                     </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>

        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/loadingNew.gif" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </ContentTemplate>
                </asp:UpdatePanel>
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







