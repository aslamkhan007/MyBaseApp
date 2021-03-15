<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="Salar.aspx.vb" Inherits="Salar" title="Salary Slip" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div ID="divmaster" class="noprint">
                <style media="print" type="text/css">

.noprint {
display: none;
}
</style>
<script language="javascript" type="text/javascript">
    function AccessClipboardData() {
        try {
            window.clipboardData.setData('text', "No print data");
        } catch (err) {
            // txt = "There was an error on this page.\n\n";
            // txt += "Error description: " + err.description + "\n\n";
            // txt += "Click OK to continue.\n\n";
            //  alert(txt);
        }

    }
</script>

                <script language="javascript" type="text/javascript">

    
<!--

document.onselectstart = new Function('return false'); function ds(e) { return false; } function ra() { return true; } document.onmousedown = ds; document.onclick = ra;

document.oncontextmenu = new Function('alert("Not Permitted"); return false') 



function printPartOfPage(elementId) {

 var printContent = document.getElementById(elementId);
 var windowUrl = 'about:blank';
 var uniqueName = new Date();
 var windowName = 'Print' + uniqueName.getTime();
 var printWindow=window.open(windowUrl, windowName, 'left=500000,top=500000,width=-12,height=-12');

 printWindow.document.write(printContent.innerHTML);
 printWindow.document.close();
 printWindow.focus();
 printWindow.print();
 printWindow.close();
 
 
   
        
        
        
        
}
// -->
</script>

                <script language="javascript" type="text/javascript">

    function AccessClipboardData() {
        try {
            window.clipboardData.setData('text', "No print data");
        } catch (err) {
            // txt = "There was an error on this page.\n\n";
            // txt += "Error description: " + err.description + "\n\n";
            // txt += "Click OK to continue.\n\n";
            //  alert(txt);
        }

    }
</script>

                <script language="JavaScript" type="text/javascript">

    setInterval("AccessClipboardData()", 300);
    var ClipBoardText = "";

    if (window.clipboardData) {
        ClipBoardText = window.clipboardData.getData('text');
        if (ClipBoardText == "") {
            alert('Sorry you have to allow the page to access clipboard');
            // hide the div which contains your data
            document.all("divmaster").style.display = "none"
        } else {

            document.onkeydown = function(ev) {
                var a;
                ev = window.event;
                if (typeof ev == "undefined") {
                    alert("PLEASE DON'T USE KEYBORD");
                }
                a = ev.keyCode;
                alert("PLEASE DON'T USE KEYBORD");
                return false;
            }
            document.onkeyup = function(ev) {
                var charCode;
                if (typeof ev == "undefined") {
                    ev = window.event;
                    alert("PLEASE DON'T USE KEYBORD");
                } else {
                    alert("PLEASE DON'T USE KEYBORD");
                }
                return false;
            }
        }
    }
       
