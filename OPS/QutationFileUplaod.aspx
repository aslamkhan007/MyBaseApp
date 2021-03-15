<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="QutationFileUplaod.aspx.vb" Inherits="OPS_QutationFileUplaod" %>

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
                Quotation 
                <asp:Label ID="lblQuotationNo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-weight: bold; font-size: 10pt; text-align: center;">
                <asp:ImageButton ID="ibtBasicInfo" runat="server" 
                    ImageUrl="~/OPS/Image/STab_BasicInfo.png" CausesValidation="False" />
                <asp:ImageButton ID="ibtShadeQty" runat="server" 
                    ImageUrl="~/OPS/Image/STab_ShadesQuantities.png" 
                    CausesValidation="False" />
                <asp:ImageButton ID="ibtPayTerms" runat="server" 
                    ImageUrl="~/OPS/Image/STab_PaymentTerms.png" CausesValidation="False" />
                <asp:ImageButton ID="ibtDispatchDetail" runat="server" 
                    ImageUrl="~/OPS/Image/STab_DispatchDetail.png" CausesValidation="False"  />
                     <asp:ImageButton ID="ibtUpload" runat="server" ImageUrl="~/OPS/Image/STab_Upload Red.png" AlternateText="Upload File" Enabled="False"
                    ValidationGroup="Tab" />
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
                <asp:SqlDataSource ID="dsDocType" runat="server" SelectCommand="jct_ops_get_Quotation_doc" ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDocType" ErrorMessage="Please specify document Type" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
            
        </tr>
        <%-- <tr>
            <td class="labelcells">
<asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:Label ID="lblDocType" runat="server"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlDocType" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>&nbsp;No. :
            </td>
            <td>
                <asp:TextBox ID="txtBaseDocNo" runat="server" CssClass="textbox" Width="164px" ReadOnly="True" 
                   ></asp:TextBox>
                &nbsp;
                <asp:LinkButton ID="cmdSubmit" runat="server" CssClass="buttonc" OnClick="cmdSubmit_Click">Submit</asp:LinkButton>
            </td>
        </tr>--%>
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
                                <asp:ControlParameter ControlID="lblQuotationNo" Name="DocNo" PropertyName="Text" Type="String" />
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
    &nbsp;<img alt="Add File" src="../Image/Icons/Action/document_add.png" onclick="AddFileUpload()" width="48" /><asp:ImageButton AlternateText ="Upload File(s)" ID="imgUpload" runat="server" OnClick="btnUpload_Click" ImageUrl="~/OPS/Image/Upload.png" Width="48px" />

    <br />
    <div class="buttonbackbar">
    <asp:LinkButton ID="cmdSubmit" runat="server" CssClass="buttonc" OnClick="cmdSubmit_Click">Submit</asp:LinkButton> 
    </div>
    <asp:Label ID="lblError" runat="server" CssClass="errormsg"></asp:Label>
   
</asp:Content>

