<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="Sizing_Recipe.aspx.cs" Inherits="OPS_Sizing_Recipe" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">





<%--  <script type="text/javascript">

      function SelectAllCheckboxes1(chkbx) {
          $('#<%=grdDetail.ClientID%>').find("input:checkbox").each(function () {
              if (this != chkbx) { this.checked = chkbx.checked; }
          });
      }
 

  </script>--%>




<%--
                         
                 
                         <asp:TemplateField HeaderText="New Qty">
                             <FooterTemplate>
                                 <asp:Label ID="lbtotqty" runat="server"></asp:Label>
                             </FooterTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="lbnewqty" runat="server"></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Rate">
                             <ItemTemplate>
                                 <asp:Label ID="lbrate" runat="server"></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="NewValue">
           
                               <ItemTemplate>
                                 <asp:Label ID="lbval" runat="server"></asp:Label>

      
                                 </ItemTemplate>
                             <FooterTemplate>
                                 <asp:Label ID="lbv" runat="server"></asp:Label>
                             </FooterTemplate>
                            
                          
                           
                  
                         </asp:TemplateField>--%>



    <table style="width: 100%">
        <tr>
            <td class="tableheader" colspan="4">
                Sizing Recipe</td>
        </tr>
        <tr>
            <td class="NormalText">
                IssueNo</td>
            <td>
                <asp:TextBox ID="txtissue" runat="server"  CssClass="textbox"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtissue_AutoCompleteExtender" runat="server" 
                    CompletionInterval="10" CompletionListCssClass="autocomplete_ListItem1" 
                    ServiceMethod="issueNotest" 
                    ServicePath="~/webservice.asmx" TargetControlID="txtissue" 
                    ContextKey="" FirstRowSelected="True" >
                </cc1:AutoCompleteExtender>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Visible="False" ></asp:TextBox>
                <cc1:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" 
                    CompletionInterval="10" DelimiterCharacters="" Enabled="True" 
                    ServiceMethod="issueNo" ServicePath="~/Webservice.asmx" 
                    TargetControlID="TextBox1" UseContextKey="True">
                </cc1:AutoCompleteExtender>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="false" 
                    Visible="False" >
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2013</asp:ListItem>
                    <asp:ListItem>2012</asp:ListItem>
                    <asp:ListItem>2011</asp:ListItem>
                    <asp:ListItem>2010</asp:ListItem>
                    <asp:ListItem>2009</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
            <td>
                <asp:TextBox ID="txtdatefrm" runat="server" Visible="False"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdatefrm_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdatefrm">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td>
                <asp:TextBox ID="Txtdateto" runat="server" Visible="False"></asp:TextBox>
                <cc1:CalendarExtender ID="Txtdateto_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="Txtdateto">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:Panel ID="Panel2" runat="server" ScrollBars="Vertical" Width="100%">
                    <asp:GridView ID="grdDetailselect" runat="server" 
                    AutoGenerateSelectButton="True" EmptyDataText="no records" 
                    
    onselectedindexchanged="grdDetailselect_SelectedIndexChanged" Width="80%">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="Grid item" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" 
                    onclick="lnkfetch_Click">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkupd" runat="server" CssClass="buttonc" 
                    onclick="lnkupd_Click">Update</asp:LinkButton>
                <asp:LinkButton ID="lnkfreeze" runat="server" CssClass="buttonc" 
                    onclick="lnkfreeze_Click">Freeze</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="NormalText">
                <asp:GridView ID="grdDetail" runat="server" EnableModelValidation="True" 
                    AutoGenerateColumns="False" ShowFooter="True" 
                    onrowdatabound="grdDetail_RowDataBound">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <Columns>
       
                         <asp:TemplateField HeaderText="Check">
                             <HeaderTemplate>
                                 <asp:CheckBox ID="chksel" runat="server" Text="Selectall"  
                                    oncheckedchanged="chksel_CheckedChanged" AutoPostBack="True"/>
                             </HeaderTemplate>
                             <ItemTemplate>
                                 <asp:CheckBox ID="chkbx" runat="server" />
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:BoundField DataField="ID" HeaderText="ID" />
                         <asp:BoundField DataField="Issueno" HeaderText=" Issue No" />
                            <asp:BoundField DataField="issuedate" HeaderText="Issue Date" />
                             <asp:BoundField DataField="stockno" HeaderText="Stock No" />
                             <asp:BoundField DataField="varianTno" HeaderText="Variant No" />
                             <asp:BoundField DataField="Tranuom" HeaderText="Tran UOM" />
                              <asp:BoundField DataField="Qty_in_stock_UOM" HeaderText="Qty in stock UOM" />
                             <asp:BoundField DataField="value" HeaderText="value" />
                        
                            <asp:TemplateField HeaderText="Solid percentage">
                                <FooterTemplate>
                                    <asp:Label ID="lbtot" runat="server" Text="Total"></asp:Label>
                                </FooterTemplate>
                            <ItemTemplate>
                       <asp:TextBox ID="solid" runat="server" Width="40%" 
                                    Text='<%# Eval("solidPercent") %>'></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="solid_FilteredTextBoxExtender" runat="server" 
                                    TargetControlID="solid" ValidChars="0123456789.">
                                </cc1:FilteredTextBoxExtender>
                            </ItemTemplate>
                        </asp:TemplateField>   

                         
                 
                         <asp:TemplateField HeaderText="New Qty">
                             <FooterTemplate>
                                 <asp:Label ID="lbtotqty" runat="server"></asp:Label>
                             </FooterTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="lbnewqty" runat="server" Text='<%# Eval("NewQty") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Rate">
                             <ItemTemplate>
                                 <asp:Label ID="lbrate" runat="server" Text='<%# Eval("Rate") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="NewValue" Visible="False">
           
                               <ItemTemplate>
                                 <asp:Label ID="lbval" runat="server" Text='<%# Eval("NewValue") %>'></asp:Label>

      
                                 </ItemTemplate>
                             <FooterTemplate>
                                 <asp:Label ID="lbv" runat="server"></asp:Label>
                             </FooterTemplate>
                            
                          
                           
                  
                         </asp:TemplateField>
  <asp:BoundField DataField="Description" HeaderText="Description" />
                         
                  
