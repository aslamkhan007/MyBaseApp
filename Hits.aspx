<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Hits.aspx.vb" Inherits="Hits" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

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

</script>

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
                                font-weight: 700;" Text="Hits"></asp:Label>
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
               <table cellpadding="0" cellspacing="0" 
        style="background-position: center top; width: 100%; height: 51px; background-image: url('Image/Plain_Footer.png');" id="tblMenu"
                    class="NormalText">
                    <tr>
                    
                        <td style="background-position: right bottom; background-image: url('Image/Background/Left%20Shadow.png');
                            background-repeat: no-repeat; width: 15px;" rowspan="5">
                            &nbsp;</td>
                        <td style="background-position: center top; vertical-align: top; 
                            background-repeat: no-repeat; " height="29px" 
                            class="labelcells" colspan="4">
                             <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                 <ContentTemplate>
                                     <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                         RepeatDirection="Horizontal" AutoPostBack="True">
                                         <asp:ListItem>User Wise</asp:ListItem>
                                         <asp:ListItem Selected="True">Application Wise</asp:ListItem>
                                     </asp:RadioButtonList>
                                 </ContentTemplate>
                             </asp:UpdatePanel>
                        </td>
                        <td style="background-image: url('Image/Background/Right_Shadow.png'); background-repeat: no-repeat;
                            background-position: left bottom; width: 16px;" rowspan="5">
                            &nbsp;</td>
                    </tr>
                    <tr>
                    
                        <td style="background-position: center top; vertical-align: top; 
                            background-repeat: no-repeat; width: 26px;" height="29px" 
                            class="labelcells">
                             <asp:Label ID="Label8" runat="server" Height="16px" Text="  From Date" 
                                 Width="65px"></asp:Label>
                        </td>
                        <td style="background-position: center top; vertical-align: top;
                            background-repeat: no-repeat; width: 117px;" height="29px" 
                            class="textcells">
                <asp:UpdatePanel ID="From" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox AccessKey="d" ID="TxtEffFrom" TabIndex="3" runat="server" Width="70px"
                            CssClass="textbox" MaxLength="8" 
                            onMouseover="showhint('Please fill the date in MM/DD/YYYY 08/24/2009', this, event, '150px')"></asp:TextBox>
                        <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" Width="114px" ControlToValidate="TxtEffFrom"
                            Display="Dynamic" ControlExtender="MaskedEditExtender2" TooltipMessage="MM/DD/YYYY"
                            IsValidEmpty="False" EmptyValueMessage="*" 
                            InvalidValueMessage="The Date is invalid"></cc1:MaskedEditValidator><cc1:CalendarExtender
                                ID="CalFrom0" runat="server" TargetControlID="TxtEffFrom" 
                            Animated="False" Format="MM/dd/yyyy">
                            </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="TxtEffFrom"
                            MaskType="Date" Mask="99/99/9999">
                        </cc1:MaskedEditExtender>
                        &nbsp;&nbsp;&nbsp;
                    </ContentTemplate>
                </asp:UpdatePanel>
                        </td>
                        <td style="background-position: center top; vertical-align: top;                             background-repeat: no-repeat; width: 69px;" 
                            height="29px">
                             &nbsp;<asp:Label ID="Label9" runat="server" Text="To Date" Width="44px" 
                                 Height="16px"></asp:Label>
&nbsp;&nbsp;&nbsp; &nbsp;</td>
                        <td style="background-position: center top; vertical-align: top; 
                            background-repeat: no-repeat; width: 908px;" height="29px" 
                            class="textcells">
                <asp:UpdatePanel ID="ETo" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtEffTo" TabIndex="4" runat="server" Width="70px" 
                            CssClass="textbox" MaxLength="8" 
                            onMouseover="showhint('Please fill the date in MM/DD/YYYY 08/24/2009', this, event, '150px')"></asp:TextBox><cc1:MaskedEditValidator ID="MaskedEditValidator3"
                                runat="server" ControlToValidate="TxtEffTo" Display="Dynamic" ControlExtender="MaskedEditExtender3"
                                TooltipMessage="MM/DD/YYYY" IsValidEmpty="False" EmptyValueMessage="*" 
                            InvalidValueMessage="The Date is invalid "></cc1:MaskedEditValidator><cc1:CalendarExtender
                                    ID="CalTo" runat="server" TargetControlID="TxtEffTo" Animated="False" Format="MM/dd/yyyy">
                                </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="TxtEffTo"
                            MaskType="Date" Mask="99/99/9999">
                        </cc1:MaskedEditExtender>
                        &nbsp;
                    </ContentTemplate>
                </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                    
                        <td style="background-position: center top; vertical-align: top;
                            background-repeat: no-repeat; width: 26px; " height="29px" 
                            class="labelcells" >
                             <asp:Label ID="Label10" runat="server" Text="  Application" Height="16px" 
                                 Width="71px"></asp:Label>
                        </td>
                        <td style="background-position: center top; vertical-align: top;
                            background-repeat: no-repeat; width: 117px;" height="29px" 
                            class="textcells">
                             <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                 <ContentTemplate>
                                     <asp:DropDownList ID="DrpApp" runat="server" CssClass="combobox" Height="20px" 
                                         Width="129px" AutoPostBack="True">
                                     </asp:DropDownList>
                                 </ContentTemplate>
                             </asp:UpdatePanel>
                        </td>
                        <td style="background-position: center top; vertical-align: top; 
                            background-repeat: no-repeat; width: 69px;" height="29px">
                             &nbsp;<asp:Label ID="Label11" runat="server" Text="Page Name" Height="16px" 
                                 Width="65px"></asp:Label>
                             &nbsp;</td>
                        <td style="background-position: center top; vertical-align: top; 
                            background-repeat: no-repeat; width: 908px;" height="29px" 
                            class="textcells">
                             <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                 <ContentTemplate>
                                     <asp:DropDownList ID="DrpPage" runat="server" CssClass="combobox" Height="19px" 
                                         Width="311px">
                                     </asp:DropDownList>
                                 </ContentTemplate>
                             </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                    
                        <td height="29px" colspan="4" class="buttonbackbar">
                        <asp:LinkButton ID="LnkFetch" runat="server" CssClass="buttonc">Fetch</asp:LinkButton>
                        &nbsp;
                        </td>
                    </tr>
                    <tr>
                    
                        <td style="background-position: center top; vertical-align: top; background-image: url('Image/Plain_Footer.png');
                            background-repeat: no-repeat;" colspan="4">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" GridLines="None" CssClass="GridViewStyle" Width="100%" pagesize="50" 
    AllowPaging="true">
                            <RowStyle CssClass="RowStyle" />
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <PagerStyle CssClass="PagerStyle" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <EditRowStyle CssClass="EditRowStyle" />
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="LnkFetch" EventName="Click" />
                       
                    </Triggers>
                </asp:UpdatePanel>
                        </td>
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

