<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="Quotation_Main.aspx.vb" Inherits="OPS_Quotation_Main" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="NormalText" style="width: 100%;">
        <tr>
            <td class="tableheader">
                Quotation<asp:UpdatePanel ID="UpdatePanel27" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                    <ContentTemplate>
                        &nbsp;<asp:Label ID="lblQuotationNo" runat="server"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ibtSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ibtSave1" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="txtQuotationNo" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtQuotationNo"
                    ErrorMessage="* Please save information to create/save Quotation or provide quotation no to View/Add its detail."
                    ValidationGroup="Tab"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="height: 12px; font-weight: bold; font-size: 10pt; text-align: center;
                text-decoration: none; vertical-align: text-top;" valign="baseline">
                <asp:ImageButton ID="ibtBasicInfo" runat="server" ImageUrl="~/OPS/Image/Tab_BasicInfo.png"
                    Enabled="False" />
                <asp:ImageButton ID="ibtShadeQty" runat="server" ImageUrl="~/OPS/Image/STab_ShadesQuantities.png"
                    ValidationGroup="Tab" />
                <asp:ImageButton ID="ibtPayTerms" runat="server" ImageUrl="~/OPS/Image/STab_PaymentTerms.png"
                    ValidationGroup="Tab" />
                <asp:ImageButton ID="ibtDispatchDetail" runat="server" ImageUrl="~/OPS/Image/STab_DispatchDetail.png"
                    ValidationGroup="Tab" />
            </td>
        </tr>
        <tr>
            <td style="height: 0px; font-weight: bold; font-size: 9pt; font-family: 'trebuchet MS';">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td style="height: 12px; font-weight: bold; font-size: 10pt; width: 150px;">
                Quotation No</td>
            <td style="height: 12px; width: 380px;">
                <asp:UpdatePanel ID="UpdatePanel28" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtQuotationNo" runat="server" CssClass="textbox" Width="110px"
                            AutoPostBack="True"></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ibtSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ibtSave1" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:ImageButton ID="ibtViewQuotation" runat="server" ImageUrl="~/Image/Icons/Action/Search.png"
                    ToolTip="Search Item Code" Width="24px" Visible="False" />
                <asp:ImageButton ID="ibtSearchQuotation" runat="server" ImageUrl="~/Image/Icons/Action/Search.png"
                    ToolTip="Quotation Panel to Search Quotations" Width="24px" CausesValidation="False" />
            </td>
            <td colspan="2" rowspan="2">
                <asp:ImageButton ID="ImageButton12" runat="server" ImageUrl="~/Image/Icons/Action/document_add.png"
                    ToolTip="New Quotation" Width="32px" CausesValidation="False" />
                <asp:ImageButton ID="ibtSave1" runat="server" ImageUrl="~/Image/Icons/Action/document_save.png"
                    ToolTip="Create and Save Quotation" Width="32px" />
                <asp:ImageButton ID="cmdAuthorise2" runat="server" ImageUrl="~/Image/Icons/Action/Authorise.png"
                    ToolTip="Authorise" Width="32px" />
                <asp:ImageButton ID="ibtFreeze" runat="server" ImageUrl="~/Image/Icons/Action/Freeze.png"
                    ToolTip="Freeze" Width="32px" />
                <asp:ImageButton ID="ibtDelete2" runat="server" Style="width: 32px" ImageUrl="~/Image/Icons/Action/document_delete.png"
                    ToolTip="Cancel Quotation" />
                <asp:ImageButton ID="cmdCancel" runat="server" ImageUrl="~/Image/Icons/Action/Cancel.png"
                    ToolTip="Reject Authorised Quotation" Width="32px" />
                <asp:ImageButton ID="ibtBack" runat="server" ImageUrl="~/Image/Icons/Action/back.png"
                    ToolTip="Back" Width="32px" OnClientClick="window.history.go(-1);return false;" />
                <asp:ImageButton ID="ImageButton13" runat="server" ImageUrl="~/Image/Icons/Action/Search.png"
                    ToolTip="Preview Quotation" Width="32px" CausesValidation="False" />
                <asp:ImageButton ID="ImageButton14" runat="server" ImageUrl="~/Image/Icons/Action/dollar.png"
                    ToolTip="Preview Quotation" Width="32px" CausesValidation="False" />
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Status</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Revision
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblRevision" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Dated</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblQuoteDate" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Validity Status
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblValidity" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Expiry Date</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblExpiryDate" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                SO Requested</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel66" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblSORequested" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Authorisation Status</td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel68" runat="server">
                    <ContentTemplate>
                        <asp:DataList ID="DataList1" runat="server" 
                            DataSourceID="dsAuthorisationStatus" RepeatDirection="Horizontal" Width="100%">
                            <ItemTemplate>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width: 31px">
                                            <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("Status_Img") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAuthorityName" runat="server" Text='<%# Eval("empname") %>'></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:SqlDataSource ID="dsAuthorisationStatus" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                            SelectCommand="jct_ops_get_quote_auth_queue" 
                            SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblQuotationNo" Name="Quotation_No" 
                                    PropertyName="Text" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
    <table class="tableback" style="width: 100%;">
        <tr>
            <td style="height: 12px; font-weight: bold; font-size: 10pt;" colspan="4">
                Basic Info<hr />
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 12px; width: 150px;">
                Quotation Owner
            </td>
            <td style="height: 12px; width: 380px;">
                <asp:UpdatePanel ID="UpdatePanel59" runat="server">
                    <ContentTemplate>
                        <asp:RadioButtonList ID="rblQuotOwner" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                            Width="100%">
                            <asp:ListItem Value="S">Self</asp:ListItem>
                            <asp:ListItem Value="L">Team Leader</asp:ListItem>
                        </asp:RadioButtonList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells" style="height: 12px">
                <asp:Label ID="lblTeamLeader" runat="server" Text="Team Leader"></asp:Label>
            </td>
            <td style="height: 12px" valign="top">
                <asp:UpdatePanel ID="UpdatePanel58" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlTeamLeader" runat="server" CssClass="combobox" AppendDataBoundItems="True"
                            DataSourceID="dsSalesPersons" DataTextField="group_desc" DataValueField="sale_person_code">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="dsSalesPersons" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                            SelectCommand="jct_ops_sales_persons" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 12px; width: 150px;">
                Quotation Type
            </td>
            <td style="height: 12px; width: 380px;">
                <asp:UpdatePanel ID="UpdatePanel67" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlQuotationType" runat="server" CssClass="combobox">
                            <asp:ListItem>Regular</asp:ListItem>
                            <asp:ListItem>Forecast</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells" style="height: 12px">
                Sale Order Type</td>
            <td style="height: 12px" valign="top">
                <asp:DropDownList ID="ddlSaleOrderType" runat="server" CssClass="combobox" 
                    DataSourceID="dsSalesOrderType" DataTextField="tran_type" 
                    DataValueField="tran_type" CausesValidation="True" 
                    AppendDataBoundItems="True">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="dsSalesOrderType" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                    SelectCommand="jct_ops_so_type" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 12px; width: 150px;">
                Search Customer
            </td>
            <td style="height: 12px; width: 380px;">
                <asp:UpdatePanel ID="UpdatePanel38" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSearchCustomer" runat="server" AutoPostBack="True" Columns="50"
                            CssClass="textbox"></asp:TextBox>
                        <div id="div2" style="display: none;">
                            <cc1:AutoCompleteExtender ID="txtSearchCustomer_AutoCompleteExtender" runat="server"
                                CompletionInterval="10" CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="OPS_Customer"
                                CompletionListCssClass="AutoExtender" ServicePath="~/WebService.asmx" CompletionListElementID="div2"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListItemCssClass="AutoExtenderList"
                                TargetControlID="txtSearchCustomer">
                            </cc1:AutoCompleteExtender>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells" style="height: 12px">
                &nbsp;</td>
            <td style="height: 12px" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 12px; width: 150px;">
                Customer/Prospect Code
            </td>
            <td style="height: 12px; width: 380px;">
                <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtCustomerCode" runat="server" Columns="10" CssClass="textbox"
                            Enabled="False" ReadOnly="True"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCustomerCode"
                            ErrorMessage="Please enter Customer">*</asp:RequiredFieldValidator>
                        <asp:ImageButton ID="cmdNewProspect" runat="server" CausesValidation="False" Height="24px"
                            ImageUrl="~/Image/Icons/Action/NewDocument.png" PostBackUrl="CustomerProspectDetail.aspx"
                            ToolTip="Click to Create New Prospect" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells" style="height: 12px">
                <asp:Label ID="Label16" runat="server" Text="Customer Name"></asp:Label>
            </td>
            <td style="height: 12px" valign="top">
                <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 150px">
                Plant
            </td>
            <td style="width: 380px">
                <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPlant" runat="server" CssClass="combobox" AutoPostBack="True">
                            <asp:ListItem>Cotton</asp:ListItem>
                            <asp:ListItem>Taffeta</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Product Category</td>
            <td>
                <div id="divwidth" style="display: none;">
                </div>
                <asp:UpdatePanel ID="UpdatePanel36" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlProductCatg" runat="server" CssClass="combobox">
                            <asp:ListItem>Fabric</asp:ListItem>
                            <asp:ListItem Enabled="False">Yarn</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 150px">
                Search Sort/Item
            </td>
            <td style="width: 380px">
                <asp:UpdatePanel ID="UpdatePanel39" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSearchItem" runat="server" AutoPostBack="True" Columns="50" CssClass="textbox"
                            ToolTip="Type in minimum of 3 characters to search an Item"></asp:TextBox>
                        <div id="div3" style="display: none;">
                            <cc1:AutoCompleteExtender ID="txtSearchItem_AutoCompleteExtender" runat="server"
                                CompletionInterval="10" CompletionSetCount="20" ServiceMethod="OPS_Fabric_Items"
                                CompletionListCssClass="AutoExtender" ServicePath="~/WebService.asmx" CompletionListElementID="div3"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListItemCssClass="AutoExtenderList"
                                TargetControlID="txtSearchItem" FirstRowSelected="True">
                            </cc1:AutoCompleteExtender>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Enquiry No / Dev No</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblEnqNo" runat="server"></asp:Label>
                        &nbsp;/
                        <asp:Label ID="lblDevNo" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 150px">
                Item/Sort Description
            </td>
            <td style="width: 380px" valign="top">
                <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblItemDescription" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Item/Sort No</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel24" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox ID="txtItemCode" runat="server" CssClass="textbox" Width="66px" AutoPostBack="True"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtItemType"
                            ErrorMessage="Please provide valid Item Code">*</asp:RequiredFieldValidator>
                        <asp:ImageButton ID="ibtRefresh" runat="server" CausesValidation="False" ImageUrl="~/Image/Icons/Action/Refresh.png"
                            ToolTip="Click to Refresh Fabric Particulars &amp; Costing Details for this Quality"
                            Width="24px" Visible="False" />
                        <asp:ImageButton ID="cmdSearchItem" runat="server" CausesValidation="False" ImageUrl="~/Image/Icons/Action/Search.png"
                            ToolTip="Search Item Code" Width="24px" Visible="False" />
                        <asp:ImageButton ID="ImageButton9" runat="server" CausesValidation="False" ImageUrl="~/Image/Icons/Action/NewDocument.png"
                            ToolTip="New Item" Visible="False" Width="24px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 150px">
                Trade Name</td>
            <td style="width: 380px">
                <asp:TextBox ID="txtTradeName" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>
            </td>
            <td class="labelcells">
                RAMCO Item Code</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel64" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtRamcoItemCode" runat="server" CssClass="textbox" ToolTip="Item Code to be referred in RAMCO while creating Sale Order."></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtRamcoItemCode"
                            ErrorMessage="Please specify Item Code to be referred in RAMCO while creating Sale Order."
                            SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 150px">
                &nbsp;</td>
            <td style="width: 380px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                To be referred in Sales Order</td>
        </tr>
    </table>
    <table class="tableback" style="width: 100%;">
        <tr>
            <td style="font-weight: bold; font-size: 10pt; width: 150px;">
                Fabric Particulars
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtBlend"
                    ErrorMessage="No Particulars Picked or Exists for Given Item" ValidationGroup="b">*</asp:RequiredFieldValidator>
            </td>
            <td style="font-weight: bold; font-size: 10pt">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                    <ProgressTemplate>
                        <img alt="" src="../Image/loading.gif" style="width: 70px; height: 10px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td style="font-weight: bold; font-size: 8pt; text-align: right;" colspan="2">
                <asp:LinkButton ID="cmdEnquiryRequest" runat="server" ValidationGroup="b">Request for New Enquiry for following particulars</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="font-weight: bold; font-size: 10pt">
                &nbsp;</td>
            <td style="font-weight: bold; font-size: 10pt">
                &nbsp;</td>
            <td style="font-weight: bold; font-size: 10pt">
                &nbsp;</td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="b" />
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Blend</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtBlend" runat="server" CssClass="textbox" Width="90%"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                PPI</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtPPI" runat="server" CssClass="textbox"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                EPI</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtEPI" runat="server" CssClass="textbox"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Weight (GSM)</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtWeightGSM" runat="server" CssClass="textbox"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Width</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtWidth" runat="server" CssClass="textbox"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Weave</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtWeave" runat="server" CssClass="textbox"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table class="tableback" style="width: 100%;">
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="grdWarpWeft" runat="server" EmptyDataText="No Fabric Construction Defined for this Item"
                            EnableModelValidation="True" Width="100%">
                            <RowStyle CssClass="GridItem" />
                            <AlternatingRowStyle CssClass="GridAI" />
                            <HeaderStyle CssClass="GridHeader" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                            DataSourceMode="DataReader" SelectCommand="jct_ops_get_count_detail" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="txtItemCode" Name="sort" PropertyName="Text" Type="Decimal" />
                                <asp:ControlParameter ControlID="lblEnqNo" Name="enq" PropertyName="Text" Type="Decimal" />
                                <asp:ControlParameter ControlID="lblDevNo" Name="dev" PropertyName="Text" Type="Decimal" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="sdsQuoteFabCount" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                            DataSourceMode="DataReader" SelectCommand="jct_ops_get_quote_fab_count" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="txtQuotationNo" Name="Quotation_No" PropertyName="Text"
                                    Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtItemCode" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtSearchItem" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtQuotationNo" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
    <table class="tableback" style="width: 100%;">
        <tr>
            <td class="labelcells" style="height: 12px; font-weight: bold; font-size: 10pt;">
                Cost Parameters</td>
            <td style="width: 380px">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 150px">
                &nbsp;</td>
            <td style="width: 380px">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 150px">
                Item Type (DYD, BLD etc.)</td>
            <td style="width: 380px">
                <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtItemType" runat="server" CssClass="textbox" Width="57px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtItemType"
                            ErrorMessage="Please provide valid Item Type">*</asp:RequiredFieldValidator>
                        <div id="div4" style="display: none;">
                            <cc1:AutoCompleteExtender ID="txtItemType_AutoCompleteExtender" runat="server" CompletionInterval="10"
                                CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="OPS_Fetch_ItemType"
                                CompletionListCssClass="AutoExtender" ServicePath="~/WebService.asmx" CompletionListElementID="div1"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListItemCssClass="AutoExtenderList"
                                TargetControlID="txtItemType">
                            </cc1:AutoCompleteExtender>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Dye Type</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel52" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlDyeType" runat="server" AppendDataBoundItems="True" CssClass="combobox"
                            DataSourceID="dsDyeChem" DataTextField="parameter" DataValueField="parameter_code"
                            AutoPostBack="True">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="dsDyeChem" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                            SelectCommand="select parameter_code, parameter from jct_ops_multi_master
