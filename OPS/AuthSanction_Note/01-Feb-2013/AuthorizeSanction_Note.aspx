﻿<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
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
    <table style="width: 100%;">
        <tr>
            <td style="font-size: 10pt; font-weight: bold" class="labelcells_s">
                Summary of Pending Sanction Notes...(Click to See Detail)
            </td>
        </tr>
        <tr>
            <td>
                <%--<td style="background-color: #B2B2B2; vertical-align: top; text-align: center; font-weight: bold;
                                                font-size: 10pt; text-transform: capitalize; color: Blue; font-family: 'Trebuchet MS' , Tahoma;
                                                ">
                                                <asp:Label ID="Label19" runat="server" Text='<%# Eval("AreaName") %>'></asp:Label>
                                            </td>--%>
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
            <td>
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
                        <asp:AsyncPostBackTrigger ControlID="CmdAuthorize" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td>
                <asp:Label ID="lblDetail0" runat="server" Text="Authorization History" 
                    Font-Bold="True" Font-Size="10pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GrdAuthHistory" runat="server" 
    Width="100%" EnableModelValidation="True"
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
                                <asp:AsyncPostBackTrigger ControlID="GridView1" 
                                    EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="DataList1" EventName="ItemCommand" />
                                <asp:AsyncPostBackTrigger ControlID="CmdAuthorize" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
            </td>
        </tr>
        </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td colspan="4" class="lebelcells_s">
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
                        <asp:AsyncPostBackTrigger ControlID="DataList1" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="CmdAuthorize" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Panel ID="Panel1" runat="server" CssClass="PanelBack">
                    <table style="width:100%;">
                        <tr>
                            <td width="200">
                                Action</td>
                            <td>
                                <asp:DropDownList ID="ddlAction" runat="server" CssClass="combobox">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Authorize</asp:ListItem>
                                    <asp:ListItem>Cancel</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="ddlAction" Display="Dynamic" ErrorMessage="*" 
                                    SetFocusOnError="True" ValidationGroup="GrpApply"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td width="200">
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
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                  <asp:Panel ID="Panel2" runat="server" Visible="False">
                <table class="tableback" style="width:100%;">
                    <tr>
                        <td colspan="3" 
                            style="font-family: Calibri; font-size: medium; font-style: oblique; font-weight: 100">
                            Logistics</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblTransport" runat="server" Text="Final Mode of Transport"></asp:Label>
                        </td>
                        <td>
                            
                                    <asp:DropDownList ID="ddlFinalMode" runat="server" CssClass="combobox">
                                    </asp:DropDownList>
                               
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblFreightVal" runat="server" Text="Final Freight Value"></asp:Label>
                        </td>
                        <td>
                          
                                    <asp:TextBox ID="txtFinalFreightVal" runat="server" CssClass="textbox"></asp:TextBox>
                                
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;<asp:Label ID="Label1" runat="server" Text="Coments For SalePerson"></asp:Label>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtComentForSaleP" runat="server" CssClass="textbox" 
                                        MaxLength="200" Width="250px"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                </asp:Panel>
                </ContentTemplate>
                </asp:UpdatePanel>
              
                
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="CmdAuthorize" runat="server" CssClass="buttonc" 
                    BorderStyle="None" ValidationGroup="GrpApply">Apply</asp:LinkButton>
                &nbsp;<asp:LinkButton ID="CmdCancel" runat="server" CssClass="buttonc">Clear</asp:LinkButton>
            &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
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
