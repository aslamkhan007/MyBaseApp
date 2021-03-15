<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="frm_weaving_looms.aspx.vb" Inherits="frm_weaving_looms"Title="Untitled Page" %>

<%@ Register namespace="CrystalDecisions.Web" tagprefix="CR" %>

<script runat="server">

   
</script>


<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="2" >
                Weaving Looms&nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 102px">
                <asp:Label ID="label2" runat="server" CssClass="labelcells" Text="Shed"></asp:Label>
            </td>
            <td style="width: 480px">
                <asp:DropDownList ID="ddlshed" runat="server" AutoPostBack="True" 
                    CssClass="combobox" Width="76px">
                    <asp:ListItem>Airjet</asp:ListItem>
                    <asp:ListItem>Development</asp:ListItem>
                    <asp:ListItem>Rapier</asp:ListItem>
                    <asp:ListItem>Sulzer</asp:ListItem>
                    <asp:ListItem>Waterjet</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style5" colspan="2" align="center">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="cmdFetch" runat="server" CssClass="buttonc" Height="22px" 
                    onclick="cmdFetch_Click" Width="84px">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="cmdclose" runat="server" CssClass="buttonc" Height="22px" 
                            onclick="cmdclose_Click" Width="84px">Close</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="style5" colspan="2">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        Please wait...<asp:Image ID="ProgressBar" runat="server" ForeColor="#3333FF" 
                            Height="16px" ImageUrl="~/Image/loading.gif" Width="54px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="style5" colspan="2">
                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grdGrid1" runat="server" 
                                                        Font-Bold="False" Font-Names="Tahoma" 
                    Font-Size="8pt" Height="8%" 
                                                        HorizontalAlign="Left" Width="30%" 
                                                        AllowPaging="True" PageSize="200" style="margin-right: 0px">
                                                                <EmptyDataTemplate>
                                                                    No Record Found
                                                                </EmptyDataTemplate>
                                                                <SelectedRowStyle CssClass="selectedrow" />
                                                                <HeaderStyle BorderStyle="None" CssClass="gridheader" ForeColor="White" />
                                                                <AlternatingRowStyle BorderStyle="None" />
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                <br />
            </td>
        </tr>
    </table>

</asp:Content>


