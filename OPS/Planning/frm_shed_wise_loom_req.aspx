<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="frm_mktg_commted_date.aspx.vb" Inherits="frm_mktg_commted_date"Title="Untitled Page" %>
<%@ Register Src="../FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>

<%@ Register namespace="CrystalDecisions.Web" tagprefix="CR" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<script runat="server">

   
</script>


<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4" style="height: 37px" >
                Tentative Commetment Date&nbsp;
            </td>
        </tr>
        <tr>
            <td style="" class="labelcells">
                <asp:Label ID="label5" runat="server" CssClass=" " Text="Location "></asp:Label>
            </td>
            <td>
                        <asp:DropDownList ID="ddllocation" runat="server" AutoPostBack="True" 
                            CssClass="combobox" Width="71px">
                            <asp:ListItem>Cotton</asp:ListItem>
                            <asp:ListItem>Taffeta</asp:ListItem>
                        </asp:DropDownList>
            </td>
            <td style="" class="labelcells">
                <asp:Label ID="label10" runat="server" CssClass="labelcells" Text="Shed "></asp:Label>
            </td>
            <td style="width: 334px">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlshed" runat="server" 
    AutoPostBack="True" CssClass="combobox">
                            <asp:ListItem>Airjet</asp:ListItem>
                            <asp:ListItem>Sulzer</asp:ListItem>
                            <asp:ListItem>Rapier</asp:ListItem>
                            <asp:ListItem>Waterjet</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="height: 18px" class="labelcells">
                <asp:Label ID="label3" runat="server" CssClass=" " Text="Sort No"></asp:Label>
            </td>
            <td style="height: 18px">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtsort" runat="server" CssClass="textbox" Width="70px" 
                            TabIndex="10" AutoPostBack="True"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" 
                            CompletionInterval="1" CompletionListCssClass="autocomplete_ListItem " 
                            FirstRowSelected="True" ServiceMethod="Getsalesorts" 
                            ServicePath="~/WebService.asmx" TargetControlID="txtsort" 
                            CompletionSetCount="1" MinimumPrefixLength="1">
                        </cc1:AutoCompleteExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td  class="labelcells" style="height: 18px">
                <asp:Label ID="label8" runat="server" CssClass="labelcells" Text="Qty" 
                    ToolTip="Enter Qty Required "></asp:Label>
            </td>
            <td style="height: 18px">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" 
                            TargetControlID="txtqty" ValidChars="0123456789">
                        </cc1:FilteredTextBoxExtender>
                        <asp:TextBox ID="txtqty" runat="server" AutoPostBack="True" CssClass="textbox" 
                            TabIndex="20" ToolTip="Enter Despatch Qty" Width="51px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="label9" runat="server" CssClass=" " 
                    Text="Looms Worked " ToolTip="Select Location  ( ie Cotton/Tafetta)"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtlooms" runat="server" 
                            CssClass="textbox" 
    ToolTip="Enter Working Looms" Width="31px" TabIndex="30" AutoPostBack="True">1</asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" 
                            TargetControlID="txtlooms" ValidChars="0123456789">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                <asp:Label ID="label7" runat="server" CssClass=" " 
                    Text="Processing Days "></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtprocdays" runat="server" CssClass="textbox" TabIndex="40" 
                            Width="31px" ToolTip="Enter Processing Days">10</asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" 
                            TargetControlID="txtprocdays" ValidChars="0123456789">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="height: 11px" class="labelcells">
            </td>
            <td style="height: 11px">
            </td>
            <td style="height: 11px">
                &nbsp;</td>
            <td style="height: 11px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 151px" class="labelcells" colspan="4">
                <asp:Panel ID="Panel1" runat="server" Font-Bold="False" Font-Names="Tahoma" 
                    Font-Size="8pt" ForeColor="Blue" Height="161px" Width="579px">
                    Pl. note , We have consider the following factor for calculating the Tentative 
                    Commetment Date :-
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp; 1.&nbsp;&nbsp; Consider the pending orders&nbsp; from Ramco from March&#39; 2010 onwards.<br />
                    &nbsp;&nbsp;&nbsp;&nbsp; 2.&nbsp;&nbsp; Forcast entries which is not consider in planning for that month.<br />
                    &nbsp;&nbsp;&nbsp;&nbsp; 3.&nbsp;&nbsp; Sort consider in planning for that month.<br />
                    &nbsp;&nbsp;&nbsp;&nbsp; 4.&nbsp;&nbsp; If any Differance in ( Actual Qty Plan ) -&nbsp; ( Plan Qty consider) for 
                    that month ,then this differance will be&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; consider&nbsp;&nbsp; for calculating&nbsp; sizing length.<br />
                    &nbsp;&nbsp;&nbsp;&nbsp; 5.&nbsp;&nbsp;&nbsp;Weaving production for that month.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp; <span style="color: red">6.&nbsp;</span><span style="color: red">&nbsp; </span>
                    <span style="font-weight: normal; color: red">Sizing Length&nbsp; =&nbsp;&nbsp; ( 1 + 2 + 4 - 3 
                    )</span><span style="color: red">. </span>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp; 7.&nbsp;&nbsp; Shrinkage % from shrinkage master table which is define in Master 
                    under Shrinkage tag.&nbsp;<br />
                    &nbsp;&nbsp;&nbsp;&nbsp; 8.&nbsp;&nbsp; Production/Day for Fabric perticular&#39;s ( Production/Day * 3 ).<br />
                    &nbsp;&nbsp;&nbsp;&nbsp; <span style="color: red">9.&nbsp;&nbsp; Weaving date will be calculated with 
                    considering ( Sizing Lingth,Production/Day,Looms Worked).</span><br />
                    &nbsp;&nbsp;&nbsp;&nbsp; <span style="color: red">10.&nbsp;Tentative Commetment Date will be calculated 
                    with considering ( Weaving Date, Processing Days).</span>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4" align=" ">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="cmdFetch" runat="server" CssClass="buttonc" Height="22px" 
                     Width="84px" TabIndex="50">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="cmdclose" runat="server" CssClass="buttonc" Height="22px" 
                            onclick="cmdclose_Click" Width="84px" TabIndex="60">Close</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
                 <asp:LinkButton ID="cmdexcel1" runat="server" CssClass="buttonc" Width="84px" 
                    TabIndex="70">Excel</asp:LinkButton><uc1:FlashMessage id="FMsg" runat="server" EnableTheming="true" EnableViewState="true" FadeInDuration="2" FadeInSteps="2" FadeOutDuration="4" FadeOutSteps="2" Visible="true"></uc1:FlashMessage>
            </td>
        </tr>
        <tr>
            <td class="style5" colspan="4">
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


