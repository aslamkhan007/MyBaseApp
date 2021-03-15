<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="ReInvoicing_Stock_Authorization.aspx.vb" Inherits="OPS_ReInvoicing_Stock_Authorization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Authorize ReInvoicing Requests</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Panel ID="Panel1" runat="server" Height="150px" Width="95%" 
                    ScrollBars="Both">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GrdRequestDEtails" runat="server" 
                                AutoGenerateSelectButton="True" EnableModelValidation="True" 
                                Width="100%" DataSourceID="SQlDS_BAsicDEtail">
                                <SelectedRowStyle CssClass="GridRowGreen" />
                                 <RowStyle CssClass="GridItem" />
                                <EmptyDataTemplate>
                                    No Bales Packed for&nbsp; Source Order..
                                </EmptyDataTemplate>
                                <HeaderStyle CssClass="GridHeader" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SQlDS_BAsicDEtail" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                                SelectCommand="Jct_Ops_ReInvoicing_Fetch_BasicDEtail" 
                                SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:SessionParameter Name="UserCode" SessionField="Empcode" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:GridView ID="GrdBasicDetail" runat="server" Width="99%">
                                            <PagerStyle CssClass="PagerStyle" />
                                            <AlternatingRowStyle CssClass="GridAI" />
                                            <EmptyDataTemplate>
                                                No Data Found...! ! !
                                            </EmptyDataTemplate>
                                            <HeaderStyle CssClass="GridHeader" />
                                            <RowStyle CssClass="GridItem" />
                                            <SelectedRowStyle CssClass="GridRowGreen" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="GrdRequestDEtails" 
                                            EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblDetail0" runat="server" Text="Authorization History" Font-Bold="True"
                    Font-Size="10pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="GrdAuthHistory" runat="server" Width="100%" EnableModelValidation="True"
                            AutoGenerateColumns="true">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <EmptyDataTemplate>
                                Not Data Found... ! ! !
                            </EmptyDataTemplate>
                            <HeaderStyle CssClass="GridHeader" />
                            <RowStyle CssClass="GridItem" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="CmdAuthorize" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="GrdRequestDEtails" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Action</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlAction" runat="server" CssClass="combobox">
                            <asp:ListItem>Authorize</asp:ListItem>
                            <asp:ListItem>Cancel</asp:ListItem>
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
            <td>
                Remarks (if Any)
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" 
    Width="250px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="CmdAuthorize" runat="server" BorderStyle="None" 
                            CssClass="buttonc">Apply</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
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

