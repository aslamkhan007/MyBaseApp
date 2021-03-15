﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="JCT_Payroll_PF_EPS_transfer.aspx.cs" Inherits="Payroll_JCT_Payroll_PF_EPS_transfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                PF Transfer(Portal):
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Type
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddldedtypes" runat="server" CssClass="combobox" 
                    AppendDataBoundItems="True" AutoPostBack="True" 
                    onselectedindexchanged="ddldedtypes_SelectedIndexChanged">
                    <asp:ListItem >PF EPS Calculation</asp:ListItem>
                    <asp:ListItem Selected="True">PF Transfer</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                YearMonth
            </td>
            <td class="NormalText" colspan="3">
                <asp:TextBox ID="txttodate" runat="server" CssClass="textbox" Width="80px" 
                    ToolTip="i.e. 201906 - 201907"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttodate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                 Note: PF Month is next to Salary process month ( i.e. 201906 - 201907)
                &nbsp;
                &nbsp;
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddllocation"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <%-- <tr>
            <td class="NormalText">
                Number Of Months
            </td>
            <td class="NormalText">
                <asp:Label ID="lblMonths" runat="server"></asp:Label>
                <br />
            </td>
            <td class="NormalText">
                Amount
            </td>
            <td class="NormalText">
                <asp:Label ID="lbldedamount" runat="server"></asp:Label>
            </td>
        </tr>--%>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" OnClick="lnksave_Click"
                    ValidationGroup="A">Apply</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" CausesValidation="False"
                    ValidationGroup="A" OnClick="lnkreset_Click">Reset</asp:LinkButton>
                <%--<asp:LinkButton ID="lnkUpdate" runat="server" CssClass="buttonc" CausesValidation="False"
                    OnClick="lnkUpdate_Click" Visible="False">Update</asp:LinkButton>--%>
               <%-- <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonc" 
                    OnClick="LinkButton1_Click" Visible="False">Report</asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="950px">
                            <asp:GridView ID="grdDetail" runat="server" EnableModelValidation="True" Width="100%">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PageStyle" />
                                <RowStyle CssClass="Griditem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>


