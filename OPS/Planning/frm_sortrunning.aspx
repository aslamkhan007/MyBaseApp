<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="frm_sortrunning.aspx.vb" Inherits="frm_sortrunning"Title="Untitled Page" %>

<%@ Register namespace="CrystalDecisions.Web" tagprefix="CR" %>

<script runat="server">

   
</script>


<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <table style="width:83%;">
        <tr>
            <td class="tableheader" colspan="2" >
                Actual Sort Running </td>
        </tr>
        <tr>
            <td style="width: 102px">
                <asp:Label ID="label1" runat="server" CssClass="labelcells" Text="YearMonth"></asp:Label>
            </td>
            <td style="width: 334px">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlyrmth" runat="server" AutoPostBack="True" 
                    CssClass="combobox" Height="18px" Width="116px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 102px">
                <asp:Label ID="label2" runat="server" CssClass="labelcells" Text="Shed"></asp:Label>
            </td>
            <td style="width: 334px">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlshed" runat="server" AutoPostBack="True" 
                    CssClass="combobox" Width="71px">
                            <asp:ListItem>Airjet</asp:ListItem>
                            <asp:ListItem>Rapier</asp:ListItem>
                            <asp:ListItem>Sulzer</asp:ListItem>
                            <asp:ListItem>Waterjet</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="style5" colspan="2" align="center">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="cmdFetch" runat="server" CssClass="buttonc" Height="22px" 
                     Width="84px">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="cmdclose" runat="server" CssClass="buttonc" Height="22px" 
                            onclick="cmdclose_Click" Width="84px">Close</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
                 <asp:LinkButton ID="cmdexcel1" runat="server" CssClass="buttonc" Width="84px">Excel</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style5" colspan="2">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                    AssociatedUpdatePanelID="UpdatePanel5">
                    <ProgressTemplate>
                        Please wait...<asp:Image ID="ProgressBar" runat="server" ForeColor="#3333FF" 
                            Height="16px" ImageUrl="~/Image/loading.gif" Width="79px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="style5" colspan="2">
            <div  id = "AdjResultsDiv" 
                        style=" width: 100%; height:300px; top: 0px;"> 
                        
                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grdGrid1" runat="server" AllowPaging="True" Font-Bold="False" 
                                                                Font-Names="Tahoma" Font-Size="8pt" Height="100%" HorizontalAlign="Left" 
                                                                OnRowDataBound="grdgrid1_RowDataBound" PageSize="450" Width="23%">
                                                                <EmptyDataTemplate>
                                                                    No Record Found
                                                                </EmptyDataTemplate>
                                                                <SelectedRowStyle CssClass="selectedrow" />
                                                                <HeaderStyle BorderStyle="None" CssClass="gridheader" ForeColor="White" />
                                                                <AlternatingRowStyle BackColor="#CCCCCC" BorderStyle="None" />
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                     </div> 
                <br />
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="2" align="left">
            </td>
        </tr>
        </table>

</asp:Content>


