<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPageWithoutMenu.master" AutoEventWireup="false"
    CodeFile="New_Order_Scheduling.aspx.vb" Inherits="OPS_New_Order_Scheduling" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">


        function ButtonClick() {
            document.getElementById("<%= btnPopUp.ClientID %>").click();
        }
    </script>
    <table style="width: 800px;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label1" runat="server" Text="Processing - Order Scheduling"></asp:Label>
            </td>
        </tr>
        <tr>



        <td class="labelcells">
                Customer
            </td>
            <td>
                <asp:TextBox ID="txtCustomer" runat="server" AutoPostBack="True" CssClass="textbox"
                    Width="200px" ToolTip="Please give Customer Code or Select Customer from the List "></asp:TextBox>
                <div id="divwidth" style="display: none;">
                    <cc1:AutoCompleteExtender ID="txtCustomer_AutoCompleteExtender" runat="server" CompletionInterval="10"
                        CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="OPS_Customer"
                        CompletionListCssClass="AutoExtender" ServicePath="~/WebService.asmx" CompletionListElementID="divwidth"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListItemCssClass="AutoExtenderList"
                        TargetControlID="txtCustomer">
                    </cc1:AutoCompleteExtender>
                </div>
            </td>
            <td class="labelcells">
                Sale Person
            </td>
            <td colspan="1">
                <asp:DropDownList ID="ddlSalesPerson" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
            
         
        </tr>
        <tr>

           <td>
            Order No
            </td>
            <td>
                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox" ></asp:TextBox>
            </td>

            <td>
                Plant
            </td>
            <td style="margin-left: 80px">
                <asp:DropDownList ID="ddlPlant" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>BLENDED</asp:ListItem>
                    <asp:ListItem>COTTON</asp:ListItem>
                    <asp:ListItem>POLYESTER</asp:ListItem>
                </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="ddlPlant" Display="Dynamic" ErrorMessage="*" 
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                DateFrom
            </td>
            <td style="width: 250px">
                <asp:TextBox ID="txtEff_From" runat="server" CssClass="textbox" MaxLength="15" TabIndex="28"
                    ValidationGroup="ValidGrpSaveDetail" Width="65px"></asp:TextBox>
                <cc1:MaskedEditValidator ID="MEV6" runat="server" ControlExtender="MEE6" ControlToValidate="txtEff_From"
                    ValidationGroup="ValidGrpSaveDetail" Display="Dynamic" InvalidValueMessage="Invalid"
                    IsValidEmpty="False" EmptyValueMessage="*" TooltipMessage="MM/DD/YYYY" Width="114px"></cc1:MaskedEditValidator>
                <cc1:CalendarExtender ID="CalEfffr" runat="server" Animated="False" Format="MM/dd/yyyy"
                    TargetControlID="txtEff_From">
                </cc1:CalendarExtender>
                <cc1:MaskedEditExtender ID="MEE6" runat="server" Mask="99/99/9999" MaskType="Date"
                    TargetControlID="txtEff_From">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                DateTo
            </td>
            <td style="width: 250px">
                <asp:TextBox ID="txtEff_To" runat="server" CssClass="textbox" MaxLength="15" TabIndex="29"
                    ValidationGroup="ValidGrpSaveDetail" Width="65px"></asp:TextBox>
                <cc1:MaskedEditValidator ID="MEV7" runat="server" ControlExtender="MEE7" ControlToValidate="txtEff_To"
                    ValidationGroup="ValidGrpSaveDetail" Display="Dynamic" InvalidValueMessage="Invalid"
                    IsValidEmpty="False" EmptyValueMessage="*" TooltipMessage="MM/DD/YYYY" Width="114px"></cc1:MaskedEditValidator>
                <cc1:CalendarExtender ID="CalEffTo" runat="server" Animated="False" Format="MM/dd/yyyy"
                    TargetControlID="txtEff_To">
                </cc1:CalendarExtender>
                <cc1:MaskedEditExtender ID="MEE7" runat="server" Mask="99/99/9999" MaskType="Date"
                    TargetControlID="txtEff_To">
                </cc1:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label2" runat="server" Text="PlanType"></asp:Label>
            </td>
            <td style="width: 250px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlOPtion" runat="server" CssClass="combobox" 
                        AutoPostBack="True">
                    <asp:ListItem>Fresh</asp:ListItem>
                    <asp:ListItem>Re-Dyeing</asp:ListItem>
                    <asp:ListItem>Shortfall</asp:ListItem>
                    </asp:DropDownList>
                  
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td style="width: 250px">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: Left;width:99%; " class="labelcells" >
                **Sale Order With GreenBackground Indicates that some quantiy has been already Planned as shown
            </td>
            <td class="GridRowGreen" style="width:1%;">

            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <asp:LinkButton ID="CmdFetch" runat="server" CssClass="buttonc">Fetch</asp:LinkButton>
                <asp:LinkButton ID="CmdXl" runat="server" CssClass="buttonXL" Width="64px"></asp:LinkButton>
                <asp:LinkButton ID="LinkButton1" runat="server" 
                    onclientclick="window.history.go(-1);return false;">&lt;&lt; Back</asp:LinkButton>
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="10">
                    <ProgressTemplate>
                        <asp:Image ID="ImageProg" runat="server" ImageUrl="~/OPS/Image/loadingNew.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td colspan="3">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="80%" Height="400px">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                PageSize="50" Width="100%">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged"
                                                Width="15px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Split">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton2" runat="server" CommandName="OpenPopUp" Height="16px"
                                                ImageUrl="~/Image/SplitIcon.png" OnClientClick="ButtonClick()" Visible="false"
                                                Width="16px" OnClick="ImageButton2_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="SalePerson" HeaderText="SalePerson" />
                                    <asp:BoundField DataField="CustomerName" HeaderText="CustomerName" />
                                    <asp:BoundField DataField="OrderNo" HeaderText="OrderNo" />
                                    <asp:BoundField DataField="LineNo" HeaderText="Line">
                                        <ItemStyle Width="80px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Item" HeaderText="Item" />
                                    <asp:BoundField DataField="Shade" HeaderText="Shade" />
                                    <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" />
                                    <asp:TemplateField HeaderText="OrderDelivryDt">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtOrdDlvryDate" runat="server" CssClass="textbox" Enabled="False"
                                                ReadOnly="True" Text='<%# Eval("OrderReqDate") %>' Width="80px"></asp:TextBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("OrderReqDate") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="OrderQty" HeaderText="OrderQty" />
                                    <asp:BoundField DataField="PlannedQty" HeaderText="WeavedQty" />
                                    <asp:BoundField DataField="IssuedMeters" HeaderText="IssuedMeters" />
                                    <asp:BoundField DataField="PendingDyngQty" HeaderText="BalDyngQty" />
                                    <asp:TemplateField HeaderText="DyeingQty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDyeingMtrs" runat="server" CssClass="textbox" MaxLength="5" Width="50px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtDyeingMtrs_FilteredTextBoxExtender" runat="server"
                                                Enabled="True" FilterType="Numbers" TargetControlID="txtDyeingMtrs">
                                            </cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ReqDyeingDate">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtReqDyeingDate" runat="server" CssClass="textbox" Width="60px"></asp:TextBox>
                                            <cc1:CalendarExtender ID="txtReqDyeingDate_CalendarExtender" runat="server" Enabled="True"
                                                TargetControlID="txtReqDyeingDate">
                                            </cc1:CalendarExtender>
                                            <%--   <cc1:MaskedEditValidator ID="MEV6" runat="server" ControlExtender="MEE6" ControlToValidate="txtReqDyeingDate"
                                                Display="Dynamic" InvalidValueMessage="Invalid" IsValidEmpty="False" EmptyValueMessage="*"
                                                TooltipMessage="MM/DD/YYYY" Width="114px" ValidationGroup="None">
                                            </cc1:MaskedEditValidator>
                                            <cc1:MaskedEditExtender ID="MEE6" runat="server" Mask="99/99/9999" MaskType="Date"
                                                TargetControlID="txtReqDyeingDate">
                                            </cc1:MaskedEditExtender>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="PendingFinishQty" HeaderText="BalFinishQty" />
                                    <asp:TemplateField HeaderText="FinishedQty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFinishMtrs" runat="server" CssClass="textbox" MaxLength="5" Width="50px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtFinishMtrs_FilteredTextBoxExtender" runat="server"
                                                Enabled="True" FilterType="Numbers" TargetControlID="txtFinishMtrs">
                                            </cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ReqFinishedDate">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtReqFinishDate" runat="server" CssClass="textbox" Width="60px"></asp:TextBox>
                                            <cc1:CalendarExtender ID="txtReqFinishDate_CalendarExtender" runat="server" Enabled="True"
                                                TargetControlID="txtReqFinishDate">
                                            </cc1:CalendarExtender>
                                            <%--  <cc1:MaskedEditValidator ID="MEV1" runat="server" ControlExtender="MEE1" ControlToValidate="txtReqFinishDate"
                                                ValidationGroup="None" Display="Dynamic" InvalidValueMessage="Invalid" IsValidEmpty="False"
                                                EmptyValueMessage="*" TooltipMessage="MM/DD/YYYY" Width="114px">
                                            </cc1:MaskedEditValidator>
                                            <cc1:MaskedEditExtender ID="MEE1" runat="server" Mask="99/99/9999" MaskType="Date"
                                                TargetControlID="txtReqFinishDate">
                                            </cc1:MaskedEditExtender>--%>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DyngRemarks">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" Width="125px"></asp:TextBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FinisRemarks">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFinsRemarks" runat="server" CssClass="textbox" MaxLength="500"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
                <asp:Button ID="btnPopUp" runat="server" Style="display: none" />
                <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnPopUp"
                    PopupControlID="pnlpopup" CancelControlID="lnkSplitCancel" BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="buttonbackbar">
                <asp:LinkButton ID="CmdApply" runat="server" CssClass="buttonc" ValidationGroup="ValidGrpSaveDetail">FreeZe</asp:LinkButton>
                <asp:LinkButton ID="Cmd1" runat="server"></asp:LinkButton>
                <asp:LinkButton ID="CmdClear" runat="server" CssClass="buttonc">Clear</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="CmdDEtail" runat="server" BorderStyle="None" 
                    CssClass="buttonc">Detail</asp:LinkButton>
