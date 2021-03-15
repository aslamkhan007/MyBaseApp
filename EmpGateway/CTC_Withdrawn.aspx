<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="CTC_Withdrawn.aspx.vb" Inherits="CTC" title="CTC (Cost to Company)" MaintainScrollPositionOnPostback="true" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"  Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div id="printDiv">

   <div id = "print_area">
    <table id="Panel2" style="width: 100%; height: 1px" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="3" style="width: 97%; height: 19px">
                <asp:Panel ID="Panel1" runat="server" Width="100%">
    <table style="width: 74%">
        <tr>
            <td colspan="4" class="tableheader" >
                <strong>Cost
                    To Company ( CTC )</strong></td>
        </tr>
        <tr>
            <td style="width: 174px; height: 18px; text-align: left; background-color: lightgrey; background-image: url('Image/SmallGreyBarNormal.png');"
                valign="middle">
                <asp:Label ID="Label1" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Basic" Width="35px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 72px; height: 18px; text-align: left;"
                valign="middle">
                <asp:Label ID="Bas" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="DimGray" Height="11px" Text="0" Width="71px"></asp:Label></td>
            <td style="width: 184px; height: 18px; text-align: left; background-color: lightgrey; background-image: url(Image/SmallGreyBarNormal.png);"
                valign="middle">
                <asp:Label ID="Label10" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Entertainment Allowance"
                    Width="151px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 62px; height: 18px; text-align: left;"
                valign="middle">
     
                <asp:TextBox  ID="EntAll" runat="server" Height="13px" Width="103px" AutoPostBack="True" BackColor="#FF8080" BorderStyle="None" Font-Names="Tahoma" Font-Size="8pt" Font-Bold="True">0</asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 174px; height: 18px; text-align: left; background-color: lightgrey; background-image: url('Image/SmallGreyBarNormal.png');"
                valign="middle">
                <asp:Label ID="ConOwnApril" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="HRA" Width="26px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 72px; height: 18px; text-align: left;"
                valign="middle">
                <asp:Label ID="HRA" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="DimGray" Height="11px" Text="0" Width="70px"></asp:Label></td>
            <td style="width: 184px; height: 18px; text-align: left; background-color: lightgrey; background-image: url(Image/SmallGreyBarNormal.png);"
                valign="middle">
                <asp:Label ID="Label9" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Driver Allowance" Width="98px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 62px; height: 18px; text-align: center;"
                valign="middle">
                 <asp:TextBox  ID="DriAll" runat="server" Height="13px" Width="103px" AutoPostBack="True" BackColor="#FF8080" BorderStyle="None" Font-Names="Tahoma" Font-Size="8pt" Font-Bold="True">0</asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 174px; height: 18px; text-align: left; background-color: lightgrey; background-image: url('Image/SmallGreyBarNormal.png');"
                valign="middle">
                <asp:Label ID="ConOwnMay" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Colony Allowance" Width="110px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 72px; height: 18px; text-align: left;"
                valign="middle">
                <asp:Label ID="ColAll" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="DimGray" Height="11px" Text="0" Width="71px"></asp:Label></td>
            <td style="width: 184px; height: 18px; text-align: left; background-color: lightgrey; background-image: url(Image/SmallGreyBarNormal.png);"
                valign="middle">
                <asp:Label ID="Label6" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Others" 
                    Width="175px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 62px; height: 18px; text-align: center;"
                valign="middle">
                <asp:TextBox ID="Others" runat="server" Height="13px" Width="103px" AutoPostBack="True" BackColor="#FF8080" BorderStyle="None" Font-Names="Tahoma" Font-Bold="True" Font-Size="8pt">
                    &nbsp;&nbsp;0</asp:TextBox></td>
        </tr>
        <tr>
            <td 
                style="width: 174px; height: 18px;
                text-align: left; background-color: lightgrey; background-image: url('Image/SmallGreyBarNormal.png');" 
                valign="middle">
                <asp:Label ID="ConOwnJune" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="16px" 
                    Text="Uniform + Books Per.Allowance" Width="195px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 72px; height: 18px;
                text-align: left" valign="middle">
                <asp:Label ID="PerAll" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="DimGray" Height="11px" Text="0" Width="70px"></asp:Label></td>
            <td style="width: 184px; height: 18px;
                text-align: left; background-color: lightgrey; background-image: url(Image/SmallGreyBarNormal.png);" valign="middle">
                &nbsp;</td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 62px; height: 18px;
                text-align: center" valign="middle">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 174px; text-align: left; background-color: lightgrey; background-image: url('Image/SmallGreyBarNormal.png'); height: 18px;"
                valign="middle">
                <asp:Label ID="ConOwnJuly" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" 
                    Text="Special &amp; 2010 Allowance" Width="200px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 72px; height: 18px; text-align: left;"
                valign="middle">
                <asp:Label ID="SpeAll" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="DimGray" Height="11px" Text="0" Width="69px"></asp:Label></td>
            <td style="width: 184px; height: 18px; text-align: left; background-color: lightgrey; background-image: url(Image/SmallGreyBarNormal.png);"
                valign="middle">
                </td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 62px; height: 18px; text-align: center;"
                valign="middle">
                </td>
        </tr>
        <tr>
            <td style="width: 174px; height: 18px; text-align: left; background-color: lightgrey; background-image: url('Image/SmallGreyBarNormal.png');"
                valign="middle">
                <asp:Label ID="ConOwnAug" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Conveyance Allowance" Width="133px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 72px; height: 18px; text-align: left;"
                valign="middle">
                <asp:Label ID="ConAll" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="DimGray" Height="11px" Text="0" Width="69px"></asp:Label></td>
            <td style="width: 184px; height: 18px; text-align: left; background-color: lightgrey; background-image: url(Image/SmallGreyBarNormal.png);"
                valign="middle">
                </td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 62px; height: 18px; text-align: center;"
                valign="middle">
                </td>
        </tr>
        <tr>
            <td style="width: 174px; text-align: left; background-color: lightgrey; height: 18px; background-image: url('Image/SmallGreyBarNormal.png');"
                valign="middle">
                <asp:Label ID="ConOwnSep" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Leave Travel Allowance (LTA)" Width="174px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 72px; height: 18px; text-align: left;"
                valign="middle">
                <asp:Label ID="LtaAll" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="DimGray" Height="11px" Text="0" Width="69px"></asp:Label></td>
            <td style="width: 184px; height: 18px; text-align: left; background-color: lightgrey; background-image: url(Image/SmallGreyBarNormal.png);"
                valign="middle">
                </td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 62px; height: 18px; text-align: center;"
                valign="middle">
                </td>
        </tr>
        <tr>
            <td style="width: 174px; text-align: left; background-color: lightgrey; background-image: url('Image/SmallGreyBarNormal.png'); height: 18px;"
                valign="middle">
                <asp:Label ID="ConOwnOct" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Medical Allowance" Width="104px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 72px; height: 18px; text-align: left;"
                valign="middle">
                <asp:Label ID="Medical" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="DimGray" Height="11px" Text="0" Width="70px"></asp:Label></td>
            <td style="width: 184px; height: 18px; text-align: left; background-color: lightgrey; background-image: url(Image/SmallGreyBarNormal.png);"
                valign="middle">
                </td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 62px; height: 18px; text-align: center;"
                valign="middle">
                </td>
        </tr>
        <tr>
            <td style="width: 174px; height: 18px; background-color: lightgrey; text-align: left; background-image: url('Image/SmallGreyBarNormal.png');"
                valign="middle">
                <asp:Label ID="Label2" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Bonus" Width="39px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 72px; height: 18px;
                text-align: left" valign="middle">
                <asp:Label ID="Bonus" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="DimGray" Height="11px" Text="0" Width="69px"></asp:Label></td>
            <td style="width: 184px; height: 18px; background-color: lightgrey; text-align: left; background-image: url(Image/SmallGreyBarNormal.png);"
                valign="middle">
            </td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 62px; height: 18px;
                text-align: center" valign="middle">
            </td>
        </tr>
        <tr>
            <td style="width: 174px; background-color: lightgrey; text-align: left; background-image: url('Image/SmallGreyBarNormal.png'); height: 18px;" 
                valign="middle">
                <asp:Label ID="Label3" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Superannuation" Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 72px; height: 18px;
                text-align: left" valign="middle">
                <asp:Label ID="SupAll" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="DimGray" Height="11px" Text="0" Width="69px"></asp:Label></td>
            <td style="width: 184px; height: 18px; background-color: lightgrey; text-align: left; background-image: url(Image/SmallGreyBarNormal.png);"
                valign="middle">
            </td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 62px; height: 18px;
                text-align: center" valign="middle">
            </td>
        </tr>
        <tr>
            <td style="width: 174px; height: 18px; background-color: lightgrey; text-align: left; background-image: url('Image/SmallGreyBarNormal.png');"
                valign="middle">
                <asp:Label ID="Label4" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="PF Contribution (Employer)" Width="161px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 72px; height: 18px;
                text-align: left" valign="middle">
                <asp:Label ID="PfcAll" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="DimGray" Height="11px" Text="0" Width="67px"></asp:Label></td>
            <td style="width: 184px; height: 18px; background-color: lightgrey; text-align: left; background-image: url(Image/SmallGreyBarNormal.png);"
                valign="middle">
            </td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 62px; height: 18px;
                text-align: center" valign="middle">
            </td>
        </tr>
        <tr>
            <td style="width: 174px; height: 18px; background-color: lightgrey; text-align: left; background-image: url('Image/SmallGreyBarNormal.png');"
                valign="middle">
                <asp:Label ID="Label11" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="ESI (Employer)" Width="134px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 72px; height: 18px;
                text-align: left" valign="middle">
                <asp:Label ID="EsiAll" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="DimGray" Height="11px" Text="0" Width="68px"></asp:Label></td>
            <td style="width: 184px; height: 18px; background-color: lightgrey; text-align: left; background-image: url(Image/SmallGreyBarNormal.png);"
                valign="middle">
            </td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 62px; height: 18px;
                text-align: center" valign="middle">
            </td>
        </tr>
        <tr>
            <td style="width: 174px; height: 18px; background-color: lightgrey; text-align: left; background-image: url('Image/SmallGreyBarNormal.png');"
                valign="middle">
                <asp:Label ID="Label8" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Addl. Allo. (For Car)"
                    Width="121px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 72px; height: 18px;
                text-align: left" valign="middle">
                <asp:Label ID="NewCarAll" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="DimGray" Height="11px" Text="0" Width="68px"></asp:Label></td>
            <td style="width: 184px; height: 18px; background-color: lightgrey; text-align: left; background-image: url(Image/SmallGreyBarNormal.png);"
                valign="middle">
            </td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 62px; height: 18px;
                text-align: center" valign="middle">
            </td>
        </tr>
        <tr>
            <td style="width: 174px; height: 18px; background-color: lightgrey; text-align: left; background-image: url('Image/SmallGreyBarNormal.png');"
                valign="middle">
                <asp:Label ID="Label5" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Gratuity " Width="54px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 72px; height: 18px;
                text-align: left" valign="middle">
                <asp:Label ID="Gratuity" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="DimGray" Height="11px" Text="0" Width="68px"></asp:Label></td>
            <td style="width: 184px; height: 18px; background-color: lightgrey; text-align: left; background-image: url(Image/SmallGreyBarNormal.png);"
                valign="middle">
            </td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 62px; height: 18px;
                text-align: center" valign="middle">
            </td>
        </tr>
        <tr>
            <td colspan="4" style="background-color: lightgrey; text-align: center; background-image: url(Image/GlassBarNormal.PNG); height: 20px;" valign="middle">
                <asp:Label ID="Label13" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Trebuchet MS"
                    Font-Size="12pt" ForeColor="Red" Height="20px" Text="Your CTC Amount:" Width="155px"></asp:Label><asp:Label
                        ID="numCTC" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Trebuchet MS"
                        Font-Size="12pt" ForeColor="Red" Height="20px" Width="111px">0</asp:Label></td>
        </tr>
    </table>
                    </asp:Panel>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</table>
    </div>
    <br />
    <!-- <input type = "button" ID="Button1" runat="server" Value="Print" onclick="JavaScript:printPartOfPage('print_area');" /></td> -->
    </div>

</asp:Content>


