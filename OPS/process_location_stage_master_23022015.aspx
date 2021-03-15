<%@ Page Title="" Language="VB" MasterPageFile="~/Ops/MasterPage.master" AutoEventWireup="false" CodeFile="process_location_stage_master.aspx.vb" Inherits="Costing_process_location_stage_master" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 35%; height: 314px;">
        <tr>
            <td colspan="3" style="height: 37px">
                <asp:Label ID="Label1" runat="server" 
                    Text="Process Location &amp; Stage Master"></asp:Label>
            </td>
            <td style="height: 37px" width="50">
                <asp:Label ID="Label12" runat="server" CssClass="labelcells" Text="Action" 
                    Visible="False"></asp:Label>
                </td>
            <td style="height: 37px" width="100">
                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_action" runat="server" CssClass="combobox" 
                            Visible="False">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td style="height: 37px">
                </td>
            <td colspan="4" style="height: 37px">
                <asp:ImageButton ID="imb_close" runat="server" Height="20px" ImageAlign="Right" 
                    ImageUrl="~/Image/close24.png" ToolTip="Close Form" />
            </td>
        </tr>
        <tr>
            <td style="width: 87px">
                <asp:Label ID="Label2" runat="server" CssClass="labelcells" Text="Plant"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_location" runat="server" CssClass="combobox">
                            <asp:ListItem>COTTON</asp:ListItem>
                            <asp:ListItem>TAFFETA</asp:ListItem>                        
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Tran.No." CssClass="labelcells"></asp:Label>
            </td>
            <td colspan="2" width="300">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_tranno" runat="server" CssClass="textbox"></asp:TextBox>
                        <asp:ImageButton ID="imb_tran_fetch" runat="server" Height="12px" 
                            ImageUrl="~/Image/Buttons_Tabs/Arrow_Right.png" 
                            ToolTip="Fetch Tran. No." style="width: 15px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="Label8" runat="server" CssClass="labelcells" Text="Status"></asp:Label>
            </td>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_status" runat="server" Text="OPEN"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 87px">
                <asp:Label ID="Label3" runat="server" CssClass="labelcells" 
                    Text="Process Location Code" Width="140px"></asp:Label>
            </td>
            <td width="100">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_process_location_code" runat="server" 
                            CssClass="combobox">
                        </asp:DropDownList>
                        <asp:TextBox ID="txt_process_location_code" runat="server" CssClass="textbox" 
                            Width="70px" ToolTip="Type new process code here &amp; Press enter"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" CssClass="labelcells" Text="Desc."></asp:Label>
            </td>
            <td colspan="2" width="300">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_process_location_desc" runat="server" Text="..." 
                            CssClass="labelcells" Width="300px"></asp:Label>
                        
                        <asp:TextBox ID="txt_process_location_desc" runat="server" CssClass="textbox" 
                            Width="300px" 
                            ToolTip="Type new process location desc. here &amp; Press enter"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="Label9" runat="server" CssClass="labelcells" 
                    Text="Eff. From (mm/dd/yyyy)"></asp:Label>
            </td>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_efffrom" runat="server" CssClass="textbox" Width="54px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalExt1" runat="server" TargetControlID="txt_efffrom">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 87px">
                <asp:Label ID="Label4" runat="server" CssClass="labelcells" 
                    Text="Process Stage Code" Width="140px"></asp:Label>
            </td>
            <td width="80">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_process_stage_code" runat="server" 
                            CssClass="combobox" Width="100px">
                        </asp:DropDownList>
                        <asp:TextBox ID="txt_process_stage_code" runat="server" CssClass="textbox" 
                            Width="70px" ToolTip="Type new process stage code here &amp; Press enter"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" CssClass="labelcells" Text="Desc."></asp:Label>
            </td>
            <td colspan="2" width="300">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_process_stage_desc" runat="server" Text="..." Width="300px" 
                            CssClass="labelcells"></asp:Label>
                        <asp:TextBox ID="txt_process_stage_desc" runat="server" CssClass="textbox" 
                            Width="300px" 
                            ToolTip="Type new process stage desc. here &amp; Press enter"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="Label10" runat="server" CssClass="labelcells" 
                    Text="Eff. To (mm/dd/yyyy)"></asp:Label>
            </td>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_effto" runat="server" CssClass="textbox" Width="54px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalExt2" runat="server" TargetControlID="txt_effto">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 87px">
                <asp:Label ID="Label11" runat="server" Text="Seq. No." CssClass="labelcells"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_seqno" runat="server" CssClass="textbox" Width="50px" 
                            ToolTip="Type process seq.no. here &amp; press enter"></asp:TextBox>
                        <asp:ImageButton ID="imb_newcode" runat="server" 
                            ImageUrl="~/Image/Expand.png" ToolTip="Create New Process" />
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" 
                            TargetControlID="txt_seqno" ValidChars="0123456789">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_top" runat="server" Height="12px" 
                            ImageUrl="~/Image/LeftArrow.png" ToolTip="Top Record" Width="16px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_next" runat="server" Height="12px" 
                            ImageUrl="~/Image/DNARROW.JPG" ToolTip="Next Record" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_previous" runat="server" Height="12px" 
                            ImageUrl="~/Image/UPARROW.JPG" ToolTip="Previous Record" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_last" runat="server" Height="12px" 
                            ImageUrl="~/Image/RightArrow.png" ToolTip="Last Record" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="10">
                <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" Height="150px" 
                    ScrollBars="Both">
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" />
                                        <asp:BoundField DataField="tran_no" HeaderText="Tran No." />
                                        <asp:BoundField DataField="location" HeaderText="Location" />
                                        <asp:BoundField DataField="process_location_code" 
                                            HeaderText="Process Location Code" />
                                        <asp:BoundField DataField="process_location_desc" 
                                            HeaderText="Process Location Desc." />
                                        <asp:BoundField DataField="process_stage_code" 
                                            HeaderText="Process Stage Code" />
                                        <asp:BoundField DataField="process_stage_desc" 
                                            HeaderText="Process Stage Desc." />
                                        <asp:BoundField DataField="seq_no" HeaderText="Seq.No." />
                                        <asp:BoundField DataField="eff_from" HeaderText="Eff. From (d/m/y)" />
                                        <asp:BoundField DataField="eff_to" HeaderText="Eff. To (d/m/y)" />
                                        <asp:BoundField DataField="status" HeaderText="Status" />
                                    </Columns>
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <HeaderStyle CssClass="GridHeader" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="height: 11px;" align="center" colspan="10">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lbt_view" runat="server" CssClass="buttonc">VIEW</asp:LinkButton>
                        <asp:LinkButton ID="lbt_add" runat="server" CssClass="buttonc">ADD</asp:LinkButton>
                        <asp:LinkButton ID="lbt_modify" runat="server" CssClass="buttonc">MODIFY</asp:LinkButton>
                        <asp:LinkButton ID="lbt_authorize" runat="server" CssClass="buttonc">AUTHORIZE</asp:LinkButton>
                        <asp:LinkButton ID="lbt_delete" runat="server" CssClass="buttonc">DELETE</asp:LinkButton>
                        <asp:LinkButton ID="lbt_close" runat="server" CssClass="buttonc" 
                            Visible="False">CLOSE</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
        </tr>
        <tr>
            <td style="width: 87px">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lbt_apply" runat="server" CssClass="buttonc" 
                            Visible="False">APPLY</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="7">
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                  <ContentTemplate>
                    <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                         FadeInDuration="2" FadeInSteps="2" FadeOutDuration="2" FadeOutSteps="2" Visible="true" />
                 </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

