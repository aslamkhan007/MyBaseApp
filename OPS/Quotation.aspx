<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="Quotation.aspx.vb" Inherits="OPS_Quotation" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="NormalText" style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Quotation
                <asp:Label ID="lblQuotationNo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 12px">
                Customer Code</td>
            <td style="height: 12px; width: 311px;">
                <asp:TextBox ID="txtCustomer" runat="server" CssClass="textbox"></asp:TextBox>
                <asp:ImageButton ID="ImageButton10" runat="server" 
                    ImageUrl="~/Image/Icons/Action/NewDocument.png" ToolTip="New Item" 
                    Width="24px" />
            </td>
            <td class="labelcells" style="height: 12px">
                <asp:Label ID="Label16" runat="server" Text="Customer Name"></asp:Label>
            </td>
            <td style="height: 12px">
                <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td style="width: 311px">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Product 
                Category</td>
            <td style="width: 311px">
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="combobox">
                    <asp:ListItem>Fabric</asp:ListItem>
                    <asp:ListItem>Yarn</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                Item Type</td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="combobox">
                    <asp:ListItem>DYD</asp:ListItem>
                    <asp:ListItem>BLD</asp:ListItem>
                    <asp:ListItem>GRY</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Item Code/Sort No</td>
            <td valign="top" style="width: 311px" class="NormalText">
                <asp:TextBox ID="txtItemCode" runat="server" CssClass="textbox"></asp:TextBox>
                <asp:ImageButton ID="ImageButton8" runat="server" 
                    ImageUrl="~/Image/Icons/Action/Search.png" ToolTip="Search Item Code" 
                    Width="24px" />
                <asp:ImageButton ID="ImageButton9" runat="server" 
                    ImageUrl="~/Image/Icons/Action/NewDocument.png" ToolTip="New Item" 
                    Width="24px" />
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Item Description</td>
            <td style="width: 311px">
                <asp:Label ID="lblItemDescription" runat="server"></asp:Label>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td style="width: 311px">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
