<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="GuestHouseReq.aspx.vb" Inherits="GuestHouseReq" Title="Guest House Requisition Request" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
    <script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

}

// ]]>
    </script>

    <table style="width: 100%" class="frameheader">
        <tr>
            <td >
                <asp:Label ID="Label6" runat="server" Text="Guest House Requisition"
                    Width="155px"></asp:Label>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
    </table>
    <span >
        <table style="border-top-width: 1px; border-left-width: 1px; font-size: 3pt; border-left-color: #000000;
            border-bottom-width: 1px; border-bottom-color: #000000; width: 100%; border-top-color: #000000;
            border-right-width: 1px; border-right-color: #000000" cellspacing="0">
            <tr>
                <td class="labelcells" style="width: 88px">
                    <asp:Label ID="Label14" runat="server"  Text="Company :" Width="64px" 
                        Height="16px"></asp:Label></td>
                <td class="textcells">
                    <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                        <ContentTemplate>
                            <span >
                            <asp:DropDownList ID="DdlComp" runat="server" 
    AutoPostBack="True" Font-Names="Tahoma"
                        Font-Size="8pt" Width="140px">
                            </asp:DropDownList>
                            </span>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="labelcells" colspan="2">
                                    </td>
            </tr>
            <tr>
                <td class="labelcells" 
                    
                    style="border-left: 1px groove #000000; border-top: 1px groove #000000; width: 88px;" 
                    valign="bottom">
                    &nbsp;</td>
                <td class="labelcells" 
                    
                    style="border-top-style: groove; border-top-width: 1px; border-top-color: #000000; border-right-style: groove; border-right-width: 1px; border-right-color: #000000;">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="21px" 
                                RepeatDirection="Horizontal" Width="152px" AutoPostBack="True">
                                <asp:ListItem Selected="True">Outsider</asp:ListItem>
                                <asp:ListItem>JCTian</asp:ListItem>
                            </asp:RadioButtonList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="labelcells" 
                    
                    style="border-left: 1px groove #000000;  width: 88px;" 
                    valign="bottom">
                    <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                        <ContentTemplate>
                            <span>
                            <asp:Label ID="Label24" runat="server" Text="Emp Code"></asp:Label>
                            </span>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="labelcells" 
                    
                    style=" border-right-style: groove; border-right-width: 1px; border-right-color: #000000;">
                            <span __designer:mapid="dfb">
                            <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                <ContentTemplate>
                                    <span>
                                    <asp:TextBox ID="txtempcode" runat="server" CssClass="textbox" MaxLength="10"></asp:TextBox>
                                    </span>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            </span>
                </td>
            </tr>
            <tr>
                <td class="labelcells" 
                    style="border-left: 1px groove #000000; width: 88px;">
                    <asp:Label ID="Label2" runat="server"  Text="No. Of Persons :" Width="87px" 
                        Height="16px"></asp:Label></td>
                <td class="textcells" 
                    
                    style="border-right-style: groove; border-right-width: 1px; border-right-color: #000000">
                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                        <ContentTemplate>
                            <span >
                            <asp:TextBox ID="TxtPerson" runat="server" Width="33px" 
    class="textbox" ></asp:TextBox>
                            </span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="TxtPerson" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" 
                                TargetControlID="TxtPerson" ValidChars="0123456789.">
                            </cc1:FilteredTextBoxExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="labelcells" 
                    style="border-left: 1px groove #000000; width: 88px;">
    <span >
                    <asp:Label ID="Label21" runat="server"  Text="Name of Guest" Width="84px"></asp:Label>
       </span></td>
                <td class="textcells" 
                    
                    style="border-right-style: groove; border-right-width: 1px; border-right-color: #000000">
    <span >
                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                        <ContentTemplate>
                            <span >
                            <asp:TextBox ID="TxtName" runat="server" Width="175px" 
    Font-Names="Tahoma" Font-Size="8pt"></asp:TextBox>
                            </span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="TxtName" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
       </span>
                </td>
            </tr>
            <tr>
                <td class="labelcells" 
                    style="border-left: 1px groove #000000; height: 17px; width: 88px;">
                    <asp:Label ID="Label22" runat="server" Text="Address Of Guest"></asp:Label>
                    </td>
                <td class="textcells" 
                    
                    style="height: 17px; border-right-style: groove; border-right-width: 1px; border-right-color: #000000;">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="TxtAdd" runat="server" CssClass="textbox" 
                                Height="28px" TextMode="MultiLine" Width="436px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="TxtAdd" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
            </tr>
            <tr>
                <td class="labelcells" 
                    
                    style="border-left: 1px groove #000000; border-bottom: 1px groove #000000; width: 88px;">
                    <asp:Label ID="Label23" runat="server" Text="Phone Number"></asp:Label>
                </td>
                <td class="textcells" 
                    
                    style="border-bottom-style: groove; border-bottom-width: 1px; border-bottom-color: #000000; border-right-style: groove; border-right-width: 1px; border-right-color: #000000;">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="TxtGuestPhone" runat="server" CssClass="textbox" Width="153px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" 
                                TargetControlID="TxtGuestPhone" ValidChars="0.123456789-">
                            </cc1:FilteredTextBoxExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="labelcells" style="width: 88px">
                     </td>
                <td class="textcells">
                    <asp:UpdatePanel ID="UpdatePanel36" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label25" runat="server" visible="false" style="width: 300px" 
                                Text="Your Request Submitted Successfully" ForeColor="Red"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel></td>
            </tr>
            <tr>
                <td class="labelcells" style="width: 88px">
                    <asp:Label ID="Label4" runat="server" Text="To be Charged :" Width="88px" 
                        Height="16px"></asp:Label></td>
    <span >
                <td class="labelcells">
                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                        <ContentTemplate>
                            <span >
                            <asp:RadioButtonList ID="RLCharge" runat="server" 
    Font-Bold="True" Font-Names="Tahoma"
                        Font-Size="8pt" RepeatDirection="Horizontal" 
    Width="140px" ForeColor="#404040">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N">No</asp:ListItem>
                            </asp:RadioButtonList>
                            </span>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
       </span>
            </tr>
            <tr>
                <td class="labelcells" style="width: 88px">
                    <asp:Label ID="Label3" runat="server" Text="Stay Required :" Width="86px"></asp:Label></td>
                <td class="labelcells">
                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                        <ContentTemplate>
                            <span >
                            <asp:RadioButtonList ID="RLStay" runat="server" 
    AutoPostBack="True" Font-Bold="True"
                        Font-Names="Tahoma" Font-Size="8pt" 
    RepeatDirection="Horizontal" Width="140px"
                        ForeColor="#404040">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N">No</asp:ListItem>
                            </asp:RadioButtonList>
                            </span>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="labelcells" style="width: 88px">
    <span >
                                    <asp:Label ID="Label16" runat="server" Font-Bold="True" 
                        Font-Names="Tahoma" Font-Size="8pt"
                                        ForeColor="Black" Text="Serve Drinks :" Width="84px" 
                        Height="16px"></asp:Label>
       </span></td>
                <td class="labelcells">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <span >
                            <asp:RadioButtonList ID="RLDrink1" runat="server" Font-Bold="True" Font-Names="Tahoma"
                                        Font-Size="8pt" RepeatDirection="Horizontal" Width="140px" 
                                        ForeColor="#404040">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N">No</asp:ListItem>
                            </asp:RadioButtonList>
                            </span>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="labelcells" style="width: 88px">
    <span >
                                    <asp:Label ID="Label11" runat="server" Font-Bold="True" 
                        Font-Names="Tahoma" Font-Size="8pt"
                                        ForeColor="Black" Text="Kind Of Food :" Width="78px" 
                        Height="16px"></asp:Label>
       </span></td>
                <td class="labelcells">
    <span >
                                    <asp:RadioButtonList ID="RLFood" runat="server" 
                        Font-Bold="True" Font-Names="Tahoma"
                                        Font-Size="8pt" RepeatDirection="Horizontal" Width="133px" 
                                        ForeColor="#404040" Height="18px">
                                        <asp:ListItem Value="Veg">Veg</asp:ListItem>
                                        <asp:ListItem Value="Non-Veg">Non-Veg</asp:ListItem>
                                    </asp:RadioButtonList>
       </span></td>
            </tr>
            <tr>
                <td class="labelcells" colspan="2">
                            <table style="width:99%;" __designer:mapid="e97">
                                <tr __designer:mapid="ec2">
                                    <td style="width: 143px; height: 26px" __designer:mapid="ec3" 
                                        class="labelcells">
                            <span __designer:mapid="e52" >
                                        <asp:Label ID="Label7" runat="server" Font-Bold="True" 
                                                Font-Names="Tahoma" Font-Size="8pt"
                                        ForeColor="Black" Text="Duration From :" Width="89px" Height="16px"></asp:Label>
                            </span>
                                    </td><td style="width: 203px; height: 26px" __designer:mapid="ec5" 
                                        class="textcells">
                            <span __designer:mapid="e52" ><asp:UpdatePanel ID="UpdatePanel21" runat="server"><ContentTemplate><asp:TextBox AccessKey="d" ID="Datefrom" TabIndex="3" runat="server" Width="70px" 
                            CssClass="textbox" MaxLength="8" onMouseover="showhint('Please fill the date in MM/DD/YYYY 08/24/2009', this, event, '150px')"></asp:TextBox>
                        <cc1:maskededitvalidator ID="MaskedEditValidator1" runat="server" Width="114px" ControlToValidate="Datefrom"
                            Display="Dynamic" ControlExtender="MaskedEditExtender1" TooltipMessage="MM/DD/YYYY" IsValidEmpty="False" EmptyValueMessage="*" InvalidValueMessage="The Date is invalid" Height="16px"></cc1:MaskedEditValidator>
                                                <cc1:calendarextender ID="CalFrom" runat="server" TargetControlID="Datefrom" 
                            Animated="False" Format="MM/dd/yyyy" PopupPosition="TopRight">
                            </cc1:CalendarExtender>
                        <cc1:maskededitextender ID="MaskedEditExtender1" runat="server" TargetControlID="Datefrom"
                            MaskType="Date" Mask="99/99/9999">
                        </cc1:MaskedEditExtender>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                            </span>
                                    </td>
                                    <td style="width: 69px; height: 26px" __designer:mapid="eca" class="labelcells">
                            <span __designer:mapid="e52" >
                                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                                        ForeColor="Black" Text="Duration To :" Width="79px" Height="16px"></asp:Label>
                            </span>
                                    </td>
                                    <td style="height: 26px; width: 446px;" __designer:mapid="ecc" 
                                        class="textcells">
                            <span __designer:mapid="e52" >
                                            <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                             <ContentTemplate>
                        <asp:TextBox ID="Dateto" TabIndex="4" runat="server" Width="70px" CssClass="textbox" MaxLength="8" 
                                                     
                                                     
                                                     onMouseover="showhint('Please fill the date in MM/DD/YYYY 08/24/2009', this, event, '150px')"></asp:TextBox>
                                                 <cc1:maskededitvalidator
                                ID="MaskedEditValidator2" runat="server" ControlToValidate="Dateto" Display="Dynamic"
                                ControlExtender="MaskedEditExtender2" TooltipMessage="MM/DD/YYYY" IsValidEmpty="False"
                                EmptyValueMessage="*" InvalidValueMessage="The Date is invalid "></cc1:MaskedEditValidator>
                                                 <cc1:calendarextender
                                    ID="CalTo" runat="server" TargetControlID="Dateto" 
                            Animated="False" Format="MM/dd/yyyy" PopupPosition="TopRight">
                                </cc1:CalendarExtender>
                        <cc1:maskededitextender ID="MaskedEditExtender2" runat="server" TargetControlID="Dateto"
                            MaskType="Date" Mask="99/99/9999">
                        </cc1:MaskedEditExtender>
                        &nbsp;
                    </ContentTemplate>
                                            </asp:UpdatePanel>
                            </span>
                                    </td>
                                </tr>
                                </table>
                             </td>
            </tr>
            <tr>
                <td class="labelcells" colspan="2">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <span >
                            <asp:Panel ID="PnlNo" runat="server" Height="90px" Style="border-top-width: 1px;
                        border-left-width: 1px; border-left-color: black; border-bottom-width: 1px; border-bottom-color: black;
                        border-top-color: black; border-right-width: 1px; border-right-color: black;"
                        Width="100%">
                                <table id="Table2" style="border-color: #000000; border-width: 1px; font-size: 3pt;
                            width: 8%; "
                            onclick="return TABLE1_onclick()">
                                    <tr>
                                        <td class="labelcells">
                                            <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                                                Font-Size="8pt" ForeColor="Black" Text="Meals :" Width="162px" 
                                                Height="16px"></asp:Label>
                                        </td>
                                        <td class="labelcells" colspan="4">
                                            <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                                <ContentTemplate>
                                                    <span>
                                                    <asp:TextBox ID="txtmeal" runat="server" CssClass="textbox" Width="294px"></asp:TextBox>
                                                    <asp:CheckBoxList ID="CLMeal" runat="server" Font-Bold="True" 
                                                        Font-Names="Tahoma" Font-Size="8pt" ForeColor="#404040" 
                                                        RepeatDirection="Horizontal" Width="352px">
                                                        <asp:ListItem Value="BreakFast">BreakFast</asp:ListItem>
                                                        <asp:ListItem>Lunch</asp:ListItem>
                                                        <asp:ListItem>Tea/Snacks</asp:ListItem>
                                                        <asp:ListItem>Dinner</asp:ListItem>
                                                    </asp:CheckBoxList>
                                                    </span>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="labelcells">
                                            <asp:Label ID="Label17" runat="server" Font-Bold="True"  
                                        Text="Person Accompanied :" Width="125px"></asp:Label>
                                        </td>
                                        <td class="labelcells">
                                            <asp:Label ID="Label12" runat="server" Font-Bold="True" Width="69px" >Dept. Name</asp:Label>
                                        </td>
                                        <td colspan="1" class="textcells" style="width: 196px">
                                            <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                                <ContentTemplate>
                                                    <span>
                                                    <asp:DropDownList ID="DdlDept" runat="server" AutoPostBack="True" 
                                                        CssClass="combobox" Font-Names="Tahoma" Font-Size="8pt" Width="197px">
                                                    </asp:DropDownList>
                                                    </span>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td colspan="1" class="labelcells">
                                            &nbsp;<asp:Label ID="Label13" runat="server" Font-Bold="True" 
                                                Font-Names="Tahoma" Font-Size="8pt"
                                        ForeColor="Black" Text="Name :" Width="40px" Height="16px"></asp:Label>
                                        </td>
                                        <td colspan="1" class="labelcells">
                                            <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                                <ContentTemplate>
                                                    <span>
                                                    <asp:DropDownList ID="DdlName" runat="server" CssClass="combobox" 
                                                        Font-Names="Tahoma" Font-Size="8pt" Width="209px">
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="TctAccname" runat="server" CssClass="textbox"></asp:TextBox>
                                                    </span>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            </span>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="labelcells" valign="top">
                    &nbsp;&nbsp;<asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            <span >
                            <asp:Panel ID="PnlYes" runat="server" Height="29px" Style="border-top-width: 1px;
                        border-left-width: 1px; border-left-color: black; border-bottom-width: 1px; border-bottom-color: black;
                        border-top-color: black; border-right-width: 1px; border-right-color: black;"
                        Width="100%">
                                <table id="TABLE1"
                            onclick="return TABLE1_onclick()" width="100%">
                                    <tr>
                                        <td class="labelcells" style="width: 151px">
                                            <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                                                Font-Size="8pt" ForeColor="Black" Text="Accommodation :" Width="99px"></asp:Label>
                                        </td>
                                        <td class="textcells">
                                            <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                                <ContentTemplate>
                                                    <span>
                                                    <asp:DropDownList ID="DdlAccomm" runat="server" AutoPostBack="True" 
                                                        Font-Names="Tahoma" Font-Size="8pt" Width="111px">
                                                    </asp:DropDownList>
                                                    &nbsp;<asp:TextBox ID="TxtAccomm" runat="server" Font-Names="Tahoma" Font-Size="8pt" 
                                                        MaxLength="40" Width="150px"></asp:TextBox>
                                                    </span>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            </span>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:Panel ID="PnlAuth" runat="server" Height="30px" Style="border-top-width: 1px;
                        border-left-width: 1px; border-left-color: black; border-bottom-width: 1px; border-bottom-color: black;
                        border-top-color: black; border-right-width: 1px; border-right-color: black;"
                        Width="100%">
                        <table id="Table3" style="border-top-width: 1px; border-left-width: 1px; font-size: 3pt;
                            border-left-color: #000000; border-bottom-width: 1px; border-bottom-color: #000000;
                            width: 100%; border-top-color: #000000; border-right-width: 1px; border-right-color: #000000"
                            onclick="return TABLE1_onclick()">
                            <tr>
                                <td class="labelcells" style="width: 151px">
                                    <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                                        ForeColor="Black" Text="Authorization Remarks :" Width="140px"></asp:Label></td>
                                <td class="textcells">
                                                                  <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                                        <ContentTemplate>
                                            <span>
                                            <asp:TextBox ID="TxtauthRemarks" runat="server" Font-Names="Tahoma" 
                                                Font-Size="8pt" Width="327px"></asp:TextBox>
                                            </span>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                                                   </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="buttonbackbar" colspan="2" >
                    <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                        <ContentTemplate>
                            <span >
                            <asp:Button ID="Button1" runat="server" CssClass="ButtonBack" 
    Height="21px" Width="84px" BackColor="Black" Text="Close" 
    CausesValidation="False" />
                            <asp:Button ID="LnkSub" runat="server" BackColor="Black" CssClass="ButtonBack" 
                                Height="21px" Width="84px" />
                            <asp:Button ID="LnkClear" runat="server" BackColor="Black" 
                                CssClass="ButtonBack" Height="21px" Text="Clear" Width="84px" 
                                CausesValidation="False" />
                                 <asp:Button ID="LnkCancel" runat="server" BackColor="Black" 
                                CausesValidation="False" CssClass="ButtonBack" Height="21px" Text="Unaurhorize" 
                                Width="84px" />
                            </span>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            </table>
       </span><br />
</asp:Content>
