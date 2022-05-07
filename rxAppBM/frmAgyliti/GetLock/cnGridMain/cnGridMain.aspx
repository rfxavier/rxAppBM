<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridMain.aspx.cs" Inherits="rxApp.frmRx.Agyliti.GetLock.cnGridMain.cnGridMain" %>
<%@ MasterType VirtualPath="~/Main.master" %>
<%@ Register Assembly="DevExpress.Web.v19.1, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v19.1, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="updateDetails" runat="server" OnUnload="UpdatePanel_Unload">
        <ContentTemplate>
            <div><h4>Ocorrências</h4></div>
            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" OnDataBinding="ASPxGridView1_DataBinding" KeyFieldName="id" OnAutoFilterCellEditorInitialize="ASPxGridView1_AutoFilterCellEditorInitialize" OnProcessColumnAutoFilter="ASPxGridView1_ProcessColumnAutoFilter">
                <SettingsPager PageSize="20"></SettingsPager>

                <Settings ShowHeaderFilterButton="True" ShowFilterBar="Visible" ShowFilterRow="true" ShowFilterRowMenu="true"></Settings>

                <SettingsCookies Enabled="true" />
        
                <Columns>
                    <dx:GridViewDataDateColumn FieldName="trackCreationTime" SortIndex="0" SortOrder="Descending" Caption="Data Movimento" VisibleIndex="0" Settings-FilterMode="Value">
                        <CellStyle Wrap="False"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm" EditFormatString="dd/MM/yyyy HH:mm">
                        </PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="id_cofre" Caption="ID Cofre" VisibleIndex="1"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cofre_nome" Caption="Nome Cofre" VisibleIndex="2"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cofre_serie" Caption="S&#233;rie Cofre" VisibleIndex="3"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cofre_tipo" Caption="Tipo Cofre" VisibleIndex="4"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cofre_marca" Caption="Marca Cofre" VisibleIndex="5"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cofre_modelo" Caption="Modelo Cofre" VisibleIndex="6"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cofre_tamanho_malote" Caption="Tamanho Malote Cofre" VisibleIndex="7"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cod_loja" Caption="C&#243;d.Loja" VisibleIndex="8"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="nome_loja" Caption="Nome Fantasia Loja" VisibleIndex="9"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="razao_social_loja" Caption="Razão Social Loja" VisibleIndex="10"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cnpj_loja" Caption="CNPJ Loja" VisibleIndex="11"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="endereco_loja" Caption="Endereço Loja" VisibleIndex="12"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="complemento_loja" Caption="Complemento Loja" VisibleIndex="13"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="bairro_loja" Caption="Bairro Loja" VisibleIndex="14"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cidade_loja" Caption="Cidade Loja" VisibleIndex="15"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="uf_loja" Caption="UF Loja" VisibleIndex="16"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cep_loja" Caption="CEP Loja" VisibleIndex="17"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="latitude_loja" Caption="Latitude Loja" VisibleIndex="18"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="longitude_loja" Caption="Longitude Loja" VisibleIndex="19"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="pessoa_contato_loja" Caption="Pessoa Contato Loja" VisibleIndex="20"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="email_loja" Caption="Email Loja" VisibleIndex="21"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="telefone_loja" Caption="Telefone Loja" VisibleIndex="22"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cod_cliente" Caption="C&#243;d.Cliente" VisibleIndex="23"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="nome_cliente" Caption="Nome Fantasia Cliente" VisibleIndex="24"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="razao_social_cliente" Caption="Razão Social Cliente" VisibleIndex="25"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cnpj_cliente" Caption="CNPJ Cliente" VisibleIndex="26"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="endereco_cliente" Caption="Endereço Cliente" VisibleIndex="27"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="complemento_cliente" Caption="Complemento Cliente" VisibleIndex="28"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="bairro_cliente" Caption="Bairro Cliente" VisibleIndex="29"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cidade_cliente" Caption="Cidade Cliente" VisibleIndex="30"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="uf_cliente" Caption="UF Cliente" VisibleIndex="31"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cep_cliente" Caption="CEP Cliente" VisibleIndex="32"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="latitude_cliente" Caption="Latitude Cliente" VisibleIndex="33"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="longitude_cliente" Caption="Longitude Cliente" VisibleIndex="34"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="pessoa_contato_cliente" Caption="Pessoa Contato Cliente" VisibleIndex="35"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="email_cliente" Caption="Email Cliente" VisibleIndex="36"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="telefone_cliente" Caption="Telefone Cliente" VisibleIndex="37"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cod_rede" Caption="C&#243;d.Rede" VisibleIndex="38"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="nome_rede" Caption="Nome Rede" VisibleIndex="39"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="info_id" Caption="ID &#218;nico Cofre" VisibleIndex="40"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="info_ip" Caption="IP" VisibleIndex="41"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="info_mac" Caption="Mac" VisibleIndex="42"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="info_json" Caption="Json" VisibleIndex="43"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_hash" Caption="Hash" VisibleIndex="44"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="data_tmst_begin_datetime" Caption="Timestamp Inicial" VisibleIndex="45">
                        <CellStyle Wrap="False"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm" EditFormatString="dd/MM/yyyy HH:mm">
                        </PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="data_tmst_end_datetime" Caption="Timestamp Final" VisibleIndex="46">
                        <CellStyle Wrap="False"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm" EditFormatString="dd/MM/yyyy HH:mm">
                        </PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="data_user" Caption="Usu&#225;rio" VisibleIndex="47"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="user_nome" Caption="Usu&#225;rio Nome" VisibleIndex="48"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_type" Caption="Movimento" VisibleIndex="49"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="movimento_nome" Caption="Movimento Nome" VisibleIndex="50"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="movimento_tipo" Caption="Movimento Tipo" VisibleIndex="51"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_total" Caption="Valor Total" VisibleIndex="52"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_bill_2" Caption="C&#233;dula R$ 2" VisibleIndex="53"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_bill_5" Caption="C&#233;dula R$ 5" VisibleIndex="54"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_bill_10" Caption="C&#233;dula R$ 10" VisibleIndex="55"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_bill_20" Caption="C&#233;dula R$ 20" VisibleIndex="56"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_bill_50" Caption="C&#233;dula R$ 50" VisibleIndex="57"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_bill_100" Caption="C&#233;dula R$ 100" VisibleIndex="58"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_bill_200" Caption="C&#233;dula R$ 200" VisibleIndex="59"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_bill_rejected" Caption="C&#233;dula Rejeitada" VisibleIndex="60"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_envelope" Caption="Envelope" VisibleIndex="61"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_envelope_total" Caption="Envelope Valor Total" VisibleIndex="62"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_bill" Caption="Quantidade de C&#233;dulas" VisibleIndex="63"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_currency_bill_total" Caption="Valor total de C&#233;dulas" VisibleIndex="64"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="data_sensor" Caption="Sensor" VisibleIndex="65"></dx:GridViewDataTextColumn>
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
                <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" FileName="Agyliti-GetLock-Ocorrencias" />
                <SettingsBehavior EnableCustomizationWindow="true" />
            </dx:ASPxGridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <dx:EntityServerModeDataSource ID="EntityServerModeDataSource1" runat="server" ContextTypeName="rxApp.Models.ApplicationDbContext" TableName="GetLockMessageViews" OnSelecting="EntityServerModeDataSource1_Selecting" />
</asp:Content>