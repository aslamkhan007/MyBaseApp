<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="norm_master.aspx.vb" Inherits="ProductionPlanning_norm_master" title="Untitled Page" %>
<%@ Register Src="~/FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 95%; height: 329px;">
        <tr>
            <td class="tableheader" colspan="2" style="height: 30px">
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Text="Norm Master"></asp:Label>
            </td>
            <td style="height: 30px; width: 85px">
            </td>
            <td style="height: 30px; width: 196px;">
                </td>
            <td style="height: 30px; width: 102px">
                </td>
            <td style="height: 30px; width: 253px">
                </td>
        </tr>
        <tr>
            <td style="width: 16px" class="labelcells">
                <asp:Label ID="Label2" runat="server" CssClass="labelcells" Text="Action" 
                    Visible="False"></asp:Label>
            </td>
            <td class="textcells">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_action" runat="server" CssClass="combobox" 
                            Visible="False" AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 85px">
            </td>
            <td style="width: 196px;">
                </td>
            <td style="width: 102px">
                </td>
            <td style="width: 253px">
                </td>
        </tr>
        <tr>
            <td style="width: 16px; height: 17px;" class="labelcells">
                <asp:Label ID="Label8" runat="server" CssClass="labelcells" Text="Norm Catg." 
                    Width="80px"></asp:Label>
            </td>
            <td class="textcells" style="height: 17px">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_normcatg" runat="server" CssClass="combobox" 
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 85px; height: 17px;" class="labelcells">
                <asp:Label ID="Label6" runat="server" CssClass="labelcells" 
                    Text="Effective From"></asp:Label>
            </td>
            <td class="textcells" style="width: 196px; height: 17px;">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_effdate" runat="server" CssClass="textbox" Width="55px" 
                            AutoPostBack="True"></asp:TextBox>
                        <cc1:CalendarExtender ID="CE1" runat="server" TargetControlID="txt_effdate" 
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td rowspan="4" class="labelcells" style="width: 102px">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:ListBox ID="ListBox1" runat="server" Height="127px" Width="155px" 
                            CssClass="textbox" ForeColor="#990000" AutoPostBack="True">
                        </asp:ListBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td rowspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 16px; " class="labelcells">
                <asp:Label ID="Label3" runat="server" CssClass="labelcells" Text="Team Code" 
                    Width="80px"></asp:Label>
            </td>
            <td class="textcells">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_catgcode" runat="server" CssClass="combobox" 
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 85px; " class="labelcells">
                <asp:Label ID="Label7" runat="server" CssClass="labelcells" Text="Effective Upto" 
                    Width="80px"></asp:Label>
            </td>
            <td class="textcells" style="width: 196px; ">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_expdate" runat="server" CssClass="textbox" Width="55px" 
                            AutoPostBack="True"></asp:TextBox>
                        <cc1:CalendarExtender ID="CE2" runat="server" TargetControlID="txt_expdate" 
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 16px; height: 8px;" class="labelcells">
                <asp:Label ID="Label4" runat="server" CssClass="labelcells" Text="U.O.M."></asp:Label>
            </td>
            <td class="textcells" style="height: 8px">
                
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_uom" runat="server" CssClass="combobox" 
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
            </td>
            <td style="width: 85px; height: 8px;" class="labelcells">
            </td>
            <td class="textcells" style="width: 196px; height: 8px;">
            </td>
        </tr>
        <tr>
            <td style="width: 16px; height: 10px;" class="labelcells">
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="Label5" runat="server" CssClass="labelcells" Text="Norm Value" 
                    Width="80px"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 10px;" class="textcells">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_normvalue" runat="server" CssClass="textbox" Width="80px" 
                            AutoPostBack="True"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBE1" runat="server" 
                            TargetControlID="txt_normvalue" ValidChars="0123456789.">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 85px; height: 10px;" class="labelcells">
                &nbsp;</td>
            
            <td style="width: 196px; height: 10px;">
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Panel ID="Panel1" runat="server" Height="160px" 
                    Width="680px" Font-Bold="False" BorderStyle="Solid">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" Font-Names="Tahoma" Font-Size="8pt" 
                                OnRowDataBound="GridView1_RowDataBound" PageSize="5" Width="100%">
                                <EmptyDataTemplate>
                                    Records not Available
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="Selection">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" CssClass="labelcells" />
                                            <asp:LinkButton ID="Lnk_Select" runat="server" CommandName="Select" 
                                                onclick="Lnk_Select_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="catg" HeaderText="Category" />
                                    <asp:BoundField DataField="catgcode" HeaderText="Catg. Code" />
                                    <asp:BoundField DataField="uom" HeaderText="U.O.M." />
                                    <asp:BoundField DataField="normvalue" HeaderText="Norm Value" />
                                    <asp:BoundField DataField="effdate" HeaderText="Eff. Date" />
                                    <asp:BoundField DataField="expdate" HeaderText="Exp. Date" />
                                    <asp:BoundField DataField="active" HeaderText="Active" />
                                    <asp:BoundField DataField="company" HeaderText="Company" />
                                </Columns>
                                <HeaderStyle CssClass="gridheader" ForeColor="White" />
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                </asp:Panel>
            </td>
            <td style="width: 253px">
            </td>
        </tr>
        <tr>
            <td style="height: 8px" colspan="5" class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnk_view" runat="server" CssClass="buttonc" Visible="False">VIEW</asp:LinkButton>
                        <asp:LinkButton ID="lnk_add" runat="server" CssClass="buttonc">ADD</asp:LinkButton>
                        <asp:LinkButton ID="lnk_modify" runat="server" CssClass="buttonc">MODIFY</asp:LinkButton>
                        <asp:LinkButton ID="lnk_close" runat="server" CssClass="buttonc">DELETE</asp:LinkButton>
                        <asp:LinkButton ID="lnk_authorize" runat="server" CssClass="buttonc" 
                            Visible="False">AUTHORIZE</asp:LinkButton>
                        <asp:LinkButton ID="lnk_exit" runat="server" CssClass="buttonc">CLOSE</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 253px; height: 8px">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                 <ContentTemplate>
                     <asp:LinkButton ID="lnk_apply" runat="server" CssClass="buttonc" 
                         style="height: 22px" Visible="False">Apply</asp:LinkButton>
                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                   <ContentTemplate>
                    <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                         FadeInDuration="2" FadeInSteps="2" FadeOutDuration="2" FadeOutSteps="2" Visible="true" />
                 </ContentTemplate>
                </asp:UpdatePanel>
              </td>
            <td style="width: 102px">
                &nbsp;</td>
            <td style="width: 253px">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        
                                <asp:Panel ID="Panel2" runat="server" CssClass="labelcells" ForeColor="#CC0000">
                                    Catg. already exists, do you want to create catg. with new parameters ?<asp:RadioButton 
                                        ID="rbt_yes" runat="server" Text="Yes" AutoPostBack="True" 
                                        CssClass="textbox" ForeColor="#CC0000" />
                                    <asp:RadioButton ID="rbt_no" runat="server" Text="No" AutoPostBack="True" 
                                        CssClass="textbox" ForeColor="#CC0000" />
                                </asp:Panel>
                                              </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 253px">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

