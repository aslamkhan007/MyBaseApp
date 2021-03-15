<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" Theme="OpsSkinFIle" AutoEventWireup="false" CodeFile="ReviseSaleOrderSchedule.aspx.vb" Inherits="OPS_ReviseSaleOrderSchedule" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Reschedule Dyeing Plan</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="OrderNo"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtOrderNo" runat="server" AutoPostBack="True" ></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="2">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/loading.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label2" runat="server" Text="Sale Person"></asp:Label>
            </td>
            <td valign="top" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblSalePerson" runat="server"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtOrderNo" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td valign="top" width="80px">
                CustomerName</td>
            <td valign="top" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtOrderNo" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells_s" colspan="2" width="400px">
                <asp:Label ID="Label3" runat="server" Text="Order Detail"></asp:Label>
            </td>
            <td class="textcells_s" colspan="2" width="400px">
                <asp:Label ID="Label5" runat="server" Text="Planned Dates"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="tableback">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical">
                            <asp:GridView ID="GridOrderDetail" runat="server"    
                             EmptyDataText="No Data Available" Width="100%" AutoGenerateColumns="False" 
                                DataSourceID="SqlDataSource1" EnableModelValidation="True">
                                <Columns>
                                    <asp:BoundField DataField="Shade" HeaderText="Shade" SortExpression="Shade" />
                                    <asp:BoundField DataField="LineNo" HeaderText="LineNo" 
                                        SortExpression="LineNo" />
                                    <asp:BoundField DataField="Item" HeaderText="Item" SortExpression="Item" />
                                    <asp:BoundField DataField="OrderQty" HeaderText="OrderQty" 
                                        SortExpression="OrderQty" />
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                                SelectCommand="SELECT attb_discrete AS Shade,line_no AS [LineNo],Item_no AS Item,Req_Qty as OrderQty FROM miserp.som.dbo.t_order_line_nos a,miserp.som.dbo.t_order_line_nos_attrb b WHERE a.order_no=b.order_no AND a.order_srl_no=b.line_no AND a.order_no=@order_no AND b.attb_code='shade1' order by a.order_srl_no ">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtOrderNo" Name="order_no" 
                                        PropertyName="Text" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtOrderNo" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td colspan="2" valign="top" class="tableback">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel2" runat="server" Height="200px" ScrollBars="Vertical">
                            <asp:GridView ID="GridOrderDetail0" runat="server" AutoGenerateColumns="False" 
                                EmptyDataText="No Data Available" EnableModelValidation="True" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="Sort" HeaderText="Item" />
                                    <asp:BoundField DataField="LineNo" HeaderText="LineNo" />
                                    <asp:BoundField DataField="AcutalQty" HeaderText="ActualQty" />
                                    <asp:TemplateField HeaderText="PlannedQty">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPlannedQty" runat="server" CssClass="textbox" 
                                                Text='<%# Eval("PlannedQty") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="PlannedForDt" HeaderText="PlannedDate" />
                                    <asp:TemplateField HeaderText="Process">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlProcess" runat="server" CssClass="combobox">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                                <asp:ListItem>Dyeing</asp:ListItem>
                                                <asp:ListItem>Finishing</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="NewDate">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtNewDate" runat="server" CssClass="textbox"></asp:TextBox>
                                            <cc1:CalendarExtender ID="TxtNewDate_CalendarExtender" runat="server" 
                                                Enabled="True" TargetControlID="TxtNewDate">
                                            </cc1:CalendarExtender>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtOrderNo" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="CmdApply" runat="server" CssClass="buttonc">Apply</asp:LinkButton>
&nbsp;<asp:LinkButton ID="CmdClear" runat="server" CssClass="buttonc">Reset</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

