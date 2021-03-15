<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="SurveyResult.aspx.vb" Inherits="SurveyResult" title="Survey Result" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%; height: 80px">
        <tr>
            <td class="tableheader" colspan="2">
                <asp:Label ID="Label5" runat="server" Text="Survey Results Uploaded" Width="568px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3" class="buttonbackbar">
                <asp:Label ID="Label3" runat="server" Text='"The result of the selected survey is shown in the form of images"' Width="568px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells" >
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Select Survey" Width="112px"></asp:Label></td>
            <td colspan="2">
                <asp:DropDownList ID="LstResult" runat="server" AutoPostBack="True" Height="32px" Width="469px" CssClass="combobox">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Select Question" Width="112px"></asp:Label></td>
            <td class="textcells">
                <asp:DropDownList ID="LstQuest" runat="server" AutoPostBack="True" CssClass="combobox"
                    Height="32px" Width="472px">
                </asp:DropDownList></td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
            </td>
            <td colspan="2">
                <ew:CollapsablePanel ID="CollapsablePanel1" runat="server" CollapseImageUrl="Image/UPARROW.JPG"
                    CollapserAlign="Left" ExpandImageUrl="Image/DNARROW.JPG" Collapsed="True" CssClass="panelcells">
                    <asp:Image ID="SurImage" runat="server" /></ew:CollapsablePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
            </td>
            <td class="labelcells">
            </td>
            <td class="labelcells">
            </td>
        </tr>
    </table>
</asp:Content>

