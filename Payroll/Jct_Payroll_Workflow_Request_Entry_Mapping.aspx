<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Jct_Payroll_Workflow_Request_Entry_Mapping.aspx.cs" Inherits="Payroll_Jct_Payroll_Workflow_Request_Entry_Mapping" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function SetContextKey() {
            $find('<%=AutoCompleteExtender1.ClientID%>').set_contextKey($get("<%=ddlLocation.ClientID %>").value);
        }
    </script>
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                WorkFlow Hierarchy Mapping(Left Employees) :
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Area
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="combobox" AutoPostBack="True"
                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
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
                <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlplant_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                Location
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlLocation" runat="server" CssClass="combobox" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                PreviousEmp
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" AutoPostBack="True"
                    onkeyup="SetContextKey()" OnTextChanged="txtEmployee_TextChanged" Width="300px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="10"
                    CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" MinimumPrefixLength="3"
                    ServiceMethod="LocationWIse_Employee_Sapcode" ServicePath="~/WebService.asmx"
                    TargetControlID="txtEmployee" UseContextKey="True">
                </cc1:AutoCompleteExtender>
            </td>
            <td class="labelcells">
                PreviousEmpName</td>
            <td class="labelcells">
                <asp:Label ID="lblEmployeeName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" OnClick="lnksave_Click"
                    ValidationGroup="A">Apply</asp:LinkButton>



                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" CausesValidation="False"
                    OnClick="lnkreset_Click">Reset</asp:LinkButton>

                    <asp:LinkButton ID="LinkButton1del" runat="server" CssClass="buttonc" 
                    ValidationGroup="A" onclick="LinkButton1del_Click">Delete</asp:LinkButton>

                
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="1000px">
                    <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                        OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkRemoveALL" runat="server" AutoPostBack="True" OnCheckedChanged="chkRemoveALL_CheckedChanged" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkRemove" OnCheckedChanged="chkRemove_CheckedChanged"
                                        AutoPostBack="True" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Level">
                                <ItemTemplate>
                                    <asp:Label ID="lblSrNo" runat="server" Text='<%# Eval("Level") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Requester">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtReq" runat="server" CssClass="textbox" AutoPostBack="True" Text='<%# Eval("RequsterCode") %>'
                                        onkeyup="SetContextKey()" Width="200px" OnTextChanged="txtReq_TextChanged"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" CompletionInterval="10"
                                        CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                        CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" MinimumPrefixLength="3"
                                        ServiceMethod="LocationWIse_Employee_Sapcode" ServicePath="~/WebService.asmx"
                                        TargetControlID="txtReq" UseContextKey="True">
                                    </cc1:AutoCompleteExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Req.Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("RName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Authorizer">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAut" runat="server" CssClass="textbox" AutoPostBack="True" Text='<%# Eval("ActionTakenBy") %>'
                                        onkeyup="SetContextKey()" Width="200px" OnTextChanged="txtAut_TextChanged"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="10"
                                        CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                        CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" MinimumPrefixLength="3"
                                        ServiceMethod="LocationWIse_Employee_Sapcode" ServicePath="~/WebService.asmx"
                                        TargetControlID="txtAut" UseContextKey="True">
                                    </cc1:AutoCompleteExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Auth.Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName1" runat="server" Text='<%# Eval("AName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GirdItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>


