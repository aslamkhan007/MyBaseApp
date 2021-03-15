<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_payroll_PortalMenuRights.aspx.cs" Inherits="Payroll_Jct_payroll_PortalMenuRights" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                MenuRights:
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Type</td>
            <td class="labelcells">
                <asp:RadioButtonList ID="rblChoices" runat="server" 
                    RepeatDirection ="Horizontal" 
                    onselectedindexchanged="rblChoices_SelectedIndexChanged" 
                    AutoPostBack="True">
                    <asp:ListItem Text="RoleBased" Value="RoleBased" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="UserBased" Value="UserBased"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                
                   <asp:Label ID="lblrole" runat="server" Text="Role" Visible = "false"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox"  Visible = "false"
                            AutoPostBack="True" onselectedindexchanged="ddlplant_SelectedIndexChanged">
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
                
                <asp:Label ID="lblemployeename" runat="server" Text="Search Emplyoee Name" Visible = "false"></asp:Label>
            </td>
            <td class="NormalText" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" AutoPostBack="True" Visible = "false"
                            OnTextChanged="txtEmployee_TextChanged" Width="300px"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" CompletionInterval="10"
                            CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" MinimumPrefixLength="3"
                            ServiceMethod="GetEmployee_sh_Common" ServicePath="~/WebService.asmx"
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
                &nbsp;
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" OnClick="lnkfetch_Click"
                            ValidationGroup="A">Apply</asp:LinkButton>
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
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkall" runat="server" AutoPostBack="True" OnCheckedChanged="chkall_CheckedChanged" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" AutoPostBack="True" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="MenuName" HeaderText="MenuName" SortExpression="MenuName" />
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />
                            <RowStyle CssClass="GridItem" />
                        </asp:GridView>
                        </td>
                    </ContentTemplate>
                </asp:UpdatePanel>
        </tr>
    </table>
   <%-- <table class="mytable">
        <tr>
            <td class="buttonbackbar" colspan="4">
                &nbsp;
            </td>
        </tr>
    </table>
    <table class="mytable">
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>--%>
</asp:Content>
