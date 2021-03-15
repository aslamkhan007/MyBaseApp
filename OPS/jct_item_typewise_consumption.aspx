<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="jct_item_typewise_consumption.aspx.cs" Inherits="OPS_jct_item_typewise_consumption" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Item Groupwise Consumption&nbsp; :</td>
        </tr>
                    
    </table>
    <table style="width: 100%;">
                <tr>
                    <td style="width: 100px">
                   
                <asp:Label ID="lblFromDate" runat="server" Text="From Date"></asp:Label>
                   
                    </td>
                    <td style="width: 238px">
                    
                        <asp:TextBox ID="txtFromdate" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtFromdate_CalendarExtender" runat="server" 
                            TargetControlID="txtFromdate">
                        </cc1:CalendarExtender>
                       
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtFromdate" ErrorMessage="Please Select From Date...." 
                            ForeColor="#FF6600" >*</asp:RequiredFieldValidator>

                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
                                TargetControlID="txtFromdate" Mask="99/99/9999" MaskType="Date">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1" 
                                ControlToValidate="txtFromdate" CssClass="labelcells" Display="Dynamic" 
                                InvalidValueMessage="Invalid Date" IsValidEmpty="False" 
                                TooltipMessage="DD/MM/YYYY" EmptyValueMessage="PLEASE ENTER DATE" 
                            ForeColor="#FF6600"></cc1:MaskedEditValidator>
                    
                    </td>
                    <td style="width: 88px">
                    
                        <asp:Label ID="lblTodate" runat="server" Text="To Date"></asp:Label>
                    
                    </td>
                    <td style="width: 295px">
                    
                        <asp:TextBox ID="txtTodate" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtTodate_CalendarExtender" runat="server" 
                            TargetControlID="txtTodate">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtTodate" ErrorMessage="Please Select To Date...." 
                            ForeColor="#FF6600">*</asp:RequiredFieldValidator>

                             <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" 
                                    TargetControlID="txtTodate" Mask="99/99/9999" MaskType="Date">
                                </cc1:MaskedEditExtender>
                                <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="MaskedEditExtender2" 
                                    ControlToValidate="txtTodate" CssClass="labelcells" Display="Dynamic" 
                                    InvalidValueMessage="Invalid Date" IsValidEmpty="False" 
                                    TooltipMessage="DD/MM/YYYY" EmptyValueMessage="PLEASE ENTER DATE" 
                            ForeColor="#FF5050"></cc1:MaskedEditValidator>
                    
                     </td>
                    <td>
                    
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 100px">
              
                        <asp:Label ID="lblitemtype" runat="server" Text="Item Type"></asp:Label>
              
                    </td>
                    <td colspan="3">
                      
                        <asp:TextBox ID="txtitemtype" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>
                 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtitemtype" ErrorMessage="Please Select Item Type...." 
                            ForeColor="#FF6600" >*</asp:RequiredFieldValidator>
                      
                    </td>
                    <td>
                      
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 100px">
              
               <asp:LinkButton ID="lnkbtnexcel" runat="server" CssClass="buttonXL" 
              onclick="lnkbtnexcel_Click" Height="32px" Width="32px"></asp:LinkButton>           
                    
                    </td>
                    <td colspan="3">
                      
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
                          
               <%-- <div id="AdjResultsDiv">--%>
               
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
     
          <%--   </div>--%>
                        </td>
                           
                    </tr>                   
                </table>
                       
</asp:Content>

