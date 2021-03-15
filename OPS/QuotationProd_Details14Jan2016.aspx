<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="QuotationProd_Details.aspx.vb" Inherits="OPS_QuotationProd_Details_new" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <style type="text/css">
   .ajax__calendar_container { z-index : 1000 ; }
</style>

  <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Quotation Product Detail
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
  
  

  <asp:Panel runat="server" ID="pnlDetail">
     <table>
        <tr>
          <td>
              &nbsp;</td>
        </tr>
     
     </table>
    
    
    </asp:Panel>
  
  <asp:Panel runat="server" ID="main">
    <table style="width: 100%;">

    <tr>
    <td> <asp:UpdatePanel ID="UpdatePanel5" runat="server" RenderMode="Inline">
               <ContentTemplate>Pending Quotation- <asp:Label runat="server" ID="lblstatus"></asp:Label></ContentTemplate></asp:UpdatePanel></td>
    </tr>
        <tr>
            <td>
               <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline" 
                    UpdateMode="Conditional">
               <ContentTemplate>
                <div id="AdjResultsDiv1" style="height: 200px; overflow: scroll; width: 1050px; top: 0px;
                    left: 0px;">
                                     <asp:GridView ID="GridViewLevel2" runat="server" AutoGenerateColumns="False"  
                        DataKeyNames="Quotation_No" 
                        EmptyDataText="No Relevant Quotation is found." EnableModelValidation="True" 
                                         AllowPaging="True" PageSize="10">
                        <AlternatingRowStyle CssClass="GridAI" Wrap="False" />
                        <Columns>
                            <asp:TemplateField HeaderText="Remarks" Visible="False">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtRemarks" runat="server" Columns="30" CssClass="textbox" 
                                        ValidationGroup="a"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:HyperLinkField DataNavigateUrlFields="Quotation_No" 
                                DataNavigateUrlFormatString="Quotation_Main.aspx?quot={0}"  Target="_blank" 
                                DataTextField="Quotation_No" HeaderText="Quotation No" NavigateUrl="#" />
                         <%--   <asp:TemplateField HeaderText="Validity" SortExpression="Validity" 
                                Visible="False">
                                <ItemTemplate>
                                    <asp:Image ID="imgValidity0" runat="server" 
                                        ImageUrl='<%# Eval("Validity_Img") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Validity") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="P/L" SortExpression="PL">
                                <ItemTemplate>
                                    <asp:Image ID="imgPL0" runat="server" ImageUrl='<%# Eval("PL_Img") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("[Pl]") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>--%>
                            <asp:BoundField DataField="Customer" HeaderText="Customer" 
                                SortExpression="Customer">
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SalePerson" HeaderText="Sale Person" 
                                SortExpression="Sale Person">
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>
                           <%-- <asp:BoundField DataField="Greige Date" HeaderText="Greige Date(M-D-Y)"     DataFormatString="{0:MM/dd/yyyy}"   >
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Greige Remarks" HeaderText="Greige Remarks">
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>--%>
                            <asp:BoundField DataField="ItemType" HeaderText="Item Type" 
                                SortExpression="Item Type">
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Sort" HeaderText="Sort/Enq" 
                                SortExpression="Item Code">
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Dated" HeaderText="Dated" ReadOnly="True" 
                                SortExpression="Dated">
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Shades" HeaderText="Shades" ReadOnly="True" 
                                SortExpression="Shades">
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TotalQuantity" HeaderText="Total Quantity" 
                                ReadOnly="True" SortExpression="Total Quantity">
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UOM" HeaderText="UOM" SortExpression="UOM">
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DNVCost" HeaderText="DnV Cost" ReadOnly="True" 
                                SortExpression="DnV Cost AWtd.">
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SalePrice" HeaderText="Sale Price" 
                                SortExpression="Sale Price">
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MarginPer" HeaderText="Margin %" 
                                SortExpression="Margin %">
                            <HeaderStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PrefMargin" HeaderText="Pref Margin %" 
                                ReadOnly="True" SortExpression="Pref Margin %">
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NetMargin" HeaderText="Net Margin %" 
                                SortExpression="Net Margin %">
                            <HeaderStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PayTime" HeaderText="Pay Time" 
                                SortExpression="Pay Time">
                            <HeaderStyle Wrap="False" />
                            </asp:BoundField>
                        </Columns>
                                         <EmptyDataTemplate>
                                           No Relevant Quotation is found
                                         </EmptyDataTemplate>
                        <HeaderStyle CssClass="GridHeader" Wrap="False" />
                        <RowStyle CssClass="GridItem" Wrap="False" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
               
                </div>
                </ContentTemplate>
                   <Triggers>
                       <asp:AsyncPostBackTrigger ControlID="ddlType" 
                           EventName="SelectedIndexChanged" />
                   </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
   
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlForm">
  
