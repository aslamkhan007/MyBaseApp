<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="SanctionNoteConversation.aspx.vb" Inherits="OPS_SanctionNoteConversation" %>
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
            <td style="font-weight: bold; font-size: 10pt" class="tableheader">
                Sanction Note Conversation                
            </td>
        </tr>
        </table>
           <table style="width: 100%;">
           
         <tr>
            <td class="labelcells">Base Document Type :</td>
            <td style="width: 208px">
                <asp:DropDownList ID="ddlDocType" runat="server" CssClass="combobox" DataSourceID="dsDocType" DataTextField="DocTypeName" DataValueField="DocTypeId" AutoPostBack="True">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="dsDocType" runat="server" SelectCommand="jct_ops_get_Quotation_doc_sanction" ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDocType" ErrorMessage="Please specify document Type" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td></tr>
         <tr>
            <td class="labelcells" style="width: 194px">Sanction Note ID </td>
              <td style="width: 218px">
                <asp:TextBox runat="server" ID="txtSanctionID"></asp:TextBox>
            </td>
            </tr>

             <tr>
            <td class="labelcells" style="width: 154px">Reply From </td>
            <td>
             <asp:UpdatePanel ID="UpdatePanel38" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtPerson" runat="server" AutoPostBack="True" Columns="50"
                            CssClass="textbox"></asp:TextBox>
                        <div id="div2" style="display: none;">
                            <cc1:AutoCompleteExtender ID="txtSearchCustomer_AutoCompleteExtender" runat="server"
                                CompletionInterval="10" CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="GetEmployeeNameForSantioNote"
                                CompletionListCssClass="AutoExtender" ServicePath="~/WebService.asmx" CompletionListElementID="div2"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListItemCssClass="AutoExtenderList"
                                TargetControlID="txtPerson">
                            </cc1:AutoCompleteExtender>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            </tr>


            <tr>
            <td class="labelcells" style="width: 194px">Date: </td>
              <td style="width: 218px">
                 <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" TargetControlID="txtDateFrom">
                </cc1:CalendarExtender>
            </td>
            </tr>


            <tr>
                     <td class="labelcells" style="width: 194px">Sanction Note Conversation </td>
                     <td>
                     <asp:TextBox ID="txtDescription" runat="server" CssClass="textbox" Height="300px"
                            Width="80%" TextMode="MultiLine" MaxLength="5000"></asp:TextBox>
                     </td>
            </tr>
          <tr>
            <td class="labelcells">Attached Files :</td>
            <td style="width: 135px" colspan="2">
            
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        
                        <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource1" 
                            RepeatColumns="6" RepeatDirection="Horizontal" Width="285%">
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" style="width: 64px">
                                    <tr>
                                        <td>
                                            <div style="margin: auto; width: 64px">
                                                <asp:ImageButton ID="ImageButton1" runat="server" AlternateText='<%# Eval("RefDocActFileName") %>' ImageUrl='<%# Eval("LogoImgPath") %>' Width="64px" Visible="False" />
                                                <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("LogoImgPath") %>' AlternateText='<%# Eval("RefDocActFileName") %>' Width="64px" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="NormalText" style="text-align: center">
                                            <%--<asp:LinkButton ID="lnkLink" runat="server" PostBackUrl='<%# Eval("RefDocFilePath") %>' Text='<%# Eval("RefDocActFileName") %>'></asp:LinkButton>--%>
                                           <asp:LinkButton  ID="HyperLink1" runat="server"   CommandArgument='<%# Eval("RefDocActFileName") %>' CommandName="Download"  Text='<%# Eval("RefDocActFileName") %>' NavigateUrl='<%# Eval("RefDocFilePath") %>'></asp:LinkButton>
                                    

                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="jct_ops_get_ref_docs" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="txtSanctionID" Name="DocNo" PropertyName="Text" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cmdSubmit" EventName="Click" />
                        
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>


            

            </table>
            <div id="FileUploadContainer">
    </div>
    &nbsp;<img alt="Add File" src="../Image/Icons/Action/document_add.png" onclick="AddFileUpload()" width="48" /><asp:ImageButton AlternateText ="Upload File(s)" ID="imgUpload" runat="server"  ImageUrl="~/OPS/Image/Upload.png" Width="48px" />

    <br />
    <div class="buttonbackbar">
    <asp:LinkButton ID="cmdSubmit" runat="server" CssClass="buttonc" >Submit</asp:LinkButton> 
    </div>
    <asp:Label ID="lblError" runat="server" CssClass="errormsg"></asp:Label>
</asp:Content>

