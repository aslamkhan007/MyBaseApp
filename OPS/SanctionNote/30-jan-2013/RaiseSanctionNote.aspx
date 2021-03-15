<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="RaiseSanctionNote.aspx.vb" Inherits="OPS_RaiseSanctionNote" %>

<%--<%@ Register Assembly="FlashUpload" Namespace="FlashUpload" TagPrefix="cc1" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%--<%@ Register Assembly="com.flajaxian.FileUploader" Namespace="com.flajaxian" TagPrefix="cc3" %>--%>
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
    <table style="width: 100%;">
        <tr>
            <td class="tableheader">
                Raise SanctionNote
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td valign="top">
                Area
            </td>
            <td valign="top">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlarea" runat="server" CssClass="combobox" Width="200px" AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td valign="middle">
                &nbsp;SanctionNote
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:Label ID="lblID" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <%-- <tr>
            <td valign="top" width="120">
                &nbsp;
                Attachment (if any)</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="textbox" 
                    Height="22px" Width="318px" />
                <asp:ImageButton ID="ibtAddFile" runat="server" 
                    ImageUrl="~/Image/Icons/Action/iPhoneAdd.png" ToolTip="Add Item to List" 
                    Width="25px" ValidationGroup="a" />
                    &nbsp;<br />
                <asp:HyperLink ID="ImgNameLbL" runat="server" Visible="False" Width="376px">Image Name</asp:HyperLink>
            </td>
        </tr>--%>
        </tr>
        <tr>
            <td>
                Subject
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSubject" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Plant
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox">
                            <asp:ListItem>Cotton</asp:ListItem>
                            <asp:ListItem>Taffeta</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td valign="top">
                Detail Description
            </td>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="textbox" Height="200px"
                            Width="80%"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td valign="top" colspan="2">
                <table style="width: 100%;">
                    <tr>
                        <td colspan="3">
                            Parameter List
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="grdParameters" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                                        Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="ParamCode" HeaderText="Code">
                                                <ControlStyle Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ParmDesc" HeaderText="ParaMeterName" />
                                            <asp:TemplateField HeaderText="Value">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtValue" runat="server" CssClass="textbox"></asp:TextBox>
                                                    <asp:DropDownList ID="ddlValueList" runat="server" CssClass="combobox" Visible="False"
                                                        Width="150px">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("Val") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle CssClass="GridHeader" />
                                        <RowStyle CssClass="GridItem" />
                                        <AlternatingRowStyle CssClass="GridAI" />
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlarea" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
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
                    </tr>
                </table>
            </td>
        </tr>
        <%-- <tr>
            <td valign="top" width="120">
                &nbsp;
                Attachment (if any)</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="textbox" 
                    Height="22px" Width="318px" />
                <asp:ImageButton ID="ibtAddFile" runat="server" 
                    ImageUrl="~/Image/Icons/Action/iPhoneAdd.png" ToolTip="Add Item to List" 
                    Width="25px" ValidationGroup="a" />
                    &nbsp;<br />
                <asp:HyperLink ID="ImgNameLbL" runat="server" Visible="False" Width="376px">Image Name</asp:HyperLink>
            </td>
        </tr>--%>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td class="tableback">
                Attachments..
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <span style="font-family: Arial">Click to add files</span>&nbsp;&nbsp;
                        <input id="Button2" onclick="AddFileUpload()" type="button" value="add" />
                        <div id="FileUploadContainer">
                            <!--FileUpload Controls will be added here -->
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <%--  </td>
        </tr>
        </table>--%>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td valign="top" colspan="3">
                &nbsp;
            </td>
        </tr>
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
            <td valign="top" class="buttonbackbar" colspan="3">
                <asp:LinkButton ID="cmdApply" runat="server" BorderStyle="None" CssClass="buttonc">Apply</asp:LinkButton>
                &nbsp;<asp:LinkButton ID="cmdReset" runat="server" BorderStyle="None" CssClass="buttonc">Reset</asp:LinkButton>
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
                &nbsp;
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
