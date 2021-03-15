<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_Leave_Cancel.aspx.cs" Inherits="Payroll_Jct_Payroll_Leave_Cancel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
              Request Cancell/Authorize:
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label7" runat="server" Text="Category"></asp:Label>
            </td>
            <td class="NormalText" colspan="3">
                <asp:DropDownList ID="Drpcat" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="Drpcat_SelectedIndexChanged" >
                 <asp:ListItem>Compensatory</asp:ListItem>
                    <asp:ListItem Selected="True">Leave</asp:ListItem>
                    <asp:ListItem >AdminAuthrize</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label8" runat="server" Text="Action"></asp:Label>
            </td>
            <td class="NormalText" colspan="3">
                <asp:DropDownList ID="Drpaction" runat="server" >
                <%--    <asp:ListItem>Authorise</asp:ListItem>
                    <asp:ListItem Selected="True">Cancel</asp:ListItem>--%>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Leave ID
            </td>
            <td class="NormalText" colspan="3">
                <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmployee"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>


                        <asp:RequiredFieldValidator ID="ssss" runat="server" Width="80px"
                    ErrorMessage="*" ControlToValidate="txtEmployee" SetFocusOnError="True"
                    ValidationGroup="B"></asp:RequiredFieldValidator>


                    <cc1:FilteredTextBoxExtender ID="txtunits_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" TargetControlID="txtEmployee" ValidChars="0123456789">
                                    </cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Remarks(In Brief)
            </td>
            <td class="NormalText" colspan="3">
                <asp:TextBox ID="txtReasonForCancel" runat="server" Width="344px" CssClass="textbox"
                    MaxLength="200" ToolTip="Briefly Describe Reason For Cancellation ." Height="40px"
                    TextMode="MultiLine" ValidationGroup="mandatory"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Width="80px"
                    ErrorMessage="*" ControlToValidate="txtReasonForCancel" SetFocusOnError="True"
                    ValidationGroup="B"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonXL" Height="32px" Width="32px"
                    OnClick="lnkexcel_Click"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" OnClick="lnkadd_Click"
                    ValidationGroup="A">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
           <tr>
            <td class="NormalText" colspan="4">
                <asp:Panel ID="Panel4" runat="server" Height="200px" 
                    Visible="False" Width="1000px">
                    <asp:GridView ID="grdDetail" runat="server" 
                    Width="100%">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>
            </td>
       
       
       
        </tr>

    </table>              
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <table class="mytable">
            <tr>
                <td class="buttonbackbar" colspan="4">
                    <asp:LinkButton ID="lnkapply" runat="server" CssClass="buttonc" ValidationGroup="B"
                        OnClick="lnkapply_Click">Apply</asp:LinkButton>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
