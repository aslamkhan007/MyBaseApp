<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Blog.aspx.vb" Inherits="Blog" MaintainScrollPositionOnPostback="true"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table style="width: 100%; height: 200px;" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 250px; vertical-align: top;">
                <table cellpadding="0" cellspacing="0" style="width: 100%; height: 200px;" __designer:mapid="be">
                    <tr __designer:mapid="bf">
                        <td style="background-position: right -4px; width: 28px; background-image: url('Image/Frame/Frame_Left.png');
                            background-repeat: no-repeat;" rowspan="6" __designer:mapid="c0">
                        </td>
                        <td valign="middle" __designer:mapid="c1" class="frameheader">
                            <asp:Label ID="Label20" runat="server" Style="font-weight: 700" Text="Blogs"></asp:Label>
                        </td>
                        <td style="background-image: url('Image/Frame/Frame_Right.png'); background-repeat: no-repeat;
                            background-position: left -4px; width: 28px;" rowspan="6" 
                            __designer:mapid="c3">
                        </td>
                    </tr>
                    <tr __designer:mapid="c4">
                        <td style="background-position: center top; background-repeat: no-repeat; background-image: url('Image/Plain_Footer.png');"
                            valign="top" __designer:mapid="c5">
                            <asp:DataList ID="dlsLeft" runat="server" CellPadding="0" RepeatColumns="1" RepeatDirection="Horizontal"
                                HorizontalAlign="Left" Width="100%" Height="16px" CssClass="NormalText">
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" style="width: 100%;">
                                        <tr>
                                            <td valign="middle">
                                                <asp:HyperLink ID="HlinkTopic" runat="server" NavigateUrl='<%# eval("PostUrl") %>'
                                                    Text='<%# eval("Topic") %>'>
                                                </asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <asp:Label ID="LblKeywords" runat="server" Text='<%# eval("Keywords") %>'></asp:Label>
                                                <br />
                                                <asp:HyperLink ID="HlinkReadMore" runat="server" ForeColor="#333333" NavigateUrl='<%# eval("PostUrl") %>'>Read More..</asp:HyperLink>
                                                <hr />
                                            </td>
                                        </tr>
                                    </table>
                                    <%--<div class = "NormalText" style="height: 43px; width: 100%; text-align: left;">--%>
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                    </tr>
                    <tr __designer:mapid="c9">
                        <td style="background-position: left top; height: 30px; background-image: url('Image/Frame/Frame_Bottom.png');
                            background-repeat: no-repeat;" __designer:mapid="ca">
                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                        <ContentTemplate>
                                                            <asp:LinkButton ID="HlinkPostBlog" runat="server" EnableTheming="True" CssClass="buttonc">Post Blog</asp:LinkButton>
                                                            <cc1:ModalPopupExtender ID="MPE1" runat="server" BackgroundCssClass="modalBackground"
                                                                CancelControlID="LnkPostCancel" PopupControlID="PnlBlogPost" TargetControlID="HlinkPostBlog">
                                                            </cc1:ModalPopupExtender>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="vertical-align: top; text-align: left;">
                <table cellpadding="0" cellspacing="0" style="width: 100%; height: 190px;" class="NormalText"
                    __designer:mapid="4b">
                    <tr __designer:mapid="4c">
                        <td style="background-position: right -4px; width: 28px; background-image: url('Image/Frame/Frame_Left.png');
                            background-repeat: no-repeat;" rowspan="6" __designer:mapid="4d">
                        </td>
                        <td valign="middle" colspan="2" __designer:mapid="4e" class="frameheader">
                            <asp:Label ID="LblHeading" runat="server"></asp:Label>
                        </td>
                        <td style="background-image: url('Image/Frame/Frame_Right.png'); background-repeat: no-repeat;
                            background-position: left -4px; width: 28px;" rowspan="6" __designer:mapid="51">
                        </td>
                    </tr>
                    <tr __designer:mapid="52">
                        <td style="background-position: center top; background-repeat: no-repeat; background-image: url('Image/Plain_Footer.png');
                            vertical-align: top;" colspan="2" __designer:mapid="53">
                            <table cellpadding="0" cellspacing="0" style="background-position: center top; width: 100%;
                                height: 140px; vertical-align: top; background-image: url('Image/Plain_Footer.png');
                                background-repeat: no-repeat;" frame="void" __designer:mapid="54">
                                <tr __designer:mapid="55">
                                    <td style="vertical-align: top; height: 100%;" __designer:mapid="56">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td class="labelcells" colspan="2">
                                                    <asp:Label ID="Label6" runat="server" ForeColor="Gray" Text="Posted By:  "></asp:Label>
                                                    <asp:Label ID="LblPostBy" runat="server" ForeColor="Gray"></asp:Label>
                                                </td>
                                                <td class="labelcells" colspan="2">
                                                    <asp:Label ID="Label7" runat="server" ForeColor="Gray" Text="Posted On:   "></asp:Label>
                                                    <asp:Label ID="LblPostedOn" runat="server" ForeColor="Gray"></asp:Label>
                                                    <asp:Label ID="LblBlog" runat="server" ForeColor="Gray" Visible="False"></asp:Label>
                                                    <asp:Literal ID="LtlTrans" runat="server" Visible="False"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" ForeColor="Gray" Text="Hits: "></asp:Label>
                                                    <asp:Label ID="lblHits" runat="server" ForeColor="Gray"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label9" runat="server" ForeColor="Gray" Text="Rated:"></asp:Label>
                                                                        <cc1:Rating ID="Rating2" runat="server" AutoPostBack="True" BehaviorID="Rating2_RatingExtender"
                                                                            CssClass="ratingStar" Direction="LeftToRight" 
                                                        EmptyStarCssClass="Empty" FilledStarCssClass="Filled"
                                                                            Height="16px" StarCssClass="ratingItem" WaitingStarCssClass="Saved" 
                                                                            Width="66px">
                                                                        </cc1:Rating>
                                                    <asp:Label ID="lblRating" runat="server" ForeColor="Gray"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label10" runat="server" ForeColor="Gray" Text="Comments: "></asp:Label>
                                                    <asp:Label ID="lblComments" runat="server" ForeColor="Gray"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <hr />
                                                    <asp:TextBox ID="lblArticle" runat="server" BorderStyle="None" 
                                                        ForeColor="#666666" Height="273px" ReadOnly="True" TextMode="MultiLine" 
                                                        Width="100%"></asp:TextBox>
                                                    <hr />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td width="35px" style="height: 3px">
                                                                <asp:Label ID="Label11" runat="server" Text="Rate" ForeColor="#666666"></asp:Label>
                                                            </td>
                                                            <td width="80px" style="height: 3px">
                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                    <ContentTemplate>
                                                                        <cc1:Rating ID="Rating1" runat="server" AutoPostBack="True" BehaviorID="Rating1_RatingExtender"
                                                                            CssClass="ratingStar" Direction="LeftToRight" EmptyStarCssClass="Empty" FilledStarCssClass="Filled"
                                                                            Height="16px" StarCssClass="ratingItem" WaitingStarCssClass="Saved" Width="66px">
                                                                        </cc1:Rating>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                            <td width="100px" style="height: 3px">
                                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                    <ContentTemplate>
                                                                        <cc1:ModalPopupExtender ID="MPE2" runat="server" BackgroundCssClass="modalBackground"
                                                                            CancelControlID="LnkCmntCancel" PopupControlID="PnlCommentAdd" TargetControlID="lnkAddComment">
                                                                        </cc1:ModalPopupExtender>
                                                                        <asp:LinkButton ID="lnkAddComment" runat="server">Add Comment</asp:LinkButton>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                            <td style="height: 3px">
                                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:LinkButton ID="lnkViewComments" runat="server">View Comments</asp:LinkButton>
                                                                        <cc1:ModalPopupExtender ID="MPE3" runat="server" BackgroundCssClass="modalBackground"
                                                                            CancelControlID="LnkVwCancel" PopupControlID="Panel1" 
                                                                            TargetControlID="lnkViewComments">
                                                                        </cc1:ModalPopupExtender>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                <asp:Panel ID="PnlBlogPost" runat="server" BorderColor="#333333" BorderStyle="Solid"
                                                        Width="650px" style="display:none">
                                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                            <ContentTemplate>
                                                                <table style="width: 100%;" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="GridHeader">
                                                                            <asp:Label ID="Label12" runat="server" Text="Blog Posting"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table style="width: 100%; background-position: center top; width: 100%; height: 140px;
                                                                    vertical-align: top; background-image: url('Image/Plain_Footer.png'); background-repeat: no-repeat;
                                                                    background-color: #FFFFFF;">
                                                                    <tr>
                                                                        <td class="labelcells">
                                                                            <asp:Label ID="Label13" runat="server" Text="Title" ToolTip="Subject of BlogPost"></asp:Label>
                                                                        </td>
                                                                        <td class="textcells" colspan="3">
                                                                            <asp:TextBox ID="txtCrTitle" runat="server" CssClass="textbox" MaxLength="200" ToolTip="Subject of BlogPost"
                                                                                Width="535px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="labelcells">
                                                                            <asp:Label ID="Label14" runat="server" Text="Brief" 
                                                                                ToolTip="To be displayed in left pane with Heading"></asp:Label>
                                                                        </td>
                                                                        <td class="textcells" colspan="3">
                                                                            <asp:TextBox ID="txtCrKeywrds" runat="server" CssClass="textbox" MaxLength="200"
                                                                                ToolTip="To be displayed in left pane with Heading" Width="538px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="labelcells">
                                                                            <asp:Label ID="Label15" runat="server" Text="Detail"></asp:Label>
                                                                        </td>
                                                                        <td class="textcells" colspan="3">
                                                                            <asp:TextBox ID="txtCrDetail" runat="server" BorderColor="#333333" BorderStyle="Groove"
                                                                                CssClass="textbox" Height="270px" MaxLength="25000" TextMode="MultiLine" Width="544px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="labelcells">
                                                                            <asp:Label ID="Label16" runat="server" Text="Identity" ToolTip="Do you want to disclose your identity? i.e. everyone can view your name with your post?"></asp:Label>
                                                                        </td>
                                                                        <td class="textcells">
                                                                            <asp:DropDownList ID="DDLIdentity" runat="server" CssClass="combobox" ToolTip="Do you want to disclose your identity? i.e. everyone can view your name with your post?">
                                                                                <asp:ListItem Value="N">Disclose</asp:ListItem>
                                                                                <asp:ListItem Value="Y">Anonymous</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td class="labelcells" width="60px">
                                                                            <asp:Label ID="Label17" runat="server" Text="EffectiveTill"></asp:Label>
                                                                        </td>
                                                                        <td class="textcells">
                                                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="txtEffTill" runat="server" AccessKey="d" CssClass="textbox" Enabled="False"
                                                                                        MaxLength="8" onMouseover="showhint('Please fill the date in MM/DD/YYYY 08/24/2009', this, event, '150px')"
                                                                                        TabIndex="3" Width="70px"></asp:TextBox>
                                                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False" Format="MM/dd/yyyy"
                                                                                        TargetControlID="txtEffTill">
                                                                                    </cc1:CalendarExtender>
                                                                                    <cc1:MaskedEditValidator ID="MEVFFR" runat="server" ControlExtender="MEEFFR" ControlToValidate="txtEffTill"
                                                                                        Display="Dynamic" EmptyValueMessage="*" InvalidValueMessage="The Date is invalid"
                                                                                        IsValidEmpty="true" TooltipMessage="MM/DD/YYYY" Width="114px"></cc1:MaskedEditValidator>
                                                                                    <cc1:MaskedEditExtender ID="MEEFFR" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                                        TargetControlID="txtEffTill">
                                                                                    </cc1:MaskedEditExtender>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="buttonbackbar" colspan="4">
                                                                            <asp:LinkButton ID="LnkPost" runat="server" CssClass="buttonc" OnClick="LnkPost_Click">Post Blog</asp:LinkButton>
                                                                            &nbsp;
                                                                            <asp:LinkButton ID="LnkPostCancel" runat="server" CssClass="buttonc">Cancel</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </asp:Panel>
                                                    <asp:Panel ID="Panel1" runat="server" CssClass="panelbg">
                                                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                            <ContentTemplate>
                                                                <table style="width:100%;">
                                                                    <tr>
                                                                        <td class="GridHeader">
                                                                            <asp:Label ID="Label21" runat="server" Text="Comments"></asp:Label>
                                                                        </td>
                                                                        <td width="3%" class="GridHeader">
                                                                            <asp:LinkButton ID="LnkVwCancel" runat="server">X</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <asp:DataList ID="dlsCmnt" runat="server" CellPadding="0" CssClass="NormalText" 
                                                                                Height="16px" HorizontalAlign="Left" RepeatColumns="1" 
                                                                                RepeatDirection="Horizontal" Width="100%">
                                                                                <ItemTemplate>
                                                                                    <table cellpadding="0" cellspacing="0" style="width: 100%;">
                                                                                        <tr>
                                                                                            <td valign="middle">
                                                                                                <asp:Label ID="lblCmntBy" runat="server" Text='<%# eval("By") %>'></asp:Label>
                                                                                                &nbsp;-
                                                                                                <asp:Label ID="lblCmntOn" runat="server" Text='<%# eval("On") %>'></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td valign="top">
                                                                                                <asp:Label ID="LblCmnt" runat="server" Text='<%# eval("Comment") %>'></asp:Label>
                                                                                                <br />
                                                                                                <hr />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <%--<div class = "NormalText" style="height: 43px; width: 100%; text-align: left;">--%>
                                                                                </ItemTemplate>
                                                                            </asp:DataList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Panel ID="PnlCommentAdd" runat="server" BorderColor="#666666" BorderStyle="Groove"
                                                        Width="91%" style = "display:none">
                                                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                            <ContentTemplate>
                                                                <table style="width: 100%;" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="GridHeader">
                                                                            <asp:Label ID="Label18" runat="server" Text="Add Your Comment"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txtCmntAdd" runat="server" CssClass="textbox" Height="100px" MaxLength="300"
                                                                                TextMode="MultiLine" Width="98%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="labelcells" style="background-color: #FFFFFF">
                                                                            <asp:Label ID="Label19" runat="server" Text="Identity"></asp:Label>
                                                                            &nbsp;
                                                                            <asp:DropDownList ID="DDLCmtIdentity" runat="server" CssClass="combobox" Width="70px">
                                                                                <asp:ListItem Value="N">Disclose</asp:ListItem>
                                                                                <asp:ListItem Value="Y">Anonymous</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="buttonbackbar">
                                                                            <asp:LinkButton ID="LnkSubmitCmnt" runat="server"  CssClass="buttonc">Submit</asp:LinkButton>
                                                                            &nbsp;
                                                                            <asp:LinkButton ID="LnkCmntCancel" runat="server" CssClass="buttonc">Cancel</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr __designer:mapid="61">
                        <td style="background-position: left top; height: 20px; background-image: url('Image/Frame/Footer_Frame_Large.png');
                            background-repeat: no-repeat;" __designer:mapid="62">
                        </td>
                        <td style="background-position: right top; height: 20px; background-image: url('Image/Frame/Footer_Frame_Large.png');
                            background-repeat: no-repeat;" __designer:mapid="63">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
