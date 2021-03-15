<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="Quotation_Qty.aspx.vb" Inherits="OPS_Quotation_Qty" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td style="font-weight: bold; font-size: 10pt" class="tableheader">
                Quotation
                <asp:Label ID="lblQuotationNo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-weight: bold; font-size: 10pt; text-align: center; vertical-align: top;">
                <asp:ImageButton ID="ibtBasicInfo" runat="server" 
                    ImageUrl="~/OPS/Image/STab_BasicInfo.png" CausesValidation="False" />
                <asp:ImageButton ID="ibtShadeQty" runat="server" 
                    ImageUrl="~/OPS/Image/Tab_ShadesQuantities.png" Enabled="False" />
                <asp:ImageButton ID="ibtPayTerms" runat="server" 
                    ImageUrl="~/OPS/Image/STab_PaymentTerms.png" CausesValidation="False" />
                <asp:ImageButton ID="ibtDispatchDetail" runat="server" 
                    ImageUrl="~/OPS/Image/STab_DispatchDetail.png" CausesValidation="False" />
            </td>
        </tr>
        </table>
    <table style="width:100%;" class="tableback">
        <tr>
            <td style="font-weight: bold; font-size: 10pt" colspan="7">
                Shades &amp; Quantities<hr /></td>
        </tr>
        <tr>
            <td style="font-weight: bold; font-size: 9pt; height: 0px; font-family: 'trebuchet MS';" 
                colspan="7">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ValidationGroup="a" />
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Quotation Type</td>
            <td class="NormalText" valign="top">
                <%--<asp:DropDownList ID="ddlQuotationType" runat="server" CssClass="combobox" 
                    AutoPostBack="True">
                    <asp:ListItem>Regular</asp:ListItem>
                    <asp:ListItem>Forecast</asp:ListItem>
                </asp:DropDownList>--%>
                <asp:Label ReadOnly=true ID="ddlQuotationType" runat="server"></asp:Label>
            </td>
            <td class="labelcells">
                Shade Category</td>
            <td class="NormalText" style="vertical-align: top">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlShadeCat" runat="server" AppendDataBoundItems="True" 
                            CssClass="combobox">
                            <asp:ListItem Selected="True"></asp:ListItem>
                            <asp:ListItem>-</asp:ListItem>
                            <asp:ListItem>Gents</asp:ListItem>
                            <asp:ListItem>Ladies</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="ddlShadeCat" 
                            
                            ErrorMessage="Please Select Shade Category. Select &quot; - &quot; in case shade is not available." 
                            ValidationGroup="a">*</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Sub Sort No.</td>
            <td class="NormalText" valign="top" style="width: 83px">
             <asp:UpdatePanel ID="UpdatePanel90" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlsort" runat="server" AppendDataBoundItems="True" Visible="false"
                            CssClass="combobox" AutoPostBack="True">
                           
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator03" runat="server" 
                            ControlToValidate="ddlsort"     
                            ErrorMessage="Please Select Sub Sort." 
                            ValidationGroup="a">*</asp:RequiredFieldValidator>
                      </ContentTemplate>
                 </asp:UpdatePanel>
                        </td>
            <td class="NormalText" valign="top" style="width: 44px">
               </td>
               
        </tr>
        <tr>
            <td class="labelcells">
                Shade
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtShade" ErrorMessage="Please Provide Shade" 
                    SetFocusOnError="True" ValidationGroup="a">*</asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" valign="top">
                <asp:Panel ID="Panel2" runat="server" DefaultButton="ibtAddShade">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtShade" runat="server" CssClass="textbox"></asp:TextBox>
                            <div id="divwidth" style="display:none;">   
                        <cc1:AutoCompleteExtender ID="txtShade_AutoCompleteExtender" runat="server" 
                            CompletionInterval="10" CompletionSetCount="20" MinimumPrefixLength="1" 
                            ServiceMethod="OPS_Fetch_Shade"   CompletionListCssClass="AutoExtender" 
                            ServicePath="~/WebService.asmx" 
                            CompletionListElementID="divwidth" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList"
                            TargetControlID="txtShade">
                        </cc1:AutoCompleteExtender>
                        </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
                  
           
                <asp:DropDownList ID="ddlShade" runat="server" 
                    DataSourceID="SqlDataSource1" DataTextField="parameter" 
                    DataValueField="parameter_code" CssClass="combobox" Visible="False">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    
                    SelectCommand="select parameter_code, parameter from jct_ops_multi_master where parent_category = 'SHADE' and status = 'A' order by parameter" 
                    DataSourceMode="DataReader">
                </asp:SqlDataSource>
            </td>
            <td class="labelcells">
                Shade Depth</td>
            <td class="NormalText" style="vertical-align: top">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlShadeDepth" runat="server" AppendDataBoundItems="True" 
                            CssClass="combobox" DataSourceID="dsShadeDepth" DataTextField="parameter" 
                            DataValueField="parameter_code">
                            <asp:ListItem>-</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:SqlDataSource ID="dsShadeDepth" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    
                    SelectCommand="select parameter_code, parameter from jct_ops_multi_master