<%--
                         
                 
                         <asp:TemplateField HeaderText="New Qty">
                             <FooterTemplate>
                                 <asp:Label ID="lbtotqty" runat="server"></asp:Label>
                             </FooterTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="lbnewqty" runat="server"></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Rate">
                             <ItemTemplate>
                                 <asp:Label ID="lbrate" runat="server"></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="NewValue">
           
                               <ItemTemplate>
                                 <asp:Label ID="lbval" runat="server"></asp:Label>

      
                                 </ItemTemplate>
                             <FooterTemplate>
                                 <asp:Label ID="lbv" runat="server"></asp:Label>
                             </FooterTemplate>
                            
                          
                           
                  
                         </asp:TemplateField>--%>

                         
                 
                    </Columns>
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PageStyle" />
                    <RowStyle CssClass="Griditem" />
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>
            </td>
        </tr>
       <tr>
            <td class="NormalText">
                <asp:Label ID="lbunit" runat="server" Text="Unit Price" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtunit" runat="server" Visible="False" Width="20%" 
                    CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
               <asp:Label ID="lblbatch" runat="server" Text="Batch No" Visible="False"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtbatch" runat="server" Visible="False" CssClass="textbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtbatch" ErrorMessage="Please insert batch no" 
                    ValidationGroup="batch">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td colspan="4" class="NormalText">
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="90%">
                            <asp:GridView ID="grdDetail2" runat="server" AutoGenerateEditButton="True" 
                                EmptyDataText="No records found" EnableModelValidation="True" 
                                onrowediting="grdDetail2_RowEditing" onrowupdating="grdDetail2_RowUpdating" 
                                Width="85%">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PageStyle" />
                                <SelectedRowStyle CssClass="GridRowGreen" />
                            </asp:GridView>
                        </asp:Panel>
                    </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:LinkButton ID="lnkcal" runat="server" CssClass="buttonc" 
                    onclick="lnkcal_Click" Visible="False">Calculate</asp:LinkButton>
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" 
                    onclick="lnksave_Click" Visible="False">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkedit" runat="server" CssClass="buttonc" 
                    onclick="lnkedit_Click" Visible="False">Edit</asp:LinkButton>
                <asp:LinkButton ID="lnkclose" runat="server" CssClass="buttonc" 
                    onclick="lnkclose_Click" Visible="False">Close</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>

