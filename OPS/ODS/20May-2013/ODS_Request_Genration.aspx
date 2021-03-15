<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="ODS_Request_Genration.aspx.vb" Inherits="OPS_ODS_Request_Genration" %>

<%--<%@ Register Src="~/Ops/MessageBox.ascx" TagName="uscMsgBox" TagPrefix="Mc1" %>--%>
<%--    <%@ Register assembly="ProudMonkey.Common.Controls"
             namespace="ProudMonkey.Common.Controls" tagprefix="cc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label3" runat="server" Text="Generate Request"></asp:Label>
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
                &nbsp;<asp:Label ID="Label4" runat="server" Text="Request Type"></asp:Label>
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
                <asp:Label ID="Label5" runat="server" Text="Order No"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox ID="txtOrderNo" runat="server" AutoPostBack="True" CssClass="textbox"></asp:TextBox>
                        <asp:LinkButton ID="cmdSearch" runat="server" CssClass="searchbluesmall" Height="17px"
                            Width="16px"></asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                RequestID
            </td>
            <td>
                <asp:Label ID="lblID" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </td>
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
             namespace="ProudMonkey.Common.Controls" tagprefix="cc1" %>--%>        <%--    <%@ Register assembly="ProudMonkey.Common.Controls"
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
        </tr>
        <tr>
            <td colspan="2">
                <asp:Panel ID="Panel6" runat="server" BorderColor="#837D7C" BorderWidth="1px" Width="100%">
                    <table style="width: 100%;" class="tableback">
                        <tr>
                            <td colspan="4">
                                Search Bales on the basis of :-</td>
                        </tr>
                        <tr>
                            <td>
                                Sale Order
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtSaleOrder" runat="server" CssClass="textbox" 
                                            ValidationGroup="SearchGroup"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                Shade
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtShade" runat="server" CssClass="textbox" 
                                            ValidationGroup="SearchGroup"></asp:TextBox>
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
                                        <asp:TextBox ID="txtSort" runat="server" CssClass="textbox" 
                                            ValidationGroup="SearchGroup"></asp:TextBox>
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
                                        <asp:TextBox ID="txtVariant" runat="server" CssClass="textbox" 
                                            ValidationGroup="SearchGroup"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqdVariant" runat="server" 
                                            ControlToValidate="txtVariant" Display="Dynamic" ErrorMessage="*" 
                                            SetFocusOnError="True" ValidationGroup="SearchGroup" ></asp:RequiredFieldValidator>
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
            <td colspan="3" width="95%">
                <asp:Panel ID="Panel1" runat="server" Height="300px">
                    <asp:UpdatePanel ID="UpdatePanel16" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Panel ID="Panel3" runat="server" Height="300px" ScrollBars="Both" Width="95%">
                                <asp:GridView ID="GrdPackedForOrder" runat="server" Width="100%" 
                                    EnableModelValidation="True" ShowFooter="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sel">
                                            <ItemTemplate>
                                            
                                                <asp:CheckBox ID="ChkOrderItems" runat="server" Checked="true" />
                                                
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="ChkOrderSelAll" runat="server" />
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
                                        <asp:TemplateField HeaderText="Sel">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkBox" runat="server" />
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
                        </Triggers>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
            <td valign="top">
                <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                    <ContentTemplate>
                      <%--  <asp:LinkButton ID="CmdAddItem" runat="server" Font-Size="Larger">+</asp:LinkButton>--%>
                         <asp:ImageButton ID="imgAddRow" runat="server" CommandName="Add" ImageUrl="~/Image/Icons/Action/iPhoneAdd.png"  ToolTip="Click to Add More Rows" ValidationGroup="a" Width="24px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <hr />
        <tr>
            <td colspan="3">
                <asp:Panel ID="Panel4" runat="server">
                    <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GrdTempValues" runat="server" Width="90%" 
                                EnableModelValidation="True" ShowFooter="True">
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
                              <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/OPS/Image/iPhone_Delete_icon.png" />
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
    <table style="width: 100%;" class="tableback">
        <tr>
            <td valign="top">
                <asp:Label ID="Label2" runat="server" Font-Size="Small" Text="Authorizing Hierarchy"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top">
                 <table style="width: 100%;">
                    <tr>
                        <td colspan="3" valign="top">
                            <asp:UpdatePanel ID="UpdatePanel8" runat="server" RenderMode="Inline">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                                    <asp:LinkButton ID="cmdSearchEmployee" runat="server" CssClass="searchbluesmall"
                                        Height="16px" Width="16px"></asp:LinkButton>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td width="50%">
                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server" Height="200px" ScrollBars="Both" Width="450px">
                                        <asp:CheckBoxList ID="ChkEmpList" runat="server" CellPadding="0" CellSpacing="0"
                                            Height="99px" RepeatColumns="1" Width="502px">
                                        </asp:CheckBoxList>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:LinkButton ID="btnTransfer" runat="server">Level</asp:LinkButton>
                            <br />
                            <br />
                            <%--    <%@ Register assembly="ProudMonkey.Common.Controls"
             namespace="ProudMonkey.Common.Controls" tagprefix="cc1" %>--%>
                            <asp:LinkButton ID="cmdCC" runat="server">Notify</asp:LinkButton>
                            <br />
                            <br />
                            <asp:LinkButton ID="imgRemoveItem" runat="server" Height="21px" ToolTip="Click To Clear All Selected Items"
                                Width="24px" CssClass="btncross">X</asp:LinkButton>
                            <br />
                        </td>
                        <td valign="top" width="50%">
                            <asp:UpdatePanel ID="UpdatePanel10" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                <ContentTemplate>
                                    Level<br />
                                    <asp:CheckBoxList ID="ChkDynamicListing" runat="server">
                                    </asp:CheckBoxList>
                                    <hr />
                                    Notify<br />
                                    <asp:CheckBoxList ID="chkNotify" runat="server">
                                    </asp:CheckBoxList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Remarks
                        </td>
                        <td colspan="2">
                            &nbsp;<asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="always">
                    <ContentTemplate>
                        <asp:Panel ID="Panel5" runat="server" Height="150px" ScrollBars="Vertical">
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
                <asp:Panel ID="Panel7" runat="server">
                    <table style="width:100%;" class="tableback">
                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="Made of Despatch"></asp:Label>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlMode" runat="server" CssClass="combobox" Height="20px">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Air</asp:ListItem>
                                            <asp:ListItem>Express</asp:ListItem>
                                            <asp:ListItem>Road</asp:ListItem>
                                            <asp:ListItem>Ship</asp:ListItem>
                                            <asp:ListItem>Train</asp:ListItem>
                                            <asp:ListItem>Tempo</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Freight Type"></asp:Label>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlFreightType" runat="server" CssClass="combobox">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>PrePay</asp:ListItem>
                                            <asp:ListItem>Topay</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="Docs ToBe Sent To"></asp:Label>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlDocsSentTo" runat="server" CssClass="combobox">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Banglore</asp:ListItem>
                                            <asp:ListItem>Bombay</asp:ListItem>
                                            <asp:ListItem>Customer</asp:ListItem>
                                            <asp:ListItem>Delhi</asp:ListItem>
                                            <asp:ListItem>Phagwara</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
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
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="CmdApply" runat="server" BorderStyle="None" CssClass="buttonc">Genrate</asp:LinkButton>
                &nbsp;<asp:LinkButton ID="CmdClear" runat="server" BorderStyle="None" CssClass="buttonc">Clear</asp:LinkButton>
                &nbsp;<asp:LinkButton ID="CmdRemove" runat="server" BorderStyle="None" CssClass="buttonc">Remove</asp:LinkButton>
                <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
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
        <%--  <Columns>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelection" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
    </table>
</asp:Content>
