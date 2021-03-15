<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="frm_shedwiseloomrequired.aspx.vb" Inherits="frm_shedwiseloomrequired" Title="Untitled Page" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>

<%@ Register namespace="CrystalDecisions.Web" tagprefix="CR" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

 <script runat="server">

   </script>
     


<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4" >
                Shedwise Looms Alloted &nbsp;
            </td>
        </tr>
        <tr>
            <td  class="labelcells">
                <asp:Label ID="label5" runat="server"  Text="Period"></asp:Label>
            </td>
            <td class="labelcells">
                        <asp:DropDownList ID="ddlyrmth" runat="server" 
                    CssClass="combobox" 
                            onselectedindexchanged="ddlyrmth_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
            </td >
            <td class="labelcells">
                <asp:Label ID="label10" runat="server" CssClass="labelcells" Text="Shed "></asp:Label>
            </td>
            <td class="labelcells">
               
                        <%-- Perticular not prepared for this Shed--%>
                                <asp:DropDownList ID="ddlshed" runat="server" 
    AutoPostBack="True" CssClass="combobox">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Airjet</asp:ListItem>
                                    <asp:ListItem>Rapier</asp:ListItem>
                                    <asp:ListItem>Sulzer</asp:ListItem>
                                    <asp:ListItem>Waterjet</asp:ListItem>
                                </asp:DropDownList>
               
            </td>
        </tr>
        <tr>
            <td class="labelcells" >
                <asp:Label ID="label11" runat="server" CssClass="labelcells" Text="Sale Team"></asp:Label>
            </td>
            <td class="labelcells">
                        <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlsaleteam" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>--%>
                                <asp:DropDownList ID="ddlsaleteam" runat="server" AutoPostBack="True" 
                                    CssClass="combobox">
                                </asp:DropDownList>
            </td>
            <td  class="labelcells">
                <asp:Label ID="label12" runat="server" CssClass="labelcells" Text="Sale Person"></asp:Label>
            </td>
            <td class="labelcells">
                <%-- Perticular not prepared for this Shed--%>
                        <asp:DropDownList ID="ddlsaleperson" runat="server" AutoPostBack="True" 
                            CssClass="combobox">
                        </asp:DropDownList>
            </td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="buttonbackbar" >
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
            <td class="labelcells">
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
            <td class="panelcells">
            <div  id = "AdjResultsDiv" style=" width: 100%; height:300px; top: 0px;"> 
                        
                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grdGrid1" runat="server"  OnRowDataBound="grdgrid1_RowDataBound"
                                                         Height="15%"  HorizontalAlign="Left" Width="100%" PageSize="5">
                                                                <RowStyle CssClass="RowStyle" />
                                                                <EmptyDataTemplate>
                                                                     Query not matched 
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


