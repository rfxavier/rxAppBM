<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnUsuariosPerfis.aspx.cs" Inherits="rxAppBM.frmAgyliti.BlueMetering.cnUsuarios.cnUsuariosPerfis" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <dx:ASPxGridView ID="GridUserProfiles" runat="server" Width="100%" KeyFieldName="UserId;RoleId" AutoGenerateColumns="False" OnDataBinding="GridUserProfiles_DataBinding" OnRowDeleting="GridUserProfiles_RowDeleting" OnRowInserting="GridUserProfiles_RowInserting"  OnCommandButtonInitialize="GridUserProfiles_CommandButtonInitialize">
        <Columns>
            <dx:GridViewCommandColumn ShowEditButton="true" ShowDeleteButton="true" ShowNewButtonInHeader="true" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataComboBoxColumn FieldName="UserId" Caption="Usuário">
                <PropertiesComboBox TextField="UserName" IncrementalFilteringMode="Contains" ValueField="Id"></PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn FieldName="RoleId" Caption="Perfil">
                <PropertiesComboBox TextField="Name" IncrementalFilteringMode="Contains" ValueField="Id"></PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
        </Columns>
    </dx:ASPxGridView>

</asp:Content>
