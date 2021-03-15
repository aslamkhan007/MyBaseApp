<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_IncomeTaxReturn_FileBatchHeader.aspx.cs" Inherits="Payroll_Jct_Payroll_IncomeTaxReturn_FileBatchHeader" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                File Batch Header :
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

                    <asp:ListItem Selected="True" >ChallanEntry</asp:ListItem>
                    <asp:ListItem>ChallanReport</asp:ListItem>
                    <asp:ListItem>MissingPanNumber</asp:ListItem>
                    <asp:ListItem>Annexture</asp:ListItem>
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
                <asp:DropDownList ID="ddlplant" runat="server" AutoPostBack="True" CssClass="combobox"
                    OnSelectedIndexChanged="ddlplant_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlplant"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                FHDate
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtFHDate" runat="server" Style="text-transform: capitalize;" CssClass="textbox"
                    MaxLength="8" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFHDate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" WatermarkCssClass="watermark"
                    WatermarkText="17102019" TargetControlID="txtFHDate">
                </cc1:TextBoxWatermarkExtender>

                   <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                    Enabled="True" TargetControlID="txtFHDate" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>

            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                BHToken
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtBHToken" runat="server" Style="text-transform: capitalize;" CssClass="textbox"
                    MaxLength="15" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBHToken"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                <cc1:FilteredTextBoxExtender ID="txtunits_FilteredTextBoxExtender" runat="server"
                    Enabled="True" TargetControlID="txtBHToken" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkCssClass="watermark"
                    WatermarkText="700000045591976" TargetControlID="txtBHToken">
                </cc1:TextBoxWatermarkExtender>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                BHAssmentYr
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtBHAssmentYr" runat="server" Style="text-transform: capitalize;"
                    CssClass="textbox" MaxLength="6" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBHAssmentYr"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                    TargetControlID="txtBHAssmentYr" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" WatermarkCssClass="watermark"
                    WatermarkText="202021" TargetControlID="txtBHAssmentYr">
                </cc1:TextBoxWatermarkExtender>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                BHFinancialYr
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtBHFinancialYr" runat="server" Style="text-transform: capitalize;"
                    CssClass="textbox" MaxLength="6" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtBHFinancialYr"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True"
                    TargetControlID="txtBHFinancialYr" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" WatermarkCssClass="watermark"
                    WatermarkText="201920" TargetControlID="txtBHFinancialYr">
                </cc1:TextBoxWatermarkExtender>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                YearQtr
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddYearQtr" runat="server" CssClass="combobox">
                    <asp:ListItem Selected="True">Q1</asp:ListItem>
                    <asp:ListItem>Q2</asp:ListItem>
                    <asp:ListItem>Q3</asp:ListItem>
                    <asp:ListItem>Q4</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddYearQtr"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                <asp:LinkButton ID="lnkexcel0" runat="server" CssClass="buttonXL" Height="32px" OnClick="lnkexcel_Click"
                    Width="32px"></asp:LinkButton>
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
                    OnClick="lnkfetch_Click">Fetch</asp:LinkButton>
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
