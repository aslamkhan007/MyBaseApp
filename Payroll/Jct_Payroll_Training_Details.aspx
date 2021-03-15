<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_Training_Details.aspx.cs" Inherits="Payroll_Jct_Payroll_Training_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td class="tableheader" colspan="4">
                Training Details:
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Employee Code:
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtEmpCode" runat="server" Style="text-transform: capitalize;" CssClass="textbox"
                            OnTextChanged="txtEmpCode_TextChanged" AutoPostBack="True" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmpCode"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                <asp:Label ID="SrCode" runat="server" Text="Sr No" Visible="False"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="SrId" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Type Of Training
            </td>
            <td class="labelcells" colspan="3" align="center">
                <asp:UpdatePanel ID="UpdatePanel31" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 448px">
                                    <asp:Panel ID="Panel7" runat="server">
                                        <asp:RadioButtonList ID="RadioButtonList5" runat="server" RepeatDirection="Horizontal"
                                            Width="504px" Height="34px" AutoPostBack="True">
                                            <asp:ListItem Selected="True">Educational Training</asp:ListItem>
                                            <asp:ListItem>Training in your previous experience</asp:ListItem>
                                            <asp:ListItem>Training from current Org.</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label7" runat="server" Width="191px">Training/Conference 
                                Name/Title</asp:Label>
            </td>
            <td class="textcells">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtTrainingName" runat="server" CssClass="textbox" MaxLength="70"
                            Width="221px" Height="35px" TextMode="MultiLine"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="TxtTrainingName"
                            WatermarkCssClass="watermark" WatermarkText="Write name of training/conference attended by you ">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtTrainingName"
                            ErrorMessage="*" SetFocusOnError="True" Width="16px"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                <asp:Label ID="Label36" runat="server" Height="16px" Width="95px">Area of 
                                Training</asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtArea" runat="server" CssClass="textbox" Height="35px" MaxLength="40"
                            TextMode="MultiLine" Width="220px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" TargetControlID="TxtArea"
                            WatermarkCssClass="watermark" WatermarkText="Give the name of area in which you have attended that training/conference">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtArea"
                            ErrorMessage="*" SetFocusOnError="True" Width="16px"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 27px">
                <asp:Label ID="Label42" runat="server" Width="179px" Height="16px">Name of 
                Organization/Institute</asp:Label>
            </td>
            <td class="labelcells">
                <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtOrg" runat="server" CssClass="textbox" MaxLength="100" Width="300px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender8" runat="server" WatermarkCssClass="watermark"
                            WatermarkText="Write name of the Organization where the training was held " TargetControlID="TxtOrg">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="TxtOrg"
                            ErrorMessage="*" SetFocusOnError="True" Width="16px" Height="16px"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells" style="width: 32px">
            </td>
            <td class="textcells" style="width: 1715px">
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 27px">
                <asp:Label ID="Label33" runat="server" Width="47px" Height="16px">Address</asp:Label>
            </td>
            <td class="labelcells" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtLocation" runat="server" CssClass="textbox" MaxLength="80" Width="258px"
                            Height="35px" TextMode="MultiLine"></asp:TextBox><cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1"
                                runat="server" WatermarkCssClass="watermark" WatermarkText="Give the location where the training/conference was attended"
                                TargetControlID="TxtLocation">
                            </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtLocation"
                            ErrorMessage="*" SetFocusOnError="True" Width="16px"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Country
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlcountry" runat="server" CssClass="combobox" Height="18px"
                            Width="64px">
                            <asp:ListItem Value="01">India</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                State
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtstate" runat="server" CssClass="textbox" MaxLength="30"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtState_AutoCompleteExtender" runat="server" CompletionInterval="10"
                    CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="Jct_Payroll_State_List"
                    CompletionListCssClass="AutoExtender" ServicePath="~/WebService.asmx" CompletionListElementID="divwidth"
                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListItemCssClass="AutoExtenderList"
                    TargetControlID="txtstate">
                </cc1:AutoCompleteExtender>
            </td>
            <tr>
                <td class="labelcells">
                    City
                </td>
                <td class="NormalText">
                    <asp:TextBox ID="txtcity" runat="server" CssClass="textbox" MaxLength="30"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="txtCity_AutoCompleteExtender" runat="server" CompletionInterval="10"
                        CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="Jct_Payroll_City_List"
                        CompletionListCssClass="AutoExtender" ServicePath="~/WebService.asmx" CompletionListElementID="divwidth"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListItemCssClass="AutoExtenderList"
                        TargetControlID="txtcity">
                    </cc1:AutoCompleteExtender>
                </td>
                <td class="labelcells">
                    Pin
                </td>
                <td class="NormalText">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="TxtPin" runat="server" Style="text-transform: capitalize;" CssClass="textbox"
                                AutoPostBack="True" MaxLength="6"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtPin"
                                ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtPin"
                                ErrorMessage="Enter 6 digit pincode" ValidationExpression="^[0-9]{6}$" ValidationGroup="A"></asp:RegularExpressionValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="labelcells">
                    From Date
                </td>
                <td class="NormalText">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="TxtFrom" runat="server" CssClass="textbox" Width="70px" MaxLength="10"></asp:TextBox>
                            <cc1:CalendarExtender ID="TxtFrom_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="TxtFrom">
                            </cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtFrom"
                                ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="labelcells">
                    To Date
                </td>
                <td class="NormalText">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="TxtTo" runat="server" CssClass="textbox" Width="70px" MaxLength="10"></asp:TextBox>
                            <cc1:CalendarExtender ID="TxtTo_CalendarExtender" runat="server" Enabled="True" TargetControlID="TxtTo">
                            </cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TxtTo"
                                ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="labelcells">
                    <asp:Label ID="Label39" runat="server" Height="16px" Width="90px">Faculty&#39;s Name</asp:Label>
                </td>
                <td style="width: 256px">
                    <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="TxtFacluty" runat="server" CssClass="textbox" MaxLength="70" Width="195px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" TargetControlID="TxtFacluty"
                                WatermarkCssClass="watermark" WatermarkText="Write the name of faculty here ">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtFacluty"
                                ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="labelcells">
                    <asp:Label ID="Label41" runat="server" Height="16px" Width="183px">Faculty&#39;s 
                                        Organization/Institute</asp:Label>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="TxtFaclutyOrg" runat="server" CssClass="textbox" MaxLength="70"
                                Width="211px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender7" runat="server" TargetControlID="TxtFaclutyOrg"
                                WatermarkCssClass="watermark" WatermarkText="From which Org. this Faculty come? ">
                            </cc1:TextBoxWatermarkExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="labelcells">
                    <asp:Label ID="Label43" runat="server" Height="16px" Width="47px">Address</asp:Label>
                </td>
                <td style="width: 256px">
                    <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="TxtFacultyAddress" runat="server" CssClass="textbox" Height="35px"
                                MaxLength="80" TextMode="MultiLine" Width="258px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender9" runat="server" TargetControlID="TxtFacultyAddress"
                                WatermarkCssClass="watermark" WatermarkText="Give the facluty's address">
                            </cc1:TextBoxWatermarkExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="labelcells">
                    <asp:Label ID="Label44" runat="server">Remarks Type</asp:Label>
                </td>
                <td class="labelcells">
                    <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="DrpRemarksType" runat="server" CssClass="combobox" Height="21px"
                                Width="103px" AutoPostBack="True">
                                <asp:ListItem>Grade</asp:ListItem>
                                <asp:ListItem>Percentage</asp:ListItem>
                                <asp:ListItem>Marks</asp:ListItem>
                                <asp:ListItem Selected="true">No Remarks</asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="labelcells">
                    <asp:Label ID="Label45" runat="server">Marks</asp:Label>
                </td>
                <td class="labelcells">
                    <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="TxtMarks" runat="server" Style="text-transform: capitalize;" CssClass="textbox"
                                AutoPostBack="True" MaxLength="8"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="labelcells">
                    Certified:
                </td>
                <td class="labelcells">
                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                        <ContentTemplate>
                            <asp:RadioButtonList ID="RadioCertification" runat="server" RepeatDirection="Horizontal"
                                Enabled="TRUE" AutoPostBack="True">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="labelcells">
                    <asp:Label ID="Label10" runat="server">Any Comments</asp:Label>
                </td>
                <td class="labelcells">
                    <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="TxtRemarks" runat="server" CssClass="textbox" MaxLength="80" Width="358px"
                                Height="35px" TextMode="MultiLine"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" runat="server" TargetControlID="TxtRemarks"
                                WatermarkCssClass="watermark" WatermarkText="Give the appropriate comments here">
                            </cc1:TextBoxWatermarkExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="buttonbackbar" colspan="4">
                    <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" ValidationGroup="A"
                        OnClick="lnkadd_Click">Add</asp:LinkButton>
                    <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" ValidationGroup="A"
                        OnClick="lnkupdate_Click" Enabled="False">Update</asp:LinkButton>
                    <asp:LinkButton ID="lnkdelete" runat="server" CssClass="buttonc" OnClick="lnkdelete_Click"
                        Enabled="False">Delete</asp:LinkButton>
                    <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="NormalText" colspan="4">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" Width="1000px">
                                <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True" Width="100%"
                                    OnSelectedIndexChanged="grdDetail_SelectedIndexChanged">
                                    <AlternatingRowStyle CssClass="GridAI" />
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <PagerStyle CssClass="PageStyle" />
                                    <RowStyle CssClass="GridItem" />
                                    <SelectedRowStyle CssClass="GridRowGreen" />
                                </asp:GridView>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
    </table>
</asp:Content>
