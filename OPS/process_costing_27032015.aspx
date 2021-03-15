<%@ Page Title="" Language="VB" MasterPageFile="~/Ops/MasterPage.master" AutoEventWireup="false" CodeFile="process_costing.aspx.vb" Inherits="Costing_process_costing" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;<table style="width: 100%; height: 367px;">
        <tr>
            <td style="height: 1px" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Process Costing"></asp:Label>
            </td>
            <td style="height: 1px">
                <asp:Label ID="Label2" runat="server" CssClass="labelcells" Text="Action" 
                    Visible="False"></asp:Label>
            </td>
            <td style="height: 1px" colspan="6">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_action" runat="server" CssClass="combobox" 
                            Width="100px" Visible="False">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 1px">
            </td>
            <td style="height: 1px">
                <asp:ImageButton ID="imb_close" runat="server" Height="20px" ImageAlign="Right" 
                    ImageUrl="~/Image/close24.png" />
            </td>
        </tr>
        <tr>
            <td style="width: 62px">
                <asp:Label ID="Label3" runat="server" CssClass="labelcells" Text="Plant"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_location" runat="server" CssClass="combobox">
                            <asp:ListItem>COTTON</asp:ListItem>
                            <asp:ListItem>TAFFETA</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="Label8" runat="server" CssClass="labelcells" Text="Tran. No."></asp:Label>
            </td>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_tranno" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                        <asp:ImageButton ID="imb_tran_fetch" runat="server" Height="12px" 
                            ImageUrl="~/Image/Buttons_Tabs/Arrow_Right.png" 
                            ToolTip="Fetch Tran. No." />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="2">
                <asp:Label ID="Label9" runat="server" CssClass="labelcells" Text="Status"></asp:Label>
            </td>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_status" runat="server" Text="..." CssClass="labelcells" 
                            Width="100px"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 62px">
                <asp:Label ID="Label4" runat="server" CssClass="labelcells" Text="Count/Sort"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_countcode_sortno" runat="server" CssClass="textbox" 
                            Width="80px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" CssClass="labelcells" Text="Party Code"></asp:Label>
            </td>
            <td colspan="6">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_partycode" runat="server" CssClass="textbox" Width="60px"></asp:TextBox>
                        <asp:ImageButton ID="imb_fetch_partycode" runat="server" Height="12px" 
                            ImageUrl="~/Image/Buttons_Tabs/Arrow_Right.png" ToolTip="Fetch Party" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 62px">
                <asp:Label ID="Label5" runat="server" CssClass="labelcells" Text="Rate Type"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_ratetype" runat="server" CssClass="combobox">
                            <asp:ListItem>BOOK</asp:ListItem>
                            <asp:ListItem>MARKET</asp:ListItem>
                        </asp:DropDownList>
                        <asp:ImageButton ID="imb_fetch" runat="server" Height="12px" 
                            ImageUrl="~/Image/Buttons_Tabs/Arrow_Right.png" 
                            ToolTip="Fetch Count/Sort" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="Label7" runat="server" CssClass="labelcells" Text="Party Name" 
                    Width="80px"></asp:Label>
            </td>
            <td colspan="6">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_partyname" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 62px">
                &nbsp;</td>
            <td>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" 
                            ImageUrl="~/Image/loading.gif" Height="12px" Width="102px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                </td>
            <td>
                <asp:Label ID="Label10" runat="server" CssClass="labelcells" Text="Sale Person" 
                    Width="70px"></asp:Label>
            </td>
            <td colspan="6">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        
                        <asp:DropDownList ID="ddl_saleperson" runat="server" CssClass="combobox" 
                            Width="250px">
                        </asp:DropDownList>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 62px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_top" runat="server" Height="14px" 
                            ImageUrl="~/Image/LeftArrow.png" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_next" runat="server" Height="14px" 
                            ImageUrl="~/Image/DNARROW.JPG" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_previous" runat="server" Height="14px" 
                            ImageUrl="~/Image/UPARROW.JPG" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_last" runat="server" Height="14px" 
                            ImageUrl="~/Image/RightArrow.png" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="9">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="150px" 
                    BorderStyle="Solid">
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" Font-Bold="False">
                                    <HeaderStyle CssClass="GridHeader" Font-Bold="False" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </asp:Panel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 62px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td colspan="6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 62px">
                <asp:LinkButton ID="lbt_apply" runat="server" CssClass="buttonc" 
                    Visible="False">APPLY</asp:LinkButton>
            </td>
            <td colspan="8" align="center">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lbt_view" runat="server" CssClass="buttonc">VIEW</asp:LinkButton>
                        <asp:LinkButton ID="lbt_add" runat="server" CssClass="buttonc">ADD</asp:LinkButton>
                        <asp:LinkButton ID="lbt_modify" runat="server" CssClass="buttonc">MODIFY</asp:LinkButton>
                        <asp:LinkButton ID="lbt_authorize" runat="server" CssClass="buttonc">AUTHORIZE</asp:LinkButton>
                        <asp:LinkButton ID="lbt_delete" runat="server" CssClass="buttonc">DELETE</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:ImageButton ID="imb_excel" runat="server" Height="16px" 
                    ImageUrl="~/Image/XportXLFinal.png" ToolTip="Save in Excel" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 62px">
                &nbsp;</td>
            <td colspan="9">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate>
                    <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                         FadeInDuration="2" FadeInSteps="2" FadeOutDuration="2" FadeOutSteps="2" Visible="true" />
                   </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 62px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td colspan="6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

