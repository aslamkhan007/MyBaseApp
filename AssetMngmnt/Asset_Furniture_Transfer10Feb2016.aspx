<%@ Page Title="" Language="C#" MasterPageFile="~/AssetMngmnt/MasterPage.master"
    AutoEventWireup="true" CodeFile="Asset_Furniture_Transfer.aspx.cs" Inherits="AssetMngmnt_Asset_Furniture_Transfer" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function SetContextKey() {
            $find('<%=txtEmployee_AutoCompleteExtender.ClientID%>').set_contextKey($get("<%=ddlloc.ClientID %>").value);
        }
    </script>
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="6">
                Furniture Transfer
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="3">
                Current Location
            </td>
            <td class="NormalText" colspan="3">
                Target Location
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 115px">
                Location
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <div id="divwidth" style="display: none;">
                        </div>
                        <telerik:RadComboBox ID="ddlloc" runat="server" AutoPostBack="True" CssClass="combobox"
                            EnableVirtualScrolling="true" ExpandDirection="Down" Height="85" OnSelectedIndexChanged="ddlloc_SelectedIndexChanged"
                            Visible="true">
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 115px">
                &nbsp;
            </td>
            <td class="NormalText" style="width: 128px">
                Location
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <div id="divwidth0" style="display: none;">
                        </div>
                        <telerik:RadComboBox ID="ddltargetloc" runat="server" AutoPostBack="True" CssClass="combobox"
                            EnableVirtualScrolling="true" ExpandDirection="Down" Height="85" Visible="true"
                            OnSelectedIndexChanged="ddltargetloc_SelectedIndexChanged">
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 115px">
                SubLocation
            </td>
            <td class="NormalText" style="width: 122px">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="ddlSubloc" runat="server" AutoPostBack="True" CssClass="combobox"
                            EnableVirtualScrolling="True" Height="85px" 
                            onselectedindexchanged="ddlSubloc_SelectedIndexChanged">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" />
                            </Items>
                        </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSubloc"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="mandatory1"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlSubloc"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="mandatory"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 115px">
                &nbsp;
            </td>
            <td class="NormalText" style="width: 128px">
                SubLocation
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="ddlTargetSubloc" runat="server" AutoPostBack="True" CssClass="combobox"
                            EnableVirtualScrolling="True" Height="85px" 
                            onselectedindexchanged="ddlTargetSubloc_SelectedIndexChanged">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" />
                            </Items>
                        </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlTargetSubloc"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="mandatory"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                    <triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddltargetloc" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSubloc" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlloc" EventName="SelectedIndexChanged" />
                    </triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 115px; height: 16px;">
                <asp:Label ID="lblLocation" runat="server" Text="EmployeeCode" Visible="False" CssClass="Normal text"></asp:Label>
            </td>
            <td class="NormalText" style="width: 122px; height: 16px;">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtempcode" runat="server" AutoPostBack="true" CssClass="textbox"
                            onkeyup="SetContextKey()" Visible="False"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" CompletionInterval="10"
                            CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" MinimumPrefixLength="1"
                            ServiceMethod="GetEmployeeDepartment_test" ServicePath="~/WebService.asmx" TargetControlID="txtempcode"
                            UseContextKey="True">
                        </cc1:AutoCompleteExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 115px; height: 16px;">
                &nbsp;
            </td>
            <td class="NormalText" style="width: 128px; height: 16px">
                <asp:Label ID="lblMappedtext" runat="server"   CssClass="Normal text"> Employee Name</asp:Label>
            </td>
            <td class="NormalText">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                <asp:Label ID="lblMappedEmployee" runat="server"   CssClass="Normal text"></asp:Label>
                </ContentTemplate>
                                            <triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddltargetloc" 
                                                    EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlTargetSubloc" 
                                                    EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlSubloc" 
                                                    EventName="SelectedIndexChanged" />
                                            </triggers>
                </asp:UpdatePanel>

            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 97px">
                &nbsp;
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 115px">
                &nbsp;
            </td>
            <td class="NormalText" style="width: 128px">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 97px">
                RefDoc Type</td>
            <td class="NormalText">
                        <telerik:RadComboBox ID="ddlRefType" runat="server" AutoPostBack="True" CssClass="combobox"
                            EnableVirtualScrolling="True" Height="85px" >
                            <Items>
                                