<table>
<tr>
 <td colspan="2">
           <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdDispatchDetail" runat="server" AutoGenerateColumns="False" EmptyDataText="No Dispatch Schedule for this Quotation is found."
                            EnableModelValidation="True" Width="100%" >
                            <AlternatingRowStyle CssClass="GridAI" Wrap="False" />
                            <Columns>
                            <%-- <asp:BoundField  DataField="Target_Date" HeaderText="Greige Date(M-D-Y)" DataFormatString="{0:MM/dd/yyyy}" />
                             <asp:BoundField DataField="Remarks" HeaderText="Remarks" />--%>
                             <asp:BoundField DataField="Quotation_No" HeaderText="Qutation No" />
                                
                                <asp:BoundField DataField="Shade" HeaderText="Shade" SortExpression="Pay Time">
                                    <HeaderStyle Wrap="False" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                 <asp:BoundField DataField="UOM" HeaderText="UOM" />
                               
                                <asp:BoundField DataField="Dispatch_Date" HeaderText="Quot Dispatch Date" />
                                <asp:BoundField DataField="Remark" HeaderText="Remark" />
                               
                               
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" Wrap="False" />
                            <RowStyle CssClass="GridItem" Wrap="False" />
                        </asp:GridView>
                        <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                            SelectCommand="jct_ops_get_quote_dispatch_sch" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="GridViewLevel2" Name="Quotation_No" PropertyName="SelectedValue"
                                    Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
 </td>
 
</tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Current Quotation #
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:Label ID="lblQuotationNo" runat="server"></asp:Label>
                          
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                Stage
            </td>
            <td>
           
             <asp:UpdatePanel ID="UpdatePanel4" runat="server" RenderMode="Inline">
             <ContentTemplate>
            <asp:DropDownList runat="server" ID="ddlType" DataSourceID="SqlDataSource3"  Width="126px"
                    DataTextField="Type" AutoPostBack="True" AppendDataBoundItems="true">
                    <asp:ListItem>-- Select --</asp:ListItem>
                    </asp:DropDownList>
                
                             <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                                SelectCommand="spGet_Jct_Ops_Planning_internal_hierarchy" 
                                SelectCommandType="StoredProcedure">
                                <%--<SelectParameters>
                                    <asp:SessionParameter DefaultValue="" Name="Empcode" SessionField="EmpCode" 
                                        Type="String" />
                                      </SelectParameters>--%>
                             </asp:SqlDataSource>
                             </ContentTemplate>
                             </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                 Date
            </td>
            <td>
                <asp:TextBox ID="txtdate" runat="server" CssClass="textbox" ValidationGroup="a" ></asp:TextBox>
                <cc1:CalendarExtender ID="txtfinishDate_CalendarExtender" runat="server" TargetControlID="txtdate" >
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator123" runat="server" ControlToValidate="txtdate" ValidationGroup="ab"
                    ErrorMessage="Please Specify   Date"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
        <td>
         Remarks
        </td><td>
          <asp:TextBox runat="server" ID="txtRemarks" CssClass="textbox"></asp:TextBox>
        </td>
        </tr>
        <tr>
           <td>   
            <asp:LinkButton ID="cmdsubmit" runat="server" CssClass="buttonc" ValidationGroup="ab">Submit</asp:LinkButton>
           </td>
           <td>
           <%--<asp:LinkButton ID="cmdCancel" runat="server" CssClass="buttonc" ValidationGroup="ab" Visible="false">Cancel</asp:LinkButton>--%>
           </td>
        
        </tr>

    </table>
  </asp:Panel>
  <asp:Panel runat="server" ID="pnlgridauth">
  
  <table style="width: 100%;">

    <tr>
    <td>Authorized Quotations</td>
    </tr>
        <tr>
            <td>
               <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
               <ContentTemplate>
               
                                     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="Quotation_No" 
                        EmptyDataText="No Relevant Quotation is found." EnableModelValidation="True" Width="1050px" 
                                         AllowPaging="True">
                        <AlternatingRowStyle CssClass="GridAI" Wrap="False" />
                        <Columns>
                       <%--  <asp:HyperLinkField DataNavigateUrlFields="Quotation_No" 
                                DataNavigateUrlFormatString="Quotation_Main.aspx?quot={0}" 
                                DataTextField="Quotation_No" HeaderText="Quotation No" NavigateUrl="#" />--%>

                                 <asp:HyperLinkField DataNavigateUrlFields="Quotation_No" DataNavigateUrlFormatString="Quotation_Main.aspx?quot={0}"
                                        DataTextField="Quotation_No" HeaderText="Quotation No" NavigateUrl="~/OPS/Quotation_Main.aspx"
                                        Target="_blank" />

                                 <asp:BoundField DataField="Greige Date" HeaderText="Greige Date(M-D-Y)" DataFormatString="{0:MM/dd/yyyy}"
                                SortExpression="Greige Date">
                                <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" /></asp:BoundField>

                                   <asp:BoundField DataField="Greige Remarks" HeaderText="Greige Remarks" 
                                SortExpression="Greige Remarks">    <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" /></asp:BoundField>
                                <%--<asp:BoundField DataField="Finish Date" HeaderText="Finish Date(M-D-Y)" DataFormatString="{0:MM/dd/yyyy}"
                                SortExpression="Finish Date">    <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" /></asp:BoundField>
                                 <asp:BoundField DataField="Finish Remarks" HeaderText="Finish Remarks" 
                                SortExpression="Finish Remarks">    <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" /></asp:BoundField>--%>

                        </Columns>
                         <HeaderStyle CssClass="GridHeader" Wrap="False" />
                        <RowStyle CssClass="GridItem" Wrap="False" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                        </asp:GridView>



               </ContentTemplate>
               </asp:UpdatePanel>
  
             </td>
            </tr>
  </table>
  </asp:Panel>

</asp:Content>

