<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_payroll_Contact_Information.aspx.cs" Inherits="Payroll_Jct_payroll_Contact_Information" %>
    
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
              Contact Information
            </td>
        </tr>
     

        <%-- <tr>
            <td class="labelcells" style="width: 164px">
                <asp:Label ID="Label20" runat="server" Text="State"></asp:Label>
            </td>
            <td class="NormalText" style="width: 349px">
                <asp:DropDownList ID="ddlstate" runat="server" AutoPostBack="True" CssClass="combobox"
                    DataSourceID="SqlDataSource1" DataTextField="state" DataValueField="state" Height="30px"
                    OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" AppendDataBoundItems="True">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                    SelectCommand="SELECT DISTINCT state FROM JCTGEN..JCT_EPOR_STATE_MASTER "></asp:SqlDataSource>
            </td>
          
        </tr>--%>
        <%--<tr>
            <td class="labelcells" style="width: 164px">
                &nbsp;<asp:Label ID="Label21" runat="server" Text="City"></asp:Label>
            </td>
            <td class="NormalText" style="width: 349px">
                <asp:DropDownList ID="ddlcity" size="5" runat="server" CssClass="combobox" Height="20px"
                    Width="100px" AutoPostBack="True" AppendDataBoundItems="True">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells" style="width: 88px">
                &nbsp;
            </td>
            <td class="textcells" style="width: 14px">
                &nbsp;&nbsp;
            </td>
        </tr>--%>
        <tr>
            <td class="labelcells" style="width: 164px">
                MobileNo.
            </td>
            <td class="textcells" style="width: 349px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtPri_Mobile" runat="server" CssClass="textbox" TabIndex="7" MaxLength="10"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="TxtPri_Mobile_FilteredTextBoxExtender" runat="server"
                            Enabled="True" TargetControlID="TxtPri_Mobile" ValidChars="0123456789">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells" style="width: 88px">
                &nbsp;
            </td>
            <td class="textcells" style="width: 14px">
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Primary LandlineNo
            </td>
            <td class="textcells" style="width: 14px">
                <asp:TextBox ID="txtlandline" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtlandline_FilteredTextBoxExtender" runat="server"
                    Enabled="True" TargetControlID="txtlandline" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td class="labelcells">
                Secondary LandlineNo
            </td>
            <td class="textcells" style="width: 14px">
                <asp:TextBox ID="TxtSecondaryLandline" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                    TargetControlID="TxtSecondaryLandline" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 164px;">
                <asp:Label ID="Label53" runat="server" Text="Emai Id"></asp:Label>
            </td>
            <td class="textcells" style="width: 349px">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtEmailID" runat="server" CssClass="textbox" Width="150px" MaxLength="30"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ControlToValidate="TxtEmailID" ErrorMessage="Input valid Internet URL!" ValidationGroup="A"></asp:RegularExpressionValidator>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkCssClass="watermark"
                            WatermarkText="local-part@domain" TargetControlID="TxtEmailID">
                        </cc1:TextBoxWatermarkExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells" style="width: 88px;">
            </td>
            <td class="textcells" style="width: 14px;">
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="lnkSave_Click">Save</asp:LinkButton>
            </td>
        </tr>
    </table>

</asp:Content>
