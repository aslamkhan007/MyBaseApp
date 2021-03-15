<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="Sotck_Movement_Authorization.aspx.vb" Inherits="OPS_Sotck_Movement_Authorization" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../Scripts/jquery.min.js"></script>
    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../Image/minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "../Image/plus.png");
            $(this).closest("tr").next().remove();
        });
    </script>
    <table style="width: 100%;">
        <tr>
            <td class="tableheader">
                Authorize Stock Movement
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td style="font-size: 10pt; font-weight: bold" class="labelcells_s">
                Summary of Pending Stock Movment Requests...(Click to See Detail)
            </td>
        </tr>
        <tr>
            <td>
                <%--<td style="background-color: #B2B2B2; vertical-align: top; text-align: center; font-weight: bold;
                                                font-size: 10pt; text-transform: capitalize; color: Blue; font-family: 'Trebuchet MS' , Tahoma;
                                                ">
                                                <asp:Label ID="Label19" runat="server" Text='<%# Eval("AreaName") %>'></asp:Label>
                                            </td>--%>
                <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource2" RepeatDirection="Horizontal"
                    ToolTip="Click any Area to see the detials of it." Width="100%">
                    <ItemTemplate>
                        <table cellpadding="1" cellspacing="0" style="width: 100%;">
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" style="width: 100%;">
                                        <tr>
                                            <td align="center" class="HighlightBox">
                                                <asp:Label ID="lblCount" runat="server" Text='<%# Eval("Count") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <%--<td style="background-color: #B2B2B2; vertical-align: top; text-align: center; font-weight: bold;
                                                font-size: 10pt; text-transform: capitalize; color: Blue; font-family: 'Trebuchet MS' , Tahoma;
                                                ">
                                                <asp:Label ID="Label19" runat="server" Text='<%# Eval("AreaName") %>'></asp:Label>
                                            </td>--%>
                                            <td align="center" class="GridRowRed">
                                                <asp:LinkButton ID="cmdArea" runat="server" CommandName="Select" ForeColor="White"
                                                    Text='<%# Eval("AreaName") %>'></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                    SelectCommand="Jct_Ops_Pending_Authorization_Count_Fetch_Ods" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter Name="UserCode" SessionField="Empcode" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Panel ID="Panel4" runat="server" Height="200px" Width="100%" ScrollBars="Horizontal">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" EnableModelValidation="True"
                                Width="100%" DataKeyNames="SanctionNoteID">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl" runat="server" Visible="false" Text="**" ForeColor="Red"></asp:Label>
                                            <img id="imageSanctionNoteID-<%# Eval("SanctionNoteID") %>" alt="Click to show/hide Description"
                                                border="0" src="../Image/plus.png" />
                                            <div id="SanctionNoteID-<%# Eval("SanctionNoteID") %>" style="display: none; position: relative;
                                                left: 25px;">
                                                <asp:GridView ID="nestedGridView" runat="server" Width="100%" AutoGenerateColumns="False">
                                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                                    <HeaderStyle CssClass="GridHeader" />
                                                    <RowStyle CssClass="GridItem" />
                                                    <AlternatingRowStyle CssClass="GridAI" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Description" HeaderText="Description" />
                                                    </Columns>
                                                </asp:GridView>
                                                <hr />
                                                <asp:GridView ID="nestedGridView_MultipleID" runat="server" Width="100%" AutoGenerateColumns="False">
                                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                                    <HeaderStyle CssClass="GridHeader" />
                                                    <RowStyle CssClass="GridItem" />
                                                    <AlternatingRowStyle CssClass="GridAI" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Invoice" HeaderText="Invoice" />
                                                        <asp:BoundField DataField="Sort" HeaderText="Sort" />
                                                        <asp:BoundField DataField="Customer" HeaderText="Customer" />
                                                        <asp:BoundField DataField="SalesPerson" HeaderText="SalesPerson" />
                                                        <asp:BoundField DataField="InvoiceQty" HeaderText="InvoiceQty" />
                                                        <asp:BoundField DataField="ReturnQty" HeaderText="ReturnQty" />
                                                        <asp:BoundField DataField="Reason" HeaderText="Reason" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                                <SelectedRowStyle CssClass="GridRowGreen" />
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DataList1" EventName="ItemCommand" />
                            <asp:AsyncPostBackTrigger ControlID="CmdAuthorize" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </asp:Panel>
                <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="ImageProg" runat="server" ImageUrl="~/Image/Progress02.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td>
                <asp:Label ID="lblDetail0" runat="server" Text="Detail" Font-Bold="True" Font-Size="10pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DataList ID="DtlListSummary" runat="server" RepeatColumns="4" Width="100%" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <table class="tableback" style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="Total Items"></asp:Label>
                                        </td>
                                        <td class="HoverMenu">
                                            <asp:Label ID="lblTotalItems" runat="server" Text='<%# Eval("TotalItems") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label10" runat="server" Text="Total Qty."></asp:Label>
                                        </td>
                                        <td class="HoverMenu">
                                            <asp:Label ID="lblTotalQty" runat="server" Text='<%# Eval("TotalMeters") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Text="Total Fresh Qty"></asp:Label>
                                        </td>
                                        <td class="HoverMenu">
                                            <asp:Label ID="lblQtrAsFresh" runat="server" Text='<%# Eval("TotalFreshMeters") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="T" runat="server" Text="Total NonFresh Qty"></asp:Label>
                                        </td>
                                        <td class="HoverMenu">
                                            <asp:Label ID="lblQtyAsNonFresh" runat="server" Text='<%# Eval("TotalNonFreshMtrs") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label9" runat="server" Text="Total No of Bales"></asp:Label>
                                        </td>
                                        <td class="HoverMenu">
                                            <asp:Label ID="lblTotalNoOfBales" runat="server" Text='<%# Eval("BaleCount") %>'></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:Panel ID="Panel5" runat="server" Height="200px" ScrollBars="Both" Width="100%">
                            <asp:GridView ID="grdRequestDetail" runat="server" AutoGenerateColumns="true" EnableModelValidation="True"
                                Width="100%" ShowFooter="False">
                                <SelectedRowStyle CssClass="GridRowGreen" />
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                                <%-- <RowStyle CssClass="GridItem" />--%>
                                <%--  <AlternatingRowStyle CssClass="GridAI" />--%>
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="DataList1" EventName="ItemCommand" />
                        <asp:AsyncPostBackTrigger ControlID="CmdAuthorize" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td class="lebelcells_s">
                <asp:Label ID="lblDetail" runat="server" Text="Authorization History...." Font-Bold="True"
                    Font-Size="10pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="GrdAuthHistory" runat="server" Width="100%" EnableModelValidation="True"
                            AutoGenerateColumns="true">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <EmptyDataTemplate>
                                Not Data Found... ! ! !
                            </EmptyDataTemplate>
                            <HeaderStyle CssClass="GridHeader" />
                            <RowStyle CssClass="GridItem" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="DataList1" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="CmdAuthorize" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" CssClass="panelbg">
                <asp:DataList ID="dtlAttachment" runat="server">
                    <ItemTemplate>
                        <table style="width: 100%;">
                            <tr>
                                <td class="NormalText" style="width: 114px">
                                    <asp:Label ID="lblAttachments" runat="server" Text='<%# Eval("Attachment") %>'></asp:Label>
                                </td>
                                <td class="NormalText">
                                    <asp:LinkButton ID="lnkAttachment" runat="server" CommandName="Download" CommandArgument='<%# Eval("AttachedFile") %>'
                                        Text='<%# Eval("AttachedFile") %>'></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="DataList1" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="CmdAuthorize" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <table style="width: 100%;display:none" class="tableback" >
        <tr>
            <td colspan="3">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" Text="Pricing Detail"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanelPricingDetail" runat="server">
                    <ContentTemplate>
                        Pricing History....
                        <asp:GridView ID="GrdPricingHIstory" runat="server" AutoGenerateColumns="True" Width="100%"
                            EnableModelValidation="True">
                            <HeaderStyle CssClass="GridHeader" />
                        </asp:GridView>
                        Proposed Pricing...<asp:GridView ID="GrdPricingDetail" runat="server" AutoGenerateColumns="False"
                            Width="100%" EnableModelValidation="True">
                            <SelectedRowStyle CssClass="GridRowGreen" />
                            <Columns>
                                <asp:BoundField DataField="Item_no" HeaderText="ItemNo" />
                                <asp:BoundField DataField="Variant" HeaderText="Variant" />
                                <asp:BoundField DataField="AvgRate" HeaderText="AvgRate" />
                                <asp:BoundField DataField="AvgDNV" HeaderText="AvgDNV" />
                                <%--    <asp:TemplateField HeaderText="AsPer Req">
                            <ItemTemplate>
                                <asp:CheckBox ID="ChkAsPerReq" runat="server" AutoPostBack="True" 
                                    oncheckedchanged="ChkAsPerReq_CheckedChanged" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Should Be SellingPrice">
                            <ItemTemplate>
                                <telerik:RadNumericTextBox ID="NewPrice" Runat="server" CssClass="textbox" 
                                    Culture="en-US" DbValueFactor="1" 
                                    EmptyMessage="Give proposed SellingPrice" LabelWidth="64px" 
                                    MaxValue="9999.99" MinValue="0" ToolTip="Proposed Selling Price" 
                                    Width="160px" ShowSpinButtons="True" ValidationGroup="GrpApply" 
                                    Height="20px">
                                </telerik:RadNumericTextBox>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ErrorMessage="Must Give either SalePrice as per Request OR Give a new SellingPrice" ControlToValidate="NewPrice" Display="Dynamic" 
                                    SetFocusOnError="true" ValidationGroup="GrpApply" ></asp:RequiredFieldValidator>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />
                            <RowStyle CssClass="GridItem" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td colspan="4">
                <asp:Panel ID="Panel1" runat="server" CssClass="PanelBack">
                    <table style="width: 100%;">
                        <tr>
                            <td width="200">
                                Action
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlAction" runat="server" CssClass="combobox">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Authorize</asp:ListItem>
                                    <asp:ListItem>Cancel</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlAction"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="GrpApply"
                                    Enabled="true"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td width="200">
                Remarks (if Any)
            </td>
            <td>
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRemarks"
                    Display="Dynamic" ErrorMessage="**Give Proper Remarks" SetFocusOnError="True"
                    ValidationGroup="GrpApply"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <%-- <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel2" runat="server" Visible="False">
                            <table class="tableback" style="width: 100%;">
                                <tr>
                                    <td colspan="3" style="font-family: Calibri; font-size: medium; font-style: oblique;
                                        font-weight: 100">
                                        Logistics
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblTransport" runat="server" Text="Final Mode of Transport"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlFinalMode" runat="server" CssClass="combobox">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblFreightVal" runat="server" Text="Final Freight Value"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFinalFreightVal" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;<asp:Label ID="Label1" runat="server" Text="Coments For SalePerson"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtComentForSaleP" runat="server" CssClass="textbox" MaxLength="200"
                                                    Width="250px"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>--%>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="CmdAuthorize" runat="server" BorderStyle="None" ValidationGroup="GrpApply"
                            CssClass="buttonc">Apply</asp:LinkButton>
                        <asp:LinkButton ID="CmdCancel" runat="server" CssClass="buttonc">Clear</asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
