<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Plan_individual_Item.aspx.cs" Inherits="OPS_Plan_individual_Item" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .panelbg
        {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   <asp:Panel ID="pnlpopup" 
        CssClass="panelbg" runat="server" Height="600px" Width="366px" >
       
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
       
                    <table >    
                            <tr>
                                <td class="NormalText">
                                    <asp:Label ID="Label38" runat="server" Text="Plan Item"></asp:Label>
                                </td>
                            </tr>
                        </table>
                             
                                        <table>
                                            <tr>
                                                <td class="NormalText" style="width: 176px">
                                                    <asp:Label ID="Labl22" runat="server" Text="PlanID"></asp:Label>
                                                </td>
                                                <td class="NormalText">
                                                    <asp:DropDownList ID="ddlPlanID" runat="server">
                                                    </asp:DropDownList>
                                                     <%--<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="SELECT [PLANID],[Description] FROM [JCT_OPS_PLANNING_GENERATE_PLANID] WHERE ([STATUS] = @STATUS) ORDER BY [PLANID] DESC">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="A" Name="STATUS" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 176px">
                                                    <asp:Label ID="Labl18" runat="server" Text="Order No"></asp:Label>
                                                </td>
                                                <td class="NormalText">
                                                    <asp:Label ID="lblOrder_PlanItem" runat="server" Text='<%# Eval("OrderNo") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 176px">
                                                    <asp:Label ID="Labl19" runat="server" Text="Order Sort"></asp:Label>
                                                </td>
                                                <td class="NormalText">
                                                    <asp:Label ID="lblSort_PlanItem" runat="server" Text='<%# Eval("SortNo") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 176px">
                                                    <asp:Label ID="Label35" runat="server" Text="Line Item"></asp:Label>
                                                </td>
                                                <td class="NormalText">
                                                    <asp:Label ID="lblLineItem_PlanItem" runat="server" 
                                                        Text='<%# Eval("LineItem") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 176px">
                                                    <asp:Label ID="Label41" runat="server" Text="Shade"></asp:Label>
                                                </td>
                                                <td class="NormalText">
                                                    <asp:Label ID="lblShade_PlanItem" runat="server" Text='<%# Eval("LineItem") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 176px">
                                                    <asp:Label ID="Labl20" runat="server" Text="Weaving Sort"></asp:Label>
                                                </td>
                                                <td class="NormalText">
                                                    <asp:TextBox ID="txtWeavingSort_PlanItem" runat="server" Columns="6" 
                                                        CssClass="textbox" MaxLength="6" Text='<%# Eval("WeavingSort") %>'></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 176px">
                                                    <asp:Label ID="Labl21" runat="server" Text="Delivery Date"></asp:Label>
                                                </td>
                                                <td class="NormalText">
                                                    <asp:Label ID="lblDeliveryDate_PlanItem" runat="server" 
                                                        Text='<%# Eval("DeliveryDt") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 176px">
                                                    <asp:Label ID="Label22" runat="server" Text="Expetced Delivery Date"></asp:Label>
                                                </td>
                                                <td class="NormalText">
                                                    <asp:TextBox ID="txtExpectedDelivery_PlanItem" runat="server" 
                                                        AutoPostBack="True" CssClass="textbox" 
                                                        ontextchanged="txtExpectedDelivery_PlanItem_TextChanged" 
                                                        Text='<%# Eval("Expected_DeliveryDt") %>'></asp:TextBox>
                                                    <cc1:CalendarExtender ID="txtExpectedDelivery_PlanItem_CalendarExtender" 
                                                        runat="server" TargetControlID="txtExpectedDelivery_PlanItem"></cc1:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 176px">
                                                    <asp:Label ID="Label23" runat="server" Text="Expected Greigh Date"></asp:Label>
                                                </td>
                                                <td class="NormalText">
                                                    <asp:TextBox ID="txtGreighDate_PlanItem" runat="server" AutoPostBack="True" 
                                                        CssClass="textbox" Text='<%# Eval("Greigh_ReqDt") %>'></asp:TextBox>
                                                    <cc1:CalendarExtender ID="txtGreighDate_PlanItem_CalendarExtender" 
                                                        runat="server" TargetControlID="txtGreighDate_PlanItem"></cc1:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 176px">
                                                    <asp:Label ID="Label24" runat="server" Text="Order Qty"></asp:Label>
                                                </td>
                                                <td class="NormalText">
                                                    <asp:Label ID="lblOrderQty_PlanItem" runat="server" 
                                                        Text='<%# Eval("OrderQty") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 176px">
                                                    <asp:Label ID="LblPlan_PlanItem" runat="server" Text="Plan Qty"></asp:Label>
                                                </td>
                                                <td class="NormalText">
                                                    <asp:TextBox ID="txtPlanQty_PlanItem" runat="server" CssClass="textbox" 
                                                        ontextchanged="txtPlanQty_PlanItem_TextChanged" 
                                                        Text='<%# Eval("PlanQty") %>' AutoPostBack="True" ></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 176px; height: 17px;">
                                                    <asp:Label ID="Label37" runat="server" Text="CaseType"></asp:Label>
                                                </td>
                                                <td class="NormalText" style="height: 17px">
                                                    <asp:DropDownList ID="ddlGreigh_PlanItem" runat="server" AutoPostBack="True" 
                                                        CssClass="combobox" DataSourceID="SqlDataSource3" DataTextField="CaseType" 
                                                        DataValueField="CaseType" 
                                                        onselectedindexchanged="ddlGreigh_PlanItem_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                                                        ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                                                        SelectCommand="Select '--Select--' as [CaseType] Union SELECT Distinct  [CaseType] FROM production..[JCT_Process_Greigh_Request_Variation] where status='A' and GetDate() between Eff_from and Eff_To">
                                                    </asp:SqlDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 176px; height: 25px;">
                                                    <asp:Label ID="Label28" runat="server" Text="Greigh Req"></asp:Label>
                                                </td>
                                                <td class="NormalText" style="height: 25px">
                                                    <asp:TextBox ID="txtGreighReq_PlanItem" runat="server" AutoPostBack="True" 
                                                        Columns="6" CssClass="textbox" MaxLength="10" Text='<%# Eval("GreighReq") %>'></asp:TextBox>
                                                    <asp:Label ID="Label33" runat="server" Text="mtrs"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 176px">
                                                    <asp:Label ID="Label29" runat="server" Text="Greigh Adj"></asp:Label>
                                                </td>
                                                <td class="NormalText">
                                                    <asp:TextBox ID="txtGreighAdj_PlanItem" runat="server" AutoPostBack="True" 
                                                        Columns="6" CssClass="textbox" MaxLength="10" 
                                                        ontextchanged="txtGreighAdj_PlanItem_TextChanged" 
                                                        Text='<%# Eval("GreighAdj") %>'></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 176px">
                                                    <asp:Label ID="Label13" runat="server" Text="Greigh Rem"></asp:Label>
                                                </td>
                                                <td class="NormalText">
                                                    <asp:TextBox ID="txtGreighRem_PlanItem" runat="server" AutoPostBack="True" 
                                                        Columns="6" CssClass="textbox" MaxLength="10" Text='<%# Eval("GreighRem") %>'></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 176px">
                                                    <asp:Label ID="Label34" runat="server" Text="Sizing"></asp:Label>
                                                </td>
                                                <td class="NormalText">
                                                    <asp:TextBox ID="txtSizing_PlanItem" runat="server" Columns="6" 
                                                        CssClass="textbox" MaxLength="10" Text='<%# Eval("Sizing") %>'></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 176px">
                                                    <asp:Label ID="Label30" runat="server" Text="Shed"></asp:Label>
                                                </td>
                                                <td class="NormalText">
                                                    <asp:DropDownList ID="ddlShed_PlanItem" runat="server" AutoPostBack="True" 
                                                        CssClass="combobox" DataSourceID="SqlDataSource1" DataTextField="PARAMETER" 
                                                        DataValueField="PARAMETER_CODE" 
                                                        onselectedindexchanged="ddlShed_PlanItem_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                                        ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                                                        SelectCommand="Select '--Select--' as [PARAMETER_CODE],'--Select--'  [PARAMETER] union SELECT  [PARAMETER_CODE],[PARAMETER] FROM [jct_ops_multi_master] WHERE (([Status] = @Status) AND ([PARENT_CATEGORY] = @PARENT_CATEGORY)) ORDER BY [PARAMETER]">
                                                        <SelectParameters>
                                                            <asp:Parameter DefaultValue="A" Name="Status" Type="String" />
                                                            <asp:Parameter DefaultValue="ShedDays" Name="PARENT_CATEGORY" Type="String" />
                                                        </SelectParameters>
                                                    </asp:SqlDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 176px">
                                                    <asp:Label ID="Label39" runat="server" Text="RPM"></asp:Label>
                                                </td>
                                                <td class="NormalText">
                                                    <asp:TextBox ID="txtRPM_PlanItem" runat="server" AutoPostBack="True" 
                                                        Columns="6" CssClass="textbox" MaxLength="10" 
                                                        ontextchanged="txtRPM_PlanItem_TextChanged" Text='<%# Eval("RPM") %>'></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 176px">
                                                    <asp:Label ID="Label40" runat="server" Text="Efficiency"></asp:Label>
                                                </td>
                                                <td class="NormalText">
                                                    <asp:TextBox ID="txtEfficiency_PlanItem" runat="server" AutoPostBack="True" 
                                                        Columns="6" CssClass="textbox" MaxLength="10" 
                                                        ontextchanged="txtEfficiency_PlanItem_TextChanged" 
                                                        Text='<%# Eval("Efficiency") %>'></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 176px">
                                                    <asp:Label ID="Label31" runat="server" Text="Looms"></asp:Label>
                                                </td>
                                                <td class="NormalText">
                                                    <asp:TextBox ID="txtLooms_PlanItem" runat="server" AutoPostBack="True" 
                                                        Columns="3" CssClass="textbox" MaxLength="3" 
                                                        ontextchanged="txtLooms_PlanItem_TextChanged" Text='<%# Eval("Looms") %>'></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 176px">
                                                    <asp:Label ID="Label32" runat="server" Text="Wvg Days"></asp:Label>
                                                </td>
                                                <td class="NormalText">
                                                    <asp:Label ID="lblWvgDays_PlanItem" runat="server" 
                                                        Text='<%# Eval("WvgDays") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 176px">
                                                    <asp:Label ID="Label42" runat="server" Text="Split"></asp:Label>
                                                </td>
                                                <td class="NormalText">
                                                    <asp:Label ID="lblSplit_PlanItem" runat="server" Text='<%# Eval("OrderNo") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 176px">
                                                    <asp:Label ID="Label43" runat="server" Text="Individual Plan"></asp:Label>
                                                </td>
                                                <td class="NormalText">
                                                    <asp:Label ID="lblIPlan_PlanItem" runat="server" Text='<%# Eval("OrderNo") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="buttonbackbar" colspan="2">
                                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                        <ContentTemplate>
                                                            <asp:LinkButton ID="lnkSubmit_PlanItem" runat="server" CommandName="Submit" 
                                                                CssClass="buttonc" onclick="lnkSubmit_PlanItem_Click">Submit</asp:LinkButton>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 176px">
                                                    &nbsp;</td>
                                                <td class="NormalText">
                                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="100">
                                                        <ProgressTemplate>
                                                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Image/load.gif" />
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                            </tr>
                                        </table>
                             
                                        </asp:Panel>
    </div>
    </form>
</body>
</html>
