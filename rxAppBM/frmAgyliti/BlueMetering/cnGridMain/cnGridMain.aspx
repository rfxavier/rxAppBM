﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridMain.aspx.cs" Inherits="rxAppBM.frmAgyliti.BlueMetering.cnGridMain.cnGridMain" %>
<%@ MasterType VirtualPath="~/Main.master" %>
<%@ Register Assembly="DevExpress.Web.v19.1, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v19.1, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="HeadContentPlaceHolderMain" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContentPlaceHolderMain" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="updateDetails" runat="server" OnUnload="UpdatePanel_Unload">
        <ContentTemplate>
            <div><h4>Ocorrências</h4></div>
            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" OnDataBinding="ASPxGridView1_DataBinding" KeyFieldName="blueMeteringMessageId" OnAutoFilterCellEditorInitialize="ASPxGridView1_AutoFilterCellEditorInitialize" OnProcessColumnAutoFilter="ASPxGridView1_ProcessColumnAutoFilter">
                <SettingsPager PageSize="60"></SettingsPager>

                <Settings ShowHeaderFilterButton="True" ShowFilterBar="Visible" ShowFilterRow="true" ShowFilterRowMenu="true"></Settings>

                <SettingsCookies Enabled="true" />
        
                <Columns>
                    <dx:GridViewDataDateColumn FieldName="trackCreationTime" SortIndex="0" SortOrder="Descending" Caption="Data Movimento" VisibleIndex="0" Settings-FilterMode="Value">
                        <CellStyle Wrap="False"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm" EditFormatString="dd/MM/yyyy HH:mm">
                        </PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="ParamsRxTime" Caption="Rx Time" VisibleIndex="1"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="ParamsPort" Caption="Port" VisibleIndex="2"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="MetaDevice" Caption="Device" VisibleIndex="3"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="ParamsPayload" Caption="Payload" VisibleIndex="4"></dx:GridViewDataTextColumn>
                </Columns>
                <Toolbars>
                    <dx:GridViewToolbar>
                        <Items>
                            <dx:GridViewToolbarItem Command="ExportToXlsx" Text="Exportar para Excel"></dx:GridViewToolbarItem>
                            <dx:GridViewToolbarItem Command="ShowCustomizationWindow" />
                        </Items>

                        <SettingsAdaptivity Enabled="true" EnableCollapseRootItemsToIcons="true" />
                    </dx:GridViewToolbar>
                </Toolbars>
                <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" FileName="Agyliti-Bluemetering-Ocorrencias" />
                <SettingsBehavior EnableCustomizationWindow="true" />
            </dx:ASPxGridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <dx:EntityServerModeDataSource ID="EntityServerModeDataSource1" runat="server" ContextTypeName="rxApp.Models.ApplicationDbContext" TableName="BlueMeteringMessageViews" OnSelecting="EntityServerModeDataSource1_Selecting" />
</asp:Content>
