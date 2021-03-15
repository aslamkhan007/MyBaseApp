<%@ Page Title="" Language="VB" MasterPageFile="MasterPage_Default.master" AutoEventWireup="false" CodeFile="Default_asset.aspx.vb" Inherits="EmpGateway_Default_asset" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
  <table class="mytable">
        <tr>
            <td class="tableheader" colspan="6">
                Accet/Reject&nbsp; PC configration</td>
        </tr>
    
      
        </table>

          <table class="mytable">
        <tr>
           <td class="NormalText" width="350">
                <asp:TextBox ID="txtEmpName" runat="server" AutoPostBack="True" 
                    CssClass="textbox" MaxLength="30" Visible="False" Width="100%"></asp:TextBox>
  
                <cc1:AutoCompleteExtender ID="txtEmpName_AutoCompleteExtender" runat="server" 
               CompletionInterval="10" CompletionSetCount="5" MinimumPrefixLength="1" 
               CompletionListCssClass="autocomplete_ListItem" ContextKey="JCT00LTD" 
                            ServiceMethod="GetEmployeeName" ServicePath="~/WebService.asmx" 
                    TargetControlID="txtEmpName">
                </cc1:AutoCompleteExtender>
  
            </td>
            <td class="NormalText">
                <asp:Button ID="BtnGet" runat="server" BackColor="Black" CssClass="ButtonBack" 
                    Text="View Report" Visible="False" />
            </td>
        </tr>
    
      
        </table>
        <asp:Panel ID="Panel2" runat="server" Visible="False" >
        <table class="mytable">
        
            <tr>
                <td class="NormalText">
                    Computer Type
                </td>
                <td class="NormalText">
                    <asp:Label ID="lblcomptype" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="NormalText">
                    Accepted Date</td>
                <td class="NormalText">
                    <asp:Label ID="lblCurrentDate" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="NormalText">
                    Issued To</td>
                <td class="NormalText">
                    <asp:Label ID="lblissuedto" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        <tr>
            <td class="NormalText">
                Department</td>
            <td class="NormalText">
                <asp:Label ID="lbldept" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="NormalText">
                Model No</td>
            <td class="NormalText">
                <asp:Label ID="lblmodelno" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="NormalText">
                JctSrNo</td>
            <td class="NormalText">
                <asp:Label ID="lblsrno" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Computer Name</td>
            <td class="NormalText">
                <asp:Label ID="lblitemname" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        </table>

        </asp:Panel>                  



        <table>
        <tr>
            <td class="NormalText">
                <asp:DataList ID="DataList2" runat="server" DataKeyField="asset_id" 
                    onitemdatabound="DataList2_ItemDataBound1">


               <ItemTemplate>
                        <table>
                         <tr>
                         <td>
                         
                         <asp:Label ID="Labelhead" runat="server"   Text='<%# Eval("item_name") %>' 
                                 Font-Bold="True" Font-Names="Calibri" Font-Size="Large" 
                                 ForeColor="Black" ></asp:Label>
                        </td>
                       </tr>
                        <tr>
                        <td>
 
                            <asp:Panel ID="Panel1" runat="server" Width="900px">
                                <asp:GridView ID="GridView1" runat="server"  Width="100%"   BorderColor="Black" 
                                    onrowdatabound="GridView1_RowDataBound" >
                           <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PagerStyle" />
                    <RowStyle CssClass="GridItem" />
                                </asp:GridView>
                            </asp:Panel>
                            </td>

                            </tr>
                            </table>
                        </ItemTemplate>
                </asp:DataList>
     
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
     
            </td>
        </tr>
        <tr >
        <td class="NormalText">
             <asp:Label ID="Labelhead" runat="server"   Text='Printer/Scanner' 
                                 Font-Bold="True" Font-Names="Calibri" Font-Size="Large" 
                                 ForeColor="Black" Visible="False" ></asp:Label>
                                 </td>
        </tr>
        <tr>
            <td class="NormalText">
               <asp:Panel ID="Panel1" runat="server" Width="900px">
                                <asp:GridView ID="grdDetailprinter" runat="server"  Width="100%"   BorderColor="Black" 
                                    onrowdatabound="GridView1_RowDataBound" >
                           <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PagerStyle" />
                    <RowStyle CssClass="GridItem" />
                                </asp:GridView>
                            </asp:Panel>
            </td>
        </tr>
           <tr >
        <td class="buttonbackbar">
             <asp:LinkButton ID="lnknext" runat="server" CssClass="buttonc" Visible="False">Next</asp:LinkButton>
                                 <asp:LinkButton ID="lnkprev" runat="server" 
                 CssClass="buttonc" Visible="False">Previous</asp:LinkButton>
                                 <asp:LinkButton ID="lnkexit" runat="server" 
                 CssClass="buttonc" Visible="False">Exit</asp:LinkButton>
                                 </td>
        </tr>

        </table>
     

     
  
</asp:Content>

