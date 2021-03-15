<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="AuthorizeSanctionNote10.aspx.cs" Inherits="OPS_AuthorizeSanctionNote10" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" src="../Scripts/jquery.min.js"></script>
     <script type="text/javascript">
         $("[src*=plus]").live("click", function () {
             $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
             $(this).attr("src", "../Image/minus.png");
         });
         $("[src*=minus]").live("click", function () {
             $(this).attr("src", "../Image/plus.png");
             $(this).closest("tr").next().remove();
         });
    </script>
    <table style="width:100%;">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label16" runat="server" Text="Authorize Sanction Note"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
               
               <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource2" 
                            RepeatDirection="Horizontal" ToolTip="Click any Area to see the detials of it." 
                            Width="100%" onitemcommand="DataList1_ItemCommand1">
                            <ItemTemplate>
                                <table cellpadding="1" cellspacing="0" style="width: 100%;">
                                    <tr>
                                        <td>
                                            <table cellpadding="0" cellspacing="0" style="width: 100%;">
                                                <tr>
                                                    <td align="center" class="HighlightBox">
                                                        <asp:Label ID="lblCount" runat="server" Text='<%# Eval("Count") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                            <%--<td style="background-color: #B2B2B2; vertical-align: top; text-align: center; font-weight: bold;
                                                font-size: 10pt; text-transform: capitalize; color: Blue; font-family: 'Trebuchet MS' , Tahoma;
                                                ">
                                                <asp:Label ID="Label19" runat="server" Text='<%# Eval("AreaName") %>'></asp:Label>
                                            </td>--%>
                                                    <td align="center" class="GridRowRed">
                                                        <asp:LinkButton ID="cmdArea" runat="server" CommandName="Select" 
                                                            ForeColor="Black" Text='<%# Eval("AreaName") %>'></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                          <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                    SelectCommand="Jct_Ops_Pending_Authorization_Count_Fetch" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter Name="UserCode" SessionField="Empcode" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>

               
               </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Label ID="Label17" runat="server" Text="Greigh Transfer Request"></asp:Label>
            </td>
        </tr>
        </table>


