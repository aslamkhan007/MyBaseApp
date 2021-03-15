<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="PF.aspx.vb" Inherits="PF" title="PF Statment" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="printDiv">

    <table style="width: 100%" cellpadding="0" cellspacing="1">
        <tr>
            <td class="tableheader">
                Provident Fund Statement</td>
        </tr>
       
   </table>

   <div id = "print_area">
    <table id="Panel2" style="width: 100%; height: 1px" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="3" style="width: 97%; height: 19px">
                <asp:Panel ID="Panel1" runat="server" Width="100%">
    <table style="width: 100%">
        <tr>
            <td colspan="2" style="background-image: url(Image/SmallGreyBarNormal.png); width: 105px;
                height: 19px; text-align: left" valign="middle">
                <asp:Label ID="Label40" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Employee Name" Width="93px"></asp:Label></td>
            <td colspan="3" style="background-image: url(Image/SmallGlassBarNormal.PNG); height: 19px;
                text-align: left" valign="middle">
                <asp:Label ID="EmpName" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="202px"></asp:Label></td>
            <td colspan="2" style="background-image: url(Image/SmallGreyBarNormal.png); width: 105px;
                height: 19px; text-align: left" valign="middle">
                <asp:Label ID="Label41" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Father Name" Width="93px"></asp:Label></td>
            <td colspan="3" style="background-image: url(Image/SmallGlassBarNormal.PNG); height: 19px;
                text-align: left" valign="middle">
                <asp:Label ID="FatName" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="176px"></asp:Label></td>
        </tr>
        <tr>
            <td
                valign="middle" colspan="2" style="background-image: url(Image/SmallGreyBarNormal.png); width: 105px; height: 19px; text-align: left">
                <asp:Label ID="Label8" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Date of Joining Service "
                    Width="133px"></asp:Label></td>
            <td colspan="3" valign="middle" style="text-align: left; background-image: url(Image/SmallGlassBarNormal.PNG); height: 19px;">
                <asp:Label ID="TxtDojs" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="159px"></asp:Label></td>
            <td
                valign="middle" colspan="2" style="background-image: url(Image/SmallGreyBarNormal.png); width: 105px; height: 19px; text-align: center">
                <asp:Label ID="Label3" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Name of Nominee :" Width="108px"></asp:Label></td>
            <td colspan="3" valign="middle" style="text-align: left; background-image: url(Image/SmallGlassBarNormal.PNG); height: 19px;">
                <asp:Label ID="TxtNominee" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="176px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 19px; background-image: url(Image/SmallGreyBarNormal.png); width: 105px; text-align: left;" valign="middle">
                <asp:Label ID="Label1" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Date of Joining PF       :"
                    Width="129px"></asp:Label></td>
            <td colspan="3" style="height: 19px; text-align: left; background-image: url(Image/SmallGlassBarNormal.PNG);" valign="middle">
                <asp:Label ID="TxtDojp" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="172px"></asp:Label></td>
            <td colspan="2" style="height: 19px; background-image: url(Image/SmallGreyBarNormal.png); width: 105px; text-align: left;" valign="middle">
                <asp:Label ID="Label4" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="PF/FPF No." Width="64px"></asp:Label></td>
            <td colspan="3" style="height: 19px; text-align: left; background-image: url(Image/SmallGlassBarNormal.PNG);" valign="middle">
                <asp:Label ID="TxtPfVpfNo" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="177px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 19px; background-image: url(Image/SmallGreyBarNormal.png); width: 105px; text-align: left;" valign="middle">
                <asp:Label ID="Label2" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Intrest Rate                   :"
                    Width="87px"></asp:Label></td>
            <td colspan="3" style="height: 19px; text-align: left; background-image: url(Image/SmallGlassBarNormal.PNG);" valign="middle">
                <asp:Label ID="TxtRate" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td colspan="2" style="height: 19px; background-image: url(Image/SmallGreyBarNormal.png); width: 105px; text-align: left;" valign="middle">

                <asp:Label ID="Label122" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="UAN/IFSC CODE"
                    Width="87px"></asp:Label></td>
            <td colspan="3" style="height: 19px; text-align: left; background-image: url(Image/SmallGlassBarNormal.PNG);" valign="middle">
                <asp:Label ID="TxtUAN" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
        </tr>
        <tr>
            <td style="background-image: url(Image/SmallGreyBarNormal.png); width: 119px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="Label5" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Month Year" Width="87px"></asp:Label></td>
            <td colspan="2" style="background-image: url(Image/SmallGreyBarNormal.png); height: 19px;
                text-align: center; width: 105px;" valign="middle">
                <asp:Label ID="Label6" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="P.F. Contribution" Width="98px"></asp:Label></td>
            <td colspan="2" style="background-image: url(Image/SmallGreyBarNormal.png); height: 19px;
                text-align: center; width: 105px;" valign="middle">
                <asp:Label ID="Label7" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="P.F. Interest" Width="98px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGreyBarNormal.png); height: 19px; text-align: center; width: 105px;"
                valign="middle" colspan="2">
                <asp:Label ID="Label9" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Principal Amount" Width="96px"></asp:Label></td>
            <td colspan="2" style="background-image: url(Image/SmallGreyBarNormal.png); height: 19px;
                text-align: left; width: 105px;" valign="middle">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:Label ID="Label10" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="V.P.F." Width="31px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGreyBarNormal.png); width: 128px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="Label11" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="V.P.F." Width="38px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 119px; height: 19px"
                valign="middle">
            </td>
            <td style="background-image: url(Image/SmallGreyBarNormal.png); width: 135px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="Label12" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Own" Width="38px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGreyBarNormal.png); width: 128px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="Label13" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Employer" Width="38px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGreyBarNormal.png); width: 128px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="Label14" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Own" Width="38px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGreyBarNormal.png); width: 483px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="Label17" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Employer" Width="38px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGreyBarNormal.png); width: 128px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="Label15" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Own" Width="38px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGreyBarNormal.png); width: 779px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="Label18" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Employer" Width="38px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGreyBarNormal.png); width: 223px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="Label16" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Own" Width="38px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGreyBarNormal.png); width: 207px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="Label19" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Interest" Width="38px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGreyBarNormal.png); width: 128px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="Label20" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Total" Width="38px"></asp:Label></td>
        </tr>
        <tr>
            <td style="background-image: url(Image/SmallGreyBarNormal.png); width: 119px; height: 19px;"
                valign="middle">
                <asp:Label ID="Label21" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Opening Balance" Width="95px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 135px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="ConOwnOBal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="ConEmpOBal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="IntOwnObal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 483px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="IntEmpOBal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="AmtOwnOBal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 779px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="AmtEmpOBal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 223px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfOwnOBal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfEmpOBal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfOBal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 119px; background-image: url(Image/SmallGreyBarNormal.png); height: 19px; text-align: left;" valign="middle">
                <asp:Label ID="Apr" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="April" Width="100px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 135px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="ConOwnApril" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="ConEmpApril" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="IntOwnApril" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 483px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="IntEmpApril" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="width: 128px; height: 19px; background-image: url(Image/SmallGlassBarNormal.PNG); text-align: center;" valign="middle">
                <asp:Label ID="AmtOwnApril" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 779px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="AmtEmpApril" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 223px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfOwnApril" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfEmpApril" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfApril" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 119px; background-image: url(Image/SmallGreyBarNormal.png); height: 19px; text-align: left;" valign="middle">
                <asp:Label ID="May" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="May" Width="100px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 135px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="ConOwnMay" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="ConEmpMay" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="IntOwnMay" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 483px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="IntEmpMay" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="width: 128px; height: 19px; background-image: url(Image/SmallGlassBarNormal.PNG); text-align: center;" valign="middle">
                <asp:Label ID="AmtOwnMay" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 779px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="AmtEmpMay" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 223px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfOwnMay" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfEmpMay" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfMay" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
        </tr>
        <tr>
            <td style="background-image: url(Image/SmallGreyBarNormal.png); width: 119px; height: 19px; text-align: left;"
                valign="middle">
                <asp:Label ID="Jun" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="June" Width="100px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 135px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="ConOwnJune" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="ConEmpJune" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="IntOwnJune" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 483px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="IntEmpJune" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="AmtOwnJune" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 779px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="AmtEmpJune" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 223px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="VpfOwnJune" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="VpfEmpJune" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="VpfJune" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 119px; background-image: url(Image/SmallGreyBarNormal.png); height: 19px; text-align: left;" valign="middle">
                <asp:Label ID="Jul" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="July" Width="100px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 135px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="ConOwnJuly" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="ConEmpJuly" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="IntOwnJuly" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 483px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="IntEmpJuly" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="width: 128px; height: 19px; background-image: url(Image/SmallGlassBarNormal.PNG); text-align: center;" valign="middle">
                <asp:Label ID="AmtOwnJuly" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 779px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="AmtEmpJuly" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 223px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfOwnJuly" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfEmpJuly" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfJuly" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 119px; background-image: url(Image/SmallGreyBarNormal.png); height: 19px; text-align: left;" valign="middle">
                <asp:Label ID="Aug" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="August" Width="100px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 135px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="ConOwnAug" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="ConEmpAug" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="IntOwnAug" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 483px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="IntEmpAug" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="width: 128px; height: 19px; background-image: url(Image/SmallGlassBarNormal.PNG); text-align: center;" valign="middle">
                <asp:Label ID="AmtOwnAug" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 779px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="AmtEmpAug" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 223px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfOwnAug" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfEmpAug" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfAug" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 119px; background-image: url(Image/SmallGreyBarNormal.png); height: 19px; text-align: left;" valign="middle">
                <asp:Label ID="Sep" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="September" Width="100px"></asp:Label>&nbsp;</td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 135px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="ConOwnSep" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="ConEmpSep" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="IntOwnSep" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 483px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="IntEmpSep" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="width: 128px; height: 19px; background-image: url(Image/SmallGlassBarNormal.PNG); text-align: center;" valign="middle">
                <asp:Label ID="AmtOwnSep" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 779px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="AmtEmpSep" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 223px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfOwnSep" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfEmpSep" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfSep" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 119px; background-image: url(Image/SmallGreyBarNormal.png); height: 19px; text-align: left;" valign="middle">
                <asp:Label ID="Oct" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="October" Width="100px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 135px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="ConOwnOct" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="ConEmpOct" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="IntOwnOct" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 483px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="IntEmpOct" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="width: 128px; height: 19px; background-image: url(Image/SmallGlassBarNormal.PNG); text-align: center;" valign="middle">
                <asp:Label ID="AmtOwnOct" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 779px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="AmtEmpOct" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 223px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfOwnOct" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfEmpOct" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfOct" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 119px; background-image: url(Image/SmallGreyBarNormal.png); height: 19px; text-align: left;" valign="middle">
                <asp:Label ID="Nov" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="November" Width="100px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 135px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="ConOwnNov" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="ConEmpNov" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="IntOwnNov" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 483px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="IntEmpNov" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="width: 128px; height: 19px; background-image: url(Image/SmallGlassBarNormal.PNG); text-align: center;" valign="middle">
                <asp:Label ID="AmtOwnNov" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 779px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="AmtEmpNov" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 223px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfOwnNov" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfEmpNov" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfNov" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 119px; background-image: url(Image/SmallGreyBarNormal.png); height: 19px; text-align: left;" valign="middle">
                <asp:Label ID="Dec" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="December" Width="100px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 135px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="ConOwnDec" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="ConEmpDec" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="IntOwnDec" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 483px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="IntEmpDec" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="width: 128px; height: 19px; background-image: url(Image/SmallGlassBarNormal.PNG); text-align: center;" valign="middle">
                <asp:Label ID="AmtOwnDec" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 779px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="AmtEmpDec" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 223px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfOwnDec" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfEmpDec" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfDec" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 119px; background-image: url(Image/SmallGreyBarNormal.png); height: 19px; text-align: left;" valign="middle">
                <asp:Label ID="Jan" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="January" Width="100px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 135px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="ConOwnJan" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="ConEmpJan" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="IntOwnJan" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 483px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="IntEmpJan" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="width: 128px; height: 19px; background-image: url(Image/SmallGlassBarNormal.PNG); text-align: center;" valign="middle">
                <asp:Label ID="AmtOwnJan" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 779px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="AmtEmpJan" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 223px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfOwnJan" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfEmpJan" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfJan" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 119px; background-image: url(Image/SmallGreyBarNormal.png); height: 19px; text-align: left;" valign="middle">
                <asp:Label ID="Feb" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="February" Width="100px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 135px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="ConOwnFeb" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="ConEmpFeb" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="IntOwnFeb" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 483px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="IntEmpFeb" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="width: 128px; height: 19px; background-image: url(Image/SmallGlassBarNormal.PNG); text-align: center;" valign="middle">
                <asp:Label ID="AmtOwnFeb" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 779px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="AmtEmpFeb" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 223px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfOwnFeb" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfEmpFeb" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfFeb" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 119px; background-image: url(Image/SmallGreyBarNormal.png); height: 19px; text-align: left;">
                <asp:Label ID="Mar" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="March" Width="100px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 135px; height: 19px; text-align: center;">
                <asp:Label ID="ConOwnMar" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;">
                <asp:Label ID="ConEmpMar" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;">
                <asp:Label ID="IntOwnMar" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 483px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="IntEmpMar" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="width: 128px; height: 19px; background-image: url(Image/SmallGlassBarNormal.PNG); text-align: center;" valign="middle">
                <asp:Label ID="AmtOwnMar" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 779px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="AmtEmpMar" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 223px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfOwnMar" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfEmpMar" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfMar" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 119px; background-image: url(Image/SmallGreyBarNormal.png); height: 19px; text-align: left;">
                <asp:Label ID="Label34" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Total" Width="32px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 135px; height: 19px; text-align: center;">
                <asp:Label ID="ConOwnTotal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="Green" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;">
                <asp:Label ID="ConEmpTotal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="Green" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;">
                <asp:Label ID="IntOwnTotal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="Green" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 483px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="IntEmpTotal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="Green" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="width: 128px; height: 19px; background-image: url(Image/SmallGlassBarNormal.PNG); text-align: center;" valign="middle">
                <asp:Label ID="AmtOwnTotal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="Green" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 779px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="AmtEmpTotal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="Green" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 223px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfOwnTotal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="Green" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfEmpTotal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="Green" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfTotal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="Green" Height="13px" Text="  " Width="51px"></asp:Label></td>
        </tr>
        <tr>
            <td rowspan="2" style="background-image: url(Image/SmallGreyBarNormal.png); width: 119px;
                height: 19px; background-repeat: repeat-x; background-color: gainsboro;" valign="top">
                <asp:Label ID="Label38" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="Black" Height="41px" Text="Non Refundable Loan" Width="123px"></asp:Label></td>
            <td colspan="4" style="background-image: url(Image/SmallGlassBarNormal.PNG); height: 19px;
                text-align: center">
            </td>
            <td style="background-image: url(Image/SmallGreyBarNormal.png); width: 119px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="Label35" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="Red" Height="19px" Text="Sanct No." Width="58px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGreyBarNormal.png); width: 779px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="Label39" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="Red" Height="19px" Text="Sanct Date" Width="63px"></asp:Label></td>
            <td colspan="3" style="background-image: url(Image/SmallGlassBarNormal.PNG); height: 19px;
                text-align: center" valign="middle">
            </td>
        </tr>
        <tr>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 135px; height: 19px;
                text-align: center">
                <asp:Label ID="ConOwnNonRefLoan" runat="server" BorderStyle="None" Font-Bold="True"
                    Font-Names="Tahoma" Font-Size="8pt" ForeColor="Red" Height="13px" Text="  "
                    Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px;
                text-align: center">
                <asp:Label ID="ConEmpNonRefLoan" runat="server" BorderStyle="None" Font-Bold="True"
                    Font-Names="Tahoma" Font-Size="8pt" ForeColor="Red" Height="13px" Text="  "
                    Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px;
                text-align: center">
                <asp:Label ID="IntOwnNonRefLoan" runat="server" BorderStyle="None" Font-Bold="True"
                    Font-Names="Tahoma" Font-Size="8pt" ForeColor="Red" Height="13px" Text="  "
                    Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 483px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="IntEmpNonRefLoan" runat="server" BorderStyle="None" Font-Bold="True"
                    Font-Names="Tahoma" Font-Size="8pt" ForeColor="Red" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="LoanNo" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 779px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="LoanTakenDate" runat="server" BorderStyle="None" Font-Bold="True"
                    Font-Names="Tahoma" Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  "
                    Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 223px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="VpfOwnNonRefLoan" runat="server" BorderStyle="None" Font-Bold="True"
                    Font-Names="Tahoma" Font-Size="8pt" ForeColor="Red" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px;
                text-align: center" valign="middle">
                <asp:Label ID="VpfIntNonRefLoan" runat="server" BorderStyle="None" Font-Bold="True"
                    Font-Names="Tahoma" Font-Size="8pt" ForeColor="Red" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px;
                text-align: center" valign="middle">
            </td>
        </tr>
        <tr>
            <td style="background-image: url(Image/SmallGreyBarNormal.png); width: 119px; height: 19px;">
                <asp:Label ID="Label36" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="Grand Total" Width="68px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 135px; height: 19px; text-align: center;">
                <asp:Label ID="ConOwnGTotal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#0000C0" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;">
                <asp:Label ID="ConEmpGTotal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#0000C0" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;">
                <asp:Label ID="IntOwnGTotal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#0000C0" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 483px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="IntEmpGTotal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#0000C0" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="AmtOwnGTotal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 779px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="AmtEmpGTotal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 223px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfOwnGTotal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="Blue" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfEmpGTotal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="Blue" Height="13px" Text="  " Width="51px"></asp:Label></td>
            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); width: 128px; height: 19px; text-align: center;"
                valign="middle">
                <asp:Label ID="VpfGTotal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="#404040" Height="13px" Text="  " Width="51px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="10" style="text-align: center; height: 18px; background-image: url(Image/SmallGlassBarNormal.PNG);">
                &nbsp; 
                <asp:Label ID="Label37" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Trebuchet MS"
                    Font-Size="Small" ForeColor="Red" Height="17px" Text="Your Final Provident Fund Is :"
                    Width="274px"></asp:Label><asp:Label ID="FinalAmount" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Trebuchet MS"
                    Font-Size="Small" ForeColor="Red" Height="17px" Text="  " Width="109px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="10" style="background-image: url(Image/SmallGlassBarNormal.PNG); height: 19px;
                text-align: center">
                    <asp:Label ID="Label42" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Trebuchet MS"
                        Font-Size="Small" ForeColor="Red" Height="17px" Text="Your Family Pension Is :"
                        Width="158px"></asp:Label>
                    <asp:Label ID="Label44" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Trebuchet MS"
                        Font-Size="Small" ForeColor="Red" Height="17px" Text="( Opening +Current Bal.)" Width="176px"></asp:Label>
                    <asp:Label ID="FinalFPOBal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Trebuchet MS"
                        Font-Size="Small" ForeColor="Red" Height="17px" Text="  " Width="61px"></asp:Label>
                    <asp:Label ID="Label43" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Trebuchet MS"
                        Font-Size="Small" ForeColor="Red" Height="17px" Text="+" Width="1px"></asp:Label>
                    <asp:Label ID="FPFMonth" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Trebuchet MS"
                        Font-Size="Small" ForeColor="Red" Height="17px" Text="  " Width="60px"></asp:Label>
                    <asp:Label ID="Label45" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Trebuchet MS"
                        Font-Size="Small" ForeColor="Red" Height="17px" Text=" =" Width="1px"></asp:Label>
                    <asp:Label ID="FinalFPF" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Trebuchet MS"
                        Font-Size="Small" ForeColor="Red" Height="17px" Text="  " Width="81px"></asp:Label></td>
        </tr>
    </table>
                    </asp:Panel>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</table>
    </div>
    <br />
    <!-- <input type = "button" ID="Button1" runat="server" Value="Print" onclick="JavaScript:printPartOfPage('print_area');" /></td> -->
    </div>

</asp:Content>

