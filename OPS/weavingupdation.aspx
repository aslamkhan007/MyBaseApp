<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="weavingupdation.aspx.cs" Inherits="OPS_weavingupdation" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="2">
                &nbsp;Weaving Updation&nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Updation Date</td>
            <td>
                <asp:TextBox ID="txtdate" runat="server" AutoPostBack="True" CssClass="textbox"></asp:TextBox>
               <%-- <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdate">
                </cc1:CalendarExtender>--%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtdate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            ImageUrl="~/OPS/Image/loadingNew.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkapply" runat="server" CssClass="buttonc" 
                            onclick="lnkapply_Click" ValidationGroup="A">Apply</asp:LinkButton>
                        <cc1:ConfirmButtonExtender ID="lnkapply_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Are you sure?" Enabled="True" TargetControlID="lnkapply">
                        </cc1:ConfirmButtonExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