<telerik:RadComboBoxItem runat="server" Text="Other" Value="Other" 
                                    Selected="True" />
                                <telerik:RadComboBoxItem runat="server" Text="Officer Order" Value="Sold" />
                                <telerik:RadComboBoxItem runat="server" Text="Invoice" Value="Sold" />
                                <telerik:RadComboBoxItem runat="server" Text="Igp" Value="Sold" />

                            </Items>
                        </telerik:RadComboBox>
                        </td>
            <td class="NormalText" style="width: 115px">
                &nbsp;</td>
            <td class="NormalText" style="width: 128px">
                Ref Doc No</td>
            <td class="NormalText">
                        <asp:TextBox ID="txtrefdocno" runat="server"  CssClass="textbox"
                         ></asp:TextBox>                        
                    </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 97px">
                Remarks</td>
            <td class="NormalText">
                                <asp:TextBox ID="txtRemarks" runat="server" 
                    CssClass="textbox" TextMode="MultiLine"
                                    Height="50px" Width="300px" ToolTip="Remarks If Any."
                                    TabIndex="15"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 115px">
                &nbsp;</td>
            <td class="NormalText" style="width: 128px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 97px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText" style="width: 115px">
                &nbsp;</td>
            <td class="NormalText" style="width: 128px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="6">
                <asp:UpdatePanel ID="Updbuttons" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" OnClick="lnkfetch_Click"
                            ValidationGroup="mandatory1">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkTransfer" runat="server" CssClass="buttonc" ValidationGroup="mandatory"
                            OnClick="lnkTransfer_Click">Transfer</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" OnClick="lnkReset_Click">Reset</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>


    </table>
                
    <table class="mytable">
        <tr>
      <td class="tableheader" colspan="6">
               Current Location Details:
            </td>
        </tr>
        <tr >
            <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlgrid" Width="1000px" runat="server" Height="200px" ScrollBars="Horizontal">
                <asp:GridView ID="grdDetail" runat="server" Width="100%" EmptyDataText="No Record Found ..."
                    AutoGenerateColumns="False" 
                    CaptionAlign="Left">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <HeaderStyle CssClass="GridHeader" />
                    <RowStyle CssClass="GridItem" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkRemove" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Sr_no" HeaderText="SrNo" />
                        <asp:BoundField DataField="Sublocation" HeaderText="Sublocation" />
                        <asp:BoundField DataField="AssetCategory" HeaderText="AssetCategory" />
                        <asp:BoundField DataField="ItemDescription" HeaderText="ItemDescription" />
                        <asp:BoundField DataField="NoOfItems" HeaderText="NoOfItems" />
                        <asp:BoundField DataField="MappedEmployee" HeaderText="MappedEmployee" />
                        <%--             <asp:BoundField DataField="AllocationDate" HeaderText="AllocationDate" />--%>
                        <asp:TemplateField HeaderText="AllocationDate">
                            <ItemTemplate>
                                <asp:TextBox ID="txtAllocationDate" runat="server" Columns="12" CssClass="textbox"
                                    MaxLength="100" Text='<%# Eval("AllocationDate") %>' Width="70px" ToolTip="Remarks"
                                   ></asp:TextBox>
                                <cc1:CalendarExtender ID="txtunmapdateCalendarExtender" runat="server" Enabled="True"
                                    TargetControlID="txtAllocationDate">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="ReqAllocationDate" runat="server" ControlToValidate="txtAllocationDate"
                                    ErrorMessage="*" ValidationGroup="mandatory" Enabled="False"></asp:RequiredFieldValidator>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="TransNo" HeaderText="TransNo" />
                        <asp:BoundField DataField="Requestid" HeaderText="Requestid" />
                        
                    </Columns>
                </asp:GridView>               
            </asp:Panel>
                          <%--  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
             <asp:Label ID="lblTotaltext" runat="server" Text="Total Items"  
                CssClass="Normal text"></asp:Label>:
                <asp:Label ID="lblTotal" runat="server"   CssClass="Normal text"></asp:Label>

                        </ContentTemplate>
                                <triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddltargetloc" 
                                        EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlTargetSubloc" 
                                        EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlSubloc" 
                                        EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="lnkTransfer" EventName="Click" />
                                </triggers>
    </asp:UpdatePanel>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
            </td>
        </tr>
        <tr colspan="6">
      <td class="tableheader" colspan="6">
              Target Location Details:
            </td>
        </tr>
        <tr colspan="6">
            <td>
             <asp:UpdatePanel ID="UpdatePanel6" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel1" Width="1000px" runat="server" Height="200px" ScrollBars="Horizontal">
                <asp:GridView ID="grdTransfer" runat="server" Width="100%" EmptyDataText="No Record Found ..." 
                    AutoGenerateColumns="False" 
                    CaptionAlign="Left">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <HeaderStyle CssClass="GridHeader" />
                    <RowStyle CssClass="GridItem" />
                    <Columns>
                        <asp:BoundField DataField="Sr_no" HeaderText="SrNo" />
                        <asp:BoundField DataField="Sublocation" HeaderText="Sublocation" />
                        <asp:BoundField DataField="AssetCategory" HeaderText="AssetCategory" />
                        <asp:BoundField DataField="ItemDescription" HeaderText="ItemDescription" />
                        <asp:BoundField DataField="NoOfItems" HeaderText="NoOfItems" />
                        <asp:BoundField DataField="MappedEmployee" HeaderText="MappedEmployee" />                     
                        <asp:BoundField DataField="AllocationDate" HeaderText="AllocationDate" />
                        <asp:BoundField DataField="TransNo" HeaderText="TransNo" />
                        <asp:BoundField DataField="Requestid" HeaderText="Requestid" />
                        
                    </Columns>
                </asp:GridView>               
            </asp:Panel>
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
             <asp:Label ID="lblTotaltext" runat="server" Text="Total Items"  
                CssClass="Normal text"></asp:Label>:
                <asp:Label ID="lblTotal" runat="server"   CssClass="Normal text"></asp:Label>

                        </ContentTemplate>
                                <triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddltargetloc" 
                                        EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlTargetSubloc" 
                                        EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlSubloc" 
                                        EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="lnkTransfer" EventName="Click" />
                                </triggers>
    </asp:UpdatePanel>
        </ContentTemplate>
    </asp:UpdatePanel>
            </td>
        </tr>
 </table>
</asp:Content>
