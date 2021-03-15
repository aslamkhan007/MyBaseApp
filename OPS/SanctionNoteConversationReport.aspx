<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="SanctionNoteConversationReport.aspx.vb" Inherits="OPS_SanctionNoteConversationReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table style="width:100%;">
        <tr>
            <td style="font-weight: bold; font-size: 10pt" class="tableheader">
                Sanction Note Conversation  Report              
            </td>
        </tr>
        </table>
         <table style="width: 100%;">          
         <tr>
            <td class="labelcells">SanctionNote ID</td>
              <td style="width: 218px">
                <asp:TextBox runat="server" ID="txtSanctionID"></asp:TextBox>
            </td>
            </tr>
             <tr>
            <td class="labelcells">
                Attached Docs:</td>
            <td colspan="3" style="font-weight: bold; color: #FF0000">
                    <asp:UpdatePanel ID="UpdatePanel76" runat="server">
                        <ContentTemplate>
                            <asp:LinkButton ID="lnkAttachedDocs" runat="server" ToolTip="Click to view attached documents"></asp:LinkButton>
 <asp:DataList ID="dtlAttachment" runat="server" DataKeyField="RecordId">
                                <ItemTemplate>
                                    <table style="width:100%;">
                                        <tr>
                                            <td class="NormalText" style="width: 114px">
                                                <asp:Label ID="lblAttachments" runat="server" Text='<%# Eval("Attachment") %>'></asp:Label>
                                            </td>
                                            <td class="NormalText">
                                                <asp:LinkButton ID="lnkAttachment" runat="server" 
                                                    CommandArgument='<%# Eval("AttachedFile") %>' CommandName="Download" 
                                                    Text='<%# Eval("AttachedFile") %>' CausesValidation="false"></asp:LinkButton>
                                            </td>
                                                                                   </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:DataList>

                        </ContentTemplate>
                    </asp:UpdatePanel>
            </td>
        </tr>         
            </tr>
           </table>
           <div class="buttonbackbar">
    <asp:LinkButton ID="cmdSubmit" runat="server" CssClass="buttonc" >View</asp:LinkButton> 
    </div>
</asp:Content>

