<%@ Page Title="" Language="VB" MasterPageFile="~/SMSGateway/MasterPage.master" AutoEventWireup="false"
    CodeFile="MessagingGroups.aspx.vb" Inherits="SMSLive_MessagingGroups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader">
                &nbsp;Messaging Groups<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
                </asp:ScriptManagerProxy>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label18" runat="server" Text="New Group Code"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="txtGroupCode" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="textcells">
                <asp:Label ID="Label21" runat="server" Text="New Group Name"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="txtGroupName" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="textcells" colspan="3">
                <asp:LinkButton ID="cmdCreate" runat="server" CssClass="buttonc">Create</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label16" runat="server" Text="Existing Groups"></asp:Label>
            </td>
            <td class="textcells" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:ListBox ID="lstGroups" runat="server" CssClass="combobox" Height="89px" Width="37%"
                            AutoPostBack="True" DataSourceID="SqlGroups" DataTextField="GroupName" DataValueField="GroupId">
                        </asp:ListBox>
                        <asp:SqlDataSource ID="SqlGroups" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                            SelectCommand="select GroupId, GroupName from jct_sms_messaging_groups where status = 'A'">
                        </asp:SqlDataSource>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cmdCreate" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" Visible="False"></asp:TextBox>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonc" 
                    Visible="False">Filter</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Label ID="Label19" runat="server" Text="Existing Contacts in "></asp:Label>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblGroupName" runat="server"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lstGroups" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td>
            </td>
            <td class="NormalText">
                <asp:Label ID="Label20" runat="server" Text="List of available Contacts of Type"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlContactType" runat="server" AutoPostBack="True" CssClass="combobox"
                    ToolTip="Select Contact Type to Filter Contacts" Visible="False">
                    <asp:ListItem Value="Customer">Customer</asp:ListItem>
                    <asp:ListItem>Retail Customer</asp:ListItem>
                    <asp:ListItem Value="Supplier">Supplier</asp:ListItem>
                    <asp:ListItem>Employee</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tableback" colspan="2" style="width: 49%">
                <asp:Panel ID="Panel1" runat="server" Width="100%" Height="200px" CssClass="NormalText"
                    ForeColor="Blue" ScrollBars="Auto">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional" 
                        RenderMode="Inline">
                        <ContentTemplate>
                            <asp:CheckBoxList ID="cblNewContacts" runat="server" CellPadding="0" CellSpacing="0"
                                Font-Bold="False" ForeColor="Blue">
                            </asp:CheckBoxList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="cmdAddItems" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="cmdSave" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:CheckBoxList ID="cblGroupContacts" runat="server" CellPadding="0" CellSpacing="0"
                                Font-Bold="False" ForeColor="#006600" DataSourceID="SqlGroupContacts" 
                                DataTextField="EmpName" DataValueField="ContactId">
                            </asp:CheckBoxList>
                            <asp:SqlDataSource ID="SqlGroupContacts" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                              SelectCommand="select contactID, contactid + ' | ' + empname + ' | ' + deptcode as empname from jct_sms_group_members a inner join jct_empmast_base b on a.contactid = b.empcode
where GroupId = @groupid and status = 'A' order by a.empname">
                <SelectParameters>
                                    <asp:ControlParameter ControlID="lstGroups" Name="groupid" 
                                        PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="lstGroups"
                                EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="cmdSave" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
            <td style="width: 2%">
                <asp:Button ID="cmdAddItems" runat="server" BorderColor="Black" BorderStyle="Solid"
                    BorderWidth="1px" CssClass="buttonc" Text="&lt;&lt;" Width="35px" />
                <br />
                <asp:Button ID="Button2" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                    CssClass="buttonc" Text="&gt;&gt;" Width="35px" />
            </td>
            <td class="tableback" colspan="2" style="width: 49%">
                <asp:Panel ID="Panel2" runat="server" Width="100%" Height="200px" 
                    CssClass="NormalText" ScrollBars="Auto">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:CheckBoxList ID="cblContacts" runat="server" DataSourceID="SqlAllContacts" DataTextField="EmpName"
                                DataValueField="EmpCode" Font-Bold="False" Enabled="False">
                            </asp:CheckBoxList>
                            <asp:SqlDataSource ID="SqlAllContacts" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                                SelectCommand="select a.empcode, a.empname + ' | ' + a.empcode + ' | ' + a.deptcode as empname from jct_empmast_base a INNER JOIN mistel c ON a.empcode = c.empcode and a.company_code = c.company_code 
                where a.active = 'Y' and a.company_code = 'jct00ltd' order by a.empname">
                            </asp:SqlDataSource>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlContactType" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="lstGroups" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="cmdAddItems" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblMessage" runat="server" 
    CssClass="errormsg"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cmdSave" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td class="labelcells">
                <asp:LinkButton ID="cmdSave" runat="server" CssClass="buttonc">Save</asp:LinkButton>
            </td>
            <td class="textcells">
                &nbsp;
            </td>
            <td class="textcells">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="textcells">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
