﻿<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="ODS_Request_Genration.aspx.vb" Inherits="OPS_ODS_Request_Genration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label3" runat="server" Text="ODS Request"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Plant
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPlant" runat="server" CssClass="combobox">
                            <asp:ListItem>Cotton</asp:ListItem>
                            <asp:ListItem>Taffeta</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Order No
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox ID="txtOrderNo" runat="server" AutoPostBack="True" CssClass="textbox"></asp:TextBox>
                        <asp:LinkButton ID="cmdSearch" runat="server" CssClass="searchbluesmall" Height="17px"
                            Width="16px"></asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="ImageProg" runat="server" ImageUrl="~/OPS/Image/loadingNew.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" Width="100%">
                            <HeaderStyle CssClass="GridHeader" />
                            <RowStyle CssClass="GridItem" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <%--<tr>
           
            
        </tr>--%>
        <tr>
            <td>
                SalePerson
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblSalePerson" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Customer
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblCustomerName" runat="server" Width="200px"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                Line Item
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlItems" runat="server" AutoPostBack="True" CssClass="combobox">
                        </asp:DropDownList>
                        <asp:Label ID="lblSort" runat="server" Text="."></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Shade
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblLineNo" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <%--<tr>
           
            
        </tr>--%>
        <tr>
            <td>
                Subject</td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSubject" runat="server" CssClass="textbox" MaxLength="50" 
                            Width="224px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td valign="top">
                Description</td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="textbox" 
                            Height="150px" MaxLength="800" TextMode="MultiLine" 
                            ToolTip="Give Detail description of raising this sanction request (upto 800Charcter)." 
                            Width="300px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td>
                Param</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlParam" runat="server" CssClass="combobox" Width="150px">
                            <asp:ListItem>Pick Slip</asp:ListItem>
                            <asp:ListItem>Pack Slip</asp:ListItem>
                            <asp:ListItem>Sort</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="No."></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtVal" runat="server" CssClass="textbox"></asp:TextBox>
                        <asp:LinkButton ID="CmdSearchData" runat="server" CssClass="searchbluesmall" Height="17px"
                            Width="16px"></asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Panel ID="Panel1" runat="server" Height="300px">
                    <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GrdBasicDetail" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                                Width="100%">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelection" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CurrentOrder" HeaderText="CurrentOrder" />
                                    <asp:BoundField DataField="LineItem" HeaderText="LineItem" />
                                    <asp:BoundField DataField="ItemNo" HeaderText="ItemNo" />
                                    <asp:BoundField DataField="VariantNo" HeaderText="VariantNo" />
                                    <asp:BoundField DataField="BaleNo" HeaderText="BaleNo" />
                                    <asp:BoundField DataField="CurrentDNVBySP" HeaderText="CurrentDNVBySP" />
                                    <asp:BoundField DataField="CurrentSP" HeaderText="CurrentSP" />
                                    <asp:BoundField DataField="OldOrder" HeaderText="OldOrder" />
                                    <asp:BoundField DataField="OldDNV" HeaderText="OldDNV" />
                                    <asp:BoundField DataField="OldDnvByCst" HeaderText="OldDnvByCst" />
                                    <asp:BoundField DataField="OldSP" HeaderText="OldSP" />
                                </Columns>
                                <EmptyDataTemplate>
                                    Not Data Found... !!!
                                </EmptyDataTemplate>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
          <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
            <table style="width: 100%;" class="tableback">
        <tr>
            <td valign="top">
                <asp:Label ID="Label2" runat="server" Font-Size="Small" Text="Authorizing Hierarchy"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top">
                Add Level
            </td>
        </tr>
        <tr>
            <td valign="top">
                              <table style="width: 100%;">
                    <tr>
                        <td colspan="3" valign="top">
                            <asp:UpdatePanel ID="UpdatePanel8" runat="server" RenderMode="Inline">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="searchbluesmall" Height="16px"
                                        Width="16px"></asp:LinkButton>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td width="50%">
                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server" Height="200px" ScrollBars="Both" Width="450px">
                                        <asp:CheckBoxList ID="ChkEmpList" runat="server" CellPadding="0" CellSpacing="0"
                                            Height="99px" RepeatColumns="1" Width="502px">
                                        </asp:CheckBoxList>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:LinkButton ID="btnTransfer" runat="server"  >Level</asp:LinkButton>
                            <br />
                            <br /><%-- <tr>
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
                            <asp:LinkButton ID="cmdCC" runat="server">Notify</asp:LinkButton>
                            <br />
                            <br />
                            <asp:LinkButton ID="imgRemoveItem" runat="server" Height="21px" ToolTip="Click To Clear All Selected Items"
                                Width="24px" CssClass="btncross">X</asp:LinkButton>
                            <br />
                        </td>
                        <td valign="top" width="50%">
                            <asp:UpdatePanel ID="UpdatePanel10" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                <ContentTemplate>
                                    
                                    Level<br /><asp:CheckBoxList ID="ChkDynamicListing" runat="server">
                                    </asp:CheckBoxList>
                                    <hr />Notify<br />
                                    <asp:CheckBoxList ID="chkNotify" runat="server">
                                    </asp:CheckBoxList>
                                </ContentTemplate>
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
        </table>
    <table style="width: 100%;" class="tableback">
          <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="CmdApply" runat="server" BorderStyle="None" CssClass="buttonc">Genrate</asp:LinkButton>
                &nbsp;<asp:LinkButton ID="CmdClear" runat="server" BorderStyle="None" CssClass="buttonc">Clear</asp:LinkButton>
                &nbsp;<asp:LinkButton ID="CmdRemove" runat="server" BorderStyle="None" CssClass="buttonc">Remove</asp:LinkButton>
            </td>
        </tr>
      
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
