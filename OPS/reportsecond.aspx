<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="reportsecond.aspx.cs" Inherits="OPS_reportsecond" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register TagPrefix="uc1" TagName="FMsg" Src="~/FlashMessage.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%; height: 307px;">
        <tr>
            <td class="tableheader" colspan="4" >
               
                CLASSIMAT TEST RESULT (FD FAULTS)
              
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="lblDate" runat="server" Text="DATE(mm/dd/yy)"></asp:Label>
            </td>
            <td style="height: 22px; width: 173px">
                <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" 
                    ontextchanged="txtDate_TextChanged" 
                    ToolTip="CLICK ON THE TEXTBOX TO SELECT DATE"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                    TargetControlID="txtDate">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="ReqDate" runat="server" 
                    ControlToValidate="txtDate" Display="None" 
                    ErrorMessage="PLEASE ENTER VALID DATE">*</asp:RequiredFieldValidator>
            </td>
            <td style="height: 22px; width: 124px" class="labelcells">
                <asp:Label ID="lblMachineNo" runat="server" Text="MACHINE NO"></asp:Label>
            </td>
            <td style="width: 286px; height: 22px">
                <asp:TextBox ID="txtMachineNo" runat="server" CssClass="textbox" 
                    ToolTip="select machine no"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtMachineNo_AutoCompleteExtender" runat="server" 
                    CompletionInterval="100" 
                    CompletionListCssClass="autocomplete_completionListElement" 
                    CompletionSetCount="100" MinimumPrefixLength="1" ServiceMethod="machineno" 
                    ServicePath="~/webservice.asmx" TargetControlID="txtMachineNo">
                </cc1:AutoCompleteExtender>
                <asp:RequiredFieldValidator ID="ReqMacNo" runat="server" 
                    ControlToValidate="txtMachineNo" Display="None" ErrorMessage="ENTER MACHINE NO">*</asp:RequiredFieldValidator>
                    
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="lblCountNo" runat="server" Text="COUNT NO"></asp:Label>
            </td>
            <td style="height: 21px; width: 173px">
                <asp:TextBox ID="txtCountNo" runat="server" CssClass="textbox" 
                    ToolTip="TYPE ATLEAST TWO  NUMBERS TO SEARCH AN ITEM"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtCountNo_AutoCompleteExtender" runat="server" 
                    MinimumPrefixLength="2" ServiceMethod="faults" ServicePath="~/webservice.asmx" 
                    TargetControlID="txtCountNo">
                </cc1:AutoCompleteExtender>
         
                <asp:RequiredFieldValidator ID="ReqCountNo" runat="server" 
                    ControlToValidate="txtCountNo" Display="None" 
                    ErrorMessage="PLEASE ENTER COUNT NO">*</asp:RequiredFieldValidator>
            </td>
            <td style="height: 21px; width: 124px" class="labelcells">
                <asp:Label ID="lblSource" runat="server" Text="SOURCE"></asp:Label>
            </td>
            <td style="height: 21px; width: 286px">
                <asp:TextBox ID="txtSource" runat="server" CssClass="textbox" 
                    ToolTip="number or alphabets"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqSourceNo" runat="server" 
                    ControlToValidate="txtSource" Display="None" ErrorMessage="Enter Source No">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 123px" class="labelcells">
                <asp:Label ID="lbltestedLen" runat="server" Text="TESTED LENGTH(KM)"></asp:Label>
            </td>
            <td style="height: 21px; width: 173px">
                <asp:TextBox ID="txtTestedLen" runat="server" CssClass="textbox" 
                    ToolTip="Enter only numeric or decimals values"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqTestedLen" runat="server" 
                    ControlToValidate="txtTestedLen" Display="None" 
                    ErrorMessage="PLEASE ENTER TESTED LENGTH">*</asp:RequiredFieldValidator>
            </td>
            <td style="height: 21px; width: 124px" class="labelcells">
                <asp:Label ID="lblTestedWeight" runat="server" Text="TESTED WEIGHT(KG)"></asp:Label>
            </td>
            <td style="height: 21px; width: 286px">
                <asp:TextBox ID="txtTestedWeight" runat="server" style="margin-left: 0px" 
                    CssClass="textbox" ToolTip="Enter only numeric or decimals values"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqTestedWeight" runat="server" 
                    ControlToValidate="txtTestedWeight" Display="None" 
                    ErrorMessage="PLEASE   ENTER TESTED WEIGHT">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 123px" class="labelcells">
                <asp:Label ID="lblAddFdFaults" runat="server" Text="ALL FD FAULTS / 100KM"></asp:Label>
            </td>
            <td style="height: 21px; width: 173px">
                <asp:TextBox ID="txtAddFdFaults" runat="server" 
                    CssClass="textbox" ToolTip="Enter only numeric or decimals values"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqFdFaults" runat="server" 
                    ControlToValidate="txtAddFdFaults" Display="None" 
                    ErrorMessage="PLEASE ENTER FD FAULTS">*</asp:RequiredFieldValidator>
            </td>
            <td style="height: 21px; width: 124px" class="labelcells">
                <asp:Label ID="lblAllFdCuts" runat="server" Text="ALL FD CUTS/100KM"></asp:Label>
            </td>
            <td style="height: 21px; width: 286px">
                <asp:TextBox ID="txtAllfdCUTS" runat="server" CssClass="textbox" 
                    ToolTip="Enter only numeric or decimals values"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqFdCuts" runat="server" 
                    ControlToValidate="txtAllfdCUTS" Display="None" 
                    ErrorMessage="PLEASE ENTER FD CUTS">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="lblVisualObserv" runat="server" Text="VISUAL OBSERVATION"></asp:Label>
            </td>
            <td style="height: 21px; width: 173px">
                <asp:TextBox ID="txtVisualObserv" runat="server" CssClass="textbox" 
                    ToolTip="LESS THAN 10 WORDS"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqVisualObserv" runat="server" 
                    ControlToValidate="txtVisualObserv" Display="None" 
                    ErrorMessage="PLEASE ENTER VISUAL OBSERVATION">*</asp:RequiredFieldValidator>
            </td>
            <td style="height: 21px; width: 124px" class="labelcells">
                <asp:Label ID="Label2" runat="server" Text="DARK COLOR  FD MATTER"></asp:Label>
            </td>
            <td style="height: 21px; width: 286px">
                <asp:TextBox ID="txtDarkColoredMatter" runat="server" CssClass="textbox" 
                    ToolTip="Enter only numeric  values"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqDarkColorMatter" runat="server" 
                    ControlToValidate="txtDarkColoredMatter" 
                    ErrorMessage="PLEASE ENTER DARK COLOR MATTER" Display="None">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label1" runat="server" Text="VEG MATTERS"></asp:Label>
            </td>
            <td style="height: 21px; width: 173px">
                <asp:TextBox ID="txtVegMatter" runat="server" CssClass="textbox" 
                    ToolTip="Enter only numeric  values"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqVegMatters" runat="server" 
                    ControlToValidate="txtVegMatter" Display="None" 
                    ErrorMessage="PLEASE ENTER VEG MATTERS">*</asp:RequiredFieldValidator>
            </td>
            <td style="height: 21px; width: 124px" class="labelcells">
                <asp:Label ID="lblRemark" runat="server" Text="REMARK"></asp:Label>
            </td>
            <td style="height: 21px; width: 286px">
                <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox" 
                    ToolTip="WORDS LESS THAN 15"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqRemark" runat="server" 
                    ControlToValidate="txtRemark" ErrorMessage="PLEASE ENTER REMARKS">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="height: 40px" colspan="4" class="NormalText">
                <asp:ImageButton ID="imgbtnAdd" runat="server"  
                    ImageUrl="~/Image/Icons/Action/document_add.png" onclick="imgbtnAdd_Click" 
                    Width="32px" ToolTip="Add" />
                <asp:ImageButton ID="ImgBtnDel" runat="server" 
                    ImageUrl="~/Image/Icons/Action/document_delete.png" onclick="ImgBtnDel_Click" 
                    Width="32px" ToolTip="Delete" />
                <asp:ImageButton ID="ImgBtnModify" runat="server"
                    ImageUrl="~/Image/Icons/Action/document_save.png" 
                    onclick="ImgBtnModify_Click" Width="32px" ToolTip="Update" />
                <asp:ImageButton ID="ImgBtnAuthorize" runat="server" 
                    ImageUrl="~/Image/Icons/Action/Authorise.png" onclick="ImgBtnAuthorize_Click" 
                    Width="32px" ToolTip="Authorize" />
                <asp:ImageButton ID="imgBtnBack" runat="server"  CausesValidation="false"
                    ImageUrl="~/Image/Icons/Action/Back.png" onclick="imgBtnBack_Click" 
                    ToolTip="Back" Width="32px" />
                <asp:Label ID="lblid" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="height: 48px" class="NormalText">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                
                <uc1:FMsg  ID="lblErrMachineNo" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="4" style="height: 103px">
                <asp:GridView ID="grdDetails" runat="server" EnableModelValidation="True" 
                    onselectedindexchanged="grdDetails_SelectedIndexChanged" Width="100%">
                    <AlternatingRowStyle CssClass="GridAi" />
                    <Columns>
                        <asp:CommandField HeaderText="option" ShowHeader="True" 
                            ShowSelectButton="True" />
                    </Columns>
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PageStyle" />
                    <RowStyle CssClass="GridItem" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