where parent_category = 'dyetype'"></asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 150px">
                Finish</td>
            <td style="width: 380px">
                <asp:UpdatePanel ID="UpdatePanel54" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlFinish" runat="server" CssClass="combobox" DataSourceID="dsFinish"
                            DataTextField="Finish" DataValueField="recipe_code" AppendDataBoundItems="True"
                            AutoPostBack="True">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="dsFinish" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                            SelectCommand="JCT_OPS_Get_Finishes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Printing Type</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel53" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPrintingType" runat="server" CssClass="combobox" DataTextField="parameter"
                            DataValueField="parameter_code" AppendDataBoundItems="True" DataSourceID="dsPrintType"
                            AutoPostBack="True">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="dsPrintType" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                            SelectCommand="select parameter_code, parameter from jct_ops_multi_master
where parent_category = 'printingtype' and status = 'A'"></asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 150px">
                Peaching Type</td>
            <td style="width: 380px; font-weight: bold;">
                <asp:UpdatePanel ID="UpdatePanel42" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPeachingType" runat="server" AppendDataBoundItems="True"
                            AutoPostBack="True" CssClass="combobox">
                            <asp:ListItem>-</asp:ListItem>
                            <asp:ListItem>Single</asp:ListItem>
                            <asp:ListItem>Double</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Packing Style</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel55" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPackStyle" runat="server" AppendDataBoundItems="True" CssClass="combobox"
                            DataSourceID="dsPackingStyle" DataTextField="parameter" DataValueField="parameter_code"
                            AutoPostBack="True">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="dsPackingStyle" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                            SelectCommand="select parameter_code, parameter from jct_ops_multi_master
