<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="TaskManagement.aspx.vb" Inherits="Default4" Title="E-HelpDesk, Communication & Task Assignment Tool"
    MaintainScrollPositionOnPostback="true" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="datetimepicker.js">
    </script>
    <table width="100%">
        <tr>
            <td class="tableheader" colspan="6">
                <asp:Label ID="Label5" runat="server" Text="E-HelpDesk, Communication And Task Assignment"
                   ></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="6" class="buttonbackbar" style="text-align: left">
                <asp:Label ID="Label1" runat="server" Text="Task Detail" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells" >
                <asp:Label ID="Label71" runat="server" Text="Task Type*" ></asp:Label>
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
                <asp:Label ID="Label75" runat="server" Text="Task Ref(If Any)"></asp:Label>
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
                <asp:Label ID="Label77" runat="server" Text="DueDate"></asp:Label>
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
                <asp:DropDownList ID="DrpSelection" runat="server" Width="88px" CssClass="combobox">
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
                <asp:Label ID="Label81" runat="server" Text="Transaction Detail" Width="288px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells" >
                <asp:Label ID="Label82" runat="server" Text="TranType"></asp:Label>
            </td>
            <td class="textcells">
                <asp:DropDownList ID="DrpTranType" runat="server" CssClass="combobox" Width="88px">
                    <asp:ListItem>Invoice</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells" >
                <asp:Label ID="Label83" runat="server" Text="TransNo"></asp:Label>
            </td>
            <td colspan="2" class="textcells">
                <asp:TextBox ID="txtTransNo" runat="server" CssClass="textbox" Width="176px"></asp:TextBox>
            </td>
            <td class="labelcells" >
                <asp:Button ID="cmdFetch" runat="server" CssClass="ButtonBack" Text="Fetch Detail" BackColor="Black" />
            </td>
        </tr>
        <tr>
            <td colspan="6" class="labelcells" >
                <ew:CollapsablePanel ID="PnlGrid" runat="server" CollapseImageUrl="Image/UPARROW.JPG"
                    CollapserAlign="Left" ExpandImageUrl="Image/DNARROW.JPG" Height="150px" ScrollBars="Auto"
                    SlideSpeed="50" Width="685px" CssClass="panelcells">
                    <asp:GridView ID="GridTran" runat="server"
                        BorderStyle="None" CellPadding="3" GridLines="Vertical" Height="1px" Width="112px" >
                        <%--<FooterStyle BackColor="#CCCCCC" />--%>
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" CssClass="gridheader" />
                        <AlternatingRowStyle CssClass="GridAI" />
                    </asp:GridView>
                </ew:CollapsablePanel>
            </td>
        </tr>
        <tr>
            <td colspan="6" class="buttonbackbar" style="text-align: left">
            <asp:Label ID="Label4" runat="server" Text="Task Assigned To" Width="288px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <ew:CollapsablePanel ID="PnlRec" runat="server" CollapseImageUrl="Image/UPARROW.JPG"
                    CollapserAlign="Left" ExpandImageUrl="Image/DNARROW.JPG" Width="100%">
                    <table width="100%">
                        <tr>
                            <td rowspan="2" class="labelcells">
                                <asp:Panel ID="Panel1" runat="server" Height="110px" ScrollBars="Vertical"
                                    Width="98%" CssClass="panelcells">
                                    <asp:CheckBoxList ID="ChkFrom" runat="server" CellPadding="0" CellSpacing="0" Width="220px">
                                    </asp:CheckBoxList>
                                </asp:Panel>
                            </td>
                            <td>
                                <asp:Button ID="cmdTo" runat="server" Font-Bold="True" Text="To" CssClass="ButtonBack" BackColor="Black" /><br />
                                <br />
                                <asp:Button ID="cmdDel" runat="server" Text="<<" CssClass="ButtonBack" BackColor="Black" />
                            </td>
                            <td style="height: 71px" width="43%" class="textcells" colspan="4">
                                <asp:Panel ID="Panel2" runat="server" BorderStyle="None" Height="50px" ScrollBars="Vertical"
                                    Width="98%" CssClass="panelcells">
                                    <asp:CheckBoxList ID="ChkTo" runat="server" CellPadding="0" CellSpacing="0" Width="280px">
                                    </asp:CheckBoxList>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="cmdCC" runat="server" Text="CC" CssClass="ButtonBack" BackColor="Black" /><br />
                            </td>
                            <td colspan="4">
                                <asp:Panel ID="Panel3" runat="server" Height="50px" ScrollBars="Vertical"
                                    CssClass="panelcells" Width="98%">
                                    <asp:CheckBoxList ID="ChkCC" runat="server" CellPadding="0" CellSpacing="0" Width="280px">
                                    </asp:CheckBoxList>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </ew:CollapsablePanel>
            </td>
        </tr>
        <tr>
            <td colspan="6" class="buttonbackbar" style="text-align: left">
            <asp:Label ID="Label85" runat="server" Text="Task Current Status And Reply" Width="288px"  ></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="6" >
                <ew:CollapsablePanel ID="PnlReply" runat="server" CollapseImageUrl="Image/UPARROW.JPG"
                    CollapserAlign="Left" ExpandImageUrl="Image/DNARROW.JPG" Width="100%" 
                    ScrollBars="Both">
                    <table  id="" width="100%">
                        <tr>
                            <td class="labelcells">
                                <asp:Label ID="Label86" runat="server" Text="Task Status*" Width="88px"></asp:Label>
                            </td>
                            <td class="textcells">
                                <asp:DropDownList ID="DrpTaskStatus" runat="server" Width="152px" 
                                    AutoPostBack="True" CssClass="combobox">
                                    <asp:ListItem>Not Started</asp:ListItem>
                                    <asp:ListItem>In Progress</asp:ListItem>
                                    <asp:ListItem>Waiting On SomeOne Else</asp:ListItem>
                                    <asp:ListItem>Deferred</asp:ListItem>
                                    <asp:ListItem>Re Assigned</asp:ListItem>
                                    <asp:ListItem>Completed</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="labelcells">
                                <asp:Label ID="Lbldummy" runat="server" Text="dummy" Visible="False"></asp:Label>
                            </td>
                            <td class="textcells">
                                <asp:CheckBox ID="ChkAuth" runat="server" Text="Authorize Close" Width="160px" />
                            </td>
                             </tr>
                        <tr>
                            <td class="labelcells">
                                <asp:Label ID="Label87" runat="server" Text="File Attachment (If Any)" Width="96px"></asp:Label>
                            </td>
                            <td colspan="5" class="textcells">
                                <asp:FileUpload ID="FlReply" runat="server" CssClass="textbox" Height="24px" 
                                    Width="181px" />&nbsp;<asp:Label ID="Label6" runat="server" Font-Bold="True" 
                                    Font-Italic="False" Font-Names="Tahoma" Font-Size="7pt" ForeColor="Red" 
                                    Text="*FileSize Limit: 5MB"></asp:Label>
                                &nbsp;
                                <asp:Button ID="cmdAttachReply" runat="server" CssClass="ButtonBack" Text="Attach File" BackColor="Black"/>&nbsp;
                                <asp:HyperLink ID="LnkReply" runat="server" NavigateUrl="DownloadFile.aspx" Font-Bold="True"
                                    Font-Names="Tahoma" Font-Size="8pt">LnkReply</asp:HyperLink>
                            </td>
                            </tr>
                        <tr>
                            <td class="labelcells">
                                <asp:Label ID="Label88" runat="server" Text="Reply*"></asp:Label><asp:CustomValidator ID="VldReply"
                                        runat="server" ErrorMessage="Please Remove Apostrophe Sign(') from Reply Content."
                                        Enabled="False">*</asp:CustomValidator>
                            </td>
                            <td colspan="3" class="labelcells">
                                &nbsp;<asp:HyperLink ID="LnkReply1" runat="server" NavigateUrl="DownloadFile.aspx"
                                    Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt">[LnkReply1]</asp:HyperLink>
                                <asp:HyperLink ID="LnkReply2" runat="server" NavigateUrl="DownloadFile.aspx" Font-Bold="True"
                                    Font-Names="Tahoma" Font-Size="8pt">[LnkReply2]</asp:HyperLink>
                                <asp:HyperLink ID="LnkReply3" runat="server" NavigateUrl="DownloadFile.aspx" Font-Bold="True"
                                    Font-Names="Tahoma" Font-Size="8pt">[LnkReply3]</asp:HyperLink>
                                <asp:HyperLink ID="LnkReply4" runat="server" NavigateUrl="DownloadFile.aspx" Font-Bold="True"
                                    Font-Names="Tahoma" Font-Size="8pt">[LnkReply4]</asp:HyperLink>
                                <asp:HyperLink ID="LnkReply5" runat="server" NavigateUrl="DownloadFile.aspx" Font-Bold="True"
                                    Font-Names="Tahoma" Font-Size="8pt">[LnkReply5]</asp:HyperLink>
                            </td>
                             </tr>
                        <tr>
                            <td colspan="6" valign="top" style="height: 34px">
                                <asp:TextBox ID="txtReply" runat="server" Font-Names="Tahoma" Font-Size="8pt" TextMode="MultiLine"
                                    Width="646px" Height="54px"></asp:TextBox>
                            </td>
                            </tr>
                    </table>
                </ew:CollapsablePanel>
            </td>
        </tr>
        <tr>
            <td colspan="6" class="buttonbackbar" style="text-align: left">
                <asp:Label ID="Label2" runat="server" Text="History (Click On Down Arrow To View)" Width="288px"></asp:Label>
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
            &nbsp; 
                <asp:Button ID="cmdSave" runat="server" CssClass="ButtonBack" Text="Save" 
                    BackColor="Black"/>
            </td>
        </tr>
    </table>
</asp:Content>
