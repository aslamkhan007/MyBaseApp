<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="frm_loom_bookingvsactual.aspx.vb" Inherits="frm_loom_bookingvsactual"Title="Untitled Page" %>

<%@ Register namespace="CrystalDecisions.Web" tagprefix="CR" %>

<script runat="server">

   
</script>


<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <table style="width:83%;">
        <tr>
            <td class="tableheader" colspan="2" >
                Loom Booking V/S Running Sort</td>
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
            <td style="width: 102px">
                <asp:Label ID="label3" runat="server" CssClass="labelcells" Text="Plan Rev.No"></asp:Label>
            </td>
            <td style="width: 334px">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlplnrevno" runat="server" CssClass="combobox" 
                            Height="18px" Width="52px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Panel ID="Panel1" runat="server" Font-Bold="False" Font-Names="Tahoma" 
                    Font-Size="8pt" ForeColor="Blue" Height="80px" Width="581px">
                    <br />
                    Pl. note&nbsp; :-
                    <br />
                    <br />
                    &nbsp; *&nbsp; This screen will shows the report Loom Booking ( Generate in Loom Available 
                    Report Under Tag Reports )&nbsp; V/S&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Actual sort running in concerned shed in plant. &nbsp;
                </asp:Panel>
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
                Sort not covered in Looms Booking
            </td>
        </tr>
        <tr>
            <td class="style5" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdGrid2" runat="server" 
    AllowPaging="True" Font-Bold="False" Font-Names="Tahoma" Font-Size="8pt" 
    Height="100%" HorizontalAlign="Left" PageSize="15" Width="100%">
                            <AlternatingRowStyle BackColor="Silver" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>

</asp:Content>