<table class="tableback" style="width:100%;">
        <tr>
            <td style="font-weight: bold; font-size: 10pt">
                Fabric Particulars</td>
            <td style="font-weight: bold; font-size: 10pt">
                &nbsp;</td>
            <td style="font-weight: bold; font-size: 10pt">
                &nbsp;</td>
            <td style="font-weight: bold; font-size: 10pt">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="font-weight: bold; font-size: 10pt">
                &nbsp;</td>
            <td style="font-weight: bold; font-size: 10pt">
                &nbsp;</td>
            <td style="font-weight: bold; font-size: 10pt">
                &nbsp;</td>
            <td style="font-weight: bold; font-size: 10pt">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Blend</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtBlend" runat="server" CssClass="textbox"></asp:TextBox>
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
                EPI</td>
            <td class="NormalText">
                <asp:TextBox ID="txtEPI" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="labelcells">
                PPI</td>
            <td class="NormalText">
                <asp:TextBox ID="txtPPI" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Warp Count</td>
            <td class="NormalText">
                <asp:TextBox ID="txtWarpCount" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="labelcells">
                Weft Count</td>
            <td class="NormalText">
                <asp:TextBox ID="TextBox6" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Width</td>
            <td class="NormalText">
                <asp:TextBox ID="TextBox7" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="labelcells">
                Weight (GSM)</td>
            <td class="NormalText">
                <asp:TextBox ID="TextBox8" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Finish</td>
            <td class="NormalText">
                <asp:TextBox ID="TextBox10" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="labelcells">
                Weave</td>
            <td class="NormalText">
                <asp:TextBox ID="TextBox9" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                        <asp:GridView ID="grdWarpWeft" runat="server" EnableModelValidation="True" 
                            Width="100%">
                            <RowStyle CssClass="GridItem" />
                            <HeaderStyle CssClass="GridHeader" />
                        </asp:GridView>
                    </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td>
                OR</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        </table>
    <table class="tableback" style="width:100%;">
        <tr>
            <td style="font-weight: bold; font-size: 10pt">
                Yarn Particulars</td>
            <td class="NormalText">
                <img __designer:mapid="1e" alt="" src="../Image/Icons/Indicators/Blue.png" 
    style="width: 7px; height: 7px" /><img __designer:mapid="1f" alt="" src="../Image/Icons/Indicators/Green.png" 
    style="width: 7px; height: 7px" /><img __designer:mapid="20" alt="" src="../Image/Icons/Indicators/Yellow.png" 
    style="width: 7px; height: 7px" /></td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="font-weight: bold; font-size: 10pt">
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
                Yarn Count</td>
            <td class="NormalText">
                <asp:TextBox ID="txtEPI1" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="labelcells">
                Blend</td>
            <td class="NormalText">
                <asp:TextBox ID="txtEPI2" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
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
        </table>
    <table class="tableback" style="width:100%;">
        <tr>
            <td style="font-weight: bold; font-size: 10pt">
                Order Particulars</td>
            <td class="NormalText" style="width: 312px">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="font-weight: bold; font-size: 10pt">
                &nbsp;</td>
            <td class="NormalText" style="width: 312px">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Shade</td>
            <td class="NormalText" valign="top" style="width: 312px">
                <asp:DropDownList ID="ddlShade" runat="server" 
                    DataSourceID="SqlDataSource1" DataTextField="parameter" 
                    DataValueField="parameter_code" CssClass="combobox">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    
                    SelectCommand="select parameter_code, parameter from jct_ops_multi_master where parent_category = 'SHADE' and status = 'A' order by parameter" 
                    DataSourceMode="DataReader">
                </asp:SqlDataSource>
            </td>
            <td class="labelcells">
                Quantity</td>
            <td class="NormalText" valign="top">
                <asp:TextBox ID="txtQuantity" runat="server" CssClass="textbox"></asp:TextBox>
                <asp:ImageButton ID="ibtAddShade" runat="server" 
                    ImageUrl="~/Image/Icons/Action/AddItem.png" ToolTip="Add Item to List" 
                    Width="20px" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="grdShades" runat="server" EnableModelValidation="True" 
                            Width="100%">
                            <RowStyle CssClass="GridItem" />
                            <HeaderStyle CssClass="GridHeader" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ibtAddShade" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
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
        <tr>
            <td class="labelcells">
                UOM</td>
            <td class="NormalText" style="width: 312px">
                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="combobox">
                    <asp:ListItem>Mtrs</asp:ListItem>
                    <asp:ListItem>Yards</asp:ListItem>
                    <asp:ListItem>Kgs</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                Estimated Order Qty</td>
            <td class="NormalText">
                <asp:TextBox ID="TextBox12" runat="server" CssClass="textbox"></asp:TextBox>
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
        <tr>
            <td class="labelcells">
                <asp:CheckBox ID="CheckBox1" runat="server" Text="Sample Required" />
            </td>
            <td class="NormalText" style="width: 312px">
                &nbsp;</td>
            <td class="labelcells">
                <asp:CheckBox ID="CheckBox2" runat="server" Text="Labdip Required" />
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Sample Reference</td>
            <td class="NormalText" style="width: 312px">
                <asp:TextBox ID="TextBox15" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="labelcells">
                Labdip Reference</td>
            <td class="NormalText">
                <asp:TextBox ID="TextBox14" runat="server" CssClass="textbox"></asp:TextBox>
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
    <table class="tableback" style="width:100%;">
        <tr>
            <td style="font-weight: bold; font-size: 10pt">
                Indicative
                Cost/Unit</td>
            <td class="NormalText" style="width: 314px">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText" style="width: 314px">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Raw Materials</td>
            <td class="NormalText" style="width: 314px">
                <asp:TextBox ID="TextBox16" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Spinning Cost</td>
            <td class="NormalText" style="width: 314px">
                <asp:TextBox ID="TextBox17" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Weaving Cost</td>
            <td class="NormalText" style="width: 314px">
                <asp:TextBox ID="TextBox21" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Dyeing Cost</td>
            <td class="NormalText" style="width: 314px">
                <asp:TextBox ID="TextBox22" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" >
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Finishing Cost</td>
            <td class="NormalText" style="width: 314px">
                <asp:TextBox ID="TextBox23" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Packing Cost</td>
            <td class="NormalText" style="width: 314px">
                <asp:TextBox ID="TextBox24" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText" style="width: 314px">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        </table>
        <table class="tableback" style="width:100%;">
        <tr>
            <td style="font-weight: bold; font-size: 10pt">
                Discounts</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
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
                Discount</td>
            <td class="NormalText">
                <asp:DropDownList ID="DropDownList6" runat="server" CssClass="combobox">
                </asp:DropDownList>
            &nbsp;<asp:ImageButton ID="ibtAddDispatchItem0" runat="server" 
                    ImageUrl="~/Image/Icons/Action/AddItem.png" ToolTip="Add Item to List" 
                    Width="20px" />
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    DataSourceMode="DataReader"></asp:SqlDataSource>
            </td>
            <td class="labelcells">
                Discount Type</td>
            <td class="NormalText">
                <asp:Label ID="lblDiscount" runat="server"></asp:Label>
            </td>
            <td class="labelcells">
                Discount/Unit</td>
            <td class="NormalText">
                <asp:Label ID="lblDiscountPUnit" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
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
                Agent Name</td>
            <td class="NormalText">
                <asp:TextBox ID="TextBox26" runat="server" Width="197px"></asp:TextBox>
            </td>
            <td class="labelcells">
                Agent Commision</td>
            <td class="NormalText">
                <asp:TextBox ID="TextBox27" runat="server" Width="56px"></asp:TextBox>
                %</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="6">
                                <asp:GridView ID="grdDiscounts" runat="server" 
                                    EnableModelValidation="True" Width="100%">
                                    <RowStyle CssClass="GridItem" />
                                    <HeaderStyle CssClass="GridHeader" />
                                </asp:GridView>
                            </td>
        </tr>
        </table>
    <table class="tableback" style="width:100%;">
        <tr>
            <td class="labelcells">
                Currency</td>
            <td class="NormalText" style="width: 314px">
                <asp:DropDownList ID="DropDownList5" runat="server" CssClass="combobox">
                    <asp:ListItem>INR</asp:ListItem>
                    <asp:ListItem>USD</asp:ListItem>
                    <asp:ListItem>GBP</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                Exchange Rate</td>
            <td class="NormalText">
                <asp:TextBox ID="txtExchangeRate" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText" style="width: 314px">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;Value</td>
            <td class="NormalText" style="width: 314px">
                &nbsp;<asp:Label ID="lblQuotationValue" runat="server"></asp:Label>
            &nbsp;<asp:Label ID="lblCurrencySymbol" runat="server"></asp:Label>
            </td>
            <td class="labelcells">
                Value INR</td>
            <td class="NormalText">
                <asp:Label ID="lblQuotationValue0" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText" style="width: 314px">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Remark</td>
            <td colspan="3">
                <asp:TextBox ID="TextBox25" runat="server" CssClass="textbox" Width="768px"></asp:TextBox>
            </td>
        </tr>
        </table>
    <table class="tableback" style="width:100%;">
        <tr>
            <td style="font-weight: bold; font-size: 10pt">
                Dispatch Schedule</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Shade</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlDispatchShade" runat="server" CssClass="combobox" 
                    DataSourceID="SqlDataSource2" DataTextField="parameter" 
                    DataValueField="parameter_code">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    
                    
                    SelectCommand="select parameter_code, parameter from jct_ops_multi_master where parent_category = 'SHADE' and status = 'A' order by parameter" 
                    DataSourceMode="DataReader">
                </asp:SqlDataSource>
            </td>
            <td class="labelcells">
                Quantity</td>
            <td class="NormalText">
                <asp:TextBox ID="txtDispatchQuantity" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
            <td class="labelcells">
                Dispatch Date</td>
            <td class="NormalText">
                <asp:TextBox ID="txtDispatchDate" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDispatchDate_CalendarExtender" runat="server" 
                    TargetControlID="txtDispatchDate">
                </cc1:CalendarExtender>
                <asp:ImageButton ID="ibtAddDispatchItem" runat="server" 
                    ImageUrl="~/Image/Icons/Action/AddItem.png" ToolTip="Add Item to List" 
                    Width="20px" />
            </td>
        </tr>
        <tr>
            <td colspan="6">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="grdDispatchDetail" runat="server" 
                                    EnableModelValidation="True" Width="100%">
                                    <RowStyle CssClass="GridItem" />
                                    <HeaderStyle CssClass="GridHeader" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ibtAddDispatchItem" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
        </tr>
        <tr>
            <td colspan="6">
                        &nbsp;</td>
        </tr>
        </table>
    
    <table class="tableback" style="width:100%;">
        <tr>
            <td style="font-size: 10pt; font-weight: bold;">
                <asp:ImageButton ID="ImageButton1" runat="server"
                    ImageUrl="~/Image/Icons/Action/document_add.png" ToolTip="New Quotation"
                    Width="48px" />
                <asp:ImageButton ID="ibtSave" runat="server"
                    ImageUrl="~/Image/Icons/Action/document_save.png" ToolTip="Save" 
                    Width="48px" />
                <asp:ImageButton ID="ImageButton4" runat="server"
                    ImageUrl="~/Image/Icons/Action/document_delete.png" ToolTip="Delete"
                    Width="48px" />
                <asp:ImageButton ID="ImageButton5" runat="server" 
                    ImageUrl="~/Image/Icons/Action/Edit.png" ToolTip="Edit" Width="48px" />
                <asp:ImageButton ID="ImageButton6" runat="server" 
                    ImageUrl="~/Image/Icons/Action/Authorise.png" ToolTip="Authorise" 
                    Width="48px" />
                <asp:ImageButton ID="ImageButton7" runat="server" 
                    ImageUrl="~/Image/Icons/Action/Search.png" ToolTip="Search Quotation" 
                    Width="48px" />
            </td>
        </tr>
        </table>
</asp:Content>

