<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Payroll_Salary_Bank_Advice_Crystal.aspx.cs" Inherits="Payroll_Payroll_Salary_Bank_Advice_Crystal" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Bank Advice 1
            </td>
        </tr>

           <tr>
            <td class="labelcells">
                Action Area
            </td>
            <td class="NormalText">
                <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                        <asp:DropDownList ID="ddlActionArea" runat="server" CssClass="combobox"  AutoPostBack="True" 
                            Width="200px" onselectedindexchanged="ddlActionArea_SelectedIndexChanged">
                            <asp:ListItem>AdviceUpload</asp:ListItem>
                            <asp:ListItem Selected ="True">AdviceDetail</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlActionArea"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
             <%--       </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
            <td class="labelcells">
                Category
            </td>
            <td class="NormalText">
                <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>--%>
                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="combobox" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                            <asp:ListItem>Salary</asp:ListItem>
                            <asp:ListItem>Overtime</asp:ListItem>
                            <asp:ListItem>Bonus</asp:ListItem>
                            <asp:ListItem>SalaryAdvance</asp:ListItem>
                            <asp:ListItem>LTA</asp:ListItem>
                        </asp:DropDownList>
            <%--        </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
        </tr>

        <tr>
            <td class="labelcells" style="height: 25px">
                YearMonth
            </td>
            <td class="NormalText" style="height: 25px">
                <asp:TextBox ID="txtMonth" runat="server" Style="text-transform: capitalize;" CssClass="textbox"
                    AutoPostBack="True" MaxLength="10" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMonth"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells" style="height: 25px">
            </td>
            <td class="NormalText" style="height: 25px">
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 25px">
                Plant
            </td>
            <td class="NormalText" style="height: 25px">
                <%--    <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" 
                    AutoPostBack="True" Width="200px" 
                    onselectedindexchanged="ddlplant_SelectedIndexChanged">
                     </asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="ddlplant" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlplant_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="labelcells" style="height: 25px">
                Location
            </td>
            <td class="NormalText" style="height: 25px">
               <%-- <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>--%>
                        <asp:DropDownList ID="ddlLocation" runat="server" CssClass="combobox" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlLocation"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                 <%--   </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
        </tr>
     
        <tr>
            <td class="labelcells">
                BankName
            </td>
            <td class="NormalText">
              <%--  <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>--%>
                        <asp:DropDownList ID="ddlbank" runat="server" CssClass="combobox" Width="200px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlbank"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                  <%--  </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
            <td class="labelcells">
                Department
            </td>
            <td class="NormalText">
                <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>--%>
                        <asp:DropDownList ID="ddldepartment" runat="server" CssClass="combobox">
                        </asp:DropDownList>
                  <%--  </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
            Group Category
            </td>
            <td class="NormalText">
               <%-- <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>--%>
                        <asp:DropDownList ID="ddlGroupCategory" runat="server" CssClass="combobox">
                        </asp:DropDownList>
                  <%--  </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
               
                 <asp:Label ID="Label1" runat="server" Visible="False"> Advice Date</asp:Label>
            </td>
            <td class="NormalText">
             <%--   <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>--%>
                        <asp:TextBox ID="TxtOvertimeDate" runat="server" Style="text-transform: capitalize;"
                            CssClass="textbox" MaxLength="8"></asp:TextBox>
                  <%--  </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
            <td class="labelcells">
                <asp:Label ID="Label10" runat="server">Remarks</asp:Label>
            </td>
            <td class="labelcells" colspan="3">
            <%--    <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                    <ContentTemplate>--%>
                        <asp:TextBox ID="TxtOvertimeReason" runat="server" CssClass="textbox" MaxLength="50"
                            Width="300px"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtOvertimeReason"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" WatermarkCssClass="watermark"
                            WatermarkText="Give the Remarks here" TargetControlID="TxtOvertimeReason">
                        </cc1:TextBoxWatermarkExtender>
                 <%--   </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="lnkfetch_Click">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
                <asp:LinkButton ID="LnkExcel" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="LnkExcel_Click" Enabled="False">Excel</asp:LinkButton>
                <%--<asp:LinkButton ID="lnkPrint" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="lnkPrint_Click">Print</asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" Visible="False"
                    Width="1000px">
                    <asp:GridView ID="grdDetail" runat="server" Width="100%" PageSize="30">
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
     <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
        GroupTreeImagesFolderUrl="" Height="1202px" ReportSourceID="CrystalReportSource1"
        ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="1104px" />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="BankAdvise.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>

