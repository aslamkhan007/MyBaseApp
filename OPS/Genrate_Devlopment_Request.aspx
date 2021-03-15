<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true"
    CodeFile="Genrate_Devlopment_Request.aspx.cs" Inherits="Genrate_Devlopment_Request" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader">
                New Devlopment Request
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Request for Self"></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkSelf" runat="server" AutoPostBack="True" OnCheckedChanged="chkSelf_CheckedChanged" />
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblID" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 203px">
                                    Plant
                                </td>
                                <td style="width: 313px">
                                    <%--             <asp:DropDownList ID="DdlSalePerson" runat="server" CssClass="combobox">
                </asp:DropDownList>--%>
                                    <telerik:RadComboBox ID="ddlPlant" Runat="server" Skin="Metro" Width="80px">
                                        <items>
                                            <telerik:RadComboBoxItem runat="server" Text="Cotton" Value="Cotton" />
                                            <telerik:RadComboBoxItem runat="server" Text="Taffeta" Value="Taffeta" />
                                        </items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 203px">
                               
                                    
                                   
                                    Sales Person
                               
                                    
                                   
                                </td>
                                <td style="width: 313px">
                                    <telerik:RadComboBox ID="DdlSalePerson" Runat="server" 
                                        DropDownAutoWidth="Enabled" MarkFirstMatch="True" Skin="Metro">
                                    </telerik:RadComboBox>
                                </td>
                                <td class="NormalText">
                                    Prospect Customer</td>
                                <td>
                                    <telerik:RadComboBox ID="ddlProspectCust" Runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="ddlProspectCust_SelectedIndexChanged" Skin="Metro" 
                                        Width="80px">
                                        <items>
                                            <telerik:RadComboBoxItem runat="server" Owner="ddlProspectCust" Text="No" 
                                                Value="No" />
                                            <telerik:RadComboBoxItem runat="server" Owner="ddlProspectCust" Text="Yes" 
                                                Value="Yes" />
                                        </items>
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                            <td colspan="4">
                            <asp:Panel ID="Panel3" runat="server"  Visible="False"> <hr />
                                        <table style="width: 100%;" class="tableback">
                                            <tr>
                                                <td style="width: 203px">
                                                    <asp:Label ID="Label2" runat="server" Text="Prospect Customer Name"></asp:Label>
                                                </td>
                                                <td style="width: 313px">
                                                    <telerik:RadTextBox ID="txtProspectCust" runat="server" Width="145px" SelectionOnFocus="CaretToBeginning"
                                                        Skin="MetroTouch" Height="20px" Rows="1" MaxLength="100">
                                                    </telerik:RadTextBox>
                                                    <asp:RequiredFieldValidator ID="ReqdValidCustName" runat="server" 
                                                        ControlToValidate="txtProspectCust" Display="Dynamic" ErrorMessage="*" 
                                                        SetFocusOnError="True" ValidationGroup="GrpSave"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="Prospect Cust Address"></asp:Label>
                                                </td>
                                                <td colspan="2">
                                                    <telerik:RadTextBox ID="txtProspectCustAddr" runat="server" SelectionOnFocus="CaretToBeginning"
                                                        Skin="MetroTouch" Height="20px" MaxLength="500">
                                                    </telerik:RadTextBox>
                                                    <asp:RequiredFieldValidator ID="ReqdValidCustAddress" runat="server" 
                                                        ControlToValidate="txtProspectCustAddr" Display="Dynamic" ErrorMessage="*" 
                                                        SetFocusOnError="True" ValidationGroup="GrpSave"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table> <hr />
                                    </asp:Panel>
                            </td>
                            </tr>
                        </table>
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 203px">
                                    Customer
                                </td>
                                <td style="width: 313px">
                                    <%--  <cc1:filteredtextboxextender TargetControlID="txtReqMtrs" ValidChars="0123456789"
                    ID="FilteredTextBoxExtender1" runat="server">
                </cc1:filteredtextboxextender>--%>
                                    <asp:TextBox ID="txtcustomer" runat="server" Width="200px">
                                    </asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="txtcustomer_AutoCompleteExtender" runat="server" 
                                        CompletionInterval="100" 
                                        CompletionListCssClass="autocomplete_completionListElement" 
                                        MinimumPrefixLength="1" ServiceMethod="OPS_Customer" 
                                        ServicePath="~/webservice.asmx" TargetControlID="txtcustomer">
                                    </cc1:AutoCompleteExtender>
                                </td>
                                <td>
                                    No of Shades
                                </td>
                                <td>
                                    <%--
                <cc1:FilteredTextBoxExtender ID="txt_No_of_shades0_filteredtextboxextender" 
                    runat="server" TargetControlID="txt_No_of_shades0" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>--%>
                                    <telerik:RadNumericTextBox ID="txtNo_of_shades" Runat="server" 
                                        AutoCompleteType="Disabled" Culture="en-US" DbValueFactor="1" LabelWidth="64px" 
                                        MaxLength="2" MaxValue="20" MinValue="1" Width="50px">
                                        <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 203px">
                                    Required Meters
                                </td>
                                <td style="width: 313px">
                                    <telerik:RadNumericTextBox ID="txtReqMtrs" Runat="server" 
                                        AutoCompleteType="Disabled" Culture="en-US" DataType="System.Int32" 
                                        DbValueFactor="1" LabelWidth="64px" MaxLength="3" MaxValue="999" MinValue="1" 
                                        Width="50px">
                                        <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    Segment
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="ddlSegment" Runat="server" Skin="Metro" Width="80px">
                                        <items>
                                            <telerik:RadComboBoxItem runat="server" Owner="ddlSegment" Text="Fresh" 
                                                Value="Fresh" />
                                            <telerik:RadComboBoxItem runat="server" Owner="ddlSegment" Text="WorkWear" 
                                                Value="WorkWear" />
                                        </items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 203px">
                                    End Use(if Known)
                                </td>
                                <td style="width: 313px">
                                    <telerik:RadTextBox ID="txtEndUse" runat="server" Height="20px" MaxLength="100" 
                                        SelectionOnFocus="CaretToBeginning" Skin="MetroTouch">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Devlopment"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtDevlopment" Runat="server" MaxLength="150" 
                                        SelectionOnFocus="CaretToEnd" Skin="Metro">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 203px">
                                    &nbsp;
                                </td>
                                <td style="width: 313px">
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
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <table style="width: 100%" class="tableback">
                            <tr>
                                <td colspan="2">
                                    Finish<td>
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <%--    <asp:DropDownList ID="ddlFinish" runat="server" CssClass="combobox" 
                    DataSourceID="dsFinish" DataTextField="Finish" 
                    DataValueField="recipe_code" AppendDataBoundItems="True" AutoPostBack="True">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>--%>
                                                <asp:SqlDataSource ID="dsFinish" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                                                    SelectCommand="JCT_OPS_Get_Finishes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                                <telerik:RadComboBox ID="ddlFinish" runat="server" Height="30px" Skin="Metro" DataSourceID="dsFinish"
                                                    DataTextField="Finish" DataValueField="recipe_code" DropDownAutoWidth="Enabled"
                                                    MaxHeight="100px" Width="65%">
                                                </telerik:RadComboBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    Description
                                </td>
                                <td colspan="2">
                                    <telerik:RadTextBox ID="txtdescptn" runat="server" Height="200px" TextMode="MultiLine"
                                        Width="500px" SelectionOnFocus="CaretToBeginning" Skin="MetroTouch" LabelWidth="80%"
                                        Wrap="False">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                        </table>
                        <table class="tableback" style="width: 100%">
                            <tr>
                                <td width="150">
                                    Sort No/ Enq No
                                </td>
                                <td>
                                    <asp:TextBox ID="txtsort" runat="server" Width="70%" CssClass="textbox"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="txtsort_AutoCompleteExtender" runat="server" CompletionInterval="100"
                                        CompletionListCssClass="autocomplete_completionListElement" MinimumPrefixLength="1"
                                        ServiceMethod="OPS_Fabric_Items" ServicePath="~/webservice.asmx" TargetControlID="txtsort">
                                    </cc1:AutoCompleteExtender>
                                    <asp:LinkButton ID="CmdSearch" runat="server" BorderStyle="None" CssClass="searchbluesmall"
                                        Height="16px" OnClick="CmdSearch_Click" Width="16px" />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Panel ID="Panel2" runat="server" ScrollBars="Both" Width="98%">
                                        <asp:GridView ID="grdDetailsortsrch" runat="server" Width="90%">
                                            <AlternatingRowStyle CssClass="GridAI" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <PagerStyle CssClass="PageStyle" />
                                            <RowStyle CssClass="GridItem" />
                                            <SelectedRowStyle CssClass="GridGreenRow" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="98%">
                                        <asp:GridView ID="grdDetailsortnosrch" runat="server" EmptyDataText="No Record Found">
                                            <AlternatingRowStyle CssClass="GridAI" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <PagerStyle CssClass="PageStyle" />
                                            <RowStyle CssClass="GridItem" />
                                            <SelectedRowStyle CssClass="GridGreenRow" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <table class="tableback" style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Required On"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRequiredOn" runat="server" CssClass="textbox" MaxLength="15"
                                        TabIndex="28"  Width="65px"></asp:TextBox>
                                    <cc1:MaskedEditValidator ID="MEV6" runat="server" ControlExtender="MEE6" ControlToValidate="txtRequiredOn"
                                         Display="Dynamic" InvalidValueMessage="Invalid"
                                        IsValidEmpty="False" EmptyValueMessage="*" TooltipMessage="MM/DD/YYYY" 
                                        Width="114px" ValidationGroup="GrpSave"></cc1:MaskedEditValidator>
                                    <cc1:CalendarExtender ID="CalEfffr" runat="server" Animated="False" Format="MM/dd/yyyy"
                                        TargetControlID="txtRequiredOn" >
                                    </cc1:CalendarExtender>
                                    <cc1:MaskedEditExtender ID="MEE6" runat="server" Mask="99/99/9999" MaskType="Date"
                                        TargetControlID="txtRequiredOn"  >
                                    </cc1:MaskedEditExtender>
                                </td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Sample Attached"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="ddlSampleAttached" Runat="server" Skin="Metro" Width="80px">
                                        <items>
                                <telerik:RadComboBoxItem runat="server" Owner="ddlSampleAttached" Text="Yes" 
                                    Value="Yes" />
                                <telerik:RadComboBoxItem runat="server" Owner="ddlSampleAttached" Text="No" 
                                    Value="No" />
                            </items>
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:UpdateProgress ID="Updateprogress" runat="server" >
                                    <ProgressTemplate>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                                    
                                    </ProgressTemplate>
                                    </asp:UpdateProgress>

                                        
                                </td>
                            </tr>
                            <tr>
                                <td class="buttonbackbar" colspan="4">
                                    <telerik:RadButton ID="cmdApply" runat="server" onclick="cmdApply_Click" Skin="Metro"
                                        Text="Apply" ValidationGroup="GrpSave">
                                    </telerik:RadButton>
                                    &nbsp;
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
                                <td>
                                    &nbsp;
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
                            <tr>
                                <td colspan="4">
                                    <%--<telerik:RadNotification ID="RadNotification1" runat="server" Skin="Hay" 
                                        Style="z-index: 35000" VisibleOnPageLoad="true">
                                    </telerik:RadNotification>--%>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