where parent_category = 'ShadeDepth' and status = 'A'
order by entrydate
" 
                    DataSourceMode="DataReader">
                </asp:SqlDataSource>
            </td>
            <td class="labelcells">
                Peaching Type</td>
            <td class="NormalText" valign="top" style="width: 83px">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPeachingType" runat="server" AppendDataBoundItems="True" 
                            CssClass="combobox">
                            <asp:ListItem>-</asp:ListItem>
                            <asp:ListItem>Single</asp:ListItem>
                            <asp:ListItem>Double</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" valign="top" style="width: 44px">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Dye Type</td>
            <td class="NormalText" valign="top">
                <asp:DropDownList ID="ddlDyeType" runat="server" CssClass="combobox" 
                    DataValueField="parameter_code" AppendDataBoundItems="True" 
                    DataSourceID="dsDyeChem" DataTextField="parameter">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="dsDyeChem" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="select parameter_code, parameter from jct_ops_multi_master
where parent_category = 'dyetype'"></asp:SqlDataSource>
            </td>
            <td class="labelcells">
                Printing Type</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlPrintingType" runat="server" CssClass="combobox" DataTextField="parameter" 
                    DataValueField="parameter_code" AppendDataBoundItems="True" 
                    DataSourceID="dsPrintType">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="dsPrintType" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="select parameter_code, parameter from jct_ops_multi_master
where parent_category = 'printingtype'"></asp:SqlDataSource>
                </td>
            <td class="labelcells">
                Finish Type</td>
            <td class="NormalText" valign="top" style="width: 83px">
                <asp:DropDownList ID="ddlFinish" runat="server" CssClass="combobox" 
                    DataSourceID="dsFinish" DataTextField="Finish" 
                    DataValueField="recipe_code" AppendDataBoundItems="True">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="dsFinish" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="JCT_OPS_Get_Finishes" SelectCommandType="StoredProcedure">                    
                </asp:SqlDataSource>
            </td>
            <td class="NormalText" valign="top" style="width: 44px">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText" valign="top">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
             
                            </td>
            
            <td class="labelcells">
                Quantity
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtQuantity" ErrorMessage="Please Provide Shade Quantity" 
                    SetFocusOnError="True" ValidationGroup="a">*</asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" valign="top" style="width: 83px">
                <asp:Panel ID="Panel1" runat="server" DefaultButton="ibtAddShade">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtQuantity" runat="server" CssClass="textbox"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
            <td class="NormalText" valign="top" style="width: 44px">
                <asp:ImageButton ID="ibtAddShade" runat="server" 
                    ImageUrl="~/Image/Icons/Action/iPhoneAdd.png" ToolTip="Click to Add Shade and Quantity to List" 
                    Width="24px" ValidationGroup="a" />
            </td>
        </tr>
        <tr>
        <td>Sub Sort Description</td>
        <td colspan="6">
        
        <asp:UpdatePanel ID="UpdatePanel92" runat="server">
                        <ContentTemplate>
               <asp:TextBox runat="server" ID="txtsortremark" Height="16px" Width="364px" ReadOnly="true" Visible="false"></asp:TextBox>
               </ContentTemplate></asp:UpdatePanel>
        </td>
        
        </tr>
        <tr>
            <td colspan="7">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdShades" runat="server" EnableModelValidation="True" 
                            Width="100%" BorderColor="Black" BorderStyle="Solid" CellPadding="0">
                            <RowStyle CssClass="GridItem" />
                            <AlternatingRowStyle CssClass="GridAI" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" 
                                            ImageUrl="~/OPS/Image/iPhone_Delete_icon.png" CommandName="Delete" 
                                            CausesValidation="False" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ibtAddShade" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
    <table style="width:100%;" class="tableback">
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
                UOM<td class="NormalText" style="width: 312px">
                <asp:DropDownList ID="ddlUom" runat="server" CssClass="combobox">
                    <asp:ListItem>Mtrs</asp:ListItem>
                    <asp:ListItem>Yards</asp:ListItem>
                    <asp:ListItem>Kgs</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                Total Quantity</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtEstOrderQty" runat="server" CssClass="textbox" 
                            Enabled="False"></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ibtAddShade" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="grdShades" EventName="RowDeleting" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Remarks</td>
            <td class="NormalText" style="width: 312px">
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Sale Notes:</td>
            <td colspan="3">
                <asp:TextBox ID="txtSaleNotes" runat="server" Columns="150" CssClass="textbox" 
                    Height="200px" MaxLength="5000" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="errormsg" colspan="4">
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="errormsg" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ibtSave" />
                        <asp:AsyncPostBackTrigger ControlID="ibtAddShade" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="grdShades" EventName="RowDeleted" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
    <table style="width:100%;" class="tableback">
        <tr>
            <td>
                <asp:ImageButton ID="ibtSave" runat="server"
                    ImageUrl="~/Image/Icons/Action/document_save.png" ToolTip="Create and Save Quotation" 
                    Width="32px" />
                <asp:ImageButton ID="ibtSave0" runat="server"
                    ImageUrl="~/Image/Icons/Action/back.png" ToolTip="Create and Save Quotation" 
                    Width="32px" onclientclick="window.history.go(-1);return false;" />
                </td>
        </tr>
        </table>
    </asp:Content>

