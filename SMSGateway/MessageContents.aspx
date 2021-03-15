<%@ Page Title="" Language="VB" MasterPageFile="~/SMSGateway/MasterPage.master" AutoEventWireup="false"
    CodeFile="MessageContents.aspx.vb" Inherits="SMSGateway_MessageContents" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader">
                &nbsp;Message Content Templates<asp:TextBox ID="txtTrans_no" runat="server" CssClass="textbox"
                    Visible="False"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="labelcells" style="width: 190px">
                <asp:Label ID="Label16" runat="server" Text="Message Type"></asp:Label>
            </td>
            <td class="textcells">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlMsgType" runat="server" 
    CssClass="combobox" AutoPostBack="True">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem>SMS</asp:ListItem>
                            <asp:ListItem>Email</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="textcells">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 190px">
                <asp:Label ID="Label24" runat="server" Text="Message Behaviour"></asp:Label>
            </td>
            <td class="textcells">
                <asp:DropDownList ID="ddlMsgBehaviour" runat="server" CssClass="combobox" 
                    TabIndex="1">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>User</asp:ListItem>
                    <asp:ListItem>System</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="textcells">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 190px">
                <asp:Label ID="Label25" runat="server" Text="Procedure"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="txtProc" runat="server" CssClass="textbox" Width="362px" 
                    TabIndex="2"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProc"
                    ErrorMessage="**Field Required..." ValidationGroup="Group1"></asp:RequiredFieldValidator>
            </td>
            <td class="textcells">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 190px">
                <asp:Label ID="Label22" runat="server" Text="Message ID (Auto)"></asp:Label>
            </td>
            <td class="textcells">
                <asp:Label ID="lblMsgID" runat="server"></asp:Label>
            </td>
            <td class="textcells">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 190px">
                <asp:Label ID="Label19" runat="server" Text="Subject"></asp:Label>
            </td>
            <td class="textcells" colspan="3">
                <asp:TextBox ID="txtSubject" runat="server" Columns="100" CssClass="textbox" 
                    TabIndex="3"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSubject"
                    ErrorMessage="**Field Required.." ValidationGroup="Group1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 190px">
                <asp:Label ID="Label21" runat="server" Text="Message"></asp:Label>
                <br />
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline" 
                    UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblChars" runat="server" 
    BorderStyle="None" Text="( Max 160 characters )"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlMsgType" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
&nbsp;</td>
            <td colspan="3" class="labelcells">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtMsg" runat="server" Height="88px" 
    MaxLength="160" TextMode="MultiLine"
                    Width="331px" CssClass="textbox" TabIndex="4"></asp:TextBox>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="txtMsg" ErrorMessage="**Limit Exceed" 
                            ValidationExpression="[\s\S]{1,160}"></asp:RegularExpressionValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtMsg" ErrorMessage="**Field Required.." 
                            ValidationGroup="Group1"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlMsgType" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr class="buttonbackbar">
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkAdd" runat="server" CssClass="buttonc" TabIndex="5">Add</asp:LinkButton>
                <asp:LinkButton ID="lnkEdit" runat="server" CssClass="buttonc" ValidationGroup="Group1">Edit</asp:LinkButton>
                <asp:LinkButton ID="lnkDelete" runat="server" CssClass="buttonc" ValidationGroup="Group1">Delete</asp:LinkButton>
                <cc1:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server" ConfirmText="Are you sure you want to ddelete this record..?"
                    TargetControlID="lnkDelete">
                </cc1:ConfirmButtonExtender>
                <asp:LinkButton ID="lnkSearch" runat="server" CssClass="buttonc">Search</asp:LinkButton>
                <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc">Reset</asp:LinkButton>
                <asp:LinkButton ID="lnkClose" runat="server" CssClass="buttonc">Close</asp:LinkButton>
            </td>
        </tr>
        <tr class="buttonbackbar">
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkFirst" runat="server" CssClass="buttonc">First</asp:LinkButton>
                <asp:LinkButton ID="lnkNext" runat="server" CssClass="buttonc">Next</asp:LinkButton>
                <asp:LinkButton ID="lnkPrevious" runat="server" CssClass="buttonc">Previous</asp:LinkButton>
                <asp:LinkButton ID="lnkLast" runat="server" CssClass="buttonc">Last</asp:LinkButton>
            </td>
        </tr>
    </table>
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground"
        PopupControlID="PnlFlashMessage" TargetControlID="LnkAdd" Enabled="False">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="PnlFlashMessage" runat="server" CssClass="confirm-dialog" Style="display: none">
        <div class="inner" style="vertical-align: middle; text-align: center">
            <asp:Label ID="LblMessage" runat="server" Text="Your Message"></asp:Label>
            <br>
             <br>
             </br>
            </br>
        </div>
        <div class="base">
            <asp:LinkButton ID="CmdClosePopUp" CausesValidation="False" runat="server" CssClass="close" />
        </div>
    </asp:Panel>
</asp:Content>