&nbsp;<asp:LinkButton ID="LinkButton2" runat="server" 
                    onclientclick="window.history.go(-1);return false;">&lt;&lt; Back</asp:LinkButton>
                <uc1:FlashMessage id="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                    FadeInDuration="2" FadeInSteps="2" FadeOutDuration="4" FadeOutSteps="2" Visible="true">
                </uc1:FlashMessage>
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
  <asp:Panel ID="pnlpopup" runat="server" Width="80%" CssClass="panelbg"  >
        <asp:UpdatePanel ID="SubGrid" runat="server" RenderMode="Inline" 
            UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="Panel4" runat="server" Width="100%"  ScrollBars="Horizontal" >
                <asp:GridView ID="grdSplit" runat="server" CssClass="GridViewStyle" Width="100%"
                    AutoGenerateColumns="False" EnableModelValidation="True" AllowPaging="True" ShowFooter="True">
                    <Columns>
                        <asp:TemplateField>
                        <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/OPS/Image/iPhone_Delete_icon.png"
                                    CommandName="Delete" CausesValidation="False" />
                        </ItemTemplate>
                        <FooterTemplate>
                                <asp:ImageButton ID="imgAddRow" runat="server" ImageUrl="~/Image/Icons/Action/iPhoneAdd.png"
                                    ToolTip="Click to Add More Rows" Width="24px" ValidationGroup="a" OnClick="imgAddRow_Click"
                                    CommandName="Add" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="OrderNo" HeaderText="OrderNo" />
                        <asp:BoundField DataField="Item" HeaderText="Item" />
                        <asp:BoundField DataField="Shade" HeaderText="Shade" />
                        <asp:BoundField DataField="LineNo" HeaderText="LineNo" />
                        <asp:BoundField DataField="IssuedMeters" HeaderText="IssuedMeters" />
                        <asp:BoundField DataField="PendingDyngQty" HeaderText="PendingDyngQty" />
                        <asp:BoundField DataField="PendingFinishQty" HeaderText="PendingFinishQty" />
                        <asp:BoundField DataField="OrderQty" HeaderText="OrderQty" />
                        <asp:BoundField DataField="OrderReqdate" HeaderText="OrderReqdate" />
                        <asp:TemplateField HeaderText="DyeingMeters">
                            <ItemTemplate>
                                <asp:TextBox ID="txtPopDyeingMtrs" runat="server" CssClass="textbox" MaxLength="5" Width="50px" ValidationGroup="ValidSubGrpSaveDetail"></asp:TextBox>
                           <%--     <asp:RequiredFieldValidator ID="ReqPop1" runat="server" 
                                    ControlToValidate="txtPopDyeingMtrs" Display="Dynamic" ErrorMessage="*" 
                                    SetFocusOnError="True" ValidationGroup="ValidSubGrpSaveDetail"></asp:RequiredFieldValidator>
                                <cc1:FilteredTextBoxExtender ID="txtPopDyeingMtrs_FilteredTextBoxExtender" runat="server"
                                    Enabled="True" FilterType="Numbers" TargetControlID="txtPopDyeingMtrs"  >
                                </cc1:FilteredTextBoxExtender>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DyngDate">
                            <ItemTemplate>
                                <asp:TextBox ID="txtPopDyngDate" runat="server" CssClass="textbox" MaxLength="15"
                                    TabIndex="28" ValidationGroup="ValidSubGrpSaveDetail" Width="65px"></asp:TextBox>
                               <%-- <cc1:MaskedEditValidator ID="MEVPop1" runat="server" ControlExtender="MEEpop1" ControlToValidate="txtPopDyngDate"
                                    ValidationGroup="ValidSubGrpSaveDetail" Display="Dynamic" InvalidValueMessage="Invalid"
                                    IsValidEmpty="False" EmptyValueMessage="*" TooltipMessage="MM/DD/YYYY" Width="114px">
                                </cc1:MaskedEditValidator>--%>
                                <cc1:CalendarExtender ID="CalpopDyngDate" runat="server" Animated="False" Format="MM/dd/yyyy"
                                    TargetControlID="txtPopDyngDate">
                                </cc1:CalendarExtender>
                              <%--  <cc1:MaskedEditExtender ID="MEEpop1" runat="server" Mask="99/99/9999" MaskType="Date"
                                    TargetControlID="txtPopDyngDate">
                                </cc1:MaskedEditExtender>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DyngRemarks">
                        <ItemTemplate>
                        <asp:TextBox ID="txtPopDyngRemarks" runat="server" CssClass="textbox" MaxLength="150" Width="150px" ></asp:TextBox>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FinsMtrs">
                        <ItemTemplate>
                                <asp:TextBox ID="txtPopFinMtrs" runat="server" CssClass="textbox" MaxLength="5" Width="50px" ValidationGroup="ValidSubGrpSaveDetail" ></asp:TextBox>
                            <%--    <asp:RequiredFieldValidator ID="ReqPop2" runat="server" 
                                    ControlToValidate="txtPopFinMtrs" Display="Dynamic" ErrorMessage="*" 
                                    SetFocusOnError="True"  ValidationGroup="ValidSubGrpSaveDetail" ></asp:RequiredFieldValidator>
                                <cc1:FilteredTextBoxExtender ID="txtPopFinMtrs_FilteredTextBoxExtender" runat="server"
                                    Enabled="True" FilterType="Numbers" TargetControlID="txtPopFinMtrs" >
                                </cc1:FilteredTextBoxExtender>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FinsDate">
                            <ItemTemplate>
                                <asp:TextBox ID="txtPopFinDate" runat="server" CssClass="textbox" MaxLength="15"
                                    TabIndex="28" ValidationGroup="ValidSubGrpSaveDetail" Width="65px"></asp:TextBox>
                             <%--   <cc1:MaskedEditValidator ID="MEVPop2" runat="server" ControlExtender="MEEpop2" ControlToValidate="txtPopFinDate"
                                    ValidationGroup="ValidSubGrpSaveDetail" Display="Dynamic" InvalidValueMessage="Invalid"
                                    IsValidEmpty="False" EmptyValueMessage="*" TooltipMessage="MM/DD/YYYY" Width="114px">
                                </cc1:MaskedEditValidator>--%>
                                <cc1:CalendarExtender ID="CalpopFinDate" runat="server" Animated="False" Format="MM/dd/yyyy"
                                    TargetControlID="txtPopFinDate">
                                </cc1:CalendarExtender>
                            <%--    <cc1:MaskedEditExtender ID="MEEpop2" runat="server" Mask="99/99/9999" MaskType="Date"
                                    TargetControlID="txtPopFinDate">
                                </cc1:MaskedEditExtender>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FinsRemarks">
                        <ItemTemplate>
                        <asp:TextBox ID="txtPopFinsRemarks" runat="server" CssClass="textbox" MaxLength="150" Width="150px" ></asp:TextBox>
                        </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        No Recrods Found
                    </EmptyDataTemplate>
                    <HeaderStyle CssClass="gridheader" />
                    <PagerStyle CssClass="PagerStyle" />
                    <RowStyle CssClass="GridItem" />
                    <AlternatingRowStyle CssClass="GridAI" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                </asp:GridView>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
            </Triggers>
        </asp:UpdatePanel>
        <table style="width: 100%;">
            <tr>
                <td class="buttonbackbar">
                    <asp:LinkButton ID="lnkSplitCancel" runat="server" CssClass="buttonc">Cancel</asp:LinkButton>
                    <asp:LinkButton ID="lnkSplitOk" runat="server" CssClass="buttonc" 
                        ValidationGroup="ValidSubGrpSaveDetail" >Ok</asp:LinkButton>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
