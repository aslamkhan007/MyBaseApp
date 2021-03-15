<%@ Page Title="" Language="C#" MasterPageFile="~/Courier Tracking System/MasterPage.master" AutoEventWireup="true" CodeFile="Courier_Type_Mapping.aspx.cs" Inherits="Courier_Tracking_System_Courier_Type_Mapping" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label18" runat="server" Text="Courier Type Mapping"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 149px">
                <asp:Label ID="Label21" runat="server" Text="Effective From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 210px">
                <asp:TextBox ID="txtEffecFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtEffecFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtEffecFrom">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText" style="width: 125px">
                <asp:Label ID="Label22" runat="server" Text="Effective To"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtEffecTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtEffecTo_CalendarExtender" runat="server" 
                    TargetControlID="txtEffecTo">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 149px">
                <asp:Label ID="Label19" runat="server" Text="Select Department"></asp:Label>
            </td>
            <td class="NormalText" colspan="3">
                <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="combobox" 
                    DataSourceID="SqlDataSource1" DataTextField="DEPTNAME" 
                    DataValueField="DEPTCODE">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="SELECT [DEPTCODE], [DEPTNAME] FROM [DEPTMAST]">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 149px" align="justify">
                <asp:Label ID="Label20" runat="server" Text="Select Type"></asp:Label>
            </td>
            <td class="NormalText" colspan="3">
                <asp:Panel ID="Panel1" runat="server" Height="100px" ScrollBars="Vertical">
                    <asp:CheckBoxList ID="cblCourierType" runat="server" 
    DataSourceID="SqlDataSource2" DataTextField="CourierType" 
    DataValueField="Sr_no">
                    </asp:CheckBoxList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
    
                        SelectCommand="SELECT [CourierType], [Sr_no] FROM [jct_courier_Type_Master] WHERE (([STATUS] = @STATUS) AND ([Mapped_Department] IS NULL))">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="A" Name="STATUS" 
            Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 149px">
                &nbsp;</td>
            <td class="NormalText" colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc" 
                    onclick="lnkSave_Click">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc">Reset</asp:LinkButton>
            </td>
        </tr>
        </table>
</asp:Content>

