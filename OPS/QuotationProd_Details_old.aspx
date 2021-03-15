<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"    CodeFile="QuotationProd_Details.aspx.vb" Inherits="OPS_QuotationProd_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
  
  <asp:Panel runat="server" ID="pnlForm" Visible="false">
  
<table>
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
            <td><asp:DropDownList runat="server" ID="ddlType" DataSourceID="SqlDataSource3" 
                    DataTextField="Type" ></asp:DropDownList>
                             <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                                SelectCommand="spGet_Jct_Ops_Planning_internal_hierarchy" 
                                SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:SessionParameter DefaultValue="" Name="Empcode" SessionField="EmpCode" 
                                        Type="String" />
                                      </SelectParameters>
                             </asp:SqlDataSource>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator123" runat="server" ControlToValidate="txtdate" ValidationGroup="a"
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
            <asp:LinkButton ID="cmdsubmit" runat="server" CssClass="buttonc" ValidationGroup="a">Submit</asp:LinkButton>
           </td>
           <td>
           <asp:LinkButton ID="cmdCancel" runat="server" CssClass="buttonc" ValidationGroup="a" Visible="false">Cancel</asp:LinkButton>
           </td>
        
        </tr>

    </table>
  </asp:Panel>

  <asp:Panel ID="pnlAuth" runat="server">
  <table>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Current Quotation #
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:Label ID="lblQut" runat="server"></asp:Label>
                          
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                Stage
            </td>
            <td><asp:DropDownList runat="server" ID="ddlLevel"   >
                <asp:ListItem>Accept</asp:ListItem>
                <asp:ListItem>Reject</asp:ListItem>
                </asp:DropDownList>
                            
            </td>
        </tr>
             <tr>
        <td>
         Remarks
        </td><td>
          <asp:TextBox runat="server" ID="txtRemark" CssClass="textbox"></asp:TextBox>
        </td>
        </tr>
        <tr>
           <td colspan="2">   
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonc" ValidationGroup="a">Submit</asp:LinkButton>
           </td>
        
        </tr>

    </table>
  
  </asp:Panel>

  <asp:Panel runat="server" ID="pnlDetail">
     <table>
        <tr>
          <td>
            <asp:GridView ID="grdPendingQuotes" runat="server" Width="100%" 
                    AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="Quotation_No"
                    EnableModelValidation="True" EmptyDataText="No Open Quotation is found.">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <Columns>
                      
                      <asp:CommandField ShowSelectButton="True" />
                       <asp:BoundField DataField="Quotation_No" HeaderText="Quotation" />
                        <asp:BoundField DataField="Target_Date" HeaderText="Target Date" 
                            SortExpression="Greige Date" />
                        <asp:BoundField DataField="User Name" HeaderText="User Name" ReadOnly="True" 
                            SortExpression="User Name" />
                            <asp:BoundField DataField="Type" HeaderText="Stage" ReadOnly="True"    />
                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" ReadOnly="True" 
                           />
                      
                    </Columns>
                    <HeaderStyle CssClass="GridHeader" Wrap="False" />
                    <RowStyle CssClass="GridItem" />
                </asp:GridView>
       <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                                SelectCommand="Sp_get_jct_ops_quotation_prod_details" 
                                SelectCommandType="StoredProcedure"> <SelectParameters>
                                    <asp:SessionParameter DefaultValue="" Name="Usercode" SessionField="EmpCode" Type="String" />
                                     </SelectParameters>
                            </asp:SqlDataSource>
          </td>
        </tr>
     
     </table>
    
    
    </asp:Panel>
  
  <asp:Panel runat="server" ID="main" Visible="false">
    <table style="width: 100%;">
        <tr>
            <td>
                <div id="AdjResultsDiv1" style="height: 200px; overflow: scroll; width: 1050px; top: 0px;
                    left: 0px;">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                                SelectCommand="sp_jct_ops_Get_prod_Detailby_planning_level" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:SessionParameter DefaultValue="" Name="Usercode" SessionField="EmpCode" Type="String" />
                                     </SelectParameters>
                                 <%--   <asp:Parameter DefaultValue="QuotOpen" Name="status" Type="String" />
                                    <asp:Parameter DefaultValue="MktAuth" Name="Sch_Auth_Status" Type="String" />--%>
                               
                            </asp:SqlDataSource>
                            <asp:GridView ID="grdUnauthorisedQuotes" runat="server" AutoGenerateColumns="False"
                                DataSourceID="SqlDataSource2" EmptyDataText="No Relevant Quotation is found."
                                EnableModelValidation="True" DataKeyNames="Quotation_No">
                                <AlternatingRowStyle CssClass="GridAI" Wrap="False" />
                                <Columns>
                                  
                                   
                                  
                                    <asp:TemplateField HeaderText="Remarks" Visible="False">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRemarks" runat="server" Columns="30" CssClass="textbox" ValidationGroup="a"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:HyperLinkField DataNavigateUrlFields="Quotation_No" DataNavigateUrlFormatString="Quotation_Main.aspx?quot={0}"
                                        DataTextField="Quotation_No" HeaderText="Quotation No" NavigateUrl="#"
                                        Target="_blank" />


                                    <asp:TemplateField HeaderText="Validity" SortExpression="Validity" Visible="False">
                                        <ItemTemplate>
                                            <asp:Image ID="imgValidity0" runat="server" ImageUrl='<%# Eval("Validity_Img") %>' />
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
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Customer" HeaderText="Customer" SortExpression="Customer">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SalePerson" HeaderText="Sale Person" SortExpression="Sale Person">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ItemType" HeaderText="Item Type" SortExpression="Item Type">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Sort" HeaderText="Sort/Enq" SortExpression="Item Code">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Dated" HeaderText="Dated" ReadOnly="True" SortExpression="Dated">
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Shades" HeaderText="Shades" ReadOnly="True" SortExpression="Shades">
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalQuantity" HeaderText="Total Quantity" ReadOnly="True"
                                        SortExpression="Total Quantity">
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
                                    <asp:BoundField DataField="SalePrice" HeaderText="Sale Price" SortExpression="Sale Price">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MarginPer" HeaderText="Margin %" SortExpression="Margin %">
                                        <HeaderStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PrefMargin" HeaderText="Pref Margin %" ReadOnly="True"
                                        SortExpression="Pref Margin %">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NetMargin" HeaderText="Net Margin %" SortExpression="Net Margin %">
                                        <HeaderStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PayTime" HeaderText="Pay Time" SortExpression="Pay Time">
                                        <HeaderStyle Wrap="False" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" Wrap="False" />
                                <RowStyle CssClass="GridItem" Wrap="False" />
                                <SelectedRowStyle CssClass="GridRowGreen" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
   
    </asp:Panel>

  <asp:Panel runat="server" ID="Panellevel2" Visible="false">
    <table style="width: 100%;">
        <tr>
            <td>
                <div id="Div1" style="height: 200px; overflow: scroll; width: 1050px; top: 0px;
                    left: 0px;">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                                SelectCommand="sp_jct_ops_Get_prod_Detailby_planning_level" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:SessionParameter DefaultValue="" Name="Usercode" SessionField="EmpCode" Type="String" />
                                     </SelectParameters>
                                 <%--   <asp:Parameter DefaultValue="QuotOpen" Name="status" Type="String" />
                                    <asp:Parameter DefaultValue="MktAuth" Name="Sch_Auth_Status" Type="String" />--%>
                               
                            </asp:SqlDataSource>
                            <asp:GridView ID="GridViewLevel2" runat="server" AutoGenerateColumns="False"
                                DataSourceID="SqlDataSource2" EmptyDataText="No Relevant Quotation is found."
                                EnableModelValidation="True" DataKeyNames="Quotation_No">
                                <AlternatingRowStyle CssClass="GridAI" Wrap="False" />
                                <Columns>
                                   
                                    
                                    <asp:TemplateField HeaderText="Remarks" Visible="False">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRemarks" runat="server" Columns="30" CssClass="textbox" ValidationGroup="a"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:HyperLinkField DataNavigateUrlFields="Quotation_No" DataNavigateUrlFormatString="Quotation_Main.aspx?quot={0}"
                                        DataTextField="Quotation_No" HeaderText="Quotation No" NavigateUrl="#"
                                       />


                                    <asp:TemplateField HeaderText="Validity" SortExpression="Validity" Visible="False">
                                        <ItemTemplate>
                                            <asp:Image ID="imgValidity0" runat="server" ImageUrl='<%# Eval("Validity_Img") %>' />
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
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="Customer" HeaderText="Customer" SortExpression="Customer">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SalePerson" HeaderText="Sale Person" SortExpression="Sale Person">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Greige Date" HeaderText="Greige Date" ><HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="Greige Remarks" HeaderText="Greige Remarks" ><HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="ItemType" HeaderText="Item Type" SortExpression="Item Type">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Sort" HeaderText="Sort/Enq" SortExpression="Item Code">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Dated" HeaderText="Dated" ReadOnly="True" SortExpression="Dated">
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Shades" HeaderText="Shades" ReadOnly="True" SortExpression="Shades">
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalQuantity" HeaderText="Total Quantity" ReadOnly="True"
                                        SortExpression="Total Quantity">
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
                                    <asp:BoundField DataField="SalePrice" HeaderText="Sale Price" SortExpression="Sale Price">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MarginPer" HeaderText="Margin %" SortExpression="Margin %">
                                        <HeaderStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PrefMargin" HeaderText="Pref Margin %" ReadOnly="True"
                                        SortExpression="Pref Margin %">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NetMargin" HeaderText="Net Margin %" SortExpression="Net Margin %">
                                        <HeaderStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PayTime" HeaderText="Pay Time" SortExpression="Pay Time">
                                        <HeaderStyle Wrap="False" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" Wrap="False" />
                                <RowStyle CssClass="GridItem" Wrap="False" />
                                <SelectedRowStyle CssClass="GridRowGreen" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
   
    </asp:Panel>

    
  
</asp:Content>

