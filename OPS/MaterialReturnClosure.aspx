<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="MaterialReturnClosure.aspx.cs" Inherits="OPS_MaterialReturnClosure" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        var counter = 0;
        function AddFileUpload() {
            var div = document.createElement('DIV');
            div.innerHTML = '<input id="file' + counter + '" name = "file' + counter +
                            '" type="file" />' +
                            '<input id="Button' + counter + '" type="button" ' +
                            'value="Remove" onclick = "RemoveFileUpload(this)" />';

            document.getElementById("FileUploadContainer").appendChild(div);
            counter++;
        }

        function RemoveFileUpload(div) {
            document.getElementById("FileUploadContainer").removeChild(div.parentNode);
        }

    </script>
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Material Return Closure :</td>
        </tr>
        <%--  <img id="imageSanctionNoteID-<%# Eval("SanctionNoteID") %>" alt="Click to show/hide Description" border="0" src="../Image/plus.png" />  
                                            <div id="SanctionNoteID-<%# Eval("SanctionNoteID") %>" style="display:none;position:relative;left:25px;">
                                             <asp:GridView ID="nestedGridView" runat="server" Width="100%" 
                    AutoGenerateColumns="False"  >
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <HeaderStyle CssClass="GridHeader" />
                    <RowStyle CssClass="GridItem" />
                        <AlternatingRowStyle CssClass="GridAI" />
                                  <Columns>
                            <asp:BoundField DataField="Description" HeaderText="Description"/>
                          
                    </Columns>
                </asp:GridView>--%>
  
        <tr>
            <td colspan="4" style="height: 265px">
                 
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                     
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" EnableModelValidation="True" AllowPaging="true" PageSize="10"
                            Width="100%" onselectedindexchanged="GridView1_SelectedIndexChanged">
                            <AlternatingRowStyle CssClass="GridAI" />
                              <Columns>
                                <asp:TemplateField>
                                  <ItemTemplate>
                                    <asp:Label ID="lbl" runat="server" Visible="false" Text="**" ForeColor="Red"></asp:Label>
                                     <%--  <img id="imageSanctionNoteID-<%# Eval("SanctionNoteID") %>" alt="Click to show/hide Description" border="0" src="../Image/plus.png" />  
                                            <div id="SanctionNoteID-<%# Eval("SanctionNoteID") %>" style="display:none;position:relative;left:25px;">
                                             <asp:GridView ID="nestedGridView" runat="server" Width="100%" 
                    AutoGenerateColumns="False"  >
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <HeaderStyle CssClass="GridHeader" />
                    <RowStyle CssClass="GridItem" />
                        <AlternatingRowStyle CssClass="GridAI" />
                                  <Columns>
                            <asp:BoundField DataField="Description" HeaderText="Description"/>
                          
                    </Columns>
                </asp:GridView>--%>

                    <hr />

        <asp:GridView ID="nestedGridView_MultipleID" runat="server" Width="100%" 
                    AutoGenerateColumns="False"  >
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <HeaderStyle CssClass="GridHeader" />
                    <RowStyle CssClass="GridItem" />
                        <AlternatingRowStyle CssClass="GridAI" />
                                  <Columns>
                            <asp:BoundField DataField="Invoice" HeaderText="Invoice"/>
                             <asp:BoundField DataField="Sort" HeaderText="Sort"/>
                              <asp:BoundField DataField="Customer" HeaderText="Customer"/>
                               <asp:BoundField DataField="SalesPerson" HeaderText="SalesPerson"/>
                                <asp:BoundField DataField="InvoiceQty" HeaderText="InvoiceQty"/>
                              <asp:BoundField DataField="ReturnQty" HeaderText="ReturnQty"/>
                              <asp:BoundField DataField="Reason" HeaderText="Reason"/>
                          
                    </Columns>
                </asp:GridView>
                                      </div>
                                              
                                        </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />
                            <RowStyle CssClass="GridItem" />
                            <SelectedRowStyle CssClass="GridRowGreen" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="LinkButton1" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>

     
          <tr>
            <td colspan="4" class="buttonbackbar">
            </td>

           
        </tr>

        <tr>
            <td colspan="4">
            </td>
        </tr>
      <%--  <tr>
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                    <td colspan="4">
                        <asp:Label ID="lblRemarks0" runat="server" Text="Folding Observation"></asp:Label>
                    </td>
                </ContentTemplate>
            </asp:UpdatePanel>
        </tr>--%>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdFolding" runat="server" EnableModelValidation="True" AllowPaging="true"
                            PageSize="5" Width="100%" 
                            CaptionAlign="Left" Caption="Folding Observation">
                            <Columns>
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />        
                            <RowStyle Height="15px" BorderColor="Black" BorderStyle="Solid" 
                            BorderWidth="1px" CssClass ="NormalText" />               
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>


                <tr>
            <td colspan="4">
            </td>
        </tr> 


            <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GrdCosting" runat="server" EnableModelValidation="True" AllowPaging="true"
                            PageSize="5" Width="100%" Caption="Costing Authorization" 
                            CaptionAlign="Left">
                            <Columns>
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />        
                            <RowStyle Height="15px" BorderColor="Black" BorderStyle="Solid" 
                            BorderWidth="1px" CssClass ="NormalText" />               
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>



                <tr>
            <td colspan="4">
            </td>
        </tr>

        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdPushbyMarketing" runat="server" 
                            EnableModelValidation="True" AllowPaging="true"
                            PageSize="5" Width="100%" Caption="Push By Marketing" 
                            CaptionAlign="Left">
                            <Columns>
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />        
                            <RowStyle Height="15px" BorderColor="Black" BorderStyle="Solid" 
                            BorderWidth="1px" CssClass ="NormalText" />               
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>


        <tr>
            <td colspan="4">
            </td>
        </tr>
               
     
        <tr>
        <td width="80">
                <asp:Label ID="lbid" runat="server" Text="Numbers of Orders"></asp:Label>
         
         </td>
            <td>
         <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                CssClass="combobox" 
                onselectedindexchanged="ddlObservationType_SelectedIndexChanged">
                
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>6</asp:ListItem>
        <asp:ListItem>7</asp:ListItem>
        <asp:ListItem>8</asp:ListItem>
        <asp:ListItem>9</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        </asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
         <tr>
            <td colspan="4" class="buttonbackbar">
            </td>
           
        </tr>

        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdObservation" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView2" runat="server" ShowHeaderWhenEmpty="True" Width="100%"
                            AutoGenerateColumns="False">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <Columns>
                                <asp:BoundField DataField="SrNo" HeaderText="SrNo" />
                                <asp:TemplateField AccessibleHeaderText="OrderNo" HeaderText="OrderNo">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox" CausesValidation="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredOrderNo" runat="server" ErrorMessage="*"
                                            ControlToValidate="txtOrderNo" ValidationGroup="mandatory"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Comments">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtComments" runat="server" CssClass="textbox" CausesValidation="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredObservation" runat="server" ErrorMessage="*"
                                            ControlToValidate="txtComments" ValidationGroup="mandatory"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />
                            <RowStyle CssClass="GridItem" />
                            <SelectedRowStyle CssClass="GridRowGreen" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>

        <tr>
            <td colspan="4">
            </td>
           
        </tr>
            <tr>
            <td colspan="4" class="buttonbackbar">
            </td>
           
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblRemarks" runat="server" Text="Remarks"></asp:Label>
           
                      
            </td>
            <td  class="NormalText">
                
                  <asp:TextBox ID="txtRemarks" runat="server" CausesValidation="true" CssClass="textbox"
                            Width="160px"></asp:TextBox>
               
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
            <tr>
            <td colspan="4">
            </td>
         
        </tr>
        <tr>
            <td class="NormalText">
                
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
 

            
            <td colspan="3">
            </td>
        </tr>
        
           
           
           

                            
        <tr>

            <td class="buttonbackbar" colspan="4">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonc"  CausesValidation = "True"
                    onclick="LinkButton1_Click" ValidationGroup="mandatory">Apply</asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="buttonc" 
                    onclick="LinkButton2_Click">Reset</asp:LinkButton>
                        <%--<asp:LinkButton ID="lnkaddrow" runat="server" CssClass="buttonc" CausesValidation = "True"
                            onclick="lnkaddrow_Click" ValidationGroup="mandatory">AddRow</asp:LinkButton>--%>
                              </ContentTemplate>
                                  </asp:UpdatePanel>
            </td>
        </tr>
                                      
        <tr>
            <td colspan="4">
              
        </tr>
        <tr>
        <td style="width: 107px" colspan = "4">
        
<%--<asp:AsyncPostBackTrigger ControlID="LinkButton3" EventName="Click" />--%>
        
        </tr>
        
    </table>

</asp:Content>

