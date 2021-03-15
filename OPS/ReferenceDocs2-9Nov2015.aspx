<%@ Page Title="" MasterPageFile="~/OPS/MasterPage.master" Language="C#" AutoEventWireup="true" CodeFile="ReferenceDocs2.aspx.cs" Inherits="OPS_ReferenceDocs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
    <table style="width: 100%;">
        <tr>
            <td colspan="2" class="tableheader">Reference Documents : 
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblDocNo" runat="server"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cmdSubmit" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">Base Document Type :</td>
            <td>
                <asp:DropDownList ID="ddlDocType" runat="server" CssClass="combobox" DataSourceID="dsDocType" DataTextField="DocTypeName" DataValueField="DocTypeId" AutoPostBack="True" OnSelectedIndexChanged="ddlDocType_SelectedIndexChanged" AppendDataBoundItems="True">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="dsDocType" runat="server" SelectCommand="jct_ops_get_Quotation_doce" ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDocType" ErrorMessage="Please specify document Type" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
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
                <asp:TextBox ID="txtBaseDocNo" runat="server" CssClass="textbox" Width="321px" OnTextChanged="txtBaseDocNo_TextChanged"></asp:TextBox>
                <asp:LinkButton ID="cmdSubmit" runat="server" Visible="false" CssClass="buttonc" OnClick="cmdSubmit_Click">Submit</asp:LinkButton>
            </td>
        </tr>

        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBaseDocNo" ErrorMessage="Please specify document number" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td class="labelcells">Attached Files :</td>
            <td>
            
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        
                        <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource1" RepeatColumns="6" RepeatDirection="Horizontal" Width="100%">
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
                                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Eval("RefDocActFileName") %>' NavigateUrl='<%# Eval("RefDocFilePath") %>'></asp:HyperLink>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="jct_ops_get_ref_docs" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblDocNo" Name="DocNo" PropertyName="Text" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cmdSubmit" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="txtBaseDocNo" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>

        <tr>
            <td class="labelcells">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>

        </table>
    <%--<asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />--%>

    <div id="FileUploadContainer">

        <!--FileUpload Controls will be added here -->

    </div>
    &nbsp;<img alt="Add File" src="../Image/Icons/Action/document_add.png" onclick="AddFileUpload()" width="48" /><asp:ImageButton AlternateText ="Upload File(s)" ID="imgUpload" runat="server" OnClick="btnUpload_Click" ImageUrl="~/OPS/Image/Upload.png" Width="48px" />

    <%--<asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />--%>
    
    <br />
    <asp:Label ID="lblError" runat="server" CssClass="errormsg"></asp:Label>
    
</asp:Content>
