﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Courier Tracking System/MasterPage.master" AutoEventWireup="true" CodeFile="Courier_Cost.aspx.cs" Inherits="Courier_Tracking_System_Courier_Cost" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label18" runat="server" Text="Courier Cost Report"></asp:Label>
            <%--    <asp:Label ID="Label24" runat="server" ForeColor="Red" 
                    Text="New Center at Kanpur Starting from 15th June 2012." 
                    BackColor="White" BorderColor="Black" BorderStyle="Solid" Font-Bold="True" 
                    Font-Size="X-Large"></asp:Label>
                <cc1:AlwaysVisibleControlExtender ID="Label24_AlwaysVisibleControlExtender" 
                    runat="server" HorizontalSide="Center" TargetControlID="Label24">
                </cc1:AlwaysVisibleControlExtender>--%>
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
                        <asp:DropDownList ID="ddlDept" runat="server" CssClass="combobox">
                            <asp:ListItem>--All--</asp:ListItem>
                            <asp:ListItem>Admin</asp:ListItem>
                            <asp:ListItem>Factory</asp:ListItem>
                            <asp:ListItem>Purchase</asp:ListItem>
                            <asp:ListItem>R&amp;D</asp:ListItem>
                            <asp:ListItem>R/W</asp:ListItem>
                            <asp:ListItem>Sale</asp:ListItem>
                            <asp:ListItem>Sports</asp:ListItem>
                            <asp:ListItem>Tafetta</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="True" 
                            CssClass="combobox" 
                            onselectedindexchanged="ddlDepartment_SelectedIndexChanged" Visible="False">
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
      <!--  <tr>
            <td class="NormalText" style="width: 150px">
                <asp:Label ID="Label23" runat="server" Text="Courier Type"></asp:Label>
            </td>
            <td class="NormalText" style="width: 153px">
                <asp:DropDownList ID="ddlCourierType" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
            <td class="NormalText" style="width: 120px">
                      
                    </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr> -->
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                       
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" 
                            onclick="lnkReset_Click">Reset</asp:LinkButton>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
                 <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" 
                            onclick="lnkfetch_Click" ValidationGroup="A">Fetch</asp:LinkButton>
  <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" 
                            onclick="lnkExcel_Click">To Excel</asp:LinkButton><asp:Button ID="btnSend" runat="server" Text="Send" OnClick="Send" />
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
                            <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle" EmptyDataText="No data found."
                                OnRowDataBound="GridView1_RowDataBound" ShowFooter="True" Width="100%" AutoGenerateColumns="False"
                                 AllowPaging="True" 
                                onpageindexchanging="GridView1_PageIndexChanging" PageSize="40">
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                           <asp:Button ID="btnSelect" runat="server" Text="Select" CommandName = "Select" 
                                                onclick="btnSelect_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cost Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCostCenter" runat="server" Text='<%# Eval("Cost_Center") %>' 
                                                ToolTip='<%# String.Concat(" No. of couriers sent : ",Eval("counter") ) %>'></asp:Label>
                                             <asp:Label ID="Label1" runat="server" Text="       ("></asp:Label>
                                                    <asp:Label ID="Label25" runat="server" Text='<%# Eval("counter") %>'></asp:Label>
                                                       <asp:Label ID="Label2" runat="server" Text=" )"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                             
                                    <asp:TemplateField HeaderText="Cost">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkCost" runat="server" Text='<%# Eval("Cost") %>'></asp:LinkButton> 
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                 
                                    <asp:TemplateField HeaderText="Date From">
                                        <ItemTemplate>
                                            <asp:Label ID="Label26" runat="server" Text='<%# Eval("DateFrom") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date To">
                                        <ItemTemplate>
                                            <asp:Label ID="Label27" runat="server" Text='<%# Eval("DateTo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                 
                                </Columns>
                                <HeaderStyle CssClass="HeaderStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="RowStyle" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                            </asp:GridView>
                        </asp:Panel> 
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkfetch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnSend" EventName="Click" />
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

