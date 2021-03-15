<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Default.aspx.vb" Inherits="Default_New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%; height: 500px;" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2" class="Marquee">
                <%-- <script type = "text/javascript" src = "Scripts/Scroll.js" > </script>--%>

                <script id="a" language="JavaScript1.2">

/*
Cross browser Marquee script- © Dynamic Drive (www.dynamicdrive.com)
For full source code, 100's more DHTML scripts, and Terms Of Use, visit http://www.dynamicdrive.com
Credit MUST stay intact
*/

//Specify the marquee's width (in pixels)
var marqueewidth = document.body.offsetWidth - 2 //"775px"
marqueewidth += "px"
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
lefttime=setInterval("scrollmarquee()",21)
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
            </td>
        </tr>
        <tr>
            <td class="style1" style="height: 500px; vertical-align: top; width: 50%;">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:DataList ID="DataList2" runat="server" CellPadding="0" RepeatColumns="1" RepeatDirection="Horizontal"
                    HorizontalAlign="Center" Height="16px" Width="100%">
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="0" style="width: 100%; height: 200px;">
                            <tr>
                                <td rowspan="6" style="background-position: right -4px; width: 28px; background-image: url('Image/Frame/Frame_Left.png');
                                    background-repeat: no-repeat;">
                                </td>
                                <td colspan="2" style="background-position: 0px -4px; background-image: url('Image/Frame/Frame_Vertical_Back.png');
                                    height: 37px; font-size: 3pt;" valign="middle">
                                    <br />
                                    <asp:Label ID="Label7" runat="server" Style="font-family: 'Trebuchet MS'; font-size: small;
                                        font-weight: 700;" Text='<%# Eval("Data") %>'></asp:Label>
                                </td>
                                <td rowspan="6" style="background-image: url('Image/Frame/Frame_Right.png'); background-repeat: no-repeat;
                                    background-position: left -4px; width: 28px;">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="background-position: center top; background-repeat: no-repeat;
                                    background-image: url('Image/Plain_Footer.png');" valign="top">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Horizontal"
                                                Style="font-size: 8pt; text-align: left; font-weight: 700;">
                                                <StaticMenuItemStyle CssClass="frame_tab_item" />
                                                <StaticSelectedStyle CssClass="frame_tab_item_selected" />
                                                <DataBindings>
                                                    <asp:MenuItemBinding DataMember="MenuItem" TextField="text" ToolTipField="text" ValueField="value" />
                                                </DataBindings>
                                                <Items>
                                                    <asp:MenuItem Text="One" Value="One"></asp:MenuItem>
                                                    <asp:MenuItem Text="Two" Value="Two"></asp:MenuItem>
                                                </Items>
                                            </asp:Menu>
                                            <table cellpadding="0" cellspacing="0" style="width: 100%;">
                                                <tr>
                                                    <td colspan="2" style="vertical-align: top">
                                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("itemcode") %>' />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top">
                                                        <asp:DataList ID="dlChild" runat="server" CellPadding="0" RepeatColumns="1" Width="100%">
                                                            <ItemTemplate>
                                                                <table cellpadding="0" cellspacing="0" style="width: 100%; height: 42px;">
                                                                    <tr>
                                                                        <td style="text-align: left; height: 12px; width: 100%;" valign="top">
                                                                            <asp:LinkButton ID="LinkButton5" runat="server" Text='<%# Eval("text") %>' ToolTip="Click Here To View Details"
                                                                                Visible="False"></asp:LinkButton>
                                                                            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# Eval("url") %>' Style="font-weight: 700"
                                                                                Text='<%# Eval("text") %>'></asp:HyperLink>
                                                                            <asp:Label ID="Label8" runat="server" Font-Bold="False" ForeColor="#666666" Style="font-size: 7pt"
                                                                                Text='<%# Eval("text") %>' Visible="False"></asp:Label>
                                                                        </td>
                                                                        <td rowspan="2">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="text-align: left; width: 100%; height: 150px;" valign="top">
                                                                            <div style="height: 100%; width: 100%; font-weight: normal; overflow: hidden;">
                                                                                <%--<asp:Label ID="Label3" runat="server" Text="This is sample text. This is sample text. This is sample text. This is sample text. This is sample text. "></asp:Label>--%>
                                                                                <asp:Label ID="Label9" runat="server" Text='<%# Eval("desc") %>'> </asp:Label>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </td>
                                                    <td style="width: 140px; text-align: right;" valign="top">
                                                        <asp:Image ID="Image1" runat="server" Height="160px" ImageUrl="~/Image/Icons/no_image.gif"
                                                            Width="140px" Style="text-align: right" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="background-position: left; height: 20px; background-image: url('Image/Frame/Frame_Bottom.png');
                                    background-repeat: no-repeat;">
                                </td>
                                <td style="background-position: right; height: 20px; background-image: url('Image/Frame/Frame_Bottom.png');
                                    background-repeat: no-repeat;">
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
            <td class="style1" style="height: 500px; vertical-align: top; width: 50%; margin-left: 40px;">
                <asp:DataList ID="DataList4" runat="server" CellPadding="0" RepeatColumns="1" RepeatDirection="Horizontal"
                    HorizontalAlign="Center" Height="16px" Width="100%">
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="0" style="width: 100%; height: 200px;">
                            <tr>
                                <td rowspan="6" style="background-position: right -4px; width: 28px; background-image: url('Image/Frame/Frame_Left.png');
                                    background-repeat: no-repeat;">
                                </td>
                                <td colspan="2" style="background-position: 0px -4px; background-image: url('Image/Frame/Frame_Vertical_Back.png');
                                    height: 37px; font-size: 3pt;" valign="middle">
                                    <br />
                                    <asp:Label ID="Label7" runat="server" Style="font-family: 'Trebuchet MS'; font-size: small;
                                        font-weight: 700;" Text='<%# Eval("Data") %>'></asp:Label>
                                </td>
                                <td rowspan="6" style="background-image: url('Image/Frame/Frame_Right.png'); background-repeat: no-repeat;
                                    background-position: left -4px; width: 28px;">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="background-position: center top; background-repeat: no-repeat;
                                    background-image: url('Image/Plain_Footer.png');" valign="top">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:Menu ID="Menu2" runat="server" OnMenuItemClick="Menu2_MenuItemClick" Orientation="Horizontal"
                                                Style="font-size: 8pt; text-align: left; font-weight: 700;" OnLoad="Menu2_Load">
                                                <StaticMenuItemStyle CssClass="frame_tab_item" />
                                                <StaticSelectedStyle CssClass="frame_tab_item_selected" />
                                                <DataBindings>
                                                    <asp:MenuItemBinding DataMember="MenuItem" TextField="text" ToolTipField="text" ValueField="value" />
                                                </DataBindings>
                                                <Items>
                                                    <asp:MenuItem Text="One" Value="One"></asp:MenuItem>
                                                    <asp:MenuItem Text="Two" Value="Two"></asp:MenuItem>
                                                </Items>
                                            </asp:Menu>
                                            <table cellpadding="0" cellspacing="0" style="width: 100%;">
                                                <tr>
                                                    <td colspan="2" style="vertical-align: top">
                                                        <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("itemcode") %>' />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top">
                                                        <asp:DataList ID="dlChild2" runat="server" CellPadding="0" RepeatColumns="1" Width="100%">
                                                            <ItemTemplate>
                                                                <table cellpadding="0" cellspacing="0" style="width: 100%; height: 42px;">
                                                                    <tr>
                                                                        <td style="text-align: left; height: 12px; width: 100%;" valign="top">
                                                                            <asp:LinkButton ID="LinkButton5" runat="server" Text='<%# Eval("text") %>' ToolTip="Click Here To View Details"
                                                                                Visible="False"></asp:LinkButton>
                                                                            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# Eval("url") %>' Style="font-weight: 700"
                                                                                Text='<%# Eval("text") %>'></asp:HyperLink>
                                                                            <asp:Label ID="Label8" runat="server" Font-Bold="False" ForeColor="#666666" Style="font-size: 7pt"
                                                                                Text='<%# Eval("text") %>' Visible="False"></asp:Label>
                                                                        </td>
                                                                        <td rowspan="2">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="text-align: left; width: 100%; height: 150px;" valign="top">
                                                                            <div style="height: 100%; width: 100%; font-weight: normal; overflow: auto;">
                                                                                <%--<asp:Label ID="Label3" runat="server" Text="This is sample text. This is sample text. This is sample text. This is sample text. This is sample text. "></asp:Label>--%>
                                                                                <asp:Label ID="Label9" runat="server" Text='<%# Eval("desc") %>'> </asp:Label>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </td>
                                                    <td style="width: 140px; text-align: right;" valign="top">
                                                        <asp:Image ID="Image2" runat="server" Height="160px" ImageUrl="~/Image/Icons/no_image.gif"
                                                            Width="140px" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="background-position: left; height: 20px; background-image: url('Image/Frame/Frame_Bottom.png');
                                    background-repeat: no-repeat;">
                                </td>
                                <td style="background-position: right; height: 20px; background-image: url('Image/Frame/Frame_Bottom.png');
                                    background-repeat: no-repeat;">
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <asp:DataList ID="oDataList4" runat="server" CellPadding="0" RepeatColumns="1" RepeatDirection="Horizontal"
                    HorizontalAlign="Center" Height="16px" Width="100%">
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="0" style="width: 100%; height: 200px;">
                            <tr>
                                <td rowspan="6" style="background-position: right -4px; width: 28px; background-image: url('Image/Frame/Frame_Left.png');
                                    background-repeat: no-repeat;">
                                </td>
                                <td colspan="2" style="background-position: 0px -4px; background-image: url('Image/Frame/Frame_Vertical_Back.png');
                                    height: 37px; font-size: 1pt;" valign="middle">
                                    <br />
                                    <br />
                                    <br />
                                    <asp:Label ID="Label2" runat="server" Style="font-family: 'Trebuchet MS', Arial;
                                        font-weight: bold; font-size: 10pt;" Text='<%# Eval("Data") %>'></asp:Label>
                                </td>
                                <td rowspan="6" style="background-image: url('Image/Frame/Frame_Right.png'); background-repeat: no-repeat;
                                    background-position: left -4px; width: 28px;">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="background-position: center top; background-repeat: no-repeat;
                                    background-image: url('Image/Plain_Footer.png');" valign="top">
                                    <table cellpadding="0" cellspacing="0" style="width: 100%;">
                                        <tr>
                                            <td colspan="2" style="vertical-align: top">
                                                <%--<asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" Style="font-size: 8pt;
                                                            text-align: left;">
                                                            <StaticMenuItemStyle CssClass="frame_tab_item" />
                                                            <DataBindings>
                                                                <asp:MenuItemBinding DataMember="MenuItem" TextField="text" 
                                                                    ToolTipField="text" />
                                                            </DataBindings>
                                                            <Items>
                                                                <asp:MenuItem Text="One" Value="One"></asp:MenuItem>
                                                                <asp:MenuItem Text="Two" Value="Two"></asp:MenuItem>
                                                            </Items>
                                                        </asp:Menu>--%>
                                                <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Horizontal"
                                                    Style="font-size: 8pt; text-align: left; font-weight: 700;">
                                                    <StaticMenuItemStyle CssClass="frame_tab_item" />
                                                    <DataBindings>
                                                        <asp:MenuItemBinding DataMember="MenuItem" TextField="text" ToolTipField="text" ValueField="value" />
                                                    </DataBindings>
                                                    <Items>
                                                        <asp:MenuItem Text="One" Value="One"></asp:MenuItem>
                                                        <asp:MenuItem Text="Two" Value="Two"></asp:MenuItem>
                                                    </Items>
                                                </asp:Menu>
                                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("itemcode") %>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top">
                                                <asp:DataList ID="dlChild" runat="server" CellPadding="0" RepeatColumns="1" Width="100%">
                                                    <ItemTemplate>
                                                        <table cellpadding="0" cellspacing="0" style="width: 100%; height: 42px;">
                                                            <tr>
                                                                <td style="text-align: left; height: 12px; width: 100%;" valign="top">
                                                                    <asp:LinkButton ID="LinkButton4" runat="server" Text='<%# Eval("text") %>' ToolTip="Click Here To View Details"
                                                                        Visible="False"></asp:LinkButton>
                                                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# Eval("url") %>' Style="font-weight: bold"
                                                                        Text='<%# Eval("text") %>'></asp:HyperLink>
                                                                    <asp:Label ID="Label5" runat="server" Font-Bold="False" ForeColor="#666666" Style="font-size: 7pt"
                                                                        Text='<%# Eval("text") %>' Visible="False"></asp:Label>
                                                                </td>
                                                                <td rowspan="2">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left; width: 100%; height: 100px;" valign="top">
                                                                    <div style="height: 100%; width: 100%; font-weight: normal; overflow: hidden;">
                                                                        <%--<asp:Label ID="Label3" runat="server" Text="This is sample text. This is sample text. This is sample text. This is sample text. This is sample text. "></asp:Label>--%>
                                                                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("desc") %>'> </asp:Label>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </td>
                                            <td style="width: 100px;" valign="top">
                                                <asp:Image ID="Image1" runat="server" Height="160px" ImageUrl="~/Image/Icons/no_image.gif"
                                                    Width="140px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="background-position: left; height: 20px; background-image: url('Image/Frame/Frame_Bottom.png');
                                    background-repeat: no-repeat;">
                                </td>
                                <td style="background-position: right; height: 20px; background-image: url('Image/Frame/Frame_Bottom.png');
                                    background-repeat: no-repeat;">
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
</asp:Content>
