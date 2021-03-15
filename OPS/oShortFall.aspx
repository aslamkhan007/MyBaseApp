<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="ShortFall.aspx.cs" Inherits="OPS_ShortFall" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="5">
                <asp:Label ID="Label16" runat="server" Text="Generate Shortfall Request"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 140px; height: 25px;">
                <asp:Label ID="Label26" runat="server" Text="Date From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 170px; height: 25px;">
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtDateFrom">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText" style="width: 127px; height: 25px;">
                <asp:Label ID="Label27" runat="server" Text="Date To"></asp:Label>
            </td>
            <td class="NormalText" style="width: 265px; height: 25px;">
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" 
                    TargetControlID="txtDateTo">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText" style="height: 25px">
                </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 140px">
                <asp:Label ID="Label17" runat="server" Text="Order No"></asp:Label>
            </td>
            <td class="NormalText" style="width: 170px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox"  AutoPostBack="true"
                            ontextchanged="txtOrderNo_TextChanged"></asp:TextBox>
                        <cc1:PopupControlExtender ID="txtOrderNo_PopupControlExtender" runat="server"  PopupControlID="pnlSaleOrder" Position="Bottom"
                            TargetControlID="txtOrderNo">
                        </cc1:PopupControlExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 127px">
                <asp:Label ID="Label23" runat="server" Text="Customer Name"></asp:Label>
            </td>
            <td class="NormalText" style="width: 265px">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblCustomer" runat="server"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtOrderNo" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="rblSaleOrder" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 140px">
                <asp:Label ID="Label18" runat="server" Text="Sort No"></asp:Label>
            </td>
            <td class="NormalText" style="width: 170px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSortNo" runat="server" AutoPostBack="True" 
                            CssClass="combobox" 
                            onselectedindexchanged="ddlSortNo_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtOrderNo" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="rblSaleOrder" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 127px">
                <asp:Label ID="Label24" runat="server" Text="Line Item"></asp:Label>
            </td>
            <td class="NormalText" style="width: 265px">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlLineItem" runat="server" AutoPostBack="True" 
                            CssClass="combobox" 
                            onselectedindexchanged="ddlLineItem_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSortNo" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtOrderNo" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="rblSaleOrder" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 140px">
                <asp:Label ID="Label19" runat="server" Text="Planned Meters (in Mtrs)"></asp:Label>
            </td>
            <td class="NormalText" style="width: 170px">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblPlanMtrs" runat="server"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSortNo" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtOrderNo" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="rblSaleOrder" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlLineItem" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 127px">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/loadingNew.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td class="NormalText" style="width: 265px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 140px">
                <asp:Label ID="Label21" runat="server" Text="Meters to be Replanned"></asp:Label>
            </td>
            <td class="NormalText" style="width: 170px">
                <asp:TextBox ID="txtReplanMtrs" runat="server" CssClass="textbox" Columns="10" 
                    MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtReplanMtrs_FilteredTextBoxExtender" 
                    runat="server" FilterType="Numbers" TargetControlID="txtReplanMtrs" 
                    ValidChars="1,2,3,4,5,6,7,8,9,0,.">
                </cc1:FilteredTextBoxExtender>
                Mtrs<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtReplanMtrs" ErrorMessage="**" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 127px">
                &nbsp;</td>
            <td class="NormalText" style="width: 265px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 140px">
                <asp:Label ID="Label22" runat="server" Text="Reason for Shortfall"></asp:Label>
            </td>
            <td class="NormalText" style="width: 170px">
                <asp:DropDownList ID="ddlReason" runat="server" AutoPostBack="True" 
                    CssClass="combobox">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Less Production</asp:ListItem>
                    <asp:ListItem>Machine Fault</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText" style="width: 127px">
                &nbsp;</td>
            <td class="NormalText" style="width: 265px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 140px">
                <asp:Label ID="Label25" runat="server" Text="Remarks"></asp:Label>
            </td>
            <td class="NormalText" colspan="3">
                <asp:TextBox ID="txtRemarks" runat="server" Height="50px" TextMode="MultiLine" 
                    Width="200px"></asp:TextBox>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:LinkButton ID="lnkSubmit" runat="server" CssClass="buttonc" 
                    onclick="lnkSubmit_Click" ValidationGroup="A">Submit</asp:LinkButton>
                <cc1:ConfirmButtonExtender ID="lnkSubmit_ConfirmButtonExtender" runat="server" 
                    ConfirmText="On Submitting this data, Mail will be sent to planning department to replan the quantity..!!" 
                    TargetControlID="lnkSubmit">
                </cc1:ConfirmButtonExtender>
                <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" 
                    onclick="lnkReset_Click">Reset</asp:LinkButton>
                <asp:LinkButton ID="lnkAllRequests" runat="server" CssClass="buttonc" 
                    onclick="lnkAllRequests_Click">ALL Requests</asp:LinkButton>
            </td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:GridView ID="GridView1" runat="server" Width="100%">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtOrderNo" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="rblSaleOrder" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSortNo" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="lnkAllRequests" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
          <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional" 
                    RenderMode="Inline">
                    <ContentTemplate>    
    <asp:Panel ID="pnlSaleOrder" runat="server" CssClass="panelbg" style="display:none;" Width="200px"   ScrollBars="Vertical">
        <asp:RadioButtonList ID="rblSaleOrder" CssClass="textbox" runat="server" 
            AutoPostBack="True" 
            onselectedindexchanged="rblSaleOrder_SelectedIndexChanged" >
            <asp:ListItem>EXP/019818/2013</asp:ListItem>
            <asp:ListItem>EXP/019817/2013</asp:ListItem>
            <asp:ListItem>RMG/002206/2013</asp:ListItem>
        </asp:RadioButtonList>
    </asp:Panel>
    </ContentTemplate>
    <Triggers>
                   
                    <asp:AsyncPostBackTrigger ControlID="txtOrderNo" EventName="TextChanged" />
                    <asp:AsyncPostBackTrigger ControlID="rblSaleOrder" EventName="TextChanged" />
                   
                    </Triggers>
    </asp:UpdatePanel>
</asp:Content>

