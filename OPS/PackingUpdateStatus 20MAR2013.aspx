<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="PackingUpdateStatus.aspx.vb" Inherits="PackingUpdateStatus" title="Packing Update Status" MaintainScrollPositionOnPostback="true" %>  


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script language="javascript" type="text/javascript">
        // <!CDATA[

        function TABLE1_onclick() {

        }

        // ]]>
</script>

    <table style="width:100%">
        <tr>
            <td class="tableheader" colspan="5">
                Packing Update Status</td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
     
        
            <td class="labelcells" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:RadioButtonList ID="rblSelection" runat="server" AutoPostBack="True" 
                            RepeatDirection="Horizontal" Width="340px">
                            <asp:ListItem>Pack Stock</asp:ListItem>
                            <asp:ListItem>Comments</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:Label ID="txtTotal" runat="server" ForeColor="#FF3300"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
     
        
            <td class="labelcells">
                Date From</td>
            <td class="NormalText"  >
                        <asp:UpdatePanel ID="UpdFrom" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox  ID="TxtDateFrom" TabIndex="3" runat="server" Width="70px"
                            CssClass="textbox" Enabled="True" MaxLength="8" AutoPostBack="True" ></asp:TextBox>
                        <cc1:MaskedEditValidator ID="MEV2" runat="server" Width="114px" 
                            ControlToValidate="TxtDateFrom"
                            Display="Dynamic"  
                            ControlExtender="MEE2" 
                            TooltipMessage="MM/DD/YYYY"
                            IsValidEmpty="False" 
                            EmptyValueMessage="*" 
                          
                            InvalidValueMessage="The Date is invalid" ValidationGroup="A"></cc1:MaskedEditValidator>
                          
                          <cc1:CalendarExtender
                                ID="CalendarExtender1" runat="server" TargetControlID="TxtDateFrom" Animated="False" Format="MM/dd/yyyy">
                            </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MEE2" runat="server" TargetControlID="TxtDateFrom"
                            MaskType="Date" Mask="99/99/9999">
                        </cc1:MaskedEditExtender>
                      
                    </ContentTemplate>
                             
                </asp:UpdatePanel>
                        </td>
            <td class="labelcells" >
                Date To</td>
            <td style="height: 16px">
                                     <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox  ID="txtDateTo" TabIndex="3" runat="server" Width="70px"
                            CssClass="textbox" Enabled="True" MaxLength="8" ></asp:TextBox>
                        <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" Width="114px" 
                            ControlToValidate="txtDateTo"
                            Display="Dynamic" 
                            ControlExtender="MEE3" 
                            TooltipMessage="MM/DD/YYYY"
                              IsValidEmpty="False" 
                            EmptyValueMessage="*" 
                          
                            InvalidValueMessage="The Date is invalid" ValidationGroup="A"></cc1:MaskedEditValidator>
                          
                          <cc1:CalendarExtender
                                ID="CalendarExtender2" runat="server" TargetControlID="txtDateTo" Animated="False" Format="MM/dd/yyyy">
                            </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MEE3" runat="server" TargetControlID="txtDateTo"
                            MaskType="Date" Mask="99/99/9999">
                        </cc1:MaskedEditExtender>
                      
                    </ContentTemplate>
                                       
                </asp:UpdatePanel></td>
        </tr>
        <tr>
            <td class="labelcells">
                Sale Person</td>
            <td class="NormalText" >
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="txtSalePerson" runat="server" CssClass="combobox" AutoPostBack="true">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>ALL</asp:ListItem>
                                    <asp:ListItem>ASHOK KAUSHAL</asp:ListItem>
                                    <asp:ListItem>AJAY SINGH</asp:ListItem>
                                     <asp:ListItem>AJAY KUMAR</asp:ListItem>
                                    <asp:ListItem>ASHARFI KUMAR MAHATO</asp:ListItem>
                                    <asp:ListItem>JASPAL RANA</asp:ListItem>
                                    <asp:ListItem>MANMOHAN BHATIA</asp:ListItem>
                                    <asp:ListItem>NEERAJ KAUSHAL</asp:ListItem>
                                    <asp:ListItem>PANKAJ SHARMA</asp:ListItem>
                                    <asp:ListItem>PUSHP RAJ JAIN</asp:ListItem>
                                    <asp:ListItem>ROHIT MAHAJAN</asp:ListItem>
                                    <asp:ListItem>SUNIL KAPOOR</asp:ListItem>
                                    <asp:ListItem>SUNIL MAHENDRU</asp:ListItem>
                                    <asp:ListItem>SUNIL JOSHI</asp:ListItem>
                                    <asp:ListItem>SANJAY SINGH</asp:ListItem>
                                    <asp:ListItem>VANDANA</asp:ListItem>
                                    <asp:ListItem>VIKRAMJEET SINGH</asp:ListItem>
                                    <asp:ListItem>SAMPLES</asp:ListItem>
                                    <asp:ListItem>REJECTED</asp:ListItem>
                                     <asp:ListItem>TAFETTA REMNANT</asp:ListItem>
                                      <asp:ListItem>REMNANT</asp:ListItem>
                                    <asp:ListItem>Y.P.SHARMA</asp:ListItem>
                                       
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        </td>
            <td class="labelcells">
                Status</td>
            <td style="height: 16px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="txtRemarks" runat="server" CssClass="combobox" 
                             DataSourceID="SqlDataSource2" DataTextField="Catogories" 
                            DataValueField="Catogories" >
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Item Group</td>
            <td class="NormalText" >
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtItemGroup" runat="server" 
                                AutoPostBack="True" CssClass="textbox" 
                                TabIndex="2" MaxLength="6"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        
            </td>
            <td class="labelcells">
                Variant</td>
            <td style="height: 16px">
                        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="txtVariant" runat="server" CssClass="combobox">
                                    <asp:ListItem></asp:ListItem>
                                     
                                    <asp:ListItem>CH</asp:ListItem>
                                    <asp:ListItem>FN</asp:ListItem>
                                    <asp:ListItem>FR</asp:ListItem>
                                    <asp:ListItem>RG</asp:ListItem>
                                    <asp:ListItem>SF</asp:ListItem>
                                    <asp:ListItem>SLP</asp:ListItem>
                                    <asp:ListItem>SM</asp:ListItem>
                                    <asp:ListItem>SO</asp:ListItem>
                                    <asp:ListItem>SP</asp:ListItem>
                                    <asp:ListItem>ST</asp:ListItem>
                                   <asp:ListItem>SW</asp:ListItem>
                                 
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Customer</td>
            
                              <td class="NormalText" style="width: 198px">

                    <div id="divwidth" style="display:none;">   
                        </div>
                              
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                         
                        <asp:DropDownList ID="txtCustomer" runat="server" CssClass="combobox">
                            
                        </asp:DropDownList>
                         
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtSalePerson" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                      
                        
                        
            </td>



 
            <td class="labelcells" >
                Order No</td>
            <td>
                 
                                 <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                     <ContentTemplate>
                                         <asp:TextBox ID="TxtOrder" runat="server" AutoPostBack="True" 
                                             CssClass="textbox" TabIndex="2" Width="200"></asp:TextBox>
                                 
                                         <cc1:TextBoxWatermarkExtender ID="TxtOrder_TextBoxWatermarkExtender" 
                                             runat="server" TargetControlID="TxtOrder" WatermarkCssClass="normalfld" 
                                             WatermarkText="ALL">
                                         </cc1:TextBoxWatermarkExtender>
                                     </ContentTemplate>
                                 </asp:UpdatePanel>
                        
                        
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Shade</td>
            
                              <td class="NormalText" style="width: 198px">

                <asp:UpdatePanel ID="UpdatePanel15" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                         
                        <asp:DropDownList ID="txtShade" runat="server" CssClass="combobox">
                            
                        </asp:DropDownList>
                         
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtSalePerson" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                      
                        
                        
            </td>



 
            <td class="labelcells" >
                &nbsp;</td>
            <td>
                 
                                 &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 11px; text-align: center;" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:Button ID="BtnGet" runat="server" BackColor="Black" 
                              CssClass="ButtonBack" Text="Fetch" ValidationGroup="A" />
                        <asp:Button ID="BtnExcel" runat="server" BackColor="Black" 
                            CausesValidation="False" CssClass="ButtonBack" Text="Excel" />
                        <asp:Button ID="BtnClear" runat="server" BackColor="Black" 
                            CausesValidation="False" CssClass="ButtonBack" Text="Clear" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            
        </tr>
        <tr>
            <td class="tableheader" style="height: 30px" colspan="4">
                Satus For Update</td>
            
        </tr>
        </table>
    <table style="width: 100%" class="tableback">
        <tr>
            <td style="width: 99px" class="labelcells">
                Change Status </td>
            <td class="textcells" colspan="5">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="txtRemarksToUpdate" runat="server" AutoPostBack="True" 
                            CssClass="combobox" DataSourceID="SqlDataSource2" DataTextField="Catogories" 
                            DataValueField="Catogories">
                   <%-- <asp:ListItem></asp:ListItem>--%>
                   <%-- <asp:ListItem>ALL</asp:ListItem>
                          <asp:ListItem>ALL</asp:ListItem>
                           <asp:ListItem>APPROVAL AWAITED </asp:ListItem>
                            <asp:ListItem>BACK GREY</asp:ListItem>
                            <asp:ListItem>DEFENCE</asp:ListItem>
                            <asp:ListItem>DEVELOPMENT SAMPLES</asp:ListItem>
                            <asp:ListItem>DOMESTIC/LOCAL</asp:ListItem>
                            <asp:ListItem>EXCESS/COTODS</asp:ListItem>
                             <asp:ListItem>FRC</asp:ListItem> 
                            <asp:ListItem>GARMENTING</asp:ListItem>
                            <asp:ListItem>HOLD</asp:ListItem>
                            <asp:ListItem>INCOMPLETE ORDER</asp:ListItem>
                            <asp:ListItem>LIABILITY - STOCK SALE</asp:ListItem>
                            <asp:ListItem>N/A</asp:ListItem>
                            <asp:ListItem>ORDER CANCELLED</asp:ListItem>
                            <asp:ListItem>OUTSOURCED</asp:ListItem>
                             <asp:ListItem>QA STOCK</asp:ListItem>
                            <asp:ListItem>READY FOR DESPATCH</asp:ListItem>
                            <asp:ListItem>REJECTED</asp:ListItem>
                            <asp:ListItem>REMINANT</asp:ListItem>
                            <asp:ListItem>SAMPLE SURPLUS</asp:ListItem>
                            <asp:ListItem>TAFETTA REMNANT</asp:ListItem>
                            <asp:ListItem>PAYMENT AWAITED</asp:ListItem>
                            <asp:ListItem>TAFFETA</asp:ListItem>
                            <asp:ListItem>YARN STOCK</asp:ListItem>--%>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                            SelectCommand="  SELECT '' AS Catogories  UNION  SELECT UPPER(Catogories) + '--' + UPPER(SubCatogories) AS Catogories  FROM JCT_OPS_PACKED_STOCK_REASON   ORDER BY  Catogories ">
                        </asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
               </td>
                   </asp:UpdatePanel>
        </tr>
        <tr>
            <td style="width: 99px; color: #FF0000; height: 26px;" class="labelcells">
                Definitions</td>
            <td style="height: 26px;" class="textcells" colspan="5">
                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 99px; height: 27px;" class="labelcells">
                Change&nbsp; Date</td>
            <td style="width: 93px; height: 27px;" class="textcells">
                        <asp:UpdatePanel ID="From" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox  ID="txtDate" TabIndex="3" runat="server" Width="70px"
                            CssClass="textbox" Enabled="True" MaxLength="8" ></asp:TextBox>
                        <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" Width="114px" 
                            ControlToValidate="txtDate"
                            Display="Dynamic" 
                            ControlExtender="MaskedEditExtender1" 
                            TooltipMessage="MM/DD/YYYY"
                            IsValidEmpty="False" 
                            EmptyValueMessage="*" 
                            InvalidValueMessage="The Date is invalid"
                             ValidationGroup="B">
                          </cc1:MaskedEditValidator>
                          
                          <cc1:CalendarExtender
                                ID="CalFrom" runat="server" TargetControlID="txtDate" Animated="False" Format="MM/dd/yyyy" PopupPosition="TopRight">
                            </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDate"
                            MaskType="Date" Mask="99/99/9999">
                        </cc1:MaskedEditExtender>
                      
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 100px; height: 27px;" class="labelcells">
                        Comments</td>
            <td cssclass="textcells" style="width: 242px; height: 27px;">
                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="TxtComments" runat="server" AutoPostBack="True" 
                            CssClass="textbox" TabIndex="2" Width="200"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        
                         
                    </td>
            <td cssclass="textcells" style="text-align: right; height: 27px;">
                        </td>
            <td cssclass="textcells" style="height: 27px">
                        </td>
        </tr>
        <tr>
            <td colspan="6" style="text-align: center">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:Button ID="btnUpdate" runat="server" BackColor="Black" 
                            CssClass="ButtonBack" Text="Update" ValidationGroup="B" />
                        <asp:Button ID="Check" runat="server" BackColor="Black" CssClass="ButtonBack" 
                            Text="Check" />
                        <asp:Button ID="UnCheck" runat="server" BackColor="Black" CssClass="ButtonBack" 
                            Text="UnCheck" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="6">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <img alt="" src="../CostingSystemTest/Image/loading.gif" 
    style="width: 70px; height: 10px" />
                        &nbsp;
                        <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="Please Wait..."></asp:Label>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <%-- <asp:ListItem>ALL</asp:ListItem>
                          <asp:ListItem>ALL</asp:ListItem>
                           <asp:ListItem>APPROVAL AWAITED </asp:ListItem>
                            <asp:ListItem>BACK GREY</asp:ListItem>
                            <asp:ListItem>DEFENCE</asp:ListItem>
                            <asp:ListItem>DEVELOPMENT SAMPLES</asp:ListItem>
                            <asp:ListItem>DOMESTIC/LOCAL</asp:ListItem>
                            <asp:ListItem>EXCESS/COTODS</asp:ListItem>
                             <asp:ListItem>FRC</asp:ListItem> 
                            <asp:ListItem>GARMENTING</asp:ListItem>
                            <asp:ListItem>HOLD</asp:ListItem>
                            <asp:ListItem>INCOMPLETE ORDER</asp:ListItem>
                            <asp:ListItem>LIABILITY - STOCK SALE</asp:ListItem>
                            <asp:ListItem>N/A</asp:ListItem>
                            <asp:ListItem>ORDER CANCELLED</asp:ListItem>
                            <asp:ListItem>OUTSOURCED</asp:ListItem>
                             <asp:ListItem>QA STOCK</asp:ListItem>
                            <asp:ListItem>READY FOR DESPATCH</asp:ListItem>
                            <asp:ListItem>REJECTED</asp:ListItem>
                            <asp:ListItem>REMINANT</asp:ListItem>
                            <asp:ListItem>SAMPLE SURPLUS</asp:ListItem>
                            <asp:ListItem>TAFETTA REMNANT</asp:ListItem>
                            <asp:ListItem>PAYMENT AWAITED</asp:ListItem>
                            <asp:ListItem>TAFFETA</asp:ListItem>
                            <asp:ListItem>YARN STOCK</asp:ListItem>--%>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server" >
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                            CssClass="GridViewStyle" EnableModelValidation="True" GridLines="None" 
                            PageSize="150000" width="100%">
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" />
                            <Columns>
                                <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" Font-Names="Tahoma" 
                                            Font-Size="8pt" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="RowStyle" />
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <PagerStyle CssClass="PagerStyle" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <EditRowStyle CssClass="EditRowStyle" />
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                <%-- <asp:ListItem>ALL</asp:ListItem>
                          <asp:ListItem>ALL</asp:ListItem>
                           <asp:ListItem>APPROVAL AWAITED </asp:ListItem>
                            <asp:ListItem>BACK GREY</asp:ListItem>
                            <asp:ListItem>DEFENCE</asp:ListItem>
                            <asp:ListItem>DEVELOPMENT SAMPLES</asp:ListItem>
                            <asp:ListItem>DOMESTIC/LOCAL</asp:ListItem>
                            <asp:ListItem>EXCESS/COTODS</asp:ListItem>
                             <asp:ListItem>FRC</asp:ListItem> 
                            <asp:ListItem>GARMENTING</asp:ListItem>
                            <asp:ListItem>HOLD</asp:ListItem>
                            <asp:ListItem>INCOMPLETE ORDER</asp:ListItem>
                            <asp:ListItem>LIABILITY - STOCK SALE</asp:ListItem>
                            <asp:ListItem>N/A</asp:ListItem>
                            <asp:ListItem>ORDER CANCELLED</asp:ListItem>
                            <asp:ListItem>OUTSOURCED</asp:ListItem>
                             <asp:ListItem>QA STOCK</asp:ListItem>
                            <asp:ListItem>READY FOR DESPATCH</asp:ListItem>
                            <asp:ListItem>REJECTED</asp:ListItem>
                            <asp:ListItem>REMINANT</asp:ListItem>
                            <asp:ListItem>SAMPLE SURPLUS</asp:ListItem>
                            <asp:ListItem>TAFETTA REMNANT</asp:ListItem>
                            <asp:ListItem>PAYMENT AWAITED</asp:ListItem>
                            <asp:ListItem>TAFFETA</asp:ListItem>
                            <asp:ListItem>YARN STOCK</asp:ListItem>--%>
            </td>
        </tr>
    </table>
</asp:Content>