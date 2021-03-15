<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="payroll_electricity_bill.aspx.cs" Inherits="PayRoll_payroll_electricity_bill" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function SetContextKey() {
            //            $find('<%=txtEmployee_AutoCompleteExtender.ClientID%>').set_contextKey($get("<%=ddlhousetype.ClientID %>").value);
            $find('<%=txtEmployee_AutoCompleteExtender.ClientID%>').set_contextKey($get("<%=ddlplant.ClientID %>").value);
        }
    </script>
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Electricity Consumption Entry:
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Plant
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlplant_SelectedIndexChanged">
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
                From Date
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtfromdate" runat="server" CssClass="textbox" Width="70px" OnTextChanged="txtfromdate_TextChanged"
                            AutoPostBack="True"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtfromdate_CalendarExtender" runat="server" Enabled="True"
                            TargetControlID="txtfromdate">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfromdate"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                ToDate
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txttodate" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txttodate_CalendarExtender" runat="server" Enabled="True"
                            TargetControlID="txttodate">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttodate"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                House Type
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlhousetype" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                            CssClass="combobox" OnSelectedIndexChanged="ddlhousetype_SelectedIndexChanged1"
                            ValidationGroup="A">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%--                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlhousetype"
                    ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>--%>
            </td>
            <td class="labelcells">
                Employee Name
            </td>
            <td>
                <%--             <asp:TextBox ID="txtEmployee" runat="server" AutoPostBack="True" CssClass="textbox"
                    OnTextChanged="txtEmployee_TextChanged" ValidationGroup="B" CausesValidation="True"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" CompletionListCssClass="autocomplete_ListItem1"
                    Enabled="True" MinimumPrefixLength="1" ServiceMethod="LocationWIse_Employee_Bill"
                    ServicePath="~/WebService.asmx" TargetControlID="txtEmployee">
                </cc1:AutoCompleteExtender>
                --%>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtEmployee" runat="server" AutoPostBack="True" CssClass="textbox"
                            onkeyup="SetContextKey()" OnTextChanged="txtEmployee_TextChanged" ValidationGroup="B"
                            CausesValidation="True" Width="200px"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" CompletionInterval="10"
                            CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" MinimumPrefixLength="3"
                            ServiceMethod="LocationWIse_Employee_Bill" ServicePath="~/WebService.asmx" TargetControlID="txtEmployee"
                            UseContextKey="True">
                        </cc1:AutoCompleteExtender>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkCssClass="watermark"
                            WatermarkText="Single Employee Search" TargetControlID="txtEmployee">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="searchbluesmall" Height="16px"
                            OnClick="LinkButton1_Click" ValidationGroup="B" Width="16px">LinkButton</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
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
                <asp:Label ID="lblElectricityBill" runat="server" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                            <ProgressTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/OPS/Image/loadingNew.gif" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="1500px" ScrollBars="Vertical" Visible="False"
                            Width="1000px">
                            <asp:GridView ID="grdDetail" runat="server" Width="100%" EnableModelValidation="True"
                                OnRowDataBound="grdDetail_RowDataBound" AutoGenerateColumns="False">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <%--                <HeaderTemplate>
                                    <asp:CheckBox ID="chksel" runat="server" 
                                        oncheckedchanged="chksel_CheckedChanged" Text="SelectAll" 
                                        AutoPostBack="True" />
                                </HeaderTemplate>--%>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkall" runat="server" AutoPostBack="True" OnCheckedChanged="chkall_CheckedChanged"
                                                 />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk" runat="server" AutoPostBack="True" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="employeecode" HeaderText="EmployeeCode" />
                                    <asp:BoundField DataField="Employee" HeaderText="Employee" />
                                    <asp:BoundField DataField="Department" HeaderText="Department" />
                                    <asp:BoundField DataField="Designation" HeaderText="Designation" />
                                    <asp:BoundField DataField="HouseType" HeaderText="HouseType" />
                                    <asp:BoundField DataField="Houseno" HeaderText="HouseNo" />
                                    <asp:TemplateField HeaderText="Units">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtunits" runat="server" CssClass="textbox" AutoPostBack="True"
                                                OnTextChanged="txtunits_TextChanged" Width="35"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtunits_FilteredTextBoxExtender" runat="server"
                                                Enabled="True" TargetControlID="txtunits" ValidChars="0123456789">
                                            </cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="UnitRate">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtunitrate" runat="server" CssClass="textbox" Text='<%# Eval("unitrate") %>'
                                                Enabled="False" Width="30" TabIndex="1"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtunitrate_FilteredTextBoxExtender" runat="server"
                                                Enabled="True" TargetControlID="txtunitrate" ValidChars=".0123456789">
                                            </cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtamount" runat="server" CssClass="textbox" Width="40" Enabled="False"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <asp:CheckBox ID="chk" runat="server" AutoPostBack="False" />
                                </EmptyDataTemplate>
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
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" OnClick="lnksave_Click"
                            ValidationGroup="A">Save</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" OnClick="lnkReset_Click"
                            ValidationGroup="A">Reset</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset0" runat="server" CssClass="buttonc" OnClick="lnkReset0_Click"
                            ValidationGroup="A">Report</asp:LinkButton>
                        <asp:LinkButton ID="LnkAuth" runat="server" CssClass="buttonc" OnClick="LnkAuth_Click"
                            ValidationGroup="A">Freeze</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>

        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:UpdateProgress ID="UpdateProgress13" runat="server">
                            <ProgressTemplate>
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/OPS/Image/loadingNew.gif" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>

        <tr>
            <td class="labelcells" colspan="4">
                <asp:Label ID="lblShowDetail" runat="server" Visible="False">Entered Bill Details:</asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel2" runat="server" Height="200px" ScrollBars="Vertical" Width="1000px"
                            Visible="False">
                            <asp:GridView ID="grdDetailList" runat="server" Width="100%" EnableModelValidation="True"
                                AutoGenerateColumns="False">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkall1" runat="server" AutoPostBack="True" OnCheckedChanged="chkall1_CheckedChanged"
                                                 />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk" runat="server" AutoPostBack="True" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="EmployeeCode" HeaderText="EmployeeCode" />
                                    <asp:BoundField DataField="EmployeeName" HeaderText="EmployeeName" />
                                    <asp:BoundField DataField="Department" HeaderText="Department" />
                                    <asp:BoundField DataField="Desigination" HeaderText="Desigination" />
                                    <asp:BoundField DataField="HouseType" HeaderText="HouseType" />
                                    <asp:BoundField DataField="HouseNo" HeaderText="HouseNo" />
                                    <asp:TemplateField HeaderText="Units">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtunits1" runat="server" CssClass="textbox" Text='<%# Eval("Units") %>'
                                                AutoPostBack="True" OnTextChanged="txtunits1_TextChanged" Width="35"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtunits_FilteredTextBoxExtender" runat="server"
                                                Enabled="True" TargetControlID="txtunits1" ValidChars="0123456789">
                                            </cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="UnitRate">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtunitrate" runat="server" CssClass="textbox" Text='<%# Eval("UnitRate") %>'
                                                Enabled="False" Width="30"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtunitrate_FilteredTextBoxExtender" runat="server"
                                                Enabled="True" TargetControlID="txtunitrate" ValidChars=".0123456789">
                                            </cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtamount" runat="server" CssClass="textbox" Width="40"  Text='<%# Eval("Amount") %>'
                                                Enabled="False"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <asp:CheckBox ID="chk" runat="server" />
                                </EmptyDataTemplate>
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
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkUpdate" runat="server" CssClass="buttonc" OnClick="lnkUpdate_Click"
                            ValidationGroup="A" Visible="False">Update</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
