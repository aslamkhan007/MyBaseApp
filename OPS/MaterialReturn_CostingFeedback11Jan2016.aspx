<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="MaterialReturn_CostingFeedback.aspx.cs" Inherits="OPS_MaterialReturn_CostingFeedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script type="text/javascript">
     var counter = 0;
     function AddFileUpload() {
         var div = document.createElement('DIV');
         div.innerHTML = '<input id="file' + counter + '" name = "file' + counter + '" type="file" /><input id="Button' + counter + '" type="button" value="Remove" onclick = "RemoveFileUpload(this)" />';
         document.getElementById("FileUploadContainer").appendChild(div);
         counter++;
     }
     function RemoveFileUpload(div) {
         document.getElementById("FileUploadContainer").removeChild(div.parentNode);
     }
    </script>
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="2">
                Costing Feedback</td>
        </tr>
        <tr>
            <td colspan="2">
            <asp:Panel ID="pnlMain" runat="server" Height="300px" Width="90%" ScrollBars="Both">
                            <asp:GridView ID="grdDetail" runat="server" 
                    EmptyDataText="No data available" EnableModelValidation="True" AutoGenerateColumns="false"
                                 Width="100%" 
                                 DataSourceID="SqlDataSource1" AutoGenerateSelectButton="True" 
                                onselectedindexchanged="grdDetail_SelectedIndexChanged">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:BoundField DataField="SanctionNoteID" HeaderText="SanctionNoteID" 
                                        ReadOnly="True" SortExpression="SanctionNoteID" />
                                    <asp:BoundField DataField="AreaCode" HeaderText="AreaCode" ReadOnly="True" 
                                        SortExpression="AreaCode" />
                                    <asp:BoundField DataField="Invoice" HeaderText="Invoice" 
                                        SortExpression="Invoice" />
                                    <asp:BoundField DataField="Sort" HeaderText="Sort" SortExpression="Sort" />
                                    <asp:BoundField DataField="Customer" HeaderText="Customer" 
                                        SortExpression="Customer" />
                                    <asp:BoundField DataField="SalesPerson" HeaderText="SalesPerson" 
                                        SortExpression="SalesPerson" />
                                    <asp:BoundField DataField="Invoice Qty" HeaderText="Invoice Qty" 
                                        ReadOnly="True" SortExpression="Invoice Qty" />
                                    <asp:BoundField DataField="Return Qty" HeaderText="Return Qty" ReadOnly="True" 
                                        SortExpression="Return Qty" />
                                    <asp:BoundField DataField="Reason" HeaderText="Reason" 
                                        SortExpression="Reason" />
                                    <asp:BoundField DataField="RequestDate" HeaderText="RequestDate" 
                                        SortExpression="RequestDate" />

                                        <asp:BoundField DataField="SalePrice" HeaderText="SalePrice" 
                                        SortExpression="SalePrice" />

                                        <asp:BoundField DataField="ValueInvolved" HeaderText="ValueInvolved" 
                                        SortExpression="ValueInvolved" />

                                        <asp:BoundField DataField="FreightBy" HeaderText="FreightBy" 
                                        SortExpression="FreightBy" />
                                        
                                </Columns>
                                <SelectedRowStyle CssClass="GridRowGreen" />
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                                
                    SelectCommand="Jct_Ops_MR_Costing_Pending_Authorization_Fetch" 
                                SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                </asp:Panel>
                        </td>
        </tr>
        <%--JCT_OPS_MATERIAL_REQUEST_FINAL_AUTHORIZATION_DETAILS--%>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
               <asp:GridView ID="grdFoldingObservation" runat="server" 
                    EmptyDataText="No data available" EnableModelValidation="True" AutoGenerateColumns="true"
                                 Width="100%" 
                                >
                                <AlternatingRowStyle CssClass="GridAI" />
                                
                                <SelectedRowStyle CssClass="GridRowGreen" />
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView></td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" valign="top" width="100px">
            <asp:Label ID="lblRemarks" runat="server" Text="Remakrs"></asp:Label>
            
            </td>
            <td width="400px" align="left" valign="top">
            <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" MaxLength="500" 
                    TextMode="MultiLine" Width="90%" Height="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtRemarks" Display="Dynamic" ErrorMessage="Required **" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
            
        </tr>
        
        <tr>
            <td colspan="2" >
                <span style="font-family: Arial">Click to add files</span>&nbsp;&nbsp;
                <input id="Button2" onclick="AddFileUpload()" type="button" value="add" />
                <div id="FileUploadContainer">
                    <!--FileUpload Controls will be added here -->
                </div></td>
            
        </tr>
        
        <tr>
            <td colspan="2" class="buttonbackbar">
                &nbsp;</td>
            
        </tr>
        
        <tr>
            <td colspan="2" class="buttonbackbar">
                <asp:LinkButton ID="cmdApply" Text="Apply" CssClass="buttonc" runat="server" 
                    BorderStyle="None" onclick="cmdApply_Click"></asp:LinkButton>
             </td>
            
        </tr>
        
        <tr>
            <td align="left" valign="top" width="100px">
                &nbsp;</td>
            <td width="400px">
                &nbsp;</td>
            
        </tr>
        
    </table>

</asp:Content>