where parent_category = @PackStyle
and status = 'A'
order by entrydate
">
                            <SelectParameters>
                                <asp:Parameter Name="PackStyle" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 150px">
                Maximum No. of Shades
            </td>
            <td style="width: 380px; font-weight: bold;">
                <asp:UpdatePanel ID="UpdatePanel65" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlMaxShades" runat="server" CssClass="combobox">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 150px">
                &nbsp;</td>
            <td style="width: 380px; font-weight: bold;">
                <asp:LinkButton ID="cmdViewCostDetails" runat="server" CausesValidation="False">View Cost Details</asp:LinkButton>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <table class="tableback" style="width: 100%;">
        <tr>
            <td style="height: 12px; font-weight: bold; font-size: 10pt;" class="labelcells">
                Cost Sheets
            </td>
            <td style="height: 12px; font-weight: bold; font-size: 10pt;">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img alt="" src="../Image/loading.gif" style="width: 70px; height: 10px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td style="height: 12px; font-weight: bold; font-size: 8pt; text-align: right;">
                <asp:LinkButton ID="cmdReqFreshCost" runat="server" ValidationGroup="b">Request for Fresh Cost</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="height: 12px; font-weight: bold; font-size: 10pt; width: 150px;">
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </td>
            <td style="height: 12px; font-weight: bold; font-size: 10pt;">
                &nbsp;</td>
            <td style="height: 12px; font-weight: bold; font-size: 8pt; text-align: right;">
                <asp:LinkButton ID="cmdReqExtCost" runat="server" ValidationGroup="b">Request for External Cost</asp:LinkButton>
            </td>
        </tr>
    </table>
    <table class="tableback" style="width: 100%;">
        <tr>
            <td style="height: 12px; font-weight: bold; font-size: 10pt;">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="grdCosting" runat="server" EnableModelValidation="True" Width="100%"
                                EmptyDataText="No Cost Sheet Available">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True">
                                        <ItemStyle Width="40px" />
                                    </asp:CommandField>
                                    <asp:HyperLinkField DataNavigateUrlFields="Memo No,Sort/Enq,Finishing,Printing,DyeType,Peaching,Plant,Memo Dt,SortName"
                                        DataNavigateUrlFormatString="Quotation_Cost_Memo.aspx?memo_no={0}&amp;sort_no={1}&amp;finish={2}&amp;printing={3}&amp;dyetype={4}&amp;peaching={5}&amp;plant={6}&amp;memo_dt={7}&amp;Item_Code={8}"
                                        DataTextField="Memo No" DataTextFormatString="View Memo" Target="_blank" />
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                                <SelectedRowStyle CssClass="GridRowGreen" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                                DataSourceMode="DataReader" SelectCommand="jct_ops_get_cost_param" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtItemCode" Name="sort" PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="lblEnqNo" Name="Enq" PropertyName="Text" Type="Decimal" />
                                    <asp:ControlParameter ControlID="lblDevNo" Name="Dev" PropertyName="Text" Type="Decimal" />
                                    <asp:ControlParameter ControlID="ddlFinish" Name="Finishing" PropertyName="SelectedValue"
                                        DefaultValue=" " Type="String" />
                                    <asp:ControlParameter ControlID="ddlPrintingType" Name="Printing" PropertyName="SelectedValue"
                                        DefaultValue=" " Type="String" />
                                    <asp:ControlParameter ControlID="ddlDyeType" DefaultValue=" " Name="DyeType" PropertyName="SelectedValue"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="ddlPeachingType" DefaultValue=" " Name="Peaching"
                                        PropertyName="SelectedValue" Type="String" />
                                    <asp:ControlParameter ControlID="ddlPlant" DefaultValue=" " Name="Plant" PropertyName="SelectedValue"
                                        Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="txtItemCode" EventName="TextChanged" />
                            <asp:AsyncPostBackTrigger ControlID="txtQuotationNo" EventName="TextChanged" />
                            <asp:AsyncPostBackTrigger ControlID="txtSearchItem" EventName="TextChanged" />
                            <asp:AsyncPostBackTrigger ControlID="cmdViewCostDetails" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="ddlDyeType" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="ddlFinish" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="ddlPrintingType" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="ddlPackStyle" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="ddlPlant" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="ddlPeachingType" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
        <tr>
            <td style="height: 12px; font-weight: bold; font-size: 10pt;">
                &nbsp;</td>
        </tr>
    </table>
    <table class="tableback" style="width: 100%;">
        <tr>
            <td style="font-weight: bold; font-size: 10pt">
                Indicative Cost/Unit
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="labelcells">
                Memo No.
            </td>
            <td class="NormalText" style="font-weight: bold">
                <asp:UpdatePanel ID="UpdatePanel40" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblMemoNo" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="labelcells">
                Memo Date</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel57" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblMemoDate" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Raw Materials</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtRawMaterial" runat="server" CssClass="textbox" Enabled="False"
                            Columns="6"></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdCosting" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Processing M/c Cost</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtProcessing" runat="server" CssClass="textbox" Enabled="False"
                            Columns="6"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Spinning Cost</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSpinning" runat="server" CssClass="textbox" Enabled="False" Columns="6"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Finishing Cost</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtFinishing" runat="server" CssClass="textbox" Enabled="False"
                            Columns="6"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Sizing Cost</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSizing" runat="server" CssClass="textbox" Enabled="False" Columns="6"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Weaving Cost</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtWeaving" runat="server" CssClass="textbox" Enabled="False" Columns="6"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 23px">
                Greigh Cost</td>
            <td class="NormalText" style="height: 23px">
                <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblGreighCost" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells" style="height: 23px">
                &nbsp;</td>
            <td class="NormalText" style="height: 23px">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Packing Cost</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtPacking" runat="server" CssClass="textbox" Enabled="False" Columns="6"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Selling Expenses</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSellingExp" runat="server" CssClass="textbox" Enabled="False"
                            Columns="6"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                DnV Cost (By Costing)</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblDnVCost" runat="server"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdCosting" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
    <table class="tableback" style="width: 100%;">
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Shrinkage Cost
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel44" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblShrCost" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Dye/Chem Cost / Mtr
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel47" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblDyeChemCost" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Value Loss
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel45" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblValLoss" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Finish Upcharge / Mtr
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel48" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblFinishUpchrg" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Sell Exp
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel46" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblSellExp" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Printing Cost / Mtr
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel49" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblPrintingCost" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                DnV Cost
            </td>
            <td style="font-weight: bold">
                <asp:UpdatePanel ID="UpdatePanel50" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblDnv" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                (Calculated on basis of Cost Parameters)
            </td>
            <td style="font-weight: bold">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td style="font-weight: bold">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Pref.&nbsp;Sale Price/Unit
            </td>
            <td style="font-weight: bold">
                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblSellPrice" runat="server" ForeColor="#006600"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdCosting" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Pref. Margin %
            </td>
            <td class="NormalText" style="font-weight: bold">
                <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblPrefMarginPerc" runat="server" ForeColor="#006600"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdCosting" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Actual Sale Price
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel60" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblActualSalePrice" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Actual Margin %
            </td>
            <td class="NormalText" valign="top">
                <asp:UpdatePanel ID="UpdatePanel61" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblActualMargin" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                No of Shades
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel62" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblNoOfShade" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Total Quantity
            </td>
            <td class="NormalText" valign="top">
                <asp:UpdatePanel ID="UpdatePanel63" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblTotalQty" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText" valign="top">
                &nbsp;</td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td class="labelcells">
                <asp:CheckBox ID="chkSample" runat="server" Text="Sample Required" />
            </td>
            <td class="NormalText" style="width: 312px">
                &nbsp;</td>
            <td class="labelcells">
                <asp:CheckBox ID="chkLabDip" runat="server" Text="Labdip Required" />
            </td>
            <td class="NormalText">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/LabDipSystem/LabDipRequest.aspx"
                    Target="_blank">Create LabDip Request</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Sample Reference</td>
            <td class="NormalText" style="width: 312px">
                <asp:TextBox ID="txtSampleRef" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="labelcells">
                Labdip Reference</td>
            <td class="NormalText">
                <asp:TextBox ID="txtLabdipRef" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText" style="width: 312px">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
    <table class="tableback" style="width: 100%;">
        <tr>
            <td class="labelcells">
                Remark</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel56" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblMessage" runat="server" CssClass="errormsg"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ibtSave" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table class="tableback" style="width: 100%;">
        <tr>
            <td style="height: 20px">
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" />
            </td>
        </tr>
    </table>
    <table class="tableback" style="width: 100%;">
        <tr>
            <td>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Image/Icons/Action/document_add.png"
                    ToolTip="New Quotation" Width="32px" Enabled="False" />
                <asp:ImageButton ID="ibtSave" runat="server" ImageUrl="~/Image/Icons/Action/document_save.png"
                    ToolTip="Create and Save Quotation" Width="32px" />
                <asp:ImageButton ID="cmdAuthorise" runat="server" ImageUrl="~/Image/Icons/Action/Authorise.png"
                    ToolTip="Authorise Quotation" Width="32px" />
                <asp:ImageButton ID="ibtDelete" runat="server" ImageUrl="~/Image/Icons/Action/document_delete.png"
                    ToolTip="Delete" Width="32px" />
                <asp:ImageButton ID="ImageButton11" runat="server" ImageUrl="~/Image/Icons/Action/Freeze.png"
                    ToolTip="Freeze" Width="32px" Visible="False" />
                <asp:ImageButton ID="cmdCancel0" runat="server" ImageUrl="~/Image/Icons/Action/Cancel.png"
                    ToolTip="Reject" Width="32px" />
                <asp:ImageButton ID="ibtBack0" runat="server" ImageUrl="~/Image/Icons/Action/back.png"
                    ToolTip="Back" Width="32px" OnClientClick="window.history.go(-1);return false;" />
            </td>
            <td style="width: 311px">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td style="text-align: right">
                <asp:ImageButton ID="cmdAuthorise_Push_SO" runat="server" ImageUrl="~/Image/Icons/Action/Authorise_Make_SO.png"
                    ToolTip="Authorise Quotation and Request its Sale Order (Only for HOD)" 
                    Width="32px" />
                <asp:ImageButton ID="cmdPush_SO" runat="server" ImageUrl="~/Image/Icons/Action/Make_SO.png"
                    ToolTip="Request Sale Order for this Quotation (Only for HOD)" 
                    Width="32px" />
            </td>
        </tr>
    </table>
</asp:Content>
