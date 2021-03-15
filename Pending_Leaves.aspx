<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Pending_Leaves.aspx.vb" Inherits="Pending_Leaves" title="Pending Leaves" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script language="JavaScript" type="text/javascript" > 
 
function clickButton(e, buttonid){ 
      var evt = e ? e : window.event;
      var bt = document.getElementById(buttonid);
      if (bt)
      { 
          if (evt.keyCode == 13)
          { 
             bt.click(); 
              
                return false; 
          } 
      }

  }
  var FADINGTOOLTIP
  var wnd_height, wnd_width;
  var tooltip_height, tooltip_width;
  var tooltip_shown = false;
  var transparency = 100;
  var timer_id = 1;
  var tooltiptext;

  // override events
  window.onload = WindowLoading;
  window.onresize = UpdateWindowSize;
  document.onmousemove = AdjustToolTipPosition;

  function DisplayTooltip(tooltip_text) {
      FADINGTOOLTIP.innerHTML = tooltip_text;
      tooltip_shown = (tooltip_text != "") ? true : false;
      if (tooltip_text != "") {
          // Get tooltip window height
          tooltip_height = (FADINGTOOLTIP.style.pixelHeight) ? FADINGTOOLTIP.style.pixelHeight : FADINGTOOLTIP.offsetHeight;
          transparency = 0;
          ToolTipFading();
      }
      else {
          clearTimeout(timer_id);
          FADINGTOOLTIP.style.visibility = "hidden";
      }
  }

  function AdjustToolTipPosition(e) {
      if (tooltip_shown) {
          // Depending on IE/Firefox, find out what object to use to find mouse position
          var ev;
          if (e)
              ev = e;
          else
              ev = event;

          FADINGTOOLTIP.style.visibility = "visible";

          offset_y = (ev.clientY + tooltip_height - document.body.scrollTop + 30 >= wnd_height) ? -15 - tooltip_height : 20;
          FADINGTOOLTIP.style.left = Math.min(wnd_width - tooltip_width - 10, Math.max(3, ev.clientX + 6)) + document.body.scrollLeft + 'px';
          FADINGTOOLTIP.style.top = ev.clientY + offset_y + document.body.scrollTop + 'px';
      }
  }

  function WindowLoading() {
      FADINGTOOLTIP = document.getElementById('FADINGTOOLTIP');

      // Get tooltip  window width				
      tooltip_width = (FADINGTOOLTIP.style.pixelWidth) ? FADINGTOOLTIP.style.pixelWidth : FADINGTOOLTIP.offsetWidth;

      // Get tooltip window height
      tooltip_height = (FADINGTOOLTIP.style.pixelHeight) ? FADINGTOOLTIP.style.pixelHeight : FADINGTOOLTIP.offsetHeight;

      UpdateWindowSize();
  }

  function ToolTipFading() {
      if (transparency <= 100) {
          FADINGTOOLTIP.style.filter = "alpha(opacity=" + transparency + ")";
          //FADINGTOOLTIP.style.opacity=transparency/100;
          transparency += 12;
          timer_id = setTimeout('ToolTipFading()', 35);
      }
  }

  function UpdateWindowSize() {
      wnd_height = document.body.clientHeight;
      wnd_width = document.body.clientWidth;
  }
</script>
<div class="FadingTooltip" id="FADINGTOOLTIP" style="Z-INDEX: 999; VISIBILITY: hidden; POSITION: absolute"></div>
<style type="text/css">
            .FadingTooltip { BORDER-RIGHT: darkgray 1px outset; BORDER-TOP: darkgray 1px outset; FONT-SIZE: 12pt; BORDER-LEFT: darkgray 1px outset; WIDTH: auto; COLOR: black; BORDER-BOTTOM: darkgray 1px outset; HEIGHT: auto; BACKGROUND-COLOR: lemonchiffon; MARGIN: 3px 3px 3px 3px; padding: 3px 3px 3px 3px; borderBottomWidth: 3px 3px 3px 3px }
</style>
    <table style="width:100%;">
    <table class="NormalText" cellpadding="0" cellspacing="0" style="width: 100%; height: 37px;"
                    __designer:mapid="b6">
                    <tr __designer:mapid="b7">
                        <td rowspan="5" style="background-position: right -4px; width: 28px; background-image: url('Image/Frame/Frame_Left.png');
                            background-repeat: no-repeat;" __designer:mapid="b8">
                        </td>
                        <td style="background-position: 0px -4px; background-image: url('Image/Frame/Frame_Vertical_Back.png');
                            height: 37px; font-size: 3pt;" valign="middle" __designer:mapid="b9">
                            <br __designer:mapid="ba" />
                            <asp:Label ID="Label7" runat="server" Style="font-family: 'Trebuchet MS'; font-size: small;
                                font-weight: 700;" Text="Pending Leaves"></asp:Label>
                            <asp:ScriptManager ID="ScriptManager2" runat="server">
                     </asp:ScriptManager>                  
                        </td>
                        <td rowspan="5" style="background-image: url('Image/Frame/Frame_Right.png'); background-repeat: no-repeat;
                            background-position: left -4px; width: 28px;">
                        </td>
                    </tr>
                 
                </table>
               <tr>
    <%--    test end--%>
               <table cellpadding="0" cellspacing="0" style="width: 100%; height: 51px;" id="tblMenu"
                    class="NormalText">
                    <tr>
                    
                        <td style="background-position: right bottom; background-image: url('Image/Background/Left%20Shadow.png');
                            background-repeat: no-repeat; width: 16px;">
                            &nbsp;</td>
                    
                        <td style="background-position: center top; vertical-align: top; background-image: url('Image/Plain_Footer.png');
                            background-repeat: no-repeat;">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" GridLines="None" 
                            CssClass="GridViewStyle" Width="100%" pagesize="30" 
    AllowPaging="true">
                            <RowStyle CssClass="RowStyle" />
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <PagerStyle CssClass="PagerStyle" />
                            <EmptyDataTemplate>
                                No Pending Leaves to be Authorized by you and your subordinates.
                            </EmptyDataTemplate>
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <EditRowStyle CssClass="EditRowStyle" />
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                        </asp:GridView>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                     </td>
                        <td style="background-image: url('Image/Background/Right_Shadow.png'); background-repeat: no-repeat;
                            background-position: left bottom; width: 16px;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                    
                        <td style="background-position: right bottom; background-image: url('Image/Background/Left%20Shadow.png');
                            background-repeat: no-repeat; width: 16px;">
                            &nbsp;</td>
                    
                        <td style="background-position: center top; vertical-align: top; background-image: url('Image/Plain_Footer.png');
                            background-repeat: no-repeat;" align="center">
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="emp_home.aspx">Back</asp:HyperLink>
                        </td>
                        <td style="background-image: url('Image/Background/Right_Shadow.png'); background-repeat: no-repeat;
                            background-position: left bottom; width: 16px;">
                            &nbsp;</td>
                    </tr>
                </table>
           <%--    test end--%>
            <td style="background-position: right bottom; background-image: url('Image/Background/Left%20Shadow.png');
                            background-repeat: no-repeat; width: 16px;">
               
            </td>
                 
        </tr>
        <tr>
            <td style="text-align: left; " >                  
               
            </td>
                 
        </tr>
        <tr>
        <td style="width: 83px">
          <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="Button1" runat="server" CausesValidation="False" CssClass="buttondisable"
                                    Height="0px" OnClick="Button1_Click" Text="Button" Width="0px" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
        </td>
        </tr>
    </table>
</asp:Content>

