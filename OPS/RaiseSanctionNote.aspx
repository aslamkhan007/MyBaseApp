<%@ Page Title="" Language="VB" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="false"
    CodeFile="RaiseSanctionNote.aspx.vb" Inherits="OPS_RaiseSanctionNote" %>

<%--<%@ Register Assembly="FlashUpload" Namespace="FlashUpload" TagPrefix="cc1" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%--<%@ Register Assembly="com.flajaxian.FileUploader" Namespace="com.flajaxian" TagPrefix="cc3" %>--%>
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
    <table style="width: 100%;">
        <tr>
            <td class="tableheader">
                Raise SanctionNote
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Click To Import Existing Values from a SanctionNote"></asp:Label>
                &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Image/plus.png" />
                <cc2:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" CollapseControlID="ImageButton1"
                    Collapsed="True" CollapsedImage="~\Image\plus.png" ExpandedImage="~\Image\Minus.png"
                    ImageControlID="ImageButton1" ExpandControlID="ImageButton1" TargetControlID="Panel3" >
                </cc2:CollapsiblePanelExtender>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel3" runat="server" BorderColor="Gray" BorderWidth="2px">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                Import</td>
                            <td>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                                    CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Old SanctionNote"></asp:Label>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtImportSanctionNote" runat="server" CssClass="textbox"></asp:TextBox>
                                        &nbsp;<asp:LinkButton ID="cmdRetreive" runat="server">Retrieve</asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
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
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td valign="top">
                Area
            </td>
            <td valign="top">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlarea" runat="server" CssClass="combobox" Width="200px" AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cmdRetreive" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td valign="middle">
                &nbsp;SanctionNote
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:Label ID="lblID" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <%--<%@ Register Assembly="com.flajaxian.FileUploader" Namespace="com.flajaxian" TagPrefix="cc3" %>--%>
        </tr>
        <tr>
            <td>
                Subject
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSubject" runat="server" CssClass="textbox" Width="200px" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSubject"
                            Display="Dynamic" ErrorMessage="* Required" SetFocusOnError="True" ValidationGroup="GrpApply"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Plant
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" AutoPostBack="True">
                            <asp:ListItem>Cotton</asp:ListItem>
                            <asp:ListItem>Taffeta</asp:ListItem>

					<asp:ListItem>JCTHOMES</asp:ListItem>
<asp:ListItem>Garmenting</asp:ListItem>
                        </asp:DropDownList>
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
    <table style="width: 100%;">
        <tr>
            <td valign="top">
                Detail Description
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="textbox" Height="200px"
                            Width="80%" TextMode="MultiLine" MaxLength="2000"></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cmdRetreive" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                &nbsp;
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td valign="top" colspan="2">
                <table style="width: 100%;">
                    <tr>
                        <td colspan="3">
                            Parameter List
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="grdParameters" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                                        Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="ParamCode" HeaderText="Code">
                                                <ControlStyle Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ParmDesc" HeaderText="ParaMeterName" />
                                            <asp:TemplateField HeaderText="Value">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtValue" runat="server" CssClass="textbox"></asp:TextBox>
                                                    <cc2:FilteredTextBoxExtender ID="txtValue_FilteredTextBoxExtender" 
                                                        runat="server" Enabled="False" FilterType="Custom" TargetControlID="txtValue" 
                                                        ValidChars="1234567890.">
                                                    </cc2:FilteredTextBoxExtender>
                                                    <asp:DropDownList ID="ddlValueList" runat="server" CssClass="combobox" Visible="False"
                                                        Width="200px" onselectedindexchanged="ddlValueList_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="Req_DataValidation" runat="server" 
                                                        ControlToValidate="txtValue" Display="Dynamic" ErrorMessage="*" 
                                                        SetFocusOnError="True" ValidationGroup="GrpApply" Enabled="false"></asp:RequiredFieldValidator>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("Val") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="PostBack" />
                                            <asp:BoundField DataField="Reqd_flag">
<ItemStyle Width="10px" />
</asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="HdnIsValue" runat="server" Value='<%# Eval("IsValue") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            
                                        </Columns>
                                        <HeaderStyle CssClass="GridHeader" />
                                        <RowStyle CssClass="GridItem" />
                                        <AlternatingRowStyle CssClass="GridAI" />
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlarea" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlplant" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="cmdRetreive" EventName="Click" />
                                </Triggers>
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
        <%--<%@ Register Assembly="com.flajaxian.FileUploader" Namespace="com.flajaxian" TagPrefix="cc3" %>--%>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td valign="top">
                <asp:Label ID="Label1" runat="server" Font-Size="Small" Text="Authorizing Hierarchy"></asp:Label>
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
                            <asp:UpdatePanel ID="UpdatePanel8" runat="server" RenderMode="Inline">
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
                            <%--<%@ Register Assembly="com.flajaxian.FileUploader" Namespace="com.flajaxian" TagPrefix="cc3" %>--%>
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
    <table style="width: 100%;" class="tableback">
        <tr>
            <td valign="top">
                <%--<%@ Register Assembly="com.flajaxian.FileUploader" Namespace="com.flajaxian" TagPrefix="cc3" %>--%>
                <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="always">
                    <ContentTemplate>
                        <asp:Panel ID="Panel2" runat="server" Height="150px" ScrollBars="Vertical">
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
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td class="tableback">
                Attachments..
            </td>
        </tr>
        <tr>
            <td valign="top">
                <%--<asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel2" runat="server" Height="150px" ScrollBars="Vertical">
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
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlarea" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlplant" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="cmdRetreive" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>--%>
                <span style="font-family: Arial">Click to add files</span>&nbsp;&nbsp;
                <input id="Button2" onclick="AddFileUpload()" type="button" value="add" />
               <div id="FileUploadContainer">
                    <!--FileUpload Controls will be added here -->
                     <asp:Button ID="Button3" Text="Upload"  runat="server" />
                      
                            <asp:Panel ID="Panel4" runat="server" CssClass="panelbg">
                                <asp:DataList ID="dtlAttachment" runat="server" 
                                    onitemcommand="dtlAttachment_ItemCommand">
                                    <ItemTemplate>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td class="NormalText" style="width: 114px">
                                                    <asp:Label ID="lblAttachments" runat="server" Text='<%# Eval("Attachment") %>'></asp:Label>
                                                </td>
                                                <td class="NormalText">
                                                    <asp:LinkButton ID="lnkAttachment" runat="server" CommandArgument='<%# Eval("AttachedFile") %>'
                                                        CommandName="Download" Text='<%# Eval("AttachedFile") %>'></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                            </asp:Panel>
                        
                </div>
                <%--<%@ Register Assembly="com.flajaxian.FileUploader" Namespace="com.flajaxian" TagPrefix="cc3" %>--%>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td valign="top" class="buttonbackbar">
                <asp:LinkButton ID="cmdApply" runat="server" BorderStyle="None" CssClass="buttonc"
                    ValidationGroup="GrpApply">Apply</asp:LinkButton>
                &nbsp;<asp:LinkButton ID="cmdReset" runat="server" BorderStyle="None" CssClass="buttonc">Reset</asp:LinkButton>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td valign="top" colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top">
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
            <td valign="top">
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
            <td valign="top" colspan="3">
                &nbsp;
                <asp:FileUpload ID="FileUpload1" runat="server" Height="0px" Width="0px" />
                &nbsp; &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
