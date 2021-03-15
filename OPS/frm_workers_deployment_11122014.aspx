<%@ Page Title="" Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="frm_workers_deployment.aspx.vb" Inherits="OPS_frm_workers_deployment" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%; height: 325px;">
        <tr>
            <td style="height: 33px" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Workers Deployment"></asp:Label>
            </td>
            <td style="height: 33px">
                
                <asp:ImageButton ID="imb_close" runat="server" Height="20px" ImageAlign="Right" 
                    ImageUrl="~/Image/close24.png" />
                
            </td>
        </tr>
        <tr>
            <td style="height: 13px">
            </td>
            <td style="height: 13px; width: 622px;">
            </td>
            <td style="height: 13px">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/loading.gif" 
                            style="margin-top: 19px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td style="height: 18px">
                <asp:Label ID="Label2" runat="server" Text="From Date"></asp:Label>
            </td>
            <td style="height: 18px; width: 622px;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_fdate" runat="server" Width="70px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CE1" runat="server" TargetControlID="txt_fdate">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 18px">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnk_fetch" runat="server" 
    CssClass="buttonc">Detail</asp:LinkButton>
                        <asp:LinkButton ID="lnk_fetch_summary" runat="server" CssClass="buttonc">Summary</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="height: 5px">
                <asp:Label ID="Label3" runat="server" Text="To Date"></asp:Label>
            </td>
            <td style="height: 5px; width: 622px;">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_tdate" runat="server" Width="70px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CE2" runat="server" TargetControlID="txt_tdate">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 5px">
                <asp:LinkButton ID="lnk_excel" runat="server" CssClass="buttonc">Excel</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="height: 5px">
                &nbsp;</td>
            <td style="height: 5px; width: 622px;">
                &nbsp;</td>
            <td style="height: 5px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 5px" colspan="3">
                <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" Height="190px" 
                    Width="700px">
                    <div ID="AdjResultsDiv" 
                        style="width: 700px; height: 190px; left: -1px; top: 0px;">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="department_code" DataFormatString="{0:N2}" 
                                            HeaderText="Dept.Code" />
                                        <asp:BoundField DataField="department_name" DataFormatString="{0:N2}" 
                                            HeaderText="Dept. Name" />
                                        <asp:BoundField DataField="sub_department_code" DataFormatString="{0:N2}" 
                                            HeaderText="Sub Dept. Code" />
                                        <asp:BoundField DataField="sub_department_name" DataFormatString="{0:N2}" 
                                            HeaderText="Sub Dept. Name" />
                                        <asp:BoundField DataField="sanction_strength_g" DataFormatString="{0:N2}" 
                                            HeaderText="Sanc. Strength G" />
                                        <asp:BoundField DataField="sanction_strength_a" DataFormatString="{0:N2}" 
                                            HeaderText="Sanc. Strength A" />
                                        <asp:BoundField DataField="sanction_strength_b" DataFormatString="{0:N2}" 
                                            HeaderText="Sanc. Strength B" />
                                        <asp:BoundField DataField="sanction_strength_c" DataFormatString="{0:N2}" 
                                            HeaderText="Sanc. Strength C" />
                                        <asp:BoundField DataField="sanction_strength_total" DataFormatString="{0:N2}" 
                                            HeaderText="Sanc. Strength Total" />
                                        <asp:BoundField DataField="on_roll_total" DataFormatString="{0:N2}" 
                                            HeaderText="On Roll Total" />
                                        <asp:BoundField DataField="present_total" DataFormatString="{0:N2}" 
                                            HeaderText="Present Total" />
                                        <asp:BoundField DataField="es_total" DataFormatString="{0:N2}" 
                                            HeaderText="ES Total" />
                                        <asp:BoundField DataField="et_total" DataFormatString="{0:N2}" 
                                            HeaderText="ET Total" />
                                        <asp:BoundField DataField="spl_sanction_eset_hands_total" 
                                            DataFormatString="{0:N2}" HeaderText="Spl. ES/ET Total" />
                                        <asp:BoundField DataField="deployment_g" DataFormatString="{0:N2}" 
                                            HeaderText="Deployment G" />
                                        <asp:BoundField DataField="deployment_a" DataFormatString="{0:N2}" 
                                            HeaderText="Deployment A" />
                                        <asp:BoundField DataField="deployment_b" DataFormatString="{0:N2}" 
                                            HeaderText="Deployment B" />
                                        <asp:BoundField DataField="deployment_c" DataFormatString="{0:N2}" 
                                            HeaderText="Deployment C" />
                                        <asp:BoundField DataField="deployment_total" DataFormatString="{0:N2}" 
                                            HeaderText="Deployment Total" />
                                        <asp:BoundField DataField="trainee_total" DataFormatString="{0:N2}" 
                                            HeaderText="Trainee Total" />
                                        <asp:BoundField DataField="absent" DataFormatString="{0:N2}" 
                                            HeaderText="Absent" />
                                        <asp:BoundField DataField="absent_percent" DataFormatString="{0:N2}" 
                                            HeaderText="Absent %" />
                                        <asp:BoundField DataField="weekly_off" DataFormatString="{0:N2}" 
                                            HeaderText="Weekly off" />
                                        <asp:BoundField DataField="weekly_off_percent" DataFormatString="{0:N2}" 
                                            HeaderText="Weekly off %" />
                                        <asp:BoundField DataField="po" DataFormatString="{0:N2}" HeaderText="P. O." />
                                        <asp:BoundField DataField="lo" DataFormatString="{0:N2}" HeaderText="L. O." />
                                        <asp:BoundField DataField="total" DataFormatString="{0:N2}" 
                                            HeaderText="Total" />
                                        <asp:BoundField DataField="leaves" DataFormatString="{0:N2}" 
                                            HeaderText="Leaves" />
                                        <asp:BoundField DataField="leaves_percent" DataFormatString="{0:N2}" 
                                            HeaderText="Leaves %" />
                                        <asp:BoundField DataField="from_date" HeaderText="From Date" />
                                        <asp:BoundField DataField="to_date" HeaderText="To Date" />
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                </asp:GridView>
                                <asp:GridView ID="GridView1" runat="server" Font-Bold="False" 
                                    AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="department_code" HeaderText="Dept. Code" />
                                        <asp:BoundField DataField="department_name" HeaderText="Dept. Name" />
                                        <asp:BoundField DataField="sub_department_code" HeaderText="Sub Dept. Code" />
                                        <asp:BoundField DataField="sub_department_name" HeaderText="Sub Dept. Name" />
                                        <asp:BoundField DataField="sanction_strength_g" DataFormatString="{0:N2}" 
                                            HeaderText="Sanc. Strength G" />
                                        <asp:BoundField DataField="sanction_strength_a" DataFormatString="{0:N2}" 
                                            HeaderText="Sanc. Strength A" />
                                        <asp:BoundField DataField="sanction_strength_b" DataFormatString="{0:N2}" 
                                            HeaderText="Sanc. Strength B" />
                                        <asp:BoundField DataField="sanction_strength_c" DataFormatString="{0:N2}" 
                                            HeaderText="Sanc. Strength C" />
                                        <asp:BoundField DataField="sanction_strength_total" DataFormatString="{0:N2}" 
                                            HeaderText="Sanc. Strength Total" />
                                        <asp:BoundField DataField="on_roll_g" DataFormatString="{0:N2}" 
                                            HeaderText="On Roll G" />
                                        <asp:BoundField DataField="on_roll_a" DataFormatString="{0:N2}" 
                                            HeaderText="On Roll A" />
                                        <asp:BoundField DataField="on_roll_b" DataFormatString="{0:N2}" 
                                            HeaderText="On Roll B" />
                                        <asp:BoundField DataField="on_roll_c" DataFormatString="{0:N2}" 
                                            HeaderText="On Roll C" />
                                        <asp:BoundField DataField="on_roll_total" DataFormatString="{0:N2}" 
                                            HeaderText="On Roll Total" />
                                        <asp:BoundField DataField="present_g" DataFormatString="{0:N2}" 
                                            HeaderText="Present G" />
                                        <asp:BoundField DataField="present_a" DataFormatString="{0:N2}" 
                                            HeaderText="Present A" />
                                        <asp:BoundField DataField="present_b" DataFormatString="{0:N2}" 
                                            HeaderText="Present B" />
                                        <asp:BoundField DataField="present_c" DataFormatString="{0:N2}" 
                                            HeaderText="Present C" />
                                        <asp:BoundField DataField="present_total" DataFormatString="{0:N2}" 
                                            HeaderText="Present Total" />
                                        <asp:BoundField DataField="es_g" DataFormatString="{0:N2}" HeaderText="ES G" />
                                        <asp:BoundField DataField="es_a" DataFormatString="{0:N2}" HeaderText="ES A" />
                                        <asp:BoundField DataField="es_b" DataFormatString="{0:N2}" HeaderText="ES B" />
                                        <asp:BoundField DataField="es_c" DataFormatString="{0:N2}" HeaderText="ES C" />
                                        <asp:BoundField DataField="es_total" DataFormatString="{0:N2}" 
                                            HeaderText="ES Total" />
                                        <asp:BoundField DataField="et_g" DataFormatString="{0:N2}" HeaderText="ET G" />
                                        <asp:BoundField DataField="et_a" DataFormatString="{0:N2}" HeaderText="ET A" />
                                        <asp:BoundField DataField="et_b" DataFormatString="{0:N2}" HeaderText="ET B" />
                                        <asp:BoundField DataField="et_c" DataFormatString="{0:N2}" HeaderText="ET C" />
                                        <asp:BoundField DataField="et_total" DataFormatString="{0:N2}" 
                                            HeaderText="ET Total" />
                                        <asp:BoundField DataField="spl_sanction_eset_hours_g" DataFormatString="{0:N2}" 
                                            HeaderText="Spl. Sanc. ESET Hours G" />
                                        <asp:BoundField DataField="spl_sanction_eset_hours_a" DataFormatString="{0:N2}" 
                                            HeaderText="Spl. Sanc. ESET Hours A" />
                                        <asp:BoundField DataField="spl_sanction_eset_hours_b" DataFormatString="{0:N2}" 
                                            HeaderText="Spl. Sanc. ESET Hours B" />
                                        <asp:BoundField DataField="spl_sanction_eset_hours_c" DataFormatString="{0:N2}" 
                                            HeaderText="Spl. Sanc. ESET Hours C" />
                                        <asp:BoundField DataField="spl_sanction_eset_hours_total" 
                                            DataFormatString="{0:N2}" HeaderText="Spl. Sanc. ESET Hours Total" />
                                        <asp:BoundField DataField="spl_sanction_eset_hands_g" DataFormatString="{0:N2}" 
                                            HeaderText="Sol. Sanc. ESET Hands G" />
                                        <asp:BoundField DataField="spl_sanction_eset_hands_a" DataFormatString="{0:N2}" 
                                            HeaderText="Spl. Sanc. ESET Hands A" />
                                        <asp:BoundField DataField="spl_sanction_eset_hands_b" DataFormatString="{0:N2}" 
                                            HeaderText="Spl. Sanc. ESET Hands B" />
                                        <asp:BoundField DataField="spl_sanction_eset_hands_c" DataFormatString="{0:N2}" 
                                            HeaderText="Spl. Sanc. ESET Hands C" />
                                        <asp:BoundField DataField="spl_sanction_eset_hands_total" 
                                            DataFormatString="{0:N2}" HeaderText="Spl. Sanc. ESET Hands Total" />
                                        <asp:BoundField DataField="deployment_g" DataFormatString="{0:N2}" 
                                            HeaderText="Deployment G" />
                                        <asp:BoundField DataField="deployment_a" DataFormatString="{0:N2}" 
                                            HeaderText="Deployment A" />
                                        <asp:BoundField DataField="deployment_b" DataFormatString="{0:N2}" 
                                            HeaderText="Deployment B" />
                                        <asp:BoundField DataField="deployment_c" DataFormatString="{0:N2}" 
                                            HeaderText="Deployment C" />
                                        <asp:BoundField DataField="deployment_total" DataFormatString="{0:N2}" 
                                            HeaderText="Deployment Total" />
                                        <asp:BoundField DataField="trainee_g" DataFormatString="{0:N2}" 
                                            HeaderText="Trainee G" />
                                        <asp:BoundField DataField="trainee_a" DataFormatString="{0:N2}" 
                                            HeaderText="Trainee A" />
                                        <asp:BoundField DataField="trainee_b" DataFormatString="{0:N2}" 
                                            HeaderText="Trainee B" />
                                        <asp:BoundField DataField="trainee_c" DataFormatString="{0:N2}" 
                                            HeaderText="Trainee C" />
                                        <asp:BoundField DataField="trainee_total" DataFormatString="{0:N2}" 
                                            HeaderText="Trainee Total" />
                                        <asp:BoundField DataField="absent" DataFormatString="{0:N2}" 
                                            HeaderText="Absent" />
                                        <asp:BoundField DataField="absent_percent" DataFormatString="{0:N2}" 
                                            HeaderText="Absent %" />
                                        <asp:BoundField DataField="weekly_off" DataFormatString="{0:N2}" 
                                            HeaderText="Weekly Off" />
                                        <asp:BoundField DataField="weekly_off_percent" DataFormatString="{0:N2}" 
                                            HeaderText="Weekly Off %" />
                                        <asp:BoundField DataField="po" DataFormatString="{0:N2}" HeaderText="PO" />
                                        <asp:BoundField DataField="lo" DataFormatString="{0:N2}" HeaderText="LO" />
                                        <asp:BoundField DataField="total" DataFormatString="{0:N2}" 
                                            HeaderText="Total" />
                                        <asp:BoundField DataField="leaves" DataFormatString="{0:N2}" 
                                            HeaderText="Leaves" />
                                        <asp:BoundField DataField="leaves_percent" DataFormatString="{0:N2}" 
                                            HeaderText="Leaves %" />
                                        <asp:BoundField DataField="from_date" HeaderText="From Date" />
                                        <asp:BoundField DataField="to_date" HeaderText="To Date" />
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 622px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                    <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                         FadeInDuration="2" FadeInSteps="2" FadeOutDuration="2" FadeOutSteps="2" Visible="true" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 622px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

