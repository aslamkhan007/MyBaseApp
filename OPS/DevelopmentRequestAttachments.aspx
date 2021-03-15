<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="DevelopmentRequestAttachments.aspx.cs" Inherits="OPS_DevelopmentRequestAttachments" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<%--<telerik:RadScriptManager runat="server" ID="RadScriptManager1" />--%>
 <telerik:RadSkinManager ID="QsfSkinManager" runat="server" />
    <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />


    <table style="width:100%;">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label16" runat="server" Text="Development Request Attachment"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Label ID="Label17" runat="server" Text="List of all authorized requests"></asp:Label>
            </td>
        </tr>
    </table>

    <table style="width:100%;">
        <tr>
            <td class="NormalText">
              
              <telerik:RadGrid OnItemCreated="RadGrid1_ItemCreated" ID="RadGrid1" runat="server"
                    AllowPaging="True" Width="97%" onneeddatasource="RadGrid1_NeedDataSource" AllowFilteringByColumn="True"
                    AllowSorting="True" CellSpacing="0" GridLines="None"  Skin="Telerik" 
                    onprerender="RadGrid1_PreRender" onitemdatabound="RadGrid1_ItemDataBound" 
                    onselectedindexchanged="RadGrid1_SelectedIndexChanged">

            <PagerStyle Mode="NumericPages"></PagerStyle>
                  <ClientSettings>
                      <Selecting AllowRowSelect="True" />
                  </ClientSettings>
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="RequestID" ClientDataKeyNames="RequestID"
                Width="100%" CommandItemDisplay="Top" PageSize="5">

            <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false"></CommandItemSettings>
            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
            <Columns>
               <telerik:GridButtonColumn Text="Select" CommandName="Select">
                </telerik:GridButtonColumn>
                <telerik:GridBoundColumn DataField="RequestID"  HeaderText="RequestID" ReadOnly="True"   FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="EqualTo"
                    FilterDelay="2000" ShowFilterIcon="true"
                    SortExpression="RequestID" UniqueName="RequestID">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="RequestedBy" HeaderText="RequestedBy" SortExpression="RequestedBy"
                    UniqueName="RequestedBy" FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="EqualTo"
                    FilterDelay="2000" ShowFilterIcon="true" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="DESCRIPTION" HeaderText="DESCRIPTION" SortExpression="DESCRIPTION"  ShowFilterIcon="false" AllowFiltering="false"
                    UniqueName="DESCRIPTION">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Devlopment" HeaderText="Development" SortExpression="Devlopment"  ShowFilterIcon="false" AllowFiltering="false"
                    UniqueName="Devlopment">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="SortNo" HeaderText="SortNo" SortExpression="SortNo" FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="EqualTo"
                    FilterDelay="2000" ShowFilterIcon="true"
                    UniqueName="SortNo">
                </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="Req_Mtrs" HeaderText="Req_Mtrs" SortExpression="Req_Mtrs" ShowFilterIcon="false" AllowFiltering="false"
                    UniqueName="Req_Mtrs">
                </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="Finish" HeaderText="Finish" SortExpression="Finish"  FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="EqualTo"
                    FilterDelay="2000" ShowFilterIcon="true"
                    UniqueName="Finish">
                </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="no_of_shades" HeaderText="no_of_shades" SortExpression="no_of_shades"  FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="EqualTo"
                    FilterDelay="2000" ShowFilterIcon="true"
                    UniqueName="no_of_shades">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Segment" HeaderText="Segment" SortExpression="Segment"  FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="EqualTo"
                    FilterDelay="2000" ShowFilterIcon="true"
                    UniqueName="Segment">
                </telerik:GridBoundColumn>
             
            </Columns>
      
<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>

        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
  
        </MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
    </telerik:RadGrid>
              
              
              </td>
        </tr>
        <tr>
            
        <td class="NormalText">

            &nbsp;</td>
        </tr>
        <tr>
            
        <td class="NormalText">

            Attach Files :</td>
        </tr>
        <tr>
            
        <td class="NormalText">

         <div class="qsf-demo-canvas">

          <telerik:RadAsyncUpload runat="server" ID="AsyncUpload1" OnClientFileUploaded="fileUploaded"
               MultipleFileSelection="Automatic" TemporaryFolder="~\OPS\Uploads\" />
 
          </div>

         <asp:Button ID="buttonSubmit" runat="server" OnClick="ButtonSubmitClick" Text="Submit"></asp:Button>
         <asp:Label ID="lblMessage" runat="server"   Text=""></asp:Label>
        </td>
        </tr>
    </table>

   <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
          <script type="text/javascript">
          //<![CDATA[

              var fileList = null,
                    fileListUL = null;

              function fileUploaded(sender, args) {
                  var name = args.get_fileName(),
                         li = document.createElement("li");

                  if (fileList == null) {
                      fileList = document.getElementById("exFileList");
                      fileListUL = document.createElement("ul");
                      fileList.appendChild(fileListUL);

                      fileList.style.display = "block";
                  }

                  li.innerHTML = name;
                  fileListUL.appendChild(li);
              }
          //]]>
          </script>
     </telerik:RadScriptBlock>
</asp:Content>

