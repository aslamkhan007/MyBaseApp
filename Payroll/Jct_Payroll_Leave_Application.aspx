<%@ Page Title="" Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="Jct_Payroll_Leave_Application.aspx.vb" Inherits="Payroll_Jct_Payroll_Leave_Application" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

     <div class="tileTable"  style="height: 100%;" >
    <%--<table style="padding: 2px; margin: 2px; width: 100%; border-collapse: separate;border-spacing: 0 1em;padding-top: 1em;padding-bottom: 1em; " >--%>
         <table class="tblMain" >
        <tr>
            <td colspan="4" class="content-sub-heading">
                <asp:Label ID="Label5" runat="server" BorderColor="Transparent" Text="Leave Application (CL/PL/SL/CO/OD/ShortLeave)"></asp:Label>
               
            </td>
        </tr>
         <tr>
            <td  id="FirstRow" colspan="3">
                <asp:Label ID="Label16" runat="server" ForeColor="Red" 
                    Text="For leave authorization, You are not mapped under your concerned head. So due to unmapping, your leave would not be authorized."></asp:Label>
                <br />
                <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton1_Click"  
                                    CommandName="Select" ForeColor="#3333CC">Click Here To Send Mapping Notification To Your Head</asp:LinkButton>
            </td>             
        </tr>
        <tr>
            <td class="CellWidth20">Leave Type
            </td>
            <td class="CellWidth30">
                <asp:DropDownList ID="ddlleave" runat="server" class="btn btn-default btn-sm"
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
            <td class="CellWidth20">
                Leave Type
            </td>
            <td  class="CellWidth30">
                <asp:DropDownList ID="dlleavetype" runat="server" class="btn btn-default btn-sm">
                    <asp:ListItem>Full Day</asp:ListItem>
                    <asp:ListItem>Ist Half</asp:ListItem>
                    <asp:ListItem>2nd Half</asp:ListItem>
                    <asp:ListItem>Multiple Days</asp:ListItem>
                    <asp:ListItem>Hours</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td >Employee Name
            </td>
            <td colspan="3" >
                <asp:TextBox ID="txtname" runat="server" Width="390px"  ReadOnly="True"
                    BorderStyle="None"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td >
                Designation
            </td>
            <td >
                <asp:TextBox ID="TextBox6" runat="server"   ReadOnly="True"
                    BorderStyle="None"></asp:TextBox>
            </td>
            <td >
                Shift
            </td>
            <td >
                <asp:DropDownList ID="ddlshift" class="btn btn-default btn-sm" runat="server">
                    <asp:ListItem>General Shift</asp:ListItem>
                    <asp:ListItem>A</asp:ListItem>
                    <asp:ListItem>B</asp:ListItem>
                    <asp:ListItem>C</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td >
                Department
            </td>
            <td >
                <asp:TextBox ID="txtdept" runat="server"   ReadOnly="True"
                    BorderStyle="None"></asp:TextBox>
            </td>
            <td >
                &nbsp;Days
            </td>
            <td >
                <ew:NumericBox ID="Txtdays" runat="server" Width="50px"
                    ToolTip="0.5 for half day"></ew:NumericBox>
            </td>
        </tr>
        <tr>
            <td  class="CellWidth20">
                Leave From
            </td>
            <td  class="CellWidth30">
                <ew:CalendarPopup ID="TxtLeaveFrom" runat="server" Culture="English (United Kingdom)"
                    Text="..." Width="83px" BackColor="WhiteSmoke" PopupLocation="Bottom" >
                    <ClearDateStyle BackColor="#E0E0E0" />
                    <DayHeaderStyle BackColor="OrangeRed" />
                    <MonthYearSelectedItemStyle BackColor="Silver" />
                    <TodayDayStyle BackColor="#FFC0C0" />
                    <MonthHeaderStyle BackColor="Gray" />
                    <GoToTodayStyle BackColor="#E0E0E0" />
                </ew:CalendarPopup>
            </td>
            <td  class="CellWidth20">
                Leave To
            </td>
            <td  class="CellWidth30">
                <ew:CalendarPopup ID="TxtLeaveTo" runat="server" Culture="English (United Kingdom)"
                    Text="..." Width="83px" PopupLocation="Bottom" >
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
            <td  class="CellWidth20" >
                Time From
            </td>
            <td  class="CellWidth30" >
                <ew:TimePicker ID="txttimefrom" runat="server" Enabled="False" Width="63px" Text="..."
                    MinuteInterval="FifteenMinutes" PopupLocation="Bottom" >
                </ew:TimePicker>
            </td>
            <td  class="CellWidth20">
                Time To
            </td>
            <td  class="CellWidth30">
                <ew:TimePicker ID="TxtTimeTo" runat="server" Enabled="False" Width="63px" Text="..."
                    MinuteInterval="FifteenMinutes" PopupLocation="Bottom" >
                </ew:TimePicker>
            </td>
        </tr>
        <tr>
            <td  class="CellWidth20">
                <asp:Label ID="lblCompensatory" runat="server" Text="Compensatory Leave"></asp:Label>
            </td>
            <td colspan="3"  class="CellWidth80">
                <asp:TextBox ID="txtcompleave" runat="server" Width="80%" Enabled="False" 
                    ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  class="CellWidth20">
                Compensatory Against
            </td>
            <td id="Td1" colspan="3"  class="CellWidth80">
                <ew:CalendarPopup ID="TxtCoDtAgian" runat="server" Culture="English (United Kingdom)"
                    Text="..." Width="83px" BackColor="WhiteSmoke" Enabled="False" 
                    PopupLocation="Bottom" >
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
            <td  class="CellWidth20">
                Remarks
            </td>
            <td colspan="3"  class="CellWidth80" >
                <asp:TextBox ID="txtpurleave" runat="server" Width="80%" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  style="text-align: center"  colspan="4">
                <asp:Button ID="cmdapply" runat="server" Text="Apply" class="btn btn-brand" 
                    OnClientClick='return confirm("Are you sure you want to Apply?")' />
                <asp:Button ID="cmdclear" runat="server" Text="Clear" class="btn btn-brand"  />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton2" runat="server"  
                    PostBackUrl="Default2.aspx" ToolTip="Click here to check your leave status" Visible="False">Check Leave Status</asp:LinkButton>

            &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton3" runat="server" Visible="false">Punch Records</asp:LinkButton>
                <asp:LinkButton ID="lnkcomp" runat="server" PostBackUrl="~/CoLeave.aspx">Apply Earned Compensatory</asp:LinkButton>
            </td>
        </tr>
    <tr>
            <td colspan="3">
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
</div>
    <script language="javascript" type="text/javascript" src="datetimepicker.js">

        //Date Time Picker script- by TengYong Ng of http://www.rainforestnet.com
        //Script featured on JavaScript Kit (http://www.javascriptkit.com)
        //For this script, visit http://www.javascriptkit.com 



    </script>

</asp:Content>


