<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage4.master" AutoEventWireup="false"
    CodeFile="RegisterUser.aspx.vb" Inherits="RegisterUser" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table style="background-position: center center; width: 100%; height: 100%;
        vertical-align: middle; text-align: center; background-image: url('Image/Headers/RegistrationHeader.png');
        background-repeat: no-repeat;  min-width : 790px;" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <div id="left" 
                    style="width: 750px; height: 298px; text-align: right; vertical-align: middle; font-size: small;">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
            <br />
            <table style="width: 40%; text-align: left; background-repeat: no-repeat;" class="NormalText"
                dir="ltr">
                <tr>
                    <td class="style16">
                        &nbsp;</td>
                    <td class="style13">
                        <asp:Label ID="Label5" runat="server" Text="User Name*"></asp:Label>
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="textbox" Width="141px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style16">
                        &nbsp;
                    </td>
                    <td class="style13">
                        <asp:Label ID="Label2" runat="server" Text="Password*"></asp:Label>
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="textbox" Width="133px" 
                            TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style17">
                        &nbsp;
                    </td>
                    <td class="style14">
                        <asp:Label ID="Label3" runat="server" Text="Confirm Password*"></asp:Label>
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="textbox" Height="16px" 
                            Width="132px" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="style5">
                    </td>
                </tr>
                <tr>
                    <td class="style18">
                    </td>
                    <td class="style12">
                        <asp:Label ID="Label4" runat="server" Text="Company &amp; Location"></asp:Label>
                    </td>
                    <td class="style12">
                        <asp:DropDownList ID="ddlCompany" runat="server" CssClass="combobox">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlLocation" runat="server" CssClass="combobox">
                        </asp:DropDownList>
                    </td>
                    <td class="style11">
                    </td>
                </tr>
                <tr>
                    <td class="style19">
                    </td>
                    <td class="style20" style="vertical-align: top">
                        <asp:Label ID="Label8" runat="server" Text="Card No"></asp:Label>
                    </td>
                    <td class="style20">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" Height="16px" 
                            MaxLength="4" Width="52px"></asp:TextBox>
                    </td>
                    <td class="style20">
                    </td>
                </tr>
                <tr>
                    <td class="style19">
                        &nbsp;</td>
                    <td class="style20" style="vertical-align: top">
                        <asp:Label ID="Label7" runat="server" Text="Comments"></asp:Label>
                    </td>
                    <td class="style20">
                        <asp:TextBox ID="txtComments" runat="server" CssClass="textbox" Height="38px" 
                            TextMode="MultiLine" Width="145px"></asp:TextBox>
                    </td>
                    <td class="style20">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style21">
                    </td>
                    <td class="style22">
                        &nbsp;<asp:LinkButton ID="lnkHome" runat="server" 
                            PostBackUrl="~/Default.aspx">Back to HOME</asp:LinkButton>
                    </td>
                    <td class="style22">
                        <asp:LinkButton ID="lnkRegister" runat="server" CssClass="buttonc">Register</asp:LinkButton>
                    </td>
                    <td class="style22">
                    </td>
                </tr>
                <tr>
                    <td class="style21" style="height: 17px">
                        &nbsp;</td>
                    <td class="style22" colspan="3" style="height: 17px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style21" style="height: 17px">
                        </td>
                    <td class="style22" colspan="3" style="height: 17px">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblError" runat="server" CssClass="errormsg"></asp:Label>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="lnkRegister" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="style21" style="height: 17px">
                        &nbsp;</td>
                    <td class="style22" colspan="3" style="height: 17px">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
            </td>
        </tr>
    </table>
<%--    <div id="ParentDiv" style="background-position: center center; width: 100%; height: 100%;
        vertical-align: middle; text-align: center; background-image: url('Image/RegistrationHeader.png');
        background-repeat: no-repeat;">
        
    </div>--%>
</asp:Content>
