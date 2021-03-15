<%@ Page Title="" Language="VB" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="false"
    CodeFile="UploadReimbursement.aspx.vb" Inherits="Payroll_UploadReimbursement" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
       <table style="width: 100%;" class="tableback">
        <tr>
            <td class="tableback">
                Attachments..
            </td>
        </tr>
        <tr>
            <td valign="top">
                <%--<asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel2" runat="server" Height="150px" ScrollBars="Vertical">
                            <asp:GridView ID="GrdEmployee" runat="server" Width="99%">
                                <PagerStyle CssClass="PagerStyle" />
                                <AlternatingRowStyle CssClass="GridAI" />
                                <EmptyDataTemplate>
                                    No Data Found...! ! !
                                </EmptyDataTemplate>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                                <SelectedRowStyle CssClass="GridRowGreen" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlarea" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlplant" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="cmdRetreive" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>--%>
                <span style="font-family: Arial">Click to add files</span>&nbsp;&nbsp;
                <input id="Button2" onclick="AddFileUpload()" type="button" value="add" />
               <div id="FileUploadContainer">
                    <!--FileUpload Controls will be added here -->
                     <asp:Button ID="Button3" Text="Upload"  runat="server" />
                      
                            <asp:Panel ID="Panel4" runat="server" CssClass="panelbg">
                                <asp:DataList ID="dtlAttachment" runat="server" 
                                    onitemcommand="dtlAttachment_ItemCommand">
                                    <ItemTemplate>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td class="NormalText" style="width: 114px">
                                                    <asp:Label ID="lblAttachments" runat="server" Text='<%# Eval("Attachment") %>'></asp:Label>
                                                </td>
                                                <td class="NormalText">
                                                    <asp:LinkButton ID="lnkAttachment" runat="server" CommandArgument='<%# Eval("AttachedFile") %>'
                                                        CommandName="Download" Text='<%# Eval("AttachedFile") %>'></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                            </asp:Panel>
                        
                </div>
                <%--<%@ Register Assembly="com.flajaxian.FileUploader" Namespace="com.flajaxian" TagPrefix="cc3" %>--%>
            </td>
        </tr>
    </table>
     <table style="width: 100%;" class="tableback">
        <tr>
            <td valign="top" colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top" colspan="3">
                &nbsp;
                <asp:FileUpload ID="FileUpload1" runat="server" Height="0px" Width="0px" />
                &nbsp; &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
