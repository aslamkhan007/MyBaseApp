 

<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="FinalPacking.aspx.vb" Inherits="Final" title="Final Packing Status" MaintainScrollPositionOnPostback="true" %>  


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
                Final Packing Changes</td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True"    AutoGenerateColumns="false"
                     PageSize="31"   width="100%" GridLines="None"  CssClass="GridViewStyle" 
                     
                    EnableModelValidation="True" OnRowCreated="GridView1_RowCreated">
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" />
                    <Columns>


                   
                    <asp:BoundField DataField="MonthDate" HeaderText="MonthDate"/>
                    

                     <asp:BoundField DataField="INS_RTD" HeaderText="IN"/>

                    <asp:BoundField DataField="OUTS_RTD" HeaderText="OUT"/>

                    <asp:BoundField DataField="DODPer_RTD" HeaderText="%"/>

                     <asp:BoundField DataField="INS_PA" HeaderText="IN"/>

                    <asp:BoundField DataField="OUTS_PA" HeaderText="OUT"/>

                    <asp:BoundField DataField="DODPer_PA" HeaderText="%"/>

                    
                      <asp:BoundField DataField="INS_PP" HeaderText="IN"/>

                    <asp:BoundField DataField="OUTS_PP" HeaderText="OUT"/>

                    <asp:BoundField DataField="DODPer_PP" HeaderText="%"/>


                   

                    <asp:BoundField DataField="INS_ICP" HeaderText="IN"/>

                    <asp:BoundField DataField="OUTS_ICP" HeaderText="OUT"/>

                    <asp:BoundField DataField="DODPer_ICP" HeaderText="%"/>


                     <asp:BoundField DataField="INS_WIP" HeaderText="IN"/>

                    <asp:BoundField DataField="OUTS_WIP" HeaderText="OUT"/>

                    <asp:BoundField DataField="DODPer_WIP" HeaderText="%"/>
                                        
                     <asp:BoundField DataField="INS_PFWIP" HeaderText="IN"/>

                    <asp:BoundField DataField="OUTS_PFWIP" HeaderText="OUT"/>

                    <asp:BoundField DataField="DODPer_PFWIP" HeaderText="%"/>

                          <asp:BoundField DataField="INS_FAB" HeaderText="IN"/>

                    <asp:BoundField DataField="OUTS_FAB" HeaderText="OUT"/>

                    <asp:BoundField DataField="DODPer_FAB" HeaderText="%"/>

                    </Columns>
                  
    <RowStyle CssClass="RowStyle" />

    <EmptyDataRowStyle CssClass="EmptyRowStyle" />

    <PagerStyle CssClass="PagerStyle" />

    <SelectedRowStyle CssClass="SelectedRowStyle" />

    <HeaderStyle CssClass="HeaderStyle" />

    <EditRowStyle CssClass="EditRowStyle" />

    <AlternatingRowStyle CssClass="AltRowStyle" />


                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

