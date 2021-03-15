<%@ Page Title="" Language="C#" MasterPageFile="~/Courier Tracking System/MasterPage.master"
    AutoEventWireup="true" CodeFile="Generate_request10.aspx.cs" Inherits="Courier_Tracking_System_Generate_request10" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

 <script type = "text/javascript">
          var counter = 0;
          function AddFileUpload() {
              var div = document.createElement('DIV');
              div.innerHTML = '<input id="file' + counter + '" name = "file' + counter + '" type="file" /><input id="Button' + counter + '" type="button" value="Remove" onclick = "RemoveFileUpload(this)" />';
              document.getElementById("FileUploadContainer").appendChild(div);
              counter++;
          }
          function RemoveFileUpload(div) {
              document.getElementById("FileUploadContainer").removeChild(div.parentNode);
          }
</script>

      <%--<asp:UpdatePanel ID="UpdatePanelGrd" runat="server" >
                                        <ContentTemplate>--%>

    <table style="width: 100%">
        <tr>
            <td class="tableheader">
                Generate Courier Request
                a1</td>
        </tr>
    </table>

    <table style="width: 100%">
        <tr>
            <td class="tableheader" style="color: #008080">
                <asp:Image ID="ImageCourierDetail" runat="server" ImageUrl="~/Image/plus.png" Style="margin-right: 5px;" />
                Courier Details
                 <cc1:CollapsiblePanelExtender ID="cpe" runat="Server" AutoCollapse="False" AutoExpand="True"
                                    CollapseControlID="ImageCourierDetail" Collapsed="False" CollapsedImage="~/Image/plus.png"
                                    CollapsedSize="0" ExpandControlID="ImageCourierDetail" ExpandDirection="Vertical" ExpandedImage="~/Image/minus.png"
                                    ImageControlID="ImageCourierDetail" ScrollContents="false" TargetControlID="Panel4" />
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Panel ID="Panel4" Width="100%" runat="server" BorderStyle="Solid" BorderWidth="1px">
                    <table style="width: 100%;" class="tableback">
                        <tr>
                            <td class="NormalText" style="width: 117px">
                                <asp:Label ID="Label49" runat="server" Text="Courier Type"></asp:Label>
                            </td>
                            <td class="NormalText" style="width: 216px">
                                <asp:DropDownList ID="ddlCourierType" runat="server" CssClass="combobox" TabIndex="1">
                                </asp:DropDownList>
                                <asp:LinkButton ID="lnkAddNewCourierType" runat="server" ToolTip="Add new Courier Type i.e. Documnet, Sample, Invoice, Purchase order etc. You can create item before generating the courier request.">Add New</asp:LinkButton>
                                <cc1:ModalPopupExtender ID="lnkAddNewCourierType_ModalPopupExtender" runat="server"
                                    TargetControlID="lnkAddNewCourierType" CancelControlID="lnkCancelCourierType"
                                    BackgroundCssClass="modalBackground" PopupControlID="Panel2">
                                </cc1:ModalPopupExtender>
                            </td>
                            <td class="NormalText" style="width: 113px">
                                <asp:Label ID="Label51" runat="server" Text="Courier Service"></asp:Label>
                            </td>
                            <td class="NormalText">
                                <asp:DropDownList ID="ddlCourierService" runat="server" CssClass="combobox" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"
                                    TabIndex="2">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="NormalText" style="width: 117px">
                                <asp:Label ID="Label50" runat="server" Text="Select Cost Center"></asp:Label>
                            </td>
                            <td class="NormalText" style="width: 216px">
                                <asp:UpdatePanel ID="UpdatePanel13" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtCostCenter" CssClass="textbox" runat="server" AutoPostBack="True"
                                            OnTextChanged="txtCostCenter_TextChanged" ToolTip="Type the department name for which courier is to send."></asp:TextBox>
                                                 <div id="divwidth2" style="display:none;">   
                                            <cc1:AutoCompleteExtender ID="txtCostCenter_AutoCompleteExtender" runat="server"
                                                CompletionInterval="10" CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth2"
                                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListItemCssClass="AutoExtenderList"
                                                CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="CostCenter" ServicePath="~/WebService.asmx"
                                                TargetControlID="txtCostCenter">
                                            </cc1:AutoCompleteExtender>
                                        </div>
                                    </ContentTemplate>
                               
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="rblSelect" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server" RenderMode="Inline" 
                                    UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Image ID="imgCheck" runat="server" Visible="false" />
                                </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtCostCenter" EventName="TextChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel13" DisplayAfter="100">
                                    <ProgressTemplate>
                                        <asp:Image ID="imgCostCenter" runat="server" ImageUrl="~/Image/load.gif" />
                                    </ProgressTemplate>
                                   
                                </asp:UpdateProgress>
                            </td>
                            <td class="NormalText" style="width: 113px">
                                <asp:Label ID="Label42" runat="server" Text="Delivery Type"></asp:Label>
                            </td>
                            <td class="NormalText">
                                <asp:DropDownList ID="ddlDelivery" runat="server" CssClass="combobox" TabIndex="3">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 117px">
                               
                            </td>
                            <td class="NormalText" style="width: 216px">
                                &nbsp;
                            </td>
                            <td class="NormalText" style="width: 113px">
                                &nbsp;
                            </td>
                            <td class="NormalText">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>

    <table style="width: 100%">
        <tr>
            <td class="tableheader" style="color: #008080">
                <asp:Image ID="ImageReceiverDetail" runat="server" ImageUrl="~/Image/plus.png" Style="margin-right: 5px;" />
                Receiver's Detail 
                    <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="Server" AutoCollapse="False" AutoExpand="True"
                                    CollapseControlID="ImageReceiverDetail" Collapsed="False" CollapsedImage="~/Image/plus.png"
                                    CollapsedSize="0" ExpandControlID="ImageReceiverDetail" ExpandDirection="Vertical" ExpandedImage="~/Image/minus.png"
                                    ImageControlID="ImageReceiverDetail" ScrollContents="false" TargetControlID="Panel5" />
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Panel ID="Panel5" Width="100%" runat="server" BorderStyle="Solid" BorderWidth="1px">
                    <table style="width: 100%;" class="tableback">
                        <tr>
                            <td class="NormalText" style="width: 117px">
                                <asp:Label ID="Label33" runat="server" Text="Send Courier To"></asp:Label>
                            </td>
                            <td class="NormalText" colspan="3">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                     <asp:RadioButtonList ID="rblSelect" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
                                            CssClass="labelcells" Font-Bold="True" Font-Italic="False" Font-Overline="False"
                                            Font-Underline="False" OnSelectedIndexChanged="rblSelect_SelectedIndexChanged"
                                            Width="500px" CellPadding="0" CellSpacing="0">
                                            <asp:ListItem Selected="True">Customer</asp:ListItem>
                                            <asp:ListItem>Supplier</asp:ListItem>
                                            <asp:ListItem>HO</asp:ListItem>
                                            <asp:ListItem Value="Hoshiarpur">Hoshiarpur JCT</asp:ListItem>
                                            <asp:ListItem>Sales Office</asp:ListItem>
                                            <asp:ListItem>Other</asp:ListItem>
                                            <asp:ListItem>Personal</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <cc1:PopupControlExtender ID="rblSelect_PopupControlExtender" runat="server" TargetControlID="rblSelect"
                                            PopupControlID="pnlSaleOffice" Position="Right">
                                        </cc1:PopupControlExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="NormalText" style="width: 117px">
                                <asp:Label ID="Label54" runat="server" Text="Party Code"></asp:Label>
                            </td>
                            <td class="NormalText" colspan="3">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txt" runat="server" AutoPostBack="True" CssClass="textbox" OnTextChanged="txt_TextChanged"
                                            ToolTip="Enter party Code or click Search Button to search Party." TabIndex="5"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt"
                                            ErrorMessage="Please Enter Party Code" Enabled="False"></asp:RequiredFieldValidator>
                                        <asp:CheckBox ID="chkIsSample" runat="server" Text="Sample" AutoPostBack="True" 
                                            oncheckedchanged="chkIsSample_CheckedChanged" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="txtPartyName" EventName="TextChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="rblSelect" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="rblSaleOffices" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                                   
                                    <ProgressTemplate>
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Image/load.gif" />
                                    </ProgressTemplate>
                                   
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 117px; vertical-align: top;">
                                <asp:Label ID="Label22" runat="server" Text="Party Name"></asp:Label>
                            </td>
                            <td class="NormalText" style="width: 216px">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtPartyName" runat="server" CssClass="textbox" Width="200px" TabIndex="6"
                                            AutoPostBack="True" OnTextChanged="txtPartyName_TextChanged"></asp:TextBox>
                                        <br />
                                        <asp:TextBox ID="txtSupplierName" runat="server" AutoPostBack="True" CssClass="textbox"
                                            OnTextChanged="txtPartyName_TextChanged" TabIndex="6" Visible="False" Width="200px"></asp:TextBox>
                                        <div id="divwidth" style="display: none;">
                                            <cc1:AutoCompleteExtender ID="txtSupplierName_AutoCompleteExtender" runat="server"
                                                TargetControlID="txtSupplierName" CompletionInterval="1" FirstRowSelected="True"
                                                MinimumPrefixLength="1" ServiceMethod="SupplierAddress_CourierSystem" ServicePath="~/WebService.asmx"
                                                CompletionListElementID="divwidth" CompletionListCssClass="AutoExtender" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                CompletionListItemCssClass="AutoExtenderList">
                                            </cc1:AutoCompleteExtender>
                                        </div>
                                        <div id="divwidth1" style="display: none;">
                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="1"
                                                FirstRowSelected="True" MinimumPrefixLength="1" ServiceMethod="CustomerAddress_CourierSystem"
                                                ServicePath="~/WebService.asmx" TargetControlID="txtPartyName" CompletionListElementID="divwidth1"
                                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListCssClass="AutoExtender"
                                                CompletionListItemCssClass="AutoExtenderList">
                                            </cc1:AutoCompleteExtender>
                                        </div>
                                        <br />
                                        <asp:TextBox ID="txtOtherParty" runat="server" AutoPostBack="True" CssClass="textbox"   ontextchanged="txtOtherParty_TextChanged"
                                            TabIndex="6" Visible="False" Width="200px"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ID="txtOtherParty_AutoCompleteExtender" runat="server"
                                            TargetControlID="txtOtherParty" CompletionInterval="1" CompletionListCssClass="AutoExtender"
                                            CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                            CompletionListItemCssClass="AutoExtenderList" FirstRowSelected="True" MinimumPrefixLength="1"
                                            ServiceMethod="OtherPartyAddress_CourierSystem" ServicePath="~/WebService.asmx">
                                        </cc1:AutoCompleteExtender>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="txt" EventName="TextChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="rblSelect" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="rblSelect" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="rblSaleOffices" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <a id="addLink" href="javascript:void(0)" onclick="ShowEditBox()" style="display: none;"
                                    title="Add">Add</a>
                            </td>
                            <td class="NormalText" style="width: 113px; vertical-align: top;">
                                <asp:Label ID="Label34" runat="server" Text="Address 1"></asp:Label>
                            </td>
                            <td class="NormalText">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtAdd1" runat="server" CssClass="textbox" Width="200px" TabIndex="7"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="txt" EventName="TextChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="txtPartyName" EventName="TextChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="NormalText">
                                <asp:Label ID="Label53" runat="server" Text="Address 2"></asp:Label>
                            </td>
                            <td class="NormalText">
                                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtAdd2" runat="server" CssClass="textbox" Width="200px" TabIndex="8"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="txt" EventName="TextChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="txtPartyName" EventName="TextChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td class="NormalText">
                                <asp:Label ID="Label55" runat="server" Text="Address 3"></asp:Label>
                            </td>
                            <td class="NormalText">
                                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtAdd3" runat="server" CssClass="textbox" Width="200px" TabIndex="9"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="txt" EventName="TextChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="txtPartyName" EventName="TextChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="NormalText">
                                <asp:Label ID="Label37" runat="server" Text="City"></asp:Label>
                            </td>
                            <td class="NormalText">
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtCity1" runat="server" CssClass="textbox" Width="200px" TabIndex="10"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="txt" EventName="TextChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="txtPartyName" EventName="TextChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td class="NormalText">
                                <asp:Label ID="Label40" runat="server" Text="Zip Code"></asp:Label>
                            </td>
                            <td class="NormalText">
                                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtZipCode" runat="server" CssClass="textbox" TabIndex="11" Columns="11"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="txt" EventName="TextChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="txtPartyName" EventName="TextChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="NormalText">
                                <asp:Label ID="Label38" runat="server" Text="State"></asp:Label>
                            </td>
                            <td class="NormalText">
                                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtState1" runat="server" CssClass="textbox" TabIndex="12" Columns="25"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="txt" EventName="TextChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="txtPartyName" EventName="TextChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td class="NormalText">
                                <asp:Label ID="Label39" runat="server" Text="Country"></asp:Label>
                            </td>
                            <td class="NormalText">
                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtCountry1" runat="server" CssClass="textbox" TabIndex="13" Columns="20"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="txt" EventName="TextChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="txtPartyName" EventName="TextChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="NormalText">
                                <asp:Label ID="Label58" runat="server" Text="Phone No"></asp:Label>
                            </td>
                            <td class="NormalText">
                                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtPhoneNo" runat="server" Columns="25" CssClass="textbox" 
                                            TabIndex="12"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="GridView2" 
                                            EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="txt" EventName="TextChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="txtPartyName" EventName="TextChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td class="NormalText">
                                &nbsp;</td>
                            <td class="NormalText">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="NormalText">
                             <asp:Label ID="Label18" runat="server" Text="Destination City"></asp:Label>
                            </td>
                            <td class="NormalText">
                             <asp:TextBox ID="txtDestination" runat="server" CssClass="textbox" TabIndex="12" Columns="25"></asp:TextBox>
                            </td>
                            <td class="NormalText">
                            </td>
                            <td class="NormalText">
                            </td>
                        </tr>
                        <tr>
                            
                            <td class="NormalText" colspan="4">
                                <asp:Panel ID="Panel8" runat="server">
                                    <%--<asp:UpdatePanel ID="UpdatePanelGrd" runat="server" >
                                        <ContentTemplate>--%>
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td style="width: 185px">
                                                        <asp:Label ID="Label64" runat="server" Text="No. of Invoices"></asp:Label>
                                                    </td>
                                                    <td colspan="3">
                                                        <%--<asp:UpdatePanel ID="UpdatePanelList" runat="server">
                                             <ContentTemplate>--%>
                                                        <asp:DropDownList ID="ddlNo_of_inv" runat="server" CssClass="combobox" AutoPostBack="True"
                                                            OnSelectedIndexChanged="ddlNo_of_inv_SelectedIndexChanged">
                                                            <asp:ListItem>0</asp:ListItem>
                                                            <asp:ListItem>1</asp:ListItem>
                                                            <asp:ListItem>2</asp:ListItem>
                                                            <asp:ListItem>3</asp:ListItem>
                                                            <asp:ListItem>4</asp:ListItem>
                                                            <asp:ListItem>5</asp:ListItem>
                                                            <asp:ListItem>6</asp:ListItem>
                                                            <asp:ListItem>7</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <%--  </ContentTemplate>
                                                </asp:UpdatePanel>--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                        <ContentTemplate>
                                                        <asp:GridView ID="GrdInvoice" runat="server" AutoGenerateColumns="False" 
                                                            Width="100%" OnRowCommand="GrdInvoice_RowCommand" >
                                                            <AlternatingRowStyle CssClass="GridAI" />
                                                            <Columns>
                                                                <asp:BoundField HeaderText="SrNo" DataField="srno" />
                                                                <asp:TemplateField HeaderText="InvoiceNo">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtInvoiceNo" runat="server" CssClass="textbox" ></asp:TextBox>
                                                                        <asp:ImageButton ID="imgRefresh" runat="server" ImageUrl="~/Image/refresh-icon.gif"
                                                                            CommandName="fetch" CausesValidation="False" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="BundleNo">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblBundleNo" runat="server"></asp:Label>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                            ControlToValidate="txtBaleNo" Display="Dynamic" ErrorMessage="Please click fetch button." 
                                                                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                        <asp:TextBox ID="txtBaleNo" runat="server" BorderStyle="None" Enabled="false" 
                                                                            Width="452px" ></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                Not Data Found... ! ! !
                                                            </EmptyDataTemplate>
                                                            <HeaderStyle CssClass="GridHeader" />
                                                            <RowStyle CssClass="GridItem" />
                                                        </asp:GridView>
                                                        </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 185px">
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
                                     <%--   </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="rblSelect" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="rblSelect" 
                                                EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>--%>
                                </asp:Panel>
                           
                            </td>
                        </tr>
                        <tr>
                            <td class="NormalText">
                                &nbsp;</td>
                            <td class="NormalText">
                                &nbsp;</td>
                            <td class="NormalText">
                                &nbsp;</td>
                            <td class="NormalText">
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>

    <table style="width: 100%">
        <tr>
            <td class="tableheader" style="color: #008080">
                <asp:Image ID="ImageAdditionalDetails" runat="server" ImageUrl="~/Image/plus.png" Style="margin-right: 5px;" />
                Additional Details

                     <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender3" runat="Server" AutoCollapse="False" AutoExpand="True"
                                    CollapseControlID="ImageAdditionalDetails" Collapsed="False" CollapsedImage="~/Image/plus.png"
                                    CollapsedSize="0" ExpandControlID="ImageAdditionalDetails" ExpandDirection="Vertical" ExpandedImage="~/Image/minus.png"
                                    ImageControlID="ImageAdditionalDetails" ScrollContents="false" TargetControlID="Panel6" />

            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Panel ID="Panel6" Width="100%" runat="server" BorderStyle="Solid" BorderWidth="1px">
                    <table style="width: 100%;" class="tableback" >
                        <tr>
                            <td class="NormalText" style="width: 117px">
                                <asp:Label ID="Label25" runat="server" Text="Subject (If any..)"></asp:Label>
                            </td>
                            <td class="NormalText" style="width: 216px" colspan="3">
                                <asp:TextBox ID="txtSubject" runat="server" CssClass="textbox" Width="200px" TabIndex="4"   MaxLength="100"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="NormalText" style="width: 117px">
                                <asp:Label ID="Label56" runat="server" Text="Party Account No."></asp:Label>
                            </td>
                            <td class="NormalText" style="width: 216px" colspan="3">
                                <asp:TextBox ID="txtAccountNo" runat="server" CssClass="textbox" TabIndex="4" 
                                    Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="NormalText" style="width: 117px">
                                <asp:Label ID="Label57" runat="server" Text="Booking No."></asp:Label>
                            </td>
                            <td class="NormalText" colspan="3" style="width: 216px">
                                <asp:TextBox ID="txtBookingNo" runat="server" CssClass="textbox" TabIndex="4" 
                                    Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                      <!--  <tr>
                            <td class="NormalText" style="width: 117px; vertical-align: top;">
                                <asp:Label ID="Label29" runat="server" Text="Attach File"></asp:Label>
                            </td>
                            <td class="NormalText" style="width: 215px">

                              
                              
                                  <asp:FileUpload ID="UploadFile" runat="server" TabIndex="14" />
                                 
                                <asp:CheckBoxList ID="chkAttachedFiles" runat="server" AutoPostBack="True" 
                                    OnSelectedIndexChanged="chkAttachedFiles_SelectedIndexChanged">
                                </asp:CheckBoxList>

                            </td>
                            <td class="NormalText" colspan="2">
                               
                                  <asp:LinkButton ID="lnkAttach" runat="server" OnClick="lnkAttach_Click" 
                                    TabIndex="9">Attach</asp:LinkButton>
                               
                            </td>
                        </tr> -->

                          <tr>
                            <td class="NormalText" style="width: 117px; vertical-align: top;">
                                <asp:Label ID="Label62" runat="server" Text="Attach File"></asp:Label>
                            </td>
                            <td class="NormalText" colspan="3">
                                   <span style ="font-family:Arial">Click to add files</span>&nbsp;&nbsp;
        <input id="Button2" type="button" value="add" onclick = "AddFileUpload()" />
                                     <div id = "FileUploadContainer">
            <!--FileUpload Controls will be added here -->
        </div>
                                </td>
                        </tr>
                         

                        <tr>
                            <td class="NormalText" valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Remarks"></asp:Label>
                            </td>
                            <td class="NormalText" style="width: 215px">
                                <asp:TextBox ID="txtOtherRequest" runat="server" CssClass="textbox" TextMode="MultiLine"
                                    Height="50px" Width="300px" ToolTip="Fill this area only in case the Letter to be issued is printed and cannot be attched to this system."
                                    TabIndex="15"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 117px">
                              
                            </td>
                            <td class="NormalText" style="width: 215px">
                                &nbsp;
                            </td>
                            <td class="NormalText" style="width: 113px">
                                &nbsp;
                            </td>
                            <td class="NormalText">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>

        <table style="width: 100%">
        <tr>
            <td class="tableheader" style="color: #008080">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/plus.png" Style="margin-right: 5px;" />
                <asp:Label ID="Label63" runat="server" Text="Send CC " 
                    ToolTip="Enter the details of the person to whom the copy of letter or any document is to be send within JCT only.Files attached above will be mailed."></asp:Label>
                       <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="Server" AutoCollapse="False" AutoExpand="True"
                                    CollapseControlID="Image1" Collapsed="False" CollapsedImage="~/Image/plus.png"
                                    CollapsedSize="0" ExpandControlID="Image1" ExpandDirection="Vertical" ExpandedImage="~/Image/minus.png"
                                    ImageControlID="Image1" ScrollContents="false" TargetControlID="Panel7" />
                     </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Panel ID="Panel7" Width="100%" runat="server" BorderStyle="Solid" BorderWidth="1px">
                    <table style="width: 100%;" class="tableback" >
                        <tr>
                            <td class="NormalText" style="width: 117px">
                                <asp:Label ID="Label59" runat="server" Text="To"></asp:Label>
                            </td>
                            <td class="NormalText" style="width: 216px" colspan="3">
                                      
                                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtTo" runat="server" AutoPostBack="True" CssClass="textbox" 
                                            ontextchanged="txtTo_TextChanged" Width="200px"
                                              ToolTip="Enter Email of the person to whom you want to send the copy of these documents."></asp:TextBox>
                                            <div id="div1" style="display:none;">  
                                            
                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" 
                                            CompletionInterval="10" CompletionListCssClass="AutoExtender" 
                                            CompletionListElementID="div1" 
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" 
                                            MinimumPrefixLength="1" ServiceMethod="Email_IDs" 
                                            ServicePath="~/WebService.asmx" TargetControlID="txtTo">
                                        </cc1:AutoCompleteExtender>
                                        </div>
                                           <asp:CheckBoxList ID="chkEmailIDTo" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="chkEmailIDTo_SelectedIndexChanged">
                                        </asp:CheckBoxList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtTo" EventName="TextChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="NormalText" style="width: 117px">
                                <asp:Label ID="Label60" runat="server" Text="CC"></asp:Label>
                            </td>
                            <td class="NormalText" style="width: 216px" colspan="3">
                                
                                <asp:UpdatePanel ID="UpdatePanel20" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtCC" runat="server" AutoPostBack="True" CssClass="textbox" 
                                            ontextchanged="txtCC_TextChanged" Width="200px"></asp:TextBox>
                                            <div id="div2" style="display:none;">   
                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" 
                                            CompletionInterval="10" CompletionListCssClass="AutoExtender" 
                                            CompletionListElementID="div2" 
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" 
                                            MinimumPrefixLength="1" ServiceMethod="Email_IDs" 
                                            ServicePath="~/WebService.asmx" TargetControlID="txtCC">
                                        </cc1:AutoCompleteExtender>  </div>
                                        <br />
                                        <asp:CheckBoxList ID="chkEmailID" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="chkEmailID_SelectedIndexChanged">
                                        </asp:CheckBoxList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtCC" EventName="TextChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="NormalText" style="width: 117px; vertical-align: top;">
                                <asp:Label ID="Label61" runat="server" Text="Remarks"></asp:Label>
                            </td>
                            <td class="NormalText" style="width: 215px">

                              
                              
                                  <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>

                            </td>
                            <td class="NormalText" colspan="2">
                               
                               
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 117px">
                              
                            </td>
                            <td class="NormalText" style="width: 215px">
                                &nbsp;
                            </td>
                            <td class="NormalText" style="width: 113px">
                                &nbsp;
                            </td>
                            <td class="NormalText">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>


    <table style="width: 100%;">
        <tr>
            <td class="buttonbackbar" colspan="2">
                <asp:LinkButton ID="lnkSubmit" runat="server" CssClass="buttonc" OnClick="lnkSubmit_Click"
                    TabIndex="16">Submit</asp:LinkButton>
                <asp:LinkButton ID="lnkSubmit0" runat="server" CssClass="buttonc" OnClick="lnkSubmit0_Click"
                    TabIndex="17" ValidationGroup="x">Reset</asp:LinkButton>
                <asp:LinkButton ID="lnkSearchParty" runat="server" CssClass="buttonc" TabIndex="18">Search</asp:LinkButton>
                <asp:LinkButton ID="lnkDelete" runat="server" CssClass="buttonc" OnClick="lnkDelete_Click"
                    TabIndex="19">Delete</asp:LinkButton>
                <cc1:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server" ConfirmText="Are you sure ?"
                    TargetControlID="lnkDelete">
                </cc1:ConfirmButtonExtender>
                <asp:LinkButton ID="lnkShowAll" runat="server" CssClass="buttonc" TabIndex="20" OnClick="lnkShowAll_Click">Show All</asp:LinkButton>
                <asp:LinkButton ID="lnkAddParty0" runat="server" OnClick="lnkAddParty_Click" CssClass="buttonc"
                    Visible="False">Add Party</asp:LinkButton>
                <cc1:ModalPopupExtender ID="lnkAddParty0_ModalPopupExtender" runat="server" BackgroundCssClass="modalBackground"
                    PopupControlID="Panel3" TargetControlID="lnkAddParty0">
                </cc1:ModalPopupExtender>
                <cc1:ModalPopupExtender ID="lnkSearchParty_ModalPopupExtender" runat="server" TargetControlID="lnkSearchParty"
                    BackgroundCssClass="modalBackground" CancelControlID="lnkCancel" PopupControlID="pnlSearch">
                </cc1:ModalPopupExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 20%">
                &nbsp;
            </td>
            <td class="NormalText" style="width: 80%">
                <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                    FadeInDuration="2" FadeInSteps="2" FadeOutDuration="10" FadeOutSteps="2" Visible="true">
                </uc1:FlashMessage>
            </td>
        </tr>
    </table>

    <table style="width: 100%;">
        <tr>
            <td class="NormalText">
                <asp:Panel ID="Panel1" runat="server" CssClass="panelbg" ScrollBars="Both" Width="100%" BorderWidth="1px" BorderStyle="Solid" >
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
                       PagerStyle-CssClass="PagerStyle" 
                        EnableModelValidation="True" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
                        OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging"
                        OnRowDataBound="GridView1_RowDataBound">
                          <RowStyle CssClass="GridItem" />
                            <AlternatingRowStyle CssClass="GridAI" />
                            <HeaderStyle CssClass="GridHeader" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                                <ItemStyle Width="10px" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="Serial_No">
                                <ItemTemplate>
                                    <a id='<%#Eval("Serial_No")%>' class="anchor1" href="javascript:void(0);" style="display: none;">
                                        <%#Eval("Serial_No")%></a>
                                    <asp:TextBox ID="txtSerialNo" runat="server" Enabled="false" Text='<%#Eval("Serial_No")%>'
                                        Visible="false"></asp:TextBox>
                                    <asp:Label ID="lblSerial" runat="server" Text='<%# Eval("Serial_No") %>'></asp:Label>
                                    <cc1:HoverMenuExtender ID="lblSerial_HoverMenuExtender" runat="server" OffsetX="0"
                                        OffsetY="0" PopDelay="10" PopupControlID="pnlToolTip" PopupPosition="Right" TargetControlID="lblSerial">
                                    </cc1:HoverMenuExtender>
                                    <div id="disp" class="large" style="position: absolute; background-color: #FFF; z-index: 20000;">
                                    </div>
                                    <br />
                                    <asp:Panel ID="pnlToolTip" runat="server" BorderColor="Black" BorderWidth="1px" BorderStyle="Solid"
                                       CssClass="panelbg" Width="30%">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td class="NormalText" style="width: 36%">
                                                    <asp:Label ID="Label10" runat="server" Text="Serial_No"></asp:Label>
                                                </td>
                                                <td class="NormalText" style="width: 90%">
                                                    <asp:Label ID="lblSerialNo" runat="server" Text='<%# Eval("Serial_No") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 36%">
                                                    <asp:Label ID="Label14" runat="server" Text="Subject"></asp:Label>
                                                </td>
                                                <td class="NormalText" style="width: 90%">
                                                    <asp:Label ID="Label41" runat="server" Text='<%# Eval("Subject") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 36%">
                                                    <asp:Label ID="Label15" runat="server" Text="Party Name"></asp:Label>
                                                </td>
                                                <td class="NormalText" style="width: 90%">
                                                    <asp:Label ID="Label26" runat="server" Text='<%# Eval("Party_Name") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 36%">
                                                    <asp:Label ID="Label16" runat="server" Text="Address"></asp:Label>
                                                </td>
                                                <td class="NormalText" style="width: 90%">
                                                    <asp:Label ID="Label27" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 36%">
                                                    <asp:Label ID="Label17" runat="server" Text="Attached File"></asp:Label>
                                                </td>
                                                <td class="NormalText" style="width: 90%">
                                                    <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" 
                                                        style="margin-top: 0px" onitemcommand="DataList1_ItemCommand">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkFile" runat="server" 
                                                                CommandArgument='<%# Eval("File") %>' CommandName="Download" 
                                                                Text='<%# Eval("File") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 36%">
                                                    <asp:Label ID="Label23" runat="server" Text="Request By"></asp:Label>
                                                </td>
                                                <td class="NormalText" style="width: 90%">
                                                    <asp:Label ID="Label43" runat="server" Text='<%# Eval("Request_By") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 36%">
                                                    <asp:Label ID="Label24" runat="server" Text="Courier Service"></asp:Label>
                                                </td>
                                                <td class="NormalText" style="width: 90%">
                                                    <asp:Label ID="Label44" runat="server" Text='<%# Eval("Courier_Service") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="NormalText" style="width: 36%">
                                                    <asp:Label ID="Label45" runat="server" Text="Tracking ID"></asp:Label>
                                                </td>
                                                <td class="NormalText" style="width: 90%">
                                                    <asp:LinkButton ID="lnkTrackingID" runat="server" CommandArgument='<%# Eval("Website") %>'
                                                        CommandName="TrackingID" Text='<%# Eval("TrackingID") %>' OnCommand="lnkTrackingID_Command"></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ItemTemplate>
                                <ItemStyle Width="10px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subject">
                                <ItemTemplate>
                                    <asp:Label ID="lblSubject" runat="server" Text='<%# Eval("Subject") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="20px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Party Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblPartyName" runat="server" Text='<%# Eval("Party_Name") %>'></asp:Label>
                                </ItemTemplate>
                                  <ItemStyle Width="250px"  Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Item Send ">
                                <ItemTemplate>
                                    <asp:Label ID="lblItem" runat="server" Text='<%# Eval("Courier_Type") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="10px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Send To">
                                <ItemTemplate>
                                    <asp:Label ID="lblSendType" runat="server" Text='<%# Eval("SendType") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="20px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="3px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Request Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblRequestedDate" runat="server" Text='<%# Eval("Request_Date") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="5px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Request By">
                                <ItemTemplate>
                                    <asp:Label ID="lblRequestBy" runat="server" Text='<%# Eval("Request_By") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="gridHeader" />
                        <PagerStyle CssClass="PagerStyle" />
                        <RowStyle CssClass="GridItem" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
    </table>

    <asp:Panel ID="pnlSearch" runat="server" CssClass="panelbg" stye="display:none;">
        <table style="width: 60%;">
            <tr>
                <td class="tableheader" colspan="3">
                    <asp:Label ID="Label32" runat="server" Text="Search Party"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="NormalText" style="width: 89px">
                    <asp:Label ID="Label31" runat="server" Text="Party Name"></asp:Label>
                </td>
                <td class="NormalText">
                    <asp:TextBox ID="txtPartNameSearch" runat="server" CssClass="textbox" Width="400px"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="10"
                        FirstRowSelected="True" MinimumPrefixLength="0" ServiceMethod="CustomerAddress_CourierSystem"
                        ServicePath="~/WebService.asmx" TargetControlID="txtPartNameSearch">
                    </cc1:AutoCompleteExtender>
                </td>
                <td class="NormalText">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="NormalText" style="width: 89px">
                    &nbsp;
                </td>
                <td class="NormalText">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:LinkButton ID="lnkSearch" runat="server" CausesValidation="false" CssClass="buttonc"
                                OnClick="lnkSearch_Click">Search</asp:LinkButton>
                            <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="false" CssClass="buttonc"
                                OnClick="lnkCancel_Click">Cancel</asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="NormalText">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="NormalText" style="width: 89px">
                    &nbsp;
                </td>
                <td class="NormalText">
                    <asp:UpdatePanel ID="UPD1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="GridView2" runat="server" CssClass="GridViewStyle" EnableModelValidation="True"
                                OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                                <HeaderStyle CssClass="HeaderStyle" />
                                <RowStyle CssClass="RowStyle" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="lnkSearch" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="lnkCancel" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td class="NormalText">
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="Panel2" CssClass="panelbg" runat="server" Width="40%" stye="display:none;">
        <table style="width: 100%;">
            <tr class="NormalText">
                <td class="tableheader" colspan="3">
                    <asp:Label ID="Label2" runat="server" Text="Add New Courier Type"></asp:Label>
                </td>
            </tr>
            <tr class="NormalText">
                <td class="BoundColumn_long" style="width: 107px">
                    <asp:Label ID="Label46" runat="server" Text="Effective From"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEffecFrom" runat="server" CssClass="textbox"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtEffecFrom_CalendarExtender" runat="server" TargetControlID="txtEffecFrom">
                    </cc1:CalendarExtender>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr class="NormalText">
                <td class="BoundColumn_long" style="width: 107px">
                    <asp:Label ID="Label47" runat="server" Text="Effective To"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEffecTo" runat="server" CssClass="textbox"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtEffecTo_CalendarExtender" runat="server" TargetControlID="txtEffecTo">
                    </cc1:CalendarExtender>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr class="NormalText">
                <td class="BoundColumn_long" style="width: 107px">
                    <asp:Label ID="Label3" runat="server" Text="Courier Type"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCourierType" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr class="NormalText">
                <td class="BoundColumn_long" style="width: 107px">
                    <asp:Label ID="Label4" runat="server" Text="Description"></asp:Label>
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtTypeDescription" runat="server" Height="40px"
                        TextMode="MultiLine" Width="200px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr class="buttonbackbar">
                <td colspan="3">
                    <asp:LinkButton ID="lnkAddCourierType" runat="server" CssClass="buttonc" OnClick="lnkAddCourierType_Click">Add</asp:LinkButton>
                    <asp:LinkButton ID="lnkCancelCourierType" runat="server" CssClass="buttonc">Cancel</asp:LinkButton>
                </td>
            </tr>
            <tr class="NormalText">
                <td style="width: 107px" colspan="3">
                    <uc1:FlashMessage ID="FMsg1" runat="server" EnableTheming="true" EnableViewState="true"
                        FadeInDuration="2" FadeInSteps="2" FadeOutDuration="10" FadeOutSteps="2" Visible="true">
                    </uc1:FlashMessage>
                </td>
            </tr>
            <tr class="NormalText">
                <td style="width: 107px">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr class="NormalText">
                <td style="width: 107px">
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
    </asp:Panel>

    <asp:Panel ID="Panel3" runat="server" Width="60%" Height="15%" Style="display: none;"
        CssClass="panelbg">
        <table style="width: 100%;">
            <tr class="tableheader">
                <asp:Label ID="Label5" runat="server" Text="Add New Party"></asp:Label>
            </tr>
            <tr class="NormalText">
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Party Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPartyNameNew" runat="server" CssClass="textbox" MaxLength="18"></asp:TextBox>
                </td>
            </tr>
            <tr class="NormalText">
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Address1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress1" runat="server" CssClass="textbox" Width="80%" MaxLength="40"></asp:TextBox>
                </td>
            </tr>
            <tr class="NormalText">
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Address2"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress2" runat="server" CssClass="textbox" Width="80%" MaxLength="40"></asp:TextBox>
                </td>
            </tr>
            <tr class="NormalText">
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Address3"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress3" runat="server" CssClass="textbox" Width="80%" MaxLength="40"></asp:TextBox>
                </td>
            </tr>
            <tr class="NormalText">
                <td>
                    <asp:Label ID="Label11" runat="server" Text="City"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server" CssClass="textbox" MaxLength="30"></asp:TextBox>
                </td>
            </tr>
            <tr class="NormalText">
                <td>
                    <asp:Label ID="Label12" runat="server" Text="State"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtState" runat="server" CssClass="textbox" MaxLength="30"></asp:TextBox>
                </td>
            </tr>
            <tr class="NormalText">
                <td>
                    <asp:Label ID="Label13" runat="server" Text="Country"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCountry" runat="server" CssClass="textbox" MaxLength="30"></asp:TextBox>
                </td>
            </tr>
            <tr class="buttonbackbar">
                <td colspan="2">
                    <asp:LinkButton ID="lnkAddNewParty" CssClass="buttonc" runat="server" OnClick="lnkAddNewParty_Click"
                        CausesValidation="False">Add</asp:LinkButton>
                    <asp:LinkButton ID="lnkCancelNewParty" CssClass="buttonc" runat="server" CausesValidation="False">Cancel</asp:LinkButton>
                </td>
            </tr>
            <tr class="NormalText">
                <td colspan="2">
                    <uc1:FlashMessage ID="FMsg2" runat="server" EnableTheming="true" EnableViewState="true"
                        FadeInDuration="2" FadeInSteps="2" FadeOutDuration="10" FadeOutSteps="2" Visible="true">
                    </uc1:FlashMessage>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pnlSaleOffice" CssClass="panelbg" runat="server" Style="display: none;">
                <asp:RadioButtonList CssClass="combobox" ID="rblSaleOffices" runat="server" RepeatDirection="Vertical"
                    AutoPostBack="True" OnSelectedIndexChanged="rblSaleOffices_SelectedIndexChanged">
                </asp:RadioButtonList>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="rblSelect" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:HiddenField ID="hd1" runat="server" />
    <asp:HiddenField ID="hdDept" runat="server" />
    <asp:HiddenField ID="hd2" runat="server" />
    <asp:HiddenField ID="hd3" runat="server" />
    <asp:HiddenField ID="hd4" runat="server" />
    <asp:HiddenField ID="hd5" runat="server" />
    <asp:HiddenField ID="hdSerialNo" runat="server" />
    <asp:HiddenField ID="hd6" runat="server" />
</asp:Content>
