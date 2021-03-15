<%@ Page Title="" Language="C#" MasterPageFile="~/Courier Tracking System/MasterPage.master" AutoEventWireup="true" CodeFile="Courier_Cost.aspx.cs" Inherits="Courier_Tracking_System_Courier_Cost" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label18" runat="server" Text="Courier Cost Report"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 150px">
                <asp:Label ID="Label19" runat="server" Text="Date From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 153px">
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtDateFrom">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtDateFrom" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 120px">
                <asp:Label ID="Label20" runat="server" Text="Date From"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" 
                    TargetControlID="txtDateTo">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtDateTo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 150px">
                <asp:Label ID="Label21" runat="server" Text="Select Department"></asp:Label>
            </td>
            <td class="NormalText" style="width: 153px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="True" 
                            CssClass="combobox" onselectedindexchanged="ddlDepartment_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 120px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 150px">
                <asp:Label ID="Label22" runat="server" Text="Courier Service"></asp:Label>
            </td>
            <td class="NormalText" style="width: 153px">
                <asp:DropDownList ID="ddlCourierService" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
            <td class="NormalText" style="width: 120px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 150px">
                <asp:Label ID="Label23" runat="server" Text="Courier Type"></asp:Label>
            </td>
            <td class="NormalText" style="width: 153px">
                <asp:DropDownList ID="ddlCourierType" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
            <td class="NormalText" style="width: 120px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" 
                            onclick="lnkfetch_Click" ValidationGroup="A">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" 
                            onclick="lnkReset_Click">Reset</asp:LinkButton>
                        <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" 
                            onclick="lnkExcel_Click">To Excel</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                    AssociatedUpdatePanelID="UpdatePanel2" DisplayAfter="10">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/loading.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle" 
                                EmptyDataText="No data found." onrowdatabound="GridView1_RowDataBound" 
                                ShowFooter="True" Width="100%">
                                <HeaderStyle CssClass="HeaderStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="RowStyle" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkfetch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 150px">
                &nbsp;</td>
            <td class="NormalText" style="width: 153px">
                &nbsp;</td>
            <td class="NormalText" style="width: 120px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

