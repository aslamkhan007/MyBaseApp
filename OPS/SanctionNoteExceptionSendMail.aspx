<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="SanctionNoteExceptionSendMail.aspx.vb" Inherits="OPS_SanctionNoteExceptionSendMail" %>
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
                <asp:Label ID="Label2" runat="server" Text="SanctionNote"></asp:Label>
                <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
                <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
            &nbsp;<asp:TextBox ID="txtSanctionNote" runat="server" CssClass="textbox"></asp:TextBox>
&nbsp;<asp:LinkButton ID="cmdFetch" runat="server">Fetch</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                Area:-
                <asp:Label ID="lblarea" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblsubject" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Auth By 
                <asp:DropDownList ID="ddlAuthBy" runat="server" CssClass="combobox" 
                    AutoPostBack="True">
                </asp:DropDownList>
            &nbsp;<asp:LinkButton ID="LinkButton1" runat="server">Fetch</asp:LinkButton>
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
                        
                        
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
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
    <table style="width: 100%;" class="tableback">
        <tr>
            <td colspan="4">
                &nbsp;</td>
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
                        <asp:LinkButton ID="CmdSendMail" runat="server" BorderStyle="None" ValidationGroup="GrpApply"
                            CssClass="buttonc">SendMail</asp:LinkButton>
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

