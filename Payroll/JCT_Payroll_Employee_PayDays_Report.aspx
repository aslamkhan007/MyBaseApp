<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="JCT_Payroll_Employee_PayDays_Report.aspx.cs" Inherits="Payroll_JCT_Payroll_Employee_PayDays_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
   
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
    function SetContextKey() {
        $find('<%=txtEmployee_AutoCompleteExtender.ClientID%>').set_contextKey($get("<%=ddlLocation.ClientID %>").value);
    }
    </script>
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
              Attendence Queries:
            </td>
        </tr>

        <tr>
            <td class="labelcells">
                Report Type
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddldedtype" runat="server" CssClass="combobox"
                    AppendDataBoundItems="True" 
                    onselectedindexchanged="ddldedtype_SelectedIndexChanged" AutoPostBack="True"                    
                    >
                    <asp:ListItem >BloodGroup</asp:ListItem>
                    <asp:ListItem >JobTypeWise Attendance</asp:ListItem>
                    <asp:ListItem >AreaWise Attendance</asp:ListItem>
                    <asp:ListItem>DepartmentWise Attendance</asp:ListItem>
                    <asp:ListItem>ShiftWise Attendance</asp:ListItem>
                    <asp:ListItem Selected="True">Employee PayDays</asp:ListItem>                                        
                    <asp:ListItem >ShortDuty</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>



         <tr>
           <td class="labelcells">
                FromYearMonth
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txttodate" runat="server" CssClass="textbox"  Width="80px"></asp:TextBox>
                 
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3"
                                runat="server" WatermarkCssClass="watermark" WatermarkText="YrMth ie.201806"
                                TargetControlID="txttodate">
                            </cc1:TextBoxWatermarkExtender>
                <%--       <cc1:CalendarExtender ID="txttodate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txttodate">
                </cc1:CalendarExtender>--%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttodate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>

            <td class="labelcells">
                ToYearMonth
            </td>
            <td class="NormalText">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                <%--       <cc1:CalendarExtender ID="txttodate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txttodate">
                </cc1:CalendarExtender>--%>

                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1"
                                runat="server" WatermarkCssClass="watermark" WatermarkText="YrMth ie.201806"
                                TargetControlID="TextBox1">
                            </cc1:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txttodate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
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
               Department
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddl1" runat="server" CssClass="combobox"
                    >

                    <%-- <asp:ListItem Selected="True">Detail</asp:ListItem>
                    <asp:ListItem>Count</asp:ListItem>--%>
                </asp:DropDownList>
                
            </td>
                     <td class="labelcells">
                Search Emplyoee Name
            </td>
            <td class="NormalText" colspan="3">
                <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" AutoPostBack="True"
                    onkeyup="SetContextKey()" OnTextChanged="txtEmployee_TextChanged" Width="300px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" CompletionInterval="10"
                    CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" MinimumPrefixLength="3"
                    ServiceMethod="LocationWIse_Employee" ServicePath="~/WebService.asmx" TargetControlID="txtEmployee">
                </cc1:AutoCompleteExtender>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmployee"
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
                        <asp:Panel ID="Panel1" runat="server" Height="550px" ScrollBars="Both" Width="950px">
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



