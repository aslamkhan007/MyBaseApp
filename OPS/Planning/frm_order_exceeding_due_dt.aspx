<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="frm_order_exceeding_due_dt.aspx.vb" Inherits="frm_order_exceeding_due_dt"Title="Untitled Page" %>

<%@ Register namespace="CrystalDecisions.Web" tagprefix="CR" %>

<script runat="server">

   
</script>


<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="2" >
                Orders Exceeding Due Date </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 15%" >
                <asp:Label ID="label1" runat="server" CssClass="labelcells" Text="YearMonth"></asp:Label>
            </td>
            <td class="NormalText" style="width: 85%">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlyrmth" runat="server" AutoPostBack="True" 
                    CssClass="combobox" >
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 15%" >
                <asp:Label ID="label2" runat="server"  Text="Location"></asp:Label>
            </td>
            <td class="NormalText" style="width: 85%">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddllocation" runat="server" AutoPostBack="True" 
                    CssClass="combobox" >
                            <asp:ListItem>Cotton</asp:ListItem>
                            <asp:ListItem>Taffeta
                            </asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
        <table style="width:100%;">
        <tr>
            <td class="buttonbackbar" colspan="2" >
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="cmdFetch" runat="server" CssClass="buttonc"
                   >Fetch</asp:LinkButton>
                        <asp:LinkButton ID="cmdclose" runat="server" CssClass="buttonc"  
                            onclick="cmdclose_Click">Close</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
                 <asp:LinkButton ID="cmdexcel1" runat="server" CssClass="buttonc" >Excel</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="labelcells" colspan="2">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                    AssociatedUpdatePanelID="UpdatePanel5">
                    <ProgressTemplate>
                        Please wait...<asp:Image ID="ProgressBar" runat="server" ForeColor="#3333FF" 
                            ImageUrl="~/Image/loading.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="panelcells" colspan="2">
            <div  id = "AdjResultsDiv" 
                        style=" width: 100%; height:300px;"> 
                        
                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                        <ContentTemplate>
                                                             <asp:GridView ID="grdGrid1" runat="server" AllowPaging="True" Font-Bold="False" Width="100%" 
                                                                OnRowDataBound="grdgrid1_RowDataBound" PageSize="450">
                                                                <EmptyDataTemplate>
                                                                    No Record Freezed 
                                                                </EmptyDataTemplate>
                                                                <SelectedRowStyle CssClass="selectedrow" />
                                                                <HeaderStyle CssClass="GridHeader" />
                                                                <AlternatingRowStyle BackColor="#CCCCCC" BorderStyle="None" />
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                     </div> 
                <br />
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="2" >
            </td>
        </tr>
        </table>

</asp:Content>


