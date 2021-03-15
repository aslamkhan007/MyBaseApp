<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="frm_outstanding.aspx.vb" Inherits="frm_outstanding" Title="Untitled Page" %>

<%@ Register Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<script runat="server">

   
</script>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="2">
                Outstanding
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="label1" runat="server" CssClass="labelcells" Text="Team Name"></asp:Label>
            </td>
            <td class="textcells">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlteam" runat="server" AutoPostBack="True" CssClass="combobox"
                            Width="116px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="label2" runat="server" CssClass="labelcells" Text="Sales Person"></asp:Label>
            </td>
            <td class="textcells">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlsaleperson" runat="server" AutoPostBack="True" CssClass="combobox"
                            Width="71px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="style5" colspan="2" align="center">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="cmdFetch" runat="server" CssClass="buttonc" Height="22px" OnClick="cmdFetch_Click"
                            Width="84px">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="cmdclose" runat="server" CssClass="buttonc" Height="22px" OnClick="cmdclose_Click"
                            Width="84px">Close</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
                            <asp:LinkButton ID="cmdexcel1" runat="server" CssClass="buttonc" 
                            Width="84px" Height="22px">Excel</asp:LinkButton>
                
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="style5">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        Please wait...<asp:Image ID="ProgressBar" runat="server" ForeColor="#3333FF" Height="16px"
                            ImageUrl="~/Image/loading.gif" Width="54px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="grdGrid1" runat="server" Font-Bold="False" Font-Names="Tahoma"
                                Font-Size="8pt" HorizontalAlign="Left" AllowPaging="True" PageSize="30" 
                                Width="100%">
                                <EmptyDataTemplate>
                                    No Record Found
                                </EmptyDataTemplate>
                                <SelectedRowStyle CssClass="selectedrow" />
                                <HeaderStyle BorderStyle="None" CssClass="gridheader" ForeColor="White" />
                                <AlternatingRowStyle BorderStyle="None" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
