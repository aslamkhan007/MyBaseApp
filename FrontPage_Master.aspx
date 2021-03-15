<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="FrontPage_Master.aspx.vb" Inherits="FrontPage_Master" title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" cellspacing="0">
        <tr>
        
            <td style="text-align: left; background-image: url('Image/Frame/Frame_Vertical_Back.png');" 
                class="tableheader" colspan="4" title="Home Page Item Master">
                <asp:Label ID="Label1" runat="server" BorderColor="Transparent" 
                    Font-Bold="True" Font-Names="Trebuchet MS" Font-Size="10pt" 
                    Text="Item Master"></asp:Label>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                </td>
        </tr>
        <tr>
        <td style="width: 111px; text-align: left; " class="labelcells">
                <asp:Label ID="lblItemcateg" runat="server" Text="Item Category"></asp:Label>
            </td>
            <td style="width: 275px; text-align: left; " class="textcells">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                  <ContentTemplate>
                                       <asp:DropDownList ID="ddlItemcateg" runat="server" CssClass="combobox" 
                              Height="19px" Width="91px">
                              <asp:ListItem>MenuItem</asp:ListItem>
                              <asp:ListItem>ItemText</asp:ListItem>
                              <asp:ListItem>Frame</asp:ListItem>
                          </asp:DropDownList>
         
                  </ContentTemplate>
            </asp:UpdatePanel>
            </td>
              <td style="width: 104px; text-align: left; " class="labelcells">
          
                  </td>
            <td style="width: 249px; text-align: left; ">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 111px; text-align: left; " class="labelcells">
          
                <asp:Label ID="lblItemCode" runat="server" Text="Item Code"></asp:Label>
            </td>
            <td style="width: 275px; text-align: left; " valign="top" 
                class="textcells">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          
             <ContentTemplate>
                <asp:TextBox ID="txtItemCode" runat="server" CssClass="textbox" Width="85px" 
                     MaxLength="15"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="Err3" runat="server" 
                     ControlToValidate="txtItemCode" ErrorMessage="*" 
                     SetFocusOnError="True"></asp:RequiredFieldValidator>
                 </ContentTemplate>
                  </asp:UpdatePanel>
            </td>
            <td style="text-align: left; width: 104px; " class="labelcells">
                <asp:Label ID="lblPItemCode" runat="server" Text="Parent Item Code" 
                    Width="100px"></asp:Label>
            </td>
            <td style="text-align: left; width: 249px;" class="textcells">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                 <ContentTemplate>
                <asp:TextBox ID="txtPItemCode" runat="server" CssClass="textbox" MaxLength="15" 
                         Width="85px"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="Err5" runat="server" 
                         ControlToValidate="txtPItemCode" ErrorMessage="*" 
                         SetFocusOnError="True"></asp:RequiredFieldValidator>
                     <cc1:HoverMenuExtender ID="HoverMenuExtender1" runat="server" 
                         TargetControlID="txtPItemCode" PopupControlID="panel3" 
                         PopupPosition="Left">
                     </cc1:HoverMenuExtender>
                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 111px; text-align: left; height: 12px;" class="labelcells">
                <asp:Label ID="lblSdesc" runat="server" Text="Short Description" 
                    style="text-align: left"></asp:Label>
            </td>
            <td style="width: 275px; text-align: left; height: 12px;" valign="top" 
                class="textcells">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
               <ContentTemplate>
                <asp:TextBox ID="txtSDesc" runat="server" CssClass="textbox" Width="85px" 
                       MaxLength="30"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="Err6" runat="server" 
                       ControlToValidate="txtSDesc" ErrorMessage="*" 
                       SetFocusOnError="True"></asp:RequiredFieldValidator>
                </ContentTemplate>
                 </asp:UpdatePanel>
            </td>
            <td style="text-align: left; width: 104px; height: 12px;" class="labelcells">
                <asp:Label ID="lblLDesc" runat="server" Text="Long Description"></asp:Label>
            </td>
            <td style="text-align: left; height: 12px; width: 249px;" class="textcells">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                 <ContentTemplate>
                <asp:TextBox ID="txtLDesc" runat="server" CssClass="textbox" 
                    TextMode="MultiLine" Width="83%" MaxLength="5000" Height="25px"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="Err7" runat="server" 
                     ErrorMessage="*" SetFocusOnError="True" 
                         ControlToValidate="txtLDesc"></asp:RequiredFieldValidator>
                     </ContentTemplate>
                    </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 111px; text-align: left; height: 22px;" class="labelcells">
                <asp:Label ID="lblseq" runat="server" Text="Sequence"></asp:Label>
            </td>
            <td style="width: 275px; text-align: left; height: 22px;" valign="top" 
                class="textcells">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
               <ContentTemplate>
                <asp:TextBox ID="txtSeq" runat="server" CssClass="textbox" Width="56px" 
                       MaxLength="10"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="Err9" runat="server" 
                   ErrorMessage="*" SetFocusOnError="True" 
                       ControlToValidate="txtSeq"></asp:RequiredFieldValidator>
                   <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" 
                       TargetControlID="txtSeq" ValidChars="1234567890">
                   </cc1:FilteredTextBoxExtender>
                </ContentTemplate>
                 </asp:UpdatePanel>
            </td>
            <td style="text-align: left; width: 104px; height: 22px;" class="labelcells">
                <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                    <ContentTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="Popup" Enabled="False" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="text-align: left; height: 22px; width: 249px;" class="textcells">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="border-left: thin groove #000000; border-top: thin groove #000000; width: 111px; text-align: left; border-bottom-width: thin; border-bottom-color: #000000; border-top-style: groove; border-bottom-style: none; border-left-style: groove;" 
                class="labelcells">
                <asp:Label ID="Label2" runat="server" Text="Upload Icon Image" Width="107px" 
                    Height="16px"></asp:Label>
            </td><td style="border-top: thin groove #000000; border-bottom: thin none #000000; width: 275px; text-align: left; "  valign="top" class="textcells">
                <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                                    <ContentTemplate><asp:FileUpload ID="FileUpload1" runat="server" CssClass="textbox" 
                    Height="22px" Width="183px" /><asp:LinkButton ID="CmdUpload" runat="server" CssClass="buttonc" 
                                            Height="22px"  Width="84px" CausesValidation="False">Upload</asp:LinkButton>
                                    </ContentTemplate><Triggers><asp:PostBackTrigger ControlID="CmdUpload" /><asp:AsyncPostBackTrigger ControlID="cmdAdd" EventName="Click" />
                                    </Triggers></asp:UpdatePanel></td><td style="border-top: thin groove #000000; border-bottom: thin none #000000; text-align: left; width: 104px; border-top-style: groove; border-bottom-style: groove;" class="labelcells" rowspan="3">
                                    <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                        <ContentTemplate>
                                            <asp:Image ID="Image2" runat="server" 
    Width="89px" Height="80px" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                               </td>
            <td style="border-right: thin groove #000000; border-top: thin groove #000000; border-bottom: thin none #000000; text-align: left; width: 249px;" 
                class="textcells">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="border-left: thin groove #000000; border-top: thin groove #000000; width: 111px; text-align: left; border-bottom-width: thin; border-bottom-color: #000000; border-top-style: none; border-bottom-style: none; border-left-style: groove;" 
                class="labelcells">
                <asp:Label ID="Label18" runat="server" Text="Path"></asp:Label>
            </td>
            <td style="border-top: thin none #000000; border-bottom: thin none #000000; width: 275px; text-align: left; " 
                valign="top" class="textcells">
                       
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtIconImage" runat="server" CssClass="textbox" MaxLength="50" 
                      Enabled="False" Width="203px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="Err8" runat="server" 
                      ControlToValidate="txtIconImage" ErrorMessage="*" 
                      SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                  </asp:UpdatePanel>
                                    
            </td>
            <td style="border-right: thin groove #000000; border-top: thin groove #000000; border-bottom: thin none #000000; text-align: left; width: 249px; border-top-style: none; border-right-style: groove; border-bottom-style: none;" 
                class="textcells">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="border-left: thin groove #000000; border-top: thin groove #000000; width: 111px; text-align: left; border-bottom-width: thin; border-bottom-color: #000000; border-top-style: none; border-bottom-style: groove; border-left-style: groove;" 
                class="labelcells">
                &nbsp;</td>
            <td style="border-top: thin none #000000; border-bottom: thin groove #000000; width: 275px; text-align: left; " 
                valign="top" class="textcells">
                &nbsp;</td>
            <td style="border-right: thin groove #000000; border-top: thin groove #000000; border-bottom: thin none #000000; text-align: left; width: 249px; border-top-style: none; border-right-style: groove; border-bottom-style: groove;" 
                class="textcells">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="font-size: 1px;">
                </td>
            <td style="width: 275px; font-size: 1px;" 
                valign="top">
                        <br/>
                                    
            </td>
            <td style="font-size: 1px;">
                </td>
            <td style="font-size: 1px;">
                </td></tr>
        <tr>
            <td style="border-left: thin groove #000000; border-top: thin groove #000000; border-bottom: thin groove #000000; width: 111px; text-align: left; border-top-style: groove; border-bottom-style: none; border-left-style: groove;" 
                class="labelcells">
                <asp:Label ID="Label23" runat="server" Text="Document Type"></asp:Label>
            </td>
            <td style="border-top: thin groove #000000; border-bottom: thin none #000000; width: 275px; text-align: left; " 
                valign="top" class="textcells">
                        <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="TxtDocType" runat="server" CssClass="textbox" MaxLength="39"></asp:TextBox>
                                <cc1:HoverMenuExtender ID="HoverMenuExtender2" runat="server" 
                                    PopupControlID="panel1" PopupPosition="Left" TargetControlID="TxtDocType">
                                </cc1:HoverMenuExtender>
                            </ContentTemplate>
                </asp:UpdatePanel>
                                    
            </td>
            <td style="border-top: thin groove #000000; border-bottom: thin groove #000000; text-align: left; width: 104px; border-top-style: groove; border-bottom-style: none;" 
                class="labelcells">
                &nbsp;</td>
            <td style="border-right: thin groove #000000; border-top: thin none #000000; border-bottom: thin none #000000; text-align: left; width: 249px; border-top-style: groove; border-right-style: groove; border-bottom-style: none;" 
                class="textcells">
                &nbsp;</td></tr>
        <tr>
            <td style="border-left: thin groove #000000; border-top: thin groove #000000; border-bottom: thin groove #000000; width: 111px; text-align: left; border-top-style: none; border-bottom-style: groove; border-left-style: groove;" 
                class="labelcells">
                <asp:Label ID="Label19" runat="server" Text="Upload Document" Width="114px"></asp:Label>
            </td>
            <td style="border-top: thin none #000000; border-bottom: thin groove #000000; width: 275px; text-align: left; " 
                valign="top">
                           <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                                    <ContentTemplate>
                                        <asp:FileUpload ID="FileUpload2" runat="server" CssClass="textbox" 
                                            Height="22px" Width="183px" Enabled="False" />
                                        <asp:LinkButton ID="CmdUpload0" runat="server" CssClass="buttonc" Height="22px" 
                                            Width="84px" CausesValidation="False">Upload</asp:LinkButton>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="CmdUpload0" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                </td><td style="border-top: thin groove #000000; border-bottom: thin groove #000000; text-align: left; width: 104px; border-top-style: none; border-bottom-style: groove;"class="labelcells">
                <asp:Label ID="Label20" runat="server" Text="Path"></asp:Label>
            </td>
            <td style="border-right: thin groove #000000; border-top: thin none #000000; border-bottom: thin none #000000; text-align: left; width: 249px; border-top-style: none; border-right-style: groove; border-bottom-style: groove;" 
                class="textcells">
                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
              <ContentTemplate>
                  <asp:TextBox ID="txtDocumentIconImage" runat="server" CssClass="textbox" 
                      MaxLength="50" Width="199px" Enabled="False"></asp:TextBox> 
                      </ContentTemplate>
                      </asp:UpdatePanel>
                
                <br /></td></tr><tr><td style="width: 111px; text-align: left;" class="labelcells">
                <asp:Label ID="lblEffFrom" runat="server" Text="Eff From"></asp:Label>
            </td>
            <td style="width: 275px; text-align: left;" class="textcells">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
              <ContentTemplate>
                       <asp:TextBox ID="txtEffFrom" runat="server" CssClass="textbox" 
                          Width="80px"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="Err1" runat="server" 
                          ControlToValidate="txtEffFrom" ErrorMessage="*" 
                          SetFocusOnError="True"></asp:RequiredFieldValidator>
                             <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
                    TargetControlID="txtEffFrom" Mask="99/99/9999" MaskType="Date" ></cc1:MaskedEditExtender><cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtEffFrom" Animated="False" Format="MM/dd/yyyy">
                </cc1:CalendarExtender>
                </ContentTemplate>
                  </asp:UpdatePanel></td>
            <td style="text-align: left; width: 104px;" class="labelcells">
                <asp:Label ID="lblEffTo" runat="server" Text="Eff To"></asp:Label>
            </td>
            <td style="text-align: left; width: 249px;" class="textcells">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                 <ContentTemplate><asp:TextBox ID="txtEffTo" runat="server" CssClass="textbox" Width="81px"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="Err2" runat="server" 
                             ControlToValidate="txtEffTo" ErrorMessage="*" 
                             SetFocusOnError="True"></asp:RequiredFieldValidator>
                         <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" 
                    TargetControlID="txtEffTo" Mask="99/99/9999" MaskType="Date">
                </cc1:MaskedEditExtender><cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEffTo" Animated="False" Format="MM/dd/yyyy"> 
                </cc1:CalendarExtender>
                 </ContentTemplate></asp:UpdatePanel></td></tr>
        <tr>
            <td style="text-align: center;" colspan="4" class="buttonbackbar">
               
                <asp:UpdatePanel ID="UpdatePanel12" runat="server" RenderMode="Inline">
                <ContentTemplate>
                <asp:LinkButton ID="cmdAdd" runat="server" CssClass="buttonc" 
                        CausesValidation="False" Height="22px" Width="84px">Add</asp:LinkButton>
                   
                <asp:LinkButton ID="cmdEdit" runat="server" CssClass="buttonc" 
                        CausesValidation="False" Height="22px" Width="84px">Edit</asp:LinkButton>
                
                    
               
                        <asp:LinkButton ID="cmdDelete" runat="server" CssClass="buttonc" 
                            style="text-align: center" CausesValidation="False" Height="22px" 
                        Width="84px">Delete</asp:LinkButton>
                   
              
                        <asp:LinkButton ID="cmdClose" runat="server" 
                            CssClass="buttonc" CausesValidation="False" Height="22px" Width="84px">Close</asp:LinkButton>
                            <asp:LinkButton ID="cmdsearch" runat="server" CssClass="buttonc" 
                    CausesValidation="False" Height="22px" Width="84px">Search</asp:LinkButton>
                    <cc1:PopupControlExtender ID="PopupExp" runat="server" 
                    CommitProperty="value" Enabled="True"
                            PopupControlID="Panel2" Position="Left" TargetControlID="CmdSearch" 
                            OffsetX="-250" OffsetY="-175"></cc1:PopupControlExtender>
                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="CmdDelete"
                            ConfirmText="Are You Sure ?"></cc1:ConfirmButtonExtender>
                   </ContentTemplate>
                    </asp:UpdatePanel>
               
                
            </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="4" class="buttonbackbar">
               
                <asp:UpdatePanel ID="Movement" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="CmdFirst" runat="server" CausesValidation="False" CssClass="buttonc"
                            Height="22px" TabIndex="5" Width="84px">First</asp:LinkButton><asp:LinkButton ID="CmdNext"
                                runat="server" CausesValidation="False" CssClass="buttonc" Height="22px" TabIndex="6"
                                Width="84px">Move Next</asp:LinkButton><asp:LinkButton ID="CmdPrevious" runat="server"
                                    CausesValidation="False" CssClass="buttonc" Height="22px" TabIndex="7" Width="84px">Move Prev</asp:LinkButton><asp:LinkButton
                                        ID="CmdLast" runat="server" CausesValidation="False" CssClass="buttonc" Height="22px"
                                        TabIndex="8" Width="84px">Last</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="4">
               
                <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                    <ContentTemplate>
                       <asp:Panel ID="Panel1" runat="server" Height="104px" Width="106px" 
                            BorderStyle="Groove" BorderColor="Black" BorderWidth="3px" 
                            Font-Names="Tahoma" Font-Size="8pt" BackColor="#ECEAEB" style="display:none"
                             >
                                                       <asp:GridView ID="GrdDocType" runat="server" BorderStyle="None" Height="52px" HorizontalAlign="Left" 
                                    OnSelectedIndexChanged="GrdDocType_SelectedIndexChanged" Width="121px" CaptionAlign="Left">
                                    <PagerSettings Visible="False" />
                                    <RowStyle HorizontalAlign="Left" /><EmptyDataRowStyle HorizontalAlign="Left" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" 
                                                    CommandName="Select"></asp:LinkButton>
                                            </ItemTemplate>
                                            <FooterStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        &nbsp;<asp:Label ID="Label5" runat="server" Text="No Data Available" Width="118px"></asp:Label>
                                    </EmptyDataTemplate>
                                    <SelectedRowStyle BackColor="Gray" />
                                    <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
                                </asp:GridView>
                                </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="4">
               
                <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel3" runat="server" Height="150px" Width="362px" ScrollBars="Auto" BorderStyle="Inset" BorderColor="Black" BorderWidth="0px" 
                            Font-Names="Tahoma" Font-Size="8pt" BackColor="#ECEAEB" 
                            style="display:none"  >
                                                       <asp:GridView ID="GridView1" runat="server" BorderStyle="None" Height="52px" HorizontalAlign="Left" 
                                    OnSelectedIndexChanged="gridview1_SelectedIndexChanged" Width="357px" CaptionAlign="Left">
                                    <PagerSettings Visible="False" />
                                    <RowStyle HorizontalAlign="Left" /><EmptyDataRowStyle HorizontalAlign="Left" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" 
                                                    CommandName="Select"></asp:LinkButton>
                                            </ItemTemplate>
                                            <FooterStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        &nbsp;<asp:Label ID="Label5" runat="server" Text="No Data Available" Width="118px"></asp:Label>
                                    </EmptyDataTemplate>
                                    <SelectedRowStyle BackColor="Gray" />
                                    <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
                                </asp:GridView>
                                </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left;" colspan="4" >
            <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                    <ContentTemplate>
                    <asp:Panel ID="Panel2" runat="server" Height="126px" Width="412px" CssClass="panelbg" 
                           ScrollBars="None" BorderStyle="Inset" BorderColor="Black" BorderWidth="0px" 
                            Font-Names="Tahoma" Font-Size="8pt" style="display:none"  > 
                            <div  id = "AdjResultsDiv"> 
                                <asp:GridView ID="GrdHelp" runat="server" BorderStyle="None" Height="52px" HorizontalAlign="Left" 
                                    OnSelectedIndexChanged="grdHelp_SelectedIndexChanged" Width="1012px" 
                                    GridLines="Both">
                                    <PagerSettings Visible="False" />
                                    <RowStyle HorizontalAlign="Justify" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" 
                                                    CommandName="Select"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        &nbsp;<asp:Label ID="Label5" runat="server" Text="No Data Available" Width="118px"></asp:Label>
                                    </EmptyDataTemplate>
                                    <SelectedRowStyle BackColor="Gray" />
                                    <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
                                </asp:GridView>
                            </div>
                    </asp:Panel> 
                 
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="4" >
                     <asp:UpdatePanel ID="MSg" runat="server">
                   <ContentTemplate>
                       <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                            FadeInDuration="2" FadeInSteps="2" FadeOutDuration="4" FadeOutSteps="2" Visible="true">
                        </uc1:FlashMessage> 
                        </ContentTemplate>
                            </asp:UpdatePanel>
                </td>
        </tr>
                
         
    </table>
</asp:Content>

