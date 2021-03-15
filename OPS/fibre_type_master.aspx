<%@ Page Title="" Language="VB" MasterPageFile="~/Ops/MasterPage.master" AutoEventWireup="false" CodeFile="fibre_type_master.aspx.vb" Inherits="Costing_fibre_type_master" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 90%; height: 280px;">
        <tr>
            <td style="width: 166px; height: 39px">
                <asp:Label ID="Label1" runat="server" Text="Fibre Type Master" Width="120px"></asp:Label>
            </td>
            <td style="height: 39px">
                </td>
            <td style="height: 39px; width: 18px">
                <asp:Label ID="Label10" runat="server" CssClass="labelcells" Text="Action" 
                    Visible="False"></asp:Label>
                </td>
            <td style="height: 39px">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_action" runat="server" CssClass="combobox" 
                            Width="134px" Visible="False">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td style="height: 39px">
                </td>
            <td style="height: 39px">
                <asp:ImageButton ID="imb_close" runat="server" Height="20px" ImageAlign="Right" 
                    ImageUrl="~/Image/close24.png" />
                </td>
            <td style="height: 39px">
                </td>
        </tr>
        <tr>
            <td style="width: 166px; height: 19px">
                <asp:Label ID="Label2" runat="server" CssClass="labelcells" 
                    Text="Main Fibre Code"></asp:Label>
            </td>
            <td style="height: 19px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_main_fibre_code" runat="server" CssClass="combobox" 
                            AutoPostBack="True" Width="69px">
                        </asp:DropDownList>
                        <asp:TextBox ID="txt_main_fibre_code" runat="server" CssClass="textbox" 
                            Height="10px" Width="50px" AutoPostBack="True"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 19px; width: 18px">
                <asp:Label ID="Label4" runat="server" CssClass="labelcells" Text="Desc."></asp:Label>
            </td>
            <td style="height: 19px">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_main_fibre_desc" runat="server" CssClass="textbox" 
                            Width="240px" Height="10px" AutoPostBack="True"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 19px">
                <asp:Label ID="Label6" runat="server" CssClass="labelcells" Text="Tran. No."></asp:Label>
                </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_tranno" runat="server" CssClass="textbox" Width="70px" 
                            Height="10px"></asp:TextBox>
                        <asp:ImageButton ID="imb_tran_fetch" runat="server" Height="10px" 
                            ImageUrl="~/Image/Buttons_Tabs/Arrow_Right.png" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td style="height: 19px">
                </td>
        </tr>
        <tr>
            <td style="width: 166px; height: 13px">
                <asp:Label ID="Label3" runat="server" CssClass="labelcells" 
                    Text="Sub Fibre Code"></asp:Label>
            </td>
            <td style="height: 13px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_sub_fibre_code" runat="server" CssClass="combobox" 
                            Width="69px" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:TextBox ID="txt_sub_fibre_code" runat="server" CssClass="textbox" 
                            Height="10px" Width="50px" AutoPostBack="True"></asp:TextBox>
                        <asp:ImageButton ID="imb_newcode" runat="server" ImageUrl="~/Image/Expand.png" 
                            style="width: 9px" ToolTip="Create new code" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 13px; width: 18px">
                <asp:Label ID="Label5" runat="server" CssClass="labelcells" Text="Desc."></asp:Label>
            </td>
            <td style="height: 13px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_sub_fibre_desc" runat="server" CssClass="textbox" 
                            Height="10px" Width="240px" AutoPostBack="True"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 13px">
                <asp:Label ID="Label7" runat="server" CssClass="labelcells" Text="Status"></asp:Label>
                </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_status" runat="server" Text="..." CssClass="labelcells" 
                            Width="100px"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td style="height: 13px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 166px; height: 14px;">
                
                <asp:Label ID="Label11" runat="server" CssClass="labelcells" 
                    Text="Main Fibre Seq. No."></asp:Label>
                
                </td>
            <td style="height: 14px;">
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_main_fibre_seqno" runat="server" CssClass="textbox" 
                            Height="10px" Width="50px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBE1" runat="server" FilterType="Numbers" 
                            TargetControlID="txt_main_fibre_seqno">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 18px; height: 14px;">
                <asp:Label ID="Label8" runat="server" CssClass="labelcells" 
                    Text="Eff.From"></asp:Label>
            </td>
            <td style="height: 14px">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_efffrom" runat="server" CssClass="textbox" Width="55px" 
                            Height="10px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalExt1" runat="server" TargetControlID="txt_efffrom">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 14px">
                <asp:Label ID="Label9" runat="server" CssClass="labelcells" 
                    Text="Eff. To"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_effto" runat="server" CssClass="textbox" Width="55px" 
                            Height="10px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalExt2" runat="server" TargetControlID="txt_effto">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 14px">
                </td>
        </tr>
        <tr>
            <td style="width: 166px">
                
                <asp:Label ID="Label12" runat="server" CssClass="labelcells" 
                    Text="Sub Fibre Seq. No."></asp:Label>
                
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_sub_fibre_seqno" runat="server" CssClass="textbox" 
                            Height="10px" Width="50px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBE2" runat="server" FilterType="Numbers" 
                            TargetControlID="txt_sub_fibre_seqno">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 18px">
                <asp:Label ID="Label13" runat="server" CssClass="labelcells" 
                    Text="(mm/dd/yyyy)"></asp:Label>
              </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="Label14" runat="server" CssClass="labelcells" 
                    Text="(mm/dd/yyyy)"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" Height="187px">
                    <div ID="AdjResultsDiv">
                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    Font-Bold="False">
                                    <Columns>
                                        <asp:BoundField DataField="tran_no" HeaderText="Tran. No." />
                                        <asp:BoundField DataField="main_fibre_code" HeaderText="Main Fibre Code" />
                                        <asp:BoundField DataField="main_fibre_desc" HeaderText="Main Fibre Desc." />
                                        <asp:BoundField DataField="main_sequence_no" HeaderText="Main Seq. No." />
                                        <asp:BoundField DataField="sub_fibre_code" HeaderText="Sub Fibre Code" />
                                        <asp:BoundField DataField="sub_fibre_desc" HeaderText="Sub Fibre Desc." />
                                        <asp:BoundField DataField="sub_sequence_no" HeaderText="Sub Seq. No." />
                                        <asp:BoundField DataField="eff_from" HeaderText="Eff.From" />
                                        <asp:BoundField DataField="eff_to" HeaderText="Eff.To." />
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </asp:Panel>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 166px">
                &nbsp;</td>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
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
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 166px">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        
                        <asp:LinkButton ID="lbt_apply" runat="server" CssClass="buttonc" 
                            Visible="False">APPLY</asp:LinkButton>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                    <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                         FadeInDuration="2" FadeInSteps="2" FadeOutDuration="2" FadeOutSteps="2" Visible="true" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 166px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td style="width: 18px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

