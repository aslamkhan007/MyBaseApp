<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="Holiday_Master.aspx.vb" Inherits="Holiday_Master" title="Holiday Master" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="JavaScript" type="text/javascript"> 
 
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
 



 



    <table id="TABLE1" width="100%" >
        <tr>
            <td class="tableheader" colspan="2">
                Holiday&nbsp;Master
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td class="labelcells" colspan="2" style="display:none" >
                <asp:Label ID="Label1" runat="server" Width="119px">Expense Code</asp:Label>
                <asp:UpdatePanel ID="Code" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtCode" onclick="javascript:btnClick.click();" runat="server" CssClass="textbox"
                            Enabled="False" MaxLength="4"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 99px">
                <asp:Label ID="Label6" runat="server" Width="92px">Holiday Name</asp:Label>
            </td>
            <td class="textcells" style="width: 968px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox AccessKey="s" ID="TxtHolidayName" TabIndex="2" runat="server" Width="344px"
                            CssClass="textbox" Enabled="False" MaxLength="200" 
                            onMouseover="showhint('Please fill the full description like  OTHER EXPENSES', this, event, '150px')"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Width="80px"
                            ErrorMessage="*" ControlToValidate="TXTHOLIDAYNAME" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 99px">
                <asp:Label ID="Label7" runat="server" Width="84px">Holiday Date</asp:Label>
            </td>
            <td class="textcells" style="width: 968px">
                <asp:UpdatePanel ID="From0" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox AccessKey="d" ID="TxtDate" TabIndex="3" runat="server" Width="70px"
                            CssClass="textbox" Enabled="False" MaxLength="8" 
                            onMouseover="showhint('Please fill the date in MM/DD/YYYY 08/24/2009', this, event, '150px')"></asp:TextBox>
                        <cc1:MaskedEditValidator ID="MaskedEditValidator3" runat="server" Width="114px" ControlToValidate="TxtDate"
                            Display="Dynamic" ControlExtender="MaskedEditExtender3" TooltipMessage="MM/DD/YYYY"
                            IsValidEmpty="False" EmptyValueMessage="*" 
                            InvalidValueMessage="The Date is invalid"></cc1:MaskedEditValidator><cc1:CalendarExtender
                                ID="CalFrom0" runat="server" TargetControlID="TxtDate" 
                            Animated="False" Format="MM/dd/yyyy">
                            </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="TxtDate"
                            MaskType="Date" Mask="99/99/9999">
                        </cc1:MaskedEditExtender>
                        &nbsp;&nbsp;&nbsp;
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 99px">
                <asp:Label ID="Label8" runat="server" Width="84px">Serial No.</asp:Label>
            </td>
            <td class="textcells" style="width: 968px">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                                             <asp:TextBox ID="TxtSerial" runat="server" Width="40px" CssClass="textbox" enabled="false" maxlength="3"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="F3" runat="server" TargetControlID="TxtSerial"
                            ValidChars="1234567890.">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 99px">
                <asp:Label ID="Label3" runat="server" Width="116px">Effective From</asp:Label>
            </td>
            <td class="textcells" style="width: 968px">
                <asp:UpdatePanel ID="From" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox AccessKey="d" ID="TxtEffFrom" TabIndex="3" runat="server" Width="70px"
                            CssClass="textbox" Enabled="False" MaxLength="8" onMouseover="showhint('Please fill the date in MM/DD/YYYY 08/24/2009', this, event, '150px')"></asp:TextBox>
                        <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" Width="114px" ControlToValidate="TxtEffFrom"
                            Display="Dynamic" ControlExtender="MaskedEditExtender1" TooltipMessage="MM/DD/YYYY"
                            IsValidEmpty="False" EmptyValueMessage="*" InvalidValueMessage="The Date is invalid"></cc1:MaskedEditValidator><cc1:CalendarExtender
                                ID="CalFrom" runat="server" TargetControlID="TxtEffFrom" Animated="False" Format="MM/dd/yyyy">
                            </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="TxtEffFrom"
                            MaskType="Date" Mask="99/99/9999">
                        </cc1:MaskedEditExtender>
                        &nbsp;&nbsp;&nbsp;
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 99px; height: 15px;">
                <asp:Label ID="Label4" runat="server" Width="82px">Effective To</asp:Label>
            </td>
            <td class="textcells" style="height: 15px; width: 968px;">
                <asp:UpdatePanel ID="ETo" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtEffTo" TabIndex="4" runat="server" Width="70px" CssClass="textbox"
                            Enabled="False" MaxLength="8" onMouseover="showhint('Please fill the date in MM/DD/YYYY 08/24/2009', this, event, '150px')"></asp:TextBox><cc1:MaskedEditValidator ID="MaskedEditValidator2"
                                runat="server" ControlToValidate="TxtEffTo" Display="Dynamic" ControlExtender="MaskedEditExtender2"
                                TooltipMessage="MM/DD/YYYY" IsValidEmpty="False" EmptyValueMessage="*" InvalidValueMessage="The Date is invalid "></cc1:MaskedEditValidator><cc1:CalendarExtender
                                    ID="CalTo" runat="server" TargetControlID="TxtEffTo" Animated="False" Format="MM/dd/yyyy">
                                </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="TxtEffTo"
                            MaskType="Date" Mask="99/99/9999">
                        </cc1:MaskedEditExtender>
                        &nbsp;
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td  colspan="2">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="10" DynamicLayout="False">
                    <ProgressTemplate>
                        <asp:Image ID="ProgressBar" runat="server" Height="10px" Width="70px" ImageUrl="~/Image/loading.gif">
                        </asp:Image><br />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; text-align: center;" colspan="2" align="center" class="buttonbackbar">
                <asp:UpdatePanel ID="Add" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="CmdAdd" TabIndex="5" OnClick="CmdAdd_Click" runat="server" Height="22px"
                            Width="84px" CausesValidation="False" CssClass="buttondisable" Enabled="False">Add</asp:LinkButton><asp:LinkButton
                                ID="CmdEdit" TabIndex="6" runat="server" Height="22px" Width="84px" CausesValidation="False"
                                CssClass="buttondisable" Enabled="False" OnClick="CmdEdit_Click">Edit</asp:LinkButton><asp:LinkButton
                                    ID="CmdDeActive" TabIndex="7" runat="server" Height="22px" Width="84px" CausesValidation="False"
                                    CssClass="buttondisable" Enabled="False" OnClick="CmdDeActive_Click">DeActive</asp:LinkButton><asp:LinkButton
                                        ID="CmdClose" TabIndex="8" runat="server" Height="22px" Width="84px" CausesValidation="False"
                                        CssClass="buttonc" OnClick="CmdClose_Click">Close</asp:LinkButton><asp:LinkButton
                                            ID="CmdSearch" runat="server" CausesValidation="False" CssClass="buttonc" Height="22px"
                                            OnClick="CmdSearch_Click" TabIndex="5" Width="84px">Search</asp:LinkButton><cc1:PopupControlExtender ID="PopupExp" runat="server" CommitProperty="value" Enabled="True"
                            PopupControlID="Panel2" Position="Top" TargetControlID="CmdSearch" 
                            OffsetX="-250" OffsetY="-175"></cc1:PopupControlExtender><cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="CmdDeActive"
                            ConfirmText="Are You Sure ?"></cc1:ConfirmButtonExtender><asp:LinkButton ID="CmdAmendment" runat="server" CausesValidation="False" 
                            CssClass="buttonc" Enabled="False" Height="22px" 
                            OnClick="CmdAmendment_Click" TabIndex="6" Width="84px">Amendment</asp:LinkButton><asp:LinkButton ID="CmdAuthorize" runat="server" CausesValidation="False" 
                            CssClass="buttonc" Enabled="False" Height="22px" OnClick="CmdAuthorize_Click" 
                            TabIndex="5" Width="80px">Authorize</asp:LinkButton>
                        &nbsp;
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; text-align: center;" colspan="2" align="center" class="buttonbackbar">
                <asp:UpdatePanel ID="Movement" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="CmdFirst" runat="server" CausesValidation="False" CssClass="buttonc"
                            Height="22px" TabIndex="5" Width="84px">First</asp:LinkButton><asp:LinkButton ID="CmdNext"
                                runat="server" CausesValidation="False" CssClass="buttonc" Height="22px" TabIndex="6"
                                Width="84px">Move Next</asp:LinkButton><asp:LinkButton ID="CmdPrevious" runat="server"
                                    CausesValidation="False" CssClass="buttonc" Height="22px" TabIndex="7" Width="84px">Move Prev</asp:LinkButton><asp:LinkButton
                                        ID="CmdLast" runat="server" CausesValidation="False" CssClass="buttonc" Height="22px"
                                        TabIndex="8" Width="84px">Last</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td  colspan="2" style="height: 21px">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                   
                    <ContentTemplate>
                         <asp:Panel ID="Panel2" runat="server" Height="186px" Width="420px" CssClass="panelbg" 
                           ScrollBars="None" BorderStyle="None"> 
                            <div  id = "AdjResultsDiv"> 
                            <asp:GridView ID="GrdHelp" runat="server" Height="62px" Width="727px" HorizontalAlign="Left"
                                OnSelectedIndexChanged="grdHelp_SelectedIndexChanged" BorderStyle="Solid" 
                                    GridLines="Horizontal" BackColor="#E4E4E4" Font-Names="Tahoma" 
                                    Font-Size="8pt">
                                <PagerSettings Visible="False"></PagerSettings>
                                <RowStyle HorizontalAlign="Justify"></RowStyle>
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Select"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    &nbsp;<asp:Label ID="Label5" runat="server" Width="118px" Text="No Data Available"></asp:Label>
                                </EmptyDataTemplate>
                                <SelectedRowStyle BackColor="skyblue"></SelectedRowStyle>
                                <HeaderStyle HorizontalAlign="Left" CssClass="gridheader"></HeaderStyle>
                            </asp:GridView>
                            </div>
                    </asp:Panel> 
                 
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        &nbsp;
                        <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                            FadeInDuration="2" FadeInSteps="2" FadeOutDuration="4" FadeOutSteps="2" Visible="true">
                        </uc1:FlashMessage>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="Button1" runat="server" CausesValidation="False" CssClass="buttondisable"
                                    Height="0px" OnClick="Button1_Click" Text="Button" Width="0px" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

