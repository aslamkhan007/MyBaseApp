<%@ Page Language="C#"  MasterPageFile ="~/Ops/MasterPage.master" AutoEventWireup="true" CodeFile="sizing.aspx.cs" Inherits="sizing" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                  <table  style="height: 250px; width: 100%">
                        <tr>
                            <td colspan="4" class="tableheader">
                    SIZING RECIPE  MATERIAL MAPPING:</td>
                        </tr>
                        <tr>
                            <td class="labelcells">
                    <asp:Label ID="lblFromDate" runat="server" Text="FROM DATE"></asp:Label>
                            </td>
                            <td class="labelcells">
                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="textbox"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtFromDate_FilteredTextBoxExtender" 
                        runat="server" TargetControlID="txtFromDate" ValidChars ="0123456789/" >
                    </cc1:FilteredTextBoxExtender>
                    <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" 
                        TargetControlID="txtFromDate">
                    </cc1:CalendarExtender>
                            </td>
                            <td class="labelcells">
                    <asp:Label ID="lblToDate" runat="server" Text="TO DATE"></asp:Label>
                            </td>
                            <td class="labelcells">
                    <asp:TextBox ID="txtToDate" runat="server" AutoPostBack="True" 
                        ontextchanged="txtToDate_TextChanged" CssClass="textbox"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtToDate_FilteredTextBoxExtender" 
                        runat="server" TargetControlID="txtToDate" ValidChars ="0123456789/">
                    </cc1:FilteredTextBoxExtender>
                    <cc1:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" 
                        TargetControlID="txtToDate">
                    </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" class="buttonbackbar">
                                <asp:LinkButton ID="lnkBtnFetch" runat="server" onclick="lnkBtnFetch_Click" 
                                    CssClass="buttonc">Fetch </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                               <asp:Panel ID="PnlGrdBeamInfo" runat="server" Height="156px"  
                                    ScrollBars="Vertical">
                   
                        <asp:GridView ID="grdBeamInfo" runat="server" Width="100%" 
                        Caption="BEAM INFORMATION: " CaptionAlign="Left" 
                            onselectedindexchanged="grdBeamInfo_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField HeaderText="SELECT">
                                    <ItemTemplate>
                                        <asp:RadioButton ID="rdbtnBeamInfo" runat="server" AutoPostBack="True" 
                                            oncheckedchanged="rdbtnBeamInfo_CheckedChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <asp:Label ID="lblBeamInfo" runat="server" Text="No Record Present"></asp:Label>
                            </EmptyDataTemplate>
                            <HeaderStyle CssClass="GridHeader" />
                            <RowStyle CssClass="GridItem" />
                        </asp:GridView>
                         </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                    <asp:GridView ID="grdSizingInfo" runat="server" Width="100%" 
                        Caption="SIZING MATERIAL INFORMATION: " CaptionAlign="Left" 
                        EmptyDataText="No Record Present!!!!" style="margin-bottom: 0px">
                        <Columns>
                            <asp:TemplateField HeaderText="SELECT">
                                <ItemTemplate>                               
                                    <asp:CheckBox ID="ChkBeamSizinfo" runat="server" AutoPostBack="True" 
                                        oncheckedchanged="ChkBeamSizinfo_CheckedChanged" />                               
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Current consumption">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtgridsizinginfo" runat="server" Enabled="False" 
                                        CssClass="textbox"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtgridsizinginfo_FilteredTextBoxExtender" 
                                        runat="server" TargetControlID="txtgridsizinginfo"
                                          ValidChars="0 1 2 3 4 5 6 7 8 9 ." >
                                    </cc1:FilteredTextBoxExtender>                           
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="GridHeader" />
                        <RowStyle CssClass="GridItem" />
                    </asp:GridView>
                            </td>
                        </tr>
                     
                        <tr>                                               
                            <td colspan="4">
                                <asp:Panel ID="Panel2" runat="server" CssClass="buttonbackbar" Visible="True">                         
                                <asp:LinkButton ID="lnkBtnSave" runat="server" onclick="lnkBtnSave_Click" 
                                    Visible="False" CssClass="buttonc">Save</asp:LinkButton>               
                                </asp:Panel>
                            </td>                                
                        </tr>
                        <tr>
                            <td colspan="4">
                    <asp:GridView ID="grdRecentRecords" runat="server" 
                        Caption="RECENT RECORDS: " CaptionAlign="Left" AutoGenerateColumns="False" 
                        onrowcommand="grdRecentRecords_RowCommand" 
                        onrowdeleting="grdRecentRecords_RowDeleting" EnableModelValidation="True" Width="100%" 
                                    AllowPaging="True">
                        <Columns>
                            <asp:TemplateField HeaderText="DELETE">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkdelete" runat="server" CommandName="DELETE">DELETE</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FREEZE">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkfreeze" runat="server" CommandName="FREEZE">FREEZE</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="iss_no" HeaderText="IssNo" />
                            <asp:BoundField DataField="ISSUE" HeaderText="ISSUE" />
                            <asp:BoundField DataField="BatchNo" HeaderText="BatchNo" />
                            <asp:BoundField DataField="sort_no" HeaderText="Sort_No" />
                            <asp:BoundField DataField="Current_consumption" 
                                HeaderText="CurrentConsumption" />
                            <asp:BoundField DataField="totqty" HeaderText="TotQty" />
                            <asp:BoundField DataField="balance" HeaderText="Balance" />
                            <asp:BoundField DataField="status" HeaderText="Status" />
                            <asp:BoundField DataField="job_no" HeaderText="Job_No" />
                            <asp:BoundField DataField="Cost" HeaderText="Cost" />
                            <asp:BoundField DataField="CostPerMeter" HeaderText="CostPer100Meter" />
                        </Columns>
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PagerStyle" />
                        <RowStyle Font-Underline="False" CssClass="GridItem" />
                    </asp:GridView>
                            </td>
                        </tr>
                        </table>        
 </asp:Content>

 

