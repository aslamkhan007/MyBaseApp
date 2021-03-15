<%@ Page Title="Page Hits" Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="Hits.aspx.vb" Inherits="Hits" %>

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
<table cellpadding="0" cellspacing="0" id="tblMenu"
                    class="NormalText" width="100%"><tr>
                        <td class="frameheader" colspan="4" width="100%">
                             Hits<asp:ScriptManager ID="ScriptManager2" runat="server">
                     </asp:ScriptManager>                  
                        </td>
                        <td style="background-image: url('Image/Background/Right_Shadow.png'); background-repeat: no-repeat;
                            background-position: left bottom; width: 16px;" rowspan="6">
                            &nbsp;</td>
                    </tr>
                    <tr>
                    
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
                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                <ContentTemplate>
                                    <asp:LinkButton ID="LnkFetch" runat="server" 
    CssClass="buttonc">View Report</asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LnkChart" runat="server" CssClass="buttonc"
                                        > View Chart</asp:LinkButton>
                                </ContentTemplate>
                            </asp:UpdatePanel>
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
                        
                        <asp:AsyncPostBackTrigger ControlID="LnkFetch" EventName="Click" />
                       
                    </Triggers>
                </asp:UpdatePanel>
                        </td>
                    </tr>
               
           <%--    test end--%>
 </table>
</asp:Content>

