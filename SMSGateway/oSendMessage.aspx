<%@ Page Title="" Language="VB" MasterPageFile="~/SMSGateway/MasterPage.master" AutoEventWireup="false" CodeFile="SendMessage.aspx.vb" Inherits="SMSLive_SendMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader">
                &nbsp; New&nbsp;Message</td>
        </tr>
    </table>
    
    <table style="width:100%;">
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label16" runat="server" Text="Message Type"></asp:Label>
            </td>
            <td class="textcells">
                <asp:CheckBox ID="CheckBox1" runat="server" Text="SMS" />
&nbsp;
                <asp:CheckBox ID="CheckBox2" runat="server" Text="Email" />
            &nbsp;<asp:CheckBox ID="CheckBox3" runat="server" Text="Both" />
            </td>
            <td class="labelcells">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label17" runat="server" Text="Contact Type"></asp:Label>
            </td>
            <td class="textcells">
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="combobox">
                    <asp:ListItem>Customer</asp:ListItem>
                    <asp:ListItem>Retail Customer</asp:ListItem>
                    <asp:ListItem>Employee</asp:ListItem>
                    <asp:ListItem>Supplier</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="textcells">
                <asp:CheckBox ID="chkGroups" runat="server" Text="Show Groups" />
                <asp:CheckBox ID="chkContacts" runat="server" Text="Show Contacts" />
            </td>
            <td class="labelcells">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="tableback" valign="top">
                <asp:Label ID="Label18" runat="server" Text="Contact Name(s)"></asp:Label>
            </td>
            <td class="tableback" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                    <asp:CheckBoxList ID="cblContacts" runat="server" CellPadding="0" 
                    CellSpacing="0" RepeatColumns="2" RepeatDirection="Horizontal" 
                    DataSourceID="SqlDataSource1" DataTextField="ContactName" 
                    DataValueField="ContactID" Width="100%" AutoPostBack="True">
                        </asp:CheckBoxList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                            SelectCommand="Select ContactID, ContactID + ':' + ContactName as ContactName from jct_sms_contactmaster where status = 'A'">
                        </asp:SqlDataSource>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="buttonc" 
                    Visible="False">Add</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="textcells" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="grdContacts" runat="server" Font-Bold="False" Width="100%" 
                            AutoGenerateColumns="False">
                            <RowStyle CssClass="GridItem" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgRemove" runat="server" 
                                            ImageUrl="Image/iphone_delete_icon.png" 
                                            CommandArgument='<%# Eval("ContactID") %>' CommandName="Remove" />
                                    </ItemTemplate>
                                    <ItemStyle Width="15px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ContactID" HeaderText="Contact ID" />
                                <asp:BoundField DataField="ContactName" HeaderText="Contact Name" />
                                <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" />
                                <asp:BoundField DataField="EmailAddress" HeaderText="Email Address" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" 
                                            ImageUrl="~/SMSGateway/Image/iPhone_SMS_sm.jpg" 
                                            Visible='<%# Eval("SMSMode") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="15px" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Image ID="Image2" runat="server" 
                                            ImageUrl="~/SMSGateway/Image/iphone-email_sm.jpg" 
                                            Visible='<%# Eval("EmailMode") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="15px" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cblContacts" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label20" runat="server" Text="To"></asp:Label>
            </td>
            <td class="textcells" colspan="2">
                <asp:TextBox ID="txtTo" runat="server" CssClass="textbox" Height="33px" 
                    TextMode="MultiLine" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label19" runat="server" Text="Subject"></asp:Label>
            </td>
            <td class="textcells" colspan="2">
                <asp:DropDownList ID="ddlSubject" runat="server" CssClass="combobox" 
                    AutoPostBack="True">
                    <asp:ListItem Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label21" runat="server" Text="Message"></asp:Label>
            </td>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtMessageText" runat="server" Height="88px" MaxLength="160" 
                    TextMode="MultiLine" Width="331px" CssClass="textbox"></asp:TextBox>
                        <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMessageText" 
                    Display="Dynamic" ErrorMessage="Maximum 160 characters are allowed including spaces." 
                    ValidationExpression="[\s\S]{1,160}" SetFocusOnError="True"></asp:RegularExpressionValidator>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSubject" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td colspan="2">
                <asp:LinkButton ID="cmdSendMessage" runat="server" CssClass="buttonc" 
                    onclientclick="javascript: return confirm('Are you sure you want to Send this message')">Send</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

