<%@ Page Title="" Language="VB" MasterPageFile="~/SMSGateway/MasterPage.master" AutoEventWireup="false"
    CodeFile="SendMessage.aspx.vb" Inherits="SMSLive_SendMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader">
                New&nbsp;Message
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label16" runat="server" Text="Message Type"></asp:Label>
            </td>
            <td class="textcells">
                <asp:CheckBox ID="CheckBox1" runat="server" Text="SMS" />
                &nbsp;
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label17" runat="server" Text="Contact Type"></asp:Label>
            </td>
            <td class="textcells">
                <asp:DropDownList ID="ddlContactType" runat="server" CssClass="combobox" AutoPostBack="True"
                    Enabled="False">
                    <asp:ListItem>Employee</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        </table>
    <table style="width: 100%;">
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label18" runat="server" Text="Contact Groups"></asp:Label>
            </td>
            <td class="textcells">
                &nbsp;</td>
        </tr>
        </table>
    <table style="width: 100%;">
        <tr>
            <td class="tableback" valign="top" colspan="2">
                <asp:Panel ID="Panel3" runat="server" Height="70px" ScrollBars="Auto" Width="100%">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:CheckBoxList ID="cblGroups" runat="server" CellPadding="0" CellSpacing="0" RepeatColumns="3"
                                RepeatDirection="Horizontal" DataSourceID="dsContactGroups" DataTextField="groupname"
                                DataValueField="groupid" Width="100%" AutoPostBack="True">
                            </asp:CheckBoxList>
                            <asp:SqlDataSource ID="dsContactGroups" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                                SelectCommand="select groupid, groupname from jct_sms_messaging_groups where status = 'A'">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlContactType" Name="contacttype" PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
                
                <asp:LinkButton ID="cmdAddGroup" runat="server" CssClass="buttonc">Add Group</asp:LinkButton>
                
            </td>
        </tr>
        <tr>
            <td class="tableback" valign="top" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="AdjResultsDiv1">
                                <asp:GridView ID="grdGroupContacts" runat="server" 
                                AutoGenerateColumns="False" Font-Bold="False"
                                    Width="97%">
                                    <RowStyle CssClass="GridItem" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgRemove0" runat="server" CommandArgument='<%# Eval("ContactID") %>'
                                                    CommandName="Remove" ImageUrl="Image/iphone_delete_icon.png" />
                                            </ItemTemplate>
                                            <ItemStyle Width="15px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="GroupID" HeaderText="Group" />
                                        <asp:BoundField DataField="ContactID" HeaderText="Contact ID" />
                                        <asp:BoundField DataField="ContactName" HeaderText="Contact Name" />
                                        <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" />
                                        <asp:BoundField DataField="EmailAddress" HeaderText="Email Address" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Image ID="Image3" runat="server" ImageUrl="~/SMSGateway/Image/iPhone_SMS_sm.jpg"
                                                    Visible='<%# Eval("SMSMode") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="15px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Image ID="Image4" runat="server" ImageUrl="~/SMSGateway/Image/iphone-email_sm.jpg"
                                                    Visible='<%# Eval("EmailMode") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="15px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                </asp:GridView>
                           <%-- </asp:Panel>--%>
                            <%--<asp:Panel ID="Panel13" runat="server" Height="200px" ScrollBars="Auto" Width="100%">--%>
                                </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cblContacts" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="cmdAdd" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ddlContactType" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="cmdAddGroup" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                
            </td>
        </tr>
        <tr>
            <td class="labelcells" valign="top">
                Contacts
            </td>
            <td valign="top">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="tableback" valign="top" colspan="2">
                <asp:Panel ID="Panel2" runat="server" Height="200px" ScrollBars="Auto" Width="100%">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:CheckBoxList ID="cblContacts" runat="server" CellPadding="0" CellSpacing="0"
                                RepeatColumns="3" RepeatDirection="Horizontal" DataSourceID="SqlDataSource1"
                                DataTextField="empname" DataValueField="empcode" Width="100%">
                            </asp:CheckBoxList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                                SelectCommand="select a.empcode, a.empname + ' | ' + a.empcode + ' | ' + a.deptcode as empname from jct_empmast_base a INNER JOIN mistel c ON a.empcode = c.empcode and a.company_code = c.company_code 
                where a.active = 'Y' and a.company_code = 'jct00ltd' order by a.empname">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlContactType" Name="contacttype" PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlContactType" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="grdContacts" EventName="RowCommand" />
                        </Triggers>
                    </asp:UpdatePanel>
                </asp:Panel>
                <asp:LinkButton ID="cmdAdd" runat="server" CssClass="buttonc">Add Contact</asp:LinkButton>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="AdjResultsDiv">
                            <%--<asp:Panel ID="Panel13" runat="server" Height="200px" ScrollBars="Auto" Width="100%">--%>
                                <asp:GridView ID="grdContacts" runat="server" AutoGenerateColumns="False" Font-Bold="False"
                                    Width="97%">
                                    <RowStyle CssClass="GridItem" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgRemove" runat="server" CommandArgument='<%# Eval("ContactID") %>'
                                                    CommandName="Remove" ImageUrl="Image/iphone_delete_icon.png" />
                                            </ItemTemplate>
                                            <ItemStyle Width="15px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ContactID" HeaderText="Contact ID" />
                                        <asp:BoundField DataField="ContactName" HeaderText="Contact Name" />
                                        <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" />
                                        <asp:BoundField DataField="EmailAddress" HeaderText="Email Address" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/SMSGateway/Image/iPhone_SMS_sm.jpg"
                                                    Visible='<%# Eval("SMSMode") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="15px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Image ID="Image2" runat="server" ImageUrl="~/SMSGateway/Image/iphone-email_sm.jpg"
                                                    Visible='<%# Eval("EmailMode") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="15px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                </asp:GridView>
                           <%-- </asp:Panel>--%>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cblContacts" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="cmdAdd" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ddlContactType" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label20" runat="server" Text="To"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="txtTo" runat="server" CssClass="textbox" Height="33px" TextMode="MultiLine"
                    Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label19" runat="server" Text="Subject"></asp:Label>
            </td>
            <td class="textcells">
                <asp:DropDownList ID="ddlSubject" runat="server" CssClass="combobox" AutoPostBack="True">
                    <asp:ListItem Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label21" runat="server" Text="Message"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtMessageText" runat="server" Height="88px" MaxLength="160" TextMode="MultiLine"
                            Width="331px" CssClass="textbox"></asp:TextBox>
                        <br />
                        <asp:DataList ID="dlsValues" runat="server" RepeatColumns="2" RepeatDirection="Horizontal"
                            Width="100%">
                            <ItemTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="labelcells">
                                            <asp:Label ID="lblLabel" runat="server" Text='<%# Eval("PlaceHolder") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtValue" runat="server" CssClass="textbox" Text='<%# Bind("Value") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:LinkButton ID="cmdPreviewMsg" runat="server" CssClass="buttonc">Preview</asp:LinkButton>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMessageText"
                            Display="Dynamic" ErrorMessage="Maximum 160 characters are allowed including spaces."
                            ValidationExpression="[\s\S]{1,160}" SetFocusOnError="True"></asp:RegularExpressionValidator>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSubject" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                <asp:LinkButton ID="cmdSendMessage" runat="server" CssClass="buttonc" OnClientClick="javascript: return confirm('Are you sure you want to Send this message')">Send</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
