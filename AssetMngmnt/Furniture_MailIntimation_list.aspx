<%@ Page Title="" Language="C#" MasterPageFile="~/AssetMngmnt/MasterPage.master"
    AutoEventWireup="true" CodeFile="Furniture_MailIntimation_list.aspx.cs" Inherits="AssetMngmnt_Furniture_MailIntimation_list" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader">
                Furniture Mail Intimation :
            </td>
        </tr>
    </table>
    <%--                        <asp:HyperLinkField HeaderText="Preview"  Text="Preview"  DataNavigateUrlFields="RequestID" 
                                      DataNavigateUrlFormatString="asset_item_print.aspx?requestid={0}"
                                        DataTextField="RequestID" DataTextFormatString="Preview" Target="_blank" /> --%>
    <table class="NormalText">
        <tr>
            <td class="NormalText">
                <asp:Label ID="Label27" runat="server" Text="Email Pending List:"></asp:Label>
            </td>
        </tr>
    </table>
    <table class="NormalText">
        <tr>
            <td class="NormalText">
                <asp:Label ID="Label2" runat="server" Text="Email Id Availibility"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlFilter" runat="server" CssClass="combobox" OnSelectedIndexChanged="ddlFilter_SelectedIndexChanged"
                    AutoPostBack="True">
                    <asp:ListItem Value="WithMail">WithMail</asp:ListItem>
                    <asp:ListItem Value="WithOutMail">WithOut Mail</asp:ListItem>
                    <asp:ListItem Selected="True" Value="All"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="LblLocation" runat="server" Text="Location"></asp:Label>
            </td>
            <td>
                <%--             <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>--%>
                <div id="divwidth" style="display: none;">
                </div>
                <asp:DropDownList ID="ddlloc" runat="server" CssClass="combobox" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlloc_SelectedIndexChanged">
                </asp:DropDownList>
                <%--                    </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
            <td>
                <asp:Label ID="lblSublocation" runat="server" Text="Sublocation"></asp:Label>
            </td>
            <td>
                <%--           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                <div id="div1" style="display: none;">
                </div>
                <asp:DropDownList ID="ddlsublocation" runat="server" CssClass="combobox" OnSelectedIndexChanged="ddlsublocation_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:DropDownList>
                <%--          </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlgrid" Width="1000px" runat="server" Height="200px" ScrollBars="Horizontal">
        <asp:GridView ID="grdDetail" runat="server" Width="100%" EmptyDataText="No Record Found ..."
            EnableModelValidation="True" DataKeyNames="requestid" OnRowDataBound="grdDetail_RowDataBound"
            OnRowCommand="grdDetail_RowCommand" OnSelectedIndexChanged="grdDetail_SelectedIndexChanged"
            AutoGenerateColumns="True">
            <AlternatingRowStyle CssClass="GridAI" />
            <SelectedRowStyle CssClass="SelectedRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <RowStyle CssClass="GridItem" />
            <Columns>
                <asp:TemplateField HeaderText="E-mail">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkemail" runat="server" BorderStyle="None" CommandName="Sendmail"
                            CssClass="emailicon" Height="16px" Width="16px"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--                        <asp:HyperLinkField HeaderText="Preview"  Text="Preview"  DataNavigateUrlFields="RequestID" 
                                      DataNavigateUrlFormatString="asset_item_print.aspx?requestid={0}"
                                        DataTextField="RequestID" DataTextFormatString="Preview" Target="_blank" /> --%>
                <asp:TemplateField HeaderText="Confirm">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkConfirm" runat="server" CommandName="lnkConfirm">Confirm</asp:LinkButton>
                        <%--<cc1:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server" ConfirmText="Are you sure ?" TargetControlID="lnkDelete">
                                      </cc1:ConfirmButtonExtender>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ByPassMail">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkByPass" runat="server" CommandName="lnkByPass">ByPass Mail</asp:LinkButton>
                        <%--<cc1:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server" ConfirmText="Are you sure ?" TargetControlID="lnkDelete">
                                      </cc1:ConfirmButtonExtender>--%>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Check">
                    <HeaderTemplate>
                        <asp:CheckBox ID="ChkOrderSelAll" runat="server" AutoPostBack="True" OnCheckedChanged="ChkOrderSelAll_CheckedChanged" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="chkCheck" />
                    </ItemTemplate>
                </asp:TemplateField>


            </Columns>
        </asp:GridView>
    </asp:Panel>
    <table class="mytable">
        <tr>
            <td class="buttonbackbar">
                <asp:LinkButton ID="lnkEmailAll" runat="server" CssClass="buttonc" OnClick="lnkEmailAll_Click">Email All</asp:LinkButton>
                <asp:LinkButton ID="lnkConfirmAll" runat="server" CssClass="buttonc" OnClick="lnkConfirmAll_Click">Confirm All</asp:LinkButton>
                <asp:LinkButton ID="lnkByPassAll" runat="server" CssClass="buttonc" OnClick="lnkByPassAll_Click">ByPass All</asp:LinkButton>
                <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" OnClick="lnkReset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
    </table>
    <table class="mytable">
        <tr>
            <td class="NormalText">
                <asp:Label ID="Label1" runat="server" Text="Mail Sent List:"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" Width="1000px" runat="server" Height="200px" ScrollBars="Horizontal">
        <asp:GridView ID="GridView1" runat="server" Width="100%" EmptyDataText="No Record Found ..."
            EnableModelValidation="True">
            <AlternatingRowStyle CssClass="GridAI" />
            <SelectedRowStyle CssClass="SelectedRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <RowStyle CssClass="GridItem" />
        </asp:GridView>
    </asp:Panel>
</asp:Content>
