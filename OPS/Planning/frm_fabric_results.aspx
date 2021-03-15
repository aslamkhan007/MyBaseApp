<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="frm_fabric_results.aspx.vb" Inherits="frm_fabric_results"Title="Untitled Page" %>

<%@ Register namespace="CrystalDecisions.Web" tagprefix="CR" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<script runat="server">

   
</script>


<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="2" >
                Fabric Results&nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 102px; height: 22px;">
                <asp:Label ID="label1" runat="server" CssClass="labelcells" Text="Sort No"></asp:Label>
            </td>
            <td class="textcells">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtsort" runat="server" CssClass="textbox" Width="67px" 
                            AutoPostBack="True" ToolTip=" "></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                            CompletionInterval="10" CompletionListCssClass="autocomplete_ListItem " 
                            ContextKey="" FirstRowSelected="True" MinimumPrefixLength="2" 
                            ServiceMethod="Getfabricsorts" ServicePath="~/WebService.asmx" 
                            TargetControlID="txtsort">
                        </cc1:AutoCompleteExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 102px">
                <asp:Label ID="label2" runat="server" CssClass="labelcells" Text="Shed Name"></asp:Label>
            &nbsp;</td>
            <td style="width: 334px">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlshed" runat="server" AutoPostBack="True" 
                    CssClass="combobox" Width="71px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
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
                                                        HorizontalAlign="Left" Width="97%" 
                                                        AllowPaging="True" PageSize="20">
                                                                <EmptyDataTemplate>
                                                                    No Record Found
                                                                </EmptyDataTemplate>
                                                                <SelectedRowStyle CssClass="selectedrow" />
                                                                <HeaderStyle BorderStyle="None" CssClass="gridheader" ForeColor="White" />
                                                                <AlternatingRowStyle BorderStyle="None" BackColor="#CCCCCC" />
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                <br />
            </td>
        </tr>
    </table>

</asp:Content>


