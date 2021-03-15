<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="ReimDocUploads.aspx.cs" Inherits="Payroll_ReimDocUploads" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    <table>
        <tr>
            <td>
                <div id="FileUploadContainer">
                </div>
                &nbsp;<img alt="Add File" src="../Image/Icons/Action/document_add.png" onclick="AddFileUpload()"
                    width="48" />
                <asp:ImageButton AlternateText="Upload File(s)" ID="imgUpload" runat="server" OnClick="btnUpload_Click"
                    ImageUrl="~/OPS/Image/Upload.png" Width="48px" />
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" Height="30px" Width="25px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td colspan="4">
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DataList ID="DataList2" runat="server" RepeatColumns="6" RepeatDirection="Horizontal"
                            OnItemCommand="DataList2_ItemCommand">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <div style="margin: auto; width: 64px">
                                                <asp:ImageButton ID="ImageButton1" runat="server" AlternateText='<%# Eval("RefDocActFileName") %>'
                                                    ImageUrl='<%# Eval("LogoImgPath") %>' Visible="False" Width="64px" />
                                                <asp:Image ID="Image2" runat="server" AlternateText='<%# Eval("RefDocActFileName") %>'
                                                    ImageUrl='<%# Eval("LogoImgPath") %>' Width="64px" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="NormalText" style="text-align: center">
                                            <asp:LinkButton ID="HyperLink1" runat="server" CommandArgument='<%# Eval("RefDocActFileName") %>'
                                                CommandName="Download" NavigateUrl='<%# Eval("RefDocFilePath") %>' Text='<%# Eval("RefDocActFileName") %>'></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
