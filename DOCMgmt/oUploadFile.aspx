<%@ Page Language="VB" MasterPageFile="User_Screen.master" AutoEventWireup="false" CodeFile="UploadFile.aspx.vb" Inherits="UploadFile" title="Upload File" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        <table style="width: 719px;">
    <tr>
        <td class="tableheader" colspan="3">Upload File</td>
    </tr>
    <tr>
        <td colspan="3" align="left" class="buttonbackbar" style="text-align: left">
    
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                    <asp:LinkButton ID="cmdBack" runat="server" BorderStyle="None" 
                    CssClass="buttonc" Enabled="False">&lt;&lt; Back</asp:LinkButton>
                </ContentTemplate>
            </asp:UpdatePanel>
        
        </td>
    </tr>
    <tr>
        <td align="center" colspan="3" valign="top">
    
        <asp:Wizard ID="Wizard1" runat="server" Width="100%" BorderStyle="None" CellPadding="1" 
            CellSpacing="1" Font-Names="Tahoma" Font-Size="8pt" ActiveStepIndex="2" 
            OnFinishButtonClick="Wizard1_FinishButtonClick" DisplaySideBar="False">
            <StepStyle HorizontalAlign="Left" VerticalAlign="Top" />
            <StartNextButtonStyle CssClass="buttoncmd" />
            <FinishCompleteButtonStyle CssClass="buttoncmd" />
            <StepNextButtonStyle CssClass="buttoncmd" />
            <FinishPreviousButtonStyle CssClass="ButtonBack" />
            <WizardSteps>
                <asp:WizardStep runat="server" title="File Details" StepType="Start">
                    <table style="width: 100%;" cellpadding="1" cellspacing="1">
                        <tr>
                            <td class="labelcells" width="20%">
                                <asp:Label ID="Label1" runat="server" Text="File Type"></asp:Label>
                            </td>
                            <td class="textcells" colspan="3" width="30%">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtFileType" runat="server" AutoPostBack="True" 
                                            CssClass="textbox" Width="328px"></asp:TextBox>
                                        <asp:Button ID="BtnSrch" runat="server" CssClass="ButtonBack" Height="16px" 
                                            Visible="False" Width="19px" />
                                        <cc1:AutoCompleteExtender ID="ACECatg" runat="server" CompletionInterval="100" 
                                            CompletionListCssClass="autocomplete_ListItem " MinimumPrefixLength="0" 
                                            ServiceMethod="GetParentCatg" ServicePath="WebService.asmx" 
                                            TargetControlID="txtFileType">
                                        </cc1:AutoCompleteExtender>
                                        <cc1:ModalPopupExtender ID="MPSrch" runat="server" 
                                            BackgroundCssClass="modalBackground" PopupControlID="Panel3" 
                                            TargetControlID="BtnSrch">
                                        </cc1:ModalPopupExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr style="visibility: hidden; display: none">
                            <td colspan="4" style="visibility: hidden; display: none">
                                <asp:Panel ID="Panel3" runat="server">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:Table ID="Table1" runat="server" BorderStyle="Solid" BorderWidth="2px">
                                            </asp:Table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="labelcells" width="20%">
                                <asp:Label ID="Label6" runat="server" Text="Department"></asp:Label>
                            </td>
                            <td width="30%" colspan="3" style="width: 60%" class="textcells">
                                <asp:DropDownList ID="DrpDept" runat="server" CssClass="combobox" 
                                    Width="216px" Enabled="False">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="labelcells" width="20%">
                                <asp:Label ID="Label2" runat="server" Text="FileRefNo."></asp:Label>
                            </td>
                            <td width="30%" class="textcells">
                                <asp:TextBox ID="txtFileRef" runat="server" CssClass="textbox"></asp:TextBox>
                            </td>
                            <td class="labelcells" style="width: 16%">
                                <asp:Label ID="Label3" runat="server" Text="FileRefDate"></asp:Label>
                            </td>
                            <td width="30%" class="textcells">
                                <asp:TextBox ID="txtRefDate" runat="server" CssClass="textbox" Width="73px"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="Mid" runat="server" CultureAMPMPlaceholder="" 
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                    CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                    Mask="99/99/9999" MaskType="Date" TargetControlID="txtRefDate">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CE" runat="server" Enabled="True" Format="MM/dd/yyyy" 
                                    TargetControlID="txtRefDate">
                                </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="labelcells" width="20%">
                                <asp:Label ID="Label4" runat="server" Text="Key Info"></asp:Label>
                            </td>
                            <td colspan="3" style="width: 60%" class="textcells">
                                <asp:TextBox ID="txtKeyInfo" runat="server" Rows="2" 
                                    TextMode="MultiLine" Width="445px" Font-Names="Verdana" Font-Size="8pt" 
                                    Height="50px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="labelcells" width="20%" style="height: 1px">
                                <asp:Label ID="Label10" runat="server" Text="No. Of Pages"></asp:Label>
                            </td>
                            <td width="30%" style="height: 1px" class="textcells">
                                <asp:TextBox ID="txtPgNo" runat="server" CssClass="textbox" Width="75px" 
                                    MaxLength="3"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" 
                                    Enabled="True" FilterType="Numbers" TargetControlID="txtpgno" 
                                    ValidChars="0123456789">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td class="labelcells" style="width: 16%; height: 1px;">
                                <asp:Label ID="Label5" runat="server" Text="Privacy" Visible="False"></asp:Label>
                            </td>
                            <td width="30%" style="height: 1px" class="textcells">
                                <asp:DropDownList ID="DrpPrivacy" runat="server" CssClass="combobox" 
                                    Visible="False">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="display: none; visibility: hidden;">
                            <td class="labelcells" width="20%">
                                &nbsp;</td>
                            <td width="30%">
                                &nbsp;</td>
                            <td class="labelcells" style="width: 16%">
                                <asp:Label ID="Label11" runat="server" Text="Amt Involved" Visible="False"></asp:Label>
                            </td>
                            <td width="30%" class="textcells">
                                <asp:TextBox ID="txtAmt" runat="server" CssClass="textbox" Height="17px" 
                                    Width="62px" Visible="False">0</asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" 
                                    Enabled="True" FilterType="Numbers" TargetControlID="txtamt" 
                                    ValidChars="0123456789">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                        </tr>
                    </table>
                </asp:WizardStep>
                <asp:WizardStep runat="server" Title="FileDetails(Optional)">
                    
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    
                </asp:WizardStep>
                <asp:WizardStep runat="server" title="Upload File" StepType="Finish">
                    <table style="width:100%; ">
                        <tr>
                            <td class="labelcells" style="height: 23px">
                                <asp:Label ID="Label21" runat="server" Text="Select File"></asp:Label>
                            </td>
                            <td colspan="2" style="height: 23px">
                                <input ID="File2" runat="server" size="60" type="file"></input>
                            </input>
                                </input>
                            </td>
                        </tr>
                        <tr>
                            <td class="labelcells">
                                <asp:Label ID="Label14" runat="server" Text="Description"></asp:Label>
                            </td>
                            <td class="textcells">
                                <asp:TextBox ID="txtDesc" runat="server" CssClass="textbox" 
                                    Width="345px"></asp:TextBox>
                            </td>
                            <td width="20%" class="textcells">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="labelcells">
                                <asp:Label ID="Label15" runat="server" Text="Sequence"></asp:Label>
                            </td>
                            <td class="textcells">
                                <asp:TextBox ID="txtSeq" runat="server" CssClass="textbox" Width="45px"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" 
                                    Enabled="True" FilterType="Numbers" TargetControlID="txtSeq" 
                                    ValidChars="0123456789">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td class="textcells">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td valign="top" class="labelcells">
                                <asp:Label ID="Label22" runat="server" Text="Files Selected"></asp:Label>
                            </td>
                            <td class="textcells" valign="top">
                                
                                <asp:ListBox ID="ListBox1" runat="server" Width="440px">
                                    <asp:ListItem></asp:ListItem>
                                </asp:ListBox>
                                
                                </td>
                            <td valign="top" class="textcells">
                                &nbsp;</td>
                        </tr>
                        <tr>
                        <td class="buttonbackbar" colspan="3">
                            <asp:LinkButton ID="LnkAttach" runat="server" BorderStyle="None" 
                                CssClass="buttonc">Attach</asp:LinkButton>
                            <asp:LinkButton ID="LnkDel" runat="server" BorderStyle="None" 
                                CssClass="buttonc">Delete</asp:LinkButton>
                            <asp:LinkButton ID="LnkUpload" runat="server" CssClass="buttonc">Upload</asp:LinkButton>
                                    
                            <asp:LinkButton ID="LnkUpdate" runat="server" CssClass="buttonc" 
                                Enabled="False">Update</asp:LinkButton>
                                    
                        </td>
                        </tr>
                        <tr>
                            <td>
                                <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="True" 
                                    FadeInDuration="2" FadeInSteps="2" FadeOutDuration="4" FadeOutSteps="2" 
                                    Message="test" />
                            </td>
                            <td style="height: 1px;">
                                <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" 
                                    BackgroundCssClass="modalBackground" 
                                    DynamicServicePath="" Enabled="False" OkControlID="lnkupload" 
                                    PopupControlID="Panel4" TargetControlID="lnkupload" 
                                    CancelControlID="LnkCancel">
                                </cc1:ModalPopupExtender>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Panel ID="Panel4" runat="server" BorderColor="#666666" style="display:none"
                                    BorderStyle="Outset" BorderWidth="1px" CssClass="panelcells" Height="109px" 
                                    Visible="False" Width="80%" Wrap="False">
                                    <table style="width:100%;">
                                        <tr>
                                            <td align="center" style="width: 989px">
                                                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                                                    Font-Size="Medium" ForeColor="#0033CC" Width="415px"></asp:Label>
                                            </td>
                                            <td align="right" valign="top">
                                                <asp:LinkButton ID="LnkCancel" runat="server" CssClass="closebutton" 
                                                    Height="23px" Width="22px"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:Label ID="Label23" runat="server" ForeColor="#000066" 
                                                    Text="&quot;** Please Note this No. on Document. This file no. will be used in further transactions.&quot;"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                <asp:Label ID="Label16" runat="server" 
                                                    Text="** Total Number of Uploads By Me :-     "></asp:Label>
                                                <asp:Label ID="lblFileCount" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                <asp:Label ID="Label17" runat="server" Text="**  Total Files Uploaded By Me Today  :- "></asp:Label>
                                                <asp:Label ID="lblTodayFileCount" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 989px">
                                                &nbsp;</td>
                                            <td align="right" valign="top">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:WizardStep>
            </WizardSteps>
            <NavigationButtonStyle CssClass="buttoncmd" />
            <SideBarStyle HorizontalAlign="Left" VerticalAlign="Top" Width="17%" />
            <StepPreviousButtonStyle CssClass="buttoncmd" />
        </asp:Wizard>
        
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
        
</asp:Content>

