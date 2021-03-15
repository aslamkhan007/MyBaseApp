<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="ExcessBudgetsanction.aspx.cs" Inherits="OPS_ExcessBudgetsanction" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
      var counter = 0;
      function AddFileUpload() {
          var div = document.createElement('DIV');
          div.innerHTML = '<input id="file' + counter + '" name = "file' + counter + '" type="file" /><input id="Button' + counter + '" type="button" value="Remove" onclick = "RemoveFileUpload(this)" />';
          document.getElementById("FileUploadContainer").appendChild(div);
          counter++;
      }
      function RemoveFileUpload(div) {
          document.getElementById("FileUploadContainer").removeChild(div.parentNode);
      }
      function add_onclick() {

      }

      function Button2_onclick() {

      }

 </script>
  
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Excess Budget Sanction</td>
        </tr>
        <tr runat="server" visible="false">
               <td class="NormalText">
                Department</td>
            <td class="NormalText"><%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>--%>
                <asp:DropDownList ID="ddldept" runat="server" CssClass="combobox"
                    ontextchanged="ddldept_TextChanged" 
                    AutoPostBack="True" AppendDataBoundItems="True" 
                    onselectedindexchanged="ddldept_SelectedIndexChanged">
                    <asp:ListItem Selected="True"></asp:ListItem>
                </asp:DropDownList>
                <%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>--%>
            </td>
               <td class="NormalText">
                   &nbsp;</td>
            <td class="NormalText">
                <%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>--%>
                <asp:Label ID="lblBudgetID" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
               <td class="NormalText">
                   <asp:Label ID="Label16" runat="server" Text="HOD"></asp:Label>
               </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlhod" runat="server" CssClass="combobox" >
                </asp:DropDownList>
            </td>
               <td class="NormalText">
                   &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
               <td class="NormalText">
                   Sub-Department</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlsubdept" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlsubdept_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
               <td class="NormalText">
                   Budget Type</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddltype" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddltype_SelectedIndexChanged">
                    <asp:ListItem>Inventory</asp:ListItem>
                    <asp:ListItem>Repair</asp:ListItem>
                </asp:DropDownList>
               </td>
        </tr>
        <tr>
            <td class="NormalText">
                Budget Amount</td>
            <td class="NormalText">
                <asp:TextBox ID="txtbudamt" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtbudamt_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtbudamt" 
                    ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td class="NormalText">
                Balance Amount</td>
            <td class="NormalText">
                <asp:TextBox ID="txtbalamt" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtbalamt_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtbalamt" 
                    ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Indent Amount</td>
            <td class="NormalText">
                <asp:TextBox ID="txtindentamt" runat="server" CssClass="textbox" 
                    AutoPostBack="True"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtindentamt_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtindentamt" 
                    ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td class="NormalText">
                Indent No</td>
            <td class="NormalText">
                <asp:TextBox ID="txtindentno" runat="server" CssClass="textbox" AutoPostBack="True" 
                    ontextchanged="txtindentno_TextChanged"></asp:TextBox>
                <asp:LinkButton ID="LinkButton1" runat="server" BorderStyle="None" 
                    CssClass="searchbluesmall" Height="16px" onclick="LinkButton1_Click" 
                    Width="16px" Visible="False"></asp:LinkButton>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtindentno" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Sanction Amount</td>
            <td class="NormalText">
                <asp:TextBox ID="txtexcessamt" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtexcessamt_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtexcessamt" 
                    ValidChars=".01234567890">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td class="NormalText">
                   Group Code</td>
            <td class="NormalText">
               
                      <asp:DropDownList ID="ddlgroupcode" runat="server" CssClass="combobox" 
                        DataSourceID="SqlDataSource3" DataTextField="group_description" 
                        DataValueField="group_code">
                        <asp:ListItem Value="D">Dye</asp:ListItem>
                        <asp:ListItem>Chemical</asp:ListItem>
                        <asp:ListItem Value="SI">StoreItem</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                        SelectCommand="SELECT group_description,group_code FROM miserp.reportdb.dbo.jct_budget_group_master">
                    </asp:SqlDataSource>

            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Remarks</td>
            <td class="NormalText" colspan="3">
                <asp:TextBox ID="txtremarks" runat="server" CssClass="textbox" 
                    TextMode="MultiLine" Width="359px" Height="59px"></asp:TextBox>
            </td>
        </tr>
        <tr>
      
             <td class="NormalText" colspan="4">
              <asp:FileUpload ID="FileUpload1" runat="server" Width="0px" 

                      AllowMultiple="true"  Height="0px"  />

   
        <br />
                <%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>--%>
   <input id="Button2" onclick="AddFileUpload()" type="button" value="Attach files" onclick="return Button2_onclick()"
        onclick="return Button2_onclick()" <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="apply" Visible="false" />
    <div id="FileUploadContainer">
    </div>

    <div>
    
    </div>

                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:GridView ID="grdDetail" runat="server" Width="100%">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PageStyle" />
                    <RowStyle CssClass="GridItem" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="Lnkapply" runat="server" CssClass="buttonc" 
                    onclick="Lnkapply_Click" ValidationGroup="A">Apply</asp:LinkButton>
                <asp:LinkButton ID="Lnkcancel" runat="server" CssClass="buttonc" 
                    onclick="Lnkcancel_Click">Cancel</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>

