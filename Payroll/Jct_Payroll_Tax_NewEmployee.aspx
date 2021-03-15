<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_Tax_NewEmployee.aspx.cs" Inherits="Payroll_Jct_Payroll_Tax_NewEmployee" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Tax New Employee :
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                FIYear
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txttodate" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttodate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
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
                Search Emplyoee Name
            </td>
           <%-- <td class="NormalText" colspan="3">
                <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" AutoPostBack="True"                    
                     OnTextChanged="txtEmployee_TextChanged" Width="300px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" CompletionInterval="10"
                    CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" MinimumPrefixLength="3"
                    ServiceMethod="LocationWIse_Employee" ServicePath="~/WebService.asmx" TargetControlID="txtEmployee">
                </cc1:AutoCompleteExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmployee"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                &nbsp; &nbsp;
            </td>--%>
                       <td class="NormalText" colspan="3">
                <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" AutoPostBack="True"
                    OnTextChanged="txtEmployee_TextChanged" Width="300px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" CompletionInterval="10"
                    CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" MinimumPrefixLength="3"
                    ServiceMethod="GetEmployee_sh_Common" ServicePath="~/WebService.asmx" TargetControlID="txtEmployee">
                </cc1:AutoCompleteExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmployee"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonXL" Height="32px" OnClick="lnkexcel_Click"
                    Width="32px"></asp:LinkButton>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" OnClick="lnkadd_Click"
                    ValidationGroup="A">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
    </table>
    <table class="mytable">

     <tr>
            <td class="NormalText" colspan="4">
               <%-- <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>--%>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="950px">
                            <asp:GridView ID="grdDetail" runat="server" Width="100%" EmptyDataText="No Record Found"
                                EnableModelValidation="True">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>                                  
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PageStyle" />
                                <RowStyle CssClass="Griditem" />
                            </asp:GridView>
                        </asp:Panel>
                   <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
        </tr>
         </table>
</asp:Content>
