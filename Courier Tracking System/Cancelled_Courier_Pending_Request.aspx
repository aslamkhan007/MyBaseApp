<%@ Page Title="" Language="C#" MasterPageFile="~/Courier Tracking System/MasterPage.master" AutoEventWireup="true" CodeFile="Cancelled_Courier_Pending_Request.aspx.cs" Inherits="Courier_Tracking_System_Cancelled_Courier_Pending_Request" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label18" runat="server" Text="Cancelled Courier Requests"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label20" runat="server" Text="From Date"></asp:Label>
            </td>
            <td class="NormalText" >
                             <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                <asp:TextBox ID="txtFrom" runat="server" CssClass="textbox" Columns="10" 
                    MaxLength="10"></asp:TextBox>
            
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
                            Mask="99/99/9999" MaskType="Date" TargetControlID="txtFrom">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" 
                            ControlExtender="MaskedEditExtender1" ControlToValidate="txtFrom" 
                            Display="Dynamic" EmptyValueMessage="ENTER DATE!!" 
                            InvalidValueMessage="INVALID DATE" 
                            ValidationGroup="mandatory"></cc1:MaskedEditValidator>

                <cc1:CalendarExtender ID="txtFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtFrom">
                </cc1:CalendarExtender>   
                </ContentTemplate>
                </asp:UpdatePanel>       

            </td>
            <td class="labelcells" style="width: 78px; height: 16px;">
                <asp:Label ID="Label24" runat="server" Text="To Date"></asp:Label>
            </td>
            <td class="NormalText">
                                         <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                <asp:TextBox ID="txtTo" runat="server" CssClass="textbox" Columns="10" 
                    MaxLength="10"></asp:TextBox>
             
                <cc1:CalendarExtender ID="txtTo_CalendarExtender" runat="server" 
                    TargetControlID="txtTo">
                </cc1:CalendarExtender>

                  <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" 
                            Mask="99/99/9999" MaskType="Date" TargetControlID="txtTo">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" 
                            ControlExtender="MaskedEditExtender1" ControlToValidate="txtTo" 
                            Display="Dynamic" EmptyValueMessage="ENTER DATE!!" 
                            InvalidValueMessage="INVALID DATE" 
                            ValidationGroup="mandatory"></cc1:MaskedEditValidator>

                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtTo">
                </cc1:CalendarExtender> 
                                </ContentTemplate>
                </asp:UpdatePanel>   

            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 108px">
                <asp:Label ID="Label19" runat="server" Text="Courier ID"></asp:Label>
            </td>
            <td class="NormalText">
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                <asp:TextBox ID="txtCourierID" runat="server" Columns="20" CssClass="textbox"   ToolTip="Please enter your unique courier id. E.g- SAL/10001022/2012 or just 1022"
                    MaxLength="20"></asp:TextBox>
                                                    </ContentTemplate>
                </asp:UpdatePanel>   
            </td>
            <td class="labelcells">
                Courier Type</td>
            <td class="NormalText">
                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                 <telerik:RadComboBox ID="DdlCouriertype" Runat="server"  Visible="true" 
                            Height="150" EnableVirtualScrolling="true" ExpandDirection="Down"  
                            DataSourceID="SqlDataSource1" DataTextField="Courier_Service" 
                            DataValueField="Courier_Service">
                 </telerik:RadComboBox>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand=" Select '' as  Courier_Service   Union  SELECT Courier_Service   FROM  jct_Courier_Service_Master where STATUS = 'A' ORDER BY Courier_Service">
                </asp:SqlDataSource>
                   </ContentTemplate>
                </asp:UpdatePanel>   
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 108px">
                <asp:Label ID="Label23" runat="server" Text="Request By"></asp:Label>
            </td>
            <td class="NormalText">
                  <div id="div1" style="display:none;">   
                                        </div>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtRequestBy" runat="server" AutoPostBack="True" 
                            CssClass="textbox" ontextchanged="txtRequestBy_TextChanged"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" 
                            CompletionInterval="10" CompletionListCssClass="AutoExtender" 
                            CompletionListElementID="div1" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" 
                            MinimumPrefixLength="1" ServiceMethod="Email_IDs" 
                            ServicePath="~/WebService.asmx" TargetControlID="txtRequestBy">
                        </cc1:AutoCompleteExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells" style="width: 78px">
                Delivery Type</td>
            <td class="NormalText">                
                 <telerik:RadComboBox ID="ddlDeliveryType" Runat="server"  Visible="true" 
                            Height="150" EnableVirtualScrolling="true" ExpandDirection="Down"  
                            DataSourceID="SqlDataSource2" DataTextField="DeliveryType" 
                            DataValueField="DeliveryType">
                 </telerik:RadComboBox>

                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="select '' as  DeliveryType union  SELECT DeliveryType FROM  jct_courier_Delivery_Type where STATUS = 'A' ORDER BY DeliveryType">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 108px">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <progresstemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </progresstemplate>
                </asp:UpdateProgress>
            </td>
            <td class="NormalText" style="width: 166px">
                  &nbsp;</td>
            <td class="NormalText" style="width: 78px">
                &nbsp;</td>
            <td class="NormalText">
                <asp:LinkButton ID="excel" runat="server" CssClass="buttonXL" Height="32px" 
                    onclick="excel_Click" Width="32px" ToolTip="Excel"></asp:LinkButton>
            </td>
        </tr>
        </table>

    <table style="width:100%;">
        <tr>
            <td class="buttonbackbar">
                   <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkSearch" runat="server" CssClass="buttonc" 
                            onclick="lnkSearch_Click" ValidationGroup="mandatory">FETCH</asp:LinkButton>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
               <%--   <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" onclick="lnkExcel_Click">Excel</asp:LinkButton>--%>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" >                                                 
                            <asp:GridView ID="grdDetail" runat="server"  
                    onselectedindexchanged="grdDetail_SelectedIndexChanged" 
  EmptyDataText="No Record Found ..." onrowdatabound="grdDetail_RowDataBound" >
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GirdItem" />
 
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>

</asp:Content>

