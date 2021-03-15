<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="Rights.aspx.vb" Inherits="Rights" title="Rights" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<script language="JavaScript" type="text/javascript">
</script>
     <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                User
                Rights Report<asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td class="labelcells" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
    RepeatDirection="Horizontal" AutoPostBack="True">
                            <asp:ListItem>Web Application</asp:ListItem>
                            <asp:ListItem Selected="True">Windows Application</asp:ListItem>
                        </asp:RadioButtonList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label10" runat="server" Height="16px" Text="  Application" 
                    Width="70px"></asp:Label>
            </td>
            <td style="width: 223px" >
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DrpApp" runat="server" AutoPostBack="True" 
                            CssClass="combobox"  Width="129px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells" style="width: 121px">
                <asp:Label ID="Label11" runat="server" Height="16px" Text="Parent Menu" 
                    Width="75px"></asp:Label>
            </td>
            <td class="textcells">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DrpParent" runat="server" AutoPostBack="True" 
                            CssClass="combobox"  Width="171px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label12" runat="server" Height="16px" Text="Sub Menu" 
                    Width="71px"></asp:Label>
            </td>
            <td style="width: 223px" >
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DrpSub" runat="server" AutoPostBack="True" 
                            CssClass="combobox"  Width="225px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells" style="width: 121px">
                <asp:Label ID="Label13" runat="server" Height="16px" Text="Action" Width="43px"></asp:Label>
            </td>
            <td class="textcells">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DrpAction" runat="server" CssClass="combobox" 
                             Width="171px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label14" runat="server" Height="16px" Text="Employee Name" 
                    Width="98px"></asp:Label>
            </td>
            <td colspan="2" >
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtEmpName" runat="server" AutoPostBack="True" 
                            CssClass="textbox" MaxLength="30" Width="374px" >ALL</asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                            CompletionInterval="100" CompletionListCssClass="autocomplete_ListItem " 
                            ContextKey="JCT00LTD" FirstRowSelected="True" MinimumPrefixLength="0" 
                            ServiceMethod="GetEmployeeName_for_rights" ServicePath="~/WebService.asmx" 
                            TargetControlID="txtEmpName">
                        </cc1:AutoCompleteExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="textcells">
                        <asp:LinkButton ID="LnkFetch0" runat="server" Font-Underline="False" 
                    Height="16px" Width="182px">Click Here For Export To Excel</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="LnkFetch" runat="server" CssClass="buttonc">Fetch</asp:LinkButton>
                        &nbsp;
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td  colspan="4" style="font-size: x-small; font-family: Tahoma">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate> <asp:Image ID="Image1" runat="server" Height="50px" ImageUrl="~/Image/progress.gif"
                            Width="50px" />
                        Please Wait...........
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td  colspan="4" style="font-size: x-small; font-family: Tahoma">
                <asp:Panel ID="Panel1" runat="server" Height="477px" ScrollBars="None" 
                    Width="100%">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" 
    UpdateMode="Conditional">
                        <ContentTemplate>
                        <div  id = "AdjResultsDiv" style=" width:100%; height:250px;"> 
                           <asp:GridView id="GridView1" runat="server" Width="100%" Height="1%" Font-Size="8pt" Font-Names="Tahoma" 
                                Font-Bold="False" AllowPaging="true" PageSize="200"
                                      HorizontalAlign="Left"><SelectedRowStyle BackColor="DarkGray"></SelectedRowStyle>
<HeaderStyle BorderStyle="None" ForeColor="White" CssClass="gridheader"></HeaderStyle>
<AlternatingRowStyle BorderStyle="None"></AlternatingRowStyle>
<EmptyDataTemplate> <asp:Label ID="Label14" runat="server" Height="16px" Text="Employee Name" 
                    Width="98px">No Data is Available</asp:Label>
</EmptyDataTemplate>
</asp:GridView> 
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="LnkFetch" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" colspan="4">
                &nbsp;</td>
        </tr>
    </table>
 
    </asp:Content>

