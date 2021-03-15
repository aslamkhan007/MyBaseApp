<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="material_required.aspx.vb" Inherits="material_required" title="Untitled Page" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <table class="style5" cellspacing="0">
        <tr>
            <td class="tableheader" colspan="2" style="height: 26px">
                <asp:Label ID="Label6" runat="server" 
                    Text="Material Required" Font-Names="Arial"></asp:Label>
            </td>
            <td style="height: 24px">
                </td>
            <td class="style111" style="width: 18px; height: 24px" colspan="2">
                </td>
            <td class="style134" style="height: 24px; width: 35px;">
                </td>
            <td colspan="2" style="height: 24px">
                </td>
            <td style="height: 24px">
                </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 75px">
                &nbsp;</td>
            <td class="textcells">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="textcells" style="width: 18px" colspan="2">
                &nbsp;</td>
            <td style="width: 35px" class="labelcells">
                &nbsp;</td>
            <td class="textcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style70">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 75px">
                <asp:Label ID="Label1" runat="server" Text="Year Month     " 
                    CssClass="labelcells" Width="70px" Height="20px"></asp:Label>
            </td>
            <td class="textcells">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_yearmonth" runat="server" 
    Width="137px" AutoPostBack="True" CssClass="combobox">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                <asp:Label ID="Label3" runat="server" Text="Plant" CssClass="labelcells"></asp:Label>
            </td>
            <td class="textcells" style="width: 18px" colspan="2">
                <asp:DropDownList ID="ddl_plant" runat="server" Width="87px" 
                    CssClass="combobox" AutoPostBack="True">
                    <asp:ListItem>Cotton</asp:ListItem>
                    <asp:ListItem>Taffeta</asp:ListItem>
                </asp:DropDownList>
                </td>
            <td style="width: 35px" class="labelcells">
                <asp:Label ID="Label5" runat="server" Text="Report Type" CssClass="labelcells" 
                    Width="70px"></asp:Label>
            </td>
            <td class="textcells">
                <asp:DropDownList ID="ddl_reporttype" runat="server" 
                    Width="208px" CssClass="combobox">
                    <asp:ListItem>Sort wise looms requirement advice</asp:ListItem>
                    <asp:ListItem>Sort wise yarn requirement advice</asp:ListItem>
                    <asp:ListItem>Count wise yarn requirement advice</asp:ListItem>
                    <asp:ListItem>Planned Vs Actual Prdn.</asp:ListItem>
                    <asp:ListItem Value="Raw material value advice">Raw Material Value Advice</asp:ListItem>
                </asp:DropDownList>
                </td>
            <td>
                &nbsp;</td>
            <td class="style70">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 75px">
                <asp:Label ID="Label2" runat="server" Text="Plan Rev.No" CssClass="labelcells"></asp:Label>
            </td>
            <td class="textcells">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_revno" runat="server" Width="80px" 
                            CssClass="combobox" AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                <asp:Label ID="Label4" runat="server" Text="Cot./Syn." CssClass="labelcells"></asp:Label>
            </td>
            <td class="textcells" style="width: 18px" colspan="2">
                <asp:DropDownList ID="ddl_cotsyn" runat="server" Width="87px" 
                    CssClass="combobox">
                    <asp:ListItem>Cotton</asp:ListItem>
                    <asp:ListItem>Synthetic</asp:ListItem>
                </asp:DropDownList>
                </td>
            <td style="width: 35px" class=";abelcells">
                <asp:Label ID="Label7" runat="server" CssClass="labelcells" Text="Remarks"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_remarks" runat="server" CssClass="textbox" Enabled="False" 
                            Width="203px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td class="style71">
                &nbsp;</td>
        </tr>
        <tr>
            <td  colspan="8">
                <asp:Panel ID="Panel1" runat="server" Height="190px" 
                    Width="750px" Font-Bold="False" BorderStyle="Solid">
                  <div  id = "AdjResultsDiv" 
                        style=" width: 100%; height:190px; left: -1px; top: 0px;"> 
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                           <asp:GridView ID="GridView1" runat="server" Font-Names="Tahoma" Font-Size="8pt" 
                                Width="100%" Height="16px" >
                                <EmptyDataTemplate>
                                    Records not Available
                                </EmptyDataTemplate>
                                <HeaderStyle CssClass="gridheader" Font-Names="Tahoma" Font-Size="8pt" 
                                    ForeColor="White" BorderStyle="None" />
                                <AlternatingRowStyle BorderStyle="None" BackColor="#CCCCCC" />
                            </asp:GridView>
            </ContentTemplate>
                    </asp:UpdatePanel>
                    </div> 
                 </asp:Panel>
            </td>
            
            <td class="style72">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style133" style="width: 75px; height: 10px;">
                </td>
            <td style="height: 10px">
                </td>
            <td colspan="2" style="height: 10px">
                        &nbsp;</td>
            <td style="height: 10px">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="10">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" Height="12px" Width="103px" 
                            ImageUrl="~/Image/loading.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td style="height: 10px">
                        &nbsp;</td>
            <td style="height: 16px">
                </td>
            <td style="height: 16px">
                </td>
            <td style="height: 16px">
                </td>
        </tr>
        <tr class="buttonbackbar">
            <td style="height: 25px; width: 75px;">
                </td>
            <td style="height: 25px">
                </td>
            <td style="height: 25px">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="lnk_fetch" runat="server" 
                                  CssClass="buttonc" style="height: 22px">FETCH</asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                </td>
            <td align="center" style="height: 25px" colspan="2">
                                &nbsp;<asp:LinkButton ID="lnk_excel" runat="server" 
                    CssClass="buttonc">EXCEL</asp:LinkButton>
             </td>
            <td align="center" style="height: 25px">
                                <asp:LinkButton ID="lnk_exit" runat="server" CssClass="buttonc" 
                                    style="margin-left: 0px" Width="84px">CLOSE</asp:LinkButton>
             </td>
            <td style="height: 25px">
                </td>
            <td style="height: 25px">
                </td>
            <td style="height: 25px">
                </td>
        </tr>
        <tr>
            <td style="width: 75px">
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td style="width: 18px" colspan="2">
               <asp:UpdatePanel ID="UpdatePanel3" runat="server">
               <ContentTemplate>
                  <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                       FadeInDuration="2" FadeInSteps="2" FadeOutDuration="2" FadeOutSteps="2" Visible="true" />
               </ContentTemplate>
               </asp:UpdatePanel>
             </td>
            <td style="width: 35px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                </td>
        </tr>
    </table>

</asp:Content>


