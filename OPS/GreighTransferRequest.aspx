<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="GreighTransferRequest.aspx.cs" Inherits="OPS_GreighTransferRequest" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <script language="javascript" type="text/javascript">
         function expandcollapse(obj, row) {
             var div = document.getElementById(obj);
             var img = document.getElementById('img' + obj);

             if (div.style.display == "none") {
                 div.style.display = "block";
                 if (row == 'alt') {
                     img.src = "../Image/minus.png";
                 }
                 else {
                     img.src = "../Image/minus.png";
                 }
                 img.alt = "Close";
             }
             else {
                 div.style.display = "none";
                 if (row == 'alt') {
                     img.src = "../Image/plus.png";
                 }
                 else {
                     img.src = "../Image/plus.png";
                 }
                 img.alt = "Expand to show Order Details";
             }
         }
    </script>

    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="3">
                <asp:Label ID="Label16" runat="server" Text="Greigh Transfer Request"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 153px; height: 16px;">
                <asp:Label ID="Label17" runat="server" Text="Original Sale Order"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtSaleOrder" runat="server" CssClass="textbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSaleOrder" Display="Dynamic" ErrorMessage="** Field Required" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText"></td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 153px">
                <asp:Label ID="Label18" runat="server" Text="New Sale Order"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtNewSaleOrder" runat="server" CssClass="textbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewSaleOrder" Display="Dynamic" ErrorMessage="** Field Required" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">&nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 153px">
                <asp:Label ID="Label19" runat="server" Text="Remarks"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtRemarks" runat="server" Height="50px" TextMode="MultiLine" Width="300px"></asp:TextBox>
            </td>
            <td class="NormalText">&nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 153px">
                &nbsp;</td>
            <td class="NormalText">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td class="NormalText">&nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="3">
                <asp:UpdatePanel ID="updButton" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" OnClick="lnkFetch_Click" ValidationGroup="A">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc" OnClick="lnkSave_Click">Save</asp:LinkButton>
                        <asp:LinkButton ID="lnkModify" runat="server" CssClass="buttonc" OnClick="lnkModify_Click">Modify</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" OnClick="lnkReset_Click">Reset</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
            </td>
            
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlOriginalSaleOrder" runat="server">
                            <asp:GridView ID="grdOrignalSaleOrder" 
                                        runat="server" 
                                        EnableModelValidation="True" 
                                        Width="100%" 
                                        OnRowDataBound="grdOrignalSaleOrder_RowDataBound"   
                                        AutoGenerateColumns="False">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="True" OnCheckedChanged="chkSelect_CheckedChanged" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Order No">
                                        <ItemTemplate>
                                          
                                         <asp:Label ID="lblorder_no" runat="server"    Text='<%# Eval("order_no") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Sort No">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblsort_no" runat="server"    Text='<%# Eval("sort_no") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Line No">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblline_no" runat="server"    Text='<%# Eval("line_no") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Shade">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblshade" runat="server"    Text='<%# Eval("shade") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Order Qty">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblorder_qty" runat="server"    Text='<%# Eval("order_qty") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Sale Price">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblsale_price" runat="server"    Text='<%# Eval("sale_price") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Greigh Requested">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblgreigh_requested" runat="server"    Text='<%# Eval("greigh_requested") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Greigh Issued">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblgreigh_issued" runat="server"    Text='<%# Eval("greigh_issued") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Greigh Transfered">
                                        <ItemTemplate>
                                            <asp:Label ID="lblnet_amt" runat="server"    Text='<%# Eval("net_amt") %>'></asp:Label>
                                                    <asp:Label ID="lblgreigh_transfered" runat="server"    Text='<%# Eval("greigh_transfered") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>
 
                                    <asp:TemplateField HeaderText="Plant">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblplant" runat="server"    Text='<%# Eval("plant") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>

     <table style="width:100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlNewSaleOrder" runat="server">
                            <asp:GridView ID="grdNewSaleOrder" 
                                    runat="server" 
                                    EnableModelValidation="True" 
                                    Width="100%" 
                                    OnRowDataBound="grdNewSaleOrder_RowDataBound"   
                                    AutoGenerateColumns="False">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="True" OnCheckedChanged="ChkSelectedChanged" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Order No">
                                        <ItemTemplate>
                                          
                                         <asp:Label ID="lblorder_no" runat="server"    Text='<%# Eval("order_no") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Sort No">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblsort_no" runat="server"    Text='<%# Eval("sort_no") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Line No">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblline_no" runat="server"    Text='<%# Eval("line_no") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Shade">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblshade" runat="server"    Text='<%# Eval("shade") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Order Qty">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblorder_qty" runat="server"    Text='<%# Eval("order_qty") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Sale Price">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblsale_price" runat="server"    Text='<%# Eval("sale_price") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Greigh Requested">
                                        <ItemTemplate>
                                         
                                                    <asp:Label ID="lblgreigh_requested" runat="server"    Text='<%# Eval("greigh_requested") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Greigh Issued">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblgreigh_issued" runat="server"    Text='<%# Eval("greigh_issued") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Greigh Transfered">
                                        <ItemTemplate>
                                            <asp:Label ID="lblnet_amt" runat="server"    Text='<%# Eval("net_amt") %>'></asp:Label>
                                                    <asp:Label ID="lblgreigh_transfered" runat="server"    Text='<%# Eval("greigh_transfered") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="To Transfer">
                                        <ItemTemplate>
                                          
                                                <asp:TextBox ID="txtto_transfer" Width="50px" MaxLength="6" runat="server"    Text='<%# Eval("to_transfer") %>'></asp:TextBox>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Plant">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblplant" runat="server"    Text='<%# Eval("plant") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                        </asp:Panel>

                        <asp:Panel runat="server" ID="pnlModify">

                               <asp:GridView ID="grdModify" 
                                        runat="server" 
                                        EnableModelValidation="True"
                                        OnRowCommand="grdModify_RowCommand" 
                                        Width="100%" 
                                        OnRowDataBound="grdModify_RowDataBound"
                                        DataKeyNames="ID"    
                                        AutoGenerateColumns="False">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                      <asp:TemplateField>
                                        <ItemTemplate>
                                            <a href="javascript:expandcollapse('div<%# Eval("ID") %>','one');">
                                                <img id="imgdiv<%# Eval("ID") %>" alt="Click to show/hide"
                                                    width="9px" border="0" src="../Image/minus.png" />
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" CommandName="Authorize" ID="lnkAuthorize" Text="Authorize"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" CommandName="Delete" ID="lnkDeleteRow" Text="Delete"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Order No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblorder_no" runat="server" Text='<%# Eval("order_no") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Sort No">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblsort_no" runat="server"    Text='<%# Eval("sort_no") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Line No">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblline_no" runat="server"    Text='<%# Eval("line_no") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Shade">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblshade" runat="server"    Text='<%# Eval("shade") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Order Qty">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblorder_qty" runat="server"    Text='<%# Eval("order_qty") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Sale Price">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblsale_price" runat="server"    Text='<%# Eval("sale_price") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Greigh Issued">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblgreigh_issued" runat="server"    Text='<%# Eval("greigh_issued") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Greigh Transfered">
                                        <ItemTemplate>
                                   
                                                    <asp:Label ID="lblgreigh_transfered" runat="server"    Text='<%# Eval("greigh_transfered") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                    <ItemTemplate>
                        <tr>
                            <td colspan="100%">
                                <div  id="div<%# Eval("ID") %>"  position: relative; left: 15px; 
                                    overflow: auto; width: 97%">
                                  
                            <asp:GridView ID="grdChildModify" 
                                    runat="server" 
                                    EnableModelValidation="True" 
                                    Width="100%"
                                    AutoGenerateColumns="False">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                       <asp:TemplateField HeaderText="Order No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblorder_no" runat="server"    Text='<%# Eval("order_no") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Sort No">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblsort_no" runat="server"    Text='<%# Eval("sort_no") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Line No">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblline_no" runat="server"    Text='<%# Eval("line_no") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Shade">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblshade" runat="server"    Text='<%# Eval("shade") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Order Qty">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblorder_qty" runat="server"    Text='<%# Eval("order_qty") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Sale Price">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblsale_price" runat="server"    Text='<%# Eval("sale_price") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Greigh Issued">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblgreigh_issued" runat="server"    Text='<%# Eval("greigh_issued") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Greigh Transfered">
                                        <ItemTemplate>
                                             
                                                    <asp:Label ID="lblgreigh_transfered" runat="server"    Text='<%# Eval("greigh_transfered") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="To Transfer">
                                        <ItemTemplate>
                                          <asp:Label ID="lblto_transfer" runat="server"    Text='<%# Eval("to_transfer") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>


                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:TemplateField>


                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>

                        </asp:Panel>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>

</asp:Content>

