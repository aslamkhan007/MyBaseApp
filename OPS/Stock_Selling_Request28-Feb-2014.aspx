<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="Stock_Selling_Request.aspx.vb" Inherits="OPS_Stock_Selling_Request" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="6">
                <asp:Label ID="Label1" runat="server" Text="Stock Selling Request"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:Panel ID="Panel6" runat="server" BorderColor="#837D7C" BorderWidth="1px" Width="100%">
                    <table style="width: 100%;" class="tableback">
                        <tr>
                            <td>
  <asp:Label ID="Lbl_Search_SaleOrder" runat="server" Text="Sale Order"></asp:Label>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtSearchSaleOrder" runat="server" CssClass="textbox" ValidationGroup="SearchGroup"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:Label ID="Lbl_Shade" runat="server" Text="Shade"></asp:Label>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtSearchShade" runat="server" CssClass="textbox" ValidationGroup="SearchGroup"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblValue1" runat="server">Sort</asp:Label>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtSearchSort" runat="server" CssClass="textbox" ValidationGroup="SearchGroup"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:Label ID="lblValue2" runat="server">Variant</asp:Label>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtSearchVariant" runat="server" CssClass="textbox" ValidationGroup="SearchGroup"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqdVariant" runat="server" ControlToValidate="txtSearchVariant"
                                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" 
                                            ValidationGroup="SearchGroup" Enabled="False"></asp:RequiredFieldValidator>
                                        <asp:LinkButton ID="CmdSearchData" runat="server" CssClass="searchbluesmall" Height="17px"
                                            Width="16px" ValidationGroup="SearchGroup"></asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <asp:Image ID="ImageProg" runat="server" ImageUrl="~/Image/Progress02.gif" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Panel ID="Panel7" runat="server">
                    <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                        <ContentTemplate>
                            <asp:Panel ID="Panel8" runat="server" Height="300px" ScrollBars="Both">
                                <asp:GridView ID="GrdBasicDetail" runat="server" AutoGenerateColumns="true" 
                                    EnableModelValidation="True" Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelection" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                    <RowStyle CssClass="GridItem" />
                                </asp:GridView>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
            <td valign="top" style="width: 10%">

                <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                    <ContentTemplate>
                        <%--  <asp:LinkButton ID="CmdAddItem" runat="server" Font-Size="Larger">+</asp:LinkButton>--%>
                        <asp:ImageButton ID="imgAddRow" runat="server" CommandName="Add" ImageUrl="~/Image/Icons/Action/iPhoneAdd.png"
                            ToolTip="Click to Add More Rows" ValidationGroup="a" Width="24px" />
                        &nbsp;
                        <asp:ImageButton ID="imgClear" runat="server" CommandName="Add" 
                            ImageUrl="~/Image/Icons/Action/iPhoneCross.png" 
                            ToolTip="Click to Remove all data for this Session" ValidationGroup="a" 
                            Width="24px" />
                    </ContentTemplate>
                </asp:UpdatePanel>

            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Panel ID="Panel4" runat="server" Width="100%">
                    <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GrdTempValuesBaleDEtail" AutoGenerateColumns="true"  
                                runat="server" EnableModelValidation="True" 
                                ShowFooter="True" Width="100%">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkDelete0" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                            </asp:GridView>
                            <asp:GridView ID="GrdSummary" runat="server" AutoGenerateColumns="true" 
                                EnableModelValidation="True" Width="100%">
                               
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                            <asp:GridView ID="GrdTempValues" runat="server" Width="100%" EnableModelValidation="True"
                                ShowFooter="True" AutoGenerateColumns="False">
                                <Columns>
                                   <%-- <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkDelete" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:BoundField DataField="Sort" HeaderText="Sort" />
                                    <asp:BoundField DataField="Shade" HeaderText="Shade" />
                                    <asp:BoundField DataField="Meters" HeaderText="Meters" />
                                    <asp:TemplateField HeaderText="Rate/Mtr">
                                        <ItemTemplate>
                                            <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtRate" runat="server" CssClass="textbox" Width="80px" MaxLength="5"></asp:TextBox>
                                                    <cc1:FilteredTextBoxExtender ID="txtRate_FilteredTextBoxExtender" 
                                                        runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtRate" 
                                                        ValidChars=".1234567890">
                                                    </cc1:FilteredTextBoxExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                        ControlToValidate="txtRate" Display="Dynamic" ErrorMessage="*" 
                                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ShadeCatg">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlShadeCatg" runat="server">
                                                <asp:ListItem>G</asp:ListItem>
                                                <asp:ListItem>L</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="LastSoldAt" HeaderText="LastSoldAt" />
                                    <asp:BoundField DataField="LastSoldOn" HeaderText="LastSoldOn" />
                                    <asp:BoundField DataField="LastSoldTo" HeaderText="LastSoldTo" />
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
            <td valign="top" style="width: 10%">
                <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                    <ContentTemplate>
                        <%--     <asp:LinkButton ID="cmdDeleteRows" runat="server" CssClass="btncross" Height="21px"
                            ToolTip="Click To Clear All Selected Items" Width="24px"></asp:LinkButton>--%>
                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete"
                            ImageUrl="~/OPS/Image/iPhone_Delete_icon.png" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                &nbsp;</td>
                <td></td>
        </tr>
        <tr>
            <td colspan="6">
                        <asp:Panel ID="Pnl_DepatchDetail" runat="server">
                            <table style="width: 100%;" class="tableback">
                                <tr>
                                    <td colspan="4">
                                        <asp:Panel ID="Pnl_OtherCust" runat="server">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td width="90px" colspan="2" style="width: 240px">
                                                        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                                                            <ProgressTemplate>
                                                                <asp:Image ID="ImageProg0" runat="server" ImageUrl="~/Image/Progress02.gif" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="90px">
                                                        <asp:Label ID="Label11" runat="server" Text="Customer Name"></asp:Label>
                                                    </td>
                                                    <td style="width: 350px" width="150px">
                                                        <asp:TextBox ID="txtSearchCustomer" runat="server" AutoPostBack="True" 
                                                            CssClass="textbox" 
                                                            ToolTip="Please give Customer Code or Select Customer from the List " 
                                                            Width="200px"></asp:TextBox>
                                                        <div ID="divwidth" style="display: none;">
                                                            <cc1:AutoCompleteExtender ID="txtSearchCustomer_AutoCompleteExtender0" 
                                                                runat="server" CompletionInterval="10" CompletionListCssClass="AutoExtender" 
                                                                CompletionListElementID="divwidth" 
                                                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                                                CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" 
                                                                MinimumPrefixLength="1" ServiceMethod="OPS_Customer" 
                                                                ServicePath="~/WebService.asmx" TargetControlID="txtSearchCustomer">
                                                            </cc1:AutoCompleteExtender>
                                                        </div>
                                                        &nbsp;<asp:LinkButton ID="CmdSearchCust0" runat="server" CssClass="searchbluesmall" 
                                                            Height="17px" Width="16px"></asp:LinkButton>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:LinkButton ID="CmdSearchClear" runat="server" BorderStyle="None" 
                                                            CssClass="clear"></asp:LinkButton>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Made of Despatch"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlMode" runat="server" CssClass="combobox" Height="20px">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Air</asp:ListItem>
                                            <asp:ListItem>Express</asp:ListItem>
                                            <asp:ListItem>Road</asp:ListItem>
                                            <asp:ListItem>Ship</asp:ListItem>
                                            <asp:ListItem>Train</asp:ListItem>
                                            <asp:ListItem>Tempo</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="Freight Type"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlFreightType" runat="server" CssClass="combobox">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>PrePay</asp:ListItem>
                                            <asp:ListItem>Topay</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text="Docs ToBe Sent To"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlDocsSentTo" runat="server" CssClass="combobox">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Banglore</asp:ListItem>
                                            <asp:ListItem>Bombay</asp:ListItem>
                                            <asp:ListItem>Customer</asp:ListItem>
                                            <asp:ListItem>Delhi</asp:ListItem>
                                            <asp:ListItem>Phagwara</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Shipment Address</td>
                                    <td>
                                        <asp:DropDownList ID="ddlShipmentAddress" runat="server" CssClass="combobox" 
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text="Prefered Logistics"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtTransportDetail" runat="server" CssClass="textbox" MaxLength="1000"
                                            Width="300px"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="1">
                                        Shipping Address
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="LblAddress" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                        Remarks
                                    </td>
                                    <td colspan="3">
                                        <%-- &nbsp;<asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                            <ContentTemplate>--%>
                                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                                        <%--   </ContentTemplate>
                                        </asp:UpdatePanel>--%>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
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
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="6">
                <asp:LinkButton ID="CmdApply" runat="server" BorderStyle="None" 
                    CssClass="buttonc">Apply</asp:LinkButton>
            &nbsp;<asp:LinkButton ID="CmdClear" runat="server" BorderStyle="None" 
                    CssClass="buttonc">Clear</asp:LinkButton>
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
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

</asp:Content>

