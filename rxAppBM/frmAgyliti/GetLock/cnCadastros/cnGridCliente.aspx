<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridCliente.aspx.cs" Inherits="rxApp.frmAgyliti.GetLock.cnCadastros.cnGridCliente" %>

<%@ Register Assembly="Microsoft.AspNet.EntityDataSource" Namespace="Microsoft.AspNet.EntityDataSource" TagPrefix="ef" %>

<%@ Register Assembly="DevExpress.Web.v19.1, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div><h4>Cadastro Cliente</h4></div>
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" KeyFieldName="id" Width="100%" EnableRowsCache="False" AutoGenerateColumns="False" OnDataBinding="ASPxGridView1_DataBinding" OnRowDeleting="ASPxGridView1_RowDeleting" OnRowInserting="ASPxGridView1_RowInserting" OnRowUpdating="ASPxGridView1_RowUpdating">
        <SettingsDataSecurity AllowInsert="true" />
        <EditFormLayoutProperties>
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="700" />
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowEditButton="True" ShowInCustomizationForm="True" VisibleIndex="0" ShowNewButtonInHeader="True" ShowDeleteButton="True"></dx:GridViewCommandColumn>
            <dx:GridViewDataColumn FieldName="cod_cliente" Caption="Código Cliente" />
            <dx:GridViewDataColumn FieldName="nome" Caption="Nome Fantasia" />
            <dx:GridViewDataComboBoxColumn FieldName="cod_rede" Caption="Rede">
                <PropertiesComboBox TextField="nome" IncrementalFilteringMode="Contains" ValueField="cod_rede"></PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataColumn FieldName="razao_social" Caption="Razão Social" />
            <dx:GridViewDataColumn FieldName="cnpj" Caption="CNPJ" />
            <dx:GridViewDataColumn FieldName="endereco" Caption="Endereço" />
            <dx:GridViewDataColumn FieldName="complemento" Caption="Complemento" />
            <dx:GridViewDataColumn FieldName="bairro" Caption="Bairro" />
            <dx:GridViewDataColumn FieldName="cidade" Caption="Cidade" />
            <dx:GridViewDataColumn FieldName="uf" Caption="UF" />
            <dx:GridViewDataColumn FieldName="CEP" Caption="CEP" />
            <dx:GridViewDataColumn FieldName="latitude" Caption="Latitude" />
            <dx:GridViewDataColumn FieldName="longitude" Caption="Longitude" />
            <dx:GridViewDataColumn FieldName="pessoa_contato" Caption="Pessoa Contato" />
            <dx:GridViewDataColumn FieldName="email" Caption="Email" />
        </Columns>
        <SettingsPopup>
            <EditForm Width="600">
                <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="768" />
            </EditForm>
        </SettingsPopup>
    </dx:ASPxGridView>
</asp:Content>
