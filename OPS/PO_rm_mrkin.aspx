<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="PO_rm_mrkin.aspx.cs" Inherits="OPS_PO_rm_mrkin" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="tableheader">
                PO Marking</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:RadioButtonList ID="rdlst" runat="server" 
                    onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                    RepeatDirection="Horizontal" AutoPostBack="True" Visible="False">
                    <asp:ListItem Selected="True">Req Without PO</asp:ListItem>
                  <%--  <asp:ListItem Enabled="False">Mkt Approvals</asp:ListItem>--%>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table __designer:mapid="9e" style="width:100%;">
                    <tr __designer:mapid="b4">
                        <td __designer:mapid="b5">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="900px" Height="200px">
                    <asp:GridView ID="grdDetail3" runat="server" EnableModelValidation="True" 
                        onrowdatabound="grdDetail_RowDataBound">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <Columns>
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PurchaseRate/mtr">
                                <ItemTemplate>
                                    <asp:TextBox ID="Purchase" runat="server" CssClass="textbox" 
                                        Text='<%# Eval("Rate per mtr") %>' Width="60px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FinishSalePrice">
                                <ItemTemplate>
                                    <asp:TextBox ID="saleprice" runat="server" CssClass="textbox" 
                                        Text='<%# Eval("FinishSalePrice") %>' Width="60px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PO no.">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtpo" runat="server" CssClass="textbox" Enabled="False" 
                                        Text='<%# Eval("po") %>' Width="60px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                    </asp:GridView>
                    <br />
                </asp:Panel>
                        </td>
                    </tr>
                    <tr __designer:mapid="b6">
                        <td __designer:mapid="b7">
                            <asp:Label ID="lnkwrdrb" runat="server" CssClass="tableheader" 
                                Text="WardRobe Items"></asp:Label>
                        </td>
                    </tr>
                    <tr __designer:mapid="a3">
                        <td __designer:mapid="a4">
                            <asp:Panel ID="Panel2" runat="server" ScrollBars="Both" Width="900px" 
                                Height="200px">
                                <asp:GridView ID="grdDetail2" runat="server" 
                                        onrowdatabound="grdDetail2_RowDataBound1">
                                    <AlternatingRowStyle CssClass="GridAI" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ReqMtrs">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtsale" runat="server" 
                                                    CssClass="textbox" Text='<%# Eval("sale_per_mts") %>'  ></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rate/Mtrs">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtrate" runat="server" 
                    CssClass="textbox" Text='<%# Eval("rateper_mts") %>'    ></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="   Supplier            ">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtsupplr" runat="server" 
                    CssClass="textbox" Text='<%# Eval("supplier") %>'   ></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PO no">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtwdrbPO" runat="server" CssClass="textbox" Enabled="False"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BorderStyle="None" CssClass="GridHeader" />
                                    <PagerStyle CssClass="PageStyle" />
                                    <RowStyle CssClass="GridItem" />
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr __designer:mapid="a7">
                        <td __designer:mapid="a8">
                            &nbsp;</td>
                    </tr>
                    <tr __designer:mapid="a7">
                        <td __designer:mapid="a8">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" 
                    onclick="lnksave_Click">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkclr" runat="server" CssClass="buttonc" 
                    onclick="lnkclr_Click">Clear</asp:LinkButton>
                <asp:LinkButton ID="lnkaccept" runat="server" CssClass="buttonc" 
                    onclick="lnkaccept_Click" Visible="False">Approve</asp:LinkButton>
                    <cc1:ConfirmButtonExtender ID="lnkaccept_ConfirmButtonExtender" runat="server" 
                    TargetControlID="lnkaccept" ConfirmText="Are You Sure ?">
                </cc1:ConfirmButtonExtender>
                <asp:LinkButton ID="lnkreject" runat="server" CssClass="buttonc" 
                    onclick="lnkreject_Click" Visible="False">Reject</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkapply" runat="server" CssClass="buttonc" 
                    onclick="lnkapply_Click" Visible="False">Apply</asp:LinkButton>
                <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" 
                    onclick="lnkfetch_Click" Visible="False">Fetch</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>

