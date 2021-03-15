<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_Skill_Detail.aspx.cs" Inherits="Payroll_Jct_Payroll_Skill_Detail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td class="tableheader" colspan="4">
                Skill Details:
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Employee Code:
            </td>
            <td class="NormalText">
                <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>--%>
                        <asp:TextBox ID="txtEmpCode" runat="server" Style="text-transform: capitalize;" CssClass="textbox"
                            OnTextChanged="txtEmpCode_TextChanged" AutoPostBack="True" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmpCode"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                 <%--   </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
            <td class="labelcells">
                <asp:Label ID="SrCode" runat="server" Text="Sr No" Visible="False"></asp:Label>
            </td>
            <td class="labelcells" colspan="2">
                <asp:Label ID="SrId" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Skill
            </td>
            <td class="NormalText" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlskill" runat="server" CssClass="combobox" AutoPostBack="True"
                            Width="300px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlskill"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Technology
            </td>
            <td class="NormalText" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlTechnology" runat="server" CssClass="combobox" AutoPostBack="True"
                            Width="300px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlTechnology"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Experience
            </td>
            <td class="NormalText" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtExpYears" runat="server" Style="text-transform: capitalize;"
                            CssClass="textbox" AutoPostBack="True" Width="50px" MaxLength="2"></asp:TextBox>&nbsp
                        &nbsp
                        <asp:Label ID="lblExpYears" runat="server" CssClass="labelcells" Text="Years"></asp:Label>&nbsp
                        &nbsp
                        <asp:TextBox ID="TxtExpMonths" runat="server" Style="text-transform: capitalize;"
                            CssClass="textbox" AutoPostBack="True" Width="50px" MaxLength="2"></asp:TextBox>
                        <asp:Label ID="lblExpMonths" runat="server" CssClass="labelcells" Text="Months"></asp:Label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^[0-9]{2}$"
                            ErrorMessage="Enter No. Of Years" ControlToValidate="TxtExpYears" 
                            ValidationGroup="A"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression="^[0-9]{2}$"
                            ErrorMessage="Enter No. Of Months" ControlToValidate="TxtExpMonths" 
                            ValidationGroup="A"></asp:RegularExpressionValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Last Used
            </td>
            <td class="NormalText" colspan="3">
             <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                <asp:TextBox ID="TxtLastUsed" runat="server" Style="text-transform: capitalize;"
                    CssClass="textbox" AutoPostBack="True" Width="100px" MaxLength="12"></asp:TextBox>
                <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" Width="114px" ControlToValidate="TxtLastUsed"
                    Display="Dynamic" ControlExtender="MaskedEditExtender3" TooltipMessage="MM/DD/YYYY"
                    IsValidEmpty="False" EmptyValueMessage="*" InvalidValueMessage="The Date is invalid"></cc1:MaskedEditValidator>
                <cc1:CalendarExtender ID="CalFrom1" runat="server" TargetControlID="TxtLastUsed"
                    Animated="False" Format="MM/dd/yyyy" PopupPosition="TopLeft">
                </cc1:CalendarExtender>
                <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="TxtLastUsed"
                    MaskType="Date" Mask="99/99/9999">
                </cc1:MaskedEditExtender>
                        </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Remarks
            </td>
            <td class="NormalText" colspan="3">
             <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                <asp:TextBox ID="TxtRemarks" runat="server" Style="text-transform: capitalize;" CssClass="textbox"
                    AutoPostBack="false" Width="250px" MaxLength="80"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtRemarks"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                      </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="lnkadd_Click">Add</asp:LinkButton>
             <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="lnkupdate_Click" Enabled="False">Update</asp:LinkButton>
              <asp:LinkButton ID="lnkdelete" runat="server" CssClass="buttonc" 
                    OnClick="lnkdelete_Click" Enabled="False">Delete</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
                       </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" Visible="False"
                            Width="1000px">
                            <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True" Width="100%"
                                OnSelectedIndexChanged="grdDetail_SelectedIndexChanged">
                                <AlternatingRowStyle CssClass="GridAI" />
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
    </table>
</asp:Content>