<table style="width: 100%;" class="tableback">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="GridView4" runat="server" AutoGenerateSelectButton="True"  
                            EnableModelValidation="True" AutoGenerateColumns="false"
                            Width="100%" onrowdatabound="GridView4_RowDataBound" 
                            onselectedindexchanged="GridView4_SelectedIndexChanged">
                            <AlternatingRowStyle CssClass="GridAI" />
                              <Columns>
                                <asp:TemplateField>
                                  <ItemTemplate>
                                      <asp:Label ID="lbl" runat="server" Visible="false" Text="**" ForeColor="Red"></asp:Label>
                                       <img id="imageSanctionID-<%# Eval("SanctionID") %>" alt="Click to show/hide Description" border="0" src="../Image/plus.png" />  
                                            <div id="SanctionID-<%# Eval("SanctionID") %>" style="display:none;position:relative;left:25px;">
                                             <asp:GridView ID="nestedGridView" runat="server" Width="100%"  AutoGenerateColumns="False"  >
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <HeaderStyle CssClass="GridHeader" />
                    <RowStyle CssClass="GridItem" />
                        <AlternatingRowStyle CssClass="GridAI" />
                                  <Columns>
                            <asp:BoundField DataField="Remarks" HeaderText="Remarks"/>
                          
                    </Columns>
                </asp:GridView>

                <hr />
                           </div>
 
                                        </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sanction ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSanctionID" runat="server" Text='<%# Eval("SanctionID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Order No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrderNo" runat="server" Text='<%# Eval("OrderNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sort">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSort" runat="server" Text='<%# Eval("Sort") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQty" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sale Price">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSalesPrice" runat="server" Text='<%# Eval("sales_price") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GreighReq">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGreighReq" runat="server" Text='<%# Eval("GreighReq") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Greigh Prod.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGreighProd" runat="server" Text='<%# Eval("SizingDone") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Greigh Transfered">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGreighTransfered" runat="server" Text='<%# Eval("Adjusted") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Greigh Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGreighLeft" runat="server" Text='<%# Eval("GreighLeft") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Request Dt">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRequestDt" runat="server" Text='<%# Eval("RequestDt") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Request By">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRequestBy" runat="server" Text='<%# Eval("Request_By") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />
                            <RowStyle CssClass="GridItem" />
                            <SelectedRowStyle CssClass="GridRowGreen" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                                SelectCommand="JCT_OPS_PLANNING_GET_SANCTION_DETAIL_HIERARCHY_WISE" 
                                SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:SessionParameter Name="EmpCode" SessionField="EmpCode" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                      
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DataList1" EventName="ItemCommand" />
                         <asp:AsyncPostBackTrigger ControlID="lnkApply" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
    <ProgressTemplate>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
    </ProgressTemplate>
    </asp:UpdateProgress>

    

    <table style="width: 100%;" class="tableback">
        <tr>
            <td>
                <asp:Label ID="lblDetail0" runat="server" Text="Authorization History" Font-Bold="True"
                    Font-Size="10pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="GrdAuthHistory" runat="server" Width="100%" EnableModelValidation="True"
                            AutoGenerateColumns="true" 
                           
                            onrowdatabound="GrdAuthHistory_RowDataBound">
                            <AlternatingRowStyle CssClass="GridAI" />
                              <Columns>
                                <asp:TemplateField>
                                <ItemTemplate>
                                  <img id="imageSanctionID-<%# Eval("SanctionID") %>" alt="Click to show/hide Description" border="0" src="../Image/plus.png" />  
            <div id="SanctionID-<%# Eval("SanctionID") %>" style="display:none;position:relative;left:25px;">
                   <asp:GridView ID="nestedRemarks" runat="server" Width="100%" 
                    AutoGenerateColumns="False"  >
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <HeaderStyle CssClass="GridHeader" />
                    <RowStyle CssClass="GridItem" />
                        <AlternatingRowStyle CssClass="GridAI" />
                                  <Columns>
                            <asp:BoundField DataField="Remarks" HeaderText="Remarks"/>
                          
                    </Columns>
                </asp:GridView>
                                      </div>
                                              
                                        </ItemTemplate>
                                
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                Not Data Found... ! ! !
                            </EmptyDataTemplate>
                            <HeaderStyle CssClass="GridHeader" />
                            <RowStyle CssClass="GridItem" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView4" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="DataList1" EventName="ItemCommand" />
                        <asp:AsyncPostBackTrigger ControlID="lnkApply" EventName="Click" />
                       </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>

    <table style="width: 100%;" class="tableback">
        <tr>
            <td class="lebelcells_s">
                <asp:Label ID="lblDetail" runat="server" Text="Detail" Font-Bold="True" Font-Size="10pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="GrdSanctionNoteDetail" runat="server" Width="100%" EnableModelValidation="True"
                            AutoGenerateColumns="false">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <EmptyDataTemplate>
                                Not Data Found... ! ! !
                            </EmptyDataTemplate>
                            <Columns>
                                    <asp:TemplateField HeaderText="Order No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrderNo1" runat="server" Text='<%# Eval("OrderNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sort">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSort1" runat="server" Text='<%# Eval("Sort") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Shade">
                                        <ItemTemplate>
                                            <asp:Label ID="lblShade1" runat="server" Text='<%# Eval("Shade") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Line No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLineItem1" runat="server" Text='<%# Eval("LineItem") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQty1" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Sale Price">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSalesPrice1" runat="server" Text='<%# Eval("sales_price") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GreighReq">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGreighReq1" runat="server" Text='<%# Eval("GreighReq") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Greigh Adjusted">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtGreighAdjusted1"  Width="40px" CssClass="textbox" Text='<%# Eval("GreighAdjusted") %>' runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            <HeaderStyle CssClass="GridHeader" />
                            <RowStyle CssClass="GridItem" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView4" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="DataList1" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="lnkApply" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>

        <table style="width: 100%;" class="tableback">
        <tr>
            <td colspan="4">
                <asp:Panel ID="Panel3" runat="server" CssClass="PanelBack">
                    <table style="width: 100%;">
                        <tr>
                            <td width="200">
                                Action
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlAction" runat="server" CssClass="combobox">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Authorize</asp:ListItem>
                                    <asp:ListItem>Cancel</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlAction"
                                    Display="Dynamic" ErrorMessage="** Required Field" SetFocusOnError="True" ValidationGroup="GrpApply"
                                    Enabled="true"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td width="200">
                Remarks (if Any)
            </td>
            <td>
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" Width="250px" 
                    Height="50px" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtRemarks" ErrorMessage="** Required Field" 
                    ValidationGroup="GrpApply" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        </table>


        <table style="width: 100%;" class="tableback">
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="img" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdatePanel ID="Upd" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkApply" runat="server" BorderStyle="None" ValidationGroup="GrpApply"
                            CssClass="buttonc" onclick="lnkApply_Click" >Apply</asp:LinkButton>
                        <asp:LinkButton ID="lnkCancel" runat="server" CssClass="buttonc" 
                            onclick="lnkCancel_Click">Clear</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
             </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

