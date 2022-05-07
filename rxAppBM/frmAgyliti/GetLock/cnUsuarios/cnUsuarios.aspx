<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnUsuarios.aspx.cs" Inherits="rxApp.frmAgyliti.GetLock.cnUsuarios.cnUsuarios" %>

<%@ Register Assembly="DevExpress.Web.v19.1, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <dx:ASPxGridView ID="GridUsers" runat="server" KeyFieldName="Id" AutoGenerateColumns="False" OnDataBinding="GridUsers_DataBinding" OnRowDeleting="GridUsers_RowDeleting" OnRowInserting="GridUsers_RowInserting" OnRowUpdating="GridUsers_RowUpdating" OnStartRowEditing="GridUsers_StartRowEditing">
        <Columns>
            <dx:GridViewCommandColumn ShowEditButton="true" ShowDeleteButton="true" ShowNewButtonInHeader="true" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Caption="Id" FieldName="Id" Name="Id" Visible="true" VisibleIndex="1">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Usuário" FieldName="UserName" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Senha" FieldName="PasswordHash" VisibleIndex="3">
                <PropertiesTextEdit Password="True" ClientInstanceName="psweditor">
                </PropertiesTextEdit>
                <EditItemTemplate>
                    <dx:ASPxTextBox ID="pswtextbox" runat="server" Text='<%# Bind("PasswordHash") %>'
                        Visible='<%# GridUsers.IsNewRowEditing %>' Password="True">
                        <ClientSideEvents Validation="function(s,e){e.isValid = s.GetText()>5;}" />
                    </dx:ASPxTextBox>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="popup.ShowAtElement(this); return false;" Visible='<%#!GridUsers.IsNewRowEditing%>'>Editar senha</asp:LinkButton>
                </EditItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn FieldName="GetLockLojaId" Caption="Loja" VisibleIndex="4">
                <PropertiesComboBox TextField="nome" IncrementalFilteringMode="Contains" ValueField="GetLockLojaId"></PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
        </Columns>
    </dx:ASPxGridView>
    <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" HeaderText="Editar senha" Width="307px" ClientInstanceName="popup">
        <ContentCollection>
            <dx:PopupControlContentControl ID="Popupcontrolcontentcontrol1" runat="server">
                <table>
                    <tr>
                        <td>Senha atual:</td>
                        <td>
                            <dx:ASPxTextBox ID="cpsw" runat="server" Password="True" ClientInstanceName="cpsw">
                                <ClientSideEvents Validation="function(s, e) {e.isValid = (s.GetText().length&gt;5)}" />
                                <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ErrorText="The password length should be more that 6 symbols">
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Nova senha:</td>
                        <td>
                            <dx:ASPxTextBox ID="npsw" runat="server" Password="True" ClientInstanceName="npsw">
                                <ClientSideEvents Validation="function(s, e) {e.isValid = (s.GetText().length&gt;5)}" />
                                <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ErrorText="The password length should be more that 6 symbols">
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                </table>
                <dx:ASPxButton ID="confirmButton" runat="server" Text="Ok" AutoPostBack="False" OnClick="confirmButton_Click">
                </dx:ASPxButton>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Content>
