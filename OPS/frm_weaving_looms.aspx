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
            <td class="labelcells" style="width:15%;">
                <asp:Label ID="label2" runat="server"  Text="Shed"></asp:Label>
            </td>
            <td class="labelcells" style="width:85%;">
                <asp:DropDownList ID="ddlshed" runat="server" AutoPostBack="True" 
                    CssClass="combobox">
                    <asp:ListItem>Airjet</asp:ListItem>
                    <asp:ListItem>Development</asp:ListItem>
                    <asp:ListItem>Rapier</asp:ListItem>
                    <asp:ListItem>Sulzer</asp:ListItem>
                    <asp:ListItem>Waterjet</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="buttonbackbar" >
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
            <td class="labelcells">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        Please wait...<asp:Image ID="ProgressBar" runat="server" ForeColor="#3333FF" 
                         ImageUrl="~/Image/loading.gif"  />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grdGrid1" runat="server" 
                                                        Font-Bold="False" Width="100%" 
                                                        AllowPaging="True" PageSize="20" style="margin-right: 0px" CssClass="GridView">
                                                                <EmptyDataTemplate>
                                                                    No Record Found
                                                                </EmptyDataTemplate>
                                                                <PagerStyle CssClass="PagerStyle" />
                                                                <RowStyle CssClass="RowStyle" />
                                                                <SelectedRowStyle CssClass="selectedrow" />
                                                                <HeaderStyle CssClass="HeaderStyle" />
                                                                <AlternatingRowStyle BorderStyle="None" />
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                <br />
            </td>
        </tr>
    </table>

</asp:Content>


