<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_Initialise_Earning.aspx.cs" Inherits="Payroll_Jct_Payroll_Initialise_Earning" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Initialize Earning
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
                <asp:DropDownList ID="ddllocation" runat="server" CssClass="combobox" OnSelectedIndexChanged="ddllocation_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddllocation"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4" style="height: 27px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" OnClick="lnkfetch_Click"
                            ValidationGroup="A">Fetch</asp:LinkButton>
                        <%--<asp:LinkButton ID="lnkfreeeze" runat="server" CssClass="buttonc" 
                        onclick="lnkfreeeze_Click" ValidationGroup="A">Freeze</asp:LinkButton>--%>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" OnClick="lnkReset_Click">Reset</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <%--        <ew:CollapsablePanel ID="PnlExtTasks" CssClass="panelcells" runat="server" Height="150px"
                            ScrollBars="Vertical" Width="100%" CollapseImageUrl="Image/UPARROW.JPG" CollapserAlign="Left"
                            ExpandImageUrl="Image/DNARROW.JPG">--%>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="950px">
                            <asp:GridView ID="GridExtTask" runat="server" CssClass="GridViewStyle" GridLines="None"
                                Width="100%">
                                <RowStyle CssClass="RowStyle" />
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <EditRowStyle CssClass="EditRowStyle" />
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                <Columns>
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
                        </asp:Panel>
                        <%--</ew:CollapsablePanel>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 115px">
            </td>
        </tr>
    </table>
    <table class="mytable">
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkConfirmAll" runat="server" CssClass="buttonc" 
                            OnClick="lnkConfirmAll_Click" Visible="False">Apply</asp:LinkButton>
                        <%--<asp:LinkButton ID="LnkCancel" runat="server" CssClass="buttonc" OnClick="LnkCancel_Click">Cancel</asp:LinkButton>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="10">
                    <ProgressTemplate>
                        <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />--%>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
</asp:Content>
