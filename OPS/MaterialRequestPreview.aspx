<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="MaterialRequestPreview.aspx.cs" Inherits="OPS_MaterialRequestPreview" %>

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
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label16" runat="server" Text="Material Request Preview "></asp:Label>
            </td>
        </tr>
        <tr runat="server" visible="false">
            <td class="NormalText" style="width: 98px">
                <asp:Label ID="Label17" runat="server" Text="Request From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 135px">
                <asp:TextBox ID="txtRequestFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtRequestFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtRequestFrom">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtRequestFrom" Display="Dynamic" ErrorMessage="**" 
                    ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 73px">
                <asp:Label ID="Label18" runat="server" Text="Request To"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtRequestTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtRequestTo_CalendarExtender" runat="server" 
                    TargetControlID="txtRequestTo">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtRequestTo" Display="Dynamic" ErrorMessage="**" 
                    ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 98px">
                <asp:Label ID="Label19" runat="server" Text="Request ID"></asp:Label>
            </td>
            <td class="NormalText" style="width: 135px">
                <asp:TextBox ID="txtID" runat="server" Columns="10" CssClass="textbox" 
                    MaxLength="10"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 73px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc"  CausesValidation="false"
                            onclick="lnkFetch_Click" ValidationGroup="A">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc">Reset</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:GridView ID="grdMaterialRequest" runat="server" 
                                EnableModelValidation="True" Width="100%" 
                                onrowdatabound="grdMaterialRequest_RowDataBound">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:HyperLinkField HeaderText="Preview"  Text="Preview"  DataNavigateUrlFields="RequestID" 
                                      DataNavigateUrlFormatString="PreviewMaterialRequest.aspx?ID={0}" 
                                        DataTextField="RequestID" DataTextFormatString="Preview" Target="_blank" />
                                           <asp:TemplateField>
                                  <ItemTemplate>
                                      <asp:Label ID="lbl" runat="server" Visible="false" Text="**" ForeColor="Red"></asp:Label>
                                       <img id="imageSanctionNoteID-<%# Eval("RequestID") %>" alt="Click to show/hide Description" border="0" src="../Image/plus.png" />  
                                            <div id="SanctionNoteID-<%# Eval("RequestID") %>" style="display:none;position:relative;left:25px;">
                                         
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
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

