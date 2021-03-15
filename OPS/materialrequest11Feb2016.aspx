<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="materialrequest.aspx.vb" Inherits="OPS_materialrequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
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
  <%--  27 Jan 2016--%>
    <script>
        function NumberOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127 || AsciiValue == 46 ))
                event.returnValue = true;
            else
                event.returnValue = false;
        }
       
        </script>
         <%--  27 Jan 2016--%>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">

            function PopUp() {

                var id = document.getElementById('<%=txtSanctionID.ClientID %>').value;

                window.radopen("MaterialReturnPopUp.aspx?RequestID=" + id, "UserListDialog");
                return false;
            }

            function refreshGrid(arg) {
                if (!arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
                }
            }
             

        </script>
        <style type="text/css">
            upper
            {
                text-transform: uppercase;
            }
        </style>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblContent" LoadingPanelID="gridLoadingPanel">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lblContent">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblContent" LoadingPanelID="gridLoadingPanel">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel runat="server" ID="gridLoadingPanel">
    </telerik:RadAjaxLoadingPanel>
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="5">
                <asp:Label ID="Label1" runat="server" Text="Sales - Material Return"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText"  colspan="4">
               ** Sale Return For goods lying inhouse<br />** Material Return for goods returned by Customer</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 117px">
                Material Request Type
            </td>
            <td class="NormalText" style="width: 230px">
                <asp:DropDownList ID="ddlRequestType" runat="server" CssClass="combobox" AutoPostBack="True">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Material Return</asp:ListItem>
                    <asp:ListItem>Sale Return</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="ddlRequestType" Display="Dynamic" ErrorMessage="*" 
                    SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 141px">
                Action To Be Taken
            </td>
            <td style="margin-left: 80px" class="NormalText">
                <asp:DropDownList ID="ddlActionToBeTaken" runat="server" CssClass="combobox">
 <%--                   <asp:ListItem>ReProcessing In Same Order</asp:ListItem>
                    <asp:ListItem>ReProcessing In Other Order</asp:ListItem>
                    <asp:ListItem>RePacking</asp:ListItem>
                    <asp:ListItem>ReGrade</asp:ListItem>--%>
                </asp:DropDownList>
            </td>
            <td style="margin-left: 80px" class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 117px">
                &nbsp;
            </td>
            <td class="NormalText" style="width: 230px">
                &nbsp;
            </td>
            <td class="NormalText" style="width: 141px">
                &nbsp;
            </td>
            <td style="margin-left: 80px" class="NormalText">
                &nbsp;
            </td>
            <td style="margin-left: 80px" class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 117px">
                Target Category
            </td>
            <td class="NormalText" style="width: 230px">
                <asp:DropDownList ID="ddlSalesPerson2" runat="server" CssClass="combobox">
                    <asp:ListItem>FR</asp:ListItem>
                    <asp:ListItem>ST</asp:ListItem>
                     <asp:ListItem>NA</asp:ListItem>
                </asp:DropDownList>
            </td>
             <%--  27 Jan 2016--%>
            <td class="NormalText" style="width: 141px">
               Tentative Sale Price
            </td>
            <td style="margin-left: 80px" class="NormalText">
               <asp:TextBox ID="txtTentative" runat="server" Text="" onkeypress="return NumberOnly()">
               </asp:TextBox>
            </td>
             <%--  27 Jan 2016--%>
            <td style="margin-left: 80px" class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 117px">
                &nbsp;
            </td>
            <td class="NormalText" style="width: 230px">
                &nbsp;
            </td>
            <td class="NormalText" style="width: 141px">
                &nbsp;
            </td>
            <td style="margin-left: 80px" class="NormalText">
                &nbsp;
            </td>
            <td style="margin-left: 80px" class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 117px">
                Customer
            </td>
            <td class="NormalText" style="width: 230px">
                <div id="divwidth" style="display: none;">
                </div>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtCustomer" runat="server" AutoPostBack="True" CssClass="upper"
                            MaxLength="40" ToolTip="Please give Customer Code or Select Customer from the List"
                            Width="200px"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="txtCustomer_AutoCompleteExtender" runat="server" CompletionInterval="10"
                            CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" MinimumPrefixLength="1"
                            ServiceMethod="OPS_Customer" ServicePath="~/WebService.asmx" TargetControlID="txtCustomer">
                        </cc1:AutoCompleteExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 141px">
                Sale Person
            </td>
            <td style="margin-left: 80px" class="NormalText">
                <asp:DropDownList ID="ddlSalesPerson" runat="server" CssClass="combobox">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlSalesPerson"
                    Display="Dynamic" ErrorMessage="** Filed Required" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td style="margin-left: 80px" class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 117px">
                <asp:Label ID="Label16" runat="server" Text="Enclosures"></asp:Label>
            </td>
            <td class="NormalText" style="width: 230px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:CheckBoxList ID="chbEnclosures" runat="server" AutoPostBack="True">
                            <asp:ListItem>Packing List</asp:ListItem>
                            <asp:ListItem>Customer Challan</asp:ListItem>
                            <asp:ListItem>GR/LR</asp:ListItem>
                            <asp:ListItem>JCT Invoice</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:CheckBoxList>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:TextBox ID="txtEnclosures" runat="server" CssClass="textbox" Visible="False"
                                    Width="200px"></asp:TextBox>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="chbEnclosures" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 141px">
                Instructions
            </td>
            <td style="margin-left: 80px" class="NormalText">
                <asp:TextBox ID="txtinstructions" runat="server" CssClass="textbox" TextMode="MultiLine"
                    Height="40px" Width="200px"></asp:TextBox>
            </td>
            <td style="margin-left: 80px" class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 117px">
                Description
            </td>
            <td class="NormalText" style="width: 230px">
                <asp:TextBox ID="txtDescription" runat="server" CssClass="textbox" TextMode="MultiLine"
                    Height="40px" Width="200px" ValidationGroup="A" ToolTip="Include all details like bale No etc"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescription"
                    Display="Dynamic" ErrorMessage="**" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:Label ID="Label18" runat="server" Text="Previous Request ID(Import)"></asp:Label>
            </td>
            <td style="margin-left: 80px" class="NormalText">
                <asp:TextBox ID="txtSanctionID" runat="server" AutoPostBack="True" CssClass="textbox"
                    MaxLength="40" ToolTip="Enter Sanction ID "></asp:TextBox>
                <asp:LinkButton ID="lnkDetail" runat="server" OnClientClick="return PopUp()">Detail</asp:LinkButton>
                <asp:Image ID="img" runat="server" Visible="False" />
                (Optional)
            </td>
            <td style="margin-left: 80px" class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 117px">
                Select Plant
            </td>
            <td class="NormalText" style="width: 230px">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPlant" runat="server" AutoPostBack="True" CssClass="combobox">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>COTTON</asp:ListItem>
                            <asp:ListItem>TAFFETA</asp:ListItem>
                            <asp:ListItem>JCTHOMES</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlPlant"
                            Display="Dynamic" ErrorMessage="***" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:Label ID="Label17" runat="server" Text="Invoice No" Visible="False"></asp:Label>
            </td>
            <td style="margin-left: 80px" class="NormalText">
                <asp:TextBox ID="txtInvoiceNo" runat="server" CssClass="textbox" ToolTip="Enter invoice no."
                    MaxLength="40" Visible="False"></asp:TextBox>
            </td>
            <td style="margin-left: 80px" class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 117px">
                Freight Value Type
            </td>
            <td class="NormalText" colspan="1">
                <asp:UpdatePanel ID="UpdFreightType" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList runat="server" ID="ddlFreightAppliedTo" CssClass="combobox" AutoPostBack="True">
                            <asp:ListItem>Combined Value</asp:ListItem>
                            <asp:ListItem>Individual Val(Per Invoice)</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="margin-left: 80px" class="NormalText">
                &nbsp;
            </td>
            <td style="margin-left: 80px" class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <%--<asp:CheckBoxList ID="chbReasons" runat="server" CssClass="combobox" 
                        DataSourceID="SqlDataSource1" DataTextField="REASON" DataValueField="REASON" 
                        RepeatColumns="2" AutoPostBack="True">
                    </asp:CheckBoxList>--%>
            <td style="margin-left: 80px" class="NormalText">
                Freight Paid By
            </td>
            <td style="margin-left: 80px" class="NormalText" colspan="3">
              <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                <asp:DropDownList ID="ddlFreight" runat="server" CssClass="combobox">
                    <asp:ListItem>By Mill </asp:ListItem>
                    <asp:ListItem>By Customer </asp:ListItem>
                    <asp:ListItem>By Transporter</asp:ListItem>
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <%--<asp:CheckBoxList ID="chbReasons" runat="server" CssClass="combobox" 
                        DataSourceID="SqlDataSource1" DataTextField="REASON" DataValueField="REASON" 
                        RepeatColumns="2" AutoPostBack="True">
                    </asp:CheckBoxList>--%>
        </tr>
        <tr>
            <td class="NormalText" style="width: 117px">
                <asp:Label ID="Label2" runat="server">Transport Details</asp:Label>
            </td>
            <td class="NormalText" colspan="1">
                <asp:TextBox ID="txtTransport" runat="server" CssClass="textbox" ToolTip="Transport Details"
                    MaxLength="140"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtTransport"
                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td style="margin-left: 80px" class="NormalText">
                Freight Type
            </td>
            <td style="margin-left: 80px" class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlFreightType" runat="server" CssClass="combobox">
                            <asp:ListItem>Return Only</asp:ListItem>
                            <asp:ListItem>To & Fro</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 117px">
                <asp:Label ID="Label19" runat="server" Text="Invoice Date From" Visible="False"></asp:Label>
            </td>
            <td style="width: 230px">
                <asp:TextBox ID="txtEff_From" runat="server" CssClass="textbox" MaxLength="15" TabIndex="28"
                    ValidationGroup="ValidGrpSaveDetail" Width="65px" Visible="False"></asp:TextBox>
                <cc1:CalendarExtender ID="CalEfffr" runat="server" Animated="False" Format="MM/dd/yyyy"
                    TargetControlID="txtEff_From">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:Label ID="Label20" runat="server" Text="Invoice Date To" Visible="False"></asp:Label>
                &nbsp;
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtEff_To" runat="server" CssClass="textbox" MaxLength="15" TabIndex="29"
                    ValidationGroup="ValidGrpSaveDetail" Width="65px" Visible="False"></asp:TextBox>
                <cc1:CalendarExtender ID="CalEffTo" runat="server" Animated="False" Format="MM/dd/yyyy"
                    TargetControlID="txtEff_To">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td class="NormalText" style="color: #008080">
                        <asp:Image ID="ImageReasons" runat="server" ImageUrl="~/Image/plus.png" Style="margin-right: 5px;" />
                        Select appropriate reasons
                        <cc1:CollapsiblePanelExtender ID="cpe" runat="Server" AutoCollapse="False" AutoExpand="True"
                            CollapseControlID="ImageReasons" Collapsed="False" CollapsedImage="~/Image/plus.png"
                            CollapsedSize="0" ExpandControlID="ImageReasons" ExpandDirection="Vertical" ExpandedImage="~/Image/minus.png"
                            ImageControlID="ImageReasons" ScrollContents="false" TargetControlID="pnlReasons" />
                    </td>
                </tr>
                <tr>
                    <td class="NormalText">
                        <asp:Panel ID="pnlReasons" runat="server" Height="200px" ScrollBars="Vertical">
                            <%--<asp:CheckBoxList ID="chbReasons" runat="server" CssClass="combobox" 
                        DataSourceID="SqlDataSource1" DataTextField="REASON" DataValueField="REASON" 
                        RepeatColumns="2" AutoPostBack="True">
                    </asp:CheckBoxList>--%>
                            <asp:RadioButtonList ID="chbReasons" runat="server" CssClass="combobox" DataSourceID="SqlDataSource1"
                                DataTextField="REASON" DataValueField="REASON" RepeatColumns="2" AutoPostBack="True">
                            </asp:RadioButtonList>
                            <asp:TextBox ID="txtOtherReason" runat="server" CssClass="textbox" Visible="False"
                                Width="200px"></asp:TextBox>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                                SelectCommand="SELECT distinct REASON FROM JCT_OPS_SANCTION_NOTE_MATERIAL_RETURN_REASONS WHERE STATUS='A'  and Plant = @Plant ">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlPlant" DefaultValue="Cotton" Name="Plant" PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlPlant" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <table style="width: 100%;">
        <tr>
            <td valign="top">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="labelcells">Insert invoice No and details</asp:LinkButton>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtSanctionID" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table style="width: 100%;" class="tableback">
                    <tr>
                        <td valign="top">
                            <asp:Label ID="Label22" runat="server" Font-Size="Small" Text="Authorizing Hierarchy"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            Add Level
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table style="width: 100%;">
                                <tr>
                                    <td colspan="3" valign="top">
                                        <asp:UpdatePanel ID="UpdatePanel11" runat="server" RenderMode="Inline">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                                                <asp:LinkButton ID="cmdSearch" runat="server" CssClass="searchbluesmall" Height="16px"
                                                    Width="16px"></asp:LinkButton>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="50%">
                                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                            <ContentTemplate>
                                                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Both" Width="450px">
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
                                        <%--<asp:TextBox ID="txtFreightValue" runat="server" CssClass="textbox" 
                    ToolTip="Total Freight Value" 
                    MaxLength="40"></asp:TextBox>--%>
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
                        </td>
                    </tr>
                </table>
            </td>
        </tr>




        <tr>
            <td valign="top">
                <span style="font-family: Arial">Click to add files</span>&nbsp;&nbsp;
                <input id="Button2" onclick="AddFileUpload()" type="button" value="add" />
                <div id="FileUploadContainer">
            </td>
        </tr>


        <tr>
            <td valign="top">
                 &nbsp;
            </td>
        </tr>

        <tr>
            <td style="text-align: center" class="buttonbackbar">
                <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc" ValidationGroup="A">Save</asp:LinkButton>
                <asp:LinkButton ID="cmdTransport" runat="server" CssClass="buttonc">Transport</asp:LinkButton>
                <asp:LinkButton ID="cmdreset" runat="server" CssClass="buttonc">Reset</asp:LinkButton>
                <asp:LinkButton ID="cmdclose" runat="server" CssClass="buttonc">Close
                </asp:LinkButton>
                <asp:LinkButton ID="cmdclose0" runat="server" CssClass="buttonc" 
                    ValidationGroup="A">Close          </asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" class="NormalText">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="NormalText" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="pnlGridview2" runat="server" CssClass="panelbg" ScrollBars="Auto"
                            Width="100%">
                            <asp:GridView ID="GridView2" runat="server" EnableModelValidation="True" Width="100%"
                                AutoGenerateColumns="False">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Remove" ImageUrl="~/Image/Icons/close.png" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Invoice No ">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtInvocieNo" CssClass="textbox" runat="server" Text='<%# Eval("InvoiceNo") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtInvocieNo"
                                                Display="Dynamic" ErrorMessage="**" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            <asp:ImageButton ID="imgRefresh" runat="server" ImageUrl="~/Image/refresh-icon.gif"
                                                CommandName="Refresh" CausesValidation="False" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Freight Paid">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlFreight" CssClass="combobox" runat="server">
                                                <asp:ListItem>By Customer</asp:ListItem>
                                                <asp:ListItem Selected="True">By Mill</asp:ListItem>
                                                <asp:ListItem>By Transporter</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Return Qty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtReturnQty" runat="server" CssClass="textbox" MaxLength="10" AutoPostBack="True"
                                                Width="65" OnTextChanged="txtReturnQty_TextChanged" Text='<%# Eval("ReturnQty") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtReturnQty"
                                                Display="Dynamic" ErrorMessage="** Required" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bales">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtbales" runat="server" CssClass="textbox" Columns="5" MaxLength="3"
                                                Text='<%# Eval("Bales") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtbales"
                                                Display="Dynamic" ErrorMessage="** Required" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQty" Text='<%# Eval("Qty") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SalePrice">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSalePrice" Text='<%# Eval("SalePrice") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ValueInvolved">
                                        <ItemTemplate>
                                            <asp:Label ID="lblValueInvolved" Text='<%# Eval("ValueInvolved") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemNo" Text='<%# Eval("ItemNo") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Invoice Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInvoiceDt" Text='<%# Eval("InvoiceDt") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Customer">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCustomer" Text='<%# Eval("Customer") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sales Person">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSalesPerson" Text='<%# Eval("SalesPerson") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GrNo">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtGrNo" runat="server" CssClass="textbox" Columns="5" MaxLength="15"
                                                Text='<%# Eval("GrNo") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorGrNo" runat="server" ControlToValidate="txtGrNo"
                                                Display="Dynamic" ErrorMessage="** Required" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GrDate(mm/dd/yyyy)">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtGrDate" runat="server" CssClass="textbox" Columns="5" MaxLength="15"
                                                Width="85" Text='<%# Eval("GrDate") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorGrDate" runat="server" ControlToValidate="txtGrDate"
                                                Display="Dynamic" ErrorMessage="** Required" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FreightValue">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFreightTypeValue" runat="server" CssClass="textbox" Columns="5"
                                                MaxLength="15" Text='<%# Eval("FreightValue") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFreightValue" runat="server"
                                                ControlToValidate="txtFreightTypeValue" Display="Dynamic" ErrorMessage="** Required"
                                                ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                            <br />
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ddlFreightAppliedTo" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="1">
            </td>
            <td>
            </td>
            <%--<asp:TextBox ID="txtFreightValue" runat="server" CssClass="textbox" 
                    ToolTip="Total Freight Value" 
                    MaxLength="40"></asp:TextBox>--%>
        </tr>
        <tr>
            <td class="NormalText" style="width: 80px; height= 100px;">
                <asp:Label ID="Label21" runat="server">Freight Value</asp:Label>
            </td>
            <td class="NormalText" colspan="1">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <%--<asp:TextBox ID="txtFreightValue" runat="server" CssClass="textbox" 
                    ToolTip="Total Freight Value" 
                    MaxLength="40"></asp:TextBox>--%>
                        <%--  <cc1:FilteredTextBoxExtender ID="txtFreightValue_FilteredTextBoxExtender" 
                            runat="server" Enabled="True" TargetControlID="txtFreightValue">
                        </cc1:FilteredTextBoxExtender>--%>
                        <telerik:RadNumericTextBox ID="txtFreightValue" runat="server" Culture="en-US" DbValueFactor="1"
                            LabelWidth="64px" MaxValue="30000" MinValue="0" Width="60px" EmptyMessage="*"
                            ValidationGroup="A">
                        </telerik:RadNumericTextBox>
                        <asp:RequiredFieldValidator ID="ReqdValidFreightValue" runat="server" ControlToValidate="txtFreightValue"
                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td >
            <asp:Label ID="Label3" runat="server">Expected Arrival Date</asp:Label>
            </td>
            <td class="NormalText" colspan="1">
               <asp:TextBox ID="txtExpectedArrDate" runat="server" CssClass="textbox" 
                    ValidationGroup="A"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtExpectedArrDate" >
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtExpectedArrDate"  ValidationGroup="A"
                    Display="Dynamic" ErrorMessage="**"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
    </table>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow ID="UserListDialog" runat="server" Title="Material Return Detail"
                Height="300px" Width="500px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false"
                Modal="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <telerik:RadNotification ID="RadNotification1" runat="server" VisibleOnPageLoad="true"
        Style="z-index: 35000" Skin="Hay">
    </telerik:RadNotification>
    <asp:PlaceHolder ID="holder" runat="server"></asp:PlaceHolder>
    <asp:FileUpload ID="FileUpload1" runat="server" Height="0px" Width="0px" />
</asp:Content>
