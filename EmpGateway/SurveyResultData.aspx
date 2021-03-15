<%@ Page Title="" Language="VB" MasterPageFile="~/EmpGateway/MasterPage.master" AutoEventWireup="false"
    CodeFile="SurveyResultData.aspx.vb" Inherits="EmpGateway_SurveyResultData" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr class="tableheader">
            <td colspan="4">
                <asp:Label ID="Label16" runat="server" Text="Survey Detailed  Result"></asp:Label>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <br />
                <cc1:TabContainer ID="HeaderStyle" runat="server" ActiveTabIndex="0" CssClass="ajax__tab_technorati-theme"
                    Width="100%" Height="164px">
                    <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1" Width="100px"
                        Height="200px" Visible="true">
                        <HeaderTemplate>
                            Basic Parameters
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table style="width: 100%;">
                                <tr>
                                    <td class="labelcells">
                                        <asp:Label ID="lbl_Survey" runat="server" CssClass="labelcells" Text="Survey"></asp:Label>
                                    </td>
                                    <td class="textcells">
                                        <asp:DropDownList ID="ddl_Survey" runat="server" AutoPostBack="True" CssClass="combobox"
                                            DataTextField="subject" Width="300px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelcells">
                                        <asp:Label ID="lbl_Quest" runat="server" CssClass="labelcells" Text="Question"></asp:Label>
                                    </td>
                                    <td class="textcells">
                                        <table>
                                            <tr>
                                                <td class="textcells">
                                                    <asp:UpdatePanel ID="UpdatePanel_Quest" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txt_Quest" runat="server" CssClass="textbox" ReadOnly="True" TextMode="MultiLine"
                                                                Width="299px" Height="40px"></asp:TextBox>
                                                            <asp:LinkButton ID="lnk_Quest" runat="server" Text="Click" BorderStyle="None" CssClass="buttondisable"
                                                                Enabled="True"></asp:LinkButton>
                                                            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground"
                                                                PopupControlID="pnl_grd" RepositionMode="None" TargetControlID="lnk_Quest" CancelControlID="lnk_Close">
                                                            </cc1:ModalPopupExtender>
                                                            <asp:TextBox ID="txt_QuestNo" runat="server" Visible="False" CssClass="textbox"></asp:TextBox>
                                                            <asp:Panel ID="pnl_grd" runat="server" CssClass="panelcells" BackColor="White" Height="200px"
                                                                ScrollBars="Auto" Width="751px" Style="display: none">
                                                                <table style="width: 100%;">
                                                                    <tr>
                                                                        <td class="textcells">
                                                                            <asp:Label ID="Label1" runat="server" Text="Select Question"></asp:Label>
                                                                        </td>
                                                                        <td class="textcells">
                                                                            <asp:LinkButton ID="lnk_Close" runat="server" BorderStyle="None" CssClass="closebutton"
                                                                                Height="23px" Width="23px"></asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td rowspan="2" class="textcells">
                                                                            <asp:GridView ID="grd_Quest" runat="server" CellPadding="4" HeaderStyle-CssClass="HeaderStyle"
                                                                                CssClass="GridViewStyle" GridLines="None" Width="711px" Height="50px">
                                                                                <Columns>
                                                                                    <asp:CommandField ShowSelectButton="True" />
                                                                                </Columns>
                                                                                <HeaderStyle CssClass="HeaderStyle" />
                                                                                <PagerStyle CssClass="PagerStyle" />
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="textcells">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelcells">
                                        <asp:Label ID="lbl_Parameter" runat="server" Text="Parameter"></asp:Label>
                                    </td>
                                    <td class="textcells">
                                        <asp:UpdatePanel ID="UpdatePanel_Parameter" runat="server" 
                                            UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddl_Parameter" runat="server" CssClass="combobox" Width="300px">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="grd_Quest" 
                                                    EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Advanced Parameters">
                        <HeaderTemplate>
                            Advanced Parameters
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table style="width: 100%;">
                                <tr>
                                    <td class="labelcells">
                                        <asp:Label ID="lbl_Format" runat="server" Text="Format"></asp:Label>
                                    </td>
                                    <td class="textcells">
                                        <asp:UpdatePanel ID="UpdatePanel_Format" runat="server" 
                                            UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:RadioButtonList ID="rbl_Format" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                                    Width="100px" CssClass="textbox">
                                                    <asp:ListItem>Chart</asp:ListItem>
                                                    <asp:ListItem>Data</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="labelcells">
                                        <asp:Label ID="lbl_Area" runat="server" Text="Area"></asp:Label>
                                    </td>
                                    <td class="textcells">
                                        <asp:UpdatePanel ID="UpdatePanel_Area" runat="server">
                                            <ContentTemplate>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" runat="server" TargetControlID="txt_Area"
                                                    WatermarkCssClass="watermark" WatermarkText="ALL">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:TextBox ID="txt_Area" runat="server" CssClass="textbox"></asp:TextBox>
                                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender6" runat="server" CompletionListCssClass="autocomplete_ListItem"
                                                    ServiceMethod="GetArea" ServicePath="~/WebService.asmx" TargetControlID="txt_Area"
                                                    DelimiterCharacters="" Enabled="True" MinimumPrefixLength="0">
                                                </cc1:AutoCompleteExtender>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelcells">
                                        <asp:Label ID="lbl_Company" runat="server" Text="Company"></asp:Label>
                                    </td>
                                    <td class="textcells">
                                        <asp:TextBox ID="txt_Company" runat="server" CssClass="textbox"></asp:TextBox>
                                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender8" runat="server" 
                                            TargetControlID="txt_Company" WatermarkCssClass="watermark" 
                                            WatermarkText="ALL" Enabled="True">
                                        </cc1:TextBoxWatermarkExtender>
                                    </td>
                                    <td class="labelcells">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="lbl_Employee" runat="server" Text="Employee"></asp:Label></ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="textcells">
                                        <asp:UpdatePanel ID="UpdatePanel_Employee" runat="server">
                                            <ContentTemplate>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender7" runat="server" TargetControlID="txt_Employee"
                                                    WatermarkCssClass="watermark" WatermarkText="ALL">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:TextBox ID="txt_Employee" runat="server" CssClass="textbox"></asp:TextBox><cc1:AutoCompleteExtender
                                                    ID="AutoCompleteExtender7" runat="server" CompletionListCssClass="autocomplete_ListItem"
                                                    ServiceMethod="GetEmployeeName" ServicePath="~/WebService.asmx" TargetControlID="txt_Employee"
                                                    MinimumPrefixLength="0">
                                                </cc1:AutoCompleteExtender>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelcells">
                                        <asp:Label ID="lbl_Division" runat="server" Text="Division"></asp:Label>
                                    </td>
                                    <td class="textcells">
                                        <asp:UpdatePanel ID="UpdatePanel_Division" runat="server">
                                            <ContentTemplate>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txt_Division"
                                                    WatermarkCssClass="watermark" WatermarkText="ALL">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:TextBox ID="txt_Division" runat="server" CssClass="textbox"></asp:TextBox><cc1:AutoCompleteExtender
                                                    ID="AutoCompleteExtender1" runat="server" CompletionListCssClass="autocomplete_ListItem"
                                                    MinimumPrefixLength="0" ServiceMethod="GetDiv" ServicePath="~/WebService.asmx"
                                                    TargetControlID="txt_Division" CompletionSetCount="5" DelimiterCharacters=""
                                                    Enabled="True">
                                                </cc1:AutoCompleteExtender>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelcells">
                                        <asp:Label ID="lbl_Department" runat="server" Text="Department"></asp:Label>
                                    </td>
                                    <td class="textcells">
                                        <asp:UpdatePanel ID="Updatepanel_Department" runat="server">
                                            <ContentTemplate>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" TargetControlID="txt_Department"
                                                    WatermarkCssClass="watermark" WatermarkText="ALL">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:TextBox ID="txt_Department" runat="server" CssClass="textbox"></asp:TextBox><cc1:AutoCompleteExtender
                                                    ID="AutoCompleteExtender3" runat="server" CompletionListCssClass="autocomplete_ListItem"
                                                    ContextKey="All" DelimiterCharacters="" Enabled="True" MinimumPrefixLength="0"
                                                    ServiceMethod="GetDepartment" ServicePath="~/WebService.asmx" TargetControlID="txt_Department">
                                                </cc1:AutoCompleteExtender>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="labelcells">
                                        <asp:Label ID="lbl_ParentDeptt" runat="server" Text="Parent Deptt."></asp:Label>
                                    </td>
                                    <td class="textcells">
                                        <asp:UpdatePanel ID="Updatepanel_ParentDeptt" runat="server">
                                            <ContentTemplate>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txt_ParentDeptt"
                                                    WatermarkCssClass="watermark" WatermarkText="ALL">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:TextBox ID="txt_ParentDeptt" runat="server" CssClass="textbox"></asp:TextBox><cc1:AutoCompleteExtender
                                                    ID="AutoCompleteExtender2" runat="server" CompletionListCssClass="autocomplete_ListItem"
                                                    DelimiterCharacters="" Enabled="True" MinimumPrefixLength="0" ServiceMethod="GetParentDepartment"
                                                    ServicePath="~/WebService.asmx" TargetControlID="txt_ParentDeptt">
                                                </cc1:AutoCompleteExtender>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelcells">
                                        <asp:Label ID="lbl_Designation" runat="server" Text="Designation"></asp:Label>
                                    </td>
                                    <td class="textcells">
                                        <asp:UpdatePanel ID="Updatepanel_Designation" runat="server">
                                            <ContentTemplate>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" TargetControlID="txt_Designation"
                                                    WatermarkCssClass="watermark" WatermarkText="ALL">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:TextBox ID="txt_Designation" runat="server" CssClass="textbox"></asp:TextBox><cc1:AutoCompleteExtender
                                                    ID="AutoCompleteExtender4" runat="server" CompletionListCssClass="autocomplete_ListItem"
                                                    DelimiterCharacters="" Enabled="True" MinimumPrefixLength="0" ServiceMethod="GetDesg"
                                                    ServicePath="~/WebService.asmx" TargetControlID="txt_Designation">
                                                </cc1:AutoCompleteExtender>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="labelcells">
                                        <asp:Label ID="lbl_Category" runat="server" Text="Category"></asp:Label>
                                    </td>
                                    <td class="textcells">
                                        <asp:UpdatePanel ID="Updatepanel_Category" runat="server">
                                            <ContentTemplate>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" TargetControlID="txt_Category"
                                                    WatermarkCssClass="watermark" WatermarkText="ALL">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:TextBox ID="txt_Category" runat="server" CssClass="textbox"></asp:TextBox><cc1:AutoCompleteExtender
                                                    ID="AutoCompleteExtender5" runat="server" CompletionListCssClass="autocomplete_ListItem"
                                                    ContextKey="All" DelimiterCharacters="" Enabled="True" MinimumPrefixLength="0"
                                                    ServiceMethod="GetCatg" ServicePath="~/WebService.asmx" TargetControlID="txt_Category">
                                                </cc1:AutoCompleteExtender>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
            </td>
        </tr>
        <tr class="buttonbackbar">
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                     <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                     <asp:Image ID="ProgressBar" runat="server" Height="10px" Width="70px" ImageUrl="~/Image/loading.gif">
                        </asp:Image><br />
                        Please wait...
                    </ProgressTemplate>
                </asp:UpdateProgress>
                   
                    
                        <asp:LinkButton runat="server" BorderStyle="None" CssClass="buttonc" Height="20px"
                            ID="lnk_View" OnClick="lnk_View_Click">View</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Width="100%" CssClass="panelbg" BorderStyle="None"
                            ScrollBars="Auto" Height="300px">
                            <asp:GridView ID="GrdData" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                                Width="750px">
                                <Columns>
                                    <asp:TemplateField HeaderText="Employee Name">
                                        <ItemTemplate>
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td class="labelcells">
                                                        <asp:Label ID="lblName" runat="server" Text='<%# eval("fullname") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="HoverMenu">
                                                        <cc1:HoverMenuExtender ID="HoverMenuExtender1" runat="server" PopupControlID="PnlHover"
                                                            PopupPosition="Right" TargetControlID="lblName">
                                                        </cc1:HoverMenuExtender>
                                                        <asp:Panel ID="PnlHover" runat="server" BorderStyle="Groove" BorderWidth="2px" CssClass="panelcells"
                                                            Width="250px">
                                                            <table style="width: 100%;">
                                                                <tr>
                                                                    <td class="GridHeader" colspan="3">
                                                                        <asp:Label ID="Label18" runat="server" Text='<%# eval("fullname") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="labelcells" width="100px">
                                                                        <asp:Label ID="Label19" runat="server" Text="Department :"></asp:Label>
                                                                    </td>
                                                                    <td class="textcells">
                                                                        <asp:Label ID="Label21" runat="server" Text='<%# eval("Dept") %>'></asp:Label>
                                                                    </td>
                                                                    <td class="textcells" rowspan="10">
                                                                        <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl='<%# eval("imgURL") %>'
                                                                            Width="75px" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="labelcells" width="100px">
                                                                        <asp:Label ID="Label20" runat="server" Text="Designation :"></asp:Label>
                                                                    </td>
                                                                    <td class="textcells">
                                                                        <asp:Label ID="Label22" runat="server" Text='<%# eval("Desg") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="labelcells" width="100px">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td class="textcells">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="labelcells" width="100px">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td class="textcells">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="parameter" HeaderText="Parameter" />
                                    <asp:BoundField DataField="Rating" HeaderText="Rating" />
                                    <asp:BoundField DataField="Comments" HeaderText="Comments" />
                                </Columns>
                                <PagerStyle CssClass="PagerStyle" />
                                <EmptyDataTemplate>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td class="labelcells">
                                                <asp:Label ID="lbl_Deptt" runat="server" CssClass="labelcells" Text="No Record Found"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <EditRowStyle CssClass="EditRowStyle" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnk_View" EventName="Click" />
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
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
