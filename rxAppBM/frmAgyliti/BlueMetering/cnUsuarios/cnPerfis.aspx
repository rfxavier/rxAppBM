<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnPerfis.aspx.cs" Inherits="rxAppBM.frmAgyliti.BlueMetering.cnUsuarios.cnPerfis" %>

<%@ Register Assembly="DevExpress.Web.v19.1, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <dx:ASPxGridView ID="GridProfiles" runat="server" Width="100%" KeyFieldName="Name" AutoGenerateColumns="False" OnDataBinding="GridProfiles_DataBinding" OnRowDeleting="GridProfiles_RowDeleting" OnRowInserting="GridProfiles_RowInserting" OnRowUpdating="GridProfiles_RowUpdating">
        <Columns>
            <dx:GridViewCommandColumn ShowEditButton="true" ShowDeleteButton="true" ShowNewButtonInHeader="true" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Caption="Id" FieldName="Id" Name="Id" Visible="true" VisibleIndex="1">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Descrição" FieldName="Name" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
        </Columns>
    </dx:ASPxGridView>
</asp:Content>
