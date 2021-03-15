<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="frm_new_income_expense.aspx.vb" Inherits="frm_new_income_expense"Title="Untitled Page" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>

<%@ Register namespace="CrystalDecisions.Web" tagprefix="CR" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="System.Web.DataVisualization" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<script runat="server">

   
</script>


<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <table style="width:100%;" >
        <tr>
            <td class="tableheader" colspan="4" >
                Income &amp; Expenses
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 313px; height: 32px;">
                <asp:Label ID="Label2" runat="server" Text="Effective From"></asp:Label>
            </td>
            <td style="width: 160px; height: 32px;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                 <asp:TextBox ID="txtEffecFrom" runat="server" CssClass="textbox"></asp:TextBox>
                 
                <cc1:CalendarExtender ID="txtEffecFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtEffecFrom" >
                </cc1:CalendarExtender>
                </ContentTemplate>
                </asp:UpdatePanel>
               
            </td>
            <td class="NormalText" style="width: 153px; height: 32px;">
                <asp:Label ID="Label3" runat="server" Text="Effective To"></asp:Label>
            </td>
            <td class="NormalText" style="height: 32px">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtEffecTo" runat="server" CssClass="textbox" 
                            AutoPostBack="True" Width="71px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtEffecTo_CalendarExtender" runat="server" 
                          TargetControlID="txtEffecTo">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 313px; height: 33px;">
                <asp:Label ID="label24" runat="server" CssClass=" " Text="Income Expense " 
                    style="text-align: left"></asp:Label>
            </td>
            <td style="width: 160px; height: 33px;" >
                                <asp:DropDownList ID="ddlincexp" 
    runat="server" AutoPostBack="True" 
                            CssClass="combobox" >
                                    <asp:ListItem>Expense</asp:ListItem>
                                    <asp:ListItem>Income</asp:ListItem>
                                </asp:DropDownList>
            </td>
            <td class="NormalText" style="width: 153px; height: 33px;" >
                <asp:Label ID="label25" runat="server" CssClass=" " Text="Group Name  " 
                    style="text-align: left"></asp:Label>
            </td>
            <td class="NormalText" style="height: 33px">
                                <asp:DropDownList ID="ddlelement" runat="server" AutoPostBack="True" 
                    CssClass="combobox" Height="18px" Width="183px"  >
                                </asp:DropDownList>
               </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 313px; height: 32px;">
                <asp:Label ID="label26" runat="server" CssClass=" " Text="Cost Center" 
                    style="text-align: left"></asp:Label>
            </td>
            <td style="width: 160px; height: 32px;" >
                                <asp:DropDownList ID="ddlccname" runat="server" AutoPostBack="True" 
                                    CssClass="combobox" Height="18px" Width="183px">
                                </asp:DropDownList>
            </td>
            <td class="NormalText" style="width: 153px; height: 32px;" >
                <asp:Label ID="label27" runat="server" CssClass=" " Text="Location" 
                    style="text-align: left"></asp:Label>
            </td>
            <td class="NormalText" style="height: 32px">
                        <asp:DropDownList ID="ddllocation" runat="server" AutoPostBack="True" 
                            CssClass="combobox" Height="18px" Width="183px">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Abohar Office</asp:ListItem>
                            <asp:ListItem>Banglore Office</asp:ListItem>
                            <asp:ListItem>Cotton</asp:ListItem>
                            <asp:ListItem>Delhi Office</asp:ListItem>
                            <asp:ListItem>Garmenting</asp:ListItem>
                            <asp:ListItem>Mumbai Office</asp:ListItem>
                            <asp:ListItem>Retail Div.</asp:ListItem>
                            <asp:ListItem>Retail Shops</asp:ListItem>
                            <asp:ListItem>Taffeta</asp:ListItem>
                        </asp:DropDownList>
               </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4" style="height: 27px" >
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="cmdFetch" runat="server" CssClass="buttonc" 
                    >Fetch</asp:LinkButton>
                        <asp:LinkButton ID="cmdclose" runat="server" CssClass="buttonc"
                            onclick="cmdclose_Click" >Close</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
                 <asp:LinkButton ID="cmdexcel1" runat="server" CssClass="buttonc" 
                   >Excel</asp:LinkButton><uc1:FlashMessage id="FMsg" runat="server" EnableTheming="true" EnableViewState="true" FadeInDuration="2" FadeInSteps="2" FadeOutDuration="4" FadeOutSteps="2" Visible="true"></uc1:FlashMessage>
            </td>
        </tr>
        <tr>
            <td  colspan="4" class="NormalText" style="height: 45px">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                    AssociatedUpdatePanelID="UpdatePanel5">
                    <ProgressTemplate>
                        Please wait...<asp:Image ID="ProgressBar" runat="server" ForeColor="#3333FF" 
                           ImageUrl="~/Image/loading.gif" />
                        &nbsp;
                        <br />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:Panel ID="Panel3" runat="server">
             
                          <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                          <ContentTemplate>
                                                            <asp:GridView ID="grdGrid1" runat="server"  
                                                                OnRowDataBound="grdgrid1_RowDataBound" Width="100%" PageSize="5" 
                                                        style="margin-top: 9px" ShowFooter="True">
                                                                <RowStyle CssClass="GridItem" />
                                                                <AlternatingRowStyle CssClass="GridAI" />
                                                                <EmptyDataTemplate>
                                                                    No Record Found
                                                                </EmptyDataTemplate>
                                                                <SelectedRowStyle CssClass="selectedrow" />
                                                                <HeaderStyle CssClass="GridHeader" />
                                                            </asp:GridView>
                        
                                                  </ContentTemplate>
                                                  
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="cmdFetch" EventName="Click" />
                                                         </Triggers>
                                                  
                                                    </asp:UpdatePanel>
                  </asp:Panel>
              
                <br />
            </td>
        </tr>
    </table>
  
</asp:Content>


