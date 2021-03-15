<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"  CodeFile="OrdersPanel.aspx.vb" Inherits="SalesAnalysisSystem_OrdersPanel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<%--<link type="text/css" rel="stylesheet" href="style.css" />--%>
<%--    <link type="text/css" rel="stylesheet" href="Chromestyle.css" />--%>
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Sale Orders Panel</td>
           
        </tr>
        <tr>
            <td class="labelcells">
                Sales Person</td>
            <td class="NormalText">
                <asp:Label ID="lblSalesPerson" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
           
        </tr>
   
        <tr>
            <td class="labelcells" style="width: 123px">
                Sales Team</td>
            <td class="NormalText" style="width: 200px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSalesTeam" runat="server" AutoPostBack="True" 
                            CssClass="combobox">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells" style="width: 127px">
                Sales Person</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" 
                    RenderMode="Inline">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSalesPerson" runat="server" CssClass="combobox" 
                            AutoPostBack="True" 
                           >
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesTeam" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                
            </td>
        </tr>
       
        <tr>
            <td class="labelcells" style="width: 123px">
                Customer</td>
              <td class="NormalText" style="width: 200px">

                        <asp:TextBox ID="txtCustomer" runat="server" AutoPostBack="True" 
                            CssClass="textbox"  Width="200px" ToolTip="Please give Customer Code or Select Customer from the List " ></asp:TextBox>
  
                    <div id="divwidth" style="display:none;">   
                        <cc1:AutoCompleteExtender ID="txtCustomer_AutoCompleteExtender" runat="server" 
                            CompletionInterval="10" CompletionSetCount="20" MinimumPrefixLength="1" 
                            ServiceMethod="OPS_Customer"   CompletionListCssClass="AutoExtender" 
                            ServicePath="~/WebService.asmx" 
                            CompletionListElementID="divwidth" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList"
                            TargetControlID="txtCustomer">
                        </cc1:AutoCompleteExtender>
                        </div>
            </td>
            <td class="labelcells" style="width: 127px">
                Order No</td>
            <td>
                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox" 
                     AutoPostBack="True"></asp:TextBox>
            </td>
        </tr>
       
       <tr>
            <td class="labelcells">
                DateFrom
            </td>
            <td style="width: 250px">
                <asp:TextBox ID="txtEff_From" runat="server" CssClass="textbox" MaxLength="15" TabIndex="28"
                    ValidationGroup="ValidGrpSaveDetail" Width="65px"></asp:TextBox>
                <cc1:MaskedEditValidator ID="MEV6" runat="server" ControlExtender="MEE6" ControlToValidate="txtEff_From"
                    ValidationGroup="ValidGrpSaveDetail" Display="Dynamic" InvalidValueMessage="Invalid"
                    IsValidEmpty="False" EmptyValueMessage="*" TooltipMessage="MM/DD/YYYY" Width="114px"></cc1:MaskedEditValidator>
                <cc1:CalendarExtender ID="CalEfffr" runat="server" Animated="False" Format="MM/dd/yyyy"
                    TargetControlID="txtEff_From">
                </cc1:CalendarExtender>
                <cc1:MaskedEditExtender ID="MEE6" runat="server" Mask="99/99/9999" MaskType="Date"
                    TargetControlID="txtEff_From">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                DateTo
            </td>
            <td style="width: 250px">
                <asp:TextBox ID="txtEff_To" runat="server" CssClass="textbox" MaxLength="15" TabIndex="29"
                    ValidationGroup="ValidGrpSaveDetail" Width="65px"></asp:TextBox>
                <cc1:MaskedEditValidator ID="MEV7" runat="server" ControlExtender="MEE7" ControlToValidate="txtEff_To"
                    ValidationGroup="ValidGrpSaveDetail" Display="Dynamic" InvalidValueMessage="Invalid"
                    IsValidEmpty="False" EmptyValueMessage="*" TooltipMessage="MM/DD/YYYY" Width="114px"></cc1:MaskedEditValidator>
                <cc1:CalendarExtender ID="CalEffTo" runat="server" Animated="False" Format="MM/dd/yyyy"
                    TargetControlID="txtEff_To">
                </cc1:CalendarExtender>
                <cc1:MaskedEditExtender ID="MEE7" runat="server" Mask="99/99/9999" MaskType="Date"
                    TargetControlID="txtEff_To">
                </cc1:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="CmdFetch" runat="server" CssClass="buttonc">Fetch</asp:LinkButton>
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
        </table>
        <table>
        <tr>
            <td colspan="4">
                <asp:DataList ID="DataList1" runat="server" Width="800px">
                    <ItemTemplate>
                        <table style="width:100%;">
                            <tr>
                                <td class="buttonbackbar" colspan="3"  align="left">
                                    <asp:Label ID="LblHeader" runat="server" Text='<%# eval("SECTION_Name") %>' 
                                        Width="400px"></asp:Label>
                                     <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server"  SuppressPostBack="true"
                                        CollapseControlID="LblHeader" ScrollContents="true"
                                        ExpandControlID="LblHeader"  Collapsed="True" 
                                        TargetControlID="panel1"  AutoCollapse="false" AutoExpand="false">
                                    </cc1:CollapsiblePanelExtender>
                                    <asp:LinkButton ID="CmdViewMore" runat="server">ViewMore &gt;&gt;</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                              <td colspan="3" id="TesthideDiv" >
                               <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="none" 
                                        Width="800px">
                                        <asp:GridView ID="GrdDetail" runat="server" 
                                            AlternatingRowStyle-CssClass="AltRowStyle" AutoGenerateColumns="true" 
                                            CssClass="GridViewStyle" EnableModelValidation="True" 
                                            FooterStyle-CssClass="SelectedRowStyle" GridLines="None" 
                                            HeaderStyle-CssClass="HeaderStyle" Height="100px" 
                                            PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle" ShowFooter="false" 
                                            Width="110%">
                                            <AlternatingRowStyle CssClass="AltRowStyle" />
                                            <%--<FooterStyle CssClass="SelectedRowStyle" />--%>
                                            <HeaderStyle CssClass="HeaderStyle" />
                                            <PagerStyle CssClass="PagerStyle" />
                                            <RowStyle CssClass="RowStyle" />
                                        </asp:GridView>
                                    </asp:Panel>  
                                </td>
                            </tr>
                            <tr>
                                <td> 
                                    <asp:HiddenField ID="HiddenField1" runat="server" 
                                        Value='<%# Eval("ProcedureUsed") %>' />
                                    <asp:HiddenField ID="HiddenField2" runat="server" 
                                        Value='<%# Eval("No_Of_Records") %>' />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
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
    </table>
    </asp:Content>
   