<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Jct_Payroll_Conveyance_Detail_Report.aspx.cs" Inherits="Payroll_Jct_Payroll_Conveyance_Detail_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<%--    <script type="text/javascript">
        function SetContextKey() {
            $find('<%=txtEmployee_AutoCompleteExtender.ClientID%>').set_contextKey($get("<%=ddlLocation.ClientID %>").value);
        }
    </script>--%>
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                <%--Conveyance
                Calculation Detail Report:--%>
                
                Reimbursement Detail Report:
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 20px">
                 Conveyance Type</td>
            <td class="NormalText" style="height: 20px">
            <asp:DropDownList ID="ddldedtype" runat="server" CssClass="combobox" OnSelectedIndexChanged="ddldedtype_SelectedIndexChanged"
                    AppendDataBoundItems="True" DataTextField="Deduction_Short_Description" 
                    DataValueField="Deduction_code" AutoPostBack="True">

                    <asp:ListItem Selected="True">Reimbursment</asp:ListItem>
                    <asp:ListItem >Reimbursment(ii)</asp:ListItem>
                    <asp:ListItem >LeaveEncashment</asp:ListItem>
                    <asp:ListItem >LTC</asp:ListItem>

                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddldedtype"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                </td>
            <td class="labelcells" style="height: 20px">
                &nbsp;</td>
            <td class="NormalText" style="height: 20px">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 20px">
                YearMonth
            </td>
            <td class="NormalText" style="height: 20px">
                <asp:TextBox ID="txttodate" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                <%--<asp:ListItem Selected="True"></asp:ListItem>--%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttodate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells" style="height: 20px">
                &nbsp;
            </td>
            <td class="NormalText" style="height: 20px">
                &nbsp;
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
                Location
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlLocation" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
               
                Designation</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddldesignation" runat="server" 
                    CssClass="combobox">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                <%--Payment Mode--%>
                </td>
            <td class="NormalText">
                <%--<asp:DropDownList ID="ddlPaymode" runat="server" CssClass="combobox" OnSelectedIndexChanged="ddldedtype_SelectedIndexChanged"
                    AppendDataBoundItems="True" DataTextField="Deduction_Short_Description" DataValueField="Deduction_code">
                    <asp:ListItem>Bank</asp:ListItem>
                    <asp:ListItem>Cash</asp:ListItem>                    
                </asp:DropDownList>--%>
                
            </td>
        </tr>
<%--        <tr>
            <td class="labelcells">
                Designation
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddldesignation" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
        </tr>--%>

 <%--               <tr>
            <td class="labelcells">
                Department
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
        </tr>--%>

<%--        <tr>
            <td class="labelcells">
                Search Emplyoee Name
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" AutoPostBack="True"
                    OnTextChanged="txtEmployee_TextChanged" Width="300px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" CompletionInterval="10"
                    CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" MinimumPrefixLength="3"
                    ServiceMethod="LocationWIse_Employee" ServicePath="~/WebService.asmx" TargetControlID="txtEmployee"
                    UseContextKey="True">
                </cc1:AutoCompleteExtender>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;
            </td>
        </tr>--%>

<%--        <tr>
            <td class="labelcells">
                Search Emplyoee Name</td>
            <td class="NormalText">
                <asp:TextBox ID="txtEmployee" runat="server" AutoPostBack="True" 
                    CssClass="textbox" onkeyup="SetContextKey()" 
                    OnTextChanged="txtEmployee_TextChanged" Width="300px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" 
                    CompletionInterval="10" CompletionListCssClass="AutoExtender" 
                    CompletionListElementID="divwidth" 
                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" 
                    MinimumPrefixLength="3" ServiceMethod="LocationWIse_Employee" 
                    ServicePath="~/WebService.asmx" TargetControlID="txtEmployee" 
                    UseContextKey="True">
                </cc1:AutoCompleteExtender>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>--%>

        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="labelcells">
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonXL" Height="32px" Width="32px"
                    OnClick="lnkexcel_Click"></asp:LinkButton>
            </td>
            <td class="labelcells">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="lnkFetch_Click">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" CausesValidation="False"
                    OnClick="lnkreset_Click">Reset</asp:LinkButton>
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

