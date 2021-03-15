<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="AuthorizeSanction_Note.aspx.vb" Inherits="OPS_AuthorizeSanction_Note" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
            <td class="tableheader">
                Authorize Sanction Note
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td style="font-size: 10pt; font-weight: bold" class="labelcells_s">
                Summary of Pending Sanction Notes...(Click to See Detail)
            </td>
        </tr>
        <tr>
            <td>
                <%--<td style="background-color: #B2B2B2; vertical-align: top; text-align: center; font-weight: bold;
                                                font-size: 10pt; text-transform: capitalize; color: Blue; font-family: 'Trebuchet MS' , Tahoma;
                                                ">
                                                <asp:Label ID="Label19" runat="server" Text='<%# Eval("AreaName") %>'></asp:Label>
                                            </td>--%>
                <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource2" RepeatDirection="Horizontal"
                    ToolTip="Click any Area to see the detials of it." Width="100%">
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
                                                <asp:LinkButton ID="cmdArea" runat="server" CommandName="Select" ForeColor="White"
                                                    Text='<%# Eval("AreaName") %>'></asp:LinkButton>
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
                <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" EnableModelValidation="True"
                            Width="100%">
                            <AlternatingRowStyle CssClass="GridAI" />
                              <Columns>
                                <asp:TemplateField>
                                  <ItemTemplate>
                                    <asp:Label ID="lbl" runat="server" Visible="false" Text="**" ForeColor="Red"></asp:Label>
                                       <img id="imageSanctionNoteID-<%# Eval("SanctionNoteID") %>" alt="Click to show/hide Description" border="0" src="../Image/plus.png" />  
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
                </asp:GridView>

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
                        <asp:AsyncPostBackTrigger ControlID="DataList1" EventName="ItemCommand" />
                        <asp:AsyncPostBackTrigger ControlID="CmdAuthorize" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
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
                            AutoGenerateColumns="true">
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
                            <EmptyDataTemplate>
                                Not Data Found... ! ! !
                            </EmptyDataTemplate>
                            <HeaderStyle CssClass="GridHeader" />
                            <RowStyle CssClass="GridItem" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="DataList1" EventName="ItemCommand" />
                        <asp:AsyncPostBackTrigger ControlID="CmdAuthorize" EventName="Click" />
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
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="GrdSanctionNoteDetail" runat="server" Width="100%" EnableModelValidation="True"
                            AutoGenerateColumns="true">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <EmptyDataTemplate>
                                Not Data Found... ! ! !
                            </EmptyDataTemplate>
                            <HeaderStyle CssClass="GridHeader" />
                            <RowStyle CssClass="GridItem" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="DataList1" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="CmdAuthorize" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
    <p>
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" CssClass="panelbg">

              <asp:DataList ID="dtlAttachment" runat="server">
                <ItemTemplate>
                    <table style="width:100%;">
                        <tr>
                            <td class="NormalText" style="width: 114px">
                                <asp:Label ID="lblAttachments" runat="server" Text='<%# Eval("Attachment") %>'></asp:Label>
                            </td>
                            <td class="NormalText">
                                <asp:LinkButton ID="lnkAttachment" runat="server" CommandName="Download" CommandArgument='<%# Eval("AttachedFile") %>' 
                                    Text='<%# Eval("AttachedFile") %>'></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>

            </asp:Panel>
          
        </ContentTemplate>
          <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="DataList1" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="CmdAuthorize" EventName="Click" />
                    </Triggers>
        </asp:UpdatePanel>
    </p>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td colspan="4">
                <asp:Panel ID="Panel1" runat="server" CssClass="PanelBack">
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
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="GrpApply"
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
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtRemarks" Display="Dynamic" 
                    ErrorMessage="**Give Proper Remarks" SetFocusOnError="True" 
                    ValidationGroup="GrpApply"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        </table>

        <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlReProcessingCost" runat="server" Visible="False">



            <table style="width:100%;">
                <tr>
                    <td class="NormalText" style="width: 202px">
                        <asp:Label ID="Label16" runat="server" Text="Re-Processing Cost"></asp:Label>
                    </td>
                    <td class="NormalText">
                        <asp:TextBox ID="txtReprocessingCost" runat="server" CssClass="textbox" 
                            Width="250px"></asp:TextBox>
                    </td>
                </tr>
            </table>



        </asp:Panel>

    </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridView1" 
                EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>

    <table style="width: 100%;" class="tableback">
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel2" runat="server" Visible="False">
                            <table class="tableback" style="width: 100%;">
                                <tr>
                                    <td colspan="3" style="font-family: Calibri; font-size: medium; font-style: oblique;
                                        font-weight: 100">
                                        Logistics
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblTransport" runat="server" Text="Final Mode of Transport"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlFinalMode" runat="server" CssClass="combobox">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblFreightVal" runat="server" Text="Final Freight Value"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFinalFreightVal" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;<asp:Label ID="Label1" runat="server" Text="Coments For SalePerson"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtComentForSaleP" runat="server" CssClass="textbox" MaxLength="200"
                                                    Width="250px"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="CmdAuthorize" runat="server" BorderStyle="None" ValidationGroup="GrpApply"
                            CssClass="buttonc">Apply</asp:LinkButton>
                        <asp:LinkButton ID="CmdCancel" runat="server" CssClass="buttonc">Clear</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
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
