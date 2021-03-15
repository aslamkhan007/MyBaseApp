<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="AuthorizeSanction_Note.aspx.vb" Inherits="OPS_AuthorizeSanction_Note" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader">
                Authorize Sanction Note
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td style="font-size: 10pt; font-weight: bold">
                Summary of Pending Sanction Notes...(Click to See Detail)
            </td>
        </tr>
        <tr>
            <td>
                <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>--%>
                <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource2" RepeatDirection="Horizontal"
                    ToolTip="Click any Area to see the detials of it." Width="100%">
                    <ItemTemplate>
                        <table cellpadding="1" cellspacing="0" style="width: 100%;">
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" style="width: 100%;">
                                        <tr>
                                            <td align="center" class="HighlightBox">
                                                <asp:Label ID="lblCount" runat="server" Text='<%# Eval("Count") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <%--<td style="background-color: #B2B2B2; vertical-align: top; text-align: center; font-weight: bold;
                                                font-size: 10pt; text-transform: capitalize; color: Blue; font-family: 'Trebuchet MS' , Tahoma;
                                                ">
                                                <asp:Label ID="Label19" runat="server" Text='<%# Eval("AreaName") %>'></asp:Label>
                                            </td>--%>
                                            <td align="center" class="GridRowRed">
                                                <asp:LinkButton ID="cmdArea" runat="server" CommandName="Select" ForeColor="White"
                                                    Text='<%# Eval("AreaName") %>'></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
              <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                    SelectCommand="Jct_Ops_Pending_Authorization_Count_Fetch" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter Name="UserCode" SessionField="Empcode" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" EnableModelValidation="True"
                            Width="100%">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <HeaderStyle CssClass="GridHeader" />
                            <RowStyle CssClass="GridItem" />
                            <SelectedRowStyle CssClass="GridRowGreen" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DataList1" EventName="ItemCommand" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblDetail" runat="server" Text="Detail" Font-Bold="True" Font-Size="10pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="GrdSanctionNoteDetail" runat="server" Width="100%" EnableModelValidation="True"
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
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                Remarks (if Any)
            </td>
            <td>
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="CmdAuthorize" runat="server" CssClass="buttonc">Authorize</asp:LinkButton>
                &nbsp;<asp:LinkButton ID="CmdCancel" runat="server" CssClass="buttonc">Cancel</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
