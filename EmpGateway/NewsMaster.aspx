<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="NewsMaster.aspx.vb" Inherits="NewsMaster" Title="News master" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label6" runat="server" Text="News Master" Width="108px"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td colspan="7">
                <asp:Label ID="Label5" runat="server" Text="Action :" class="labelcells"></asp:Label>
            </td>
            <td colspan="3" class="textcells">
                <asp:RadioButton ID="Radd" runat="server" AutoPostBack="True" Font-Names="Verdana"
                    GroupName="a" Text="Add New" Width="110px" />&nbsp;
                <asp:RadioButton ID="Rupd" runat="server" AutoPostBack="True" Font-Names="Verdana"
                    GroupName="a" Text="Update Existing" Width="142px" />
                <asp:RadioButton ID="Rauth" runat="server" AutoPostBack="True" Font-Names="Verdana"
                    GroupName="a" Text="Authorize" Width="118px" />
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server" Height="60px" Width="100%" >
        <table style="width: 100%; font-size: 3pt; border-top-width: 1px; border-left-width: 1px;
            border-left-color: #000000; border-bottom-width: 1px; border-bottom-color: #000000;
            border-top-color: #000000; height: 60px; border-right-width: 1px; border-right-color: #000000;">
            <tr>
                <td class="labelcells">
                    <asp:Label ID="Label26" runat="server" Text="Department" Width="112px"></asp:Label>
                </td>
                <td class="textcells">
                    <asp:DropDownList ID="ddldept" runat="server" Height="20px" Width="276px" AutoPostBack="True"
                        CssClass="combobox">
                    </asp:DropDownList>
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:Button ID="btnview" runat="server" CssClass="ButtonBack" Text="View All" BackColor="Black" />
                </td>
            </tr>
            <tr>
                <td class="labelcells">
                    <asp:Label ID="Label2" runat="server" Text="Type" Width="112px"></asp:Label>
                </td>
                <td class="textcells">
                    <asp:RadioButtonList ID="RLtype" runat="server" Height="25px" RepeatDirection="Horizontal"
                        Width="209px" AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="I">Internal</asp:ListItem>
                        <asp:ListItem Value="E">External</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <span style="font-size: 3pt">ff</span><br />
    <asp:Panel ID="Panel2" runat="server" Width="100%" Style="height: 200px">
        <table style="width: 100%; font-size: 3pt; border-top-width: 1px; border-left-width: 1px;
            border-left-color: #000000; border-bottom-width: 1px; border-bottom-color: #000000;
            border-top-color: #000000; height: 200px; border-right-width: 1px; border-right-color: #000000;">
            <tr>
                <td class="labelcells">
                    <asp:Label ID="Label9" runat="server" Text="News No." Width="112px"></asp:Label>
                </td>
                <td colspan="3" class="labelcells">
                    <asp:Label ID="lblnews" runat="server" Width="112px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="labelcells">
                    <asp:Label ID="Label1" runat="server" Text="Headline" Width="112px"></asp:Label>
                </td>
                <td colspan="3" class="textcells">
                    <asp:TextBox ID="txthead" runat="server" Height="13px" Width="353px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labelcells">
                    <asp:Label ID="Label3" runat="server" Text="News Start Date" Width="112px"></asp:Label>
                </td>
                <td colspan="1" class="textcells">
                    <ew:CalendarPopup ID="datestart" runat="server" CssClass="textbox" Culture="English (United Kingdom)"
                        Text="..." UpperBoundDate="12/31/9990 23:59:00" VisibleDate="" Width="65px">
                        <ClearDateStyle BackColor="#E0E0E0" />
                        <DayHeaderStyle BackColor="OrangeRed" />
                        <MonthYearSelectedItemStyle BackColor="Silver" />
                        <TodayDayStyle BackColor="#FFC0C0" />
                        <MonthHeaderStyle BackColor="Gray" />
                        <GoToTodayStyle BackColor="#E0E0E0" />
                    </ew:CalendarPopup>
                </td>
                <td colspan="1" class="labelcells">
                    <asp:Label ID="Label4" runat="server" Text="News Ending Date" Width="112px"></asp:Label>
                </td>
                <td colspan="1" class="labelcells">
                    &nbsp;<ew:CalendarPopup ID="DateEnd" runat="server" Culture="English (United Kingdom)"
                        Text="..." UpperBoundDate="12/31/9990 23:59:00" VisibleDate="" Width="65px">
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
                    <asp:Label ID="Label7" runat="server" Text="Description" Width="112px"></asp:Label>
                </td>
                <td colspan="3" style="height: 16px;">
                    <asp:TextBox ID="txtdesc" runat="server" Height="57px" Width="353px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labelcells">
                    <asp:LinkButton ID="lnkaddimg" runat="server" CausesValidation="False" Width="110px">Attach File</asp:LinkButton>
                </td>
                <td colspan="3" class="labelcells">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="329px" />
                </td>
            </tr>
            <tr>
                <td align="center" class="buttonbackbar" colspan="4" style="height: 16px;">
                    <asp:Button ID="btnIns" runat="server" CssClass="ButtonBack"  BackColor="Black" />
                    &nbsp; &nbsp;&nbsp;
                    <asp:Button ID="btndet" runat="server" CssClass="ButtonBack" Text="Add/View Detail"
                        Width="93px" BackColor="Black" />
                    &nbsp; &nbsp;&nbsp;<asp:Button ID="btnClear" runat="server" CausesValidation="False"
                        CssClass="ButtonBack" Text="Reset" Height="21px" BackColor="Black" />
                    &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
    <span style="font-size: 3pt; color: #ffffff">eee<asp:Panel ID="Panel3" runat="server"
        Height="200px" ScrollBars="Vertical" 
        Width="100%" CssClass="panelcells">
        <table style="width: 100%; border-top-width: 1px; border-left-width: 1px; border-left-color: #000000;
            border-bottom-width: 1px; border-bottom-color: #000000; border-top-color: #000000;
            border-right-width: 1px; border-right-color: #000000;">
            <tr>
                <td class="textcells">
                    <asp:Label ID="Label8" runat="server"
                        Text="Status:" CssClass="labelcells"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:DropDownList ID="ddlnews" runat="server" AutoPostBack="True"
                        Width="88px" CssClass="combobox">
                        <asp:ListItem Value="P">Pending</asp:ListItem>
                        <asp:ListItem Value="A">Authorized</asp:ListItem>
                        <asp:ListItem Value="C">Cancelled</asp:ListItem>
                    </asp:DropDownList>
                   
                </td>
            </tr>
            <tr style="font-family: Times New Roman">
                <td style="height: 21px;">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="98%">
                        <Columns>
                            <asp:TemplateField HeaderText="News No.">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnknews" runat="server" Font-Names="Verdana" ForeColor="Red"
                                        Text='<%# Eval("transaction_no") %>' CommandName="select"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Headline">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblhead" runat="server" Text='<%# eval("headline") %>' Width="198px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FileName">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblfile" runat="server" Text='<%# eval("filename") %>' Width="95px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Start_Date">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblstart" runat="server" Text='<%# Eval("DOS") %>' Width="61px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="End_Date">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblend" runat="server" Text='<%# Eval("DOE") %>' Width="59px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Details">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkdetail" runat="server" CausesValidation="False" Font-Names="Verdana"
                                        Width="52px">Detail</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remove">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkrem" runat="server" CausesValidation="False" Font-Names="Verdana"
                                        Width="52px" CommandName="delete">Remove</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" 
                            CssClass="gridheader" />
                        <AlternatingRowStyle CssClass="GridAI" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
    </span>
    <br />
</asp:Content>
