<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="Leave_Application.aspx.vb" Inherits="Default9" Title="Leave Applications" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td colspan="5" class="tableheader">
                <asp:Label ID="Label5" runat="server" BorderColor="Transparent" Text="Leave Application (OD/SL/PL/CL/Travel Leave/Comp Leave)"
                    Width="365px"></asp:Label>
                    <asp:ScriptManager ID="ScriptManager1" runat="server" >
                </asp:ScriptManager>
            </td>
        </tr>
         <tr>
            <td class="NormalText" id="FirstRow" colspan="4">
                <asp:Label ID="Label16" runat="server" ForeColor="Red" 
                    Text="For leave authorization, You are not mapped under your concerned head. So due to unmapping, your leave would not be authorized."></asp:Label>
                <br />
                <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton1_Click"  
                                    CommandName="Select" ForeColor="#3333CC"
                                    >Click Here To Send Mapping Notification To Your Head</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Nature of Leave
            </td>
            <td colspan="2" class="textcells">
                <asp:DropDownList ID="ddlleave" runat="server" Width="206px" CssClass="combobox"
                    AutoPostBack="True">
                    <asp:ListItem>Casual Leave</asp:ListItem>
                    <asp:ListItem>Short Leave</asp:ListItem>
                    <asp:ListItem>Priviledge Leave</asp:ListItem>
                    <asp:ListItem>Sick Leave</asp:ListItem>
                    <asp:ListItem>Compensatry Leave</asp:ListItem>
                    <asp:ListItem>Tour</asp:ListItem>
                    <asp:ListItem>Official Duty</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                Leave Type
            </td>
            <td class="textcells">
                <asp:DropDownList ID="dlleavetype" runat="server" Width="116px" CssClass="combobox">
                    <asp:ListItem>Full Day</asp:ListItem>
                    <asp:ListItem>Ist Half</asp:ListItem>
                    <asp:ListItem>2nd Half</asp:ListItem>
                    <asp:ListItem>Multiple Days</asp:ListItem>
                    <asp:ListItem>Hours</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Name of Employee
            </td>
            <td colspan="4" class="textcells">
                <asp:TextBox ID="txtname" runat="server" Width="390px" CssClass="textbox" ReadOnly="True"
                    BorderStyle="None"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Designation
            </td>
            <td colspan="2" class="textcells">
                <asp:TextBox ID="TextBox6" runat="server" Width="300px" CssClass="textbox" ReadOnly="True"
                    BorderStyle="None"></asp:TextBox>
            </td>
            <td class="labelcells">
                Shift
            </td>
            <td class="textcells">
                <asp:DropDownList ID="ddlshift" CssClass="combobox" runat="server" Width="90px">
                    <asp:ListItem>General Shift</asp:ListItem>
                    <asp:ListItem>A</asp:ListItem>
                    <asp:ListItem>B</asp:ListItem>
                    <asp:ListItem>C</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Department
            </td>
            <td colspan="2" class="textcells">
                <asp:TextBox ID="txtdept" runat="server" Width="276px" CssClass="textbox" ReadOnly="True"
                    BorderStyle="None"></asp:TextBox>
            </td>
            <td class="labelcells">
                Number of Days
            </td>
            <td class="textcells">
                <ew:NumericBox ID="Txtdays" runat="server" CssClass="textbox" Height="14px" Width="42px"
                    ToolTip="0.5 for half day"></ew:NumericBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Leave From
            </td>
            <td colspan="2" class="textcells">
                <ew:CalendarPopup ID="TxtLeaveFrom" runat="server" Culture="English (United Kingdom)"
                    Text="..." Width="63px" BackColor="WhiteSmoke" PopupLocation="Bottom" CssClass="textbox">
                    <ClearDateStyle BackColor="#E0E0E0" />
                    <DayHeaderStyle BackColor="OrangeRed" />
                    <MonthYearSelectedItemStyle BackColor="Silver" />
                    <TodayDayStyle BackColor="#FFC0C0" />
                    <MonthHeaderStyle BackColor="Gray" />
                    <GoToTodayStyle BackColor="#E0E0E0" />
                </ew:CalendarPopup>
            </td>
            <td style="width: 108px;">
                <strong><span style="font-size: 8pt; color: #696969; font-family: Tahoma">Leave To</span></strong>
            </td>
            <td style="width: 93px;">
                <ew:CalendarPopup ID="TxtLeaveTo" runat="server" Culture="English (United Kingdom)"
                    Text="..." Width="63px" PopupLocation="Bottom" CssClass="textbox">
                    <ClearDateStyle BackColor="#E0E0E0" />
                    <DayHeaderStyle BackColor="OrangeRed" />
                    <MonthYearSelectedItemStyle BackColor="Silver" />
                    <TodayDayStyle BackColor="#FFC0C0" />
                    <MonthHeaderStyle BackColor="Gray" />
                    <GoToTodayStyle BackColor="#E0E0E0" />
                </ew:CalendarPopup>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Time From
            </td>
            <td colspan="2" class="textcells">
                <ew:TimePicker ID="txttimefrom" runat="server" Enabled="False" Width="63px" Text="..."
                    MinuteInterval="FifteenMinutes" PopupLocation="Bottom" CssClass="textbox">
                </ew:TimePicker>
            </td>
            <td class="labelcells">
                Time To
            </td>
            <td class="textcells">
                <ew:TimePicker ID="TxtTimeTo" runat="server" Enabled="False" Width="63px" Text="..."
                    MinuteInterval="FifteenMinutes" PopupLocation="Bottom" CssClass="textbox">
                </ew:TimePicker>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="lblCompensatory" runat="server" Text="Compensatory Leave"></asp:Label>
            </td>
            <td colspan="4" class="textcells">
                <asp:TextBox ID="txtcompleave" runat="server" Width="530px" Enabled="False" 
                    CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Compensatory Against
            </td>
            <td id="Td1" colspan="4" class="textcells">
                <ew:CalendarPopup ID="TxtCoDtAgian" runat="server" Culture="English (United Kingdom)"
                    Text="..." Width="63px" BackColor="WhiteSmoke" Enabled="False" 
                    PopupLocation="Bottom" CssClass="textbox">
                    <ClearDateStyle BackColor="#E0E0E0" />
                    <DayHeaderStyle BackColor="OrangeRed" />
                    <MonthYearSelectedItemStyle BackColor="Silver" />
                    <TodayDayStyle BackColor="#FFC0C0" />
                    <MonthHeaderStyle BackColor="Gray" />
                    <GoToTodayStyle BackColor="#E0E0E0" />
                </ew:CalendarPopup>
                <asp:Label ID="lblmessage" runat="server" BackColor="#E0E0E0" BorderColor="Red" ForeColor="Red"
                    Text="     *    " Width="1px" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Purpose of Leave
            </td>
            <td colspan="4" class="textcells">
                <asp:TextBox ID="txtpurleave" runat="server" Width="530px" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Address while  on Leave
            </td>
            <td colspan="4" class="textcells">
                <asp:TextBox ID="txtaddleave" runat="server" Width="530px" CssClass="textbox" BorderStyle="NotSet"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Phone while on Leave
            </td>
            <td colspan="4" class="textcells">
                <asp:TextBox ID="txtphoneleave" runat="server" Width="530px" CssClass="textbox"
                    BorderStyle="NotSet"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="5">
                <asp:Button ID="cmdapply" runat="server" Text="Apply" CssClass="ButtonBack" BackColor="black"
                    OnClientClick='return confirm("Are you sure you want to Apply?")' />
                <asp:Button ID="cmdclear" runat="server" Text="Clear" CssClass="ButtonBack" BackColor="black" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton2" runat="server"  
                    PostBackUrl="Default2.aspx" ToolTip="Click here to check your leave status" >Check Leave Status</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton3" runat="server" Visible="false">Punch Records</asp:LinkButton>
            </td>
        </tr>
    <tr>
            <td colspan="4">
                <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" 
                    BackgroundCssClass="modalBackground" 
                    PopupControlID="Panel1" TargetControlID="cmdapply">
                </cc1:ModalPopupExtender>
                &nbsp;<asp:Panel ID="Panel1" runat="server" BackColor="White" Height="99px" 
                    style="text-align: center; display:none" Width="288px" BorderColor="Black" 
                    BorderStyle="Groove" >
                   
                        &nbsp;<span style="color: #FF3300">Due To Un-mapping, Your Leave Application is in Doubt.!!<br />
                        Please Check your leave status,
                        <br />
                        As You Need To Contact At 4226 For Further Processing of Your Leave</span><br />
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonc" 
                            Height="21px" Width="84px">OK</asp:LinkButton>
                        &nbsp;&nbsp;
                        
                </asp:Panel>
                <asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                    Font-Size="8pt" ForeColor="#990000"></asp:Label>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript" src="datetimepicker.js">

        //Date Time Picker script- by TengYong Ng of http://www.rainforestnet.com
        //Script featured on JavaScript Kit (http://www.javascriptkit.com)
        //For this script, visit http://www.javascriptkit.com 



    </script>

</asp:Content>
