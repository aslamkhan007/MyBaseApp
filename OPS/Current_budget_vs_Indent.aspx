<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="Current_budget_vs_Indent.aspx.cs" Inherits="OPS_Current_budget_vs_Indent" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Current Budget Vs Indents:</td>
        </tr>
                    
    </table>
  <table style="width: 100%;">
                <tr>
                    <td style="width: 99px">
              

                    
                        Select Department</td>
                    <td>
                      
                        <asp:DropDownList ID="DropDownList1" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                      
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 99px">
              
               <asp:LinkButton ID="lnkbtnexcel" runat="server" CssClass="buttonXL" 
              onclick="lnkbtnexcel_Click" Height="32px" Width="32px"></asp:LinkButton>           
                    
                    </td>
                    <td>
                      
                        &nbsp;</td>
                    <td>
                      
                        &nbsp;</td>
                </tr>
                </table>

        <table style="width: 100%;" >
            <tr>
                <td class="buttonbackbar" >
                     <asp:UpdatePanel ID="UpdateControl" runat="server" >
              <ContentTemplate>
                               <asp:LinkButton ID="lnkbtnFetch" runat="server" CssClass="buttonc" 
                                   onclick="lnkbtnFetch_Click">Fetch</asp:LinkButton>
            </ContentTemplate>
            </asp:UpdatePanel>             
                </td>                      
            </tr>
            <tr>
                <td class="NormalText">
                   <asp:UpdateProgress ID="UpdateProgress3" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image3" runat="server" Height="16px" 
                            ImageUrl="~/Image/loading.gif" Width="124px" />
                    </ProgressTemplate>
                  </asp:UpdateProgress>
                </td>
            </tr>
      </table>


           
                <table style="width: 100%;">
                    <tr>
                        <td>
             
                
               
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
              <ContentTemplate>
                <asp:Panel ID="Panel1" runat="server" Height="250px" ScrollBars="Both" 
                        Visible="False" Width="1050px">
                
                <asp:GridView ID="Grdfreezedate" runat="server" Width="100%">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="Pagestyle" />
                    <RowStyle CssClass="GridItem" />
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>
                     </asp:Panel>
                     </ContentTemplate>
                   </asp:UpdatePanel> 
      
          
                        </td>
                           
                    </tr>                   
                </table>
</asp:Content>

