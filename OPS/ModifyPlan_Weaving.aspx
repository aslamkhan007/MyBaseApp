<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true"
    CodeFile="ModifyPlan_Weaving.aspx.cs" Inherits="OPS_ModifyPlan_Weaving" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function expandcollapse(obj, row) {
            var div = document.getElementById(obj);
            var img = document.getElementById('img' + obj);
            
            if (div.style.display == "none") {
                div.style.display = "block";
                if (row == 'alt') {
                    img.src = "../Image/minus.png";
                }
                else {
                    img.src = "../Image/minus.png";
                }
                img.alt = "Close";
            }
            else {
                div.style.display = "none";
                if (row == 'alt') {
                    img.src = "../Image/plus.png";
                }
                else {
                    img.src = "../Image/plus.png";
                }
                img.alt = "Expand to show Order Details";
            }
        } 
    </script>
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label16" runat="server" Text="Modify Weaving plan"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 103px">
                <asp:Label ID="Label17" runat="server" Text="Order No"></asp:Label>
            </td>
            <td class="NormalText" style="width: 249px">
                <asp:TextBox ID="txtOrderNo" runat="server" Columns="20" CssClass="textbox" MaxLength="20"></asp:TextBox>
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 103px">
                <asp:Label ID="Label18" runat="server" Text="Sort No"></asp:Label>
            </td>
            <td class="NormalText" style="width: 249px">
                <asp:TextBox ID="txtSortNo" runat="server" Columns="20" CssClass="textbox" MaxLength="20"></asp:TextBox>
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                            OnClick="lnkFetch_Click">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc">Reset</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    
 <div>
        <asp:GridView ID="grdParent" runat="server" Width="100%" 
            AutoGenerateColumns="False" 
            EnableModelValidation="True" OnRowDataBound="grdParent_RowDataBound" 
            AllowPaging="True" onpageindexchanging="grdParent_PageIndexChanging">
            <AlternatingRowStyle CssClass="GridAI" />
            <HeaderStyle CssClass="GridHeader" />
            <PagerStyle CssClass="PagerStyle" />
            <RowStyle CssClass="GridItem" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href="javascript:expandcollapse('div<%# Eval("OrderNo") %>--<%# Eval("SortNo") %>>','one');">
                            <img id="imgdiv<%# Eval("OrderNo") %>--<%# Eval("SortNo") %>>" alt="Click to show/hide  for OrderNo <%# Eval("OrderNo") %>"
                                width="9px" border="0" src="../Image/minus.png" />
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Order No" SortExpression="OrderNo">
                    <ItemTemplate>
                        <asp:Label ID="lblOrderNo" Text='<%# Eval("OrderNo") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sort No" SortExpression="SortNo">
                    <ItemTemplate>
                        <asp:Label ID="lblSortNo" Text='<%# Eval("SortNo")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                   <asp:TemplateField HeaderText="Order Qty" SortExpression="OrderQty">
                    <ItemTemplate>
                        <asp:Label ID="lblOrderQty" Text='<%# Eval("OrderQty")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Greigh Req" SortExpression="GreighReq">
                    <ItemTemplate>
                        <asp:Label ID="lblGreighReq" Text='<%# Eval("GreighReq")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Greigh Adj" SortExpression="GreighAdj">
                    <ItemTemplate>
                        <asp:Label ID="lblGreighAdj" Text='<%# Eval("GreighAdj")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sizing Required" SortExpression="SizingRequired">
                    <ItemTemplate>
                        <asp:Label ID="lblSizing" Text='<%# Eval("SizingRequired")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Sizing Done" SortExpression="SizingDone">
                    <ItemTemplate>
                        <asp:Label ID="lblSizingDone" Text='<%# Eval("SizingDone")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sizing Remaining" SortExpression="SizingRem">
                    <ItemTemplate>
                        <asp:Label ID="lblSizingRem" Text='<%# Eval("SizingRem")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <tr>
                            <td colspan="100%">
                                <div id="div<%# Eval("OrderNo") %>--<%# Eval("SortNo") %>>"  position: relative; left: 15px; 
                                    overflow: auto; width: 97%">
                                    <asp:GridView ID="GridView2" AllowPaging="True" AllowSorting="true" BackColor="White"
                                        Width="100%" Font-Size="X-Small" AutoGenerateColumns="false" Font-Names="Verdana"
                                        runat="server" DataKeyNames="OrderNo" ShowFooter="true" BorderStyle="Double" PageSize="20"
                                        BorderColor="#0083C1" EmptyDataText="No Record Present" OnPageIndexChanging="GridView2_PageIndexChanging"
                                        OnRowUpdating="GridView2_RowUpdating" OnRowCommand="GridView2_RowCommand" OnRowEditing="GridView2_RowEditing"
                                        OnRowUpdated="GridView2_RowUpdated" OnRowCancelingEdit="GridView2_CancelingEdit"
                                        OnRowDataBound="GridView2_RowDataBound" OnRowDeleting="GridView2_RowDeleting"
                                        OnRowDeleted="GridView2_RowDeleted" OnSorting="GridView2_Sorting">
                                        <RowStyle BackColor="Gainsboro" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <HeaderStyle BackColor="#0083C1" ForeColor="White" />
                                        <FooterStyle BackColor="White" />
                                        <Columns>
                                            <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDelete" CommandName="Delete" runat="server">Delete</asp:LinkButton>
                                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="lnkDelete" ConfirmText="Are your Sure ?">
                                                    </cc1:ConfirmButtonExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="ID" SortExpression="ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblID" Text='<%# Eval("ID") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblID" Text='<%# Eval("ID") %>' runat="server"></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Order No" SortExpression="OrderNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrderNo" Text='<%# Eval("OrderNo") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblOrderNo" Text='<%# Eval("OrderNo") %>' runat="server"></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sort No" SortExpression="SortNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSortNo" Text='<%# Eval("SortNo") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblSortNo" Text='<%# Eval("SortNo") %>' runat="server"></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Line Item" SortExpression="Lineitem">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLineItem" Text='<%# Eval("Lineitem") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblLineItem" Text='<%# Eval("Lineitem") %>' runat="server"></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Weaving Sort" SortExpression="WeavingSort">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWeavingSort" Text='<%# Eval("WeavingSort") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                   
                                                      <asp:TextBox ID="txtWeavingSort" CssClass="textbox" MaxLength="15" Columns="10" Text='<%# Eval("WeavingSort") %>'
                                                        runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Order Qty" SortExpression="OrderQty">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrderQty" Text='<%# Eval("OrderQty") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblOrderQty" Text='<%# Eval("OrderQty") %>' runat="server"></asp:Label>
                                                       <asp:ImageButton ID="imgRefresh" runat="server"  ImageUrl="~/Image/refresh-icon.gif" CommandName="Refresh" CausesValidation="False" />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="CaseType" SortExpression="CaseType">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCaseType" Text='<%# Eval("CaseType") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlCaseType" CssClass="combobox" runat="server" AutoPostBack="True" 
                                                        DataSourceID="SqlDataSource1" DataTextField="CaseType" 
                                                        DataValueField="CaseType" 
                                                        onselectedindexchanged="ddlCaseType_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                                                        SelectCommand="Select '--Select--' as [CaseType] Union SELECT Distinct  [CaseType] FROM production..[JCT_Process_Greigh_Request_Variation] where GetDate() between Eff_from and Eff_To">
                                                    </asp:SqlDataSource>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Greigh Req" SortExpression="GreighReq">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGreighReq" Text='<%# Eval("GreighReq") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtGreighReq" CssClass="textbox" MaxLength="15" Columns="10"  Text='<%# Eval("GreighReq") %>'
                                                        runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Greigh Adj" SortExpression="GreighAdj">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGreighAdj" Text='<%# Eval("GreighAdj") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtGreighAdj" CssClass="textbox" MaxLength="15" Columns="10" Text='<%# Eval("GreighAdj") %>'
                                                        runat="server" AutoPostBack="True" 
                                                        ontextchanged="txtGreighAdj_TextChanged"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Greigh Rem" SortExpression="GreighRem">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGreighRem" Text='<%# Eval("GreighRem") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtGreighRem" CssClass="textbox" MaxLength="15" Columns="10" Text='<%# Eval("GreighRem") %>'
                                                        runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sizing" SortExpression="Sizing">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSizing" Text='<%# Eval("Sizing") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtSizing" CssClass="textbox" MaxLength="15" Columns="10" Text='<%# Eval("Sizing") %>'
                                                        runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="grdParent" EventName="RowEditing" />
            <asp:AsyncPostBackTrigger ControlID="grdParent" EventName="RowUpdating" />
            <asp:AsyncPostBackTrigger ControlID="grdParent" EventName="RowUpdated" />
            <asp:AsyncPostBackTrigger ControlID="grdParent" EventName="RowCommand" />
            <asp:AsyncPostBackTrigger ControlID="grdParent" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
   

    
   
</asp:Content>
