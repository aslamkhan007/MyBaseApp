<%@ Page Title="" Language="C#" MasterPageFile="~/Courier Tracking System/MasterPage.master"
    AutoEventWireup="true" CodeFile="Dispatched_Courier.aspx.cs" Inherits="Courier_Tracking_System_Dispatched_Courier" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label18" runat="server" Text="Dispatched Couriers"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="NormalText" style="width: 108px">
                <asp:Label ID="Label20" runat="server" Text="Dispatched From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 226px">

                <asp:TextBox ID="txtFrom" runat="server" CssClass="textbox" Columns="10" MaxLength="10"></asp:TextBox>
                <cc1:CalendarExtender ID="txtFrom_CalendarExtender" runat="server" TargetControlID="txtFrom">
                </cc1:CalendarExtender>

            </td>
            <td class="NormalText" style="width: 78px">
                <asp:Label ID="Label24" runat="server" Text="Dispatched UpTo"></asp:Label>
            </td>
            <td class="NormalText" style="width: 266px">
                <asp:TextBox ID="txtTo" runat="server" CssClass="textbox" Columns="10" MaxLength="10"></asp:TextBox>
                <cc1:CalendarExtender ID="txtTo_CalendarExtender" runat="server" TargetControlID="txtTo">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 108px">
                <asp:Label ID="Label19" runat="server" Text="Courier ID"></asp:Label>
            </td>
            <td class="NormalText" style="width: 226px">
                <asp:TextBox ID="txtCourierID" runat="server" Columns="20" CssClass="textbox" ToolTip="Please enter your unique courier id. E.g- SAL/10001022/2012 or just 1022"
                    MaxLength="20"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 78px">
                Courier Type
            </td>
            <td class="NormalText" style="width: 266px">

                <asp:DropDownList ID="DdlCouriertype" runat="server" AppendDataBoundItems="True"
                    CssClass="combobox" DataSourceID="SqlDataSource1" DataTextField="Courier_Service"
                    DataValueField="Courier_Service">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                    SelectCommand=" Select '' as  Courier_Service   Union  SELECT Courier_Service   FROM  jct_Courier_Service_Master where STATUS = 'A' ORDER BY Courier_Service">
                </asp:SqlDataSource>

            </td>
            <td class="NormalText">

                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 108px">
                <asp:Label ID="Label23" runat="server" Text="Request By"></asp:Label>
            </td>
            <td class="NormalText" style="width: 226px">
                <div id="div1" style="display: none;">
                </div>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtRequestBy" runat="server" AutoPostBack="True" CssClass="textbox"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" CompletionInterval="10"
                            CompletionListCssClass="AutoExtender" CompletionListElementID="div1" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" MinimumPrefixLength="1"
                            ServiceMethod="Email_IDs" ServicePath="~/WebService.asmx" TargetControlID="txtRequestBy">
                        </cc1:AutoCompleteExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 78px">
                Delivery Type
            </td>
            <td class="NormalText" style="width: 266px">
                <asp:DropDownList ID="ddlDeliveryType" runat="server" AppendDataBoundItems="True"
                    CssClass="combobox" DataSourceID="SqlDataSource2" DataTextField="DeliveryType"
                    DataValueField="DeliveryType">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                    SelectCommand="select '' as  DeliveryType union  SELECT DeliveryType FROM  jct_courier_Delivery_Type where STATUS = 'A' ORDER BY DeliveryType">
                </asp:SqlDataSource>
            </td>
            <td class="NormalText">
                <asp:LinkButton ID="excel" runat="server" CssClass="buttonXL" Height="32px" 
                    onclick="excel_Click" Width="32px" ToolTip="Excel"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 108px">
                Courier Status
            </td>
            <td class="NormalText" style="width: 226px">
                <asp:DropDownList ID="ddlCourierStatus" runat="server" CssClass="combobox">
                    <asp:ListItem Selected="True"></asp:ListItem>
                    <asp:ListItem>Authorized</asp:ListItem>
                    <asp:ListItem>Pending</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText" style="width: 78px">
                Party Type
            </td>
            <td class="NormalText" style="width: 266px">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                <asp:DropDownList ID="ddlPartyType" runat="server" CssClass="combobox" OnSelectedIndexChanged="ddlPartyType_SelectedIndexChanged"
                    AutoPostBack="True">
                    <asp:ListItem>Customer</asp:ListItem>
                    <asp:ListItem>Supplier</asp:ListItem>
                    <asp:ListItem>HO</asp:ListItem>
                    <asp:ListItem Value="Hoshiarpur">Hoshiarpur JCT</asp:ListItem>
                    <asp:ListItem>Sales Office</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                    <asp:ListItem Selected="True">All</asp:ListItem>
                </asp:DropDownList>
                                                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                    &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 108px">
                SubType
            </td>
            <td class="NormalText" style="width: 226px">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                <asp:DropDownList ID="ddlSubpartytype" runat="server" CssClass="combobox" AutoPostBack="True">
                </asp:DropDownList>
                                                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 78px">
                &nbsp;
            </td>
            <td class="NormalText" style="width: 266px">
                &nbsp;
                </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
            <td class="NormalText">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Image/loadingNew.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="buttonbackbar">
                   <asp:UpdatePanel ID="Updbuttons" runat="server">
                    <ContentTemplate>
                <asp:LinkButton ID="lnkSearch" runat="server" CssClass="buttonc" OnClick="lnkSearch_Click">Search</asp:LinkButton>
                
                  </ContentTemplate>
                </asp:UpdatePanel>
                
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="NormalText">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                <asp:Panel ID="Panel1" Width="1000px" runat="server" Height="200px" ScrollBars="Horizontal">
                    <asp:GridView ID="GridView1" runat="server" EmptyDataText="Please Check the Courier ID. No Courier Available for the id entered."
                        Width="100%" AutoGenerateColumns="False" EnableModelValidation="True" ShowFooter="True">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PagerStyle" />
                        <RowStyle CssClass="GridItem" />
                        <Columns>
                            <asp:TemplateField HeaderText="Courier ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblOrdernoF" runat="server" Text='<%# Eval("Courier ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Party Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblLineItemF" runat="server" Text='<%# Eval("Party Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblSortF" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tracking ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblVariantF" runat="server" Text='<%# Eval("Tracking ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cost">
                                <ItemTemplate>
                                    <asp:Label ID="lblCost" runat="server" Text='<%# Eval("Cost") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Account No">
                                <ItemTemplate>
                                    <asp:Label ID="lblAccountNo" runat="server" Text='<%# Eval("AccountNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Booking No">
                                <ItemTemplate>
                                    <asp:Label ID="lblBookingNo" runat="server" Text='<%# Eval("BookingNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Courier">
                                <ItemTemplate>
                                    <asp:Label ID="lblPlantF" runat="server" Text='<%# Eval("Courier") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delivery">
                                <ItemTemplate>
                                    <asp:Label ID="lblClothTypeF" runat="server" Text='<%# Eval("Delivery") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DispatchDt">
                                <ItemTemplate>
                                    <asp:Label ID="lblDispatchDt" runat="server" Text='<%# Eval("DispatchDt") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Authorized Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblReqdtF" runat="server" Text='<%# Eval("Authorized Date") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subject">
                                <ItemTemplate>
                                    <asp:Label ID="lblSubject" runat="server" Text='<%# Eval("Subject") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address">
                                <ItemTemplate>
                                    <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Request By">
                                <ItemTemplate>
                                    <asp:Label ID="lblReqBy" runat="server" Text='<%# Eval("Request By") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remarks">
                                <ItemTemplate>
                                    <asp:Label ID="lblRemarks1" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ref No">
                                <ItemTemplate>
                                    <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("RefNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                                  </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
