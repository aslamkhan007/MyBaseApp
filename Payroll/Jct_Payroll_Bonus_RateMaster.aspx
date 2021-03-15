<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_Bonus_RateMaster.aspx.cs" Inherits="Payroll_Jct_Payroll_Bonus_RateMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Bonus Rate
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                FY Period:
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtfypd" MaxLength="7" runat="server" CssClass="textbox" Width="80px" ToolTip="2019-20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtfypd"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                <%--cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtendesasdasdasdasr1" runat="server"
                    WatermarkCssClass="watermark" WatermarkText="2020-21" TargetControlID="txtfypd">
                </cc1:TextBoxWatermarkExtender>--%>
               <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtendasasdasder2" runat="server"
                    Enabled="True" TargetControlID="txtfypd" ValidChars="-.0123456789">
                </cc1:FilteredTextBoxExtender>
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
                FromPeriod
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtFromPeriod" runat="server" CssClass="textbox" Width="80px" ToolTip="202001" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtFromPeriod"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
          <%--      <cc1:TextBoxWatermarkExtender ID="TextBoxWatermaasdasasrkExtender1" runat="server"
                    WatermarkCssClass="watermark" WatermarkText="202001" TargetControlID="txtFromPeriod">
                </cc1:TextBoxWatermarkExtender>--%>
               <cc1:FilteredTextBoxExtender ID="FilteasdasredTextBoxExtender2" runat="server" Enabled="True"
                    TargetControlID="txtFromPeriod" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td class="labelcells">
                ToPeriod
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtToPeriod" runat="server" CssClass="textbox" ToolTip="202001" Width="80px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtToPeriod"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
               <%-- <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtasddasdender1" runat="server"
                    WatermarkCssClass="watermark" WatermarkText="202001" TargetControlID="txtToPeriod">
                </cc1:TextBoxWatermarkExtender>--%>
              <cc1:FilteredTextBoxExtender ID="FilteredTextBasasdsoxExtender2" runat="server" Enabled="True"
                    TargetControlID="txtToPeriod" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Category
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="combobox">
                    <asp:ListItem>UnSkilled</asp:ListItem>
                    <asp:ListItem>SemiSkilled</asp:ListItem>
                    <asp:ListItem>Skilled</asp:ListItem>
                    <asp:ListItem>HighlySkilled</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                <asp:Label ID="lblComponentNature" runat="server" Text="Rate"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtrate" runat="server" MaxLength="6" CssClass="textbox" Width="80px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatoasdr1" runat="server" ControlToValidate="txtrate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
               <%-- <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtenasdderasda3" runat="server"
                    WatermarkCssClass="watermark" WatermarkText="202001" TargetControlID="txtrate">
                </cc1:TextBoxWatermarkExtender>--%>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                    TargetControlID="txtrate" ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" OnClick="lnksave_Click"
                    ValidationGroup="A">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" OnClick="lnkupdate_Click"
                    ValidationGroup="A">Update</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
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
            </td>
        </tr>
    </table>
</asp:Content>
