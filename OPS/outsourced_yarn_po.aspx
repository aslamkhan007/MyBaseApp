<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="outsourced_yarn_po.aspx.cs" Inherits="OPS_outsourced_yarn_po" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                PO Marking</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 110px">

                &nbsp;</td>
            <td class="NormalText" colspan="3">
                <asp:RadioButtonList ID="rdlist" runat="server" 
                    onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                    RepeatDirection="Horizontal" AutoPostBack="True" Visible="False">
                    <asp:ListItem Selected="True">PO Allocation-Yarn</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td style="width: 110px">

                <asp:Label ID="lbefffrm" runat="server" CssClass="NormalText" 
                    Text="EffectiveFrom" Visible="False"></asp:Label>
              </td>
            <td style="width: 228px">
                <asp:TextBox ID="txtefffrm" runat="server" CssClass="textbox" Visible="False"></asp:TextBox>
                <cc1:CalendarExtender ID="txtefffrm_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtefffrm">
                </cc1:CalendarExtender>
            </td>
            <td class="BoundColumn_Date">
                <asp:Label ID="lbeffto" runat="server" CssClass="NormalText" Text="EffectiveTo" 
                    Visible="False"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txteffto" runat="server" CssClass="textbox" Visible="False"></asp:TextBox>
                <cc1:CalendarExtender ID="txteffto_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txteffto">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr runat="server" id="buttonbackbar">
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" 
                    onclick="lnkfetch_Click" Visible="False">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkclose" runat="server" CssClass="buttonc" Visible="False" 
                    onclick="lnkclose_Click">Close</asp:LinkButton>
            </td>
        </tr>
        </table>
    <table class="mytable">
        <tr>
            <td>

                <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="800px">
                    <asp:GridView ID="grdDetail" runat="server" EnableModelValidation="True" 
                    Visible="False" Width="100%" 
    AllowPaging="True" onpageindexchanging="grdDetail_PageIndexChanging">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chbSelectAll" OnCheckedChanged="chbSelectAll_CheckedChanged" 
                                        AutoPostBack="true" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chbSelect" runat="server" 
                                        oncheckedchanged="chbSelect_CheckedChanged" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PoNo">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtpo" runat="server" CssClass="textbox"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>

                </td>
        </tr>
         </table>
    <table class="mytable">
        <tr>
            <td>
                <asp:GridView ID="grdGrid1" runat="server"
                                     Width="100%" PageSize="5" 
                                     Style="margin-top: 9px" ShowFooter="True" 
                    EnableModelValidation="True" Visible="False">
                                <RowStyle CssClass="GridItem" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Location ">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddllocation" runat="server" Font-Size="Smaller">
                                                <asp:ListItem>Cotton</asp:ListItem>
                                                <asp:ListItem>Taffeta</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DocuRcvd">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddldocument" runat="server" Font-Size="Smaller">
                                                <asp:ListItem>N</asp:ListItem>
                                                <asp:ListItem>Y</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="QtyRcvd">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtqtyrcvd" runat="server" Width="85px"></asp:TextBox>
                                            <%--<cc1:FilteredTextBoxExtender ID="txtqtyrcvd_FilteredTextBoxExtender" 
                                                runat="server" TargetControlID="txtqtyrcvd" ValidChars="0123456789.">
                                            </cc1:FilteredTextBoxExtender>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ChallanNo">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtchallanno" runat="server" CssClass="titletext"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ChallanDate">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtchallandt" runat="server"></asp:TextBox>
                                            <cc1:CalendarExtender ID="txtchallandt_CalendarExtender" runat="server" 
                                                Enabled="True" TargetControlID="txtchallandt">
                                            </cc1:CalendarExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                   
                                </EmptyDataTemplate>
                                <SelectedRowStyle CssClass="selectedrow" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GridAI" />
                            </asp:GridView>
              </td>
        </tr>
          <tr runat="server" id="buttonbackbar2">
            <td class="buttonbackbar">

                <asp:LinkButton ID="lnksave" runat="server" onclick="lnksave_Click" 
                    CssClass="buttonc" Visible="False">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkclr" runat="server" onclick="lnkclr_Click" 
                    CssClass="buttonc" Visible="False">Clear</asp:LinkButton>

                </td>
        </tr>
    </table>
</asp:Content>

