<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true"
    CodeFile="Testing_Entry.aspx.vb" Inherits="OPS_Testing_Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Testing Entry
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 106px" valign="top">
                Stage
            </td>
            <td style="width: 106px" valign="top">
                <div id="divwidth" style="display: none;">
                </div>
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlStage" runat="server" CssClass="combobox" >
                            <asp:ListItem>Greigh</asp:ListItem>
                            <asp:ListItem>Dyeing</asp:ListItem>
                            <asp:ListItem>Finish</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td rowspan="1" width="100" valign="top">
                 Test Type</td>
            <td rowspan="1" width="60%" valign="top">
                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlTestType" runat="server" 
                            ValidationGroup="ValidGrpSaveDetail" CssClass="combobox">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Chemical</asp:ListItem>
                            <asp:ListItem>Physical</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="ddlTestType" Display="Dynamic" ErrorMessage="*" 
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 106px" valign="top">
                Plant</td>
            <td style="width: 106px" valign="top">
                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPlantType" runat="server" CssClass="combobox">
                            <asp:ListItem>Cotton</asp:ListItem>
                            <asp:ListItem>Taffeta</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td width="100" valign="top">
                 Process</td>
            <td width="60%" valign="top">
                        <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlprocess" runat="server" 
    CssClass="combobox"  Width="199px" AutoPostBack="True">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 106px" valign="top">
                &nbsp;</td>
            <td valign="top" colspan="3">
                        <asp:UpdateProgress ID="UpdateProgress2" runat="server" 
                    DisplayAfter="10">
                            <ProgressTemplate>
                                <asp:Image ID="ImageProg" runat="server" 
                                    ImageUrl="~/OPS/Image/loadingNew.gif" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="NormalText" valign="top" colspan="4">
            <table style="width:100%;" class="tableback">
                            <tr>
                                <td>
                                    Order No</td>
                                <td>

                                    <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                                    <asp:LinkButton ID="cmdSearch" runat="server" CssClass="searchbluesmall" 
                                        Width="16px" Height="17px"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server">Batch No</asp:Label>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel18" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtBatchNo" runat="server" CssClass="textbox" MaxLength="5" 
                                                Width="50px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="BatchNo_FilteredTextBoxExtender" 
                                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtBatchNo" 
                                                ValidChars="0123456789">
                                            </cc1:FilteredTextBoxExtender>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="txtOrderNo" EventName="TextChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="GrdOrderDetails" 
                                                EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
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
                <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        
                       
                            <asp:Panel ID="Pnl" runat="server" Height="200px" ScrollBars="Both" 
                                Width="100%">
                                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="GrdOrderDetails" runat="server" 
                                            AutoGenerateSelectButton="True" Width="98%">
                                            <HeaderStyle CssClass="GridHeader" />
                                            <RowStyle CssClass="GridItem" />
                                            <SelectedRowStyle CssClass="GridRowGreen" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:Panel>
                        
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="rblSaleOrder" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="GrdSavedRecords" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="GrdOrderDetails" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtBatchNo" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
    <table style="width: 100%;" class="tableback">
       <tr>
            <td class="NormalText"  valign="top">
                Line
            </td>
            <td colspan="1">
                <asp:UpdatePanel ID="UpdatePanel15" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlLineNo" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:Label ID="lblSort" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td valign="top">
                Shade
            </td>
                <td valign="top">
                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblShade" runat="server" Text="."></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" >
                Serial No.
            </td>
            <td >
                <asp:UpdatePanel ID="UpdatePanel23" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblSerial" runat="server" Text="0000"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GrdOrderDetails" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
             <td   valign="top">
                &nbsp;</td>
             <td   valign="top">
                 &nbsp;</td>
        </tr>
       <tr>
            <td class="NormalText" >
                Test Conducted By
            </td>
            <td >
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtTestConductedBy" runat="server" CssClass="textbox" AutoPostBack="True"
                            
                            ToolTip="Select Employee from the PopUp List or Give Employee Code Directly !!!" 
                            ValidationGroup="ValidGrpSaveDetail" Width="175px"></asp:TextBox>
                        <div id="div1" style="display: none;">
                            <cc1:AutoCompleteExtender ID="txtTestConductedBy_AutoCompleteExtender" runat="server"
                                CompletionInterval="10" CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="GetEmployee_OPS"
                                CompletionListElementID="div1" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                CompletionListItemCssClass="AutoExtenderList" ServicePath="~/WebService.asmx"
                                TargetControlID="txtTestConductedBy">
                            </cc1:AutoCompleteExtender>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtTestConductedBy" Display="Dynamic" ErrorMessage="*" 
                            SetFocusOnError="True" ValidationGroup="ValidGrpSaveDetail"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
             <td valign="top">
                 <asp:Label ID="Label2" runat="server" Text="Test Conducted On "></asp:Label>
            </td>
             <td  valign="top" width="250">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtTestDate" runat="server" CssClass="textbox" Width="60px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtTestDate_CalendarExtender" runat="server" Format="MM/dd/yyyy"
                            Animated="False" TargetControlID="txtTestDate">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditValidator ID="MEV1" runat="server" ControlExtender="MEE1" ControlToValidate="txtTestDate"
                            ValidationGroup="ValidGrpSaveDetail" Display="Dynamic" InvalidValueMessage="Invalid"
                            SetFocusOnError="true" IsValidEmpty="False" EmptyValueMessage="*" TooltipMessage="MM/DD/YYYY"
                            Width="114px">

                        </cc1:MaskedEditValidator>
                        <cc1:MaskedEditExtender ID="MEE1" runat="server" Mask="99/99/9999" MaskType="Date"
                            TargetControlID="txtTestDate">
                        </cc1:MaskedEditExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" >
                Tested Sample (mtrs)
            </td>
            <td >
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSampleMtrs" runat="server" CssClass="textbox" MaxLength="3" Columns="5"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="txtSampleMtrs_FilteredTextBoxExtender" runat="server"
                            FilterInterval="10" FilterType="Numbers" TargetControlID="txtSampleMtrs" ValidChars="1,2,3,4,5,6,7,8,9,0">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
             <td  valign="top">
                Result
            </td>
             <td  valign="top">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlResult" runat="server" CssClass="combobox" ValidationGroup="ValidGrpSaveDetail">
                            <asp:ListItem Selected="True"> </asp:ListItem>
                            <asp:ListItem>Pass</asp:ListItem>
                            <asp:ListItem>Fail</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                            ErrorMessage="*" ControlToValidate="ddlResult" SetFocusOnError="True" ValidationGroup="ValidGrpSaveDetail"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" >
                Reason
            </td>
            <td class="NormalText" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtReason" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" >
                Remarks
            </td>
            <td class="NormalText" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkApply" runat="server" CssClass="buttonc" ValidationGroup="ValidGrpSaveDetail">Apply</asp:LinkButton>
                        <asp:LinkButton ID="lnkClear" runat="server" CssClass="buttonc">Clear</asp:LinkButton>
                        <asp:LinkButton ID="CmdDelete" runat="server" CssClass="buttonc">Delete</asp:LinkButton>
                        &nbsp;&nbsp;&nbsp;
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Panel ID="Panel2" runat="server" Height="200px" Width="100%" 
                    ScrollBars="Both">
                    <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GrdSavedRecords" runat="server" Width="100%" AutoGenerateColumns="False" 
                                DataSourceID="SqlDataSource1" EnableModelValidation="True" 
                                AutoGenerateSelectButton="True">
                                <Columns>
                                    <asp:BoundField DataField="OrderNo" HeaderText="OrderNo" SortExpression="OrderNo" />
                                    <asp:BoundField DataField="LineItem" HeaderText="LineItem" SortExpression="LineItem" />
                                    <asp:BoundField DataField="SortNo" HeaderText="SortNo" SortExpression="SortNo" />
                                    <asp:BoundField DataField="TestConductedBy" HeaderText="TestConductedBy" SortExpression="TestConductedBy" />
                                    <asp:BoundField DataField="EmpName" HeaderText="EmpName" SortExpression="EmpName" />
                                    <asp:BoundField DataField="TestConductedOn" HeaderText="TestConductedOn" SortExpression="TestConductedOn" />
                                    <asp:BoundField DataField="MtrsTested" HeaderText="MtrsTested" SortExpression="MtrsTested" />
                                    <asp:BoundField DataField="Result" HeaderText="Result" SortExpression="Result" />
                                    <asp:BoundField DataField="Reason" HeaderText="Reason" SortExpression="Reason" />
                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />
                                    <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate" />
                                    <asp:BoundField DataField="TransID" HeaderText="TransID" SortExpression="TransID" />
                                    <asp:BoundField DataField="batchNo" HeaderText="BatchNo" SortExpression="batchNo" />
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                                <SelectedRowStyle CssClass="GridRowGreen" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:jctdevConnectionString %>"
                                SelectCommand="SELECT  OrderNo,LineItem,SortNo,Shade,TestConductedBy,b.empname AS EmpName,convert(varchar(10),TestConductedOn,101) as TestConductedOn ,MetersTested as MtrsTested ,Result ,Reason ,Remarks ,convert(varchar(10),CreatedDate,101) as CreatedDate ,TransID,BatchNo FROM Jct_Ops_QA_Feedback_Entry a,dbo.JCT_EmpMast_Base b WHERE STATUS='A' AND Active='Y' AND a.TestConductedBy=b.empcode order by transid desc"
                                UpdateCommand="Update Jct_Ops_QA_Feedback_Entry set status='D' where transid=@TranId">
                                <UpdateParameters>
                                    <asp:ControlParameter ControlID="GrdSavedRecords" Name="TranId" PropertyName="SelectedValue" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr style="display: none">
            <td style="display: none">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="BtnFetch" runat="server" Text="Button" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
            <asp:Panel ID="pnlSaleOrder" runat="server" CssClass="panelbg" Width="200px" Height="400px"
                Style="display: none;" ScrollBars="Vertical">
                <asp:RadioButtonList ID="rblSaleOrder" CssClass="textbox" runat="server" AutoPostBack="True">
                </asp:RadioButtonList>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="txtOrderNo" EventName="TextChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
