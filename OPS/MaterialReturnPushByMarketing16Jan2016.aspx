<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="MaterialReturnPushByMarketing.aspx.cs" Inherits="OPS_MaterialReturnPushByMarketing" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
                Material Return Push By Marketing :</td>
        </tr>
       
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" EnableModelValidation="True"
                            AllowPaging="true" PageSize="10" Width="100%" 
                            OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
                            onpageindexchanging="GridView1_PageIndexChanging">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl" runat="server" Visible="false" Text="**" ForeColor="Red"></asp:Label>
                                        <hr />
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
                 <tr>
            <td colspan="4" >
                <asp:Label ID="lblFoldingobservation" runat="server" 
                  >Folding Observation</asp:Label>
            </td>
        </tr>
                         <tr>
            <td colspan="4">
            </td>
        </tr>
           
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="GridView3" runat="server" EnableModelValidation="True" AllowPaging="true"
                            PageSize="10" Width="100%" CaptionAlign="Left">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <Columns>                           
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />
                            <RowStyle CssClass="GridItem" />
                            <SelectedRowStyle CssClass="GridRowGreen" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                      <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>

       <%--                                <asp:TemplateField AccessibleHeaderText="Qty" HeaderText="Qty">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtQty" runat="server" CssClass="textbox" CausesValidation="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredOrderNo" runat="server" ErrorMessage="*"
                                            ControlToValidate="txtQty" ValidationGroup="mandatory"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
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
                            AutoGenerateColumns="False" onrowdatabound="GridView2_RowDataBound" 
                            CaptionAlign="Left">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkRemove" 
                                            oncheckedchanged="chkRemove_CheckedChanged" AutoPostBack="True" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SortNo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSortNo" runat="server" Text='<%# Eval("SortNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Shade">
                                    <ItemTemplate>
                                        <asp:Label ID="lblShade" runat="server" Text='<%# Eval("Shade") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Meters">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMeters" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="PendingQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPendingQty" runat="server" Text='<%# Eval("Pending") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Variant">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVariant" runat="server" Text='<%# Eval("Types") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>



                                <asp:TemplateField HeaderText="Qty">
                                    <ItemTemplate>
                                        <telerik:radnumerictextbox id="txtQty" runat="server" width="60px" inputtype="Number"
                                            maxlength="7" datatype="System.Int32" minvalue="1" culture="en-US" dbvaluefactor="1"
                                            emptymessage="?" labelwidth="32px" maxvalue="10000" causesvalidation="True" validationgroup="mandatory">
                                    <NumberFormat DecimalDigits="0" />
                                </telerik:radnumerictextbox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtQty"
                                            ErrorMessage="*" Display="Dynamic" ValidationGroup="mandatory" ForeColor="#FF3300" Enabled="false"
                                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>


<%--                                <asp:TemplateField AccessibleHeaderText="Qty" HeaderText="Qty">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtQty" runat="server" CssClass="textbox" CausesValidation="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredOrderNo" runat="server" ErrorMessage="*"
                                            ControlToValidate="txtQty" ValidationGroup="mandatory"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>

                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />
                            <RowStyle CssClass="GridItem" />
                            <SelectedRowStyle CssClass="GridRowGreen" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
         
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
         
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


