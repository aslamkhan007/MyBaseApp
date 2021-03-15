<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="po_outsorced.aspx.cs" Inherits="OPS_po_outsorced" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Material Inspection (WH)</td>
        </tr>
        <tr>
            <td class="NormalText">
                From Date</td>
            <td class="NormalText">
                <asp:TextBox ID="txtdatefrm" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdatefrm_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdatefrm">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText">
                To Date</td>
            <td class="NormalText">
                <asp:TextBox ID="txttodate" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txttodate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txttodate">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="fetch" runat="server" CssClass="buttonc" 
                    onclick="fetch_Click">Fetch</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="4">
               
               
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/loadingNew.gif" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                 
                
        
              
            </td>
        </tr>
        <tr>
            <td colspan="4" class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Horizontal" Width="900px">
                            <asp:GridView ID="grdDetail" runat="server" EnableModelValidation="True" 
                                AutoGenerateColumns="False">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                   
                                    <asp:BoundField DataField="StockName" HeaderText="StockName" />
                                  <asp:BoundField DataField="Vendor" HeaderText="Vendor" />
                                <asp:BoundField DataField="Doc Rcvd" HeaderText="Doc Rcvd" />
                                <asp:BoundField DataField="Bales Rcvd" HeaderText="Bales Rcvd" />
                               <asp:BoundField DataField="Qty Rcvd" HeaderText="Qty Rcvd" />
                               <%-- <asp:BoundField DataField="pono" HeaderText="PO No" />--%>
                          
                                 <asp:TemplateField HeaderText="ChallanNo">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtchallanno" runat="server" Width="60px" CssClass="textbox"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ChallanDt">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtchallandt" runat="server" Width="60px" CssClass="textbox"></asp:TextBox>
                                            <cc1:TextBoxWatermarkExtender ID="txtchallandt_TextBoxWatermarkExtender" 
                                                runat="server" Enabled="false" TargetControlID="txtchallandt" 
                                                WatermarkText="DD/MM/YY">
                                            </cc1:TextBoxWatermarkExtender>
                                            <cc1:CalendarExtender ID="txtchallandt_CalendarExtender" runat="server" 
                                                Enabled="True" TargetControlID="txtchallandt">
                                            </cc1:CalendarExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Alt Sort">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtaltersort" runat="server" Width="60px" CssClass="textbox"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SortNo">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtSortno" runat="server" Width="60px" CssClass="textbox"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mtr ok">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtmtr" runat="server"  Width="60px" CssClass="textbox"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Shortage">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtShortage" runat="server" Width="60px" CssClass="textbox"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="HookTom">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtHook" runat="server"  Width="60px" CssClass="textbox"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rejection">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtrejct" runat="server"  Width="60px" CssClass="textbox"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtremarks" runat="server" Width="60px" CssClass="textbox"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                         <asp:BoundField DataField="UnloadNo" HeaderText="UnloadNo" />
                               <asp:BoundField DataField="unloadDate" HeaderText="UnloadDtae" />
                                 <asp:BoundField DataField="EntryNo" HeaderText="EntryNO" />
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PageStyle" />
                                <SelectedRowStyle CssClass="GridRowGreen" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="fetch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" ondatabinding="fetch_Click" 
                    UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:LinkButton ID="Lnkapply" runat="server" CssClass="buttonc" 
                    onclick="Lnkapply_Click" Visible="False">Apply</asp:LinkButton>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="fetch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    </asp:Content>

