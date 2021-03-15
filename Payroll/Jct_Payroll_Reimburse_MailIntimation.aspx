<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_Reimburse_MailIntimation.aspx.cs" Inherits="Payroll_Jct_Payroll_Reimburse_MailIntimation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader">
                Conveyance Mail Intimation :
            </td>
        </tr>
    </table>
    <table class="NormalText">
        <tr>
            <td class="NormalText">
                <asp:Label ID="Label27" runat="server" Text="Pending List:"></asp:Label>
            </td>
        </tr>
    </table>
    <table class="mytable">
        <%--        <tr>
            <td class="NormalText">
                <asp:Label ID="Label2" runat="server" Text="Email Id Availibility"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlFilter" runat="server" CssClass="combobox" OnSelectedIndexChanged="ddlFilter_SelectedIndexChanged"
                    AutoPostBack="True">
                    <asp:ListItem Value="WithMail">WithMail</asp:ListItem>
                    <asp:ListItem Value="WithOutMail">WithOut Mail</asp:ListItem>
                    <asp:ListItem Selected="True" Value="All"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="LblLocation" runat="server" Text="Location"></asp:Label>
            </td>
            <td>
                <div id="divwidth" style="display: none;">
                </div>
                <asp:DropDownList ID="ddlloc" runat="server" CssClass="combobox" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlloc_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="lblSublocation" runat="server" Text="Sublocation"></asp:Label>
            </td>
            <td>
                <div id="div1" style="display: none;">
                </div>
                <asp:DropDownList ID="ddlsublocation" runat="server" CssClass="combobox" OnSelectedIndexChanged="ddlsublocation_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>--%>
        <tr>
            <td class="NormalText">
                YearMonth
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txttodate" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                <%--       <cc1:CalendarExtender ID="txttodate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txttodate">
                </cc1:CalendarExtender>--%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttodate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Plant
            </td>
            <td class="NormalText">
                <%--<asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" 
                    DataSourceID="SqlDataSource1" DataTextField="plant_name" 
                    DataValueField="Plant_code">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="SELECT  plant_name,Plant_code FROM jctpayroll_PlantMaster WHERE Status='A'">
                </asp:SqlDataSource>
                --%>
                <asp:DropDownList ID="ddlplant" runat="server" AutoPostBack="True" CssClass="combobox"
                    OnSelectedIndexChanged="ddlplant_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="NormalText">
                Location
            </td>
            <td class="NormalText">
                <%--<asp:DropDownList ID="ddllocation" runat="server" CssClass="combobox" DataSourceID="SqlDataSource2"
                    DataTextField="Location_description" DataValueField="Location_code">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                    SelectCommand="SELECT '' as  Location_code,'' as Location_description union SELECT  Location_code,Location_description FROM JCT_payroll_location_master WHERE Status='A'">
                </asp:SqlDataSource>--%>
                <asp:DropDownList ID="ddllocation" runat="server" CssClass="combobox">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddllocation"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlgrid" Width="1000px" runat="server" Height="200px" ScrollBars="Horizontal">
      <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
        <asp:GridView ID="grdDetail" runat="server" Width="100%" EmptyDataText="No Record Found ..."
            EnableModelValidation="True" AutoGenerateColumns="True">
            <AlternatingRowStyle CssClass="GridAI" />
            <SelectedRowStyle CssClass="SelectedRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <RowStyle CssClass="GridItem" />
            <Columns>
                <%--<asp:TemplateField HeaderText="E-mail">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkemail" runat="server" BorderStyle="None" CommandName="Sendmail"
                            CssClass="emailicon" Height="16px" Width="16px"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Confirm">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkConfirm" runat="server" CommandName="lnkConfirm">Confirm</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ByPassMail">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkByPass" runat="server" CommandName="lnkByPass">ByPass Mail</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Check">
                    <HeaderTemplate>
                        <asp:CheckBox ID="ChkOrderSelAll" runat="server" AutoPostBack="True" OnCheckedChanged="ChkOrderSelAll_CheckedChanged" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="chkCheck" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <table class="mytable">
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/OPS/Image/loadingNew.gif" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkEmailAll" runat="server" CssClass="buttonc" OnClick="lnkEmailAll_Click">Fetch</asp:LinkButton>
                        <%--<asp:LinkButton ID="lnkByPassAll" runat="server" CssClass="buttonc" OnClick="lnkByPassAll_Click">ByPass All</asp:LinkButton>--%>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" OnClick="lnkReset_Click">Reset</asp:LinkButton>
                        <asp:LinkButton ID="lnkConfirmAll" runat="server" CssClass="buttonc" OnClick="lnkConfirmAll_Click">Email All</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table class="mytable">
        <tr>
            <td class="NormalText">
                <asp:Label ID="Label1" runat="server" Text="Mail Sent List:"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" Width="1000px" runat="server" Height="200px" ScrollBars="Horizontal">
      <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
        <asp:GridView ID="GridView1" runat="server" Width="100%" EmptyDataText="No Record Found ..."
            EnableModelValidation="True">
            <AlternatingRowStyle CssClass="GridAI" />
            <SelectedRowStyle CssClass="SelectedRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <RowStyle CssClass="GridItem" />
        </asp:GridView>
        </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
