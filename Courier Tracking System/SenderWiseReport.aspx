<%@ Page Title="" Language="C#" MasterPageFile="~/Courier Tracking System/MasterPage.master" AutoEventWireup="true" CodeFile="SenderWiseReport.aspx.cs" Inherits="Courier_Tracking_System_SenderWiseReport" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="5">
                <asp:Label ID="Label18" runat="server" Text="Sender Wise Courier Report"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 112px">
                <asp:Label ID="Label23" runat="server" Text="Date From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 185px">
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtDateFrom">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText" style="width: 74px">
                <asp:Label ID="Label24" runat="server" Text="Date To"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" 
                    TargetControlID="txtDateTo">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 112px">
                <asp:Label ID="Label19" runat="server" Text="Select Type"></asp:Label>
            </td>
            <td class="NormalText" style="width: 185px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" RenderMode="Inline">
                <ContentTemplate>
                
              
                <asp:DropDownList ID="ddlSelectType" runat="server" AutoPostBack="True" 
                    CssClass="combobox" DataSourceID="SqlDataSource1" DataTextField="SendType" 
                    DataValueField="SendType" 
                    onselectedindexchanged="ddlSelectType_SelectedIndexChanged">
                    <asp:ListItem>Customer</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    
                    
                        SelectCommand="Select '  All  ' as [SendType] Union SELECT DISTINCT [SendType] FROM [jct_courier_Request]">
                </asp:SqlDataSource>
                  </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" colspan="2">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                    AssociatedUpdatePanelID="UpdatePanel4" DisplayAfter="10">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/loading.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 112px">
                <asp:Label ID="Label20" runat="server" Text="Party Name"></asp:Label>
            </td>
            <td class="NormalText" style="width: 185px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" 
                    RenderMode="Inline">
                    <ContentTemplate>
                            <asp:DropDownList ID="ddlName" runat="server">
                            </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSelectType" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 74px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 112px">
                <asp:Label ID="Label21" runat="server" Text="Courier Service"></asp:Label>
            </td>
            <td class="NormalText" style="width: 185px">
                <asp:DropDownList ID="ddlCourierService" runat="server" AutoPostBack="True" 
                    CssClass="combobox" DataSourceID="SqlDataSource2" DataTextField="Courier_Service" 
                    DataValueField="Courier_Service" 
                    onselectedindexchanged="ddlSelectType_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    
                    SelectCommand="Select '  All  ' as [Courier_Service]  Union SELECT Courier_Service FROM [jct_Courier_Service_Master] WHERE ([STATUS] = @STATUS)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="A" Name="STATUS" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td class="NormalText" style="width: 74px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 112px">
                <asp:Label ID="Label30" runat="server" Text="Item Sent"></asp:Label>
            </td>
            <td class="NormalText" style="width: 185px">
                <asp:DropDownList ID="ddlCourierType" runat="server" AutoPostBack="True" 
                    CssClass="combobox" DataSourceID="SqlDataSource4" DataTextField="CourierType" 
                    DataValueField="CourierType" 
                    onselectedindexchanged="ddlSelectType_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    
                    SelectCommand="Select '  All  ' as [CourierType] Union SELECT DISTINCT [CourierType] FROM [jct_courier_Type_Master] WHERE ([STATUS] = @STATUS)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="A" Name="STATUS" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td class="NormalText" style="width: 74px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 112px">
                <asp:Label ID="Label22" runat="server" Text="Courier Delivery"></asp:Label>
            </td>
            <td class="NormalText" style="width: 185px">
                <asp:DropDownList ID="ddlDelivery" runat="server" AutoPostBack="True" 
                    CssClass="combobox" DataSourceID="SqlDataSource3" DataTextField="DeliveryType" 
                    DataValueField="DeliveryType" 
                    onselectedindexchanged="ddlSelectType_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    
                    SelectCommand="Select '  All  ' as [DeliveryType] Union SELECT [DeliveryType] FROM [jct_courier_Delivery_Type] WHERE ([STATUS] = @STATUS)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="A" Name="STATUS" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td class="NormalText" style="width: 74px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
           <td class="NormalText">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="100">
                    <progresstemplate>
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Image/load.gif" />
                    </progresstemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="5">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                            onclick="lnkFetch_Click">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc">Reset</asp:LinkButton>
                       
                        <asp:LinkButton ID="lnkSummary" runat="server" CssClass="buttonc" 
                            onclick="lnkSummary_Click">Summary</asp:LinkButton>
                       
                    </ContentTemplate>
                </asp:UpdatePanel>
                 <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" 
                    onclick="lnkExcel_Click1">To Excel</asp:LinkButton>
            </td>
        </tr>
        </table>
    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="Panel2" runat="server" Width="900px">
            <asp:GridView ID="grdCourierCount" runat="server" CssClass="GridViewStyle">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <RowStyle CssClass="RowStyle" />
           </asp:GridView>
        </asp:Panel>
    </ContentTemplate>
     <Triggers>
        <asp:AsyncPostBackTrigger ControlID="lnkSummary" EventName="Click" />
     </Triggers>
    </asp:UpdatePanel>
    <table style="width:100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="500px" ScrollBars="Both" 
                            Width="900px">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                CssClass="GridViewStyle" EnableModelValidation="True" AllowPaging="True" 
                                onpageindexchanging="GridView1_PageIndexChanging" 
                                onrowdatabound="GridView1_RowDataBound" ShowFooter="True" Width="100%">
                                <AlternatingRowStyle CssClass="AlternateRowStyle" />
                                <Columns>
                                    <asp:HyperLinkField DataNavigateUrlFields="Party_Name" 
                                        DataNavigateUrlFormatString="Detailed_Cost.aspx?Party_Name={0}" 
                                        Text="Detail" Target="_blank"  />
                                    <asp:TemplateField HeaderText="Party Code">
                                        <ItemTemplate>
                                            <asp:Label ID="Label25" runat="server" Text='<%# Eval("PartyCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Party Name">
                                        <ItemTemplate>
                                            <asp:Label ID="Label26" runat="server" Text='<%# Eval("Party_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Cost">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCost" runat="server" Text='<%# Eval("Cost") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No. of Couriers">
                                        <ItemTemplate>
                                            <asp:Label ID="Label29" runat="server" Text='<%# Eval("TotalCouriers") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle CssClass="FooterRow" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="RowStyle" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
</asp:Content>

