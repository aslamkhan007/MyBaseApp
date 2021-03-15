<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="Modify Despatch Instruction.aspx.vb" Inherits="OPS_ODS_Modify_Despatch_Instruction" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%--<%@ Register Src="~/Ops/MessageBox.ascx" TagName="uscMsgBox" TagPrefix="Mc1" %>--%>
<%--    <%@ Register assembly="ProudMonkey.Common.Controls"
             namespace="ProudMonkey.Common.Controls" tagprefix="cc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">

        function transportmaster() {
            //            popupwindow = window.open("TransportMode.aspx");
            popupwindow = window.open("TransportMode.aspx");
        }

</script>   
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label3" runat="server" Text="Modify Request"></asp:Label>
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
                Plant
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPlant" runat="server" CssClass="combobox">
                            <asp:ListItem>Cotton</asp:ListItem>
                            <asp:ListItem>Taffeta</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Request Type"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel21" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlRequestType" runat="server" AutoPostBack="True" CssClass="combobox"
                            Width="140px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ReqVldRequestType" runat="server" ControlToValidate="ddlRequestType"
                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="LblOrderNo" runat="server" Text="Order No"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <%--    <%@ Register assembly="ProudMonkey.Common.Controls"
             namespace="ProudMonkey.Common.Controls" tagprefix="cc1" %>--%>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:RequiredFieldValidator ID="Reqd_OrderSearch" runat="server" 
                            ControlToValidate="txtOrderNo" Display="Dynamic" ErrorMessage="*" 
                            SetFocusOnError="True" ValidationGroup="OrderSearch"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtOrderNo" runat="server" AutoPostBack="True" CssClass="textbox"></asp:TextBox>
                        <asp:LinkButton ID="cmdSearch" runat="server" CssClass="searchbluesmall" Height="16PX"
                            Width="16px" ValidationGroup="OrderSearch"></asp:LinkButton>
                        &nbsp;
                        <asp:ImageButton ID="CmdRefresh" runat="server" BorderStyle="None" Height="20px"
                            Width="20px" ImageUrl="~/Image/Refresh.png"></asp:ImageButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                RequestID</td>
                 
                <td>
                 <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                <asp:Label ID="lblID" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                       </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                Search Id
             
              </td>
            <td>
            
                <asp:TextBox ID="txtSearchRequestId" runat="server"></asp:TextBox>
                <asp:LinkButton ID="Retrive" runat="server"  Height="16PX" Width="16px"
                            CssClass="searchbluesmall">Retrive</asp:LinkButton>
            
               
                </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="true"
                            EnableModelValidation="True">
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
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <%--    <%@ Register assembly="ProudMonkey.Common.Controls"
             namespace="ProudMonkey.Common.Controls" tagprefix="cc1" %>--%><%--    <%@ Register assembly="ProudMonkey.Common.Controls"
             namespace="ProudMonkey.Common.Controls" tagprefix="cc1" %>--%>
        <tr>
            <td>
                Subject
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSubject" runat="server" CssClass="textbox" MaxLength="50" Width="224px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="ImageProg" runat="server" ImageUrl="~/Image/Progress02.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblReason" runat="server" Text="Reason"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlReason" runat="server" CssClass="combobox">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td valign="top">
                Description
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="textbox" Height="150px"
                            MaxLength="800" TextMode="MultiLine" ToolTip="Give Detail description of raising this sanction request (upto 800Charcter)."
                            Width="400px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Panel ID="Panel6" runat="server" BorderColor="#837D7C" BorderWidth="1px" Width="100%">
                    <table style="width: 100%;" class="tableback">
                        <tr>
                            <td colspan="4">
                                Search Bales on the basis of :-
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="Lbl_Search_SaleOrder" runat="server" Text="Sale Order"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtSearchSaleOrder" runat="server" CssClass="textbox" ValidationGroup="SearchGroup"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel36" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="Lbl_Shade" runat="server" Text="Shade"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
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
                                <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblValue1" runat="server">Sort</asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtSearchSort" runat="server" CssClass="textbox" ValidationGroup="SearchGroup"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblValue2" runat="server">Variant</asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtSearchVariant" runat="server" CssClass="textbox" ValidationGroup="SearchGroup"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqdVariant" runat="server" ControlToValidate="txtSearchVariant"
                                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="SearchGroup"></asp:RequiredFieldValidator>
                                        <asp:LinkButton ID="CmdSearchData" runat="server" CssClass="searchbluesmall" Height="17px"
                                            Width="16px" ValidationGroup="SearchGroup"></asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td colspan="3">
           
                <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="ImageProg0" runat="server" ImageUrl="~/Image/Progress02.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
               
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3" width="95%">
                <asp:Panel ID="Panel1" runat="server" Height="300px">
                    <asp:UpdatePanel ID="UpdatePanel16" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Panel ID="Panel3" runat="server" Height="300px" ScrollBars="Both" Width="99%">
                                <asp:GridView ID="GrdPackedForOrder" runat="server" Width="100%" EnableModelValidation="True"
                                    ShowFooter="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sel">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkOrderItems" runat="server" />
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="ChkOrderSelAll" runat="server" AutoPostBack="True" 
                                                    oncheckedchanged="ChkOrderSelAll_CheckedChanged" />
                                            </HeaderTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Bales Packed for&nbsp; Source Order..
                                    </EmptyDataTemplate>
                                    <HeaderStyle CssClass="GridHeader" />
                                </asp:GridView>
                                <asp:GridView ID="GrdBasicDetail" runat="server" EnableModelValidation="True" Width="100%">
                                    <AlternatingRowStyle CssClass="GridAI" />
                                    <%--  <Columns>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelection" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <%--  <asp:BoundField DataField="CurrentOrder" HeaderText="CurrentOrder" />
                                    <asp:BoundField DataField="LineItem" HeaderText="LineItem" />
                                    <asp:BoundField DataField="ItemNo" HeaderText="ItemNo" />
                                    <asp:BoundField DataField="OrderVar" HeaderText="OrderVar" />
                                   
                                    <asp:BoundField DataField="BaleNo" HeaderText="BaleNo" />
                                     <asp:BoundField DataField="VariantNo" HeaderText="VariantNo" />
                                    <asp:BoundField DataField="Req_Qty" HeaderText="Qty" />
                                    <asp:BoundField DataField="CurrentDNVBySP" HeaderText="CurrentDNVBySP" />
                                    <asp:BoundField DataField="CurrentSP" HeaderText="CurrentSP" />
                                    <asp:BoundField DataField="OldOrder" HeaderText="OldOrder" />
                                    <asp:BoundField DataField="OldDNV" HeaderText="OldDNV" />
                                    <asp:BoundField DataField="OldDnvByCst" HeaderText="OldDnvByCst" />
                                    <asp:BoundField DataField="OldSP" HeaderText="OldSP" />--%><%-- </Columns>--%>
                                    <Columns>
                                        <%-- <asp:TemplateField HeaderText="Sel">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkBox" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Sel">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="ChkBasicDetail_SelAll" runat="server" OnCheckedChanged="ChkBasicDetail_SelAll_CheckedChanged"
                                                    AutoPostBack="true" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkBox" runat="server" 
                                                   />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        Not Data Found... !!!
                                    </EmptyDataTemplate>
                                    <HeaderStyle CssClass="GridHeader" />
                                    <RowStyle CssClass="GridItem" />
                                </asp:GridView>
                            </asp:Panel>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="cmdSearch" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="CmdSearchData" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="CmdRefresh" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
            <td valign="top">
                <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                    <ContentTemplate>
                        <%--  <asp:LinkButton ID="CmdAddItem" runat="server" Font-Size="Larger">+</asp:LinkButton>--%>
                        <asp:ImageButton ID="imgAddRow" runat="server" CommandName="Add" ImageUrl="~/Image/Icons/Action/iPhoneAdd.png"
                            ToolTip="Click to Add More Rows" ValidationGroup="a" Width="24px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <hr />
        <tr>
            <td colspan="3">
                <asp:Panel ID="Panel4" runat="server" Width="100%">
                    <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GrdTempValues" runat="server" Width="99%" EnableModelValidation="True"
                                ShowFooter="True">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkDelete" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
            <td valign="top">
                <asp:UpdatePanel ID="UpdatePanel28" runat="server">
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
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GrdCostDetail" runat="server" EnableModelValidation="True" AutoGenerateColumns="False"
                            Width="100%">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <Columns>
                                <asp:BoundField DataField="ItemNo" HeaderText="ItemNo" />
                                <asp:BoundField DataField="Variant" HeaderText="Variant" />
                                <asp:TemplateField HeaderText="SellingPrice">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtProposedSellingPrice" runat="server" CssClass="textbox" Width="55px"
                                            MaxLength="6"></asp:TextBox>
                                        <%--     <cc1:FilteredTextBoxExtender ID="txtProposedSellingPrice_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" TargetControlID="txtProposedSellingPrice" 
                                            ValidChars=".0123456789">
                                         
                                        </cc1:FilteredTextBoxExtender>--%>
                                        <telerik:RadInputManager ID="RadInputManager1" runat="server">
                                            <telerik:NumericTextBoxSetting AllowRounding="False" Culture="en-US" DecimalDigits="2"
                                                DecimalSeparator="." GroupSeparator="," GroupSizes="3" MaxValue="999" MinValue="1"
                                                NegativePattern="-n" PositivePattern="n" SelectionOnFocus="SelectAll" ZeroPattern="n">
                                                <TargetControls>
                                                    <telerik:TargetInput ControlID="RadInputManager1" />
                                                    <telerik:TargetInput ControlID="txtProposedSellingPrice" />
                                                </TargetControls>
                                                <Validation IsRequired="True" />
                                                <Validation IsRequired="True" />
                                            </telerik:NumericTextBoxSetting>
                                        </telerik:RadInputManager>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RateUom">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlRateUom" runat="server">
                                            <asp:ListItem Value="Meter">Meter</asp:ListItem>
                                            <asp:ListItem>Yards</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                Not Data Found... !!!
                            </EmptyDataTemplate>
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
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%;" class="tableback">
                <tr>
                    <td valign="top">
                        <asp:Label ID="Label2" runat="server" Font-Size="Small" Text="Authorizing Hierarchy"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:Panel ID="PnlAuthorization" runat="server">
                            <table style="width: 100%;">
                                <tr>
                                    <td colspan="3" valign="top">
                                        <%--  <asp:UpdatePanel ID="UpdatePanel8" runat="server" RenderMode="Inline">
                                            <ContentTemplate>--%>
                                        <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                                        <asp:LinkButton ID="cmdSearchEmployee" runat="server" CssClass="searchbluesmall"
                                            Height="16px" Width="16px"></asp:LinkButton>
                                        <%--   </ContentTemplate>
                                        </asp:UpdatePanel>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="50%">
                                        <%--  <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                            <ContentTemplate>--%>
                                        <asp:Panel ID="Panel2" runat="server" Height="200px" ScrollBars="Both" Width="450px">
                                            <asp:CheckBoxList ID="ChkEmpList" runat="server" CellPadding="0" CellSpacing="0"
                                                Height="99px" RepeatColumns="1" Width="502px">
                                            </asp:CheckBoxList>
                                        </asp:Panel>
                                        <%--   </ContentTemplate>
                                        </asp:UpdatePanel>--%>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="btnTransfer" runat="server">Level</asp:LinkButton>
                                        <br />
                                        <br />
                                        <%--  <asp:BoundField DataField="CurrentOrder" HeaderText="CurrentOrder" />
                                    <asp:BoundField DataField="LineItem" HeaderText="LineItem" />
                                    <asp:BoundField DataField="ItemNo" HeaderText="ItemNo" />
                                    <asp:BoundField DataField="OrderVar" HeaderText="OrderVar" />
                                   
                                    <asp:BoundField DataField="BaleNo" HeaderText="BaleNo" />
                                     <asp:BoundField DataField="VariantNo" HeaderText="VariantNo" />
                                    <asp:BoundField DataField="Req_Qty" HeaderText="Qty" />
                                    <asp:BoundField DataField="CurrentDNVBySP" HeaderText="CurrentDNVBySP" />
                                    <asp:BoundField DataField="CurrentSP" HeaderText="CurrentSP" />
                                    <asp:BoundField DataField="OldOrder" HeaderText="OldOrder" />
                                    <asp:BoundField DataField="OldDNV" HeaderText="OldDNV" />
                                    <asp:BoundField DataField="OldDnvByCst" HeaderText="OldDnvByCst" />
                                    <asp:BoundField DataField="OldSP" HeaderText="OldSP" />--%>
                                        <asp:LinkButton ID="cmdCC" runat="server">Notify</asp:LinkButton>
                                        <br />
                                        <br />
                                        <asp:LinkButton ID="imgRemoveItem" runat="server" Height="21px" ToolTip="Click To Clear All Selected Items"
                                            Width="24px" CssClass="btncross">X</asp:LinkButton>
                                        <br />
                                    </td>
                                    <td valign="top" width="50%">
                                        <%--   <asp:UpdatePanel ID="UpdatePanel10" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                            <ContentTemplate>--%>
                                        Level<br />
                                        <asp:CheckBoxList ID="ChkDynamicListing" runat="server">
                                        </asp:CheckBoxList>
                                        <hr />
                                        Notify<br />
                                        <asp:CheckBoxList ID="chkNotify" runat="server">
                                        </asp:CheckBoxList>
                                        <%--  </ContentTemplate>
                                        </asp:UpdatePanel>--%>
                                    </td>
                                </tr>
                               
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="always">
                    <ContentTemplate>
                        <asp:Panel ID="Pnl_Emplyee_Hierarchy" runat="server" Height="150px" ScrollBars="Vertical">
                            <asp:GridView ID="GrdEmployee" runat="server" Width="99%">
                                <PagerStyle CssClass="PagerStyle" />
                                <AlternatingRowStyle CssClass="GridAI" />
                                <EmptyDataTemplate>
                                    No Data Found...! ! !
                                </EmptyDataTemplate>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                                <SelectedRowStyle CssClass="GridRowGreen" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Pnl_DepatchDetail" runat="server">
                            <table style="width: 100%;" class="tableback">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="Customer Type"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                        <asp:RadioButtonList ID="RblSearch_Cust" runat="server" AutoPostBack="True" 
                                            CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True">Default</asp:ListItem>
                                            <asp:ListItem>Other</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Panel ID="Pnl_OtherCust" runat="server">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td width="90px">
                                                        <asp:Label ID="Label11" runat="server" Text="Customer Name"></asp:Label>
                                                    </td>
                                                    <td width="150px" style="width: 350px">
                                                        <asp:TextBox ID="txtSearchCustomer" runat="server" AutoPostBack="True" CssClass="textbox"
                                                            Width="200px" ToolTip="Please give Customer Code or Select Customer from the List "></asp:TextBox>
                                                        <div id="divwidth" style="display: none;">
                                                            <cc1:AutoCompleteExtender ID="txtSearchCustomer_AutoCompleteExtender" runat="server" CompletionInterval="10"
                                                                CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="OPS_Customer"
                                                                CompletionListCssClass="AutoExtender" ServicePath="~/WebService.asmx" CompletionListElementID="divwidth"
                                                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListItemCssClass="AutoExtenderList"
                                                                TargetControlID="txtSearchCustomer">
                                                            </cc1:AutoCompleteExtender>
                                                        </div>
                                                        &nbsp;<asp:LinkButton ID="CmdSearchCust0" runat="server" CssClass="searchbluesmall" Height="17px"
                                                            Width="16px"></asp:LinkButton>
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
                                        <asp:Label ID="Label6" runat="server" Text="Mode of Despatch"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlMode" runat="server" CssClass="combobox" Height="20px" 
                                            AutoPostBack="True">
                                    <%--        <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>AIR</asp:ListItem>
                                            <asp:ListItem>SEA</asp:ListItem>
                                            <asp:ListItem>ROAD</asp:ListItem> --%>                                     
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlModeDescription" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtModeCode" runat="server" AutoPostBack="True"></asp:TextBox>
                                        <%--<asp:ImageButton ID="imgTransportmode" runat="server" BackColor="#990000" 
                                            CausesValidation="False" Font-Bold="True" ForeColor="White" Height="16px"   OnClick = "imgTransportmode_Click"  
                                            ImageUrl="~/Image/Icons/Action/Search.png" 
                                            ToolTip="PREVIEW REPORT" Width="20px" />--%>
                                        <asp:ImageButton ID="imgbtnTransportmode0" runat="server" Height="20px" 
                                            ImageUrl="~/Image/document_add.PNG" 
                                            onclientclick="transportmaster();return false;" ToolTip="Add New TransportMode" 
                                            Width="20px" />
                                    </td>
                                        
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="Freight Type"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlFreightType" runat="server" CssClass="combobox" 
                                            AutoPostBack="True">
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
                                        <asp:DropDownList ID="ddlShipmentAddress" runat="server" CssClass="combobox" AutoPostBack="True">
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
                                <tr>
                                    <td>
                                        <asp:Label ID="lblNotifyName" runat="server" Text="NotifyName"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtNotifyName" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" Text="NotifyAddress1"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtNotifyAdd1" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label14" runat="server" Text="NotifyAddress2"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtNotifyAdd2" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label15" runat="server" Text="NotifyAddress3"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtNotifyAdd3" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label16" runat="server" Text="NotifyCity"></asp:Label>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="txtNotifyCity" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label19" runat="server" Text="NotifyState"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNotifyState" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>

                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label20" runat="server" Text="NotifyCountry"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNotifyCountry" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblbuyerpo0" runat="server" Text="Buyers Po"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBuyerPo" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblPayTerm" runat="server" Text="PayTerm"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPayTerm" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPortofDispatch" runat="server" 
                                            Text="Despatch Country" Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDespatchPort" runat="server" CssClass="textbox" 
                                            Visible="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDestination" runat="server" 
                                            Text="Destination Country" Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDestinationPort" runat="server" CssClass="textbox" 
                                            Visible="False"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCarrierName" runat="server" Text="Carrier Name"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCarrierName" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                   <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
            
                <asp:LinkButton ID="CmdApply" runat="server" BorderStyle="None" CssClass="buttonc">Update</asp:LinkButton>
                <asp:LinkButton ID="CmdSendRequest" runat="server" BorderStyle="None" CssClass="buttonc">Send 
                        Request</asp:LinkButton>
              <asp:LinkButton ID="CmdClear" runat="server" BorderStyle="None" CssClass="buttonc">Clear</asp:LinkButton>
             
                &nbsp;<asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
                                </ContentTemplate>
                       <triggers>
                           <asp:AsyncPostBackTrigger ControlID="CmdApply" EventName="Click" />
                       </triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
               
                             <asp:UpdateProgress ID="UpdateProgress3" runat="server" 
                                 AssociatedUpdatePanelID="UpdatePanel4" DisplayAfter="10">
                    <ProgressTemplate>
                        <asp:Image ID="ImageProg1" runat="server" ImageUrl="~/Image/Progress02.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>

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
        <%--  <asp:BoundField DataField="CurrentOrder" HeaderText="CurrentOrder" />
                                    <asp:BoundField DataField="LineItem" HeaderText="LineItem" />
                                    <asp:BoundField DataField="ItemNo" HeaderText="ItemNo" />
                                    <asp:BoundField DataField="OrderVar" HeaderText="OrderVar" />
                                   
                                    <asp:BoundField DataField="BaleNo" HeaderText="BaleNo" />
                                     <asp:BoundField DataField="VariantNo" HeaderText="VariantNo" />
                                    <asp:BoundField DataField="Req_Qty" HeaderText="Qty" />
                                    <asp:BoundField DataField="CurrentDNVBySP" HeaderText="CurrentDNVBySP" />
                                    <asp:BoundField DataField="CurrentSP" HeaderText="CurrentSP" />
                                    <asp:BoundField DataField="OldOrder" HeaderText="OldOrder" />
                                    <asp:BoundField DataField="OldDNV" HeaderText="OldDNV" />
                                    <asp:BoundField DataField="OldDnvByCst" HeaderText="OldDnvByCst" />
                                    <asp:BoundField DataField="OldSP" HeaderText="OldSP" />--%>
    </table>
</asp:Content>

