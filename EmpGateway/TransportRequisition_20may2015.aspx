<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="TransportRequisition.aspx.vb" Inherits="TransportRequisition" title="Transport Requisitions" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>

<%@ Register Assembly="eWorld.UI.Compatibility, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI.Compatibility" TagPrefix="cc1" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="Uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td colspan="4" class="tableheader">
                <asp:Label ID="Label2" runat="server"  Text="Transport Requistion"></asp:Label>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 185px">
                <asp:Label ID="lblvehicle" runat="server" Text="Vehicle required by" Width="139px"></asp:Label></td>
            <td class="textcells" style="width: 128px">
                <asp:TextBox ID="Txtrequiredby" runat="server" Width="191px" CssClass="textbox" 
                     ></asp:TextBox></td>
            <td class="labelcells" style="width: 26px">
                <asp:Label ID="lblslno" runat="server" Text="Sl.No"></asp:Label>
                </td>
            <td class="textcells" >
                <asp:TextBox ID="Txtslno" runat="server" Width="78px" CssClass="textbox" 
                    Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 185px" >
                <asp:Label ID="lblplace" runat="server" Text="Place to be visited" ></asp:Label></td>
            <td class="textcells" style="width: 128px" >
                <asp:TextBox ID="Txtplace" runat="server" CssClass="textbox" Width="176px" ></asp:TextBox></td>
            <td class="labelcells" style="width: 26px">
                <asp:Label ID="lbldt" runat="server" Visible="false" Text="Date" Width="37px"></asp:Label>
                </td>
            <td class="textcells">
                <asp:TextBox ID="Txtdt" Visible="false" runat="server" CssClass="textbox" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 185px" >
                <asp:Label ID="lbldtreq" runat="server" Text="Date when required" Font-Bold="True" ></asp:Label></td>
            <td style="width: 128px" >
                <cc1:CalendarPopup ID="CadReq" runat="server" Width="75px" 
                    CssClass="textbox" >
                    <ButtonStyle CssClass="ButtonBack" Height="20px" Width="10px" />
                </cc1:CalendarPopup>
            </td>
            <td style="width: 26px" class="labelcells" >
                &nbsp;</td>
            <td class="textcells" >
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 185px" >
                <asp:Label ID="Label1" runat="server" Text="Time" ></asp:Label></td>
            <td style="width: 128px" >
                <ew:timepicker id="txtrequiredtime" runat="server" Width="63px" 
                    MinuteInterval="FifteenMinutes" PopupLocation="Bottom" CssClass="textbox">
                    <ButtonStyle CssClass="ButtonBack" Height="20px" Width="10px" />
                </ew:timepicker>
            </td>
            <td style="width: 26px" class="labelcells" >
                &nbsp;</td>
            <td class="textcells" >
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 185px" >
                <asp:Label ID="lblpurpose" runat="server" Text="Purpose of visit" ></asp:Label></td>
            <td class="textcells" style="width: 128px" >
                <asp:TextBox ID="Txtpurpose" runat="server" CssClass="textbox" Width="183px" ></asp:TextBox>
            </td>
            <td style="width: 26px" class="labelcells" >
                <asp:Label ID="Label16" runat="server" Text="No of Persons Accompanying " 
                    Width="170px"></asp:Label>
            </td>
            <td class="textcells" >
                <asp:TextBox ID="txtNo_of_Persons" runat="server" CssClass="textbox" 
                    MaxLength="3" Width="44px"></asp:TextBox>
                <cc2:FilteredTextBoxExtender ID="FltExt1" runat="server" 
                    TargetControlID="txtNo_of_Persons" FilterType="Numbers" ValidChars="0123456789">
                </cc2:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 185px" >
                <asp:Label ID="Label17" runat="server" Text="Vehicle Prefrences"></asp:Label>
            </td>
            <td class="textcells" style="width: 128px" >
                <asp:DropDownList ID="DdlVehicle" runat="server" CssClass="combobox" 
                    Width="131px">
                </asp:DropDownList>
            </td>
            <td class="labelcells" >
                &nbsp;</td>
            <td >
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 185px" >
                <asp:Label ID="lbldtreturn" runat="server" Text="Expected date of return" ></asp:Label></td>
            <td class="textcells" style="width: 128px" >
                <cc1:CalendarPopup ID="cadreturn" runat="server" Width="85px" 
                    CssClass="textbox" >
                    <ButtonStyle CssClass="ButtonBack" Height="20px" Width="10px" />
                </cc1:CalendarPopup>
            </td>
            <td ">
                &nbsp;</td>
            <td >
            </td>
        </tr>
        <tr>
            <td class="labelcells" >
                <asp:Label ID="lbltimereturn" runat="server" 
                Text="Expected time of return" Font-Names="Tahoma" Font-Size="8pt" ></asp:Label></td>
            <td>
                <ew:timepicker id="txtreturntime" runat="server" font-names="Tahoma" font-size="Smaller"
                    width="85px" CssClass="textbox">
                    <ButtonStyle CssClass="ButtonBack" Height="20px" Width="10px" />
                </ew:timepicker>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 185px" >
                <asp:Label ID="lblreport" runat="server" Text="Where the vehicle should report" ></asp:Label></td>
            <td class="textcells" style="width: 128px" >
                <asp:TextBox ID="txtreport" runat="server" CssClass="textbox" Width="183px" ></asp:TextBox></td>
            <td style="width: 26px" >
                &nbsp;</td>
            <td >
            </td>
        </tr>
        <tr>
            <td class="labelcells" colspan="4" >
                <asp:Panel ID="Panel1" runat="server">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                <asp:Label ID="lblchargeable" runat="server" Text="Chargeable"></asp:Label>
                            </td>
                            <td class="textcells">
                                <asp:RadioButtonList ID="rblcharge" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Smaller" Height="16px" RepeatDirection="Horizontal" Width="145px">
                                    <asp:ListItem Selected="True">Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:Label ID="lblVehicleAlloted" runat="server" Text="Vehicle Alloted"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DdlVehicleAllocated" runat="server" AutoPostBack="True" 
                                    CssClass="combobox" Width="131px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="labelcells">
                                <asp:Label ID="lblCarNo" runat="server" Text="Car No."></asp:Label>
                            </td>
                            <td class="textcells">
                                <asp:TextBox ID="txtCarAllocated" runat="server" CssClass="textbox" 
                                    Enabled="False"></asp:TextBox>
                            </td>
                            <td class="labelcells">
                                <asp:Label ID="lblRemarks" runat="server" Text="Remarks"></asp:Label>
                            </td>
                            <td class="textcells">
                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" Width="226px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqdValid2" runat="server" 
                                    ControlToValidate="txtRemarks" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 185px" >
                <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                            FadeInDuration="2" FadeInSteps="2" FadeOutDuration="10" FadeOutSteps="2" Visible="true">
                        </uc1:FlashMessage>
             </td>
            <td class="textcells" style="width: 128px" >
                &nbsp;</td>
            <td style="width: 26px" >
                &nbsp;</td>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 185px" >
            </td>
            <td colspan="2" >
               <asp:Button ID="BtnBack" runat="server" Text="Back" CssClass="ButtonBack" 
                    Height="21px" Width="84px" BackColor="Black" Visible="False" />
                <asp:Button ID="btnsub" runat="server" Text="Submit" CssClass="ButtonBack" 
                    Height="21px" Width="84px" BackColor="Black" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="ButtonBack" 
                    Height="21px" Width="84px" BackColor="Black" /></td>
            <td >
            </td>
        </tr>
    </table>
</asp:Content>