</script>

                <div ID="printDiv">
                    <table cellpadding="0" cellspacing="1" style="width: 100%">
                        <tr>
                            <td class="tableheader" colspan="2">
                                Salary Slip</td>
                        </tr>
                        <tr>
                            <td class="labelcells">
                                <asp:Label ID="Label52" runat="server" Text="Select Month &amp; Year"></asp:Label>
                            </td>
                            <td class="textcells">
                                <asp:DropDownList ID="DTP2" runat="server" AutoPostBack="True" class="combobox" 
                                    Width="90px">
                                    <asp:ListItem Value="January">January</asp:ListItem>
                                    <asp:ListItem Value="February">February</asp:ListItem>
                                    <asp:ListItem Value="March">March</asp:ListItem>
                                    <asp:ListItem Value="April">April</asp:ListItem>
                                    <asp:ListItem Value="May">May</asp:ListItem>
                                    <asp:ListItem Value="June">June</asp:ListItem>
                                    <asp:ListItem Value="July">July</asp:ListItem>
                                    <asp:ListItem Value="August">August</asp:ListItem>
                                    <asp:ListItem Value="September">September</asp:ListItem>
                                    <asp:ListItem Value="October">October</asp:ListItem>
                                    <asp:ListItem Value="November">November</asp:ListItem>
                                    <asp:ListItem Value="December">December</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="DTP3" runat="server" AutoPostBack="True" 
                                    CssClass="combobox" Width="56px">
                                    <asp:ListItem>2008</asp:ListItem>
                                    <asp:ListItem>2009</asp:ListItem>
                                    <asp:ListItem>2010</asp:ListItem>
                                    <asp:ListItem>2011</asp:ListItem>
                                    <asp:ListItem>2012</asp:ListItem>
                                    <asp:ListItem>2013</asp:ListItem>
                                    <asp:ListItem>2014</asp:ListItem>
                                    <asp:ListItem>2015</asp:ListItem>
                                    <asp:ListItem>2016</asp:ListItem>
                                    <asp:ListItem>2017</asp:ListItem>
                                    <asp:ListItem>2018</asp:ListItem>
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="display" runat="server" BackColor="Transparent" 
                                    ForeColor="WhiteSmoke" Visible="False" Width="103px"></asp:Label>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                    <div ID="print_area">
                        <table ID="Panel2" cellpadding="0" cellspacing="0" 
                            style="width: 100%; height: 1px">
                            <tr>
                                <td style="width: 100%; height: 21px">
                                    <asp:Panel ID="Panel1" runat="server" Width="100%">
                                        <table style="width: 100%">
                                            <tr>
                                                <td class="labelcells">
                                                    <asp:Label ID="Label8" runat="server" class="labelcells" Height="13px" 
                                                        Text="Month" Width="64px"></asp:Label>
                                                </td>
                                                <td class="labelcells" colspan="3">
                                                    <asp:Label ID="Month" runat="server" class="labelcells" Height="13px" 
                                                        Width="122px"></asp:Label>
                                                </td>
                                                <td class="labelcells">
                                                    <asp:Label ID="Label17" runat="server" Height="13px" Text="Year" Width="64px"></asp:Label>
                                                </td>
                                                <td class="labelcells" colspan="3" style="height: 10px;">
                                                    <asp:Label ID="Year" runat="server" Height="13px" Width="129px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="labelcells" style="width: 77px; height: 10px">
                                                    <asp:Label ID="Label23" runat="server" Height="13px" Text="Name" Width="64px"></asp:Label>
                                                </td>
                                                <td class="labelcells" colspan="3" style="height: 10px;">
                                                    <asp:Label ID="Empname" runat="server" Width="207px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 108px; height: 10px">
                                                    <asp:Label ID="Label24" runat="server" Height="13px" Text="Designation" 
                                                        Width="70px"></asp:Label>
                                                </td>
                                                <td class="labelcells" colspan="3" style="height: 10px;">
                                                    <asp:Label ID="Desg" runat="server" Height="13px" Width="195px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="labelcells" style="width: 77px; height: 1px">
                                                    <asp:Label ID="Label26" runat="server" Height="13px" Text="A/C No." 
                                                        Width="46px"></asp:Label>
                                                </td>
                                                <td class="labelcells" colspan="2">
                                                    <asp:Label ID="BcodeNo" runat="server" Height="13px" Width="137px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 51px; height: 1px;">
                                                </td>
                                                <td class="labelcells" style="width: 108px; height: 1px">
                                                    <asp:Label ID="Label27" runat="server" Height="13px" Text="PAN" Width="30px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 2px; height: 1px;">
                                                    <asp:Label ID="Pan" runat="server" Height="13px" Width="85px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 102px; height: 1px">
                                                </td>
                                                <td class="labelcells" style="width: 85px; height: 1px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="labelcells" style="width: 77px; height: 10px;">
                                                    <asp:Label ID="Label3" runat="server" Height="13px" Text="Days Att." 
                                                        Width="58px"></asp:Label>
                                                </td>
                                                <td class="labelcells">
                                                    <asp:Label ID="daysattnd" runat="server" Text="Label" Width="49px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 55px; height: 10px;">
                                                    <asp:Label ID="Label12" runat="server" Height="13px" Text="Basic Pay" 
                                                        Width="80px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 51px; height: 10px;  ">
                                                    <asp:Label ID="Salary" runat="server" Height="13px" Text="Label" Width="62px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 108px; height: 10px;">
                                                    <asp:Label ID="Salary1lbl" runat="server" Height="13px" Text="Salary Advance" 
                                                        Width="88px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 2px; height: 10px;">
                                                    <asp:Label ID="Salary1" runat="server" Height="13px" Width="58px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 102px; height: 10px;">
                                                    <asp:Label ID="Label39" runat="server" Height="13px" Text="PF" Width="32px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 85px; height: 10px;">
                                                    <asp:Label ID="PF" runat="server" Height="13px" Width="65px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="labelcells" style="width: 77px; height: 13px;">
                                                    <asp:Label ID="Label5" runat="server" Height="13px" Text="PL" Width="16px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 59px; height: 13px;">
                                                    <asp:Label ID="Pl" runat="server" Text="Label" Width="50px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 55px; height: 13px;">
                                                    <asp:Label ID="Label2" runat="server" Height="13px" Text="DA" Width="16px"></asp:Label>
                                                </td>
                                                <td style="width: 51px; height: 13px;">
                                                </td>
                                                <td class="labelcells" style="width: 108px; height: 13px;">
                                                    <asp:Label ID="Label29" runat="server" Height="13px" Text="Cycle Rent" 
                                                        Width="88px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 2px; height: 13px;">
                                                    <asp:Label ID="cyclerent" runat="server" Height="13px" Width="35px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 102px; height: 13px;">
                                                    <asp:Label ID="Label40" runat="server" Height="13px" Text="VPF" Width="88px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 85px; height: 13px;">
                                                    <asp:Label ID="VPF" runat="server" Height="13px" Width="80px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="labelcells" style="width: 77px;">
                                                    <asp:Label ID="Label6" runat="server" Height="13px" Text="CL" Width="24px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 59px;">
                                                    <asp:Label ID="Cl" runat="server" Text="Label" Width="48px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 55px;">
                                                    <asp:Label ID="Label4" runat="server" Height="13px" Text="SPL D.A." 
                                                        Width="56px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 51px;">
                                                </td>
                                                <td class="labelcells" style="width: 108px;">
                                                    <asp:Label ID="Label30" runat="server" Height="13px" Text="Furn. Rent" 
                                                        Width="88px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 2px;">
                                                    <asp:Label ID="FurRent" runat="server" Height="13px" Width="44px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 102px;">
                                                    <asp:Label ID="Label41" runat="server" Height="13px" Text="F.P.F." Width="48px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 85px;  ">
                                                    <asp:Label ID="FPF" runat="server" Height="13px" Width="80px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="labelcells" style="width: 77px; height: 1px;">
                                                    <asp:Label ID="Label7" runat="server" Height="13px" Text="SL" Width="16px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 59px; height: 1px;  ">
                                                    <asp:Label ID="SL" runat="server" Text="Label" Width="49px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 55px; height: 1px;">
                                                    <asp:Label ID="Label13" runat="server" Height="13px" Text="FDA" Width="32px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 51px; height: 1px;">
                                                    <asp:Label ID="FDA" runat="server" Height="13px" Text="Label" Width="62px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 108px; height: 1px;">
                                                    <asp:Label ID="Label31" runat="server" Height="13px" Text="Tel. Charge" 
                                                        Width="88px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 2px; height: 1px;">
                                                    <asp:Label ID="TelChrg" runat="server" Height="13px" Width="2px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 102px; height: 1px;">
                                                    <asp:Label ID="Label42" runat="server" Height="13px" Text="P.F. Loan Realised" 
                                                        Width="102px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 85px; height: 1px;  ">
                                                    <asp:Label ID="PFLoan" runat="server" Height="13px" Width="80px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="labelcells" style="width: 77px; height: 2px;">
                                                    <asp:Label ID="Label77" runat="server" Height="13px" Text="Absent" Width="47px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 59px; height: 2px;">
                                                    <asp:Label ID="Absent" runat="server" Text="Label" Width="43px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 55px; height: 2px;">
                                                    <asp:Label ID="Label14" runat="server" Height="13px" Text="WB/AD/Inc." 
                                                        Width="72px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 51px; height: 2px;">
                                                    <asp:Label ID="WBADHOC" runat="server" Height="13px" Text="Label" Width="62px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 108px; height: 2px;">
                                                    <asp:Label ID="Label32" runat="server" Height="13px" Text="Elec+Bus+Tea" 
                                                        Width="104px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 2px; height: 2px;">
                                                    <asp:Label ID="Label1" runat="server" Text="Label" Width="47px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 102px; height: 2px;">
                                                    <asp:Label ID="Label43" runat="server" Height="13px" Text="L.I.C. TA.T.G" 
                                                        Width="88px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 85px; height: 2px;">
                                                    <asp:Label ID="LIC" runat="server" Height="13px" Width="80px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="labelcells" style="width: 77px; height: 7px;">
                                                    <asp:Label ID="Label9" runat="server" Height="13px" Text="LWP" Width="32px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 59px; height: 7px;">
                                                    <asp:Label ID="LWP" runat="server" Text="Label" Width="51px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 55px; height: 7px;">
                                                    <asp:Label ID="Label15" runat="server" Height="13px" Text="Per Allow" 
                                                        Width="58px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 51px; height: 7px;  ">
                                                    <asp:Label ID="perallow" runat="server" Height="13px" Width="58px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 108px; height: 7px;">
                                                    <asp:Label ID="Label33" runat="server" Height="13px" Text="Advance Staff Exp" 
                                                        Width="110px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 2px; height: 7px;  ">
                                                    <asp:Label ID="ADVSTAFFEXP" runat="server" Height="13px" Text="label1" 
                                                        Width="54px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 102px; height: 7px;">
                                                    <asp:Label ID="Label44" runat="server" Height="13px" Text="E.S.I" Width="32px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 85px; height: 7px;  ">
                                                    <asp:Label ID="ESI" runat="server" Height="13px" Width="80px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="labelcells" style="width: 77px; height: 11px;">
                                                    <asp:Label ID="Label11" runat="server" Height="13px" Text="Pays Days" 
                                                        Width="64px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 59px; height: 11px;">
                                                    <asp:Label ID="PaysDays" runat="server" Text="Label" Width="46px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 55px; height: 11px;">
                                                    <asp:Label ID="Label16" runat="server" Height="13px" Text="Arrear" Width="74px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 51px; height: 11px;  ">
                                                    <asp:Label ID="Arrear" runat="server" Height="13px" Text="Label" Width="62px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 108px; height: 11px;">
                                                    <asp:Label ID="Label34" runat="server" Height="13px" Text="Security Deposit" 
                                                        Width="105px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 2px; height: 11px;  ">
                                                    <asp:Label ID="SecuriDeposit" runat="server" Height="13px" Text="Label" 
                                                        Width="62px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 102px; height: 11px;">
                                                    <asp:Label ID="Label45" runat="server" Height="13px" Text="Rent Receivable" 
                                                        Width="92px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 85px; height: 11px;  ">
                                                    <asp:Label ID="RentRece" runat="server" Height="13px" Width="76px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="labelcells" style="width: 77px; height: 10px;">
                                                    <asp:Label ID="Label28" runat="server" BackColor="Transparent" Height="13px" 
                                                        Text="Actual Basic" Width="76px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 59px; height: 10px;  ">
                                                    <asp:Label ID="Basic" runat="server" Text="Label" Width="50px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 55px; height: 10px;">
                                                    <asp:Label ID="Label18" runat="server" Height="13px" Text="House Rent" 
                                                        Width="71px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 51px; height: 10px;  ">
                                                    <asp:Label ID="HouseRent" runat="server" Height="13px" Text="Label" 
                                                        Width="62px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 108px; height: 10px;">
                                                    <asp:Label ID="Label35" runat="server" Height="13px" Text="Thapar Staff Club" 
                                                        Width="100px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 2px; height: 10px;  ">
                                                    <asp:Label ID="THAPARSTAFF" runat="server" Height="13px" Text="Label" 
                                                        Width="61px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 102px; height: 10px;">
                                                    <asp:Label ID="Label46" runat="server" Height="13px" Text="T.W.C.C. Society" 
                                                        Width="91px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 85px; height: 10px;  ">
                                                    <asp:Label ID="TWCCSOCIETY" runat="server" Height="13px" Width="41px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="labelcells" style="width: 77px; height: 9px;">
                                                </td>
                                                <td class="labelcells" style="width: 59px; height: 9px;">
                                                </td>
                                                <td class="labelcells" style="width: 55px; height: 9px;">
                                                    <asp:Label ID="Label19" runat="server" Height="13px" Text="Tran Allow" 
                                                        Width="67px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 51px; height: 9px;">
                                                    <asp:Label ID="lbl2" runat="server" Height="13px" Text="Label" Width="62px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 108px; height: 9px; ">
                                                    <asp:Label ID="Label80" runat="server" Height="13px" Text="ABP Install." 
                                                        Width="104px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 2px; height: 9px;">
                                                    <asp:Label ID="ABPINST" runat="server" Height="13px" Text="Label" Width="63px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 102px; height: 9px;">
                                                    <asp:Label ID="Label82" runat="server" Height="13px" Text="C.T.D./R.D." 
                                                        Width="95px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 85px; height: 9px;">
                                                    <asp:Label ID="CTDRD" runat="server" Height="13px" Width="80px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="labelcells" style="width: 77px; height: 8px;">
                                                </td>
                                                <td class="labelcells" style="width: 59px; height: 8px;">
                                                </td>
                                                <td class="labelcells" style="width: 55px; height: 8px;">
                                                    <asp:Label ID="Label79" runat="server" Height="13px" Text="Others" Width="64px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 51px; height: 8px;">
                                                    <asp:Label ID="othallow" runat="server" Height="13px" Width="62px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 108px; height: 8px;">
                                                    <asp:Label ID="Label37" runat="server" Height="13px" Text="T.W.C. Store" 
                                                        Width="100px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 2px; height: 8px;">
                                                    <asp:Label ID="TWCSTORE" runat="server" Height="13px" Text="Label" Width="63px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 102px; height: 8px;">
                                                    <asp:Label ID="Label48" runat="server" Height="13px" Text="Income-Tax" 
                                                        Width="96px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 85px; height: 8px;">
                                                    <asp:Label ID="IncomeTax" runat="server" Height="13px" Width="80px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="labelcells" style="width: 77px; height: 2px;">
                                                </td>
                                                <td class="labelcells" style="width: 59px; height: 2px;">
                                                </td>
                                                <td class="labelcells" style="width: 55px; height: 2px;">
                                                    <asp:Label ID="Label21" runat="server" Height="13px" Text="Col/Elec Allow." 
                                                        Width="82px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 51px; height: 2px;">
                                                    <asp:Label ID="ColonyElec" runat="server" Height="13px" Text="Label" 
                                                        Width="62px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 108px; height: 2px; ">
                                                    <asp:Label ID="Label84" runat="server" Text="Int. Con. Charges" Width="120px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 2px; height: 2px;  ">
                                                    <asp:Label ID="LblIntConChr" runat="server" Height="13px" Text="Label" 
                                                        Width="63px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 102px; height: 2px; ">
                                                    <asp:Label ID="Label49" runat="server" Height="13px" Text="Others" Width="96px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 85px; height: 2px;  ">
                                                    <asp:Label ID="OTH" runat="server" Height="13px" Width="80px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="labelcells" style="width: 77px; height: 5px; ">
                                                </td>
                                                <td class="labelcells" style="width: 59px; height: 5px; ">
                                                </td>
                                                <td class="labelcells" style="width: 55px; height: 5px; ">
                                                    <asp:Label ID="Label10" runat="server" Height="13px" Text="Uniform Allow." 
                                                        Width="82px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 51px; height: 5px;  ">
                                                    <asp:Label ID="Uniform" runat="server" Height="13px" Text=" " Width="62px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 108px; height: 5px; ">
                                                    <asp:Label ID="Label85" runat="server" Text="Int. Monthly Rent" Width="120px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 2px; height: 5px;  ">
                                                    <asp:Label ID="LblIntRent" runat="server" Height="13px" Text="Label" 
                                                        Width="63px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 102px; height: 5px; ">
                                                    <asp:Label ID="Label50" runat="server" CssClass="HighlightLabel" Height="17px" 
                                                        Text="Total Deductions" Width="102px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 85px; height: 5px;  ">
                                                    <asp:Label ID="totaldeductions" runat="server" CssClass="HighlightLabel" 
                                                        ForeColor="Red" Height="17px" Width="100%">0</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="labelcells" style="width: 77px; height: 5px; ">
                                                    &nbsp;</td>
                                                <td class="labelcells" style="width: 59px; height: 5px;">
                                                    &nbsp;</td>
                                                <td class="labelcells" style="width: 55px; height: 5px;">
                                                    <asp:Label ID="Label83" runat="server" Text="LTA/Med. Adj" Width="84px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 51px; height: 5px;">
                                                    <asp:Label ID="LTAMED" runat="server" Height="13px" Text="Label" Width="62px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 108px; height: 5px; ">
                                                    <asp:Label ID="Label86" runat="server" Text="Claim Deduction" Width="120px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 2px; height: 5px;">
                                                    <asp:Label ID="Lblclaimded" runat="server" Height="13px" Width="63px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 102px; height: 5px; ">
                                                    &nbsp;</td>
                                                <td class="labelcells" style="width: 85px; height: 5px;">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td labelcells"="" style="width: 77px; height: 5px; class=">
                                                    &nbsp;</td>
                                                <td labelcells"="" style="width: 59px; height: 5px; class=">
                                                    &nbsp;</td>
                                                <td labelcells"="" style="width: 55px; height: 5px; class=">
                                                    <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                                                        Font-Size="8pt" ForeColor="#404040" Height="19px" 
                                                        Text="Books &amp; Perd. Allow." Width="115px"></asp:Label>
                                                </td>
                                                <td labelcells"="" style="width: 51px; height: 5px; class=">
                                                    <asp:Label ID="LblBooks" runat="server" Font-Names="Tahoma" Font-Size="8pt" 
                                                        ForeColor="#404040" Height="13px" Width="62px"></asp:Label>
                                                </td>
                                                <td labelcells"="" style="width: 108px; height: 5px; class=">
                                                    &nbsp;</td>
                                                <td labelcells"="" style="width: 2px; height: 5px; class=">
                                                    &nbsp;</td>
                                                <td labelcells"="" style="width: 102px; height: 5px; class=">
                                                    &nbsp;</td>
                                                <td labelcells"="" style="width: 85px; class=">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="labelcells" style="width: 77px; height: 5px; ">
                                                </td>
                                                <td class="labelcells" style="width: 59px; height: 5px;">
                                                </td>
                                                <td class="labelcells" style="width: 55px; height: 5px;">
                                                    <asp:Label ID="Label22" runat="server" CssClass="HighlightLabel" Height="17px" 
                                                        Text="Gross Salary" Width="84px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 51px; height: 5px;">
                                                    <asp:Label ID="GrossSal" runat="server" CssClass="HighlightLabel" 
                                                        ForeColor="Green" Height="17px" Text="0" Width="62px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 108px; height: 5px; ">
                                                    <asp:Label ID="Label38" runat="server" Height="13px" Text="Round Off" 
                                                        Width="105px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 2px; height: 5px;">
                                                    <asp:Label ID="Round" runat="server" Height="13px" Text="Label" Width="59px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 102px; height: 5px; ">
                                                    <asp:Label ID="Label51" runat="server" CssClass="HighlightLabel" Height="17px" 
                                                        Text="Net Salary" Width="102px"></asp:Label>
                                                </td>
                                                <td class="labelcells" style="width: 85px; height: 5px;">
                                                    <asp:Label ID="NetSalary" runat="server" CssClass="HighlightLabel" 
                                                        ForeColor="Blue" Height="17px" Width="100%">0</asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:Panel ID="Panel3" runat="server" Height="9px" Visible="False" Width="29px">
                        <img ID="IMG1" alt="Print Salary Slip" 
                            onclick="JavaScript:printPartOfPage('print_area');" src="Image/print_ico.gif" /></asp:Panel>
                    <!-- <input type = "button" ID="Button1" runat="server" Value="Print" onclick="JavaScript:printPartOfPage('print_area');" /></td> -->
                </div>
                <br />
                <asp:Timer ID="Timer1" runat="server" Enabled="False" Interval="2000" 
                    ontick="Timer1_Tick">
                </asp:Timer>
                <br />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <p>
        <br />
    </p>
 
</asp:Content>

