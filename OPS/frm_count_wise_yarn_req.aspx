<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="frm_count_wise_yarn_req.aspx.vb" Inherits="frm_count_wise_yarn_req"Title="Untitled Page" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>

<%@ Register namespace="CrystalDecisions.Web" tagprefix="CR" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<script runat="server">

   
</script>


<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4" style="height: 37px" >
                Count Wise Yarn Requirment &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 140px">
                <asp:Label ID="label11" runat="server" Text="Year Month"></asp:Label>
            </td>
            <td>
                        <asp:DropDownList ID="ddlyrmth" runat="server" AutoPostBack="True" 
                    CssClass="combobox" >
                        </asp:DropDownList>
            </td>
            <td  class="labelcells">
                &nbsp;</td>
            <td >
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td  class="labelcells" style="width: 140px">
                <asp:Label ID="label5" runat="server" CssClass=" " Text="Location " 
                    style="text-align: left"></asp:Label>
            </td>
            <td >
                        <asp:DropDownList ID="ddllocation" runat="server" AutoPostBack="True" 
                            CssClass="combobox" Width="71px">
                            <asp:ListItem>Cotton</asp:ListItem>
                            <asp:ListItem>Taffeta</asp:ListItem>
                        </asp:DropDownList>
            </td>
            <td  class="labelcells" >
                &nbsp;</td>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td  class="labelcells" style="width: 140px">
                <asp:Label ID="label12" runat="server"  Text="Cloth Type "></asp:Label>
            </td>
            <td >
                        <asp:DropDownList ID="ddlclthtype" runat="server" AutoPostBack="True" 
                            CssClass="combobox" >
                            <asp:ListItem>Cotton</asp:ListItem>
                            <asp:ListItem>Synthetic</asp:ListItem>
                        </asp:DropDownList>
            </td>
            <td  class="labelcells" style="height: 18px">
                &nbsp;</td>
            <td >
                &nbsp;</td>
        </tr>
        </table>
        <table style="width:100%">
        <tr>
            <td class="buttonbackbar" colspan="4" align=" ">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="cmdFetch" runat="server" CssClass="buttonc" 
                    TabIndex="50">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="cmdclose" runat="server" CssClass="buttonc" 
                            onclick="cmdclose_Click" TabIndex="60">Close</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
                 <asp:LinkButton ID="cmdexcel1" runat="server" CssClass="buttonc" 
                    TabIndex="70">Excel</asp:LinkButton><uc1:FlashMessage id="FMsg" runat="server" EnableTheming="true" EnableViewState="true" FadeInDuration="2" FadeInSteps="2" FadeOutDuration="4" FadeOutSteps="2" Visible="true"></uc1:FlashMessage>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                    AssociatedUpdatePanelID="UpdatePanel5">
                    <ProgressTemplate>
                        Please wait...<asp:Image ID="ProgressBar" runat="server" ForeColor="#3333FF" 
                            ImageUrl="~/Image/loading.gif"  />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="panelcells" colspan="4">
            <div  id = "AdjResultsDiv" style=" width: 100%; height:300px; top: 0px;"> 
                        
                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grdGrid1" runat="server"  OnRowDataBound="grdgrid1_RowDataBound"
                                                         Height="15%"  HorizontalAlign="Left" Width="100%" PageSize="5">
                                                                <RowStyle CssClass="RowStyle" />
                                                                <EmptyDataTemplate>
                                                                    Perticular not prepared for this Shed
                                                                </EmptyDataTemplate>
                                                                <SelectedRowStyle CssClass="selectedrow" />
                                                                <HeaderStyle BorderStyle="None" CssClass="gridheader" />
                                                                <AlternatingRowStyle BorderStyle="None" />
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                     </div> 
                <br />
            </td>
        </tr>
    </table>

</asp:Content>


