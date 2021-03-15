<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="EmployeeImage.aspx.vb" Inherits="EmployeeImage" Title="Upload Image" %>

<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function LoadImage() {
            document.getElementById('img').src = document.getElementById('File1').value;
        }
    </script>

    <table style="width: 100%">
        <tr>
            <td align="center" colspan="10" style="text-align: left;" class="tableheader">
                <asp:Label ID="Label1" runat="server" BorderColor="Transparent" Text="Employee Image"
                    Width="108px"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid;
        width: 100%; border-bottom: #000000 1px solid" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="7" class="labelcells" style="height: 15px" valign="top">
                <asp:Label ID="lblact" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Card Number :" Width="112px"></asp:Label>
            </td>
            <td colspan="1" style="width: 19%; height: 15px; " valign="top">
                &nbsp;<asp:Label ID="lblcard" runat="server" Font-Bold="True" Font-Names="Verdana"
                    Font-Size="9pt"></asp:Label>
            </td>
            <td colspan="1" class="labelcells" style="height: 15px" valign="top">
                <asp:Label ID="lblleave" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Add/Replace Image :" Width="146px"></asp:Label>
            </td>
            <td colspan="1" valign="top">
                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="textbox" 
                    Height="22px" Width="238px" />
            </td>
        </tr>
        <tr>
            <td colspan="7" class="labelcells">
            </td>
            <td colspan="1" style="width: 19%; height: 20px; background-color: whitesmoke">
            </td>
            <td colspan="1" class="labelcells">
            </td>
            <td colspan="1" style="width: 40%; height: 20px; background-color: whitesmoke" valign="middle">
                <asp:RegularExpressionValidator ID="REV" runat="server" ControlToValidate="FileUpload1"
                    ErrorMessage="Please Select .jpg  files only" Font-Bold="True" Font-Names="Verdana"
                    Font-Size="8pt" ValidationExpression="^.+(.jpg|.JPG)$" 
                    style="font-family: Tahoma"></asp:RegularExpressionValidator>
            </td>
        </tr>
    </table>
    <span style="font-size: 3pt; color: #ffffff">dfdsf </span>
    <table style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid;
        border-bottom: #000000 1px solid; height: 300px; background-color: whitesmoke"
        width="100%">
        <tr>
            <td align="center" colspan="3" rowspan="1" style="height: 20px">
                <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                    FadeInDuration="2" FadeInSteps="2" FadeOutDuration="2" FadeOutSteps="2" Visible="true" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="height: 200px">
                <asp:Image ID="imgemp" runat="server" Height="200px" Width="150px" BackColor="Silver"
                    BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
            </td>
        </tr>
        <tr>
            <td  colspan="3" class="labelcells">
               
                    * Preferred File size : (150 <span style="mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        × 200)<br />
                    <span style="color: #ff0000">*</span> Preferred File type : ( .JPG )<br />
                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Names="Verdana"
                        Font-Size="8pt" ForeColor="Red" Width="70px">« Back </asp:LinkButton></strong></span>
            </td>
        </tr>
        <tr>
            <td align="center" class="buttonbackbar" colspan="3" rowspan="1" style="height: 20px">
                <asp:Button ID="btnsub" runat="server" CssClass="ButtonBack" Height="21px" Text="Upload" />
            </td>
        </tr>
    </table>
</asp:Content>
