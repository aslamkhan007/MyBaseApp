<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_Workflow_CommonRequest_Entry.aspx.cs" Inherits="Payroll_Jct_Payroll_Workflow_CommonRequest_Entry" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <%-- <script type="text/javascript">
        function SetContextKey() {
            $find('<%=AutoCompleteExtender1.ClientID%>').set_contextKey($get("<%=ddlLocation.ClientID %>").value);
        }
    </script>--%>
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Common WorkFlow Hierarchy Entry :
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
                Area
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="combobox" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                    AutoPostBack="True">
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
                Authorizer Name
            </td>
            <td class="NormalText">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" AutoPostBack="True"
                    onkeyup="SetContextKey()" OnTextChanged="TextBox1_TextChanged" Width="300px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="10"
                    CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" MinimumPrefixLength="3"
                    ServiceMethod="GetEmployee_sh_Common_Sap" ServicePath="~/WebService.asmx"
                    TargetControlID="TextBox1">
                </cc1:AutoCompleteExtender>
            </td>
            <td class="labelcells">
                <asp:Label ID="Label1" runat="server" Text="Authorizer Name"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Level
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
            <td class="NormalText">
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonXL" Height="32px" OnClick="lnkexcel_Click"
                    Width="32px"></asp:LinkButton>
            </td>
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
                <asp:LinkButton ID="lnkFreeze" runat="server" CssClass="buttonc" OnClick="lnkFreeze_Click"
                    ValidationGroup="A">Update</asp:LinkButton>
                <asp:LinkButton ID="lnkFreeze0" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="lnkFreeze0_Click">Back</asp:LinkButton>
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
                            <asp:TemplateField HeaderText="Authorizer">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAut" runat="server" CssClass="textbox" AutoPostBack="True" Text='<%# Eval("ActionTakenBy") %>'
                                        onkeyup="SetContextKey()" Width="200px" OnTextChanged="txtAut_TextChanged"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="10"
                                        CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                        CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" MinimumPrefixLength="3"
                                        ServiceMethod="GetEmployee_sh_Common_Sap" ServicePath="~/WebService.asmx"
                                        TargetControlID="txtAut" >
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
