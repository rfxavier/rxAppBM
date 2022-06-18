<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridConsumidor.aspx.cs" Inherits="rxAppBM.frmAgyliti.BlueMetering.cnCadastros.cnGridConsumidor" %>

<%@ Register Assembly="Microsoft.AspNet.EntityDataSource" Namespace="Microsoft.AspNet.EntityDataSource" TagPrefix="ef" %>

<%@ Register Assembly="DevExpress.Web.v19.1, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div><h4>Cadastro Consumidor</h4></div>
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" KeyFieldName="BlueMeteringConsumidorId" Width="100%" EnableRowsCache="False" AutoGenerateColumns="False" OnDataBinding="ASPxGridView1_DataBinding" OnRowDeleting="ASPxGridView1_RowDeleting" OnRowInserting="ASPxGridView1_RowInserting" OnRowUpdating="ASPxGridView1_RowUpdating">
        <SettingsDataSecurity AllowInsert="true" />
        <EditFormLayoutProperties>
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="700" />
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowEditButton="True" ShowInCustomizationForm="True" VisibleIndex="0" ShowNewButtonInHeader="True" ShowDeleteButton="True"></dx:GridViewCommandColumn>
            <dx:GridViewDataColumn FieldName="IdConsumidor" Caption="Id Consumidor" />
            <dx:GridViewDataColumn FieldName="IdExternoConsumidor" Caption="Id Externo Consumidor" />
            <dx:GridViewDataColumn FieldName="NomeCompleto" Caption="Nome Completo" />
            <dx:GridViewDataColumn FieldName="CPF" Caption="CPF" />
            <dx:GridViewDataColumn FieldName="RG" Caption="RG" />
        </Columns>
        <SettingsPopup>
            <EditForm Width="600">
                <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="768" />
            </EditForm>
        </SettingsPopup>
    </dx:ASPxGridView>
</asp:Content>
