<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="SurveyMaster.aspx.vb" Inherits="SurveyMaster" Title="Upload Survey" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
    <%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%; height: 102%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label5" runat="server" Text="Survey Master" Width="328px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label1" runat="server" Text="Select Department" Width="112px"></asp:Label>
            </td>
            <td colspan="2" class="textcells">
                <asp:DropDownList ID="DepList" runat="server" Width="368px" Height="32px" AutoPostBack="True"
                    CssClass="combobox">
                </asp:DropDownList>
            </td>
            <td colspan="1" class="textcells">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label11" runat="server" Text="Select :-" Width="112px"></asp:Label>
            </td>
            <td colspan="3" class="textcells">
                <asp:RadioButton ID="OptionCreate" runat="server" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="Black" GroupName="Sel" TabIndex="1" Text="Create Survey"
                    Width="108px" AutoPostBack="True" Checked="True" /><asp:RadioButton ID="OptionUpload"
                        runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black"
                        GroupName="sel" TabIndex="1" Text="Upload Result" Width="101px" 
                    AutoPostBack="True" /><asp:RadioButton
                            ID="OptionAddQuest" runat="server" Font-Bold="True" 
                    Font-Names="Tahoma" Font-Size="8pt"
                            ForeColor="Black" GroupName="sel" TabIndex="1" Text="Add Question To Existing Survey / Result"
                            Width="251px" AutoPostBack="True" />
                <asp:RadioButton
                            ID="OptionEdit" runat="server" Font-Bold="True" 
                    Font-Names="Tahoma" Font-Size="8pt"
                            ForeColor="Black" GroupName="sel" TabIndex="1" Text="Edit "
                            Width="54px" AutoPostBack="True" style="height: 20px" />
            </td>
        </tr>
        <tr id="update">
            <td class="labelcells" colspan="4">
                <asp:Panel ID="Panel1" runat="server">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="Y">Update Question/asp</asp:ListItem>
                        <asp:ListItem Value="N">Don't Update Question</asp:ListItem>
                    </asp:RadioButtonList>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Survey Subject" Width="112px"></asp:Label>
            </td>
            <td colspan="2" class="textcells">
                <asp:TextBox ID="txtSubject" runat="server" MaxLength="100" CssClass="textbox" Width="563px"
                    Wrap="False"></asp:TextBox><br />
                <asp:DropDownList ID="CboQuestions" runat="server" CssClass="combobox" AutoPostBack="True"
                    Visible="False" Width="376px">
                </asp:DropDownList>
            </td>
            <td colspan="1" valign="top" class="textcells">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label2" runat="server" Text="Survey Question" class="labelcells"></asp:Label>
            </td>
            <td colspan="3" class="textcells">
                <asp:TextBox ID="TxtSurveyQuest" CssClass="textbox" runat="server" MaxLength="300"
                    Width="726px" Wrap="False" Height="17px"></asp:TextBox><br />
                <asp:ListBox ID="LstMultiQuest" runat="server" Visible="False" Width="724px" 
                    AutoPostBack="True"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label14" runat="server" 
                    Text="Are the Remarks required for all options of this Question?" 
                    class="labelcells" Width="228px"></asp:Label>
            </td>
            <td colspan="2" class="textcells">
                <asp:RadioButtonList ID="RadioRemarksQuestion" runat="server" 
                    AutoPostBack="True" RepeatDirection="Horizontal">
                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                    <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td colspan="1" class="textcells">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label12" runat="server" Text="Select Category" 
                    class="labelcells"></asp:Label>
            </td>
            <td colspan="2" class="textcells">
                <asp:Button ID="BtnNewQuest" runat="server" CssClass="ButtonBack" Text="Add New Question"
                    Visible="False" />
            &nbsp;
                <asp:RadioButtonList ID="RblQnType" runat="server" BorderStyle="Solid" 
                    BorderWidth="1px" RepeatDirection="Horizontal" RepeatLayout="Flow" 
                    ToolTip="Select Question Category">
                    <asp:ListItem Selected="True">Single Selection</asp:ListItem>
                    <asp:ListItem>Multiple Selection</asp:ListItem>
                    <asp:ListItem>Ranking</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td colspan="1" class="textcells">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label9" runat="server" Text="Options To Select From (Atleast 2) each Question"
                    ToolTip="Set this Flag to Yes if You Don't want to show the result to the person who is posting reply to this survey"
                    Width="104px"></asp:Label>
            </td>
            <td colspan="2" class="textcells">
                <asp:TextBox ID="TxtChoice" runat="server" MaxLength="100" Width="368px" Wrap="False"
                    ToolTip="This option will alow you to add multiple answers out of which user will select its particular choice"
                    CssClass="textbox"></asp:TextBox>
            </td>
            <td colspan="1" class="textcells">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label13" runat="server" 
                    Text="Are the Remarks required for this Option?" class="labelcells" 
                    Width="218px"></asp:Label>
            </td>
            <td colspan="2" class="textcells">
                <asp:RadioButtonList ID="RadioRemarksOption" runat="server" AutoPostBack="True" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                    <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td colspan="1" class="textcells">
                <asp:Button ID="BtnAddParameter" runat="server" CssClass="ButtonBack" Text="Add Options" BorderColor="Black" />
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td colspan="2" class="textcells">
                <asp:ListBox ID="LstChoiceList" runat="server" Visible="False" Width="351px" 
                    AutoPostBack="True"></asp:ListBox>
            </td>
            <td colspan="1" class="textcells">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label3" runat="server" Text="Attach Image(if Any)"></asp:Label>
            </td>
            <td colspan="2" valign="top" class="textcells">
                <asp:FileUpload ID="FileUpload1" runat="server" Height="22px" Width="318px" CssClass="textbox" /><br />
                <asp:HyperLink ID="ImgNameLbL" runat="server" Visible="False" Width="376px">Image Name</asp:HyperLink>
            </td>
            <td valign="top" class="textcells">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label4" runat="server" Text="Survey Last Date"></asp:Label>
            </td>
            <td valign="top" class="textcells" style="width: 498px">
                <strong>&nbsp;<ew:CalendarPopup ID="txtlastdate" runat="server" BackColor="WhiteSmoke" Culture="English (United Kingdom)"
                                Text="..." Width="66px" Font-Names="Tahoma" Font-Size="8pt">
                                <ClearDateStyle BackColor="#E0E0E0" />
                                <DayHeaderStyle BackColor="OrangeRed" />
                                <MonthYearSelectedItemStyle BackColor="Silver" />
                                <TodayDayStyle BackColor="#FFC0C0" />
                                <MonthHeaderStyle BackColor="Gray" />
                                <GoToTodayStyle BackColor="#E0E0E0" />
                            </ew:CalendarPopup>
                            </strong>
            </td>
            <td class="labelcells">
                <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="*   Survey Duration 30 Days (By Default)"></asp:Label>
            </td>
            <td class="textcells">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label7" runat="server" Text="Confidential" ToolTip="Set this Flag to Yes if You Don't want to show the result to the person who is posting reply to this survey"
                    Width="104px"></asp:Label>
            </td>
            <td class="textcells" style="width: 498px">
                <asp:DropDownList ID="DrpConfidential" runat="server" Height="40px"
                    ToolTip="Set this Flag to Yes if You Don't want to show the result to the person who is posting reply to this survey"
                    Width="128px" CssClass="combobox">
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="textcells">
            </td>
            <td class="textcells">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="lblComents" runat="server" Text="Comments" ToolTip="Set this Flag to Yes if You Don't want to show the result to the person who is posting reply to this survey"
                    Width="104px" Visible="False"></asp:Label>
            </td>
            <td  class="textcells" style="width: 498px">
                <asp:TextBox ID="txtReason" runat="server" cssclass="textbox" MaxLength="200" ToolTip="Give Reason For Rejection ??" Visible="False" Width="368px"></asp:TextBox>
            </td>
            <td class="textcells" colspan="2">
            </td>
        </tr>
        <tr>
            <td class="labelcells" colspan="4" >
                <asp:Button ID="AuthBtn" runat="server" CssClass="ButtonBack" Text="Accept Authrization"
                    Visible="False" Width="117px" BackColor="Black"/>
            &nbsp;<asp:Button ID="CancelAuthBtn" runat="server" CssClass="ButtonBack" Text="Reject Authrization"
                    Visible="False" Width="128px" />
            </td>
        </tr>
        <tr class="buttonbackbar">
            <td colspan="4">
                <asp:Button ID="ApplyBtn" runat="server" Text="Apply" CssClass="ButtonBack" 
                    BackColor="Black" style="height: 26px" />
                <asp:Button ID="CancleBtn" runat="server" Text="Reset"  CssClass="ButtonBack" BackColor="Black" />
            </td>
        </tr>
        <tr class="buttonbackbar">
            <td colspan="4">
                   <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" 
                            EnableViewState="true" FadeInDuration="2" FadeInSteps="2" FadeOutDuration="4" 
                            FadeOutSteps="2" Visible="true" /></td>
        </tr>
    </table>
</asp:Content>
