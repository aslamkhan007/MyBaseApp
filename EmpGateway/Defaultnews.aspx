<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" title="Welcome to Employee Gateway" %>



<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script language="javascript" type="text/javascript"  src="CalendarControl.js">
//function ShowMarquee()
//{
// var marquee="<font color="#FF0000" face = "Tahoma" > <marquee scrolldelay=10 scrollamount = 1>MyText</marquee></font>"; 
// document.write(marquee);
//}
</script>
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="3" style= "background-image: url(image/redbar25px.png); height: 23px;font-weight: bold;  font-size: 10pt; color: white; font-family: 'Trebuchet MS';">
            <script id ="a" language="JavaScript1.2">

/*
Cross browser Marquee script- © Dynamic Drive (www.dynamicdrive.com)
For full source code, 100's more DHTML scripts, and Terms Of Use, visit http://www.dynamicdrive.com
Credit MUST stay intact
*/

//Specify the marquee's width (in pixels)
var marqueewidth="730px"
//Specify the marquee's height
var marqueeheight="18px"
//Specify the marquee's marquee speed (larger is faster 1-10)
var marqueespeed=2
//configure background color:
var marqueebgcolor="#000000"
//Pause marquee onMousever (0=no. 1=yes)?
var pauseit=1

//Specify the marquee's content (don't delete <nobr> tag)
//Keep all content on ONE line, and backslash any single quotations (ie: that\'s great):

//var marqueecontent='<nobr><p style = "">Marquee: dimentions, speed, color and content hard coded within the script. Thank you for visiting <a href="http://www.ipopper.net">ValleySites.ca</a>.  If you find this site useful, please contact us to let us know <a href="../contact_us/default.asp">click here</a>. Enjoy your stay!</p></nobr>'
var marqueecontent
////NO NEED TO EDIT BELOW THIS LINE////////////
marqueespeed=(document.all)? marqueespeed : Math.max(1, marqueespeed-1) //slow speed down by 1 for NS
var copyspeed=marqueespeed
var pausespeed=(pauseit==0)? copyspeed: 0
var iedom=document.all||document.getElementById
if (iedom)
document.write('<span id="temp" style="visibility:hidden;position:absolute;top:-100px;left:-9000px">'+marqueecontent+'</span>')
var actualwidth=''
var cross_marquee, ns_marquee

function populate(){
if (iedom){
cross_marquee=document.getElementById? document.getElementById("iemarquee") : document.all.iemarquee
cross_marquee.style.left=parseInt(marqueewidth)+8+"px"
cross_marquee.innerHTML='<div style = "filter:shadow(color:black,strength:2,direction:135);">' + marqueecontent + '</div>'
actualwidth=document.all? temp.offsetWidth : document.getElementById("temp").offsetWidth
}
else if (document.layers){
ns_marquee=document.ns_marquee.document.ns_marquee2
ns_marquee.left=parseInt(marqueewidth)+8
ns_marquee.document.write(marqueecontent)
ns_marquee.document.close()
actualwidth=ns_marquee.document.width
}
lefttime=setInterval("scrollmarquee()",20)
}
window.onload=populate

function scrollmarquee(){
if (iedom){
if (parseInt(cross_marquee.style.left)>(actualwidth*(-1)+8))
cross_marquee.style.left=parseInt(cross_marquee.style.left)-copyspeed+"px"
else
cross_marquee.style.left=parseInt(marqueewidth)+8+"px"

}
else if (document.layers){
if (ns_marquee.left>(actualwidth*(-1)+8))
ns_marquee.left-=copyspeed
else
ns_marquee.left=parseInt(marqueewidth)+8
}
}

if (iedom||document.layers){
with (document){
document.write('<table border="0" cellspacing="0" cellpadding="0"><td>')
if (iedom){
write('<div style="position:relative;width:'+marqueewidth+';height:'+marqueeheight+';overflow:hidden">')
//write('<div style="position:absolute;width:'+marqueewidth+';height:'+marqueeheight+';background-color:'+marqueebgcolor+'" onMouseover="copyspeed=pausespeed" onMouseout="copyspeed=marqueespeed">')
write('<div style="position:absolute;width:'+marqueewidth+';height:'+marqueeheight+'" onMouseover="copyspeed=pausespeed" onMouseout="copyspeed=marqueespeed">')
write('<div id="iemarquee" style="position:absolute;left:0px;top:0px"></div>')
write('</div></div>')
}
else if (document.layers){
write('<ilayer width='+marqueewidth+' height='+marqueeheight+' name="ns_marquee" bgColor='+marqueebgcolor+'>')
write('<layer name="ns_marquee2" left=0 top=0 onMouseover="copyspeed=pausespeed" onMouseout="copyspeed=marqueespeed"></layer>')
write('</ilayer>')
}
document.write('</td></table>')
}
}
</script>
                <asp:Panel ID="Panel1" runat="server" Height="23px" Width="100%" BackImageUrl="~/Image/RedBar25px.PNG" Font-Bold="True" Font-Names="Tahoma" Font-Size="16px" Font-Underline="False" ForeColor="White" Visible="False">
                
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="height: 23px">
        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="ButtonBack" Font-Bold="True"
        Font-Names="Trebuchet MS" Font-Size="10pt" PostBackUrl="~/MyWorkArae.aspx" Style="vertical-align: bottom;
        text-align: center" Width="240px">My Consent Area</asp:LinkButton></td>
            <td style="height: 25px">
                <asp:LinkButton
                ID="LnkPostal" runat="server" CssClass="ButtonBack" Font-Bold="True" Font-Names="Trebuchet MS"
                Font-Size="10pt" PostBackUrl="~/UnderConstruction.aspx" Style="vertical-align: bottom;
                text-align: center" Width="246px">My Postal Mails</asp:LinkButton></td>
            <td style="height: 25px">
                <asp:LinkButton
            ID="LnkAction" runat="server" CssClass="ButtonBack" Font-Bold="True" Font-Names="Trebuchet MS"
            Font-Size="10pt" PostBackUrl="~/MyActions.aspx" Style="vertical-align: bottom;
            text-align: center" Width="252px">My Action Area</asp:LinkButton></td>
        </tr>
        <tr>
            <td colspan="3" style="height: 340px; text-align: center; background-image: url(jackets.png);" valign="middle">
                </td>
        </tr>
    </table>
</asp:Content>

