<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="frm_pending_orders.aspx.vb" Inherits="frm_pending_orders"Title="Untitled Page" %>

<%@ Register namespace="CrystalDecisions.Web" tagprefix="CR" %>

<script runat="server">

   
</script>


<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="2">
                Pending Orders
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 15%">
                <asp:Label ID="label1" runat="server" CssClass="labelcells" Text="Team Name"></asp:Label>
            </td>
            <td class="labelcells" style="width: 85%">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlteam" runat="server" AutoPostBack="True" 
                    CssClass="combobox" >
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 15%">
                <asp:Label ID="label2" runat="server" CssClass="labelcells" Text="Sales Person"></asp:Label>
            </td>
            <td class="labelcells" style="width: 85%">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlsaleperson" runat="server" AutoPostBack="True" 
                    CssClass="combobox" >
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 15%">
                <asp:Label ID="label3" runat="server" CssClass="labelcells" Text="Category"></asp:Label>
            </td>
            <td class="labelcells" style="width: 85%">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlcatg" runat="server" 
    AutoPostBack="True" CssClass="combobox" >
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 15%">
                <asp:Label ID="label4" runat="server" CssClass="labelcells" Text="Customer"></asp:Label>
            </td>
            <td class="labelcells" style="width: 85%">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlcustomer" runat="server" 
    AutoPostBack="True" CssClass="combobox" >
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
        <table style="width:100%">
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="cmdFetch" runat="server" CssClass="buttonc" 
                    onclick="cmdFetch_Click" >Fetch</asp:LinkButton>
                        <asp:LinkButton ID="cmdclose" runat="server" CssClass="buttonc" 
                            onclick="cmdclose_Click" >Close</asp:LinkButton>
                        
                    </ContentTemplate>
                    
                </asp:UpdatePanel>
                <asp:LinkButton ID="cmdexcel1" runat="server" CssClass="buttonc" >Excel</asp:LinkButton>
            </td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="labelcells">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        Please wait...<asp:Image ID="ProgressBar" runat="server" ForeColor="#3333FF" ImageUrl="~/Image/loading.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <div>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grdGrid1" runat="server" Font-Bold="False" PageSize="30" 
                                                                Width="100%" AllowPaging="True" CssClass="GridView">
                                                                <EmptyDataTemplate>
                                                                    No Record Found
                                                                </EmptyDataTemplate>
                                                                <PagerStyle CssClass="PagerStyle" />
                                                                <RowStyle CssClass="RowStyle" />
                                                                <SelectedRowStyle CssClass="selectedrow" />
                                                                <HeaderStyle BorderStyle="None" CssClass="HeaderStyle" ForeColor="White" />
                                                                <AlternatingRowStyle BorderStyle="None" />
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                       
                                                            <asp:AsyncPostBackTrigger ControlID="cmdFetch" EventName="Click" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                        </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                                                    
                <br />
            </td>
        </tr>
    </table>

</asp:Content>


