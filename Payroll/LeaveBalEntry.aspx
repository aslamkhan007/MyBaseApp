<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="LeaveBalEntry.aspx.cs" Inherits="Payroll_LeaveBalEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Leave Balance 
                Update:
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Year
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="combobox">
                            <asp:ListItem Selected="True">2019</asp:ListItem>
                            <asp:ListItem>2020</asp:ListItem>
                            <asp:ListItem>2021</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
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
                Action
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlplant" runat="server" AutoPostBack="True" CssClass="combobox"
                            OnSelectedIndexChanged="ddlplant_SelectedIndexChanged">
                            <asp:ListItem Selected="True">OpeningBalance</asp:ListItem>
                            <asp:ListItem>Consumption</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlplant"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Search Emplyoee Name
            </td>
          
                    <td class="NormalText" colspan="3">
                      <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                        <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" AutoPostBack="True"
                            OnTextChanged="txtEmployee_TextChanged" Width="300px"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" CompletionInterval="10"
                            CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" MinimumPrefixLength="3"
                            ServiceMethod="GetEmployee_sh_Common_CardNo" ServicePath="~/WebService.asmx"
                            TargetControlID="txtEmployee">
                        </cc1:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmployee"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                    &nbsp; &nbsp;
                </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonXL" Height="32px" Width="32px"
                    OnClick="lnkexcel_Click" Visible="False"></asp:LinkButton>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" OnClick="lnkfetch_Click"
                            ValidationGroup="A">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table class="mytable">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdDetail" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                            Width="100%">
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
                                <asp:BoundField DataField="LeaveType" HeaderText="LeaveType" SortExpression="LeaveType" />
                                <asp:TemplateField HeaderText="Amount">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtPanno" runat="server" CssClass="textbox" Width="35"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />
                            <RowStyle CssClass="GridItem" />
                        </asp:GridView>
                        </td>
                    </ContentTemplate>
                </asp:UpdatePanel>
        </tr>
    </table>
    <table class="mytable">
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkapply" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="lnkadd_Click">Save</asp:LinkButton>
            </td>
        </tr>
    </table>
    <table class="mytable">
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="Label5" runat="server" Text="Leave Consumption" Visible="False"></asp:Label>
                        <asp:GridView ID="GridView1" runat="server" Width="100%" EmptyDataText="No Record Found"
                            EnableModelValidation="True">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <Columns>
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle CssClass="PageStyle" />
                            <RowStyle CssClass="Griditem" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
