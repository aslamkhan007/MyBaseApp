<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="Re-Plan_PendingOrders.aspx.cs" Inherits="OPS_Re_Plan_PendingOrders" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<link href="js/reveal.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="http://code.jquery.com/jquery-1.6.min.js"></script>

    <script src="js/jquery.reveal.js" type="text/javascript"></script>
	
    <script src="js/jquery-1.4.3.min.js" type="text/javascript"></script>
    <style type="text/css">
        .web_dialog_overlay
        {
            position: fixed;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            height: 100%;
            width: 100%;
            margin: 0;
            padding: 0;
            background: #000000;
            opacity: .15;
            filter: alpha(opacity=15);
            -moz-opacity: .15;
            z-index: 101;
            display: none;
        }
        .web_dialog
        {
            display: none;
            position: fixed;
            width: 380px;
            height: 500px;
            top: 50%;
            left: 50%;
            margin-left: -190px;
            margin-top: -100px;
            background-color: #ffffff;
            border: 2px solid #336699;
            padding: 0px;
            z-index: 102;
            font-family: Verdana;
            font-size: 10pt;
        }
        .web_dialog_title
        {
            border-bottom: solid 2px #336699;
            background-color: #336699;
            padding: 4px;
            color: White;
            font-weight:bold;
        }
        .web_dialog_title a
        {
            color: White;
            text-decoration: none;
        }
        .align_right
        {
            text-align: right;
        }
    </style>
    <script type="text/javascript">

        $(document).ready(function () {
            $("#btnShowSimple").click(function (e) {
                ShowDialog(false);
                e.preventDefault();
            });

            $("#btnShowModal").click(function (e) {
                ShowDialog(true);
                e.preventDefault();
            });

            $("#btnClose").click(function (e) {
                HideDialog();
                e.preventDefault();
            });

            $("#btnSubmit").click(function (e) {
                var brand = $("#brands input:radio:checked").val();
                $("#output").html("<b>Your favorite mobile brand: </b>" + brand);
                HideDialog();
                e.preventDefault();
            });
        });

        function ShowDialog(modal) {
            $("#overlay").show();
            $("#dialog").fadeIn(300);

            if (modal) {
                $("#overlay").unbind("click");
            }
            else {
                $("#overlay").click(function (e) {
                    HideDialog();
                });
            }
        }

        function HideDialog() {
            $("#overlay").hide();
            $("#dialog").fadeOut(300);
        } 
        
    </script>
		<style type="text/css">
			body { font-family: "HelveticaNeue","Helvetica-Neue", "Helvetica", "Arial", sans-serif; }
			.big-link { display:block; }
		    .style6
            {
                font-family : Tahoma;
                font-size : 8pt;
                font-weight : bold;
                text-align : left;
                color : Black;
                display : block;
                margin-left: 0px;
                width: 208px;
            }
		</style>
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
  	
    <script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.8.24.custom.min.js" type="text/javascript"></script>


    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="5">
                <asp:Label ID="Label16" runat="server" Text="Pending Orders Re-Plan"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 83px">
                <asp:Label ID="Label21" runat="server" Text="Select Plant"></asp:Label>
            </td>
            <td class="style6">
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPlant" runat="server" AutoPostBack="True" 
                            CssClass="combobox" onselectedindexchanged="ddlPlant_SelectedIndexChanged">
                            <asp:ListItem>COTTON</asp:ListItem>
                            <asp:ListItem>TAFFETA</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
               
               </td>
            <td class="NormalText">
              
                 </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 83px">
                <asp:Label ID="Label17" runat="server" Text="Select PlanID"></asp:Label>
            </td>
            <td class="style6">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlPlanID" runat="server" CssClass="combobox" 
                    DataSourceID="SqlDataSource2" DataTextField="DESCRIPTION" 
                    DataValueField="PLANID">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    
                    SelectCommand="SELECT [PLANID],Upper([DESCRIPTION]) as Description FROM [JCT_OPS_PLANNING_GENERATE_PLANID] WHERE ([STATUS] = @STATUS) and Plant=@Plant ORDER BY [PLANID] ASC">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="A" Name="STATUS" Type="String" />
                          
                        <asp:ControlParameter ControlID="ddlPlant" DefaultValue="" Name="Plant" 
                            PropertyName="SelectedValue" />
                          
                    </SelectParameters>
                </asp:SqlDataSource>
                </ContentTemplate>
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlPlant" />
                </Triggers>
                </asp:UpdatePanel>
           
               
               </td>
            <td class="NormalText">
                 &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 83px">
                <asp:Label ID="Label18" runat="server" Text="New PlanID"></asp:Label>
            </td>
            <td class="style6">
                  <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="ddlNewPlan" runat="server" CssClass="combobox" 
                    DataSourceID="SqlDataSource1" DataTextField="DESCRIPTION" 
                    DataValueField="PLANID">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    
                        SelectCommand="SELECT [PLANID],Upper([DESCRIPTION]) as Description FROM [JCT_OPS_PLANNING_GENERATE_PLANID] WHERE ([STATUS] = @STATUS) and Plant=@Plant ORDER BY [PLANID] DESC">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="A" Name="STATUS" Type="String" />
                        <asp:ControlParameter ControlID="ddlPlant" DefaultValue="" Name="Plant" 
                            PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
                
                </ContentTemplate>
                
                </asp:UpdatePanel>
                </td>
            <td class="NormalText">
                 &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 83px">
                <asp:Label ID="Label19" runat="server" Text="Order No"></asp:Label>
            </td>
            <td class="style6">
               
                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                <asp:Label ID="Label20" runat="server" Text="Weaving Sort"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtWeavingSort" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="5">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                            onclick="lnkFetch_Click">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkRePlan" runat="server" CssClass="buttonc" 
                            onclick="lnkRePlan_Click">RePlan</asp:LinkButton>

                            <cc1:ConfirmButtonExtender ID="lnkRePlan_ConfirmButtonExtender" runat="server" 
                                ConfirmText="Are you sure you want to replan selected items ?" 
                                TargetControlID="lnkRePlan">
                            </cc1:ConfirmButtonExtender>

                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc">Reset</asp:LinkButton>
                          <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" 
                            onclick="lnkExcel_Click">Excel</asp:LinkButton>
                    </ContentTemplate>
                     <Triggers>
                        <asp:PostBackTrigger ControlID="lnkExcel" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText" style="width: 83px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        </table>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnlRePlan" runat="server" CssClass="panelbg">


        <asp:GridView ID="grdRePlan" AllowSorting="True" BackColor="White"
                                        Width="100%" Font-Size="X-Small" 
                                        AutoGenerateColumns="False" Font-Names="Verdana"
                                        runat="server" DataKeyNames="OrderNo" ShowFooter="True" 
                                        BorderStyle="Double"
                                        BorderColor="#0083C1" 
                                        EmptyDataText="No Record Present" OnPageIndexChanging="grdRePlan_PageIndexChanging" 
                                        EnableModelValidation="True" AllowPaging="True">
                                        <RowStyle BackColor="Gainsboro" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <HeaderStyle BackColor="#0083C1" ForeColor="White" />
                                        <FooterStyle BackColor="White" />
                                        <Columns>
                                        
                                   <asp:TemplateField>
                                       <HeaderTemplate>
                                           <asp:CheckBox ID="chbSelectAll" runat="server" AutoPostBack="True" 
                                               oncheckedchanged="chbSelectAll_CheckedChanged"  />
                                       </HeaderTemplate>
                                   <ItemTemplate>
                                   
                            <asp:CheckBox  runat="server" ID="chbSelect">
                                       </asp:CheckBox>

                                   </ItemTemplate>
                                       
                                   </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Stop">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkStop" CommandName="Stop" runat="server" 
                                                        onclick="lnkStop_Click">Stop</asp:LinkButton>
                                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="lnkStop" ConfirmText="Are your Sure ?">
                                                    </cc1:ConfirmButtonExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                       <asp:TemplateField HeaderText="PlanID" SortExpression="PlanID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPlanID" Text='<%# Eval("PlanID") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblPlanID" Text='<%# Eval("PlanID") %>' runat="server"></asp:Label>
                                                </EditItemTemplate>
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
                                                <asp:TemplateField HeaderText="ItemNo" SortExpression="ItemNo">
                                                <ItemTemplate>
                                                        <asp:Label ID="lblItemNo" Text='<%# Eval("ItemNo") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblItemNo" Text='<%# Eval("ItemNo") %>' runat="server"></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="WeavingSort" SortExpression="WeavingSort">
                                                <ItemTemplate>
                                                     <asp:TextBox ID="txtWeavingSort" CssClass="textbox" MaxLength="15" Columns="10"  
                                                        Text='<%# Eval("WeavingSort") %>' runat="server"></asp:TextBox>
                                                  
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                      <asp:TextBox ID="txtWeavingSort" CssClass="textbox" MaxLength="15" Columns="10"  
                                                        Text='<%# Eval("WeavingSort") %>' runat="server"></asp:TextBox>
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

                                            <asp:TemplateField HeaderText="Plan Qty" SortExpression="PlanQty">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPlanQty" Text='<%# Eval("PlanQty") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                 <asp:TextBox ID="txtPlanQty" CssClass="textbox" MaxLength="15" Columns="10"  
                                                        Text='<%# Eval("PlanQty") %>' runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>


                <asp:TemplateField HeaderText="Sizing Req" SortExpression="SizingRequired">
                    <ItemTemplate>
                      <asp:TextBox ID="txtSizing" CssClass="textbox" MaxLength="15" Columns="10" Text='<%# Eval("SizingReq") %>' runat="server"></asp:TextBox>
                        
                    </ItemTemplate>
                </asp:TemplateField>
                          <asp:TemplateField HeaderText="Sizing Done" SortExpression="SizingDone">
                    <ItemTemplate>
                    
                        <asp:Label ID="lblSizingDone" Text='<%# Eval("SizingDone") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 
                
                <asp:TemplateField HeaderText="Sizing Rem" SortExpression="SizingRem">
                    <ItemTemplate>
                      <asp:TextBox ID="lblSizingRem" CssClass="textbox" MaxLength="15" Columns="10" Text='<%# Eval("SizingRem") %>'  runat="server"></asp:TextBox>
                       
                    </ItemTemplate>
                </asp:TemplateField>         
                <asp:TemplateField HeaderText="Greige Rem" SortExpression="GreigeRem">
                    <ItemTemplate>
                      <asp:TextBox ID="txtGreigeRem" CssClass="textbox" MaxLength="15" Columns="10" Text='<%# Eval("GreigeRem") %>'  runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>         

                    <asp:TemplateField HeaderText="Shed">
                                       <ItemTemplate>
                                           <asp:DropDownList ID="ddlShed" CssClass="combobox" runat="server"  
                                               AutoPostBack="True" 
                                             
                                               SelectedValue='<%# Eval("Shed") %>' 
                                               onselectedindexchanged="ddlShed_SelectedIndexChanged"  >
                                                   <asp:ListItem Value="">Select</asp:ListItem>
                                                   <asp:ListItem Value="RP190">Rapier</asp:ListItem>
                                                   <asp:ListItem Value="AR190">Airjet</asp:ListItem>
                                                   <asp:ListItem Value="WP102">Waterjet Plain</asp:ListItem>
                                                   <asp:ListItem Value="WD12">Waterjet Dobby</asp:ListItem>
                                                   <asp:ListItem Value="WC38">Waterjet Cam</asp:ListItem>
                                                   <asp:ListItem Value="SA130">Sulzer A130</asp:ListItem>
                                                   <asp:ListItem Value="SA153">Sulzer A153</asp:ListItem>
                                                   <asp:ListItem Value="SB153">Sulzer B</asp:ListItem>
                                                   <asp:ListItem Value="SC130">Sulzer C130</asp:ListItem>
                                                   <asp:ListItem Value="SC153">Sulzer C153</asp:ListItem>
                                                   <asp:ListItem Value="SD153">Sulzer D</asp:ListItem>
                                                   <asp:ListItem Value="SE153">Sulzer E</asp:ListItem>
                                               <asp:ListItem Value="CON">Conventional</asp:ListItem>
                                           </asp:DropDownList>

                                       </ItemTemplate>
                                   </asp:TemplateField>
                                  <asp:TemplateField HeaderText="RPM">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtRPM" runat="server" Columns="4" MaxLength="5" 
                                               CssClass="textbox" Text='<%# Eval("RPM") %>' 
                                                AutoPostBack="True" ontextchanged="txtRPM_TextChanged"></asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Efficiency">
                                       <ItemTemplate>
                                                   <asp:TextBox ID="txtEfficiency" Columns="3" MaxLength="3" runat="server" 
                                                       Text='<%# Eval("Efficiency") %>' 
                                                       AutoPostBack="True" ontextchanged="txtEfficiency_TextChanged" ></asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Loom">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtLoomAllot" runat="server" Columns="3" MaxLength="4"  AutoPostBack="true"
                                               CssClass="textbox" Text='<%# Eval("Looms") %>' 
                                               ontextchanged="txtLoomAllot_TextChanged" > </asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Wvg Days">
                                       <ItemTemplate>
                                           <asp:Label ID="lblWvgDays" runat="server" 
                                               Text='<%# Eval("WvgDays") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                               
                                         
                                        </Columns>
                                    </asp:GridView>

        </asp:Panel>
    
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

