<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="MyWorkArae.aspx.vb" Inherits="MyWorkArae" Title="My Consent Area" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label5" runat="server" Text="My Consent Area (INBOX)" Width="328px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" style="text-align: left">
                <asp:Label ID="Label1" runat="server" Text="Leave Applications(To)" Width="165px"></asp:Label>
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
        <tr>
            <td colspan="3" class="buttonbackbar" style="text-align: left">
                <asp:Label ID="Label4" runat="server" Text="Leave Applications(BCC)" Width="176px"></asp:Label>
            </td>
        </tr>
        <tr>
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
        </tr>
        <tr>
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
        </tr>
        <tr>
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
        </tr>
        <tr>
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
        </tr>
        <tr>
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
        </tr>
        <tr>
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
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 115px">
            </td>
        </tr>
    </table>
</asp:Content>
