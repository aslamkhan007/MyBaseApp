<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true"
    CodeFile="QualityAnalysisReport.aspx.cs" Inherits="OPS_QualityAnalysisReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="tableheader" colspan="4">
                Quality Analysis Report
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                DateFrom
            </td>
            <td style="width: 234px">
                <asp:TextBox ID="txtdatefrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdatefrom_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txtdatefrom">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdatefrom"
                    Display="Dynamic" ErrorMessage="cant be blank" SetFocusOnError="True"> </asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                DateTo
            </td>
            <td>
                <asp:TextBox ID="txtdateto" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdateto_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txtdateto">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdateto"
                    Display="Dynamic" ErrorMessage="cant be blank" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                OrderNo
            </td>
            <td style="width: 234px">
                <asp:TextBox ID="txtorderno" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                TestedBy
            </td>
            <td>
                <asp:TextBox ID="txttestedby" runat="server" CssClass="textbox" OnTextChanged="txttestedby_TextChanged"></asp:TextBox>
                <%-- <cc1:AutoCompleteExtender ID="txttestedby_AutoCompleteExtender" runat="server" 
                    FirstRowSelected="True" ServiceMethod="GetEmpName" 
                    TargetControlID="txttestedby" UseContextKey="True" 
                    CompletionInterval="100" CompletionSetCount="100" 
                    ServicePath="~/webservice.asmx" 
                    CompletionListCssClass="autocomplete_completionListElement">

                </cc1:AutoCompleteExtender>--%>
                <div id="div1" style="display: none;">
                    <cc1:AutoCompleteExtender ID="txttestedby_AutoCompleteExtender" runat="server" CompletionInterval="10"
                        CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="GetEmployee_OPS"
                        CompletionListElementID="div1" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                        CompletionListItemCssClass="AutoExtenderList" ServicePath="~/WebService.asmx"
                        TargetControlID="txttestedby">
                    </cc1:AutoCompleteExtender>
                </div>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                SortNo
            </td>
            <td style="width: 234px">
                <asp:TextBox ID="txtsortno" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                Result
            </td>
            <td>
                <asp:DropDownList ID="ddlresult" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Pass</asp:ListItem>
                    <asp:ListItem>Fail</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                &nbsp;
                <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" OnClick="lnkFetch_Click">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" OnClick="lnkReset_Click">Reset</asp:LinkButton>
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonc" OnClick="lnkexcel_Click">Excel</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Panel ID="Panel1" runat="server" Height="300px" ScrollBars="Both" 
                    Width="95%">
                    <asp:GridView ID="grdDetail" runat="server" EmptyDataText="no record found" Width="100%">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="width: 234px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
