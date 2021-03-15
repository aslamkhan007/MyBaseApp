<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="OPSTracking.aspx.vb" Inherits="OPS_OPSTracking" %>

 
  <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Order Profitability Tracking</td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 101px">
                <asp:Label ID="Label1" runat="server" Width="103px" Height="16px">Order Date From</asp:Label>
            </td>
            <td class="textcells" style="width: 201px">
                <asp:UpdatePanel ID="From" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox  ID="TxtEffFrom" TabIndex="3" runat="server" Width="70px"
                            CssClass="textbox" Enabled="True" MaxLength="8" ></asp:TextBox>
                        <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" Width="114px" 
                            ControlToValidate="TxtEffFrom"
                            Display="Dynamic" 
                            ControlExtender="MaskedEditExtender1" 
                            TooltipMessage="MM/DD/YYYY"
                            IsValidEmpty="False" 
                            EmptyValueMessage="*" 
                            InvalidValueMessage="The Date is invalid">
                          </cc1:MaskedEditValidator>
                          
                          <cc1:CalendarExtender
                                ID="CalFrom" runat="server" TargetControlID="TxtEffFrom" Animated="False" Format="MM/dd/yyyy">
                            </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="TxtEffFrom"
                            MaskType="Date" Mask="99/99/9999">
                        </cc1:MaskedEditExtender>
                      
                    </ContentTemplate>
                </asp:UpdatePanel></td>
            <td class="textcells" style="width: 165px">
                <asp:Label ID="Label6" runat="server" Width="99px">Order Date To</asp:Label>
            </td>
            <td class="textcells" style="width: 969px">
                <asp:UpdatePanel ID="ETo" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtEffTo" TabIndex="4" runat="server" Width="70px" CssClass="textbox"
                            Enabled="True" MaxLength="8" ></asp:TextBox>
                            <cc1:MaskedEditValidator
                                ID="MaskedEditValidator2" runat="server" 
                                ControlToValidate="TxtEffTo" Display="Dynamic"
                                ControlExtender="MaskedEditExtender2" 
                                TooltipMessage="MM/DD/YYYY" 
                                IsValidEmpty="False"
                                EmptyValueMessage="*" 
                                InvalidValueMessage="The Date is invalid ">
                             </cc1:MaskedEditValidator>
                             <cc1:CalendarExtender    ID="CalTo" runat="server" TargetControlID="TxtEffTo" Animated="False" Format="MM/dd/yyyy">
                                </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="TxtEffTo"
                            MaskType="Date" Mask="99/99/9999">
                        </cc1:MaskedEditExtender>
                             </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Sales Team</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSalesTeam" runat="server" CssClass="combobox" 
                            AutoPostBack="True" Width="120px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Sales Person</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSalesPerson" runat="server" 
    CssClass="combobox" Width="120px">
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
            <td class="labelcells">
                Customer</td>
            
                              <td class="NormalText" style="width: 200px">

                    <div id="divwidth" style="display:none;">   
                        </div>
                              
                                <asp:TextBox ID="TxtCustomer" runat="server" CssClass="textbox"                                                               
                                    TabIndex="2" Width="200" AutoPostBack="True" ></asp:TextBox>
                                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                                                                CompletionInterval="10" CompletionListCssClass="AutoExtender" 
                                                     
                                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                                        CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20"  
                                                                 MinimumPrefixLength="1" ServiceMethod="OPS_Customer" 
                                                                ServicePath="~/CityService.asmx" 
                                                        TargetControlID="TxtCustomer">
                                                            </cc1:AutoCompleteExtender>
                                                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" 
                                                                TargetControlID="TxtCustomer" WatermarkCssClass="normalfld" 
                                                                WatermarkText="ALL">
                                                            </cc1:TextBoxWatermarkExtender>
                      
                        
                        
            </td>



 
            <td class="labelcells">
                Order No</td>
            <td>
                 
                                 <asp:TextBox ID="TxtOrder" runat="server" CssClass="textbox" 
                                    TabIndex="3" Width="200px"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="OrderExt" runat="server" 
                                    CompletionInterval="10" CompletionListCssClass="AutoExtender" 
                                              CompletionListElementID="divwidth" 
                                              CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                              CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" 
                                    MinimumPrefixLength="4" ServiceMethod="OPS_ORDER" 
                                    ServicePath="~/CityService.asmx" TargetControlID="TxtOrder" 
                                    UseContextKey="True">
                                </cc1:AutoCompleteExtender>
                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" 
                                    TargetControlID="TxtOrder" WatermarkCssClass="normalfld" 
                                    WatermarkText="ALL">
                                </cc1:TextBoxWatermarkExtender>
                        
                        
            </td>
        </tr>
        <tr>
            <td class="labelcells" colspan="4">

                <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" Height="22px" Width="84px"
                    CausesValidation="False">Fetch</asp:LinkButton>
                <asp:LinkButton ID="CmdXl" runat="server" CssClass="buttonXL" Width="64px"></asp:LinkButton>
                </td>
            
        </tr>
        <tr>
            <td colspan="4">
                 <asp:Panel ID="pnlGrid" runat="server" Height="800px" Width="1000px" ScrollBars="Both">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="grdTracking" runat="server" AllowPaging="True" CssClass="GridViewStyle"
                                GridLines="None" PageSize="50" ShowFooter="True" Width="100%">
                                <RowStyle CssClass="RowStyle" />
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <EditRowStyle CssClass="EditRowStyle" />
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </asp:Panel></td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
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