<%--<asp:GridView ID="grdRequestDetail" runat="server" AutoGenerateColumns="False" 
                                EnableModelValidation="True" Width="100%">
                                <SelectedRowStyle CssClass="GridRowGreen" />
                                <Columns>
                                    <asp:BoundField DataField="CurrentOrder" HeaderText="Current Order" />
                                    <asp:BoundField DataField="CurrentOrderLine" HeaderText="LineItem" />
                                    <asp:BoundField DataField="Item_no" HeaderText="Sort" />
                                    <asp:BoundField DataField="OrderVar" HeaderText="OrderVar" />
                                    <asp:BoundField DataField="Bale_No" HeaderText="BaleNo" />
                                    <asp:BoundField DataField="Varaint" HeaderText="Varaint" />
                                    <asp:BoundField DataField="QtyBooked" HeaderText="QtyBooked" />
                                    <asp:BoundField DataField="ItemBookedAt" HeaderText="BookedAt" />
                                    <asp:BoundField DataField="DNV" HeaderText="DNV" />
                                    <asp:BoundField DataField="SellingPrice" HeaderText="SellingPrice" />
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                                <AlternatingRowStyle CssClass="GridAI" />
                            </asp:GridView>--%>
<%--                     <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                                CellSpacing="0" GridLines="None" ShowGroupPanel="True">
                                <ClientSettings AllowDragToGroup="True">
                                </ClientSettings>
                                <MasterTableView>
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                                        Visible="True">
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                                        Visible="True">
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="RequestID" 
                                            FilterControlAltText="Filter column column" Groupable="False" 
                                            HeaderText="RequestID" UniqueName="column">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="TransferedBy" 
                                            FilterControlAltText="Filter column1 column" Groupable="False" 
                                            HeaderText="TransferedBy" UniqueName="column1">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="TransferedOn" 
                                            FilterControlAltText="Filter column2 column" HeaderText="TransferedOn" 
                                            UniqueName="column2">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PackedIn" 
                                            FilterControlAltText="Filter column3 column" HeaderText="PackedIn" 
                                            UniqueName="column3">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Shade" 
                                            FilterControlAltText="Filter column4 column" HeaderText="Shade" 
                                            UniqueName="column4">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Item" 
                                            FilterControlAltText="Filter column5 column" HeaderText="Item" 
                                            UniqueName="column5">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="BaleNo" 
                                            FilterControlAltText="Filter column6 column" HeaderText="BaleNo" 
                                            UniqueName="column6">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Variant" 
                                            FilterControlAltText="Filter column7 column" HeaderText="Variant" 
                                            UniqueName="column7">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Mtrs" 
                                            FilterControlAltText="Filter column8 column" HeaderText="Mtrs" 
                                            UniqueName="column8">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="SellingPrice" 
                                            FilterControlAltText="Filter column9 column" HeaderText="SellingPrice" 
                                            UniqueName="column9">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="RateUom" 
                                            FilterControlAltText="Filter column10 column" HeaderText="RateUom" 
                                            UniqueName="column10">
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                    </EditFormSettings>
                                    <PagerStyle PageSizeControlType="RadComboBox" />
                                </MasterTableView>
                                <PagerStyle PageSizeControlType="RadComboBox" />
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>
                            </telerik:RadGrid>
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:jctdevConnectionString %>" >
                                
                              <%--  SelectCommand="Jct_Ops_ODS_Transfer_Sell_Items_Fetch @RequestID,@p1,@p2,@p3">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="GridView1" DbType="String" Name="RequestID" 
                                        PropertyName="SelectedValue" Type="String" />
                                    <asp:Parameter DbType="String" DefaultValue="" Name="p1" />
                                    <asp:Parameter DbType="String" DefaultValue="" Name="p2" />
                                    <asp:Parameter DbType="String" DefaultValue="" Name="p3" />
                                </SelectParameters>
                            </asp:SqlDataSource>--%>