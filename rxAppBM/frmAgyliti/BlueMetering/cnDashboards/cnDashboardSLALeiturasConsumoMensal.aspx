﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnDashboardSLALeiturasConsumoMensal.aspx.cs" Inherits="rxAppBM.frmAgyliti.BlueMetering.cnDashboards.cnDashboardSLALeiturasConsumoMensal" %>

<%@ Register Assembly="DevExpress.Dashboard.v21.1.Web.WebForms, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div style="position: absolute; left:0; right:0; top:70px; bottom:0;">
        <dx:ASPxDashboard ID="ASPxDashboard1" runat="server" WorkingMode="ViewerOnly" Width="100%" Height="100%" OnDataLoading="ASPxDashboard1_DataLoading" OnConfigureDataReloadingTimeout="ASPxDashboard1_ConfigureDataReloadingTimeout1"></dx:ASPxDashboard>
        <dx:ASPxDashboard ID="ASPxDashboard2" runat="server" WorkingMode="ViewerOnly" Width="100%" Height="100%" OnDataLoading="ASPxDashboard2_DataLoading" OnConfigureDataReloadingTimeout="ASPxDashboard2_ConfigureDataReloadingTimeout"></dx:ASPxDashboard>
    </div>
</asp:Content>