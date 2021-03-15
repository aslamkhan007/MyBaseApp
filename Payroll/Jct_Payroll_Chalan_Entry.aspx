<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_Chalan_Entry.aspx.cs" Inherits="Payroll_Jct_Payroll_Chalan_Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Challan Entry :
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="LblReportType" runat="server" Text="Type"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlReporttypes" runat="server" CssClass="combobox" OnSelectedIndexChanged="ddlReporttypes_SelectedIndexChanged"
                    AutoPostBack="True">
                    <%--<asp:ListItem Selected="True">FileBatch</asp:ListItem>
                    <asp:ListItem>ChallanDed</asp:ListItem>
                    <asp:ListItem>Annexture</asp:ListItem>
                    <asp:ListItem>TaxReturn</asp:ListItem>--%>
                    <asp:ListItem Selected="True">ChallanEntry</asp:ListItem>
                    <asp:ListItem>ChallanReport</asp:ListItem>
                    <asp:ListItem>MissingPanNumber</asp:ListItem>
                    <asp:ListItem>QtrAnnexture</asp:ListItem>
                    <asp:ListItem>YearlyAnnexture</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Plant
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlplant" runat="server" AutoPostBack="True" CssClass="combobox"
                            OnSelectedIndexChanged="ddlplant_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlplant"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                YearMonth
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txttodate" runat="server" MaxLength="6" CssClass="textbox" Width="80px"></asp:TextBox>
                        <%--       <cc1:CalendarExtender ID="txttodate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txttodate">
                </cc1:CalendarExtender>--%>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txttodate"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtenderasda3" runat="server" WatermarkCssClass="watermark"
                            WatermarkText="202001" TargetControlID="txttodate">
                        </cc1:TextBoxWatermarkExtender>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                            TargetControlID="txttodate" ValidChars="0123456789">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                SerialNo
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSerialNo" runat="server" CssClass="combobox">
                            <asp:ListItem Selected="True">1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                        </asp:DropDownList>
                        <%--  <asp:TextBox ID="txtSerialNo" runat="server" Style="text-transform: capitalize;"
                    CssClass="textbox" MaxLength="1" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSerialNo"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" WatermarkCssClass="watermark"
                    WatermarkText="1,2,3" TargetControlID="txtSerialNo">
                </cc1:TextBoxWatermarkExtender>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" Enabled="True"
                    TargetControlID="txtSerialNo" ValidChars="123">
                </cc1:FilteredTextBoxExtender>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                EductionCess
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtEductionCess" runat="server" Style="text-transform: capitalize;"
                            CssClass="textbox" MaxLength="8" Width="100px"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEductionCess"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                        <cc1:FilteredTextBoxExtender ID="txtunits_FilteredTextBoxExtender" runat="server"
                            Enabled="True" TargetControlID="txtEductionCess" ValidChars=".0123456789">
                        </cc1:FilteredTextBoxExtender>
                        <%--<cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkCssClass="watermark"
                            WatermarkText="0.00" TargetControlID="txtEductionCess">
                        </cc1:TextBoxWatermarkExtender>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                IntrestPlenty
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtIntrestPlenty" runat="server" Style="text-transform: capitalize;"
                            CssClass="textbox" MaxLength="8" Width="100px"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8545" runat="server" ControlToValidate="txtIntrestPlenty"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4444" runat="server" Enabled="True"
                            TargetControlID="txtIntrestPlenty" ValidChars=".0123456789">
                        </cc1:FilteredTextBoxExtender>
                        <%--<cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender555" runat="server" WatermarkCssClass="watermark"
                            WatermarkText="0.00" TargetControlID="txtIntrestPlenty">
                        </cc1:TextBoxWatermarkExtender>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Fee
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtFee" runat="server" Style="text-transform: capitalize;" CssClass="textbox"
                            MaxLength="8" Width="100px"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtFee"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtende224r4" runat="server" Enabled="True"
                            TargetControlID="txtFee" ValidChars=".0123456789">
                        </cc1:FilteredTextBoxExtender>
                        <%--<cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" WatermarkCssClass="watermark"
                            WatermarkText="0.00" TargetControlID="txtFee">
                        </cc1:TextBoxWatermarkExtender>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                PlentyOthers
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtPlentyOthers" runat="server" Style="text-transform: capitalize;"
                            CssClass="textbox" MaxLength="8" Width="100px"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3754559" runat="server" ControlToValidate="txtPlentyOthers"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender854454" runat="server" Enabled="True"
                            TargetControlID="txtPlentyOthers" ValidChars=".0123456789">
                        </cc1:FilteredTextBoxExtender>
                        <%--<cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender644kj" runat="server" WatermarkCssClass="watermark"
                            WatermarkText="0.00" TargetControlID="txtPlentyOthers">
                        </cc1:TextBoxWatermarkExtender>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                BRSCode
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtBRSCode" runat="server" Style="text-transform: capitalize;" CssClass="textbox"
                            MaxLength="7" Width="100px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator954kl" runat="server" ControlToValidate="txtBRSCode"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4545k" runat="server" Enabled="True"
                            TargetControlID="txtBRSCode" ValidChars="0123456789">
                        </cc1:FilteredTextBoxExtender>
                        <%--<cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6jj" runat="server" WatermarkCssClass="watermark"
                            WatermarkText="1254" TargetControlID="txtBRSCode">
                        </cc1:TextBoxWatermarkExtender>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                DateOfDeposit
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtDateOfDeposit" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txttodate_CalendarExtender" runat="server" Enabled="True"
                            TargetControlID="txtDateOfDeposit">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtDateOfDeposit"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                ChallanNo
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtChallanNo" runat="server" Style="text-transform: capitalize;"
                            CssClass="textbox" MaxLength="5" Width="100px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator564554544" runat="server" ControlToValidate="txtChallanNo"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender544545451" runat="server"
                            Enabled="True" TargetControlID="txtChallanNo" ValidChars="0123456789">
                        </cc1:FilteredTextBoxExtender>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" WatermarkCssClass="watermark"
                            WatermarkText="12345" TargetControlID="txtChallanNo">
                        </cc1:TextBoxWatermarkExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                ModeOfDeposit
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlModeOfDeposit" runat="server" CssClass="combobox">
                            <asp:ListItem Selected="True">Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                IntrestAllocated
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtIntrestAllocated" runat="server" Style="text-transform: capitalize;"
                            CssClass="textbox" MaxLength="8" Width="100px"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator45l5" runat="server" ControlToValidate="txtIntrestAllocated"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender25444564" runat="server"
                            Enabled="True" TargetControlID="txtIntrestAllocated" ValidChars=".0123456789">
                        </cc1:FilteredTextBoxExtender>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender564jkj3" runat="server"
                            WatermarkCssClass="watermark" WatermarkText="0.0" TargetControlID="txtIntrestAllocated">
                        </cc1:TextBoxWatermarkExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <%-- YearQtr--%>
            </td>
            <td class="NormalText">
                <%-- <asp:DropDownList ID="ddYearQtr" runat="server" CssClass="combobox">
                    <asp:ListItem Selected="True">Q1</asp:ListItem>
                    <asp:ListItem>Q2</asp:ListItem>
                    <asp:ListItem>Q3</asp:ListItem>
                    <asp:ListItem>Q4</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddYearQtr"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            </td>
            <td class="labelcells">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkexcel0" runat="server" Visible="false" CssClass="buttonXL"
                            Height="32px" OnClick="lnkexcel_Click" Width="32px"></asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" ValidationGroup="A"
                            OnClick="lnkfetch_Click">Save</asp:LinkButton>
                        <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" Visible="False"
                            Width="1000px">
                            <asp:GridView ID="grdDetail" runat="server" Width="100%" EmptyDataText="No Record Found">
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
