<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridCofre.aspx.cs" Inherits="rxApp.frmRx.Agyliti.GetLock.cnCadastros.cnGridCofre" %>

<%@ Register Assembly="Microsoft.AspNet.EntityDataSource" Namespace="Microsoft.AspNet.EntityDataSource" TagPrefix="ef" %>

<%@ Register Assembly="DevExpress.Web.v19.1, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div><h4>Cadastro Cofre</h4></div>
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" DataSourceID="EntityDataSource1" KeyFieldName="id" Width="100%" EnableRowsCache="False" AutoGenerateColumns="False">
        <SettingsDataSecurity AllowInsert="true" />
        <EditFormLayoutProperties>
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="700" />
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowEditButton="True" ShowInCustomizationForm="True" VisibleIndex="0" ShowNewButtonInHeader="True" ShowDeleteButton="True"></dx:GridViewCommandColumn>
            <dx:GridViewDataColumn FieldName="id_cofre" Caption="ID Cofre" />
            <dx:GridViewDataColumn FieldName="nome" Caption="Nome" />
            <dx:GridViewDataColumn FieldName="serie" Caption="Série" />
            <dx:GridViewDataColumn FieldName="tipo" Caption="Tipo" />
            <dx:GridViewDataColumn FieldName="marca" Caption="Marca" />
            <dx:GridViewDataColumn FieldName="modelo" Caption="Modelo" />
            <dx:GridViewDataColumn FieldName="tamanho_malote" Caption="Tamanho Malote" />
            <dx:GridViewDataColumn FieldName="cod_loja" Caption="Código Loja" />
        </Columns>
        <SettingsPopup>
            <EditForm Width="600">
                <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="768" />
            </EditForm>
        </SettingsPopup>
    </dx:ASPxGridView>
    <ef:EntityDataSource ID="EntityDataSource1" runat="server" ContextTypeName="rxApp.Models.ApplicationDbContext" EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntitySetName="GetLockCofres"></ef:EntityDataSource>
</asp:Content>
