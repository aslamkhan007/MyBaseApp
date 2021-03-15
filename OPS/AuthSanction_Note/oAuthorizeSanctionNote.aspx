<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="AuthorizeSanctionNote.aspx.cs" Inherits="OPS_AuthorizeSanctionNote" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label16" runat="server" Text="Authorize Sanction Note"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Label ID="Label17" runat="server" Text="Pending SO Adjustment "></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <div class="container">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:GridView ID="GridView1" runat="server" Width="100%" 
                                AutoGenerateColumns="False" EnableModelValidation="True" 
                                DataSourceID="SqlDataSource1" 
                              
                                onrowcommand="GridView1_RowCommand">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                     <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSelect" runat="server" CommandName="Select">Select</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Cancel">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                                            <cc1:ConfirmButtonExtender ID="lnkCancel_ConfirmButtonExtender" 
                                                runat="server" ConfirmText="Are you Sure ?" TargetControlID="lnkCancel">
                                            </cc1:ConfirmButtonExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Authorize">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkAuthorize" runat="server" CommandName="Authorize">Authorize</asp:LinkButton>
                                            <cc1:ConfirmButtonExtender ID="lnkAuthorize_ConfirmButtonExtender" 
                                                runat="server" ConfirmText="Are you Sure ?" TargetControlID="lnkAuthorize">
                                            </cc1:ConfirmButtonExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sanction ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSanctionID" runat="server" Text='<%# Eval("SanctionID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Order No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrderNo" runat="server" Text='<%# Eval("OrderNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sort">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSort" runat="server" Text='<%# Eval("Sort") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQty" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sale Price">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSalesPrice" runat="server" Text='<%# Eval("sales_price") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GreighReq">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGreighReq" runat="server" Text='<%# Eval("GreighReq") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Greigh Prod.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGreighProd" runat="server" Text='<%# Eval("GreighProd") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Adjusted">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAdjusted" runat="server" Text='<%# Eval("Adjusted") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Request By">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRequestBy" runat="server" Text='<%# Eval("Request_By") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                                SelectCommand="JCT_OPS_PLANNING_GREIGH_TRANSFER_SANCTION" 
                                SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
                    </Triggers>
                </asp:UpdatePanel>
                </div>
            </td>
        </tr>
    </table>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
    <ProgressTemplate>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
    </ProgressTemplate>
    </asp:UpdateProgress>

    <table style="width: 100%;">
        <tr>
            <td class="NormalText">
                
                  <div class="container">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel2" runat="server">
                            <asp:GridView ID="GridView2" runat="server" Width="100%" 
                                AutoGenerateColumns="False" EnableModelValidation="True">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Order No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrderNo1" runat="server" Text='<%# Eval("OrderNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sort">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSort1" runat="server" Text='<%# Eval("Sort") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Shade">
                                        <ItemTemplate>
                                            <asp:Label ID="lblShade1" runat="server" Text='<%# Eval("Shade") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Line No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLineItem1" runat="server" Text='<%# Eval("LineItem") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQty1" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Sale Price">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSalesPrice1" runat="server" Text='<%# Eval("sales_price") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GreighReq">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGreighReq1" runat="server" Text='<%# Eval("GreighReq") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Greigh Adjusted">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtGreighAdjusted1"  Width="40px" CssClass="textbox" Text='<%# Eval("GreighAdjusted") %>' runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="RowCommand" />
                    </Triggers>
                </asp:UpdatePanel>
                </div>
                
                </td>
        </tr>
        </table>


</asp:Content>

