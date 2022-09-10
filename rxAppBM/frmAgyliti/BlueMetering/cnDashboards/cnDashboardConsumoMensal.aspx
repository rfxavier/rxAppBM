<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnDashboardConsumoMensal.aspx.cs" Inherits="rxAppBM.frmAgyliti.BlueMetering.cnDashboards.cnDashboardConsumoMensal" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Dashboard.v21.1.Web.WebForms, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <style>  
        .dxflGroup {  
            height:100%;  
        }  
    </style>  
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">

    <div style="position: absolute; left:0; right:0; top:90px; bottom:0;">
        <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ColCount="5" ColumnCount="5" Width="100%" Height="100%">
            <Items>
                <dx:LayoutItem ShowCaption="False" ColSpan="1" Visible="False">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem ShowCaption="False" ColSpan="1" Visible="False">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Data inicial" ColSpan="1" Width="16%" HorizontalAlign="Right" Visible="False">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxDateEdit ID="deStart" ClientInstanceName="deStart" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy" Width="90" runat="server">
                                <CalendarProperties>
                                    <FastNavProperties DisplayMode="Inline" />
                                </CalendarProperties>
                            </dx:ASPxDateEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right" VerticalAlign="Middle"></CaptionSettings>
                    <CaptionStyle Font-Bold="False" Font-Names="Tahoma, Geneva, sans-serif"></CaptionStyle>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Data final" ColSpan="1" Width="16%" HorizontalAlign="Right" Visible="False">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxDateEdit ID="deEnd" ClientInstanceName="deEnd" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy" Width="90" runat="server">
                                <CalendarProperties>
                                    <FastNavProperties DisplayMode="Inline" />
                                </CalendarProperties>
                                <DateRangeSettings StartDateEditID="deStart"></DateRangeSettings>
                            </dx:ASPxDateEdit>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings HorizontalAlign="Right" VerticalAlign="Middle"></CaptionSettings>
                    <CaptionStyle Font-Bold="False" Font-Names="Tahoma, Geneva, sans-serif"></CaptionStyle>
                </dx:LayoutItem>
                <dx:LayoutItem ShowCaption="False" ColSpan="1" Width="10%" HorizontalAlign="Center" Visible="False">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Aplicar filtro" OnClick="ASPxButton1_Click"></dx:ASPxButton>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem ShowCaption="False" ColSpan="5" ColumnSpan="5" Height="100%">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxDashboard runat="server" ID="ASPxDashboard1" WorkingMode="ViewerOnly" Width="100%" Height="100%" OnDataLoading="ASPxDashboard1_DataLoading" OnCustomParameters="ASPxDashboard1_CustomParameters" OnConfigureDataReloadingTimeout="ASPxDashboard1_ConfigureDataReloadingTimeout" OnSetInitialDashboardState="ASPxDashboard1_SetInitialDashboardState">
                            </dx:ASPxDashboard>

                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
            </Items>
        </dx:ASPxFormLayout>
    </div>
</asp:Content>
