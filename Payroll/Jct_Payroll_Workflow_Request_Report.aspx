<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Jct_Payroll_Workflow_Request_Report.aspx.cs" Inherits="Payroll_Jct_Payroll_Workflow_Request_Report" %>


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
                WorkFlow Hierarchy Report :
            </td>
        </tr>

                <tr>
            <td class="labelcells">
                Report Type
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddldedtype" runat="server" CssClass="combobox"
                    AppendDataBoundItems="True"                    
                    AutoPostBack="True" 
                    onselectedindexchanged="ddldedtype_SelectedIndexChanged">
                     <asp:ListItem  >LeaveHierarchy</asp:ListItem>
                    <asp:ListItem Selected="True">LeaveHierarchy With Others WorkFlow</asp:ListItem>                    
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
                Requester Name
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
                <asp:Label ID="employeename" runat="server" Text="Requester Name"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="lblEmployeeName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="lblauthname" runat="server"> Authorizer</asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" AutoPostBack="True"
                    onkeyup="SetContextKey()" OnTextChanged="TextBox1_TextChanged" Width="300px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="10"
                    CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" MinimumPrefixLength="3"
                    ServiceMethod="LocationWIse_Employee_Sapcode" ServicePath="~/WebService.asmx"
                    TargetControlID="TextBox1" UseContextKey="True">
                </cc1:AutoCompleteExtender>
            </td>
            <td class="labelcells">
                <asp:Label ID="LlbAuthname1" runat="server" Text="Authorizer Name"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="lblLevel" runat="server"> Level</asp:Label>
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
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
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" 
                    OnClick="lnksave_Click">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" CausesValidation="False"
                    OnClick="lnkreset_Click">Reset</asp:LinkButton>
                
                <asp:LinkButton ID="lnkreset0" runat="server" CssClass="buttonc" CausesValidation="False"
                    OnClick="lnkreset_Click">Back</asp:LinkButton>
                
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="1000px">
                    <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="True"
                       >
                        <Columns>
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


