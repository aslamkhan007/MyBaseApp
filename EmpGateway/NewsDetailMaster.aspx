<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="NewsDetailMaster.aspx.vb" Inherits="NewsDetailMaster" title="News Detail Master" %>
 <%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[



// ]]>
</script>

    <table style="width: 100%">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label6" runat="server" Text="News Detail Master"></asp:Label></td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
            <td align="left"  colspan="10"  class="textcells"  >
                <asp:LinkButton ID="LinkButton1" runat="server" Width="196px">« Back to News Master</asp:LinkButton></td>
        </tr>
    </table>
    <table style="width: 100%; border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid; border-bottom: #000000 1px solid;" id="TABLE1" onclick="return TABLE1_onclick()">
        <tr>
            <td colspan="7"  class="labelcells" >
                <asp:Label ID="Label2" runat="server"      
                    Text="News No." Width="112px"></asp:Label></td>
            <td colspan="3"  class="labelcells" >
                <asp:Label ID="lblnews" runat="server" Width="112px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="7"  class="labelcells" >
                <asp:Label ID="Label1" runat="server" Text="Attach" Width="112px"></asp:Label></td>
            <td colspan="3" class="textcells">
                <asp:RadioButtonList ID="RLAtt" runat="server"    
                      Height="20px" RepeatDirection="Horizontal" Width="432px">
                    <asp:ListItem Value="P" Selected="True">Image</asp:ListItem>
                    <asp:ListItem Value="F">Feedback Form</asp:ListItem>
                    <asp:ListItem Value="A">Attendence List</asp:ListItem>
                    <asp:ListItem Value="V">Video</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td colspan="7"   class="labelcells" >
                <asp:Label ID="Label26" runat="server" Text="Attach File" Width="112px"></asp:Label></td>
            <td colspan="3" class="textcells">
                <asp:FileUpload ID="FileUpload1" runat="server" Width="359px" /></td>
        </tr>
        <tr>
            <td colspan="7"  class="labelcells" >
                <asp:Label ID="Label7" runat="server" Text="Description" Width="112px"></asp:Label></td>
            <td colspan="3" class="textcells">
                <asp:TextBox ID="txtdesc" runat="server" Height="99px" TextMode="MultiLine" 
                    Width="353px" CssClass="textbox"></asp:TextBox><br />
            </td>
        </tr>
        <tr>
            <td align="center" class="buttonbackbar" colspan="10" >
                <asp:Button ID="btnadd" runat="server" CssClass="ButtonBack"  Text="Add" />
               </td>
        </tr>
    </table>
    <span style="font-size: 3pt; color: #ffffff">reerr</span><br />
    <table style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid;
        width: 100%; border-bottom: #000000 1px solid">
        <tr style="font-size: 12pt; font-family: Times New Roman">
            <td colspan="10" style="height: 21px;  " align="center">
                &nbsp;<uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                    FadeInDuration="2" FadeInSteps="2" FadeOutDuration="2" FadeOutSteps="2" Visible="true" />
            </td>
        </tr>
        <tr style="font-size: 12pt; font-family: Times New Roman">
            <td colspan="10" style="height: 21px;  " class="panelcells">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="News No.">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblnews" runat="server"      
                                    ForeColor="Red" Text='<%# eval("Transaction_no") %>' Width="59px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lbltype" runat="server"      
                                    Text='<%# eval("flag") %>' Width="59px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FileName">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkfile" runat="server"  
                                          Text='<%# eval("file_name") %>'
                                    Width="131px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lbldesc" runat="server"      
                                    Text='<%# eval("description") %>' Width="228px"></asp:Label>&nbsp;
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remove">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkrem" runat="server" CausesValidation="False" CommandName="delete"
                                            Width="52px">Remove</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle HorizontalAlign="Center" />
                    <HeaderStyle CssClass="gridheader" />
                    <AlternatingRowStyle CssClass="GridAI" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

