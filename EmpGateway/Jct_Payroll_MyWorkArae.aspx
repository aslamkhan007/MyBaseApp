<%@ Page Title="" Language="VB" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="false" CodeFile="Jct_Payroll_MyWorkArae.aspx.vb" Inherits="Payroll_Jct_Payroll_MyWorkArae" %>


    <%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="JavaScript" type="text/javascript" >

        function clickButton(e, buttonid) {
            var evt = e ? e : window.event;
            var bt = document.getElementById(buttonid);
            if (bt) {
                if (evt.keyCode == 13) {
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
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
<div class="FadingTooltip" id="FADINGTOOLTIP" style="Z-INDEX: 999; VISIBILITY: hidden; POSITION: absolute"></div>
<style type="text/css">
            .FadingTooltip { BORDER-RIGHT: darkgray 1px outset; BORDER-TOP: darkgray 1px outset; FONT-SIZE: 12pt; BORDER-LEFT: darkgray 1px outset; WIDTH: auto; COLOR: black; BORDER-BOTTOM: darkgray 1px outset; HEIGHT: auto; BACKGROUND-COLOR: lemonchiffon; MARGIN: 3px 3px 3px 3px; padding: 3px 3px 3px 3px; borderBottomWidth: 3px 3px 3px 3px }
</style>


  <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
        <style type="text/css">
            .orderText
            {
                font: normal 12px Arial,Verdana;
                margin-top: 6px;
            }
        </style>
    </telerik:RadCodeBlock>

    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function ShowEditForm(id) {
                var grid = $find("<%= GridView1.ClientID %>");

                window.radopen("PunchRecordDetail.aspx?LeaveID=" + id, "UserListDialog");
                return false;
            }
            function ShowInsertForm() {
                window.radopen("PunchRecordDetail.aspx", "UserListDialog");
                return false;
            }
            function refreshGrid(arg) {
                if (!arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
                }
            }
            function RowDblClick(sender, eventArgs) {
                window.radopen("PunchRecordDetail.aspx?RequestID=" + eventArgs.getDataKeyValue("LeaveID"), "UserListDialog");
            }
        </script>
    </telerik:RadCodeBlock>


     <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" >
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel runat="server" ID="gridLoadingPanel"></telerik:RadAjaxLoadingPanel>



    <table style="width: 100%">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label5" runat="server" Text="My Consent Area (INBOX)" Width="328px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" style="text-align: left">
                <asp:Label ID="Label1" runat="server" Text="Leave Applications(To)" 
                    Width="165px" Height="16px"></asp:Label><asp:Button ID="cmdauthorize" runat="server" Text="Authorize" 
                    CssClass="ButtonBack" BackColor="Black" /><asp:Button ID="cmdcancle" runat="server" Text="UnAuthorize" 
                    CssClass="ButtonBack" BackColor="Black" />
                <asp:Button ID="CmdCheck" runat="server" Text="Check All" CssClass="ButtonBack" 
                    BackColor="Black" />
               <asp:Button ID="UnCheck" runat="server" 
                    Text="Un Check All" CssClass="ButtonBack" BackColor="Black"/>
            </td>
            <td class="buttonbackbar" style="text-align: left">
                <asp:Label ID="Label2" runat="server" Text="Status:"></asp:Label>
            </td>
            <td class="buttonbackbar" style="text-align: left">
                <asp:DropDownList ID="DrpLvStatus" runat="server" AutoPostBack="True" Width="88px"
                    CssClass="combobox">
                    <asp:ListItem>Pending</asp:ListItem>
                    <asp:ListItem>Authorized</asp:ListItem>
                    <asp:ListItem>Cancelled</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 31px" valign="top">
                <ew:CollapsablePanel ID="PnlLv" runat="server" CssClass="panelcells" CollapseImageUrl="Image/UPARROW.JPG"
                    CollapserAlign="Left" ExpandImageUrl="Image/DNARROW.JPG" ScrollBars="Auto" Width="100%"
                    AllowSliding="True" SlideSpeed="10">
                    <asp:GridView ID="GridView1" runat="server"  AllowPaging="True"  
                       width="100%" GridLines="None"  CssClass="GridViewStyle" 
                        EnableModelValidation="True" AutoGenerateColumns="False">
                         <Columns>
                             <asp:TemplateField>
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:CheckBox ID="CheckBox1" runat="server" Font-Names="Tahoma" Font-Size="8pt" 
                                         oncheckedchanged="CheckBox1_CheckedChanged" />
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="PunchRecord">
                                 <ItemTemplate>
                                     <asp:LinkButton ID="lnkPunch" runat="server" onclick="lnkPunch_Click" CommandName="popup">View</asp:LinkButton>
                                       <asp:LinkButton ID="lnkDetail" runat="server" onclick="lnkDetail_Click"  CommandName="detail">Detail</asp:LinkButton>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             
                             <asp:BoundField DataField="ID" HeaderText="ID" />
                             <asp:BoundField DataField="Nature" HeaderText="Nature" />
                             <asp:BoundField DataField="Name" HeaderText="Name" />
                             <asp:BoundField DataField="Department" HeaderText="Department" />
                             <asp:BoundField DataField="Days" HeaderText="Days" />
                             <asp:BoundField DataField="From" HeaderText="From" />
                             <asp:BoundField DataField="To" HeaderText="To" />
                             <asp:BoundField DataField="Applied On" HeaderText="Applied On" />
                             
                        </Columns>
                          <RowStyle CssClass="RowStyle" />
                          <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                          <PagerStyle CssClass="PagerStyle" />
                          <SelectedRowStyle CssClass="SelectedRowStyle" />
                          <HeaderStyle CssClass="HeaderStyle" />
                          <EditRowStyle CssClass="EditRowStyle" />
                          <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView>
                </ew:CollapsablePanel>
            </td>
        </tr>
 <%--       <tr>
            <td colspan="3" class="buttonbackbar" style="text-align: left">
                <asp:Label ID="Label4" runat="server" Text="Leave Applications(BCC)" Width="176px"></asp:Label>
            </td>
        </tr>--%>
<%--        <tr>
            <td colspan="3" style="height: 31px" valign="top">
                <ew:CollapsablePanel ID="CPforCc" runat="server" CollapseImageUrl="Image/UPARROW.JPG"
                    CollapserAlign="Left" ExpandImageUrl="Image/DNARROW.JPG" ScrollBars="Auto" SlideSpeed="10"
                    CssClass="panelcells">
                    <asp:GridView ID="GridView2" runat="server"  AllowPaging="True"  
                       width="100%" GridLines="None"  CssClass="GridViewStyle">
                          <RowStyle CssClass="RowStyle" />
                          <EmptyDataRowStyle CssClass="EmptyRowStyle" />

    <PagerStyle CssClass="PagerStyle" />

    <SelectedRowStyle CssClass="SelectedRowStyle" />

    <HeaderStyle CssClass="HeaderStyle" />

    <EditRowStyle CssClass="EditRowStyle" />

    <AlternatingRowStyle CssClass="AltRowStyle" />
                    
                    </asp:GridView>
                </ew:CollapsablePanel>
            </td>
        </tr>--%>
<%--        <tr>
            <td colspan="3" class="buttonbackbar" style="text-align: left">
                <asp:Label ID="Label3" runat="server" Text="Area I Need To Be Informed About" Width="447px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 31px">
                <ew:CollapsablePanel ID="PnlTasks" runat="server" CollapseImageUrl="Image/UPARROW.JPG"
                    CssClass="panelcells" CollapserAlign="Left" ExpandImageUrl="Image/DNARROW.JPG"
                    ScrollBars="Both" Width="100%" SlideSpeed="10">
                    <asp:GridView ID="GridMyTasks" runat="server"   
                       width="100%" GridLines="None"  CssClass="GridViewStyle">
                          <RowStyle CssClass="RowStyle" />
                          <EmptyDataRowStyle CssClass="EmptyRowStyle" />

    <PagerStyle CssClass="PagerStyle" />

    <SelectedRowStyle CssClass="SelectedRowStyle" />

    <HeaderStyle CssClass="HeaderStyle" />

    <EditRowStyle CssClass="EditRowStyle" />

    <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView>
                </ew:CollapsablePanel>
            </td>
        </tr>--%>
<%--        <tr>
            <td class="buttonbackbar" colspan="3" style="text-align: left">
                <asp:Label ID="Label6" runat="server" Text="Comments For Me" Width="447px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 31px">
                <ew:CollapsablePanel ID="CollapsablePanel1" runat="server" CollapseImageUrl="Image/UPARROW.JPG"
                    CollapserAlign="Left" ExpandImageUrl="Image/DNARROW.JPG" ScrollBars="Auto" CssClass="panelcells"
                    Width="100%" SlideSpeed="10">
                    <asp:GridView ID="GrdComments" runat="server"  Width="100%" PageSize="5" GridLines="None"    CssClass="GridViewStyle">
            <RowStyle CssClass="RowStyle" />           
    <EmptyDataRowStyle CssClass="EmptyRowStyle" />

    <PagerStyle CssClass="PagerStyle" />

    <SelectedRowStyle CssClass="SelectedRowStyle" />

    <HeaderStyle CssClass="HeaderStyle" />

    <EditRowStyle CssClass="EditRowStyle" />

    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>
                </ew:CollapsablePanel>
            </td>
        </tr>--%>
<%--        <tr>
            <td class="buttonbackbar" colspan="3" style="text-align: left">
                <asp:Label ID="LblSurveyCaption" runat="server" Text="Survey To Be Authorized" Width="184px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <ew:CollapsablePanel ID="Pannel1" CssClass="panelcells" runat="server" CollapseImageUrl="Image/UPARROW.JPG"
                    CollapserAlign="Left" ExpandImageUrl="Image/DNARROW.JPG" Height="150px" ScrollBars="Vertical"
                    Width="100%" Collapsed="True">
                    <asp:GridView ID="GrdSurAuthrised" runat="server"  Width="100%" PageSize="5" GridLines="None"    CssClass="GridViewStyle">
            <RowStyle CssClass="RowStyle" />           
    <EmptyDataRowStyle CssClass="EmptyRowStyle" />

    <PagerStyle CssClass="PagerStyle" />

    <SelectedRowStyle CssClass="SelectedRowStyle" />

    <HeaderStyle CssClass="HeaderStyle" />

    <EditRowStyle CssClass="EditRowStyle" />

    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>
                </ew:CollapsablePanel>
            </td>
        </tr>--%>
<%--        <tr>
            <td class="buttonbackbar" style="text-align: left">
                <asp:Label ID="Label7" runat="server" Text="News To Be Authorized" Width="184px"></asp:Label>
            </td>
            <td class="buttonbackbar" style="text-align: left">
                <asp:Label ID="Label8" runat="server" Text="Status:"></asp:Label>
            </td>
            <td class="buttonbackbar" style="text-align: left">
                <asp:DropDownList ID="ddlnews" runat="server" AutoPostBack="True" Width="88px" CssClass="combobox">
                    <asp:ListItem Value="P">Pending</asp:ListItem>
                    <asp:ListItem Value="A">Authorized</asp:ListItem>
                    <asp:ListItem Value="C">Cancelled</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <ew:CollapsablePanel ID="CPNews" runat="server" CollapseImageUrl="Image/UPARROW.JPG"
                    CollapserAlign="Left" ExpandImageUrl="Image/DNARROW.JPG" Height="150px" ScrollBars="Vertical"
                    Width="100%" Collapsed="True" CssClass="panelcells">
                    <asp:GridView ID="GridNews" runat="server"  Width="100%" PageSize="5" GridLines="None"    CssClass="GridViewStyle">
           
                        <Columns>
                            <asp:TemplateField HeaderText="News No.">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnknews" runat="server" CssClass="labelcells" ForeColor="Red"
                                        Text='<%# Eval("trans") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Headline">
                                <ItemTemplate>
                                    <asp:Label ID="lblhead" runat="server" CssClass="labelcells" Text='<%# Eval("head") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="UserCode">
                                <ItemTemplate>
                                    <asp:Label ID="lbluser" runat="server" CssClass="labelcells" Text='<%# eval("empname") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Submission Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblsubdate" runat="server" CssClass="labelcells" Text='<%# Eval("date") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Dept Name">
                                <ItemTemplate>
                                    <asp:Label ID="lbldept" runat="server" CssClass="labelcells" Text='<%# Eval("dept") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                      
                        <EmptyDataTemplate>
                            <asp:Label ID="lbldept" runat="server" CssClass="labelcells" Text="No News" Width="129px"></asp:Label>
                        </EmptyDataTemplate>
                       <RowStyle CssClass="RowStyle" />           
    <EmptyDataRowStyle CssClass="EmptyRowStyle" />

    <PagerStyle CssClass="PagerStyle" />

    <SelectedRowStyle CssClass="SelectedRowStyle" />

    <HeaderStyle CssClass="HeaderStyle" />

    <EditRowStyle CssClass="EditRowStyle" />

    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>
                   
                </ew:CollapsablePanel>
            </td>
        </tr>--%>
<%--        <tr>
            <td class="buttonbackbar" style="text-align: left">
                <asp:Label ID="Label9" runat="server" Text="Document(s) To Be Authorized" Width="254px"></asp:Label>
            </td>
            <td class="buttonbackbar" style="text-align: left">
                <asp:Label ID="Label10" runat="server" Text="Status:"></asp:Label>
            </td>
            <td class="buttonbackbar" style="text-align: left">
                <asp:DropDownList ID="ddldoc" runat="server" AutoPostBack="True" Width="88px" CssClass="combobox">
                    <asp:ListItem Value="P">Pending</asp:ListItem>
                    <asp:ListItem Value="A">Authorized</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <ew:CollapsablePanel ID="CPDoc" runat="server" CollapseImageUrl="Image/UPARROW.JPG"
                    CollapserAlign="Left" ExpandImageUrl="Image/DNARROW.JPG" Height="150px" ScrollBars="Vertical"
                    Width="100%" Collapsed="True" CssClass="panelcells">
                    <asp:GridView ID="GrdDoc" runat="server"  Width="100%" PageSize="5" GridLines="None"    CssClass="GridViewStyle">
         
                        <Columns>
                            <asp:TemplateField HeaderText="Document Type">
                                <ItemTemplate>
                                    <asp:Label ID="lbltype" runat="server" CssClass="labelcells" Text='<%# Eval("type") %>'></asp:Label>&nbsp;
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Department">
                                <ItemTemplate>
                                    <asp:Label ID="lbldept" runat="server" CssClass="labelcells" Text='<%# Eval("dept") %>'></asp:Label>&nbsp;
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="UserCode">
                                <ItemTemplate>
                                    <asp:Label ID="lbluser" runat="server" CssClass="labelcells" Text='<%# Eval("usertype") %>'></asp:Label>&nbsp;
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="File">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkfile" runat="server" CommandName="select" Font-Names="Verdana"
                                        Font-Size="8pt" ForeColor="Red" Text='<%# Eval("file") & Eval("ext") %>'></asp:LinkButton>&nbsp;
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Authorize">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkauth" runat="server" CommandName="update" Font-Names="Verdana"
                                        Font-Size="8pt" Text="Authorize"></asp:LinkButton>&nbsp;
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        
                        <EmptyDataTemplate>
                            <asp:Label ID="lbldept" runat="server" CssClass="labelcells" Text="No Document" Width="129px"></asp:Label>
                        </EmptyDataTemplate>
                           <RowStyle CssClass="RowStyle" />           
    <EmptyDataRowStyle CssClass="EmptyRowStyle" />

    <PagerStyle CssClass="PagerStyle" />

    <SelectedRowStyle CssClass="SelectedRowStyle" />

    <HeaderStyle CssClass="HeaderStyle" />

    <EditRowStyle CssClass="EditRowStyle" />

    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>
                </ew:CollapsablePanel>
            </td>
        </tr>--%>
<%--         <tr>
            <td align="left" class="buttonbackbar" style="text-align: left">
                <asp:Label ID="Label11" runat="server" Text="Guest House Authorization" 
                    Width="254px"></asp:Label>
            </td>
            <td class="buttonbackbar">
                <asp:Label ID="Label12" runat="server" Text="Status:"></asp:Label>
            </td>
            <td style="width: 115px" class="buttonbackbar">
                <asp:DropDownList ID="ddlGuest" runat="server" AutoPostBack="True" Width="88px" 
                    CssClass="combobox">
                    <asp:ListItem Value="P">Pending</asp:ListItem>
                    <asp:ListItem Value="A">Authorized</asp:ListItem>
                     <asp:ListItem Value="C">Cancelled</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left"  colspan="3" style="text-align: left">
                <ew:CollapsablePanel ID="CPNews0" runat="server" CollapseImageUrl="Image/UPARROW.JPG"
                    CollapserAlign="Left" ExpandImageUrl="Image/DNARROW.JPG" Height="150px" ScrollBars="Vertical"
                    Width="100%" Collapsed="True" CssClass="panelcells">
                    <asp:GridView ID="GridGuest" runat="server"   
                       width="100%" GridLines="None"  CssClass="GridViewStyle">
                        <RowStyle CssClass="RowStyle" />
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <PagerStyle CssClass="PagerStyle" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <EditRowStyle CssClass="EditRowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView>
                   
                </ew:CollapsablePanel>
            </td>
        </tr>


--%>









<%--
<tr>
            <td class="buttonbackbar" colspan="3" style="text-align: left">
                <table style="width:100%;">
                    <tr>
                        <td>
                <asp:Label ID="lblTransportReq" runat="server" Text="Transport Requisition(s) To Be Authorized" ></asp:Label>
                        </td>
                        <td>
                <asp:Label ID="lblStatus" runat="server" Text="Status:"></asp:Label>
                        </td>
                        <td>
                <asp:DropDownList ID="ddlTransPortation" runat="server" AutoPostBack="True" Width="88px" 
                                CssClass="combobox">
                    <asp:ListItem Value="P">Pending</asp:ListItem>
                    <asp:ListItem Value="A">Authorized</asp:ListItem>
                </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <ew:CollapsablePanel ID="PnlTransport" CssClass="panelcells" runat="server" CollapseImageUrl="Image/UPARROW.JPG"
                    CollapserAlign="Left" ExpandImageUrl="Image/DNARROW.JPG" Height="150px" ScrollBars="Vertical"
                    Width="100%" Collapsed="True">
                    <asp:GridView ID="GrdTransport" runat="server" Width="100%" PageSize="5" GridLines="None"
                        CssClass="GridViewStyle">
                        <RowStyle CssClass="RowStyle" />
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <PagerStyle CssClass="PagerStyle" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <EditRowStyle CssClass="EditRowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView>
                </ew:CollapsablePanel>
            </td>
        </tr>
--%>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 115px">
            </td>
        </tr>
        
    </table>

     <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow ID="UserListDialog" runat="server" Title="Punch Record Detail" Height="200px"
                Width="280px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false"
                Modal="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>

</asp:Content>


