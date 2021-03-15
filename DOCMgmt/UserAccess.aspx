<%@ Page Title="" Language="VB" MasterPageFile="User_Screen.master" AutoEventWireup="false" CodeFile="UserAccess.aspx.vb" Inherits="DOCMgmt_UserAccess"  MaintainScrollPositionOnPostback="True" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="2">
                <asp:Label ID="Label16" runat="server" Text="Grant User/Role Access"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="textcells_s" colspan="2">
                <asp:RadioButtonList ID="RBLAccessType" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem>FileType Wise Access</asp:ListItem>
                    <asp:ListItem Selected="True">File Wise Access</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="labelcells_s" rowspan="2" style="width: 61px">
                <asp:Label ID="Label17" runat="server" Text="Select Users"></asp:Label>
            </td>
            <td class="textcells">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="LnkSearch" runat="server" 
    CssClass="buttonc">Search</asp:LinkButton>
                        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" 
                    PopupControlID="pnlsearch" TargetControlID="lnksearch">
                        </cc1:ModalPopupExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="textcells_s">
                <asp:Panel ID="PnlUsers" runat="server" Height="160px" ScrollBars="Auto" 
                    Width="640px" BorderStyle="Double">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:CheckBoxList ID="chkUsers" runat="server" RepeatColumns="2">
                            </asp:CheckBoxList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="labelcells_s" style="width: 61px; height: 1px">
                <asp:Label ID="Label22" runat="server" Text="Select Actions"></asp:Label>
            </td>
            <td class="textcells_s" style="height: 1px">
                <table border="0" cellpadding="0" cellspacing="0" class="textcells" 
                    style="width:100%;">
                    <tr>
                        <td width="70px">
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:CheckBoxList ID="chkAction" runat="server">
                                        <asp:ListItem>Read</asp:ListItem>
                                        <asp:ListItem>Write</asp:ListItem>
                                        <asp:ListItem>Delete</asp:ListItem>
                                    </asp:CheckBoxList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="RbSelect" 
                                        EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                <ContentTemplate>
                                    <asp:RadioButtonList ID="RbSelect" runat="server" 
    AutoPostBack="True">
                                        <asp:ListItem>Select All</asp:ListItem>
                                        <asp:ListItem>Select None</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="labelcells_s" style="width: 61px; height: 18px">
                Select FileType</td>
            <td class="textcells_s" style="height: 18px">
                <asp:DropDownList ID="DDLFileType" runat="server" AutoPostBack="True" 
                    CssClass="combobox" Height="17px" Width="361px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells_s" style="width: 61px">
                <asp:Label ID="Label23" runat="server" Text="Select Files"></asp:Label>
            </td>
            <td class="textcells_s" style="height: 1px">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="GrdResult" runat="server" 
    AutoGenerateColumns="False" Width="640px"
                    BorderColor="#666666" BorderStyle="Solid" 
    BorderWidth="1px">
                            <Columns>
                                <asp:TemplateField HeaderText="Check">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAllFiles" runat="server" AutoPostBack="True" 
                                            oncheckedchanged="chkAllFiles_CheckedChanged" Text="Select All" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkFile" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Autofileno" HeaderText="DocRefNo" />
                                <asp:BoundField DataField="transno" HeaderText="Trans No" />
                                <asp:BoundField DataField="fileno" HeaderText="File No" />
                                <asp:TemplateField HeaderText="File Name">
                                    <ItemTemplate>
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblName" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                                                        Text='<%# eval("filename") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Image ID="Image1" runat="server" Height="16px" ImageUrl='<%# eval("img") %>'
                                                        Width="16px" />
                                                            <cc1:HoverMenuExtender ID="HoverMenuExtender1" runat="server" PopupControlID="Panel1"
                                                        TargetControlID="Image1">
                                                            </cc1:HoverMenuExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Panel ID="Panel1" runat="server" BorderStyle="Groove" BorderWidth="3px"  style="display:none"
                                                        CssClass="panelcells">
                                                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                    <ContentTemplate>
                                                                        <table style="width: 100%;">
                                                                            <tr>
                                                                                <td class="gridheader">
                                                                                    <asp:Label ID="Label25" runat="server" Text='<%# eval("filename") %>'></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl='<%# eval("img") %>' NavigateUrl='<%# eval("url") %>'
                                                                                Text='<%# eval("filename") %>'></asp:HyperLink>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="FileRefNo" HeaderText="FileRefNo" />
                                <asp:BoundField DataField="FileRefDate" HeaderText="FileRefDate" />
                                <asp:BoundField DataField="CreatedDt" HeaderText="CreatedDt" />
                                <asp:BoundField DataField="UploadBy" HeaderText="UploadBy" />
                                <asp:BoundField DataField="KeyInfo" HeaderText="KeyValue" />
                            </Columns>
                            <HeaderStyle CssClass="gridheader" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DDLFileType" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="2" style="height: 1px">
                        <asp:LinkButton ID="LnkSubmit" runat="server" 
    CssClass="buttonc">Submit</asp:LinkButton>
                        </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="2" style="height: 1px">
                        <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="True" Message="test" 
                         FadeInDuration="2" FadeInSteps="2" FadeOutDuration="4" FadeOutSteps="2" /></td>
        </tr>
        <tr>
            <td class="labelcells" colspan="2">
                <asp:Panel ID="PnlSearch" runat="server" BorderColor="#666666" 
                    BorderStyle="Outset" BorderWidth="1px" CssClass="panelcells">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table style="width:100%;">
                                <tr>
                                    <td align="center" class="gridheader" colspan="4">
                                        <asp:Label ID="Label18" runat="server" Text="Search Criteria"></asp:Label>
                                        &nbsp;(**Please provide required field data.)</td>
                                </tr>
                                <tr>
                                    <td class="labelcells">
                                        <asp:Label ID="Label19" runat="server" Text="Department"></asp:Label>
                                    </td>
                                    <td class="textcells" style="width: 177px">
                                        <asp:TextBox ID="txtDept" runat="server" CssClass="textbox" Width="158px"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ID="ACE1" runat="server" CompletionInterval="100" 
                                                    CompletionListCssClass="autocomplete_ListItem " ContextKey="ALL" 
                                                    MinimumPrefixLength="0" ServiceMethod="GetDepartment" 
                                                    ServicePath="WebService.asmx" TargetControlID="txtDept">
                                        </cc1:AutoCompleteExtender>
                                    </td>
                                    <td class="labelcells">
                                        <asp:Label ID="Label20" runat="server" Text="Role"></asp:Label>
                                    </td>
                                    <td class="textcells">
                                        <asp:TextBox ID="txtRole" runat="server" CssClass="textbox" Width="56px"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ID="ACE2" runat="server" CompletionInterval="100" 
                                                    CompletionListCssClass="autocomplete_ListItem " MinimumPrefixLength="0" 
                                                    ServiceMethod="GetRole" ServicePath="WebService.asmx" 
                                                    TargetControlID="txtRole">
                                        </cc1:AutoCompleteExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelcells">
                                        <asp:Label ID="Label21" runat="server" Text="User Name/EmpCode"></asp:Label>
                                    </td>
                                    <td class="textcells" style="width: 177px">
                                        <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" Width="168px"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ID="ACE3" runat="server" CompletionInterval="100" 
                                                    CompletionListCssClass="autocomplete_ListItem " MinimumPrefixLength="0" 
                                                    ServiceMethod="GetEmpNameCode" ServicePath="WebService.asmx" 
                                                    TargetControlID="txtEmployee">
                                        </cc1:AutoCompleteExtender>
                                    </td>
                                    <td class="labelcells">
                                        &nbsp;</td>
                                    <td class="textcells">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="buttonbackbar" colspan="4">
                                        <asp:LinkButton ID="LnkGet" runat="server" OnClick="LnkGet_Click" 
                                                    CssClass="buttonc">Get Names</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 61px">
                &nbsp;</td>
            <td class="textcells">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 61px">
                &nbsp;</td>
            <td class="textcells">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

