<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="Complaints.aspx.vb" Inherits="Default4" Title="E-HelpDesk, Communication & Task Assignment Tool"
    MaintainScrollPositionOnPostback="true" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="datetimepicker.js">
    </script>
    <table width="100%">
        <tr>
            <td class="tableheader" colspan="6">
                <asp:Label ID="Label5" runat="server" Text="Complaints"
                   ></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="6" style="text-align: left; font-weight: bold;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem>Customer Complaint</asp:ListItem>
                    <asp:ListItem>Supplier Complaint</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td colspan="6" class="buttonbackbar" style="text-align: left">
                <asp:Label ID="Label1" runat="server" Text="Task Detail" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells" >
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="labelcells" >
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="labelcells" >
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells" >
                <asp:Label ID="Label71" runat="server" Text="Complaint Type*" ></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DrpTaskType" runat="server" cssclass="combobox" Width="112px">
                </asp:DropDownList>
            </td>
            <td class="labelcells" >
                <asp:Label ID="Label72" runat="server" Text="Area*"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DrpArea" runat="server" AutoPostBack="True" CssClass="combobox" Width="104px">
                </asp:DropDownList>
            </td>
            <td class="labelcells" >
                <asp:Label ID="Label73" runat="server" Text="SubArea*" ></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DrpSubArea" runat="server" Width="216px" AutoPostBack="True"
                    CssClass="combobox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells" >
                <asp:Label ID="Label75" runat="server" Text="Complaint Ref(If Any)"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="txtTaskRef" runat="server" Width="64px" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="labelcells" >
                <asp:Label ID="Label76" runat="server" Text="Ref Date"></asp:Label>
            </td>
            <td colspan="2" class="textcells">
                 <ew:CalendarPopup ID="txtRefDate" runat="server" Culture="English (United Kingdom)"
                    Text="..." Width="66px" CssClass="textbox">
                    <ClearDateStyle BackColor="#E0E0E0" />
                    <DayHeaderStyle BackColor="OrangeRed" />
                    <MonthYearSelectedItemStyle BackColor="Silver" />
                    <TodayDayStyle BackColor="#FFC0C0" />
                    <MonthHeaderStyle BackColor="Gray" />
                    <GoToTodayStyle BackColor="#E0E0E0" />
                </ew:CalendarPopup>
            </td>
            <td class="textcells">
                <asp:TextBox ID="txtTaskNo" runat="server" CssClass="textbox" Width="144px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells" >
                <asp:Label ID="Label78" runat="server" Text="Subject(Brief Description)*"></asp:Label>
            </td>
            <td colspan="5" class="textcells">
                <asp:TextBox ID="txtSub" runat="server" Width="527px" Font-Bold="True" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells"  >
                <asp:Label ID="Label79" runat="server" Text="Detail Description*" ></asp:Label>
            </td>
            <td colspan="5" class="textcells">
                <asp:TextBox ID="txtJobDescr" runat="server" TextMode="MultiLine" Width="527px" CssClass="textbox"
                    Height="40px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells" >
                <asp:Label ID="Label74" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Priority*"></asp:Label>
            </td>
            <td class="textcells">
                <asp:DropDownList ID="DrpPriority" runat="server" Width="64px" CssClass="combobox">
                    <asp:ListItem>High</asp:ListItem>
                    <asp:ListItem>Normal</asp:ListItem>
                    <asp:ListItem>Low</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells" >
                <asp:Label ID="Label77" runat="server" Text="Due Date"></asp:Label>
            </td>
            <td colspan="2" class="textcells">
                <ew:CalendarPopup ID="txtduedate" runat="server" Culture="English (United Kingdom)"
                    Text="..." Width="66px" CssClass="textbox">
                    <ClearDateStyle BackColor="#E0E0E0" />
                    <DayHeaderStyle BackColor="OrangeRed" />
                    <MonthYearSelectedItemStyle BackColor="Silver" />
                    <TodayDayStyle BackColor="#FFC0C0" />
                    <MonthHeaderStyle BackColor="Gray" />
                    <GoToTodayStyle BackColor="#E0E0E0" />
                </ew:CalendarPopup>
            </td>
            <td class="textcells" style="width:100px">
                <asp:DropDownList ID="DrpSelection" runat="server" Width="88px" 
                    CssClass="combobox" Visible="False">
                    <asp:ListItem>Assign Task</asp:ListItem>
                    <asp:ListItem>Reply</asp:ListItem>
                    <asp:ListItem>Close</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells" >
                <asp:Label ID="Label80" runat="server" Text="File Attachment(If Any)" 
                    Width="151px"></asp:Label>
            </td>
            <td colspan="3" >
                <asp:FileUpload ID="FlAttcAssn" runat="server" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="DimGray" Height="24px" Width="206px" 
                    CssClass="textbox" /><asp:Label
                        ID="Label3" runat="server" Font-Bold="True" Font-Italic="False" Font-Names="Tahoma"
                        Font-Size="7pt" ForeColor="Red" Text="*FileSize Limit: 5MB" witdh="300px"></asp:Label>
            </td>
            <td colspan="2" class="textcells">
                <asp:Button ID="cmdAttachAssn" runat="server" Text="Attach File" CssClass="ButtonBack" BackColor="Black" />
                &nbsp;
                <asp:HyperLink ID="LnkAssign" runat="server" NavigateUrl="DownloadFile.aspx" Font-Bold="True"
                    Font-Names="Tahoma" Font-Size="8pt">LnkAssign</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td colspan="6" class="buttonbackbar" style="text-align: left">
                <asp:Label ID="Label2" runat="server" Text="History" Width="85px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="6" >
                <ew:CollapsablePanel ID="PnlHistory" runat="server" CssClass="panelcells" CollapseImageUrl="Image/UPARROW.JPG"
                    CollapserAlign="Left" CollapseText="Click To Close" ExpandImageUrl="Image/DNARROW.JPG"
                    Height="150px" ScrollBars="Vertical">
                    <asp:TextBox ID="txtHistory" runat="server" Height="112px" CssClass="textbox"
                        Rows="5" TextMode="MultiLine" Width="650px"></asp:TextBox></ew:CollapsablePanel>
            </td>
        </tr>
        <tr>
            <td colspan="6" class="buttonbackbar"  > 
                <asp:Button ID="cmdSubmit" runat="server" CssClass="ButtonBack" Text="Submit" BackColor="Black"/>
            </td>
        </tr>
    </table>
</asp:Content>
