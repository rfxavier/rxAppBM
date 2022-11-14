<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridHidrometro.aspx.cs" Inherits="rxAppBM.frmAgyliti.BlueMetering.cnCadastros.cnGridHidrometro" %>

<%@ Register Assembly="Microsoft.AspNet.EntityDataSource" Namespace="Microsoft.AspNet.EntityDataSource" TagPrefix="ef" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div><h4>Cadastro Hidrômetro</h4></div>
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" KeyFieldName="BlueMeteringHidrometroId" Width="100%" EnableRowsCache="False" AutoGenerateColumns="False" OnDataBinding="ASPxGridView1_DataBinding" OnRowDeleting="ASPxGridView1_RowDeleting" OnRowInserting="ASPxGridView1_RowInserting" OnRowUpdating="ASPxGridView1_RowUpdating">
        <SettingsDataSecurity AllowInsert="true" />
        <EditFormLayoutProperties>
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="700" />
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowEditButton="True" ShowInCustomizationForm="True" VisibleIndex="0" ShowNewButtonInHeader="True" ShowDeleteButton="True"></dx:GridViewCommandColumn>
            <dx:GridViewDataColumn FieldName="IdHidrometro" Caption="Id Hidrômetro" />
            <dx:GridViewDataColumn FieldName="RedeIotId" Caption="Id Rede Iot" />
            <dx:GridViewDataColumn FieldName="NumeroSerie" Caption="Número Série" />
            <dx:GridViewDataComboBoxColumn FieldName="BlueMeteringHidrometroTipoId" Caption="Tipo">
                <PropertiesComboBox TextField="Descricao" IncrementalFilteringMode="Contains" ValueField="BlueMeteringHidrometroTipoId"></PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataColumn FieldName="Capacidade" Caption="Capacidade" />
            <dx:GridViewDataColumn FieldName="NumeroSerieRelojoaria" Caption="Número Série Relojoaria" />
            <dx:GridViewDataColumn FieldName="MarcacaoInicial" Caption="Marcação Inicial" />
            <dx:GridViewDataColumn FieldName="DeviceId" Caption="ID Device" />
            <dx:GridViewDataComboBoxColumn FieldName="BlueMeteringLigacaoId" Caption="Ligação">
                <PropertiesComboBox TextField="BlueMeteringLigacaoId" IncrementalFilteringMode="Contains" ValueField="BlueMeteringLigacaoId"></PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn FieldName="BlueMeteringValvulaCorteId" Caption="Válvula Corte">
                <PropertiesComboBox TextField="NumeroSerie" IncrementalFilteringMode="Contains" ValueField="BlueMeteringValvulaCorteId"></PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
        </Columns>
        <SettingsPopup>
            <EditForm Width="600">
                <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="768" />
            </EditForm>
        </SettingsPopup>
    </dx:ASPxGridView>
</asp:Content>
