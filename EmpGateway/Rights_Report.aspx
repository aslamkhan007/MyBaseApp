<%@ Page Title="Page Hits" Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Rights_Report.aspx.vb" Inherits="Rights" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script language="JavaScript" type="text/javascript" > 
 </script>
<table cellpadding="0" cellspacing="0" id="tblMenu"
                    class="NormalText" width="100%"><tr>
                        <td class="frameheader" colspan="4" width="100%">
                             Rights<asp:ScriptManager ID="ScriptManager2" runat="server">
                     </asp:ScriptManager>                  
                        </td>
                        <td style="background-image: url('Image/Background/Right_Shadow.png'); background-repeat: no-repeat;
                            background-position: left bottom; width: 16px;" rowspan="7">
                            &nbsp;</td>
                    </tr>
                    <tr>
                    
                        <td style="background-position: center top; vertical-align: top;
                            background-repeat: no-repeat; width: 26px; " height="29px" 
                            class="labelcells" >
                             <asp:Label ID="Label10" runat="server" Text="  Application" Height="16px" 
                                 Width="71px"></asp:Label>
                        </td>
                        <td style="background-position: center top; vertical-align: top;
                            background-repeat: no-repeat; width: 117px;" height="29px" 
                            class="textcells">
                             <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                 <ContentTemplate>
                                     <asp:DropDownList ID="DrpApp" runat="server" CssClass="combobox" Height="20px" 
                                         Width="129px" AutoPostBack="True">
                                     </asp:DropDownList>
                                 </ContentTemplate>
                             </asp:UpdatePanel>
                        </td>
                        <td height="29px" class="labelcells">
                             &nbsp;<asp:Label ID="Label11" runat="server" Text="Parent Menu" Height="16px" 
                                 Width="77px"></asp:Label>
                             &nbsp;</td>
                        <td style="background-position: center top; vertical-align: top; 
                            background-repeat: no-repeat; width: 908px;" height="29px" 
                            class="textcells">
                             <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                 <ContentTemplate>
                                     <asp:DropDownList ID="DrpParent" runat="server" CssClass="combobox" Height="16px" 
                                         Width="171px" AutoPostBack="True">
                                     </asp:DropDownList>
                                 </ContentTemplate>
                             </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                    
                        <td style="background-position: center top; vertical-align: top;
                            background-repeat: no-repeat; width: 26px; " height="29px" 
                            class="labelcells" >
                             <asp:Label ID="Label12" runat="server" Text="Sub Menu" Height="16px" 
                                 Width="71px"></asp:Label>
                        </td>
                        <td style="background-position: center top; vertical-align: top;
                            background-repeat: no-repeat; width: 117px;" height="29px" 
                            class="textcells">
                             <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                 <ContentTemplate>
                                     <asp:DropDownList ID="DrpSub" runat="server" CssClass="combobox" Height="20px" 
                                         Width="129px" AutoPostBack="True">
                                     </asp:DropDownList>
                                 </ContentTemplate>
                             </asp:UpdatePanel>
                        </td>
                        <td style="background-position: center top; vertical-align: top; 
                            background-repeat: no-repeat; width: 69px;" height="29px" 
                            class="labelcells">
                             <asp:Label ID="Label13" runat="server" Text="Action" Height="16px" 
                                 Width="59px"></asp:Label>
                             </td>
                        <td style="background-position: center top; vertical-align: top; 
                            background-repeat: no-repeat; width: 908px;" height="29px" 
                            class="textcells">
                             <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                 <ContentTemplate>
                                     <asp:DropDownList ID="DrpAction" runat="server" CssClass="combobox" Height="16px" 
                                         Width="171px">
                                     </asp:DropDownList>
                                 </ContentTemplate>
                             </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                    
                        <td style="background-position: center top; vertical-align: top;
                            background-repeat: no-repeat; width: 26px; " height="29px" 
                            class="labelcells" >
                             &nbsp;</td>
                        <td style="background-position: center top; vertical-align: top;
                            background-repeat: no-repeat; width: 117px;" height="29px" 
                            class="textcells">
                             <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                 <ProgressTemplate>
                                     Please wait.................
                                 </ProgressTemplate>
                             </asp:UpdateProgress>
                        </td>
                        <td style="background-position: center top; vertical-align: top; 
                            background-repeat: no-repeat; width: 69px;" height="29px" 
                            class="labelcells">
                             &nbsp;</td>
                        <td style="background-position: center top; vertical-align: top; 
                            background-repeat: no-repeat; width: 908px;" height="29px" 
                            class="textcells">
                             &nbsp;</td>
                    </tr>
                    <tr>
                    
                        <td style="background-position: center top; vertical-align: top;
                            background-repeat: no-repeat; width: 26px; " height="29px" 
                            class="labelcells" >
                             <asp:Label ID="Label14" runat="server" Text="Employee Name" Height="16px" 
                                 Width="98px"></asp:Label>
                        </td>
                        <td style="background-position: center top; vertical-align: top;
                            background-repeat: no-repeat; " height="29px" 
                            class="textcells" colspan="3">
                         <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                 <ContentTemplate>
                                     <asp:TextBox ID="txtEmpName" runat="server" AutoPostBack="True" 
                                         CssClass="textbox" Height="16px" MaxLength="30" Width="318px"></asp:TextBox>
                                     <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                                         CompletionInterval="100" CompletionListCssClass="autocomplete_ListItem " 
                                         ContextKey="JCT00LTD" FirstRowSelected="True" MinimumPrefixLength="0" 
                                         ServiceMethod="GetEmployeeName" ServicePath="~/WebService.asmx" 
                                         TargetControlID="txtEmpName">
                                     </cc1:AutoCompleteExtender>
                                 </ContentTemplate>
                             </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                    
                        <td height="29px" colspan="4" class="buttonbackbar">
                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                <ContentTemplate>
                                    <asp:LinkButton ID="LnkFetch" runat="server" 
    CssClass="buttonc">Fetch</asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LnkChart" runat="server" CssClass="buttonc">View Chart</asp:LinkButton>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        &nbsp;
                        </td>
                    </tr>
                    <tr>
                    
                        <td style="background-position: center top; vertical-align: top; background-image: url('Image/Plain_Footer.png');
                            background-repeat: no-repeat;" colspan="4">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" GridLines="None" CssClass="GridViewStyle" Width="100%" pagesize="50" 
    AllowPaging="true">
                            <RowStyle CssClass="RowStyle" />
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <PagerStyle CssClass="PagerStyle" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <EditRowStyle CssClass="EditRowStyle" />
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        
                        <asp:AsyncPostBackTrigger ControlID="LnkFetch" EventName="Click" />
                       
                    </Triggers>
                </asp:UpdatePanel>
                        </td>
                    </tr>
               
           <%--    test end--%>
 </table>
</asp:Content>

